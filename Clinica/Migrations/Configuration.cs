using System;
using System.Data.Entity.Migrations;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Hospital.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<Hospital.Modelos.HospitalContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Hospital.Modelos.HospitalContext";
        }

        protected override void Seed(Hospital.Modelos.HospitalContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            //
        }
    }
}
