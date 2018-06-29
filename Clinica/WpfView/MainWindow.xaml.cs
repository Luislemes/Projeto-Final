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
using Controles;
using Modelos;
namespace WpfView
{
    /// <summary>
    /// Interação lógica para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnMedicos_Click(object sender, RoutedEventArgs e)
        {
            Medicos medicos = new Medicos();
            medicos.ShowDialog();
        }
        private void btnNewMedico_Click(object sender, RoutedEventArgs e)
        {
            NewMedico newMedico = new NewMedico();
            newMedico.ShowDialog();
        }
        private void btnUpdateMedico_Click(object sender, RoutedEventArgs e)
        {
            UpdateMedico medico = new UpdateMedico(0);
            medico.ShowDialog();
        }

        private void btnConsultas_Click(object sender, RoutedEventArgs e)
        {
            Consultas consultas = new Consultas();
            consultas.ShowDialog();
        }
        private void btnNewConsulta_Click(object sender, RoutedEventArgs e)
        {
            NewConsulta consulta = new NewConsulta();
            consulta.ShowDialog();
        }
        private void btnUpdateConsulta_Click(object sender, RoutedEventArgs e)
        {
            UpdateConsulta consulta = new UpdateConsulta(0);
            consulta.ShowDialog();
        }

        private void btnPaciente_Click(object sender, RoutedEventArgs e)
        {
            PacienteView paciente = new PacienteView();
            paciente.ShowDialog();
        }
        private void btnNewPaciente_Click(object sender, RoutedEventArgs e)
        {
            NewPaciente paciente = new NewPaciente();
            paciente.ShowDialog();
        }
        private void btnUpdatePaciente_Click(object sender, RoutedEventArgs e)
        {
            UpdatePaciente paciente = new UpdatePaciente(0);
            paciente.ShowDialog();
        }
    }
}