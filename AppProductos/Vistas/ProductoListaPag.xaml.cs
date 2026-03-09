using AppProductos.Vistas.Modelos;
using EsquemaMAUI.Esquemas;

namespace AppProductos.Vistas;

public partial class ProductoListaPage : ContentPage
{
    private readonly ProductoListVistaModelo loVM;
    private bool lbPrimeraCarga = true;
    public ProductoListaPage()
    {
        InitializeComponent();
        loVM = new ProductoListVistaModelo();
        BindingContext = loVM;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        if (lbPrimeraCarga)
        {
            lbPrimeraCarga = false;
            await loVM.mxCargarProductos(); // Carga inicial
            return;
        }

        // Recarga post Agregar/Editar
        await loVM.mxCargarProductos();
    }

    private async void OnAgregarProductoClick(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ProductoAgrePag());
    }

    private async void OnProductoSeleccionado(object sender, SelectionChangedEventArgs e)
    {
        ProductoListaModel loProducto = e.CurrentSelection.FirstOrDefault() as ProductoListaModel;
        if (loProducto != null)
        {
            await Navigation.PushAsync(new ProductoAgrePag(loProducto));
            ((CollectionView)sender).SelectedItem = null;
        }
    }

    private async void OnRefreshing(object sender, EventArgs e)
    {
        await loVM.mxCargarProductos();
    }
}