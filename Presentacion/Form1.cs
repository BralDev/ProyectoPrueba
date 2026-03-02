using System;
using Transversal;
using System.Windows.Forms;
using ReferenciaServicios.WRGestionProductos;

namespace ProyectoPrueba.Vistas
{
    public partial class Form1 : Form
    {

        private WSGestionProductos referenciaServicio;

        private int id, stock;
        private String nombre, descripcion;
        private decimal precio;

        public Form1()
        {
            InitializeComponent();
            this.referenciaServicio = new WSGestionProductos();            
            txtId.Enabled = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            CargarProductos();
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

            int confirmacion = this.referenciaServicio.EliminarProducto(this.id);

            if (confirmacion > 0)
            {
                MessageBox.Show("Se ha eliminado el producto " + id);
                LimpiarCampos();
                CargarProductos();
            }
            else
            {
                MessageBox.Show("No se ha podido eliminar el producto");
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

            ProductoCrearRQT producto = new ProductoCrearRQT
            {                
                pcNomPro = this.nombre,
                pcDesPro = this.descripcion,
                pnPrePro = this.precio,
                pnStoPro = this.stock                
            };

            ProductoCrearRPT confirmacion = this.referenciaServicio.CrearProducto(producto);

            if (confirmacion != null)
            {
                MessageBox.Show("Se ha creado un producto");
                LimpiarCampos();
                CargarProductos();
            }
            else
            {
                MessageBox.Show("No se ha podido crear el producto");
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

            ProductoActualizarRQT producto = new ProductoActualizarRQT
            {
                pnIdePro = this.id,
                pcNomPro = this.nombre,
                pcDesPro = this.descripcion,
                pnPrePro = this.precio,
                pnStoPro = this.stock
            };

            ProductoActualizarRPT confirmacion = this.referenciaServicio.ActualizarProducto(producto);

            if (confirmacion != null)
            {
                MessageBox.Show("Se ha actualizado el producto " + this.id);
                LimpiarCampos();
                CargarProductos();
            }
            else
            {
                MessageBox.Show("No se ha podido actualizar el producto");
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
            grdProd.Columns["Id"].DataPropertyName = "pnIdePro";

            grdProd.Columns.Add("Nombre", "Nombre");
            grdProd.Columns["Nombre"].DataPropertyName = "pcNomPro";

            grdProd.Columns.Add("Descripcion", "Descripcion");
            grdProd.Columns["Descripcion"].DataPropertyName = "pcDesPro";

            grdProd.Columns.Add("Precio", "Precio");
            grdProd.Columns["Precio"].DataPropertyName = "pnPrePro";

            grdProd.Columns.Add("Stock", "Stock");
            grdProd.Columns["Stock"].DataPropertyName = "pnStoPro";

            grdProd.Columns.Add("Creado", "Creado");
            grdProd.Columns["Creado"].DataPropertyName = "ptFecPro";

            ProductosListRPT listaLlena = this.referenciaServicio.ListarProductos();

            if (listaLlena.paProductos.Length == 0)
            {
                MessageBox.Show(Constantes._M_RECURSO_NO_EXISTENTE);
            }
            grdProd.DataSource = listaLlena.paProductos;
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