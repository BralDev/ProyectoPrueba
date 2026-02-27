using Datos.Conexion;
using ProyectoPrueba.Vistas;
using Datos.Repositorios;
using System;
using System.Windows.Forms;
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
            GestorProducto gestor = new GestorProducto();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1(gestor));
        }
    }
}
