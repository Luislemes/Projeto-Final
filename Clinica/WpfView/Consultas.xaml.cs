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
using Controles;
using Modelos;

namespace WpfView
{
    /// <summary>
    /// Lógica interna para Consultas.xaml
    /// </summary>
    public partial class Consultas : Window
    {
        public Consultas()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ConsultaController ConsultaController = new Controles.ConsultaController();
            dgConsultas.ItemsSource = ConsultaController.readConsultas();
        }

        private void dgConsultas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dg = ((DataGrid)sender);
            Consulta med = (Consulta)dg.Items[dg.SelectedIndex];
        }

        private void dgConsultas_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var currentRowIndex = dgConsultas.Items.IndexOf(dgConsultas.SelectedItem);
            {
                if (dgConsultas.SelectedItem != null)
                {
                    int consultaId = ((Consulta)dgConsultas.SelectedItem).Id;
                    UpdateConsulta updateConsulta = new UpdateConsulta(consultaId);
                    updateConsulta.ShowDialog();
                }
            }
        }
    }
}