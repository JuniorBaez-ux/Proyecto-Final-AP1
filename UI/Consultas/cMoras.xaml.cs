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
    /// Interaction logic for cMoras.xaml
    /// </summary>
    public partial class cMoras : Window
    {
        public cMoras()
        {
            InitializeComponent();
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var listado = new List<Moras>();

            if (CriterioTextBox.Text.Trim().Length > 0)
            {
                switch (FiltroComboBox.SelectedIndex)
                {
                    case 0: //NegocioId
                        int.TryParse(CriterioTextBox.Text, out int NegocioId);
                        listado = MorasBLL.GetList(a => a.MoraId == NegocioId);
                        break;

                    case 1: //Monto
                        Decimal.TryParse(CriterioTextBox.Text, out decimal Monto);
                        listado = MorasBLL.GetList(a => a.Monto == Monto);
                        break;
                }
            }
            else
            {
                listado = MorasBLL.GetList(c => true);
            }
            if (DesdeDataPicker.SelectedDate != null)
                listado = listado.Where(c => c.Fecha.Date >= DesdeDataPicker.SelectedDate).ToList();

            if (HastaDatePicker.SelectedDate != null)
                listado = listado.Where(c => c.Fecha.Date <= HastaDatePicker.SelectedDate).ToList();


            DatosDataGrid.ItemsSource = null;
            DatosDataGrid.ItemsSource = listado;
        }
    }
}
