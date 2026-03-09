using AppProductos.Vistas.Modelos;

namespace AppProductos.Vistas;

public partial class ProductoTrasladoPag : ContentPage
{
    public ProductoTrasladoPag()
    {
        InitializeComponent();
        BindingContext = new ProductoTrasladoVistaModelo();
    }
}