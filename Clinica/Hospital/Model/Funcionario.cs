using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Model
{
    public class Funcionario : Pessoa
    {
        public String Turno { get; set; }
        public Conta conta { get; set; }
    }

}
