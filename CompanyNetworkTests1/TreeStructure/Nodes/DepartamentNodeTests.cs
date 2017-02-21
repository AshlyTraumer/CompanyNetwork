using Microsoft.VisualStudio.TestTools.UnitTesting;
using CompanyNetwork.BaseTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyNetwork.BaseTree.Tests
{
    [TestClass()]
    public class DepartamentNodeTests
    {
        [TestMethod()]
        public void DepartamentNodeTest()
        {
            var test = "English, German";
            var outTest = test.Replace(",", "").Split(' ');
            Assert.Fail();
        }

        [TestMethod()]
        public void GetByIdTest()
        {
            Assert.Fail();
        }
    }
}