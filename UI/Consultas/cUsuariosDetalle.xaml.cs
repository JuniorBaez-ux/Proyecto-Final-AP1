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
    /// Interaction logic for cUsuariosDetalle.xaml
    /// </summary>
    public partial class cUsuariosDetalle : Window
    {
        public cUsuariosDetalle()
        {
            InitializeComponent();
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var listado = new List<UsuariosDetalle>();

            if (CriterioTextBox.Text.Trim().Length > 0)
            {
                switch (FiltroComboBox.SelectedIndex)
                {
                    case 0: //Id
                        int.TryParse(CriterioTextBox.Text, out int UsuarioId);
                        listado = UsuariosDetalleBLL.GetList(a => a.UsuarioId == UsuarioId);
                        break;
                }
            }
            else
            {
                listado = UsuariosDetalleBLL.GetList(c => true);
            }
            DatosDataGrid.ItemsSource = null;
            DatosDataGrid.ItemsSource = listado;
        }
    }
}
