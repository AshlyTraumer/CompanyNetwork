using System.Collections.Generic;
using System.Linq;
using CompanyNetwork.BaseTree;
using CompanyNetwork.Core.TreeStructure.Nodes;
using DomenModel.Models;
using CitizenshipDescription = CompanyNetwork.Core.TreeStructure.Nodes.CitizenshipDescription;

namespace CompanyNetwork.Core.TreeStructure
{
    public static class TreeCreator
    {
        public static DepartamentNode Root { get; private set; }

        public static DepartamentNode MakeTree(List<Departament> list)
        {
            Root = NodeCreator(list.Single(q => q.ParentId == null), list);

            return Root;
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
                   .SetNationality(
                   new CitizenshipDescription
                   {
                       Id = employee.CitizenshipDescription.Id,
                       Name = employee.CitizenshipDescription.Name
                   })
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

    }
}