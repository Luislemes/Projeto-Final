using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Control
{
    public class MedicoController
    {
        Model.HospitalContext ctx = new Model.HospitalContext();

        public void createMedico(String nome, DateTime nasc, String fone, String cpf, Model.Conta conta, string crm, Model.Especialidade especialidade, String turno)
        {
            Model.Medico m = new Model.Medico();
            m.Nome = nome;
            m.Nascimento = nasc;
            m.Telefone = fone;
            m.CPF = cpf;
            m.conta = conta;
            m.CRM = crm;
            m.Especialidade = especialidade;
            m.Turno = turno;

            ctx.Medicos.Add(m);
            ctx.SaveChanges();
        }

        public void deleteMedico(Model.Medico medico)
        {
            if (medico.MedicoId != 0)
            {
                ctx.Medicos.Remove(medico);
                ctx.SaveChanges();
            }
        }

        public IList<Model.Medico> readMedicos()
        {
            var medicos = from medico in ctx.Medicos select medico;
            return medicos.ToList();
        }

        public void updateMedico(Model.Medico medico)
        {
            var tempMedico = ctx.Medicos.SingleOrDefault(c => c.MedicoId == medico.MedicoId);
            tempMedico.Nome = medico.Nome;
            tempMedico.Nascimento = medico.Nascimento;
            tempMedico.Telefone = medico.Telefone;
            tempMedico.CPF = medico.CPF;
            tempMedico.conta = medico.conta;
            tempMedico.CRM = medico.CRM;
            tempMedico.Especialidade = medico.Especialidade;
            tempMedico.Turno = medico.Turno;
            ctx.SaveChanges();
        }
    }

}
