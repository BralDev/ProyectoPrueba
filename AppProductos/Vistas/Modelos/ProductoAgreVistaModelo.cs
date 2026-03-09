using AppProductos.Servicios;
using EsquemaMAUI.Esquemas;
using System.Windows.Input;

namespace AppProductos.Vistas.Modelos
{
    public class ProductoAgreVistaModelo : BindableObject
    {
        private readonly ProductoServicio loProductoServicio;

        // ─── PROPIEDADES ───────────────────────────────────────
        private int lnIdePro = 0;
        public int pnIdePro
        {
            get => lnIdePro;
            set { lnIdePro = value; OnPropertyChanged(); }
        }

        private string lcNomPro = string.Empty;
        public string pcNomPro
        {
            get => lcNomPro;
            set { lcNomPro = value; OnPropertyChanged(); }
        }

        private string lcDesPro = string.Empty;
        public string pcDesPro
        {
            get => lcDesPro;
            set { lcDesPro = value; OnPropertyChanged(); }
        }

        private decimal lnPrePro;
        public decimal pnPrePro
        {
            get => lnPrePro;
            set { lnPrePro = value; OnPropertyChanged(); }
        }

        private int lnStoPro;
        public int pnStoPro
        {
            get => lnStoPro;
            set { lnStoPro = value; OnPropertyChanged(); }
        }

        private int lnIdeSed;
        public int pnIdeSed
        {
            get => lnIdeSed;
            set { lnIdeSed = value; OnPropertyChanged(); }
        }

        private string lcTitulo = "Nuevo Producto";
        public string pcTitulo
        {
            get => lcTitulo;
            set { lcTitulo = value; OnPropertyChanged(); }
        }
        
        private string lcTextoBoton = "Guardar";
        public string pcTextoBoton
        {
            get => lcTextoBoton;
            set { lcTextoBoton = value; OnPropertyChanged(); }
        }

        public ICommand GuardarCommand { get; }

        public ICommand EliminarCommand { get; }

        public bool pbEsEditar => pnIdePro != 0;

        // ─── CONSTRUCTOR NUEVO ─────────────────────────────────
        public ProductoAgreVistaModelo()
        {
            loProductoServicio = new ProductoServicio();
            GuardarCommand = new Command(async () => await mxGuardar());
            EliminarCommand = new Command(async () => await mxEliminar(), () => pnIdePro != 0);
        }

        // ─── CONSTRUCTOR EDITAR ────────────────────────────────
        public ProductoAgreVistaModelo(ProductoListaModel toProducto) : this()
        {
            pcTitulo = "Editar Producto";            
            pcTextoBoton = "Guardar Cambios";
            pnIdePro = toProducto.pnIdePro;
            pnIdePro = toProducto.pnIdePro;
            pcNomPro = toProducto.pcNomPro;
            pcDesPro = toProducto.pcDesPro;
            pnPrePro = toProducto.pnPrePro;
            pnStoPro = toProducto.pnStoPro;
            pnIdeSed = toProducto.pnIdeSed; 
        }

        // ─── GUARDAR ───────────────────────────────────────────
        private async Task mxGuardar()
        {
            var loMainPage = Application.Current?.Windows[0].Page as NavigationPage;
            var loCurrentPage = loMainPage?.CurrentPage ?? Application.Current?.MainPage;

            // Validación básica en la UI
            if (string.IsNullOrWhiteSpace(pcNomPro))
            {
                await loMainPage?.DisplayAlert("Validación", "El nombre es obligatorio.", "OK");
                return;
            }
            if (pnPrePro <= 0)
            {
                await loMainPage?.DisplayAlert("Validación", "El precio debe ser mayor a 0.", "OK");
                return;
            }
            if (pnIdeSed <= 0)
            {
                await loMainPage?.DisplayAlert("Validación", "El ID de sede es obligatorio.", "OK");
                return;
            }

            if (pnIdePro == 0)
                await mxCrear(loMainPage);
            else
                await mxActualizar(loMainPage);
        }

        private async Task mxCrear(Page loMainPage)
        {
            ProductoCrearRQT loRQT = new ProductoCrearRQT
            {
                pcNomPro = pcNomPro,
                pcDesPro = pcDesPro,
                pnPrePro = pnPrePro,
                pnStoPro = pnStoPro,
                pnIdeSed = pnIdeSed
            };

            ProductoCrearRPT loRPT = await loProductoServicio.amCrearProducto(loRQT);

            await loMainPage?.DisplayAlert(
                loRPT.pnCodigo == 201 ? "Éxito" : "Error",
                loRPT.pcMensaje,
                "OK"
            );

            if (loRPT.pnCodigo == 201)
                await loMainPage?.Navigation.PopAsync();
        }

        private async Task mxActualizar(Page loMainPage)
        {
            ProductoActualizarRQT loRQT = new ProductoActualizarRQT
            {
                pnIdePro = pnIdePro,
                pcNomPro = pcNomPro,
                pcDesPro = pcDesPro,
                pnPrePro = pnPrePro,
                pnStoPro = pnStoPro,
                pnIdeSed = pnIdeSed
            };

            ProductoActualizarRPT loRPT = await loProductoServicio.amActualizarProducto(loRQT);

            await loMainPage?.DisplayAlert(
                loRPT.pnCodigo == 200 ? "Éxito" : "Error",
                loRPT.pcMensaje,
                "OK"
            );

            if (loRPT.pnCodigo == 200)
                await loMainPage?.Navigation.PopAsync();
        }

        private async Task mxEliminar()
        {
            var loMainPage = Application.Current?.Windows[0].Page as NavigationPage;

            bool lbConfirmar = await loMainPage.DisplayAlert(
                "Confirmar",
                $"¿Estás seguro de eliminar '{pcNomPro}'?",
                "Sí, eliminar",
                "Cancelar"
            );

            if (!lbConfirmar) return;

            ProductoEliminarRQT loRQT = new ProductoEliminarRQT
            {
                pnIdePro = pnIdePro
            };

            ProductoEliminarRPT loRPT = await loProductoServicio.amEliminarProducto(loRQT);

            await loMainPage.DisplayAlert(
                loRPT.pnCodigo == 200 ? "Éxito" : "Error",
                loRPT.pcMensaje,
                "OK"
            );

            if (loRPT.pnCodigo == 200)
                await loMainPage.Navigation.PopAsync();
        }
    }
}