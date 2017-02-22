using System;
using DomenModel.Enums;

namespace CompanyNetwork.Models
{
    public class TableViewModel
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

        public string DepartamentTitle { get; set; }

        public string Fio
        {
            get
            {
                return (LastName != null)
                    ? $"{FirstName} {Name[0]}. {LastName[0]}."
                    : $"{FirstName} {Name[0]}.";
            }
        }

        public string DateOfBirthFormat
        {
            get
            {
                return DateOfBirth.ToString("g");
            }
        }

        public string DateOfEmploymentFormat
        {
            get
            {
                return DateOfEmployment.ToString("g");
            }
        }

        public string DateOfDismissalFormat
        {
            get
            {
                return (DateOfDismissal == null) 
                    ? "No details" 
                    : ((DateTime) DateOfDismissal).ToString("g");
            }
        }

        public string LanguageFormat
        {
            get
            {
                return Language.ToString().Replace(" ", Environment.NewLine);
            }
        }

        public string CitizenshipFormat
        {
            get
            {
                return Сitizenship.ToString().Replace(" ", Environment.NewLine);
            }
        }

        public string SexFormat
        {
            get
            {
                return Sex.ToString();
            }
        }
    }
}