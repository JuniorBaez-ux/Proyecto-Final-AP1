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

namespace Proyecto_Final_AP1.UI.Registros
{
    /// <summary>
    /// Lógica de interacción para rGarantes.xaml
    /// </summary>
    public partial class rGarantes : Window
    {
        public rGarantes()
        {
            InitializeComponent();
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Limpiar()
        {
            GaranteIDTextBox.Clear();
            NombreTextBox.Clear();
            CedulaTextBox.Clear();
            TelefonoTextBox.Clear();
            DireccionTextBox.Clear();
            parentescoTextBox.Clear();
        }

        private void Nuevo_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
