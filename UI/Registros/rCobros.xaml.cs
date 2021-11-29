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
        Prestamos prestamo = new Prestamos();
        PrestamosDetalle prestamoDetalle = new PrestamosDetalle(); 
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
            Cargar();
        }


        private bool Validar()
        {
            bool paso = true;

            if (CobrosBLL.Existe(Utilidades.ToInt(CobroIdTextBox.Text)))
            {
                MessageBox.Show("Este id del garante ya existe en la base de datos");

                CobroIdTextBox.Focus();
                paso = false;
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



            cobro.CobroId = Utilidades.ToInt(CobroIdTextBox.Text);



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


        private void PagarButton_Click(object sender, RoutedEventArgs e)
        {

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
            //prestamo = PrestamosDetalleBLL.Buscar(Utilidades.ToInt(ClienteIdTextBox.Text));

            //for (int i = 0; i < prestamo.NumeroCuota; i++)
            //{
            //    cobro.Detalle.Add(new CobrosDetalle
            //    {
            //        NumeroCuota = prestamo.NumeroCuota,
            //        ValorCuota = prestamo.ValorCuota,
            //        BalanceCuota = prestamo.BalanceCuota,
            //    });
            //}
            //Cargar();
        }

        private void BuscarClienteButton_Click(object sender, RoutedEventArgs e)
        {
            prestamoDetalle = PrestamosDetalleBLL.Buscar(ClienteComboBox.SelectedValue.ToString().ToInt());

            cobro.Detalle.Add(new CobrosDetalle
            {
                NumeroCuota = prestamoDetalle.NumeroCuota,
                ValorCuota = prestamoDetalle.ValorCuota,
                BalanceCuota = prestamoDetalle.BalanceCuota,
            });
        Cargar();
        }
    }

    }
