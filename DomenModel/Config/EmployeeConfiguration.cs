using System.Data.Entity.ModelConfiguration;
using DomenModel.Models;

namespace DomenModel.Config
{
    class EmployeeConfiguration : EntityTypeConfiguration<Employee>
    {
        public EmployeeConfiguration()
        {
            HasKey(p => p.Id);


            ToTable("dbo.Employee");
        }
    }
}
