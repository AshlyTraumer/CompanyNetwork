using System.Collections.Generic;
using System.Linq;
using CompanyNetwork.Models;
using DomenModel.Models;

namespace CompanyNetwork.BaseTree
{
    public static class TreeCreator
    {
        public static DepartamentNode _root { get; private set; }

        public static DepartamentNode MakeTree(List<Departament> list)
        {
            _root =  NodeCreator(list.Single(q => q.ParentId == null), list);
            return _root;
        }

        private static DepartamentNode NodeCreator(Departament item, List<Departament> list)
        {
            return new DepartamentNode(
                item.Id,
                item.Name,
                item.Country,
                GetChildren(item.Id, list),
                item.Employees.Select(employee =>
                    new EmployeeBuilder(employee.Id)
                        .SetDateOfBirth(employee.DateOfBirth)
                        .SetDateOfDismissal(employee.DateOfDismissal)
                        .SetDateOfEmployment(employee.DateOfEmployment)
                        .SetDepartamentId(employee.DepartamentId)
                        .SetFirstName(employee.FirstName)
                        .SetFlags(employee.IsReadyForMoving, employee.IsReadyForBusinessTrip)
                        .SetLanguage(employee.Language)
                        .SetLastName(employee.LastName)
                        .SetNationality(employee.Сitizenship)
                        .SetName(employee.Name)
                        .SetSalary(employee.Salary)
                        .SetSex(employee.Sex)
                        .Build()).ToList());
        }

        private static List<DepartamentNode> GetChildren(int id, List<Departament> list)
        {
            return list
                .Where(q => q.ParentId == id)
                .Select(child => NodeCreator(child, list))
                .ToList();
        }

        public static List<DepartamentModel> Count()
        {
            var test = new List<DepartamentModel>
            {
                
            };
            return new List<DepartamentModel>();
        }

    }
}