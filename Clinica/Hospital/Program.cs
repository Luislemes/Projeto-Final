using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital
{
    static class Program
    {
        
        [STAThread]
        static void Main()
        {
            Control.ContaController cControl = new Control.ContaController();
            Control.ConvenioController convControl = new Control.ConvenioController();
            Control.SecretariaController sControl = new Control.SecretariaController();

            var contas = cControl.readContas();
            if (contas.Count == 0)
            {
                cControl.populateContas();
            }

            var secretarias = sControl.readSecretaria();
            if (secretarias.Count == 0)
            {
                sControl.popularSecretariias();
            }

            var convenios = convControl.readConvenios();
            if (convenios.Count == 0)
            {
                convControl.populateConvenio();
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new View.Medicos());
        }
    }

}
