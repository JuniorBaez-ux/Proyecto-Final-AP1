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
    /// Lógica de interacción para cGarantes.xaml
    /// </summary>
    public partial class cGarantes : Window
    {
        public cGarantes()
        {
            InitializeComponent();
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {

            var listado = new List<Garantes>();

            if (CriterioTextBox.Text.Trim().Length > 0)
            {
                switch (FiltroComboBox.SelectedIndex)
                {
                    case 0: //GaranteId
                        int.TryParse(CriterioTextBox.Text, out int GaranteId);
                        listado = GarantesBLL.GetList(a => a.GaranteId == GaranteId);
                        break;

                    case 1: //Nombre
                        listado = GarantesBLL.GetList(a => a.Nombres.ToLower().Contains(CriterioTextBox.Text.ToLower()));
                        break;
                }
            }
            else
            {
                listado = GarantesBLL.GetList(c => true);
            }

            DatosDataGrid.ItemsSource = null;
            DatosDataGrid.ItemsSource = listado;
        }
    }
}
