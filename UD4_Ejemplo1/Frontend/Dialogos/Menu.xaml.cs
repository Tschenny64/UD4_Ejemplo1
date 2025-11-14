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

            public Menu(DiinventarioexamenContext context)
            {
                InitializeComponent();
            }

        private void fbtnAddModelo_Click(object sender, RoutedEventArgs e)
        {
            DialogoModelo dialogoModelo = new DialogoModelo();
            dialogoModelo.ShowDialog();
        }

        private void buttonCerrarApp_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }


    }

}
