using AppProductos.Servicios;
using EsquemaMAUI.Esquemas;
using System.Windows.Input;

namespace AppProductos.Vistas.Modelos
{
    public class ProductoFormVM : BindableObject
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

        public ICommand GuardarCommand { get; }

        // ─── CONSTRUCTOR NUEVO ─────────────────────────────────
        public ProductoFormVM()
        {
            loProductoServicio = new ProductoServicio();
            GuardarCommand = new Command(async () => await mxGuardar());
        }

        // ─── CONSTRUCTOR EDITAR ────────────────────────────────
        public ProductoFormVM(ProductoListaModel toProducto) : this()
        {
            pcTitulo = "Editar Producto";
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
            var loMainPage = Application.Current?.MainPage;

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
    }
}