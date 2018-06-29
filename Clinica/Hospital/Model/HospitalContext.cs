using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Model
{
    public class HospitalContext : DbContext
    {
        public DbSet<Conta> Contas { get; set; }
        public DbSet<Consulta> Consultas { get; set; }
        public DbSet<Convenio> Convenios { get; set; }
        public DbSet<Especialidade> Especialidades { get; set; }
        public DbSet<Medico> Medicos { get; set; }
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Secretaria> Secretarias { get; set; }

        public HospitalContext() : base("DataContext") { }
    }

}
