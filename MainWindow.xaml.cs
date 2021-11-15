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
    }
}
