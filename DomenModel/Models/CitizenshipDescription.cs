using System.Collections.Generic;

namespace DomenModel.Models
{
    public class CitizenshipDescription
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public  ICollection<Employee> Employees { get; set; }
    }
}
