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
using Proyecto_Final_AP1.BLL;
using Proyecto_Final_AP1.Entidades;
using Proyecto_Final_AP1.DAL;

namespace Proyecto_Final_AP1.UI.Registros
{
    /// <summary>
    /// Lógica de interacción para rGarantes.xaml
    /// </summary>
    public partial class rGarantes : Window
    {
        private Garantes garantes = new Garantes();
        public rGarantes()
        {
            InitializeComponent();
            this.DataContext = this.garantes;
            garantes = new Garantes();
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var garante = GarantesBLL.Buscar(Utilidades.ToInt(GaranteIDTextBox.Text));

            if (garante != null)
            {
                this.garantes = garante;
            }
            else
            {
                this.garantes = new Garantes();
                MessageBox.Show("Este garante no existe", "No existe", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            Cargar();
        }


        private bool Validar()
        {
            {
                bool esValido = true;

                if (GaranteIDTextBox.Text.ToInt() <= 0)
                {
                    esValido = false;
                    MessageBox.Show("Debe ingresar un ID valido");
                }
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
                
              
                if (DireccionTextBox.Text.Length <= 0)
                {
                    esValido = false;
                    MessageBox.Show("Debe agregar una direccion!");
                }
                if (parentescoTextBox.Text.Length <= 0)
                {
                    esValido = false;
                    MessageBox.Show("Debe agregar un parentesco de correo electronico!");
                }
                if (CedulaTextBox.Text.Length <= 5)
                {
                    esValido = false;
                    MessageBox.Show("Debe agregar una cedula");
                }
                if (GarantesBLL.ExisteCedula(CedulaTextBox.Text))
                {
                    esValido = false;
                    MessageBox.Show("Debe ingresar una cedula que no exista....");
                }
                if (!CedulaTextBox.Text.Contains("-"))
                {
                    esValido = false;
                    MessageBox.Show("Debe arreglar el formato de la cedula ....");
                }
                if (!TelefonoTextBox.Text.Contains("-") && !TelefonoTextBox.Text.Contains("-"))
                {
                    esValido = false;
                    MessageBox.Show("Debe arreglar el formato del telefono....");
                }
               
                return esValido;
            }
        }

        private void Limpiar()
        {
            garantes = new Garantes();
            Cargar();
        }

       

        private void Cargar()
        {
            this.DataContext = null;
            this.DataContext = this.garantes;
        }




        private void Nuevo_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Validar())
                return;

            var paso = GarantesBLL.Guardar(this.garantes);

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
            Garantes existe = GarantesBLL.Buscar(this.garantes.GaranteId);

            if (GarantesBLL.Eliminar(this.garantes.GaranteId))
            {
                Limpiar();
                MessageBox.Show("El garante ha sido eliminado con exito");
            }
            else
            {
                MessageBox.Show("No fue posible eliminarlo");
            }
        }

        
    }
}
