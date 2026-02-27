using Datos.Entidades;
using System.Collections.Generic;

namespace Datos.Interfaces
{
    public interface IProductoRepositorio
    {
        int createProducto(ProductoCD producto);
        int updateProducto(ProductoCD producto);
        List<ProductoCD> listProducto();
        int deleteProducto(int id);
    }
}
