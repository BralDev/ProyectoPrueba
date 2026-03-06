using AppProductos.Servicios;
using EsquemaMAUI.Esquemas;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace AppProductos.Vistas.Modelos
{
    public class ProductoListaVM : BindableObject
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

        public ProductoListaVM()
        {
            loProductoServicio = new ProductoServicio();
            CargarProductosCommand = new Command(async () => await mxCargarProductos());
            Task.Run(async () => await mxCargarProductos());
        }

        public async Task mxCargarProductos()
        {
            IsRefreshing = true;
            pbHayError = false;
            paProductos.Clear();

            ProductosListRPT loRPT = await loProductoServicio.amObtenerProductos();

            if (loRPT.pnCodigo == 200 && loRPT.paProductos != null)
            {
                foreach (ProductoListaModel loProducto in loRPT.paProductos)
                {
                    paProductos.Add(loProducto);
                }
            }
            else
            {
                pbHayError = true;
                pcMensaje = loRPT.pcMensaje;
            }

            IsRefreshing = false;
        }
    }
}