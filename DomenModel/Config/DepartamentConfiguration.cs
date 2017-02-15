using System.Data.Entity.ModelConfiguration;
using DomenModel.Models;

namespace DomenModel.Config
{
    class DepartamentConfiguration : EntityTypeConfiguration<Departament>
    {
        public DepartamentConfiguration()
        {
            HasKey(p => p.Id);

            HasMany(p => p.Employees)
               .WithRequired(p => p.Departament)
               .WillCascadeOnDelete(false); ;

            ToTable("dbo.Departament");
        }
    }
}
