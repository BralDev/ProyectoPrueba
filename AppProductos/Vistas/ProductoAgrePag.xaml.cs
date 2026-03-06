using AppProductos.Vistas.Modelos;
using EsquemaMAUI.Esquemas;

namespace AppProductos.Vistas;

public partial class ProductoAgrePag : ContentPage
{
    // Constructor para nuevo producto
    public ProductoAgrePag()
    {
        InitializeComponent();
        BindingContext = new ProductoFormVM();
    }

    // Constructor para editar producto
    public ProductoAgrePag(ProductoListaModel toProducto)
    {
        InitializeComponent();
        BindingContext = new ProductoFormVM(toProducto);
    }
}