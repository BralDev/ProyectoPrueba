using Negocio.Esquemas;
using System.Collections.Generic;

namespace Negocio.Interfaces
{
    public interface IGestorProducto
    {
        int createProducto(ProductCreateDto dtoProducto);
        int updateProducto(ProductUpdateDto dtoProducto);
        List<ProductResponseDto> listProducto();
        int deleteProducto(int id);
    }
}
