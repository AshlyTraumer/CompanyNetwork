using System;
using System.Collections.Generic;
using CompanyNetwork.TreeStructure;

namespace CompanyNetwork.Models
{
    public class ChartModel<T> 
    {
        public SortedDictionary<T, int> Dictionary;

        public ChartModel()
        {
            Dictionary = new SortedDictionary<T, int>
            {
            };
        }
    }
}