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
    /// Interaction logic for rUsuarios.xaml
    /// </summary>
    public partial class rUsuarios : Window
    {
        private Usuarios Usuario = new Usuarios();
        public rUsuarios()
        {
            InitializeComponent();
            this.DataContext = this.Usuario;
            LlenarComboPermisos();
            LlenarComboRol();
        }
        private void LlenarComboPermisos()
        {
            this.PermisoIdComboBox.ItemsSource = PermisosBLL.GetList(x => true);
            this.PermisoIdComboBox.SelectedValuePath = "PermisoId";
            this.PermisoIdComboBox.DisplayMemberPath = "Descripcion";

            if (PermisoIdComboBox.Items.Count > 0)
                PermisoIdComboBox.SelectedIndex = 0;
        }

        private void LlenarComboRol()
        {
            this.RolIdComboBox.ItemsSource = RolesBLL.GetList(x => true);
            this.RolIdComboBox.SelectedValuePath = "RolId";
            this.RolIdComboBox.DisplayMemberPath = "Descripcion";

            if (RolIdComboBox.Items.Count > 0)
                RolIdComboBox.SelectedIndex = 0;
        }

        private bool Validar()
        {
            bool esValido = true;

            if (NombresTextBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Transacción Fallida!", "Fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            if (EmailTextBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Transacción Fallida!", "Fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            if (FechaIngresoDatePicker.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Transacción Fallida!", "Fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            if (ClaveTextBox.Password.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Transacción Fallida!", "Fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            if (RolIdComboBox.Items.Count <= 0)
            {
                esValido = false;
                MessageBox.Show("Debe Seleccionar un Rol", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            if (PermisoIdComboBox.Items.Count <= 0)
            {
                esValido = false;
                MessageBox.Show("Debe Seleccionar un Permiso", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return esValido;
        }

        private void Cargar()
        {
            this.DatosDataGrid.ItemsSource = null;
            this.DatosDataGrid.ItemsSource = this.Usuario.Detalle;
            this.DataContext = null;
            this.DataContext = this.Usuario;
        }
        private void Limpiar()
        {
            Usuario = new Usuarios();
            ClaveTextBox.Password = null;
            FechaIngresoDatePicker.SelectedDate = DateTime.Now;
            Cargar();
            LlenarComboPermisos();
            LlenarComboRol();
        }
        private void BuscarIdButton_Click(object sender, RoutedEventArgs e)
        {
            int.TryParse(UsuarioIDTextBox.Text, out int id);
            var Proyecto = UsuariosBLL.Buscar(id);

            if (Proyecto != null)
            {
                this.Usuario = Proyecto;
                Cargar();
            }
            else
            {
                this.Usuario = new Usuarios();
                MessageBox.Show("Este proyecto no existe", "No existe", MessageBoxButton.OK, MessageBoxImage.Information);

            }
        }

        private void AgregarButton_Click(object sender, RoutedEventArgs e)
        {

            var RolId = (int)RolIdComboBox.SelectedValue;
            var PermisoId = (int)PermisoIdComboBox.SelectedValue;

            this.Usuario.Detalle.Add(new UsuariosDetalle
            {
                Id = 0,
                RolId = RolId,
                PermisoId = PermisoId,

            });
            Cargar();
        }

        private void EliminarPermiso_Click(object sender, RoutedEventArgs e)
        {
            if (DatosDataGrid.SelectedIndex < 0)
                return;
            if (Usuario.Detalle.Count <= 0)
                return;

            if (DatosDataGrid.Items.Count >= 1 && DatosDataGrid.SelectedIndex <= DatosDataGrid.Items.Count - 1)
            {
                this.Usuario.Detalle.RemoveAt(DatosDataGrid.SelectedIndex);
                Cargar();

            }
        }

        private void NButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if (UsuariosBLL.Eliminar(this.Usuario.UsuarioId))
            {
                Limpiar();
                MessageBox.Show("Eliminado", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("Transaccion Fallida", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);

        }
    }
}
