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

namespace Proyecto_Final_AP1.UI.Registros
{
    /// <summary>
    /// Lógica de interacción para rTipoViviendas.xaml
    /// </summary>
    public partial class rTipoViviendas : Window
    {
        private TipoViviendas tipoViviendas = new TipoViviendas();
        public rTipoViviendas()
        {
            tipoViviendas = new TipoViviendas();
            this.DataContext = this.tipoViviendas;
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

            if (TipoViviendasBLL.Existe(Utilidades.ToInt(DescripcionTextBox.Text)))
            {
                MessageBox.Show("Esta descripcion de Tipo vivienda ya existe en la base de datos");

                DescripcionTextBox.Focus();
                paso = false;
            }

            if (TipoViviendasBLL.Existe(Utilidades.ToInt(TipoViviendaIDTextBox.Text)))
            {
                MessageBox.Show("Este id de tipo vivienda ya existe en la base de datos");

                TipoViviendaIDTextBox.Focus();
                paso = false;
            }

            return paso;
        }

        private void Limpiar()
        {
            TipoViviendaIDTextBox.Clear();
            DescripcionTextBox.Clear();
        }

        private void LlenarCampos(TipoViviendas tipoViviendas)
        {
            TipoViviendaIDTextBox.Text = tipoViviendas.TipoViviendasId.ToString();
            DescripcionTextBox.Text = tipoViviendas.Descripcion;

        }

        private TipoViviendas LlenarClase()
        {
            TipoViviendas tipoViviendas = new TipoViviendas();
            tipoViviendas.TipoViviendasId = Utilidades.ToInt(TipoViviendaIDTextBox.Text);
            tipoViviendas.Descripcion = DescripcionTextBox.Text;


            return tipoViviendas;


        }


        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            int id;
            TipoViviendas tipoViviendas = new TipoViviendas();
            int.TryParse(TipoViviendaIDTextBox.Text, out id);

            Limpiar();

            tipoViviendas = TipoViviendasBLL.Buscar(id);

            if (tipoViviendas != null)
            {
                MessageBox.Show("El Tipo de vivienda  ha sido encontrado");
                LlenarCampos(tipoViviendas);
            }
            else
            {
                MessageBox.Show("El Tipo de vivienda   no ha sido encontrado o no esta registrado");
            }
        }

        private bool ExisteEnLaBaseDeDatos()
        {
            TipoViviendas tipoViviendas = TipoViviendasBLL.Buscar(Utilidades.ToInt(TipoViviendaIDTextBox.Text));

            return (tipoViviendas != null);
        }

        private void Nuevo_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            TipoViviendas tipoViviendas;
            bool paso = false;
            if (!Validar())
            {
                return;
            }

            tipoViviendas = LlenarClase();
            paso = TipoViviendasBLL.Guardar(tipoViviendas);

            if (!ExisteEnLaBaseDeDatos())
            {
                Limpiar();
                MessageBox.Show("Tipo de Vivienda guardada correctamente", "Guardado", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                Limpiar();
                MessageBox.Show("Tipo de viviendas modificada correctamente", "Guardado", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            int id;
            int.TryParse(TipoViviendaIDTextBox.Text, out id);
            Limpiar();
            if (TipoViviendasBLL.Eliminar(id))
            {
                MessageBox.Show("Tipo de vivienda eliminada correctamente", "Proceso exitoso", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("ID no existe en la base de datos");
            }
        }
    }
}
