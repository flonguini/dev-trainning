using System;
using System.Windows;

namespace MVVMApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            MessageBox.Show("Ocorreu um erro inesperado" + Environment.NewLine + e.Exception.Message);
        }
    }
}
