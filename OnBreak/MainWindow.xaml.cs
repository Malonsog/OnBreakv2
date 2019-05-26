using MahApps.Metro.Controls;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OnBreak
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click_AdminClientes(object sender, RoutedEventArgs e)
        {
            VentanaAdminClientes win1 = new VentanaAdminClientes();
            win1.Show();
            this.Close();
        }

        private void Button_Click_ListadoContratos(object sender, RoutedEventArgs e)
        {
            VentanaListadoContratos win1 = new VentanaListadoContratos();
            win1.Show();
            this.Close();
        }

        private void Button_Click_Contraste(object sender, RoutedEventArgs e)
        {
            Container.Background = Container.Background.Equals(Brushes.Black) ? Brushes.White : Brushes.Black;
        }

        private void Button_Click_ListadoClientes(object sender, RoutedEventArgs e)
        {
            VentanaListadoCliente listadoCliente = new VentanaListadoCliente();
            listadoCliente.Show();
            this.Close();
        }
    }
}
