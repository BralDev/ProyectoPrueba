using AppProductos.Servicios;
using EsquemaMAUI.Esquemas;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace AppProductos.Vistas.Modelos
{
    public class ProductoListVistaModelo : BindableObject
    {
        private readonly ProductoServicio loProductoServicio;

        // Colección vinculada al CollectionView del XAML
        public ObservableCollection<ProductoListaModel> paProductos { get; set; } = new();

        private bool lbRefrescando;
        public bool IsRefreshing
        {
            get => lbRefrescando;
            set { lbRefrescando = value; OnPropertyChanged(); }
        }

        private string lcMensaje;
        public string pcMensaje
        {
            get => lcMensaje;
            set { lcMensaje = value; OnPropertyChanged(); }
        }

        private bool lbHayError;
        public bool pbHayError
        {
            get => lbHayError;
            set { lbHayError = value; OnPropertyChanged(); }
        }

        public ICommand CargarProductosCommand { get; }

        private bool lbCargando = false;        

        public ProductoListVistaModelo()
        {
            loProductoServicio = new ProductoServicio();
            lbRefrescando = false;
            CargarProductosCommand = new Command(async () => await mxCargarProductos());
        }

        public async Task mxCargarProductos()
        {
            if (lbCargando) return;
            lbCargando = true;

            IsRefreshing = true;
            pbHayError = false;
            paProductos.Clear();

            ProductosListRPT loRPT = await loProductoServicio.amObtenerProductos();

            if (loRPT.pnCodigo == 200 && loRPT.paProductos != null)
                foreach (var p in loRPT.paProductos)
                    paProductos.Add(p);
            else
            {
                pbHayError = true;
                pcMensaje = loRPT.pcMensaje;
            }

            IsRefreshing = false;
            lbCargando = false;
        }
    }
}