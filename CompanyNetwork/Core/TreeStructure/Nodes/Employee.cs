using System;
using DomenModel.Enums;

namespace CompanyNetwork.Core.TreeStructure.Nodes
{
    public class Employee
    {
        public int Id { get; set; }

        public string FirstName { get; set; }
        public string Name { get; set; }
        public string LastName { get;  set; }
        public int Salary { get; set; }

        public DateTime DateOfBirth { get;  set; }
        public DateTime DateOfEmployment { get; set; }
        public DateTime? DateOfDismissal { get; set; }

        public Language Language { get; set; }
        public CitizenshipDescription Сitizenship { get; set; }
        public SexOfPerson Sex { get; set; }

        public bool IsReadyForMoving { get; set; }
        public bool IsReadyForBusinessTrip { get; set; }
        
        public int DepartamentId { get; set; }

        public int Age
        {
            get
            {
                var date = DateTime.Now.Year - DateOfBirth.Year;

                if (DateTime.Now.Month < DateOfBirth.Month || 
                    (DateTime.Now.Month == DateOfBirth.Month && DateTime.Now.Day < DateOfBirth.Day))
                {
                    date--;
                }

                return date;
            }
        }

        public bool IsWork => (DateOfDismissal != null);

        public AgeGroup AgeGroup
        {
            get
            {
                foreach (var item in Enum.GetValues(typeof(AgeGroup)))
                {
                    if (Age <= (int) item)
                    {
                        return (AgeGroup) item;
                    }
                }
                return AgeGroup.Upper50;                
            }
        }

        public int Experience
        {
            get
            {
                var date = 0;

                if (DateOfDismissal == null)
                {
                    date = DateTime.Now.Year - DateOfEmployment.Year;

                    if (DateTime.Now.Month < DateOfBirth.Month || 
                        (DateTime.Now.Month == DateOfBirth.Month && DateTime.Now.Day < DateOfBirth.Day))
                    {
                        date--;
                    }
                }
                else
                {
                    date = (int) DateOfDismissal?.Year - DateOfEmployment.Year;

                    if ((int)DateOfDismissal?.Month < DateOfEmployment.Month 
                        || ((int)DateOfDismissal?.Month == DateOfEmployment.Month &&
                            (int)DateOfDismissal?.Day < DateOfEmployment.Day))
                    {
                        date--;
                    }
                }                

                return date;
            }
        }

        public ExperienceGroup ExperienceGroup
        {
            get
            {
                foreach (var item in Enum.GetValues(typeof(ExperienceGroup)))
                {
                    if (Experience <= (int)item)
                    {
                        return (ExperienceGroup)item;
                    }
                }
                return ExperienceGroup.God;
            }
        }        
    }
}