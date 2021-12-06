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

namespace Proyecto_Final_AP1.UI.Consultas
{
    /// <summary>
    /// Lógica de interacción para cEstadosCiviles.xaml
    /// </summary>
    public partial class cEstadosCiviles : Window
    {
        public cEstadosCiviles()
        {
            InitializeComponent();
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var listado = new List<EstadosCiviles>();

            if (CriterioTextBox.Text.Trim().Length > 0)
            {
                switch (FiltroComboBox.SelectedIndex)
                {
                    case 0: //EstadoCivilId
                        int.TryParse(CriterioTextBox.Text, out int EstadoCivilId);
                        listado = EstadosCivilesBLL.GetList(a => a.EstadoCivilId == EstadoCivilId);
                        break;

                    case 1: //Descripcion
                        listado = EstadosCivilesBLL.GetList(a => a.Descripcion.ToLower().Contains(CriterioTextBox.Text.ToLower()));
                        break;
                }
            }
            else
            {
                listado = EstadosCivilesBLL.GetList(c => true);
            }

            DatosDataGrid.ItemsSource = null;
            DatosDataGrid.ItemsSource = listado;
        }

        private void CriterioTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                var listado = new List<EstadosCiviles>();

                if (CriterioTextBox.Text.Trim().Length > 0)
                {
                    switch (FiltroComboBox.SelectedIndex)
                    {
                        case 0: //EstadoCivilId
                            int.TryParse(CriterioTextBox.Text, out int EstadoCivilId);
                            listado = EstadosCivilesBLL.GetList(a => a.EstadoCivilId == EstadoCivilId);
                            break;

                        case 1: //Descripcion
                            listado = EstadosCivilesBLL.GetList(a => a.Descripcion.ToLower().Contains(CriterioTextBox.Text.ToLower()));
                            break;
                    }
                }
                else
                {
                    listado = EstadosCivilesBLL.GetList(c => true);
                }

                DatosDataGrid.ItemsSource = null;
                DatosDataGrid.ItemsSource = listado;
            }
        }
    }
}
