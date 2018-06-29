using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controles
{
    public class EspecialidadeController
    {
        HospitalContext ctx = new HospitalContext();

        public void createEspecialidade(String nome, float valor)
        {
            Especialidade esp = new Especialidade();
            esp.Nome = nome;
            esp.Valor = valor;

            ctx.Especialidades.Add(esp);
            ctx.SaveChanges();
        }

        public void populateEspecialidades()
        {
            this.createEspecialidade("Gastro", 7000);
            this.createEspecialidade("Cirurgião Plástico", 11000);
            this.createEspecialidade("Endocrino", 5000);
        }

        public IList<Especialidade> readEspecialidades()
        {
            var especialidades = from especialidade in ctx.Especialidades select especialidade;
            return especialidades.ToList();
        }

        public Especialidade getEspecialidade(int index)
        {
            var especialidades = from especialidade in ctx.Especialidades where especialidade.Id == index select especialidade;
            return (Especialidade)especialidades;
        }

    }
}