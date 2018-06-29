using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controles
{
    public class ConvenioController
    {
        HospitalContext ctx = new HospitalContext();

        public void createConvenio(String nome, String empresa, String telefone)
        {
            Convenio c = new Convenio();
            c.Nome = nome;
            c.Empresa = empresa;
            c.Telefone = telefone;

            ctx.Convenios.Add(c);
            ctx.SaveChanges();
        }

        public void populateConvenio()
        {
            this.createConvenio("Unimed Premium", "Unimed", "123456");
            this.createConvenio("Amil Standard", "Amil", "234567");
        }

        public IList<Convenio> readConvenios()
        {
            var convenios = from convenio in ctx.Convenios select convenio;
            return convenios.ToList();
        }
    }

}
