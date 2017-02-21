using System;
using DomenModel.Enums;

namespace DomenModel.Models
{
    public class Employee
    {
        public int Id { get; set; }

        public string FirstName { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Salary { get; set; }

        public DateTime DateOfBirth { get; set; }
        public DateTime DateOfEmployment { get; set; }
        public DateTime? DateOfDismissal { get; set; }

        public Language Language { get; set; }
        public Сitizenship Сitizenship { get; set; }
        public SexOfPerson Sex { get; set; }

        public bool IsReadyForMoving { get; set; }
        public bool IsReadyForBusinessTrip { get; set; }

        public Departament Departament { get; set; }
        public int DepartamentId { get; set; }

        
        
    }
}
