using Proyecto_Final_AP1.BLL;
using Proyecto_Final_AP1.Entidades;
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
    /// Interaction logic for rNegocios.xaml
    /// </summary>
    public partial class rNegocios : Window
    {
        private Negocios Negocio = new Negocios();
        public rNegocios()
        {
            Negocio = new Negocios();
            this.DataContext = this.Negocio;
            InitializeComponent();
        }

        private bool Validar()
        {
            bool esValido = true;

            if (NombreTextBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Transacción Fallida!", "Fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            if (IngresosTextBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Debe tener Ingresos", "Fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            if (DireccionTextBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Debes agregar una Direccion", "Fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            if (ActividadTextBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Debes agregar una Actividad", "Fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            if (TiempoLaborandoTextBox.Text.Length <= 0 )
            {
                esValido = false;
                MessageBox.Show("Debes Tener un tiempo trabajando", "Fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            return esValido;
        }
        private void Limpiar()
        {
            IngresosTextBox.Text = string.Empty;
            DataContext = new Negocios();
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
             Negocios existe = NegociosBLL.Buscar(this.Negocio.NegocioId);

            if (NegociosBLL.Eliminar(this.Negocio.NegocioId))
            {
                Limpiar();
                MessageBox.Show("Eliminado", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            else
                MessageBox.Show("No fue posible eliminarlo", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);

        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Validar())
                return;

            var paso = NegociosBLL.Guardar(this.Negocio);

            if (paso)
            {
                Limpiar();
                MessageBox.Show("Transaccion Exitosa!", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("Transaccion Fallida!", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void NButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void BuscarId_Click(object sender, RoutedEventArgs e)
        {
            int.TryParse(NegocioIdTextBox.Text, out int NegocioId);
            var Negocio = NegociosBLL.Buscar(NegocioId);

            if (Negocio != null)
                this.Negocio = Negocio;
            else           
            {
                this.Negocio = new Negocios();
                MessageBox.Show("Este Negocio no existe", "No existe", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            this.DataContext = this.Negocio;
        }
    }
}
