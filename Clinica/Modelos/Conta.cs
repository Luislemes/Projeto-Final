using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    [Table("Contas")]
    public class Conta
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public String Banco { get; set; }
        public String ContaCorrente { get; set; }
        public int Agencia { get; set; }

        public override String ToString()
        {
            return (this.ContaCorrente);
        }
    }

}
