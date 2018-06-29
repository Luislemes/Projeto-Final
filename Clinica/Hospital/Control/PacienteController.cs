using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Control
{
    class PacienteController
    {
        Model.HospitalContext ctx = new Model.HospitalContext();

        public void createPaciente(Model.Paciente Paciente)
        {
            Model.Paciente p = new Model.Paciente();
            p.Nome = Paciente.Nome;
            p.Nascimento = Paciente.Nascimento;
            p.Telefone = Paciente.Telefone;
            p.CPF = Paciente.CPF;
            p.Convenio = Paciente.Convenio;

            ctx.Pacientes.Add(p);
            ctx.SaveChanges();
        }

        public void deletePaciente(Model.Paciente Paciente)
        {
            if (Paciente.PacienteId != 0)
            {
                ctx.Pacientes.Remove(Paciente);
                ctx.SaveChanges();
            }
        }

        public IList<Model.Paciente> readPacientes()
        {
            var Pacientes = from Paciente in ctx.Pacientes select Paciente;
            return Pacientes.ToList();
        }

        public void updatePaciente(Model.Paciente Paciente)
        {
            var tempPaciente = ctx.Pacientes.SingleOrDefault(c => c.PacienteId == Paciente.PacienteId);
            tempPaciente.Nome = Paciente.Nome;
            tempPaciente.Nascimento = Paciente.Nascimento;
            tempPaciente.Telefone = Paciente.Telefone;
            tempPaciente.CPF = Paciente.CPF;
            tempPaciente.Convenio = Paciente.Convenio;
            ctx.SaveChanges();
        }
    }

}
