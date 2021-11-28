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

namespace Proyecto_Final_AP1.UI.Consultas
{
    /// <summary>
    /// Interaction logic for cPrestamos.xaml
    /// </summary>
    public partial class cPrestamos : Window
    {
        public cPrestamos()
        {
            InitializeComponent();
        }

        private void BuscarCriterioButton_Click(object sender, RoutedEventArgs e)
        {
            var lista = new List<Prestamos>();

            if (CriterioTextBox.Text.Trim().Length > 0)
            {
                switch (FiltroComboBox.SelectedIndex)
                {
                    case 0: //ProyectoId
                        int.TryParse(CriterioTextBox.Text, out int PrestamosId);
                        lista = PrestamosBLL.GetList(a => a.PrestamoId == PrestamosId);
                        break;

                    //case 1: //DescripcionProyectp
                    //    lista = ProyectosBLL.GetList(a => a.DescripcionProyecto.ToLower().Contains(CriterioTextBox.Text.ToLower()));
                    //    break;
                }
            }
            else
            {
                lista = PrestamosBLL.GetList(c => true);
            }

            //if (DesdeDataPicker.SelectedDate != null)
            //    lista = lista.Where(c => c.Fecha.Date >= DesdeDatePicker.SelectedDate).ToList();

            //if (HastaDatePicker.SelectedDate != null)
            //    lista = lista.Where(c => c.Fecha.Date <= HastaDatePicker.SelectedDate).ToList();

            DetalleDataGrid.ItemsSource = null;
            DetalleDataGrid.ItemsSource = lista;
        }
    }
}
