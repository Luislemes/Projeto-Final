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
    /// Interação lógica para UpdatePaciente.xaml
    /// </summary>
    public partial class UpdatePaciente : Window
    {
        public UpdatePaciente(int pacienteId)
        {
            InitializeComponent();

            Load_Paciente(pacienteId);
        }

        private void Load_Paciente(int pacienteId)
        {
            // preencher dropdown convenio
            ConvenioController convenio = new ConvenioController();
            cbConvenio.ItemsSource = convenio.readConvenios();

            PacienteController pacienteController = new PacienteController();
            Paciente paciente = pacienteController.readPaciente(pacienteId);

            txtId.Text = paciente.PacienteId.ToString();
            txtNome.Text = paciente.Nome;
            txtCPF.Text = paciente.CPF;
            txtTelefone.Text = paciente.Telefone;
            dpDataNascimento.SelectedDate = paciente.Nascimento;

            cbConvenio.SelectedValue = paciente.Convenio.Id;
        }

        private void btnSalvar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // validar
                if (string.IsNullOrEmpty(txtNome.Text))
                    throw new NullReferenceException("O campo nome é obrigatório.");
                if (string.IsNullOrEmpty(txtCPF.Text))
                    throw new NullReferenceException("O campo CPF é obrigatório.");
                if (string.IsNullOrEmpty(txtTelefone.Text))
                    throw new NullReferenceException("O campo Telefone é obrigatório.");
                if (cbConvenio.SelectedItem == null)
                    throw new NullReferenceException("O campo Convenio é obrigatório.");
                if (dpDataNascimento.SelectedDate == null)
                    throw new NullReferenceException("A campo Data de Nascimento é obrigatório.");

                Paciente paciente = new Paciente();
                paciente.PacienteId = Convert.ToInt32(txtId.Text);
                paciente.Nome = txtNome.Text;
                paciente.CPF = txtCPF.Text;
                paciente.Telefone = txtTelefone.Text;
                paciente.Nascimento = (DateTime)dpDataNascimento.SelectedDate;
                paciente.Convenio = (Convenio)cbConvenio.SelectedItem;

                PacienteController pacienteController = new PacienteController();
                pacienteController.updatePaciente(paciente);

                MessageBox.Show("Paciente salvo com sucesso!");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar o Paciente (" + ex.Message + ")");
            }
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}