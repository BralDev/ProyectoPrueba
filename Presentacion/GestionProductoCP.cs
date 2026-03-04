using System;
using Transversal;
using System.Windows.Forms;
using ReferenciaServicios.WRGestionProductos;
using System.Linq;

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
            ProductoEliminarRQT loProEliRQT = new ProductoEliminarRQT();

            if (string.IsNullOrWhiteSpace(this.txnIdePro.Text))
            {
                MessageBox.Show("El id de producto es obligatorio");
                txcNomPro.Focus();
                return;
            }

            loProEliRQT.pnIdePro = Convert.ToInt32(this.txnIdePro.Text);

            ProductoEliminarRPT loProEliRPT = loRefGestProdCR.wmEliminarProducto(loProEliRQT);

            if (loProEliRPT.Code == 200)
            {
                mxLimpCamp();
                mxCargProds();
            }
            MessageBox.Show(loProEliRPT.Message);
        }

        private void cmbInsert_Click(object sender, EventArgs e)
        {
            int lnIdeSed, lnStoPro;
            decimal lnPrePro;
            string lcNomPro, lcDescPro;
            WSGestionProductos loRefGestProdCR = new WSGestionProductos();

            if (!mxValForm())
                return;
                        
            lcNomPro = this.txcNomPro.Text;
            lcDescPro = this.txcDesPro.Text;
            lnPrePro = Convert.ToDecimal(this.txnPrePro.Text);
            lnStoPro = Convert.ToInt32(this.txnStoPro.Text);
            lnIdeSed = Convert.ToInt32(this.txnIdeSed.Text);

            ProductoCrearRQT loProCreRQT = new ProductoCrearRQT
            {                
                pcNomPro = lcNomPro,
                pcDesPro = lcDescPro,
                pnPrePro = lnPrePro,
                pnStoPro = lnStoPro,
                pnIdeSed = lnIdeSed
            };

            ProductoCrearRPT loProCreRPT = loRefGestProdCR.wmCrearProducto(loProCreRQT);

            if (loProCreRPT.Code == 201)
            {                
                mxLimpCamp();
                mxCargProds();
            }
            MessageBox.Show(loProCreRPT.Message);
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

            lnIdePro = Convert.ToInt32(this.txnIdePro.Text);
            lcNomPro = this.txcNomPro.Text;
            lcDescPro = this.txcDesPro.Text;
            lnPrePro = Convert.ToDecimal(this.txnPrePro.Text);
            lnStoPro = Convert.ToInt32(this.txnStoPro.Text);
            lnIdeSed = Convert.ToInt32(this.txnIdeSed.Text);

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

            if (loProActRPT.Code == 200)
            {                
                mxLimpCamp();
                mxCargProds();
            }
            MessageBox.Show(loProActRPT.Message);
        }

        private void grdProd_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            mxLimpCamp();
            WSGestionProductos loRefGestProdCR = new WSGestionProductos();
            ProductosListRPT loProLstRPT = loRefGestProdCR.wmObtenerProductos();
            if (e.RowIndex >= 0)
            {               
                this.txnIdePro.Text = loProLstRPT.paProductos[e.RowIndex].pnIdePro.ToString();
                this.txcNomPro.Text = loProLstRPT.paProductos[e.RowIndex].pcNomPro;
                this.txcDesPro.Text = loProLstRPT.paProductos[e.RowIndex].pcDesPro;
                this.txnPrePro.Text = loProLstRPT.paProductos[e.RowIndex].pnPrePro.ToString();
                this.txnStoPro.Text = loProLstRPT.paProductos[e.RowIndex].pnStoPro.ToString();
                this.txnIdeSed.Text = loProLstRPT.paProductos[e.RowIndex].pnIdeSed.ToString();
            }
        }

        private void mxCargProds()
        {            
            WSGestionProductos loRefGestProdCR = new WSGestionProductos();
            ProductosListRPT loProLstRPT = loRefGestProdCR.wmObtenerProductos();

            if (loProLstRPT.Code == 200)
            {
                grdProd.DataSource = loProLstRPT.paProductos;
            }
            else
            {
                MessageBox.Show(loProLstRPT.Message);
            }                
        }

        private void GestionProductoCP_Load(object sender, EventArgs e)
        {
            mxCargProds();
        }

        private void mxLimpCamp()
        {
            this.txnIdePro.Clear();
            this.txcNomPro.Clear();
            this.txcDesPro.Clear();
            this.txnPrePro.Clear();
            this.txnStoPro.Clear();
            this.txnIdeSed.Clear();
            this.txcNomPro.Focus();
        }

        private void cmbLimpiar_Click(object sender, EventArgs e)
        {
            mxLimpCamp();
        }

        private bool mxValForm()
        {
            if (string.IsNullOrWhiteSpace(this.txcNomPro.Text))
            {
                MessageBox.Show("El nombre es obligatorio");
                this.txcNomPro.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(this.txcDesPro.Text))
            {
                MessageBox.Show("La descripción es obligatoria");
                this.txcDesPro.Focus();
                return false;
            }

            if (!decimal.TryParse(this.txnPrePro.Text, out decimal precio))
            {
                MessageBox.Show("Ingrese un precio válido");
                this.txnPrePro.Focus();
                return false;
            }

            if (precio <= 0)
            {
                MessageBox.Show("El precio debe ser mayor que 0");
                this.txnPrePro.Focus();
                return false;
            }

            if (!int.TryParse(this.txnStoPro.Text, out int stock))
            {
                MessageBox.Show("Ingrese un stock válido");
                this.txnStoPro.Focus();
                return false;
            }

            if (stock < 0)
            {
                MessageBox.Show("El stock no puede ser negativo");
                this.txnStoPro.Focus();
                return false;
            }

            if (!int.TryParse(this.txnIdeSed.Text, out int idSede))
            {
                MessageBox.Show("Ingrese una sede válida");
                this.txnIdeSed.Focus();
                return false;
            }

            if (idSede < 0)
            {
                MessageBox.Show("El Id de Sede no puede ser negativo");
                this.txnIdeSed.Focus();
                return false;
            }
            return true;
        }
    }
}