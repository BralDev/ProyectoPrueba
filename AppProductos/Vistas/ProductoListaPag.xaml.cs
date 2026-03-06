using AppProductos.Vistas.Modelos;
using EsquemaMAUI.Esquemas;

namespace AppProductos.Vistas;

public partial class ProductoListaPage : ContentPage
{
    public ProductoListaPage()
    {
        InitializeComponent();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        if (BindingContext is ProductoListaVM loVM)
        {
            await loVM.mxCargarProductos();
        }
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
}