using CompanyNetwork.TreeStructure;
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
        public int Сitizenship { get; set; }

        public bool IsReadyForMoving { get; set; }
        public bool IsReadyForBusinessTrip { get; set; }

        public string DepartamentTitle { get; set; }

        public int CurrentPage { get; set; }
        public int Pages { get; set; }

        public List<Expression<Func<TableViewModel,bool>>> Filters()
        {
            var list = new List<Expression<Func<TableViewModel, bool>>>();
            if (Id != 0) list.Add(q => q.Id == Id);
            if (FirstName != null) list.Add(q => q.FirstName == FirstName);

            if ((SalaryFrom != null) && (SalaryTo != null))
               list.Add(q => (q.Salary >= SalaryFrom) && (q.Salary <= SalaryTo));

            if (IsDismissal == true) list.Add(q => q.DateOfDismissal == null);

            if (IsReadyForMoving == true) list.Add(q => q.IsReadyForMoving == true);

            if (IsReadyForBusinessTrip == true) list.Add(q => q.IsReadyForBusinessTrip == true);

            if (Sex != -1) list.Add(q => q.Sex == (SexOfPerson)Sex);
            if (Language != -1) list.Add(q => q.Language.HasFlag((Language)Language));
            if (Сitizenship != -1) list.Add(q => q.Сitizenship.HasFlag((Сitizenship)Сitizenship));

            return list;
        }
    }
}