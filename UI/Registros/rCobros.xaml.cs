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
using Proyecto_Final_AP1.Entidades;
using Proyecto_Final_AP1.BLL;

namespace Proyecto_Final_AP1.UI.Registros
{
    /// <summary>
    /// Lógica de interacción para rCobros.xaml
    /// </summary>
    public partial class rCobros : Window
    {
        Cobros cobro = new Cobros();

        public rCobros()
        {
            InitializeComponent();
            this.DataContext = cobro;
        }

        private void Cargar()
        {
            this.DatosDataGrid.ItemsSource = null;
            this.DatosDataGrid.ItemsSource = this.cobro.Detalle;
            this.DataContext = null;
            this.DataContext = this.cobro;
        }



        private void Limpiar()
        {
            cobro = new Cobros();
            Cargar();
        }

        
        private bool Validar()
        {
           
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
            int id;
            int.TryParse(ClienteIdTextBox.Text, out id);
            Limpiar();
            if (CobrosBLL.Eliminar(id))
            {
                MessageBox.Show("cliente eliminado correctamente", "Proceso exitoso", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("ID no existe en la base de datos");
            }
        }

        private void PagarButton_Click(object sender, RoutedEventArgs e)
        {

        }

       
        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void BuscarIDButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AgregarButton_Click(object sender, RoutedEventArgs e)
        {
           
        }
    }
}
