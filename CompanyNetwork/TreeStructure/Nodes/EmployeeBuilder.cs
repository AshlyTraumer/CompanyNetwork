using System;
using DomenModel.Enums;

namespace CompanyNetwork.BaseTree
{
    public class EmployeeBuilder
    {
        private readonly Employee _employee;
        public EmployeeBuilder(int id)
        {
            _employee = new Employee {Id = id};
        }

        public EmployeeBuilder SetFirstName(string firstName)
        {
            _employee.FirstName = firstName;
            return this;
        }

        public EmployeeBuilder SetName(string name)
        {
            _employee.Name = name;
            return this;
        }

        public EmployeeBuilder SetLastName(string lastName)
        {
            _employee.LastName = lastName;
            return this;
        }

        public EmployeeBuilder SetSalary(int salary)
        {
            _employee.Salary = salary;
            return this;
        }

        public EmployeeBuilder SetDateOfBirth(DateTime dateOfBirth)
        {
            _employee.DateOfBirth = dateOfBirth;
            return this;
        }

        public EmployeeBuilder SetDateOfEmployment(DateTime dateOfEmployment)
        {
            _employee.DateOfEmployment = dateOfEmployment;
            return this;
        }

        public EmployeeBuilder SetDateOfDismissal(DateTime? dateOfDismissal)
        {
            _employee.DateOfDismissal = dateOfDismissal;
            return this;
        }

        public EmployeeBuilder SetNationality(Сitizenship citizenship)
        {
            _employee.Сitizenship = citizenship;
            return this;
        }

        public EmployeeBuilder SetLanguage(Language language)
        {
            _employee.Language = language;
            return this;
        }

        public EmployeeBuilder SetSex(SexOfPerson sex)
        {
            _employee.Sex = sex;
            return this;
        }

        public EmployeeBuilder SetFlags(bool isReadyForMoving, bool isReadyForBusinessTrip)
        {
            _employee.IsReadyForMoving = isReadyForMoving;
            _employee.IsReadyForBusinessTrip = isReadyForBusinessTrip;
            return this;
        }
        public EmployeeBuilder SetDepartamentId(int departamentId)
        {
            _employee.DepartamentId = departamentId;
            return this;
        }

        public Employee Build()
        {
            return _employee;
        }

    }
}