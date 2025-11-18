using Castle.Core.Logging;
using MahApps.Metro.Controls;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
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
using UD4_Ejemplo1.Backend.Servicios;

namespace UD4_Ejemplo1.Frontend.ControlUsuario
{
    /// <summary>
    /// Interaction logic for DialogoModelo.xaml
    /// </summary>
    public partial class DialogoModelo : MetroWindow
    {
        private DiinventarioexamenContext _contexto;
        private ILogger<GenericRepository<Modeloarticulo>> _logger;
        private ModeloArticuloRepository _modeloArticuloRepository;
        private TipoArticuloRepository _tipoArticuloRepository;
        public DialogoModelo()
        {
            InitializeComponent();
        }

        private async void diagModeloArticulo_Loaded(object sender, RoutedEventArgs e)
        {
            // instanciamos el contexto y el repositorio de usuarios
            _contexto = new DiinventarioexamenContext();
            // El logger nos permite registrar eventos y errores
            _logger = LoggerFactory.Create(builder =>
            {
               builder.AddConsole();
            }).CreateLogger<GenericRepository<Modeloarticulo>>();
            _modeloArticuloRepository = new ModeloArticuloRepository(_contexto, _logger);
            _tipoArticuloRepository = new TipoArticuloRepository(_contexto, null);
            List<Tipoarticulo> tipos = await _tipoArticuloRepository.GetAllAsync();
            cmbTipoArticulo.ItemsSource = tipos;
        }
        private async void btnGuardarModeloArticulo_Click(object sender, RoutedEventArgs e)
        {
            Modeloarticulo modeloarticulo = new Modeloarticulo();
            RecogerDatos(modeloarticulo);
            try
            {
                await _modeloArticuloRepository.AddAsync(modeloarticulo);
                _contexto.SaveChanges();
                DialogResult = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar el modelo de articulo: " + ex.Message,
                    "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnCancelarModeloArticulo_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void RecogerDatos(Modeloarticulo modeloarticulo)
        {
            modeloarticulo.Nombre = txtNombreModelo.Text;
            modeloarticulo.Descripcion = txtDescripcionModelo.Text;
            modeloarticulo.Marca = txtMarcaModelo.Text;
            modeloarticulo.Modelo = txtMarcaModelo.Text;
            if (cmbTipoArticulo.SelectedItem != null)
            {
                modeloarticulo.TipoNavigation = (Tipoarticulo)cmbTipoArticulo.SelectedItem;
            }
        }
    }
}
