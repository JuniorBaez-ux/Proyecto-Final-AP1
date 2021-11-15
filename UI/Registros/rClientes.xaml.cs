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
    /// Interaction logic for rClientes.xaml
    /// </summary>
    public partial class rClientes : Window
    {
        private Clientes cliente = new Clientes();
        public rClientes()
        {
            cliente = new Clientes();
            InitializeComponent();
            this.DataContext = cliente;
            LLenarComboSexo();
            LLenarComboVivienda();
            LLenarComboEstadoCivil();
        }
        private void BuscarIDButton_Click(object sender, RoutedEventArgs e)
        {
            var Cliente = ClientesBLL.Buscar(Utilidades.ToInt(IdTextBox.Text));

            if (Cliente != null)
            {
                this.cliente = Cliente;
            }
            else
            {
                this.cliente = new Clientes();
                MessageBox.Show("Este Cliente no existe", "No existe", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            this.DataContext = this.cliente;
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Validar())
                return;

            var paso = ClientesBLL.Guardar(this.cliente);

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
            Clientes existe = ClientesBLL.Buscar(this.cliente.ClienteId);

            if (ClientesBLL.Eliminar(this.cliente.ClienteId))
            {
                Limpiar();
                MessageBox.Show("Su cliente ha sido eliminado con exito");
            }
            else
            {
                MessageBox.Show("No fue posible eliminarlo");
            }
        }

        private void Limpiar()
        {
            FechaDeIngresoDatePicker.SelectedDate = DateTime.Now;
            DataContext = new Clientes();
        }

        private bool Validar()
        {
            bool esValido = true;

            if (NombreTextBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Debe ingresar un nombre!");
            }
            if (CedulaTextBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Debe ingresar un numero de cedula!");
            }
            if (TelefonoTextBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Debe agregar un numero de telefono!");
            }
            if (OcupacionTextBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Debe agregar su ocupacion!");
            }
            if (CelularTextBox.Text.Length <= 0)
            {
                esValido = false;
                MessageBox.Show("Debe agregar un numero de celular!");
            }
            if (DireccionTextBox.Text.Length <= 0)
            {
                esValido = false;
                MessageBox.Show("Debe agregar una direccion!");
            }
            if (CorreoTextBox.Text.Length <= 0)
            {
                esValido = false;
                MessageBox.Show("Debe agregar una direccion de correo electronico!");
            }
            return esValido;
        }

        private void LLenarComboSexo()
        {
            this.SexoComboBox.ItemsSource = SexosBLL.GetList(x => true);
            this.SexoComboBox.SelectedValuePath = "SexoId";
            this.SexoComboBox.DisplayMemberPath = "Descripcion";

            if (SexoComboBox.Items.Count > 0)
            {
                SexoComboBox.SelectedIndex = 0;
            }
        }

        private void LLenarComboVivienda()
        {
            this.TipoDeViviendaComboBox.ItemsSource = ViviendasBLL.GetList(x => true);
            this.TipoDeViviendaComboBox.SelectedValuePath = "ViviendaId";
            this.TipoDeViviendaComboBox.DisplayMemberPath = "Descripcion";

            if (TipoDeViviendaComboBox.Items.Count > 0)
            {
                TipoDeViviendaComboBox.SelectedIndex = 0;
            }
        }

        private void LLenarComboEstadoCivil()
        {
            this.EstadoCivilComboBox.ItemsSource = EstadosCivilesBLL.GetList(x => true);
            this.EstadoCivilComboBox.SelectedValuePath = "EstadoCivilId";
            this.EstadoCivilComboBox.DisplayMemberPath = "Descripcion";

            if (EstadoCivilComboBox.Items.Count > 0)
            {
                EstadoCivilComboBox.SelectedIndex = 0;
            }
        }
    }
}
