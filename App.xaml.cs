using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using ShowMeTheXAML;

namespace Proyecto_Final_AP1
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            MessageBox.Show("Lo sentimos, ha ocurrido una excepcion..."+ e.Exception.Message);
            e.Handled = true;
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            XamlDisplay.Init();
            base.OnStartup(e);
        }
    }
}
