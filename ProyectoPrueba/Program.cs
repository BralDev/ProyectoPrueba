using Datos.Conexion;
using Datos.Interfaces;
using ProyectoPrueba.Vistas;
using Datos.Repositorios;
using System;
using System.Windows.Forms;
using Negocio.Interfaces;
using Negocio.Gestores;

namespace ProyectoPrueba
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            DbConexion conexion = new DbConexion();
            IProductoRepositorio repositorio = new ProductoRepositorio(conexion);
            IGestorProducto gestor = new GestorProducto(repositorio);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1(gestor));
        }
    }
}
