using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica
{
    [Table("Consultas")]
    public class Consulta
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public DateTime Hora { get; set; }
        public Paciente Paciente { get; set; }
        public Medico Medico { get; set; }
        public Secretaria Secretaria { get; set; }
    }

}
