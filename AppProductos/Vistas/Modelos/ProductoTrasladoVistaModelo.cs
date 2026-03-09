using AppProductos.Servicios;
using EsquemaMAUI.Esquemas;
using System.Windows.Input;

namespace AppProductos.Vistas.Modelos
{
    public class ProductoTrasladoVistaModelo : BindableObject
    {
        private readonly ProductoServicio loProductoServicio;

        private int lnIdeProOrigen;
        public int pnIdeProOrigen
        {
            get => lnIdeProOrigen;
            set { lnIdeProOrigen = value; OnPropertyChanged(); }
        }

        private int lnCanTraslado;
        public int pnCanTraslado
        {
            get => lnCanTraslado;
            set { lnCanTraslado = value; OnPropertyChanged(); }
        }

        private int lnIdeSedDestino;
        public int pnIdeSedDestino
        {
            get => lnIdeSedDestino;
            set { lnIdeSedDestino = value; OnPropertyChanged(); }
        }

        public ICommand TrasladarCommand { get; }

        public ProductoTrasladoVistaModelo()
        {
            loProductoServicio = new ProductoServicio();
            TrasladarCommand = new Command(async () => await mxTrasladar());
        }

        private async Task mxTrasladar()
        {
            var loMainPage = Application.Current?.Windows[0].Page as NavigationPage;

            if (pnIdeProOrigen <= 0)
            {
                await loMainPage.DisplayAlert("Validación", "El ID del producto origen es obligatorio.", "OK");
                return;
            }
            if (pnCanTraslado <= 0)
            {
                await loMainPage.DisplayAlert("Validación", "La cantidad debe ser mayor a 0.", "OK");
                return;
            }
            if (pnIdeSedDestino <= 0)
            {
                await loMainPage.DisplayAlert("Validación", "El ID de sede destino es obligatorio.", "OK");
                return;
            }

            bool lbConfirmar = await loMainPage.DisplayAlert(
                "Confirmar",
                $"¿Trasladar {pnCanTraslado} unidades del producto {pnIdeProOrigen} a la sede {pnIdeSedDestino}?",
                "Sí, trasladar",
                "Cancelar"
            );

            if (!lbConfirmar) return;

            ProductoTrasladarRQT loRQT = new ProductoTrasladarRQT
            {
                pnIdeProOrigen = pnIdeProOrigen,
                pnCanTraslado = pnCanTraslado,
                pnIdeSedDestino = pnIdeSedDestino
            };

            ProductoTrasladarRPT loRPT = await loProductoServicio.amTrasladarProducto(loRQT);

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