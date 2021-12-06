using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Proyecto_Final_AP1.BLL;
using Proyecto_Final_AP1.Entidades;

namespace Proyecto_Final_AP1.UI.Registros
{
    /// <summary>
    /// Lógica de interacción para rTipoViviendas.xaml
    /// </summary>
    public partial class rTipoViviendas : Window
    {
        private TipoViviendas tipoViviendas = new TipoViviendas();
        public rTipoViviendas()
        {
            tipoViviendas = new TipoViviendas();
            this.DataContext = this.tipoViviendas;
            InitializeComponent();
        }

        private bool Validar()
        {
            bool esValido = true;

            if (TipoViviendasIdTextBox.Text.ToInt() < 0)
            {
                esValido = false;
                MessageBox.Show("Debe ingresar un id Valido!");
            }
            if (DescripcionTextBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Debe ingresar una descripcion!");
            }
            if (TipoViviendasBLL.ExisteDescripcion(DescripcionTextBox.Text))
            {
                esValido = false;
                MessageBox.Show("Debe ingresar una descripcion que no exista...");
            }
            return esValido;
        }

        private void Limpiar()
        {
            tipoViviendas = new TipoViviendas();
            Cargar();
        }

        private void Cargar()
        {
            this.DataContext = null;
            this.DataContext = this.tipoViviendas;
        }





        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var tipovivienda = TipoViviendasBLL.Buscar(Utilidades.ToInt(TipoViviendasIdTextBox.Text));

            if (tipovivienda != null)
            {
                this.tipoViviendas = tipovivienda;
            }
            else
            {
                this.tipoViviendas = new TipoViviendas();
                MessageBox.Show("Este Tipo de vivienda no existe", "No existe", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            Cargar();
        }



        private void Nuevo_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Validar())
                return;

            var paso = TipoViviendasBLL.Guardar(this.tipoViviendas);

            if (paso)
            {
                Limpiar();
                MessageBox.Show("Informacion almacenada correctamente!");
            }
            else
                MessageBox.Show("La informacion no pudo ser almacenada correctamente.");
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            TipoViviendas existe = TipoViviendasBLL.Buscar(this.tipoViviendas.TipoViviendasId);

            if (TipoViviendasBLL.Eliminar(this.tipoViviendas.TipoViviendasId))
            {
                Limpiar();
                MessageBox.Show("El tipo de vivienda ha sido eliminado con exito");
            }
            else
            {
                MessageBox.Show("No fue posible eliminarlo");
            }
        }

        private void TipoViviendasIdTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void DescripcionTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9a-zA-Z,]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}