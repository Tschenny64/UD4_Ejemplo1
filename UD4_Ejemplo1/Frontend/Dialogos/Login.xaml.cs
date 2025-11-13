using MahApps.Metro.Controls;
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
using UD4_Ejemplo1.Backend.Servicios;
using UD4_Ejemplo1.Frontend.Dialogos;

namespace UD4_Ejemplo1.Frontend.Dialogos
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : MetroWindow
    {
        private DiinventarioexamenContext _contexto;
        private UsuarioRepository _usuarioRepository;
        public Login()
        {
            InitializeComponent();
            //instanciamos el contexto y el repositorio de usuarios
            //el contexto nos permite conectar con la base de datos
            _contexto = new DiinventarioexamenContext();
        }
        private async void btn_login_Click(object sender, RoutedEventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();
            string contrasena = txtContrasena.Password.Trim();

            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(contrasena))
            {
                MessageBox.Show("Por favor, completa todos los campos.", "Campos vacíos", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            _usuarioRepository = new UsuarioRepository(_contexto,null);

            if (await _usuarioRepository.LoginAsync (txtUsuario.Text, txtContrasena.Password))
            {
                // si la autenticacion es correcta, abrimos la ventana principal
                //pasando el usuario logueado
                Menu ventanaMenu = new Menu(_contexto);
                ventanaMenu.Show();
                this.Close();
            }else 
                {
                MessageBox.Show("Usuario o contraseña incorrectos.", "Error de autenticación", MessageBoxButton.OK, MessageBoxImage.Error);
            }


        }
    }
}
 