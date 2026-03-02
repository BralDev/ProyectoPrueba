using System;
using Transversal;
using System.Windows.Forms;
using ReferenciaServicios.WRGestionProductos;

namespace ProyectoPrueba.Vistas
{
    public partial class GestionProductoCP : Form
    {

        private WSGestionProductos loRefGestProdCR;

        private int lnIdePro, lnStoPro;
        private String lcNomPro, lcDescPro;
        private decimal lnPrePro;

        public GestionProductoCP()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Text = "Sistema de Gestión de Productos - invmpro";

            this.loRefGestProdCR = new WSGestionProductos();            
            txtId.Enabled = false;                        
            mxCargProds();
        }

        private void cmbElimin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtId.Text))
            {
                MessageBox.Show("El id es obligatorio");
                txtNombre.Focus();
                return;
            }

            this.lnIdePro = Convert.ToInt32(txtId.Text);

            int lnConfirmacion = this.loRefGestProdCR.mxEliminarProducto(this.lnIdePro);

            if (lnConfirmacion > 0)
            {
                MessageBox.Show("Se ha eliminado el producto " + this.lnIdePro);
                mxLimpCamp();
                mxCargProds();
            }
            else
            {
                MessageBox.Show("No se ha podido eliminar el producto");
            }
        }

        private void cmbInsert_Click(object sender, EventArgs e)
        {
            if (!mxValForm())
                return;

            this.lcNomPro = txtNombre.Text;
            this.lcDescPro = txtDescrip.Text;
            this.lnPrePro = Convert.ToDecimal(txtPrecio.Text);
            this.lnStoPro = Convert.ToInt32(txtStock.Text);

            ProductoCrearRQT loProCreRQT = new ProductoCrearRQT
            {                
                pcNomPro = this.lcNomPro,
                pcDesPro = this.lcDescPro,
                pnPrePro = this.lnPrePro,
                pnStoPro = this.lnStoPro
            };

            ProductoCrearRPT loProCreRPT = this.loRefGestProdCR.mxCrearProducto(loProCreRQT);

            if (loProCreRPT != null)
            {
                MessageBox.Show("Se ha creado un producto");
                mxLimpCamp();
                mxCargProds();
            }
            else
            {
                MessageBox.Show("No se ha podido crear el producto");
            }
        }
        private void cmbListar_Click(object sender, EventArgs e)
        {
            mxCargProds();
            MessageBox.Show(Constantes._M_CARGA_REGISTRO);
        }
        private void cmbEditar_Click(object sender, EventArgs e)
        {
            if (!mxValForm())
                return;

            this.lnIdePro = Convert.ToInt32(txtId.Text);
            this.lcNomPro = txtNombre.Text;
            this.lcDescPro = txtDescrip.Text;
            this.lnPrePro = Convert.ToDecimal(txtPrecio.Text);
            this.lnStoPro = Convert.ToInt32(txtStock.Text);

            ProductoActualizarRQT loProActRQT = new ProductoActualizarRQT
            {
                pnIdePro = this.lnIdePro,
                pcNomPro = this.lcNomPro,
                pcDesPro = this.lcDescPro,
                pnPrePro = this.lnPrePro,
                pnStoPro = this.lnStoPro
            };

            ProductoActualizarRPT loProActRPT = this.loRefGestProdCR.mxActualizarProducto(loProActRQT);

            if (loProActRPT != null)
            {
                MessageBox.Show("Se ha actualizado el producto " + this.lnIdePro);
                mxLimpCamp();
                mxCargProds();
            }
            else
            {
                MessageBox.Show("No se ha podido actualizar el producto");
            }
        }

        private void grdProd_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            mxLimpCamp();
            if (e.RowIndex >= 0)
            {
                DataGridViewRow loFila = grdProd.Rows[e.RowIndex];

                txtId.Text = loFila.Cells["Id"].Value.ToString();
                txtNombre.Text = loFila.Cells["Nombre"].Value.ToString();
                txtDescrip.Text = loFila.Cells["Descripcion"].Value.ToString();
                txtPrecio.Text = loFila.Cells["Precio"].Value.ToString();
                txtStock.Text = loFila.Cells["Stock"].Value.ToString();
            }
        }

        private void mxCargProds()
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

            ProductosListRPT loProLstRPT = this.loRefGestProdCR.mxObtenerProductos();

            if (loProLstRPT.paProductos.Length == 0)
            {
                MessageBox.Show(Constantes._M_RECURSO_NO_EXISTENTE);
            }
            grdProd.DataSource = loProLstRPT.paProductos;
        }
        private void mxLimpCamp()
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
            mxLimpCamp();
        }

        private bool mxValForm()
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