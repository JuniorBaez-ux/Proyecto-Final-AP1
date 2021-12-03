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
    /// Lógica de interacción para rEstadosCiviles.xaml
    /// </summary>
    public partial class rEstadosCiviles : Window
    {
        private EstadosCiviles estadosCiviles = new EstadosCiviles();
        public rEstadosCiviles()
        {
            estadosCiviles = new EstadosCiviles();
            this.DataContext = this.estadosCiviles;
            InitializeComponent();
        }

        private bool Validar()
        {
            bool esValido = true;

            if (EstadosCivilesTextBox.Text.ToInt() <=0)
            {
                esValido = false;
                MessageBox.Show("Debe ingresar un id de un Estado Civil!");
            }
            if (DescripcionTextBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Debe ingresar una descripcion para su Estado Civil!");
            }
            if (SexosBLL.ExisteDescripcion(DescripcionTextBox.Text))
            {
                esValido = false;
                MessageBox.Show("Debe ingresar un Estado Civil que no exista...");
            }
            return esValido;
        }

        private void Limpiar()
        {
            estadosCiviles = new EstadosCiviles();
            Cargar();
        }

        private void Cargar()
        {
            this.DataContext = null;
            this.DataContext = this.estadosCiviles;
        }


        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var estadoCivil = EstadosCivilesBLL.Buscar(Utilidades.ToInt(EstadosCivilesTextBox.Text));

            if (estadoCivil != null)
            {
                this.estadosCiviles = estadoCivil;
            }
            else
            {
                this.estadosCiviles = new EstadosCiviles();
                MessageBox.Show("Este Estado Civil no existe", "No existe", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            Cargar();
        }
    


        private void Nuevo_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }


        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Validar())
                return;

            var paso = EstadosCivilesBLL.Guardar(this.estadosCiviles);

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
            EstadosCiviles existe = EstadosCivilesBLL.Buscar(this.estadosCiviles.EstadoCivilId);

            if (EstadosCivilesBLL.Eliminar(this.estadosCiviles.EstadoCivilId))
            {
                Limpiar();
                MessageBox.Show("El Estado Civil ha sido eliminado con exito");
            }
            else
            {
                MessageBox.Show("No fue posible eliminarlo");
            }
        }

       
    }
}
