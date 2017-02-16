using System.Collections.Generic;
using System.Linq;
using DomenModel.Enums;

namespace CompanyNetwork.BaseTree
{
    public class DepartamentNode
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public Countries Country { get; private set; }
        public IReadOnlyList<DepartamentNode> Children;
        public IReadOnlyList<Employee> Employees;

        public DepartamentNode(int id, string name, Countries country, IEnumerable<DepartamentNode> children, IEnumerable<Employee> employee)
        {
            Id = id;
            Name = name;
            Country = country;
            Children = children.ToList();
            Employees = employee.ToList();
        }


    }
}