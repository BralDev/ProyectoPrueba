using ProyectoPrueba.Datos.Entidades;
using ProyectoPrueba.Datos.Interfaces;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ProyectoPrueba.Presentacion
{
    public partial class Form2 : Form
    {
        private IProductoRepositorio repositorio;

        private int id, stock;
        private String nombre, descripcion;
        private decimal precio;

        public Form2(IProductoRepositorio servicio)
        {
            InitializeComponent();
            this.repositorio = servicio;
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

            int confirmacion = repositorio.deleteProducto(id);

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

            Producto producto = new Producto
            {
                Nombre = nombre,
                Descripcion = descripcion,
                Precio = precio,
                Stock = stock
            };

            int confirmacion = repositorio.createProducto(producto);

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

            Producto producto = new Producto
            {
                Id = id,
                Nombre = nombre,
                Descripcion = descripcion,
                Precio = precio,
                Stock = stock
            };
      
            int confirmacion = repositorio.updateProducto(producto);

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
            grdProd.Columns["Id"].DataPropertyName = "Id";

            grdProd.Columns.Add("Nombre", "Nombre");
            grdProd.Columns["Nombre"].DataPropertyName = "Nombre";

            grdProd.Columns.Add("Descripcion", "Descripcion");
            grdProd.Columns["Descripcion"].DataPropertyName = "Descripcion";

            grdProd.Columns.Add("Precio", "Precio");
            grdProd.Columns["Precio"].DataPropertyName = "Precio";

            grdProd.Columns.Add("Stock", "Stock");
            grdProd.Columns["Stock"].DataPropertyName = "Stock";

            grdProd.Columns.Add("Creado", "Creado");
            grdProd.Columns["Creado"].DataPropertyName = "CreadoEn";

            List<Producto> listaLlena = repositorio.listProducto();

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
