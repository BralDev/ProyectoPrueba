using System.Security.Policy;

namespace Transversal
{
    public static class Constantes
    {
        //public static string _M_NO_REGISTRO_PRODUCTO = "No se registro el producto";
        public const string _M_REGISTRO_EXITOSO = "El registro se guardó correctamente.";      
        public const string _M_ACTUALIZACION_EXITOSA = "Los cambios se guardaron correctamente.";        
        public const string _M_ELIMINACION_EXITOSA = "El registro se eliminó correctamente.";

        public const string _M_ERROR_BASE_DATOS = "Error con el servidor de base de datos.";        
        public const string _M_ERROR_VALIDACION = "Los datos proporcionados no son válidos.";

        //USADOS
        public const string _M_ERROR_REGISTRO = "No se pudo guardar el registro ingresado.";
        public const string _M_ERROR_ACTUALIZAR = "No se pudo guardar los cambios realizados.";
        public const string _M_ERROR_ELIMINAR = "No se pudo eliminar el registro solicitado.";        

        public const string SP_PRODUCTO_CREAR = "PROC_I_INVMPRO";
        public const string SP_PRODUCTO_LISTAR = "PROC_S_INVMPRO_TraerTodo";
        public const string SP_PRODUCTO_ELIMINAR = "PROC_D_INVMPRO_nIdePro";
        public const string SP_PRODUCTAR_EDITAR = "PROC_U_INVMPRO";
        public const string SP_PRODUCTO_OBTENER = "PROC_S_INVMPRO_nIdePro";

        public const string SP_OBTENER_STOCK_PRODUCTO = "PROC_S_INVMPRO_nIdePronIdeSed_Stock";
        public const string SP_VALIRDAR_NOMBRE_PRODUCTO = "PROC_S_INVMPRO_cNomPronIdeSed";
        public const string SP_ACTUALIZAR_STOCK_PRODUCTO = "PROC_U_INVMPRO_nIdePronStocknIdeSed";


        public const string SP_SEDE_OBTENER = "PROC_S_INVMSED_nIdeSed";

        public const int _M_CODIGO_EXITOSO = 200;
        public const int _M_CODIGO_SIN_CONTENIDO = 204;
        public const int _M_CODIGO_ERROR = 500;
        public const int _M_CODIGO_NO_ENCONTRADO = 404;
        public const int _M_CODIGO_VALIDACION = 400;
        public const int _M_CODIGO_CREDADO = 201;


        public const string _M_SEDE_NO_EXISTE = "La sede con el identificador proporcionado no existe.";
        public const string _M_PRODUCTO_NO_EXISTE = "El producto con el identificador proporcionado no existe.";
        public const string _M_RECURSO_LISTA_VACIO = "La lista de registros está vacía.";
        public const string _M_CARGA_REGISTROS = "Los registros se obtuvieron correctamente.";

        public const string _M_CAMPO_OBLIGATORIO = "El siguiente campo es obligatorio: ";
        public const string _M_CAMPO_NUMERICO = "El siguiente campo debe ser numérico: ";
        public const string _M_CAMPO_MAYOR_CERO = "El siguiente campo debe ser mayor a cero: ";


        public const string _M_CANTIDAD_NO_VALIDO = "La cantidad ingresada no puede ser cero o negativa.";
        public const string _M_STOCK_INSUFICIENTE = "No hay suficiente stock disponible para completar la operación.";
        public const string _M_TRASLADO_EXITOSO = "El traslado se realizó correctamente.";
        public const string _M_TRASLADO_MISMA_SEDE = "No se puede realizar un traslado a la misma sede de origen.";

        public const string FECHA_ESTANDAR = "dd/MM/yyyy";
        public const string MONEDA_CULTURA = "es-PE";
        public const string FORMATO_DECIMAL = "0.00";
    }
}
