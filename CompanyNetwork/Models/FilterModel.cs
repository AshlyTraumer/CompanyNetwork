using CompanyNetwork.Models;
using DomenModel.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace CompanyNetwork.Models
{
    public class FilterModel
    {
        public bool IsDismissal { get; set; }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public int? SalaryFrom { get; set; }
        public int? SalaryTo { get; set; }

        public int Language { get; set; }
        public int Sex { get; set; }
        public int Citizenship { get; set; }

        public bool IsReadyForMoving { get; set; }
        public bool IsReadyForBusinessTrip { get; set; }

        public string DepartamentTitle { get; set; }

        public string DateOfBirthFrom { get; set; }
        public string DateOfBirthTo { get; set; }

        public string DateOfEmploymentFrom { get; set; }
        public string DateOfEmploymentTo { get; set; }

        public int CurrentPage { get; set; }
        public int Pages { get; set; }
        public string SortId { get; set; }
        public bool IsDesc { get; set; }


        public List<Expression<Func<TableViewModel, bool>>> GetFilters()
        {
            var list = new List<Expression<Func<TableViewModel, bool>>>();

            if (Id != 0)
                list.Add(q => q.Id == Id);

            if (FirstName != null)
                list.Add(q => q.FirstName == FirstName);

            if (DepartamentTitle != null)
                list.Add(q => q.DepartamentTitle == DepartamentTitle);

            if ((SalaryFrom != null) && (SalaryTo != null))
                list.Add(q => (q.Salary >= SalaryFrom) && (q.Salary <= SalaryTo));

            if (IsDismissal == true)
                list.Add(q => q.DateOfDismissal == null);

            if (IsReadyForMoving == true)
                list.Add(q => q.IsReadyForMoving == true);

            if (IsReadyForBusinessTrip == true)
                list.Add(q => q.IsReadyForBusinessTrip == true);

            if (Sex != -1)
                list.Add(q => q.Sex == (SexOfPerson)Sex);

            if (Language != -1)
                list.Add(q => q.Language.HasFlag((Language)Language));

            if (Citizenship != 0)
                list.Add(q => q.Citizenship.Id == Citizenship);

            if ((DateOfBirthFrom != null) && (DateOfBirthTo != null))
            {
                var splitFrom = DateOfBirthFrom.Split('-');
                var dateFrom = new DateTime(int.Parse(splitFrom[0]), int.Parse(splitFrom[1]), int.Parse(splitFrom[2]));
                var splitTo = DateOfBirthTo.Split('-');
                var dateTo = new DateTime(int.Parse(splitTo[0]), int.Parse(splitTo[1]), int.Parse(splitTo[2]));
                list.Add(q => (q.DateOfBirth >= dateFrom) && (q.DateOfBirth <= dateTo));
            }

            if ((DateOfEmploymentFrom != null) && (DateOfEmploymentTo != null))
            {
                var splitFrom = DateOfEmploymentFrom.Split('-');
                var dateFrom = new DateTime(int.Parse(splitFrom[0]), int.Parse(splitFrom[1]), int.Parse(splitFrom[2]));
                var splitTo = DateOfEmploymentTo.Split('-');
                var dateTo = new DateTime(int.Parse(splitTo[0]), int.Parse(splitTo[1]), int.Parse(splitTo[2]));
                list.Add(q => (q.DateOfEmployment >= dateFrom) && (q.DateOfEmployment <= dateTo));
            }

            return list;
        }

    }

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
                   /*: source.OrderBy(x => x.Citizenship.HasFlag(Сitizenship.Albanians) ? 1 
                   : x.Citizenship.HasFlag(Сitizenship.Armenians) ? 2
                   : x.Citizenship.HasFlag(Сitizenship.Australians) ? 3
                   : x.Citizenship.HasFlag(Сitizenship.BalticGermans) ? 4
                   : x.Citizenship.HasFlag(Сitizenship.Belarusians) ? 5
                   : x.Citizenship.HasFlag(Сitizenship.Belgians) ? 6
                   : x.Citizenship.HasFlag(Сitizenship.Canadians) ? 7
                   : x.Citizenship.HasFlag(Сitizenship.FrenchCitizens) ? 8
                   : x.Citizenship.HasFlag(Сitizenship.Germans) ? 9
                   : x.Citizenship.HasFlag(Сitizenship.Poles) ? 10
                   : x.Citizenship.HasFlag(Сitizenship.Russians) ? 11
                   : 0);*/
            }

            if (orderByProperty == "Id")
                return (desc)
                    ? source.OrderByDescending(x => x.Id)
                    : source.OrderBy(x => x.Id);

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
    