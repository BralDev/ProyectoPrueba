using ProyectoPrueba.Datos.Conexion;
using ProyectoPrueba.Datos.Interfaces;
using ProyectoPrueba.Presentacion;
using ProyectoPrueba.Datos.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            IProductoRepositorio servicio = new ProductoRepositorio(conexion);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form2(servicio));
        }
    }
}
