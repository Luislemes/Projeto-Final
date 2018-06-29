using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelos;

namespace Controles
{
    public class ConsultaController
    {
        HospitalContext ctx = new HospitalContext();

        public void createConsulta(Consulta consulta)
        {
            Consulta c = new Consulta();
            c.Hora = consulta.Hora;
            c.Medico = consulta.Medico;
            c.Paciente = consulta.Paciente;
            c.Secretaria = consulta.Secretaria;

            ctx.Consultas.Add(c);
            ctx.SaveChanges();
        }

        public IList<Consulta> readConsultas()
        {
            var consultas = (from consulta in ctx.Consultas select consulta).ToList();

            foreach (var ct in consultas)
            {
                ct.Medico = (from cs in ctx.Consultas
                             join med in ctx.Medicos on cs.Medico.MedicoId equals med.MedicoId
                             where cs.Id == ct.Id
                             select med).SingleOrDefault();

                ct.Secretaria = (from cs in ctx.Consultas
                                 join sc in ctx.Secretarias on cs.Secretaria.SecretariaId equals sc.SecretariaId
                                 where cs.Id == ct.Id
                                 select sc).SingleOrDefault();

                ct.Paciente = (from cs in ctx.Consultas
                               join pc in ctx.Pacientes on cs.Paciente.PacienteId equals pc.PacienteId
                               where cs.Id == ct.Id
                               select pc).SingleOrDefault();
            }

            return consultas;
        }

        public Consulta readConsulta(int consultaId)
        {
            var tempConsulta = (from consulta in ctx.Consultas
                                where consulta.Id == consultaId
                                select consulta).SingleOrDefault();

            tempConsulta.Medico = (from cs in ctx.Consultas
                                   join med in ctx.Medicos on cs.Medico.MedicoId equals med.MedicoId
                                   where cs.Id == consultaId
                                   select med).SingleOrDefault();

            tempConsulta.Secretaria = (from cs in ctx.Consultas
                                       join sc in ctx.Secretarias on cs.Secretaria.SecretariaId equals sc.SecretariaId
                                       where cs.Id == consultaId
                                       select sc).SingleOrDefault();

            tempConsulta.Paciente = (from cs in ctx.Consultas
                                     join pc in ctx.Pacientes on cs.Paciente.PacienteId equals pc.PacienteId
                                     where cs.Id == consultaId
                                     select pc).SingleOrDefault();


            return tempConsulta;
        }

        public void updateConsulta(Consulta Consulta)
        {
            var tempConsulta = ctx.Consultas.SingleOrDefault(c => c.Id == Consulta.Id);
            tempConsulta.Medico = Consulta.Medico;
            tempConsulta.Paciente = Consulta.Paciente;
            tempConsulta.Secretaria = Consulta.Secretaria;
            tempConsulta.Hora = Consulta.Hora;
            ctx.SaveChanges();
        }

        public void deleteConsulta(Consulta Consulta)
        {
            if (Consulta.Id != 0)
            {
                ctx.Consultas.Remove(Consulta);
                ctx.SaveChanges();
            }
        }
    }

}