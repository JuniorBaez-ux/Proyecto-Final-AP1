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
    /// Lógica de interacción para cTipoViviendas.xaml
    /// </summary>
    public partial class cTipoViviendas : Window
    {
        public cTipoViviendas()
        {
            InitializeComponent();
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var listado = new List<TipoViviendas>();

            if (CriterioTextBox.Text.Trim().Length > 0)
            {
                switch (FiltroComboBox.SelectedIndex)
                {
                    case 0: //TipoViviendasId
                        int.TryParse(CriterioTextBox.Text, out int TipoViviendasId);
                        listado = TipoViviendasBLL.GetList(a => a.TipoViviendasId == TipoViviendasId);
                        break;

                    case 1: //Descripcion
                        listado = TipoViviendasBLL.GetList(a => a.Descripcion.ToLower().Contains(CriterioTextBox.Text.ToLower()));
                        break;
                }
            }
            else
            {
                listado = TipoViviendasBLL.GetList(c => true);
            }

            DatosDataGrid.ItemsSource = null;
            DatosDataGrid.ItemsSource = listado;
        }
    }
}
