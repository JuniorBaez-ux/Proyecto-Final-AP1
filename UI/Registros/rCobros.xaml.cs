using Proyecto_Final_AP1.BLL;
using Proyecto_Final_AP1.Entidades;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Proyecto_Final_AP1.UI.Registros
{
    /// <summary>
    /// Lógica de interacción para rCobros.xaml
    /// </summary>
    public partial class rCobros : Window
    {
        Cobros cobro = new Cobros();
        Prestamos prestamos = new Prestamos();
        public rCobros()
        {
            InitializeComponent();
            this.DataContext = cobro;
            LLenarComboCliente();
        }

        private void LLenarComboCliente()
        {
            this.ClienteComboBox.ItemsSource = ClientesBLL.GetList(x => true);
            this.ClienteComboBox.SelectedValuePath = "ClienteId";
            this.ClienteComboBox.DisplayMemberPath = "Nombres";

            if (ClienteComboBox.Items.Count > 0)
            {
                ClienteComboBox.SelectedIndex = 0;
            }
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
            prestamos = new Prestamos();
            Cargar();
        }

        private bool Validar()
        {
            bool paso = true;

            if (CobrosBLL.Existe(CobroIdTextBox.Text.ToInt()))
            {
                MessageBox.Show("No se puede realizar modificaciones a los cobros...");

                CobroIdTextBox.Focus();
                paso = false;
                Limpiar();
            }
            if (cobro.Detalle.Count == 0)
            {
                paso = false;
                MessageBox.Show("No puede almacenar sin detalle...");
            }
            return paso;
        }

        private void Nuevo_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Validar())
                return;

            cobro.PrestamoId = PrestamosComboBox.SelectedValue.ToInt();
            cobro.Detalle.RemoveAll(x => x.BalanceCapital == x.Capital && x.BalanceInteres == x.Interes);

            var paso = CobrosBLL.Guardar(this.cobro);

            if (paso)
            {
                Limpiar();
                MessageBox.Show("Su cobro ha sido guardado correctamente");
            }
            else
                MessageBox.Show("Su cobro no ha podido ser almacenado...");
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            Cobros existe = CobrosBLL.Buscar(this.cobro.CobroId);

            if (CobrosBLL.Eliminar(this.cobro.CobroId))
            {
                Limpiar();
                MessageBox.Show("Su cobro ha sido eliminado con exito");
            }
            else
                MessageBox.Show("No fue posible eliminarlo");
        }

        private void BuscarIDButton_Click(object sender, RoutedEventArgs e)
        {
            var Cobros = CobrosBLL.Buscar(Utilidades.ToInt(CobroIdTextBox.Text));

            if (Cobros != null)
                this.cobro = Cobros;
            else
                this.cobro = new Cobros();

            Cargar();
        }

        private void AgregarButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Validar())
                return;

            decimal Monto = MontoTextBox.Text.ToDecimal();
            decimal Mora = MoraTextBox.Text.ToDecimal();

            if (Mora > 0)
            {
                if (Mora < Monto)
                    Monto -= Mora;
                else
                    Mora -= Monto;
            }

            cobro.Mora = Mora;

            if (Monto > 0)
            {
                foreach (var x in cobro.Detalle)
                {
                    if (Monto <= 0)
                        break;

                    if (x.BalanceCapital < Monto)
                    {
                        Monto -= x.BalanceCapital;
                        x.BalanceCapital = 0;
                    }
                    else
                    {
                        x.BalanceCapital -= Monto;
                        Monto = 0;
                    }

                    if (x.BalanceInteres < Monto)
                    {
                        Monto -= x.BalanceInteres;
                        x.BalanceInteres = 0;
                    }
                    else
                    {
                        x.BalanceInteres -= Monto;
                        Monto = 0;
                    }
                }
            }
            Cargar();
            BalanceTextBox.Text = prestamos.Balance.ToString("N2");
            MoraTextBox.Text = prestamos.Mora.ToString("N2");
            cobro.Monto = MontoTextBox.Text.ToInt();
            cobro.Mora = MoraTextBox.Text.ToInt();
        }

        private void ClienteComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int ClienteId = ClienteComboBox.SelectedValue.ToInt();
            LLenarComboPrestamos(ClienteId);
        }
        private void LLenarComboPrestamos(int ClienteId = 0)
        {
            this.PrestamosComboBox.ItemsSource = PrestamosBLL.GetList(x => x.ClientesId == ClienteId);
            this.PrestamosComboBox.SelectedValuePath = "PrestamoId";
            this.PrestamosComboBox.DisplayMemberPath = "PrestamoId";
        }

        private void PrestamosComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var Prestamo = PrestamosBLL.Buscar(PrestamosComboBox.SelectedValue.ToInt());
            prestamos = Prestamo;

            if (prestamos != null)
            {
                prestamos.Detalle.ForEach(x =>
                {
                    cobro.Detalle.Add(new CobrosDetalle
                    {
                        NumeroCuota = x.NumeroCuota,
                        Fecha = x.FechaCuota,
                        ValorCuota = x.ValorCuota,
                        Capital = x.Capital,
                        Interes = x.Interes,
                        BalanceCapital = x.BalanceCapital,
                        BalanceInteres = x.BalanceInteres,
                        BalanceCuota = x.BalanceCuota
                    });
                });
            }

            Cargar();
            BalanceTextBox.Text = prestamos.Balance.ToString("N2");
            MoraTextBox.Text = prestamos.Mora.ToString("N2");
        }
    }

}
