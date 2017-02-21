using System;
using DomenModel.Enums;

namespace CompanyNetwork.Models
{
    public class TableViewModel
    {
        public int Id { get; set; }
        public string Fio { get; set; }
        public int Salary { get; set; }

        public DateTime DateOfBirth { get; set; }
        public DateTime DateOfEmployment { get; set; }
        public DateTime? DateOfDismissal { get; set; }

        public Language Language { get; set; }
        public Сitizenship Сitizenship { get; set; }
        public SexOfPerson Sex { get; set; }

        public bool IsReadyForMoving { get; set; }
        public bool IsReadyForBusinessTrip { get; set; }

        public string DepartamentTitle { get; set; }

    }
}