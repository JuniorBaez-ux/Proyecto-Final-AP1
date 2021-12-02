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
    /// Interaction logic for rMoras.xaml
    /// </summary>
    public partial class rMoras : Window
    {
        Moras moras;
        public rMoras()
        {
            InitializeComponent();
            this.DataContext = this.moras = new Moras(); ;
        }

        private void Limpiar()
        {
            this.DataContext = moras = new Moras();
            LlenaCombox();
        }
        private bool Validar()
        {
            bool esValido = true;

            if (ClienteTextBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Transacción Fallida!", "Fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            if(MontoTextBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Transacción Fallida!", "Fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            if(PrestamoIdComboBox.Items.Count == 0)
            {
                esValido = false;
                MessageBox.Show("Transacción Fallida!", "Fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            return esValido;
        }
        private void LlenaCombox(int ClienteId = 0)
        {
            this.PrestamoIdComboBox.ItemsSource = PrestamosBLL.GetList(x => x.ClientesId == ClienteId && x.Balance > 0);
            this.PrestamoIdComboBox.SelectedValuePath = "PrestamoId";
            this.PrestamoIdComboBox.DisplayMemberPath = "PrestamoId";

            if (PrestamoIdComboBox.Items.Count > 0)
                PrestamoIdComboBox.SelectedIndex = 0;
        }
        private void BuscarPestamoButton_Click(object sender, RoutedEventArgs e)
        {

            //int.TryParse(ClienteTextBox.Text, out int ClienteId);
            var ClienteId = Utilidades.ToInt(ClienteTextBox.Text);
            LlenaCombox(ClienteId);

        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            //int.TryParse(MoraIdTextBox.Text, out int MoraId);
            var MoraId = Utilidades.ToInt(MoraIdTextBox.Text);
            var Mora = MorasBLL.Buscar(MoraId);

            if (Mora != null)
            {
                this.moras = Mora;
                LlenaCombox(Mora.ClienteId);
                this.PrestamoIdComboBox.SelectedValue = Mora.PrestamoId;
            }
            else
            {
                this.moras = new Moras();
                MessageBox.Show("No existe esta Mora!", "Fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            this.DataContext = this.moras;
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if (MorasBLL.Eliminar(this.moras.MoraId))
            {
                Limpiar();
                MessageBox.Show("Eliminado", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            else
                MessageBox.Show("No fue posible eliminarlo", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void NButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Validar())
                return;

            this.moras.PrestamoId = PrestamoIdComboBox.SelectedValue.ToString().ToInt();
            var paso = MorasBLL.Guardar(this.moras);

            if (paso)
            {
                Limpiar();
                MessageBox.Show("Transaccion Exitosa!", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("Transaccion Fallida!", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);

        }

        private void PrestamoIdComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var Prestamo = (Prestamos)PrestamoIdComboBox.SelectedItem;
            if (Prestamo != null)
                BalanceTextBox.Text = Prestamo.Balance.ToString("N2");
        }
    }
}
