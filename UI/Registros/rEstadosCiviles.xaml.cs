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
            bool paso = true;

            if (DescripcionTextBox.Text == string.Empty)
            {
                MessageBox.Show("Este campo no puede quedar vacio");

                DescripcionTextBox.Focus();
                paso = false;
            }

            if (EstadosCivilesBLL.Existe(Utilidades.ToInt(DescripcionTextBox.Text)))
            {
                MessageBox.Show("Esta descripcion del estado civil ya existe en la base de datos");

                DescripcionTextBox.Focus();
                paso = false;
            }

            if (EstadosCivilesBLL.Existe(Utilidades.ToInt(EstadoCivilIDTextBox.Text)))
            {
                MessageBox.Show("Este id del estado Civil ya existe en la base de datos");

                EstadoCivilIDTextBox.Focus();
                paso = false;
            }

            return paso;
        }

        private void Limpiar()
        {
            EstadoCivilIDTextBox.Clear();
            DescripcionTextBox.Clear();
        }

        private void LlenarCampos(EstadosCiviles estadosCiviles)
        {
            EstadoCivilIDTextBox.Text = estadosCiviles.EstadoCivilId.ToString();
            DescripcionTextBox.Text = estadosCiviles.Descripcion;
            
        }

        private EstadosCiviles LlenarClase()
        {
           EstadosCiviles estadosCiviles = new EstadosCiviles();
            estadosCiviles.EstadoCivilId = Utilidades.ToInt(EstadoCivilIDTextBox.Text);
            estadosCiviles.Descripcion = DescripcionTextBox.Text;
          

            return estadosCiviles;


        }
        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            int id;
            EstadosCiviles estadosCiviles = new EstadosCiviles();
            int.TryParse(EstadoCivilIDTextBox.Text, out id);

            Limpiar();

            estadosCiviles = EstadosCivilesBLL.Buscar(id);

            if (estadosCiviles != null)
            {
                MessageBox.Show("El Estado Civil  ha sido encontrado");
                LlenarCampos(estadosCiviles);
            }
            else
            {
                MessageBox.Show("El Estado Civil  no ha sido encontrado o no esta registrado");
            }
        }
    


        private void Nuevo_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private bool ExisteEnLaBaseDeDatos()
        {
            EstadosCiviles estadosCiviles = EstadosCivilesBLL.Buscar(Utilidades.ToInt(EstadoCivilIDTextBox.Text));

            return (estadosCiviles != null);
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            EstadosCiviles estadosCiviles;
            bool paso = false;
            if (!Validar())
            {
                return;
            }

            estadosCiviles = LlenarClase();
            paso = EstadosCivilesBLL.Guardar(estadosCiviles);

            if (!ExisteEnLaBaseDeDatos())
            {
                Limpiar();
                MessageBox.Show("Estado Civil guardado correctamente", "Guardado", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                Limpiar();
                MessageBox.Show("Estado Civil modificado correctamente", "Guardado", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            int id;
            int.TryParse(EstadoCivilIDTextBox.Text, out id);
            Limpiar();
            if (EstadosCivilesBLL.Eliminar(id))
            {
                MessageBox.Show("Estado Civil eliminado correctamente", "Proceso exitoso", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("ID no existe en la base de datos");
            }
        }

       
    }
}
