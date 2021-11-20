using Proyecto_Final_AP1.UI.Consultas;
using Proyecto_Final_AP1.UI.Registros;
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

namespace Proyecto_Final_AP1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void NegocioMenuItem_Click(object sender, RoutedEventArgs e)
        {
            rNegocios negocios = new rNegocios();
            negocios.Show();
        }

        private void ConsultaNegocioMenuItem_Click(object sender, RoutedEventArgs e)
        {
            cNegocios cNegocio = new cNegocios();
            cNegocio.Show();
        }

        private void GaranteMenuItem_Click(object sender, RoutedEventArgs e)
        {
            rGarantes garante = new rGarantes();
            garante.Show();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            rClientes clientes = new rClientes();
            clientes.Show();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            cClientes cclientes = new cClientes();
            cclientes.Show();
        }

        private void ConsultaGaranteMenuitem_Click(object sender, RoutedEventArgs e)
        {
            cGarantes garante = new cGarantes();
            garante.Show();
        }

        private void EstadoCivilesMenuItem_Click(object sender, RoutedEventArgs e)
        {
            rEstadosCiviles estadosciviles = new rEstadosCiviles();
            estadosciviles.Show();
        }

        private void ConsultaEstadosCivilesMenuItem_Click(object sender, RoutedEventArgs e)
        {
            cEstadosCiviles estadosciviless = new cEstadosCiviles();
            estadosciviless.Show();
        }

        private void TipoViviendaMenuItem_Click(object sender, RoutedEventArgs e)
        {
            rTipoViviendas viviendas = new rTipoViviendas();
            viviendas.Show();
        }

       

        private void ConsultaTipoViviendas_Click_1(object sender, RoutedEventArgs e)
        {
            cTipoViviendas viviendas = new cTipoViviendas();
            viviendas.Show();
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            rPermisos permisos = new rPermisos();
            permisos.Show();
        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            cPermisos permisosc = new cPermisos();
            permisosc.Show();
        }

        private void MenuItem_Click_4(object sender, RoutedEventArgs e)
        {
            rSexos sexos = new rSexos();
            sexos.Show();
        }

        private void MenuItem_Click_5(object sender, RoutedEventArgs e)
        {
            cSexos sexosc = new cSexos();
            sexosc.Show();
        }
    }
}
