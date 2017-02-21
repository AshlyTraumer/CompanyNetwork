using System.Data.Entity;
using System.Linq;
using CompanyNetwork.Models;
using DomenModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CompanyNetwork.BaseTree.Tests
{
    [TestClass()]
    public class DepartamentNodeTests
    {
        [TestMethod()]
        public void GetByIdTest()
        {
            var model = TreeCreator.MakeTree(new CompanyContext().Departaments.Include(q => q.Employees).ToList())
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

            Assert.Fail();
        }
    }
}