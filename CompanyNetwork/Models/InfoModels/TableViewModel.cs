using System;
using DomenModel.Enums;
using CompanyNetwork.TreeStructure;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using CompanyNetwork.Core.EnumHelper;
using CompanyNetwork.Models.ViewModels;
using System.Globalization;

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
                return EnumHelper.GetDescription(Sex);
            }
        }

        public List<string> LanguageDescriptions
        {
            get
            {
                var array = EnumHelper.GetFlags(Language);
                var arrayDescr = new List<string>();
                foreach (var item in array)
                {
                    arrayDescr.Add(EnumHelper.GetDescription(item));
                }
                return arrayDescr;
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
                return DateOfBirth.ToString("g", CultureInfo.CurrentCulture);
            }
        }

        public string DateOfEmploymentFormat
        {
            get
            {
                return DateOfEmployment.ToString("g", CultureInfo.CurrentCulture);
            }
        }

        public string DateOfDismissalFormat
        {
            get
            {
                return (DateOfDismissal == null)
                    ? "No details"
                    :  ((DateTime) DateOfDismissal).ToString("g",CultureInfo.CurrentCulture);
            }
        }

        public string LanguageFormat
        {
            get
            {
                var str = new List<string>();

                foreach (var item in EnumHelper.GetFlags(Language))
                {
                    str.Add(EnumHelper.GetDescription(item));
                }
                    
                return string.Join(Environment.NewLine, str);
            }
        }



        public string CitizenshipFormat
        {
            get
            {
                return Citizenship.Name;
            }
        }

        public string SexFormat
        {
            get
            {               
                var str = new List<string>();

                foreach (var item in EnumHelper.GetFlags(Sex))
                {
                    str.Add(EnumHelper.GetDescription(item));
                }
                    
                return string.Join(Environment.NewLine, str);
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
        
    }
    
}