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
            int id;
            Garantes garante = new Garantes();
            int.TryParse(GaranteIDTextBox.Text, out id);

            Limpiar();

            garante = GarantesBLL.Buscar(id);

            if (garante != null)
            {
                MessageBox.Show("El garante  ha sido encontrado");
                LlenarCampos(garante);
            }
            else
            {
                MessageBox.Show("El garante no ha sido encontrado o no esta registrado");
            }
        }


        private bool Validar()
        {
            bool paso = true;

            if (NombreTextBox.Text == string.Empty)
            {
                MessageBox.Show("Este campo no puede quedar vacio");

                NombreTextBox.Focus();
                paso = false;
            }

            if (GarantesBLL.Existe(Utilidades.ToInt(NombreTextBox.Text)))
            {
                MessageBox.Show("Este nombre del garante ya existe en la base de datos");

                NombreTextBox.Focus();
                paso = false;
            }

            if (GarantesBLL.Existe(Utilidades.ToInt(GaranteIDTextBox.Text)))
            {
                MessageBox.Show("Este id del garante ya existe en la base de datos");

                GaranteIDTextBox.Focus();
                paso = false;
            }

            return paso;
        }

        private bool ExisteEnLaBaseDeDatos()
        {
            Garantes garante = GarantesBLL.Buscar(Utilidades.ToInt(GaranteIDTextBox.Text));

            return (garante != null);
        }

        private void LlenarCampos(Garantes garante)
        {
            GaranteIDTextBox.Text = garante.GaranteId.ToString();
            NombreTextBox.Text = garante.Nombres;
            CedulaTextBox.Text = garante.Cedula;
            TelefonoTextBox.Text = garante.Telefono;
            DireccionTextBox.Text = garante.Direccion;
            parentescoTextBox.Text = garante.Parentesco;
           
        }

        private  Garantes LlenarClase()
        {
            Garantes garante = new Garantes();
            garante.GaranteId = Utilidades.ToInt(GaranteIDTextBox.Text);
            garante.Nombres = NombreTextBox.Text;
            garante.Cedula = CedulaTextBox.Text;
            garante.Telefono = TelefonoTextBox.Text;
            garante.Direccion = DireccionTextBox.Text;
            garante.Parentesco = parentescoTextBox.Text;

            return garante;


        }

        private void Limpiar()
        {
            GaranteIDTextBox.Clear();
            NombreTextBox.Clear();
            CedulaTextBox.Clear();
            TelefonoTextBox.Clear();
            DireccionTextBox.Clear();
            parentescoTextBox.Clear();
        }

        private void Nuevo_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            Garantes garante;
            bool paso = false;
            if (!Validar())
            {
                return;
            }

            garante = LlenarClase();
            paso = GarantesBLL.Guardar(garante);

            if (!ExisteEnLaBaseDeDatos())
            {
                Limpiar();
                MessageBox.Show("Garante guardado correctamente", "Guardado", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                Limpiar();
                MessageBox.Show("Garante modificado correctamente", "Guardado", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            int id;
            int.TryParse(GaranteIDTextBox.Text, out id);
            Limpiar();
            if (GarantesBLL.Eliminar(id))
            {
                MessageBox.Show("Garante eliminado correctamente", "Proceso exitoso", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("ID no existe en la base de datos");
            }
        }

        
    }
}
