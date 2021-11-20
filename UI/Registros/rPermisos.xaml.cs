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
    /// Interaction logic for rPermisos.xaml
    /// </summary>
    public partial class rPermisos : Window
    {
        private Permisos permisos = new Permisos();
        public rPermisos()
        {
            permisos = new Permisos();
            InitializeComponent();
            this.DataContext = permisos;
        }

        private void BuscarIDButton_Click(object sender, RoutedEventArgs e)
        {

            var Permisos = PermisosBLL.Buscar(Utilidades.ToInt(PermisoTextBox.Text));

            if (Permisos != null)
            {
                this.permisos = Permisos;
            }
            else
            {
                this.permisos = new Permisos();
                MessageBox.Show("Este Permiso no existe", "No existe", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            this.DataContext = this.permisos;
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Validar())
                return;

            var paso = PermisosBLL.Guardar(this.permisos);

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
            Permisos existe = PermisosBLL.Buscar(this.permisos.PermisoId);

            if (PermisosBLL.Eliminar(this.permisos.PermisoId))
            {
                Limpiar();
                MessageBox.Show("El permiso ha sido eliminado con exito");
            }
            else
            {
                MessageBox.Show("No fue posible eliminarlo");
            }
        }

        private void Limpiar()
        {
            DataContext = new Permisos();
        }

        private bool Validar()
        {
            bool esValido = true;

            if (NombreTextBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Debe ingresar un nombre!");
            }
            if (PermisoTextBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Debe ingresar un id de permiso!");
            }
            if (DescripcionTextBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Debe ingresar una descripcion para su permiso!");
            }
            return esValido;
        }
    }
}
