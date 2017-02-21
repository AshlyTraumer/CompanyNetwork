using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using CompanyNetwork.BaseTree;
using DomenModel;

namespace CompanyNetwork.Models
{
    public class DepartamentModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int DCount { get; set; }
        public int ECount { get; set; }

        }
}