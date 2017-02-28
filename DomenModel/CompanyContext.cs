using System.Data.Entity;
using DomenModel.Config;
using DomenModel.Models;

namespace DomenModel
{
    public class CompanyContext : DbContext
    {
        public CompanyContext() : base("CompanyNetworks")
        {
        }

        public DbSet<Departament> Departaments { get; set; }
        public DbSet<Employee> Emloyees { get; set; }
        public DbSet<CitizenshipDescription> CitizenshipDescriptions { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new DepartamentConfiguration());
            modelBuilder.Configurations.Add(new EmployeeConfiguration());
            modelBuilder.Configurations.Add(new CitizenshipDescriptionConfiguration());
        }
    }
}
