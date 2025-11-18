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
using System.Windows.Shapes;
using UD4_Ejemplo1.Backend.Modelo;
using UD4_Ejemplo1.Backend.Servicios;

namespace UD4_Ejemplo1.Frontend.ControlUsuario
{
    /// <summary>
    /// Interaction logic for DialogoArticulo.xaml
    /// </summary>
    public partial class DialogoArticulo : MetroWindow
    {
        private DiinventarioexamenContext _contexto;
        private ILogger<GenericRepository<Articulo>> _logger;
        private ArticuloRepository _articuloRepository; 
        private UsuarioRepository _usuarioRepository;
        private EspacioRepository _espacioRepository;
        private DepartamentoRepository _departamentoRepository;
        private ModeloArticuloRepository _modeloArticuloRepository;
        private TipoArticuloRepository _tipoArticuloRepository;

        public DialogoArticulo()
        {
            InitializeComponent();
        }

        private async void diagArticulo_Loaded(object sender, RoutedEventArgs e)
        {
            _contexto = new DiinventarioexamenContext();
            _logger = LoggerFactory.Create(builder =>
            {
                builder.AddConsole();
            }).CreateLogger<GenericRepository<Articulo>>();

            _articuloRepository = new ArticuloRepository(_contexto, _logger);

            _modeloArticuloRepository = new ModeloArticuloRepository(_contexto, null);

            _usuarioRepository = new UsuarioRepository(_contexto, null);

            var loggerEspacio = LoggerFactory.Create(builder =>
            {
                builder.AddConsole();
            }).CreateLogger<GenericRepository<Espacio>>();

            _espacioRepository = new EspacioRepository(_contexto, loggerEspacio);

            var loggerDepartamento = LoggerFactory.Create(builder =>
            {
                builder.AddConsole();
            }).CreateLogger<GenericRepository<Departamento>>();

            _departamentoRepository = new DepartamentoRepository(_contexto, loggerDepartamento);

            _tipoArticuloRepository = new TipoArticuloRepository(_contexto, null);
            
            List<Modeloarticulo> modelos = await _modeloArticuloRepository.GetAllAsync();
            cmbModelo.ItemsSource = modelos;
            List<Usuario> usuariosAlta = await _usuarioRepository.GetAllAsync();
            cmbUsuarioAlta.ItemsSource = usuariosAlta;
            List<Articulo> usuariosBaja = await _articuloRepository.GetAllAsync();
            // cmbUsuarioBaja.ItemsSource = usuariosBaja; 
            List<Espacio> espacios = await _espacioRepository.GetAllAsync();
            cmbEspacio.ItemsSource = espacios;
            List<Departamento> departamentos = await _departamentoRepository.GetAllAsync();
            cmbDepartamento.ItemsSource = departamentos;
            List<Tipoarticulo> dentroDe = await _tipoArticuloRepository.GetAllAsync();
            cmbDentroDe.ItemsSource = dentroDe;
        }

        private async void btnCancelarArticulo_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private async void btnGuardarArticulo_Click(object sender, RoutedEventArgs e)
        {
            Articulo articulo = new Articulo();
            RecogerDatos(articulo);
            try
            {
                await _articuloRepository.AddAsync(articulo);
                _contexto.SaveChanges();
                DialogResult = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar el artículo: " + ex.Message);
            }

        }

        private void RecogerDatos(Articulo articulo)
        {

            articulo.Numserie = txtNumSerie.Text;
            articulo.Estado = txtEstado.Text;
            articulo.Fechaalta = dpFechaAlta.SelectedDate.GetValueOrDefault(DateTime.Now);

            if (cmbModelo.SelectedItem is Modeloarticulo modeloarticulo)
            {
                Modeloarticulo modeloSeleccionado = (Modeloarticulo)cmbModelo.SelectedItem;
                articulo.Modelo = modeloSeleccionado.Idmodeloarticulo;
            }
            if (cmbUsuarioAlta.SelectedItem != null)
            {
                Usuario usuarioSeleccionado = (Usuario)cmbUsuarioAlta.SelectedItem;
                articulo.Usuarioalta = usuarioSeleccionado.Idusuario;
            }
            if (cmbEspacio.SelectedItem is Espacio espacio)
            {
                Espacio espacioSeleccionado = (Espacio)cmbEspacio.SelectedItem;
                articulo.Espacio = espacioSeleccionado.Idespacio;
            }
            if (cmbDepartamento.SelectedItem is Departamento departamento)
            {
                Departamento departamentoSeleccionado = (Departamento)cmbDepartamento.SelectedItem;
                articulo.Departamento = departamentoSeleccionado.Iddepartamento;
            }
            if (cmbDentroDe.SelectedItem != null)
            {
                Articulo dentroDeSeleccionado = (Articulo)cmbDentroDe.SelectedItem;
                articulo.Dentrode = dentroDeSeleccionado.Idarticulo;
            }
            
        }
    }
}
