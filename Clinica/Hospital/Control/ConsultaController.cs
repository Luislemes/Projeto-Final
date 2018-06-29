using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Control
{
    class ConsultaController
    {
        Model.HospitalContext ctx = new Model.HospitalContext();

        public void createConsulta(Model.Consulta consulta)
        {
            Model.Consulta c = new Model.Consulta();
            c.Hora = consulta.Hora;
            c.Medico = consulta.Medico;
            c.Paciente = consulta.Paciente;
            c.Secretaria = consulta.Secretaria;

            ctx.Consultas.Add(c);
            ctx.SaveChanges();
        }

        public IList<Model.Consulta> readConsulta()
        {
            var consultas = from consulta in ctx.Consultas select consulta;
            return consultas.ToList();
        }

        public void updateConsulta(Model.Consulta Consulta)
        {
            var tempConsulta = ctx.Consultas.SingleOrDefault(c => c.Id == Consulta.Id);
            tempConsulta.Medico = Consulta.Medico;
            tempConsulta.Paciente = Consulta.Paciente;
            tempConsulta.Secretaria = Consulta.Secretaria;
            tempConsulta.Hora = Consulta.Hora;
            ctx.SaveChanges();
        }

        public void deleteConsulta(Model.Consulta Consulta)
        {
            if (Consulta.Id != 0)
            {
                ctx.Consultas.Remove(Consulta);
                ctx.SaveChanges();
            }
        }
    }

}
