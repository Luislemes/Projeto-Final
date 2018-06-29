using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Control
{
    public class ConvenioController
    {
        Model.HospitalContext ctx = new Model.HospitalContext();

        public void createConvenio(String nome, String empresa, String telefone)
        {
            Model.Convenio c = new Model.Convenio();
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

        public IList<Model.Convenio> readConvenios()
        {
            var convenios = from convenio in ctx.Convenios select convenio;
            return convenios.ToList();
        }
    }

}
