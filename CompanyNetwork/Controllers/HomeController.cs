using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Web.Mvc;
using CompanyNetwork.BaseTree;
using CompanyNetwork.Models;
using CompanyNetwork.TreeStructure;
using DomenModel;
using DomenModel.Enums;
using PagedList;

namespace CompanyNetwork.Controllers
{
    public class HomeController : Controller
    {
        private readonly CompanyContext _context;
        private readonly DepartamentNode _model;

        public HomeController()
        {
            _context = new CompanyContext();
            _model = TreeCreator.MakeTree(_context.Departaments.Include(q => q.Employees).ToList());
        }

        public ActionResult Index()
        {
            var watch = Stopwatch.StartNew();

            var model = TreeCreator.MakeTree(_context.Departaments.Include(q => q.Employees).ToList())
               .GetNodes
               .OrderByDescending(q => q.EmployeeCount)
               .ThenByDescending(q => q.DepartamentCount)
               .Take(20)
               .Select(q => new DepartamentModel
               {
                   Id = q.Id,
                   Title = q.Name,
                   DCount = q.DepartamentCount,
                   ECount = q.EmployeeCount
               })
               .ToList();

            watch.Stop();
            ViewBag.Watch = watch.ElapsedMilliseconds;

            return View(model);
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Chart()
        {
            var chartModel = _model.GetById(2).BuildChartByAge;
            var dict = new List<DictionaryModel>();

            foreach (var item in chartModel.Dictionary)
            {
                dict.Add(new DictionaryModel
                {
                    Description = EnumDescription.GetDescription(item.Key),
                    Value = item.Value
                });
            }

            return Json(dict, JsonRequestBehavior.AllowGet);

        }

        public ActionResult ChartLanguage()
        {
            var chartModel = _model.GetById(2).BuildChartByLanguage;
            var dict = new List<DictionaryModel>();

            foreach (var item in chartModel.Dictionary)
            {
                dict.Add(new DictionaryModel
                {
                    Description = EnumDescription.GetDescription(item.Key),
                    Value = item.Value
                });
            }

            return Json(dict, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ChartExperience()
        {
            var chartModel = _model.GetById(2).BuildChartByExperience;
            var dict = new List<DictionaryModel>();

            foreach (var item in chartModel.Dictionary)
            {
                dict.Add(new DictionaryModel
                {
                    Description = EnumDescription.GetDescription(item.Key),
                    Value = item.Value
                });
            }

            return Json(dict, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Info(int page = 1)
        {
            var size = 20;

            var data = _context.Emloyees                 
                 .Select(q => new TableViewModel
                 {
                     Id = q.Id,
                     FirstName = q.FirstName,
                     Name = q.Name,
                     LastName = q.LastName,
                     Salary = q.Salary,
                     Language = q.Language,
                     DateOfEmployment = q.DateOfEmployment,
                     DateOfDismissal = q.DateOfDismissal,
                     DateOfBirth = q.DateOfBirth,
                     Sex = q.Sex,
                     Сitizenship = q.Сitizenship,
                     IsReadyForBusinessTrip = q.IsReadyForBusinessTrip,
                     IsReadyForMoving = q.IsReadyForMoving,
                     DepartamentTitle = q.Departament.Name
                 })
                .OrderBy(q => q.Id)
                .Skip((page - 1) * size)
                .Take(size)
                .ToList();


            var viewModel = new StaticPagedList<TableViewModel>(data, page, size, _context.Emloyees.Count());
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Info(FilterModel model)
        {
            var size = 20;

            var query = _context.Emloyees
                 .Select(q => new TableViewModel
                 {
                     Id = q.Id,
                     FirstName = q.FirstName,
                     Name = q.Name,
                     LastName = q.LastName,
                     Salary = q.Salary,
                     Language = q.Language,
                     DateOfEmployment = q.DateOfEmployment,
                     DateOfDismissal = q.DateOfDismissal,
                     DateOfBirth = q.DateOfBirth,
                     Sex = q.Sex,
                     Сitizenship = q.Сitizenship,
                     IsReadyForBusinessTrip = q.IsReadyForBusinessTrip,
                     IsReadyForMoving = q.IsReadyForMoving,
                     DepartamentTitle = q.Departament.Name
                 });

            var data = model.AddFilters(query).ToList();
            var sortedData = data.OrderBy(q => q.Id)
                            .Skip((model.CurrentPage - 1) * size)
                            .Take(size)
                            .ToList();

            // var viewModel = new StaticPagedList<TableViewModel>(data, page, size, data.Count);
            // return PartialView("_TablePartial", viewModel);
            return Json(new {
                list = sortedData,
                pages = (data.Count % size == 0) 
                    ? data.Count / size 
                    : data.Count / size + 1,
                currentPage = model.CurrentPage
            });
        }
    }
}