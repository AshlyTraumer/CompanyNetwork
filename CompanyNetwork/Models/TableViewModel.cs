using System;
using DomenModel.Enums;
using CompanyNetwork.TreeStructure;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Linq.Expressions;
using DomenModel.Models;

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

      
        public CitizenshipModel Citizenship { get; set; }
        public SexOfPerson Sex { get; set; }

        public bool IsReadyForMoving { get; set; }
        public bool IsReadyForBusinessTrip { get; set; }

        public string DepartamentTitle { get; set; }

        public string SexDescription
        {
            get
            {
                return Sex.GetType()
                .GetMember(Sex.ToString())
                .First()
                .GetCustomAttribute<DescriptionAttribute>()
                .Description;
            }
        }

        public List<string> LanguageDescriptions
        {
            get
            {
                var array = Flags.GetFlags(Language);
                var arrayDescr = new List<string>();
                foreach (var item in array)
                {
                    arrayDescr.Add(EnumDescription.GetDescription(item));
                }
                return arrayDescr;
            }
        }



        public string СitizenshipDescription
        {
            get
            {
               
                return Citizenship.ToString();
               
                
            }
        }

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
                    : ((DateTime)DateOfDismissal).ToString("g");
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
                return Citizenship.ToString().Replace(" ", Environment.NewLine);
            }
        }

        public string SexFormat
        {
            get
            {
                return Sex.ToString();
            }
        }

        public string IsReadyForMovingFormat
        {
            get
            {
                return (IsReadyForMoving) ? "Yes" : "No";
            }
        }

        public string IsReadyForBusinessTripFormat
        {
            get
            {
                return (IsReadyForBusinessTrip) ? "Yes" : "No";
            }
        }

        public string SortId { get; set; } = "Id";

        public string GetOrder
        {
            get
            {
                /*var i = 0;

                if (Citizenship.HasFlag(Сitizenship.Albanians)) { i += 1; }
                if (Citizenship.HasFlag(Сitizenship.Armenians)) { i += 2; }
                if (Citizenship.HasFlag(Сitizenship.Australians)) { i += 3; }
                if (Citizenship.HasFlag(Сitizenship.BalticGermans)) { i += 4; }
                if (Citizenship.HasFlag(Сitizenship.Belarusians)) { i += 5; }
                if (Citizenship.HasFlag(Сitizenship.Belgians)) { i += 6; }
                if (Citizenship.HasFlag(Сitizenship.Canadians)) { i += 7; }
                if (Citizenship.HasFlag(Сitizenship.FrenchCitizens)) { i += 8; }
                if (Citizenship.HasFlag(Сitizenship.Germans)) { i += 9; }
                if (Citizenship.HasFlag(Сitizenship.Poles)) { i += 10; }
                if (Citizenship.HasFlag(Сitizenship.Russians)) { i += 11; }

                return i;*/
                return Citizenship.ToString();
            }

        }
    }

    public class CitizenshipModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}