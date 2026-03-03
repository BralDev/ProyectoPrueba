using System;
using Transversal;
using System.Windows.Forms;
using ReferenciaServicios.WRGestionProductos;

namespace ProyectoPrueba.Vistas
{
    public partial class GestionProductoCP : Form
    {

        public GestionProductoCP()
        {
            InitializeComponent();            
        }

        private void cmbElimin_Click(object sender, EventArgs e)
        {            
            WSGestionProductos loRefGestProdCR = new WSGestionProductos();
            ProductoEliminarRQT productoEliminarRQT = new ProductoEliminarRQT();

            if (string.IsNullOrWhiteSpace(txnIdePro.Text))
            {
                MessageBox.Show("El id de producto es obligatorio");
                txcNomPro.Focus();
                return;
            }

            productoEliminarRQT.pnIdePro = Convert.ToInt32(txnIdePro.Text);

            ProductoEliminarRPT loConfirmacion = loRefGestProdCR.wmEliminarProducto(productoEliminarRQT);

            if (loConfirmacion.pnIdePro > 0)
            {
                MessageBox.Show("Se ha eliminado el producto " + productoEliminarRQT.pnIdePro);
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
            int lnIdeSed, lnStoPro;
            decimal lnPrePro;
            string lcNomPro, lcDescPro;
            WSGestionProductos loRefGestProdCR = new WSGestionProductos();

            if (!mxValForm())
                return;
                        
            lcNomPro = txcNomPro.Text;
            lcDescPro = txcDesPro.Text;
            lnPrePro = Convert.ToDecimal(txnPrePro.Text);
            lnStoPro = Convert.ToInt32(txnStoPro.Text);
            lnIdeSed = Convert.ToInt32(txnIdeSed.Text);

            ProductoCrearRQT loProCreRQT = new ProductoCrearRQT
            {                
                pcNomPro = lcNomPro,
                pcDesPro = lcDescPro,
                pnPrePro = lnPrePro,
                pnStoPro = lnStoPro,
                pnIdeSed = lnIdeSed
            };

            ProductoCrearRPT loProCreRPT = loRefGestProdCR.wmCrearProducto(loProCreRQT);

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
            int lnIdePro, lnStoPro, lnIdeSed;
            decimal lnPrePro;
            string lcNomPro, lcDescPro;
            WSGestionProductos loRefGestProdCR = new WSGestionProductos();

            if (!mxValForm())
                return;

            lnIdePro = Convert.ToInt32(txnIdePro.Text);
            lcNomPro = txcNomPro.Text;
            lcDescPro = txcDesPro.Text;
            lnPrePro = Convert.ToDecimal(txnPrePro.Text);
            lnStoPro = Convert.ToInt32(txnStoPro.Text);
            lnIdeSed = Convert.ToInt32(txnIdeSed.Text);

            ProductoActualizarRQT loProActRQT = new ProductoActualizarRQT
            {
                pnIdePro = lnIdePro,
                pcNomPro = lcNomPro,
                pcDesPro = lcDescPro,
                pnPrePro = lnPrePro,
                pnStoPro = lnStoPro,
                pnIdeSed = lnIdeSed
            };

            ProductoActualizarRPT loProActRPT = loRefGestProdCR.wmActualizarProducto(loProActRQT);

            if (loProActRPT != null)
            {
                MessageBox.Show("Se ha actualizado el producto " + lnIdePro);
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
            WSGestionProductos loRefGestProdCR = new WSGestionProductos();
            ProductosListRPT loProLstRPT = loRefGestProdCR.wmObtenerProductos();
            if (e.RowIndex >= 0)
            {               
                txnIdePro.Text = loProLstRPT.paProductos[e.RowIndex].pnIdePro.ToString();
                txcNomPro.Text = loProLstRPT.paProductos[e.RowIndex].pcNomPro;
                txcDesPro.Text = loProLstRPT.paProductos[e.RowIndex].pcDesPro;
                txnPrePro.Text = loProLstRPT.paProductos[e.RowIndex].pnPrePro.ToString();
                txnStoPro.Text = loProLstRPT.paProductos[e.RowIndex].pnStoPro.ToString();
                txnIdeSed.Text = loProLstRPT.paProductos[e.RowIndex].pnIdeSed.ToString();
            }
        }

        private void mxCargProds()
        {            
            WSGestionProductos loRefGestProdCR = new WSGestionProductos();
            ProductosListRPT loProLstRPT = loRefGestProdCR.wmObtenerProductos();

            if (loProLstRPT.paProductos.Length == 0)
            {
                MessageBox.Show(Constantes._M_RECURSO_NO_EXISTENTE);
            }
            grdProd.DataSource = loProLstRPT.paProductos;
        }

        private void GestionProductoCP_Load(object sender, EventArgs e)
        {
            mxCargProds();
        }

        private void mxLimpCamp()
        {
            txnIdePro.Clear();
            txcNomPro.Clear();
            txcDesPro.Clear();
            txnPrePro.Clear();
            txnStoPro.Clear();
            txnIdeSed.Clear();
            txcNomPro.Focus();
        }

        private void cmbLimpiar_Click(object sender, EventArgs e)
        {
            mxLimpCamp();
        }

        private bool mxValForm()
        {
            if (string.IsNullOrWhiteSpace(txcNomPro.Text))
            {
                MessageBox.Show("El nombre es obligatorio");
                txcNomPro.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txcDesPro.Text))
            {
                MessageBox.Show("La descripción es obligatoria");
                txcDesPro.Focus();
                return false;
            }

            if (!decimal.TryParse(txnPrePro.Text, out decimal precio))
            {
                MessageBox.Show("Ingrese un precio válido");
                txnPrePro.Focus();
                return false;
            }

            if (precio <= 0)
            {
                MessageBox.Show("El precio debe ser mayor que 0");
                txnPrePro.Focus();
                return false;
            }

            if (!int.TryParse(txnStoPro.Text, out int stock))
            {
                MessageBox.Show("Ingrese un stock válido");
                txnStoPro.Focus();
                return false;
            }

            if (stock < 0)
            {
                MessageBox.Show("El stock no puede ser negativo");
                txnStoPro.Focus();
                return false;
            }

            if (!int.TryParse(txnIdeSed.Text, out int idSede))
            {
                MessageBox.Show("Ingrese un stock válido");
                txnStoPro.Focus();
                return false;
            }

            if (idSede < 0)
            {
                MessageBox.Show("El stock no puede ser negativo");
                txnStoPro.Focus();
                return false;
            }
            return true;
        }
    }
}