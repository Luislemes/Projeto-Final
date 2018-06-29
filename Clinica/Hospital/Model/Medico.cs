using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Model
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
