using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos 
{
    public class Funcionario : Pessoa
    {
        public String Turno { get; set; }
        public Conta conta { get; set; }
    }

}
