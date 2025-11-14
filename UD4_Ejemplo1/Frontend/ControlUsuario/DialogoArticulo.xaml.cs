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
            List<Articulo> modelos = await _articuloRepository.GetAllAsync();
            cmbModelo.ItemsSource = modelos;
            List<Articulo> usuariosAlta = await _articuloRepository.GetAllAsync();
            cmbUsuarioAlta.ItemsSource = usuariosAlta;
            List<Articulo> usuariosBaja = await _articuloRepository.GetAllAsync();
            cmbUsuarioBaja.ItemsSource = usuariosBaja;
            List<Articulo> espacios = await _articuloRepository.GetAllAsync();
            cmbEspacio.ItemsSource = espacios;
            List<Articulo> departamentos = await _articuloRepository.GetAllAsync();
            cmbDepartamento.ItemsSource = departamentos;
            List<Articulo> dentroDe = await _articuloRepository.GetAllAsync();
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
            // txtNumSerie y txtEstado recogen los datos del artículo
            articulo.Numserie = txtNumSerie.Text;
            articulo.Estado = txtEstado.Text;

            // cmbModelo selecciona el modelo del artículo
            if (cmbModelo.SelectedItem != null)
            {
                Modeloarticulo modeloSeleccionado = (Modeloarticulo)cmbModelo.SelectedItem;
                articulo.Modelo = modeloSeleccionado.Idmodeloarticulo;
            }
            // cmbUsuarioAlta selecciona el usuario que da de alta el artículo
            if (cmbUsuarioAlta.SelectedItem != null)
            {
                Usuario usuarioSeleccionado = (Usuario)cmbUsuarioAlta.SelectedItem;
                articulo.Usuarioalta = usuarioSeleccionado.Idusuario;
            }
            if (cmbUsuarioBaja.SelectedItem != null)
            {
                Usuario usuarioBajaSeleccionado = (Usuario)cmbUsuarioBaja.SelectedItem;
                articulo.Usuariobaja = usuarioBajaSeleccionado.Idusuario;
            }
            else
            {
                articulo.Usuariobaja = null; // explicitamente null si no hay seleccion
            }
            if (cmbEspacio.SelectedItem != null)
            {
                Espacio espacioSeleccionado = (Espacio)cmbEspacio.SelectedItem;
                articulo.Espacio = espacioSeleccionado.Idespacio;
            }
            if (cmbDepartamento.SelectedItem != null)
            {
                Departamento departamentoSeleccionado = (Departamento)cmbDepartamento.SelectedItem;
                articulo.Departamento = departamentoSeleccionado.Iddepartamento;
            }
            if (cmbDentroDe.SelectedItem != null)
            {
                Articulo dentroDeSeleccionado = (Articulo)cmbDentroDe.SelectedItem;
                articulo.Dentrode = dentroDeSeleccionado.Idarticulo;
            }
            else
            {
                articulo.Dentrode = null; // explicitamente null si no hay seleccion
            }
            if (dpFechaAlta.SelectedDate != null)
            {
                articulo.Fechaalta = dpFechaAlta.SelectedDate.Value;
            }
            if (dpFechaBaja.SelectedDate != null)
            {
                articulo.Fechabaja = dpFechaBaja.SelectedDate.Value;
            }
            else
            {
                articulo.Fechabaja = null; // explicitamente null si no hay seleccion
            }
        }
    }
}
