using System.Linq;

namespace CompanyNetwork.Models
{
    public class FilterModel
    {
        public bool IsDismissal { get; set; }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public int? SalaryFrom { get; set; }
        public int? SalaryTo { get; set; }

        public bool IsReadyForMoving { get; set; }
        public bool IsReadyForBusinessTrip { get; set; }

        public string DepartamentTitle { get; set; }

        public int CurrentPage { get; set; }
        public int Pages { get; set; }

        public IQueryable<TableViewModel> AddFilters(IQueryable<TableViewModel> query)
        {
            if (Id != 0) query = query.Where(q => q.Id == Id);

            if (FirstName != null) query = query.Where(q => q.FirstName == FirstName);

            if ((SalaryFrom != null) && (SalaryTo != null))
                query = query.Where(q => (q.Salary >= SalaryFrom) && (q.Salary <= SalaryTo));

            if (IsDismissal == true ) query = query.Where(q => q.DateOfDismissal == null);

            if (IsReadyForMoving == true) query = query.Where(q => q.IsReadyForMoving == true);

            if (IsReadyForBusinessTrip == true) query = query.Where(q => q.IsReadyForBusinessTrip == true);

            return query;
        }
    }
}