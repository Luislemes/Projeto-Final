using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica
{
    [Table("Medicos")]
    public class Medico : Funcionario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MedicoId { get; set; }

        public String CRM { get; set; }
        public Especialidade Especialidade { get; set; }

    }

}
