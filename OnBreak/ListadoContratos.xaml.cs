using MahApps.Metro.Controls;
using OnBreak.Datos;
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

namespace OnBreak
{
    /// <summary>
    /// Interaction logic for VentanaListadoContratos.xaml
    /// </summary>
    public partial class VentanaListadoContratos : MetroWindow
    {
        public VentanaListadoContratos()
        {
            InitializeComponent();
            CargarTipos();
        }

        private void CargarTipos()
        {
            cboTipoContrato.ItemsSource = new TipoEmpresa().ReadAll();
            cboTipoContrato.DisplayMemberPath = "Descripcion";
            cboTipoContrato.SelectedValuePath = "CodigoTipo";
            cboTipoContrato.SelectedIndex = 0;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
