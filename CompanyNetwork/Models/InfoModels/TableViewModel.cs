using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using CompanyNetwork.Core.EnumHelper;
using DomenModel.Enums;

namespace CompanyNetwork.Models.InfoModels
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

        public string SexDescription => EnumHelper.GetDescription(Sex);

        public List<string> LanguageDescriptions
        {
            get
            {
                var array = EnumHelper.GetFlags(Language);
                return array.Select(EnumHelper.GetDescription).ToList();
            }
        }
        
        public string Fio => (LastName != null)
            ? $"{FirstName} {Name[0]}. {LastName[0]}."
            : $"{FirstName} {Name[0]}.";

        public string DateOfBirthFormat => DateOfBirth.ToString("g", CultureInfo.CurrentCulture);

        public string DateOfEmploymentFormat => DateOfEmployment.ToString("g", CultureInfo.CurrentCulture);

        public string DateOfDismissalFormat => DateOfDismissal?.ToString("g",CultureInfo.CurrentCulture) ?? "No details";

        public string LanguageFormat
        {
            get
            {
                var str = EnumHelper.GetFlags(Language).Select(EnumHelper.GetDescription).ToList();

                return string.Join(Environment.NewLine, str);
            }
        }



        public string CitizenshipFormat => Citizenship.Name;

        public string SexFormat
        {
            get
            {               
                var str = EnumHelper.GetFlags(Sex).Select(EnumHelper.GetDescription).ToList();

                return string.Join(Environment.NewLine, str);
            }
        }

        public string IsReadyForMovingFormat => (IsReadyForMoving) ? "Yes" : "No";

        public string IsReadyForBusinessTripFormat => (IsReadyForBusinessTrip) ? "Yes" : "No";

        public string SortId { get; set; } = "Id";
        
    }
    
}