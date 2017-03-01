using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using CompanyNetwork.Models.InfoModels;
using DomenModel.Enums;

namespace CompanyNetwork.Models.FilterModels
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
    
}
    