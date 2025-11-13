using MahApps.Metro.Controls;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using UD4_Ejemplo1.Backend.Modelo;
using UD4_Ejemplo1.Frontend.Dialogos;
using UD4_Ejemplo1.Frontend.ControlUsuario;

namespace UD4_Ejemplo1.Frontend.Dialogos
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Menu : MetroWindow
    {
        private DiinventarioexamenContext _contexto;
        private DialogoModelo mvModeloArticulo;

            public Menu(DiinventarioexamenContext contexto)
            {
                InitializeComponent();
                _contexto = contexto;
            }

        private void fbtnAddModelo_Click(object sender, RoutedEventArgs e)
        {
            contenedorPrincipal.Children.Clear();
            var dialogoModelo = new DialogoModelo(_contexto);
            contenedorPrincipal.Children.Add(dialogoModelo);
        }

        private void buttonCerrarApp_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }


    }

}
