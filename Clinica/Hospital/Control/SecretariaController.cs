using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Control
{
    class SecretariaController
    {
        Model.HospitalContext ctx = new Model.HospitalContext();

        public void createSecretaria(String nome, String cpf, DateTime nascimento, String telefone, String turno)
        {
            Model.Secretaria s = new Model.Secretaria();
            s.Nome = nome;
            s.CPF = cpf;
            s.Nascimento = nascimento;
            s.Telefone = telefone;
            s.Turno = turno;

            ctx.Secretarias.Add(s);
            ctx.SaveChanges();
        }

        public void popularSecretariias()
        {
            this.createSecretaria("Angelica", "1111111", DateTime.Now, "2222222", "Noturno");
            this.createSecretaria("Gertrudez", "222222", DateTime.Now, "3333333", "Manhã");
            this.createSecretaria("Antonieta", "333333", DateTime.Now, "4444444", "Noturno");
        }

        public IList<Model.Secretaria> readSecretaria()
        {
            var secretarias = from secretaria in ctx.Secretarias select secretaria;
            return secretarias.ToList();
        }
    }

}
