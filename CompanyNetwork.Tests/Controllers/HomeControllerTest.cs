using System;
using System.Collections.Generic;
using System.Linq;
using DomenModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DomenModel.Enums;
using DomenModel.Models;
using System.Data.Entity;
using System.Diagnostics;
using System.Xml;
using CompanyNetwork.BaseTree;
using CompanyNetwork.Models;

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
          //  var list = _context.Emloyees.ToList();
            //foreach (var item in list)
            {
                //item.Сitizenship = (Сitizenship)_random.Next(0, 100);
            }
           // root = _context.Departaments.First();
//_context.SaveChanges();
             MakeBigData(root, 0);
            Assert.Fail();
        }

        private void MakeBigData(Departament root, int index)
        {
            if (index > 20) return;

            var itemDepartament = _random.Next(1, 5);
            var itemEmployee = _random.Next(1, 5);
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
                    var w = _random.Next(1, 11);
                    var cit = _context.CitizenshipDescriptions.First(q => q.Id == w);

                    var empl = new DomenModel.Models.Employee
                    {
                        FirstName = RandomString(8),
                        Name = name[_random.Next(0, 9)],
                        LastName = RandomString(8),
                        DateOfBirth = birthDate,
                        DateOfEmployment = emplDate,
                        DateOfDismissal = disDate,
                        Salary = _random.Next(100, 2000),
                        Language = (Language)_random.Next(0, 100),
                        Citizenship = cit.Id,
                        Sex = (SexOfPerson)_random.Next(0, 2),
                        IsReadyForBusinessTrip = (_random.NextDouble() >= 0.5),
                        IsReadyForMoving = (_random.NextDouble() >= 0.5)
                    };

                   // var t = _context.CitizenshipDescriptions.Single(q => q.Id == w).Employees;
                    //if (t== null) t= new List<DomenModel.Models.Employee>();
                    //t.Add(empl);
                    employeeList.Add(empl);
                }

                var departament = new Departament
                {
                    Name = RandomString(8),
                    Country = (Countries)_random.Next(0, 9),
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

            var randTimeSpan = new TimeSpan((long)(_random.NextDouble() * range.Ticks));

            return from + randTimeSpan;
        }

        [TestMethod]
        public void Watch()
        {
          /*  var watch = Stopwatch.StartNew();
            var list = _context.Departaments.Include(q => q.Employees).ToList();
           // var list = _context.Departaments.First(q => q.Id == 2);
            watch.Stop();
            var time = watch.ElapsedMilliseconds;

            watch = Stopwatch.StartNew();
            var node = TreeCreator.MakeTree(list);
            watch.Stop();
            var timeBuilding = watch.ElapsedMilliseconds;
            var timeBuildingTicks = watch.ElapsedTicks;


            watch = Stopwatch.StartNew();
            var nodel = node
               .GetNodes
               .OrderByDescending(q => q.EmployeeCount)
               .ThenByDescending(q => q.DepartamentCount)
              // .Take(20)
               .Select(q => new
               {
                   q.Id,
                   q.Name,
                   q.DepartamentCount,
                   q.EmployeeCount
               })
               .ToList();
            watch.Stop();
            var timeList = watch.ElapsedMilliseconds;

            throw new AccessViolationException($"Time Select:  {time} Length List: {list.Count} \n Time TreeBuilding: ");*/
        }

        [TestMethod]
        public void Chart()
        {
            var model = TreeCreator.MakeTree(_context.Departaments.Include(q => q.Employees).ToList());

            var node46 = model.GetById(46);
            var nodeAge = node46.AverageEmployeeAge;

           // node46.MakeChart();
          // var chartModel = node46.BuildChart;
            Assert.Fail();
        }

        [TestMethod]
        public void Update()
        {
            var context = new CompanyContext();
            var list = context.Emloyees.ToList();
            foreach (var item in list)
            {
                //item.Сitizenship = _random.Next(1, 11);
            }
            context.SaveChanges();
            // node46.MakeChart();
            // var chartModel = node46.BuildChart;
            Assert.Fail();
        }
    }
}

