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
using Proyecto_Final_AP1.Entidades;
using Proyecto_Final_AP1.BLL;

namespace Proyecto_Final_AP1.UI.Registros
{
    /// <summary>
    /// Lógica de interacción para rCobros.xaml
    /// </summary>
    public partial class rCobros : Window
    {
        public rCobros()
        {
            InitializeComponent();
        }




        private bool Validar()
        {
            bool paso = true;

            if (ClienteIdTextBox.Text == string.Empty)
            {
                MessageBox.Show("Este campo no puede quedar vacio");

                ClienteIdTextBox.Focus();
                paso = false;
            }

            if (CobrosBLL.Existe(Utilidades.ToInt(ClienteIdTextBox.Text)))
            {
                MessageBox.Show("Este nombre del garante ya existe en la base de datos");

                ClienteIdTextBox.Focus();
                paso = false;
            }

            if (CobrosBLL.Existe(Utilidades.ToInt(CobroIdTextBox.Text)))
            {
                MessageBox.Show("Este id del garante ya existe en la base de datos");

                CobroIdTextBox.Focus();
                paso = false;
            }

            return paso;
        }

        private bool ExisteEnLaBaseDeDatos()
        {
            Cobros cobro = CobrosBLL.Buscar(Utilidades.ToInt(ClienteIdTextBox.Text));
           

            return (cobro != null);
        }

        private void LlenarCampos(Cobros cobro)
        {
            ClienteIdTextBox.Text = cobro.Clientes.ToString();
            CobroIdTextBox.Text = cobro.CobroId.ToString();
            MontoTextBox.Text = cobro.Monto.ToString();
           
        }

        private Cobros LlenarClase()
        {
            Cobros cobro = new Cobros();
            cobro.ClienteId = Utilidades.ToInt(ClienteIdTextBox.Text);
            cobro.CobroId = Utilidades.ToInt(CobroIdTextBox.Text);
            cobro.Monto = Utilidades.ToInt(MontoTextBox.Text);
          

            return cobro;


        }

        private void Limpiar()
        {
            ClienteIdTextBox.Clear();
            CobroIdTextBox.Clear();
            MontoTextBox.Clear();
          
        }



        private void Nuevo_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {

            Cobros cobro;
            bool paso = false;
            if (!Validar())
            {
                return;
            }

            cobro = LlenarClase();
            paso = CobrosBLL.Guardar(cobro);

            if (!ExisteEnLaBaseDeDatos())
            {
                Limpiar();
                MessageBox.Show("Cliente guardado correctamente", "Guardado", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                Limpiar();
                MessageBox.Show("Cliente modificado correctamente", "Guardado", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            int id;
            int.TryParse(ClienteIdTextBox.Text, out id);
            Limpiar();
            if (CobrosBLL.Eliminar(id))
            {
                MessageBox.Show("cliente eliminado correctamente", "Proceso exitoso", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("ID no existe en la base de datos");
            }
        }

        private void PagarButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AgregarMonto_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            int id;
            Cobros cobro = new Cobros();
            int.TryParse(ClienteIdTextBox.Text, out id);

            Limpiar();

            cobro = CobrosBLL.Buscar(id);

            if (cobro != null)
            {
                MessageBox.Show("El cliente  ha sido encontrado");
                LlenarCampos(cobro);
            }
            else
            {
                MessageBox.Show("El cliente no ha sido encontrado o no esta registrado");
            }
        }
    }
}
