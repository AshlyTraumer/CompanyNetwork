using DomenModel.Models;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomenModel.Config
{
    class CitizenshipDescriptionConfiguration : EntityTypeConfiguration<CitizenshipDescription>
    {
        public CitizenshipDescriptionConfiguration()
        {
            Property(p => p.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            HasMany(q => q.Employees)
                .WithRequired(q => q.CitizenshipDescription)
                .HasForeignKey(q => q.Citizenship);

            ToTable("dbo.CitizenshipDescription");
        }
    }
}
