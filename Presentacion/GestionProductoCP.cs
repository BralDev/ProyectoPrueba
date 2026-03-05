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
                MessageBox.Show(Constantes._M_CAMPO_OBLIGATORIO, "Id");
                this.txcNomPro.Focus();
                return;
            }

            loProEliRQT.pnIdePro = Convert.ToInt32(this.txnIdePro.Text);

            ProductoEliminarRPT loProEliRPT = loRefGestProdCR.wmEliminarProducto(loProEliRQT);

            if (loProEliRPT.pnCodigo == Constantes._M_CODIGO_EXITOSO)
            {
                this.mxLimpCamp();
                this.mxCargProds();
            }
            MessageBox.Show(loProEliRPT.pcMensaje);
        }

        private void cmbInsert_Click(object sender, EventArgs e)
        {
            int lnIdeSed, lnStoPro;
            decimal lnPrePro;
            string lcNomPro, lcDescPro;
            WSGestionProductos loRefGestProdCR = new WSGestionProductos();

            if (!this.mxValForm())
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

            if (loProCreRPT.pnCodigo == Constantes._M_CODIGO_CREDADO)
            {                
                this.mxLimpCamp();
                this.mxCargProds();
            }
            MessageBox.Show(loProCreRPT.pcMensaje);
        }
        private void cmbListar_Click(object sender, EventArgs e)
        {
            this.mxCargProds();
            MessageBox.Show(Constantes._M_CARGA_REGISTROS);
        }
        private void cmbEditar_Click(object sender, EventArgs e)
        {
            int lnIdePro, lnStoPro, lnIdeSed;
            decimal lnPrePro;
            string lcNomPro, lcDescPro;
            WSGestionProductos loRefGestProdCR = new WSGestionProductos();

            if (!this.mxValForm())
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

            if (loProActRPT.pnCodigo == Constantes._M_CODIGO_EXITOSO)
            {                
                this.mxLimpCamp();
                this.mxCargProds();
            }
            MessageBox.Show(loProActRPT.pcMensaje);
        }

        private void grdProd_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            this.mxLimpCamp();
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

            if (loProLstRPT.pnCodigo == Constantes._M_CODIGO_EXITOSO)
            {
                this.grdProd.DataSource = loProLstRPT.paProductos;
            }
            else
            {
                MessageBox.Show(loProLstRPT.pcMensaje);
            }                
        }

        private void GestionProductoCP_Load(object sender, EventArgs e)
        {
            this.mxCargProds();
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
            this.mxLimpCamp();
        }

        private bool mxValForm()
        {
            if (string.IsNullOrWhiteSpace(this.txcNomPro.Text))
            {
                MessageBox.Show(Constantes._M_CAMPO_OBLIGATORIO, "Nombre");
                this.txcNomPro.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(this.txcDesPro.Text))
            {
                MessageBox.Show(Constantes._M_CAMPO_OBLIGATORIO, "Descripcion");
                this.txcDesPro.Focus();
                return false;
            }

            if (!decimal.TryParse(this.txnPrePro.Text, out decimal precio))
            {
                MessageBox.Show(Constantes._M_CAMPO_NUMERICO, "Precio");
                this.txnPrePro.Focus();
                return false;
            }

            if (precio <= 0)
            {
                MessageBox.Show(Constantes._M_CAMPO_MAYOR_CERO, "Precio");
                this.txnPrePro.Focus();
                return false;
            }

            if (!int.TryParse(this.txnStoPro.Text, out int stock))
            {
                MessageBox.Show(Constantes._M_CAMPO_NUMERICO, "Stock");
                this.txnStoPro.Focus();
                return false;
            }

            if (stock < 0)
            {
                MessageBox.Show(Constantes._M_CAMPO_MAYOR_CERO, "Stock");
                this.txnStoPro.Focus();
                return false;
            }

            if (!int.TryParse(this.txnIdeSed.Text, out int idSede))
            {
                MessageBox.Show(Constantes._M_CAMPO_NUMERICO, "ID Sede");
                this.txnIdeSed.Focus();
                return false;
            }

            if (idSede < 0)
            {
                MessageBox.Show(Constantes._M_CAMPO_MAYOR_CERO, "ID Sede");
                this.txnIdeSed.Focus();
                return false;
            }
            return true;
        }

        private void cmbTrasladar_Click(object sender, EventArgs e)
        {
            WSGestionProductos loRefGestProdCR = new WSGestionProductos();
            int lnIdeProOrigen, lnCanTraslado, lnIdeSedDestino;

            lnIdeProOrigen = Convert.ToInt32(this.txnIdeProMov.Text);
            lnCanTraslado = nudCantMov.Value > 0 ? Convert.ToInt32(nudCantMov.Value) : 0;
            lnIdeSedDestino = Convert.ToInt32(this.txnIdeSedMov.Text);

            ProductoTrasladarRQT loProTrasladarRQT = new ProductoTrasladarRQT
            {
                pnIdeProOrigen = lnIdeProOrigen,
                pnCanTraslado = lnCanTraslado,
                pnIdeSedDestino = lnIdeSedDestino
            };

            ProductoTrasladarRPT loProTrasladarRPT = loRefGestProdCR.wmTrasladarProducto(loProTrasladarRQT);

            if (loProTrasladarRPT.pnCodigo == Constantes._M_CODIGO_EXITOSO)
            {
                this.mxLimpCamp();
                this.mxCargProds();
            }
            MessageBox.Show(loProTrasladarRPT.pcMensaje);
        }
    }
}