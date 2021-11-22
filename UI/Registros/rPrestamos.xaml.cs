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
    /// Interaction logic for rPrestamos.xaml
    /// </summary>
    public partial class rPrestamos : Window
    {
        private Prestamos prestamos = new Prestamos();
        double interes;
        double capital;
        double conversor;
        public rPrestamos()
        {
            InitializeComponent();
            this.DataContext = prestamos;
        }

        private void BuscarIDButton_Click(object sender, RoutedEventArgs e)
        {
            var Prestamos = PrestamosBLL.Buscar(Utilidades.ToInt(IdTextBox.Text));

            if (Prestamos != null)
            {
                this.prestamos = Prestamos;
            }
            else
            {
                this.prestamos = new Prestamos();
            }
            Cargar();
        }

        private void CalcularCuotasButton_Click(object sender, RoutedEventArgs e)
        {
            calculoInteres();
            calculoCapital();
            for (int i = 1; i <= Utilidades.ToInt(CuotasTextBox.Text); i++)
            {
                prestamos.Detalle.Add(new PrestamosDetalle
                {
                    CuotaId = i,
                    NumeroCuota = i,
                    FechaCuota = DateTime.Parse(DateTime.Today.AddMonths(i).ToString("MM/dd/yyyy")),
                    Interes = interes,
                    Capital = Convert.ToInt32(capital),
                    BalanceInteres = Convert.ToInt32(interes),
                    BalanceCapital = Convert.ToInt32(capital)
                });;
            }
            Cargar();
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Validar())
            {
                return;
            }

            llenarProyec();

            var paso = PrestamosBLL.Guardar(this.prestamos);

            if (paso)
            {
                Limpiar();
                MessageBox.Show("Su prestamo ha sido guardado correctamente");
            }
            else
            {
                MessageBox.Show("Su proyecto no ha podido ser almacenado...");
            }
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
            {
                MessageBox.Show("No fue posible eliminarlo");
            }
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
            return esValido;
        }

        private void llenarProyec()
        {
            prestamos.PrestamoId = Utilidades.ToInt(IdTextBox.Text);
            prestamos.Monto = Utilidades.ToInt(MontoTextBox.Text);
            prestamos.Cuotas = Utilidades.ToInt(CuotasTextBox.Text);
            prestamos.Interes = Utilidades.ToInt(InteresTextBox.Text);
            prestamos.Balance = Utilidades.ToInt(BalanceTextBox.Text);
        }

        //Realizar un metodo que haga el calculo de la fecha y calculo los 30 dias para cada prestamo
        //Realizar un metodo que haga el calculo de los intereses de los prestamos insertados en el detalle
        private void calculoInteres()/*I = C.i.t --> El interés simple de un préstamo es igual al monto del préstamo inicial, por la tasa de interés, por la cantidad de períodos que tendrás que pagar.*/
        {
            convertirDecimal();
            interes = Utilidades.ToInt(MontoTextBox.Text) * conversor * Utilidades.ToInt(CuotasTextBox.Text);

        }
        //Realzar un metodo que haga el calculo del capital de los prestamos insertados en el detalle
        private void calculoCapital()
        {
            double tasaPeriodica = (double)Utilidades.ToInt(InteresTextBox.Text) / Utilidades.ToInt(CuotasTextBox.Text);

            capital = interes * tasaPeriodica;
        }

        private void convertirDecimal()
        {
           conversor =  Convert.ToDouble(Utilidades.ToInt(InteresTextBox.Text) / 100);
        }
    }
}
