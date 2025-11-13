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
using System.Windows.Navigation;
using System.Windows.Shapes;
using UD4_Ejemplo1.Backend.Modelo;

namespace UD4_Ejemplo1.Frontend.ControlUsuario
{
    /// <summary>
    /// Interaction logic for DialogoModelo.xaml
    /// </summary>
    public partial class DialogoModelo : UserControl
    {
        private DiinventarioexamenContext _contexto;
        public DialogoModelo(DiinventarioexamenContext context)
        {
            InitializeComponent();
            _contexto = context;
        }
    }
}
