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
    /// Interaction logic for cPrestamosDetalle.xaml
    /// </summary>
    public partial class cPrestamosDetalle : Window
    {
        public cPrestamosDetalle()
        {
            InitializeComponent();
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var listado = new List<PrestamosDetalle>();

            if (CriterioTextBox.Text.Trim().Length > 0)
            {
                switch (FiltroComboBox.SelectedIndex)
                {
                    case 0: //Prestamo Id
                        int.TryParse(CriterioTextBox.Text, out int PrestamoId);
                        listado = PrestamosDetalleBLL.GetList(a => a.PrestamoId == PrestamoId);
                        break;
                }
            }
            else
            {
                listado = PrestamosDetalleBLL.GetList(c => true);
            }

            if (DesdeDataPicker.SelectedDate != null)
                listado = listado.Where(c => c.FechaCuota.Date >= DesdeDataPicker.SelectedDate).ToList();

            if (HastaDatePicker.SelectedDate != null)
                listado = listado.Where(c => c.FechaCuota.Date <= HastaDatePicker.SelectedDate).ToList();

            DatosDataGrid.ItemsSource = null;
            DatosDataGrid.ItemsSource = listado;
        }

        private void CriterioTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                var listado = new List<PrestamosDetalle>();

                if (CriterioTextBox.Text.Trim().Length > 0)
                {
                    switch (FiltroComboBox.SelectedIndex)
                    {
                        case 0: //Prestamo Id
                            int.TryParse(CriterioTextBox.Text, out int PrestamoId);
                            listado = PrestamosDetalleBLL.GetList(a => a.PrestamoId == PrestamoId);
                            break;
                    }
                }
                else
                {
                    listado = PrestamosDetalleBLL.GetList(c => true);
                }

                if (DesdeDataPicker.SelectedDate != null)
                    listado = listado.Where(c => c.FechaCuota.Date >= DesdeDataPicker.SelectedDate).ToList();

                if (HastaDatePicker.SelectedDate != null)
                    listado = listado.Where(c => c.FechaCuota.Date <= HastaDatePicker.SelectedDate).ToList();

                DatosDataGrid.ItemsSource = null;
                DatosDataGrid.ItemsSource = listado;
            }
        }
    }
}
