﻿using System.Collections.Generic;

namespace CompanyNetwork.Models.ChartModels
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