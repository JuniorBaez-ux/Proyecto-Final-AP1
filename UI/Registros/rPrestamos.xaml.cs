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

        }

        private void RemoverFila_Click(object sender, RoutedEventArgs e)
        {

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
    }
}
