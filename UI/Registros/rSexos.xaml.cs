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
    /// Interaction logic for rSexos.xaml
    /// </summary>
    public partial class rSexos : Window
    {
        private Sexos sexos = new Sexos();
        public rSexos()
        {
            sexos = new Sexos();
            InitializeComponent();
            this.DataContext = sexos;
        }

        private void BuscarIDButton_Click(object sender, RoutedEventArgs e)
        {
            var Sexos = SexosBLL.Buscar(Utilidades.ToInt(SexoIdTextBox.Text));

            if (Sexos != null)
            {
                this.sexos = Sexos;
            }
            else
            {
                this.sexos = new Sexos();
                MessageBox.Show("Este Sexo no existe", "No existe", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            this.DataContext = this.sexos;
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Validar())
                return;

            var paso = SexosBLL.Guardar(this.sexos);

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
            Sexos existe = SexosBLL.Buscar(this.sexos.SexoId);

            if (SexosBLL.Eliminar(this.sexos.SexoId))
            {
                Limpiar();
                MessageBox.Show("El sexo ha sido eliminado con exito");
            }
            else
            {
                MessageBox.Show("No fue posible eliminarlo");
            }
        }

        private void Limpiar()
        {
            DataContext = new Sexos();
        }

        private bool Validar()
        {
            bool esValido = true;

            if (SexoIdTextBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Debe ingresar un id de Sexo!");
            }
            if (DescripcionTextBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Debe ingresar un nombre para su Sexo!");
            }
            return esValido;
        }
    }
}
