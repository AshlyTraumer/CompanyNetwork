using CompanyNetwork.Models;
using System.Linq;
using CompanyNetwork.Models.InfoModels;


namespace CompanyNetwork.Core.OrderFilter
{
    public static class OrderFilter
    {
        public static IQueryable<TableViewModel> OrderBy(
            this IQueryable<TableViewModel> source, string orderByProperty, bool desc)
        {

            if (orderByProperty == "Id")
                return (desc)
                    ? source.OrderByDescending(x => x.Id)
                    : source.OrderBy(x => x.Id);

            if (orderByProperty == "FirstName")
                return (desc)
                    ? source.OrderByDescending(x => x.FirstName)
                    : source.OrderBy(x => x.FirstName);

            if (orderByProperty == "Citizenship")
            {
                return (desc)
                    ? source.OrderByDescending(x => x.Citizenship.Name)
                    : source.OrderBy(x => x.Citizenship.Name);                
            }

            if (orderByProperty == "DateOfBirth")
                return (desc)
                    ? source.OrderByDescending(x => x.DateOfBirth)
                    : source.OrderBy(x => x.DateOfBirth);

            if (orderByProperty == "DateOfEmployment")
                return (desc)
                    ? source.OrderByDescending(x => x.DateOfEmployment)
                    : source.OrderBy(x => x.DateOfDismissal);

            if (orderByProperty == "DepartamentTitle")
                return (desc)
                    ? source.OrderByDescending(x => x.DepartamentTitle)
                    : source.OrderBy(x => x.DepartamentTitle);

            if (orderByProperty == "Language")
                return (desc)
                    ? source.OrderByDescending(x => x.Language)
                    : source.OrderBy(x => x.Language);


            if (orderByProperty == "Salary")
                return (desc)
                    ? source.OrderByDescending(x => x.Salary)
                    : source.OrderBy(x => x.Salary);

            if (orderByProperty == "Sex")
                return (desc)
                    ? source.OrderByDescending(x => x.Sex)
                    : source.OrderBy(x => x.Sex);

            return null;
        }
    }
}