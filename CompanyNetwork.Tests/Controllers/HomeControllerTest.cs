using System;
using System.Collections.Generic;
using System.Linq;
using DomenModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DomenModel.Enums;
using DomenModel.Models;
using System.Data.Entity;
using System.Diagnostics;
using CompanyNetwork.BaseTree;

namespace CompanyNetwork.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        private readonly CompanyContext _context = new CompanyContext();
        private readonly Random _random = new Random();

        private readonly string[] name = new[]
            {"Alice", "Nicole", "Sara", "Rosa", "Kelly", "Pavel", "Tomac", "Leo", "Nelson", "George"};

        [TestMethod]
        public void Index()
        {
            var root = new Departament
            {
                Country = Countries.Belarus,
                Name = "SomeName",
                ParentId = null
            };
            _context.Departaments.Add(root);
            _context.SaveChanges();

            MakeBigData(root, 0);
            Assert.Fail();
        }

        private void MakeBigData(Departament root, int index)
        {
            if (index > 10) return;

            var itemDepartament = _random.Next(1, 4);
            var itemEmployee = _random.Next(1, 30);
            List<DomenModel.Models.Employee> employeeList;

            for (var i = 1; i <= itemDepartament; i++)
            {
                employeeList = new List<DomenModel.Models.Employee>();

                for (var j = 1; j <= itemEmployee; j++)
                {
                    var birthDate = RandomDate(new DateTime(1950, 1, 1), DateTime.Now.Subtract(new TimeSpan(2)));
                    var emplDate = RandomDate(birthDate, DateTime.Now.Subtract(new TimeSpan(1)));
                    DateTime? disDate;

                    if (_random.Next(0, 2) == 0)
                        disDate = null;
                    else
                        disDate = RandomDate(emplDate, DateTime.Now);

                    employeeList.Add(new DomenModel.Models.Employee
                    {
                        FirstName = RandomString(8),
                        Name = name[_random.Next(0, 9)],
                        LastName = RandomString(8),
                        DateOfBirth = birthDate,
                        DateOfEmployment = emplDate,
                        DateOfDismissal = disDate,
                        Salary = _random.Next(100, 2000),
                        Language = (Language)_random.Next(0, 100),
                        Nationality = (Nationality)_random.Next(0, 100),
                        Sex = (SexOfPerson)_random.Next(0, 2),
                        IsReadyForBusinessTrip = (_random.NextDouble() >= 0.5),
                        IsReadyForMoving = (_random.NextDouble() >= 0.5)
                    });
                }

                var departament = new Departament
                {
                    Name = RandomString(8),
                    Country = (Countries) _random.Next(0, 9),
                    ParentId = root.Id,
                    Employees = employeeList
                };

                _context.Departaments.Add(departament);
                _context.SaveChanges();

                index += 1;
                MakeBigData(departament, index);

            }
        }

        public string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[_random.Next(s.Length)]).ToArray());
        }

        public DateTime RandomDate(DateTime from, DateTime to)
        {
            var range = to - from;

            var randTimeSpan = new TimeSpan((long) (_random.NextDouble() * range.Ticks));

            return from + randTimeSpan;
        }

        [TestMethod]
        public void Watch()
        {
            var watch = Stopwatch.StartNew();
            var list = _context.Departaments.Include(q => q.Employees).ToList();
            watch.Stop();
            var time = watch.ElapsedMilliseconds;

            watch = Stopwatch.StartNew();
            var node = TreeCreator.MakeTree(list);
            watch.Stop();
            var timeBuilding = watch.ElapsedMilliseconds;

            throw new AccessViolationException($"Time Select:  {time} Length List: {list.Count} \n Time TreeBuilding: {timeBuilding}");
        }


    }
}

