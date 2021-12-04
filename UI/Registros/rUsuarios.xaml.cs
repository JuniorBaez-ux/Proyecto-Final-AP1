using Proyecto_Final_AP1.BLL;
using Proyecto_Final_AP1.Entidades;
using System;
using System.Collections.Generic;
using System.Globalization;
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
            if (ClaveTextBox.Password.Length <= 3)
            {
                esValido = false;
                MessageBox.Show("Transacción Fallida!", "Fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            if (RolIdComboBox.Items.Count == 0)
            {
                esValido = false;
                MessageBox.Show("Debe Seleccionar un Rol", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            if (PermisoIdComboBox.Items.Count == 0)
            {
                esValido = false;
                MessageBox.Show("Debe Seleccionar un Permiso", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            if (ConfirmarClaveTextBox.Password != null && !ClaveTextBox.Password.Equals(ConfirmarClaveTextBox.Password))
            {
                esValido = false;
                MessageBox.Show("Las contraseñas deben ser iguales!", "Fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            if (!IsValidEmail(EmailTextBox.Text))
            {
                esValido = false;
                MessageBox.Show("Debe arreglar el formato del email....");
            }
            if(Usuario.Detalle.Count == 0)
            {
                esValido = false;
                MessageBox.Show("No puede almacenar sin detalle...");
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
            ConfirmarClaveTextBox.Password = null;
            FechaIngresoDatePicker.SelectedDate = DateTime.Now;
            Cargar();
            LlenarComboPermisos();
            LlenarComboRol();
        }

        private void AgregarButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Validar())
                return;

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

        private void BuscarIdButton_Click_1(object sender, RoutedEventArgs e)
        {
          
            var id = UsuariosBLL.Buscar(Utilidades.ToInt(UsuarioIDTextBox.Text));
           
            if (id != null)
            {
                this.Usuario = id;
               
            }
            else
            {
                this.Usuario = new Usuarios();
                MessageBox.Show("Este Usuario no existe", "No existe", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            Cargar();
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {

            if (!Validar())
                return;

            this.Usuario.Clave = UsuariosBLL.SHA1(ClaveTextBox.Password);          

            var paso = UsuariosBLL.Guardar(this.Usuario);

            if (paso)
            {
                Limpiar();
                MessageBox.Show("Transaccion Exitosa", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("Transaccion Fallida", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);

        }
        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                // Normalize the domain
                email = Regex.Replace(email, @"(@)(.+)$", DomainMapper,
                                      RegexOptions.None, TimeSpan.FromMilliseconds(200));

                // Examines the domain part of the email and normalizes it.
                string DomainMapper(Match match)
                {
                    // Use IdnMapping class to convert Unicode domain names.
                    var idn = new IdnMapping();

                    // Pull out and process domain name (throws ArgumentException on invalid)
                    string domainName = idn.GetAscii(match.Groups[2].Value);

                    return match.Groups[1].Value + domainName;
                }
            }
            catch (RegexMatchTimeoutException e)
            {
                return false;
            }
            catch (ArgumentException e)
            {
                return false;
            }

            try
            {
                return Regex.IsMatch(email,
                    @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }
    }
}
