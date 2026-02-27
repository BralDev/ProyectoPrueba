using Negocio.Esquemas;
using Negocio.Gestores;
using System;
using Transversal;
using System.Windows.Forms;

namespace ProyectoPrueba.Vistas
{
    public partial class Form1 : Form
    {
      
        private GestorProducto productoGestor;

        private int id, stock;
        private String nombre, descripcion;
        private decimal precio;

        public Form1()
        {
            InitializeComponent();
            this.productoGestor = new GestorProducto();
            //CargarProductos();
            txtId.Enabled = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
        }

        private void cmbElimin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtId.Text))
            {
                MessageBox.Show("El id es obligatorio");
                txtNombre.Focus();
                return;
            }

            this.id = Convert.ToInt32(txtId.Text);

            int confirmacion = this.productoGestor.mxEliminarProducto(id);

            if (confirmacion > 0)
            {
                MessageBox.Show("Se ha eliminado el producto " + id);
                LimpiarCampos();
                CargarProductos();
            }
            else
            {
                MessageBox.Show("No hay conexion en la BD");
            }

        }

        private void cmbInsert_Click(object sender, EventArgs e)
        {

            if (!ValidarFormulario())
                return;

            this.nombre = txtNombre.Text;
            this.descripcion = txtDescrip.Text;
            this.precio = Convert.ToDecimal(txtPrecio.Text);
            this.stock = Convert.ToInt32(txtStock.Text);

            ProductCreateDto producto = new ProductCreateDto
            {
                cNomPro = this.nombre,
                cDesPro = this.descripcion,
                nPrePro = this.precio,
                nStoPro = this.stock
            };

            int confirmacion = this.productoGestor.mxCrearProducto(producto);

            if (confirmacion > 0)
            {
                MessageBox.Show("Se ha creado un producto");
                LimpiarCampos();
                CargarProductos();
            }
            else
            {
                MessageBox.Show("No hay conexion en la BD");
            }
        }

        private void cmbListar_Click(object sender, EventArgs e)
        {
            CargarProductos();
            MessageBox.Show(Constantes._M_CARGA_REGISTRO);
        }
        private void cmbEditar_Click(object sender, EventArgs e)
        {
            if (!ValidarFormulario())
                return;

            this.id = Convert.ToInt32(txtId.Text);
            this.nombre = txtNombre.Text;
            this.descripcion = txtDescrip.Text;
            this.precio = Convert.ToDecimal(txtPrecio.Text);
            this.stock = Convert.ToInt32(txtStock.Text);

            ProductUpdateDto producto = new ProductUpdateDto
            {
                nIdePro = this.id,
                cNomPro = this.nombre,
                cDesPro = this.descripcion,
                nPrePro = this.precio,
                nStoPro = this.stock
            };

            int confirmacion = this.productoGestor.mxActualizarProducto(producto);

            if (confirmacion > 0)
            {
                MessageBox.Show("Se ha actualizado el producto " + this.id);
                LimpiarCampos();
                CargarProductos();
            }
            else
            {
                MessageBox.Show("No hay conexion en la BD");
            }
        }

        private void grdProd_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            LimpiarCampos();
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = grdProd.Rows[e.RowIndex];

                txtId.Text = fila.Cells["Id"].Value.ToString();
                txtNombre.Text = fila.Cells["Nombre"].Value.ToString();
                txtDescrip.Text = fila.Cells["Descripcion"].Value.ToString();
                txtPrecio.Text = fila.Cells["Precio"].Value.ToString();
                txtStock.Text = fila.Cells["Stock"].Value.ToString();
            }
        }

        private void CargarProductos()
        {
            grdProd.AutoGenerateColumns = false;

            grdProd.Columns.Clear();

            grdProd.Columns.Add("Id", "ID");
            grdProd.Columns["Id"].DataPropertyName = "nIdePro";

            grdProd.Columns.Add("Nombre", "Nombre");
            grdProd.Columns["Nombre"].DataPropertyName = "cNomPro";

            grdProd.Columns.Add("Descripcion", "Descripcion");
            grdProd.Columns["Descripcion"].DataPropertyName = "cDesPro";

            grdProd.Columns.Add("Precio", "Precio");
            grdProd.Columns["Precio"].DataPropertyName = "nPrePro";

            grdProd.Columns.Add("Stock", "Stock");
            grdProd.Columns["Stock"].DataPropertyName = "nStoPro";

            grdProd.Columns.Add("Creado", "Creado");
            grdProd.Columns["Creado"].DataPropertyName = "tFecPro";

            ProductosRPT listaLlena = this.productoGestor.mxObtenerProductos();

            if (listaLlena.paProductos.Length == 0)
            {
                MessageBox.Show(Constantes._M_RECURSO_NO_EXISTENTE);
            }          
            grdProd.DataSource = listaLlena;                       
        }

        private void LimpiarCampos()
        {
            txtId.Clear();
            txtNombre.Clear();
            txtDescrip.Clear();
            txtPrecio.Clear();
            txtStock.Clear();
            txtNombre.Focus();
        }


        private void cmbLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private bool ValidarFormulario()
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("El nombre es obligatorio");
                txtNombre.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtDescrip.Text))
            {
                MessageBox.Show("La descripción es obligatoria");
                txtDescrip.Focus();
                return false;
            }

            if (!decimal.TryParse(txtPrecio.Text, out decimal precio))
            {
                MessageBox.Show("Ingrese un precio válido");
                txtPrecio.Focus();
                return false;
            }

            if (precio <= 0)
            {
                MessageBox.Show("El precio debe ser mayor que 0");
                txtPrecio.Focus();
                return false;
            }

            if (!int.TryParse(txtStock.Text, out int stock))
            {
                MessageBox.Show("Ingrese un stock válido");
                txtStock.Focus();
                return false;
            }

            if (stock < 0)
            {
                MessageBox.Show("El stock no puede ser negativo");
                txtStock.Focus();
                return false;
            }
            return true;
        }
    }
}
