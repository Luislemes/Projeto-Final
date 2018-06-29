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
    /// Lógica interna para NewMedico.xaml
    /// </summary>
    public partial class NewMedico : Window
    {
        public NewMedico()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // preencher dropdown contas
            ContaController contas = new ContaController();
            cbConta.ItemsSource = contas.readContas();

            // preencher dropdown especialidades
            EspecialidadeController especialidade = new EspecialidadeController();
            cbEspecialidade.ItemsSource = especialidade.readEspecialidades();
        }

        private void btnSalvar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // validar
                if (string.IsNullOrEmpty(txtNome.Text))
                    throw new NullReferenceException("O campo nome é obrigatório.");
                if (string.IsNullOrEmpty(txtCRM.Text))
                    throw new NullReferenceException("O campo CRM é obrigatório.");
                if (string.IsNullOrEmpty(txtCPF.Text))
                    throw new NullReferenceException("O campo CPF é obrigatório.");
                if (string.IsNullOrEmpty(txtTelefone.Text))
                    throw new NullReferenceException("O campo Telefone é obrigatório.");
                if (string.IsNullOrEmpty(txtTurno.Text))
                    throw new NullReferenceException("O campo Turno é obrigatório.");
                if (cbConta.SelectedItem == null)
                    throw new NullReferenceException("O campo Conta é obrigatório.");
                if (cbEspecialidade.SelectedItem == null)
                    throw new NullReferenceException("O campo Especialidade é obrigatório.");
                if (dpDataNascimento.SelectedDate == null)
                    throw new NullReferenceException("A campo Data de Nascimento é obrigatório.");

                Medico medico = new Medico();
                medico.Nome = txtNome.Text;
                medico.CRM = txtCRM.Text;
                medico.CPF = txtCPF.Text;
                medico.Telefone = txtTelefone.Text;
                medico.Turno = txtTurno.Text;
                medico.Nascimento = (DateTime)dpDataNascimento.SelectedDate;
                medico.conta = (Conta)cbConta.SelectedItem;
                medico.Especialidade = (Especialidade)cbEspecialidade.SelectedItem;

                MedicoController medicoController = new MedicoController();
                medicoController.createMedico(medico);

                MessageBox.Show("Médico salvo com sucesso!");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar o médico (" + ex.Message + ")");
            }
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}