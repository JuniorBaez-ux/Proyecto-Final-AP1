using Proyecto_Final_AP1.BLL;
using Proyecto_Final_AP1.Entidades;
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

namespace Proyecto_Final_AP1.UI.Registros
{
    /// <summary>
    /// Interaction logic for rPrestamos.xaml
    /// </summary>
    public partial class rPrestamos : Window
    {
        private Prestamos prestamos = new Prestamos();
        decimal interes = 0;
        decimal capital = 0;
        decimal TasaInteres = 0;
        public rPrestamos()
        {
            InitializeComponent();
            this.DataContext = prestamos;
            LLenarComboCliente();
        }

        private void BuscarIDButton_Click(object sender, RoutedEventArgs e)
        {
            var Prestamos = PrestamosBLL.Buscar(Utilidades.ToInt(IdTextBox.Text));

            if (Prestamos != null)
                this.prestamos = Prestamos;
            else
                this.prestamos = new Prestamos();

            Cargar();
        }
        public static decimal InteresMensual(decimal TasaAnual)
        {
            return Utilidades.Pow((1 + TasaAnual), (1d / 12d)) - 1;
        }
        public static decimal ValorCuota(decimal monto, decimal TasaMes, int Plazos)
        {
            return monto * ((TasaMes * (Utilidades.Pow(1 + TasaMes, Plazos))) / (Utilidades.Pow(1 + TasaMes, Plazos) - 1));
        }
        private void CalcularCuotasButton_Click(object sender, RoutedEventArgs e)
        {
            //calculoInteres();
            prestamos.Detalle.Clear();
            int Plazos = CuotasTextBox.Text.ToInt();
            decimal Monto = MontoTextBox.Text.ToDecimal();
            decimal TasaAnual = InteresTextBox.Text.ToDecimal() / 100;
            decimal TasaMes = InteresMensual(TasaAnual);
            decimal CuotaPagar = ValorCuota(Monto, TasaMes, Plazos);
            decimal InteresTotal = TasaAnual * (Monto / Plazos);
            for (int i = 1; i <= Utilidades.ToInt(CuotasTextBox.Text); i++)
            {
                decimal interes = Monto * TasaMes;
                decimal capital = CuotaPagar - interes;
                prestamos.Detalle.Add(new PrestamosDetalle
                {
                    CuotaId = 0,
                    NumeroCuota = i,
                    FechaCuota = DateTime.Today.AddMonths(i),
                    Interes = interes.ToRound(2),
                    Capital = (CuotaPagar - interes).ToRound(2),
                    BalanceCuota = (Math.Abs(Monto - capital)).ToRound(2),
                    ValorCuota = CuotaPagar.ToRound(2),
                    BalanceInteres = interes.ToRound(2),
                    BalanceCapital = (CuotaPagar - interes).ToRound(2)
                });
                Monto = (Math.Abs(Monto - capital)).ToRound(2);
            }
            prestamos.Balance = prestamos.Detalle.Sum(x => x.BalanceCapital+x.BalanceInteres).ToString("N2").ToDecimal();
            Cargar();
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Validar())
                return;

            prestamos.ClientesId = Utilidades.ToInt(ClienteComboBox.SelectedValue.ToString());

            var paso = PrestamosBLL.Guardar(this.prestamos);

            if (paso)
            {
                Limpiar();
                MessageBox.Show("Su prestamo ha sido guardado correctamente");
            }
            else
                MessageBox.Show("Su proyecto no ha podido ser almacenado...");
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            Prestamos existe = PrestamosBLL.Buscar(this.prestamos.PrestamoId);

            if (PrestamosBLL.Eliminar(this.prestamos.PrestamoId))
            {
                Limpiar();
                MessageBox.Show("Su Prestamo ha sido eliminado con exito");
            }
            else
                MessageBox.Show("No fue posible eliminarlo");
        }

        private void Cargar()
        {
            this.DetalleDataGrid.ItemsSource = null;
            this.DetalleDataGrid.ItemsSource = this.prestamos.Detalle;
            this.DataContext = null;
            this.DataContext = this.prestamos;
        }

        private void Limpiar()
        {
            prestamos = new Prestamos();
            Cargar();
        }

        private bool Validar()
        {
            bool esValido = true;

            if (IdTextBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("El campo Prestamos Id no puede quedar vacio");
            }
            if (MontoTextBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("El campo Monto no puede quedar vacio");
            }
            if (CuotasTextBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("El campo Cuotas no puede quedar vacio");
            }
            if (InteresTextBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("El campo Interes no puede quedar vacio");
            }
            if (prestamos.Detalle.Count == 0)
            {
                esValido = false;
                MessageBox.Show("No puede almacenar sin detalle...");
            }

            return esValido;
        }

        //Realizar un metodo que haga el calculo de la fecha y calculo los 30 dias para cada prestamo
        //Realizar un metodo que haga el calculo de los intereses de los prestamos insertados en el detalle
        private void calculoInteres()/*I = C.i.t --> El interés simple de un préstamo es igual al monto del préstamo inicial, por la tasa de interés, por la cantidad de períodos que tendrás que pagar.*/
        {
            Decimal.TryParse((Utilidades.ToDecimal(InteresTextBox.Text) / 100).ToString(), out TasaInteres);
            interes = Utilidades.ToDecimal(MontoTextBox.Text) * TasaInteres * Utilidades.ToDecimal(CuotasTextBox.Text);
        }
        //Realzar un metodo que haga el calculo del capital de los prestamos insertados en el detalle
        private void calculoCapital()
        {
            decimal tasaPeriodica = (decimal)Utilidades.ToInt(InteresTextBox.Text) / Utilidades.ToInt(CuotasTextBox.Text);

            capital = interes * tasaPeriodica;
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

        private void IdTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void MontoTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void CuotasTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void InteresTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9.]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
