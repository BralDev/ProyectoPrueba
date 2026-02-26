using ProyectoPrueba.Datos.Entidades;
using System.Collections.Generic;
using System.Linq;

namespace ProyectoPrueba.Datos.Interfaces {

	public interface IProductoRepositorio{ 
	
	 int createProducto (Producto producto);
	 int updateProducto (Producto producto);

    List<Producto> listProducto();
	int  deleteProducto(int id);
	
	}


}