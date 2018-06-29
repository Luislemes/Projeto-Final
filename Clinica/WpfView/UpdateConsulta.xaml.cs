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
    /// Lógica interna para UpdateConsulta.xaml
    /// </summary>
    public partial class UpdateConsulta : Window
    {
        public UpdateConsulta(int consultaId)
        {
            InitializeComponent();

            Load_Consulta(consultaId);
        }
        private void Load_Consulta(int consultaId)
        {
            // preencher dropdown medico
            MedicoController medicoController = new MedicoController();
            cbMedico.ItemsSource = medicoController.readMedicos();

            // preencher dropdown paciente
            PacienteController pacienteController = new PacienteController();
            cbPaciente.ItemsSource = pacienteController.readPacientes();

            // preencher dropdown secretaria
            SecretariaController secretariaController = new SecretariaController();
            cbSecretaria.ItemsSource = secretariaController.readSecretaria();

            ConsultaController consultaController = new ConsultaController();

            Consulta consulta = consultaController.readConsulta(consultaId);

            txtId.Text = consulta.Id.ToString();
            cbMedico.SelectedItem = consulta.Medico;
            cbPaciente.SelectedItem = consulta.Paciente;
            cbSecretaria.SelectedItem = consulta.Secretaria;
            dpConsulta.SelectedDate = consulta.Hora;
        }

        private void btnSalvar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // validar
                if (cbMedico.SelectedItem == null)
                    throw new NullReferenceException("O campo Médico é obrigatório.");
                if (cbPaciente.SelectedItem == null)
                    throw new NullReferenceException("O campo Paciente é obrigatório.");
                if (cbSecretaria.SelectedItem == null)
                    throw new NullReferenceException("O campo Secretária é obrigatório.");
                if (dpConsulta.SelectedDate == null)
                    throw new NullReferenceException("A campo Data da Consulta é obrigatório.");

                Consulta consulta = new Consulta();

                consulta.Id = Convert.ToInt32(txtId.Text);
                consulta.Medico = (Medico)cbMedico.SelectedItem;
                consulta.Paciente = (Paciente)cbPaciente.SelectedItem;
                consulta.Secretaria = (Secretaria)cbSecretaria.SelectedItem;
                consulta.Hora = (DateTime)dpConsulta.SelectedDate;

                ConsultaController consultaController = new ConsultaController();
                consultaController.createConsulta(consulta);

                MessageBox.Show("Consulta salva com sucesso!");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar o consulta (" + ex.Message + ")");
            }
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}