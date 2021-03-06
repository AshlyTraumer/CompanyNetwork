﻿using System.Collections.Generic;
using DomenModel.Enums;

namespace DomenModel.Models
{
    public class Departament 
    {
        public int Id { get; set; }
        public int? ParentId { get; set; }

        public string Name { get; set; }
        public Countries Country { get; set; }

        public ICollection<Employee> Employees { get; set; }
    }
}
