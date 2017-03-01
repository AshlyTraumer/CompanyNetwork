using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Web.Mvc;
using CompanyNetwork.BaseTree;
using CompanyNetwork.Models;
using CompanyNetwork.Core.OrderFilter;
using DomenModel;
using DomenModel.Enums;
using CompanyNetwork.Core.EnumHelper;
using CompanyNetwork.Core.TreeStructure;
using CompanyNetwork.Models.FilterModels;
using CompanyNetwork.Models.InfoModels;

namespace CompanyNetwork.Controllers
{
    public class HomeController : Controller
    {
        private readonly CompanyContext _context;
        private readonly DepartamentNode _model;
        

        public HomeController()
        {
            _context = new CompanyContext();

            _model = TreeCreator.MakeTree(
                _context.Departaments
                .Include(q => q.Employees)
                .Include(q => q.Employees
                    .Select(w => w.CitizenshipDescription)
                ).ToList()
                );
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

        [ActionName("Chart")]
        public ActionResult About()
        {
            return View();
        }

        public ActionResult ChartAge()
        {
            var chartModel = _model.GetById(2).BuildChartByAge;

            var dict = chartModel.Dictionary.Select(item => new DictionaryModel
            {
                Description = EnumHelper.GetDescription(item.Key), Value = item.Value
            })
            .ToList();

            return Json(dict, JsonRequestBehavior.AllowGet);

        }

        public ActionResult ChartLanguage()
        {
            var chartModel = _model.GetById(2).BuildChartByLanguage;

            var dict = chartModel.Dictionary.Select(item => new DictionaryModel
            {
                Description = EnumHelper.GetDescription(item.Key), Value = item.Value
            })
            .ToList();

            return Json(dict, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ChartExperience()
        {
            var chartModel = _model.GetById(2).BuildChartByExperience;

            var dict = chartModel.Dictionary.Select(item => new DictionaryModel
            {
                Description = EnumHelper.GetDescription(item.Key), Value = item.Value
            }).ToList();

            return Json(dict, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Info()
        {
            var enumList = new List<string>();

            foreach (var item in Enum.GetValues(typeof(SexOfPerson)))
            {
                enumList.Add(EnumHelper.GetDescription((SexOfPerson) item));
            }

            ViewBag.Sex = enumList;

            enumList = new List<string>();
            
            foreach (var item in Enum.GetValues(typeof(Language)))
            {
                enumList.Add(EnumHelper.GetDescription((Language)item));
            }

            ViewBag.Language = enumList;
                                 
            ViewBag.Сitizenship = _context.CitizenshipDescriptions
                .Select(q => q.Name)
                .ToList();

            return View();
        }

        [HttpPost]
        public ActionResult Info(FilterModel model)
        {
            const int size = 20;
            var param = "Id";

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
                     Citizenship = new CitizenshipModel
                     {
                         Id = q.CitizenshipDescription.Id,
                         Name = q.CitizenshipDescription.Name
                     },
                     IsReadyForBusinessTrip = q.IsReadyForBusinessTrip,
                     IsReadyForMoving = q.IsReadyForMoving,
                     DepartamentTitle = q.Departament.Name
                 });

            query = model.GetFilters().Aggregate(query, (current, filter) => current.Where(filter));

            var count = query.Count();

            param = (model.SortId != null) ? param = model.SortId : param;
                      
                       
            var sortedData = new List<TableViewModel>();          
             sortedData = query.OrderBy(param,model.IsDesc)                
                    .Skip((model.CurrentPage - 1) * size)
                            .Take(size)
                            .ToList();            
            
            var page = (count % size == 0) 
                ? count / size 
                : count / size + 1;       

            return Json(new {
                list = sortedData,
                pages = page,
                currentPage = model.CurrentPage,
                paginator = GetPagesNums(model.CurrentPage, page),
                sortColumn = param
            });
        }

        private HashSet<int> GetPagesNums(int currentPage, int pages)
        {
            var numList = new HashSet<int> {1};

            if (pages > 1)
                numList.Add(2);

            if (currentPage - 1 > 3)
                numList.Add(-1);

            if (currentPage != 1)
                numList.Add(currentPage - 1);
           
            numList.Add(currentPage);

            if (currentPage != pages)
                numList.Add(currentPage + 1);

            if (currentPage + 1 < pages - 2)
                numList.Add(-2);

            numList.Add(pages - 1);
            numList.Add(pages);

            if (numList.Contains(0))
                numList.Remove(0);

            return numList;
        }
    }
}