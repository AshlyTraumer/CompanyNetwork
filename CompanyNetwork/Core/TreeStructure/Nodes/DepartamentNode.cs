using System.Collections.Generic;
using System.Linq;
using CompanyNetwork.Models;
using DomenModel.Enums;
using CompanyNetwork.Core.EnumHelper;
using CompanyNetwork.Core.TreeStructure;
using CompanyNetwork.Core.TreeStructure.Nodes;
using CompanyNetwork.Models.ChartModels;

namespace CompanyNetwork.BaseTree
{
    public class DepartamentNode
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public Countries Country { get; private set; }
        public IReadOnlyList<DepartamentNode> Children;
        public IReadOnlyList<Employee> Employees;

        public DepartamentNode(
            int id, string name, Countries country, 
            IEnumerable<DepartamentNode> children, IEnumerable<Employee> employee)
        {
            Id = id;
            Name = name;
            Country = country;
            Children = children.ToList();
            Employees = employee.ToList();
        }

        public int DepartamentCount
        {
            get
            {
                return Children.Count != 0 
                    ? Children
                        .Select(q => q.DepartamentCount + 1)
                        .Sum() 
                    : 0;
            }
        }

        public int EmployeeCount
        {
            get
            {
                return Children.Count != 0 
                    ? Children
                        .Select(q => q.EmployeeCount + q.Employees.Count)
                        .Sum() 
                    : 0;
            }
        }

        private int EmployeeAge
        {
            get
            {
                var years = 0;

                if (Children.Count != 0)
                {
                    foreach (var child in Children)
                    {
                        years += child.EmployeeAge;
                    }
                }
                return years + Employees
                    .Select(q => q.Age)
                    .Sum();
            }
        }

        public int AverageEmployeeAge => EmployeeAge / (EmployeeCount + Employees.Count);


        public List<DepartamentNode> GetNodes
        {
            get
            {
                var list = Children.ToList();

                foreach (var i in Children)
                {
                    list.AddRange(i.GetNodes);
                }

                return list;
            }
        }

        public DepartamentNode GetById(int id)
        {
            if (Id == id)
            {
                return this;
            }
            else
            {
                if (Children.Count == 0)
                {
                    return null;
                }                    
                else
                {
                    foreach (var child in Children)
                    {
                        var node = child.GetById(id);

                        if (node != null)
                        {
                            return node;
                        }                            
                    }
                }
            }
            return null;
        }


        public ChartModel<AgeGroup> BuildChartByAge => ChartByAgeCreator(new ChartModel<AgeGroup>());
        public ChartModel<Language> BuildChartByLanguage => ChartByLanguageCreator(new ChartModel<Language>());
        public ChartModel<ExperienceGroup> BuildChartByExperience=> ChartByExperienceCreator(new ChartModel<ExperienceGroup>());


        private ChartModel<AgeGroup> ChartByAgeCreator(ChartModel<AgeGroup> model )
        {
            foreach (var employee in Employees)
            {
                if (!employee.IsWork) continue;

                if (model.Dictionary.ContainsKey(employee.AgeGroup))
                {
                    model.Dictionary[employee.AgeGroup] += 1;
                }                    
                else
                {
                    model.Dictionary.Add(employee.AgeGroup, 1);
                }
            }

            foreach (var child in Children)
            {
               model = child.ChartByAgeCreator(model);
            }

            return model;
        }

        private ChartModel<Language> ChartByLanguageCreator(ChartModel<Language> model)
        {
            foreach (var employee in Employees)
            {
                if (employee.IsWork)
                {
                    var languages = EnumHelper.GetFlags(employee.Language);

                    foreach (Language l in languages)
                    {
                        if (model.Dictionary.ContainsKey(l))
                        {
                            model.Dictionary[l] += 1;
                        }                            
                        else
                        {
                            model.Dictionary.Add(l, 1);
                        }                            
                    }
                }                   
            }

            foreach (var child in Children)
            {
                model = child.ChartByLanguageCreator(model);
            }

            return model;
        }

        private ChartModel<ExperienceGroup> ChartByExperienceCreator(ChartModel<ExperienceGroup> model)
        {
            foreach (var employee in Employees)
            {
                if (!employee.IsWork) continue;

                if (model.Dictionary.ContainsKey(employee.ExperienceGroup))
                {
                    model.Dictionary[employee.ExperienceGroup] += 1;
                }                    
                else
                {
                    model.Dictionary.Add(employee.ExperienceGroup, 1);
                }

            }

            foreach (var child in Children)
            {
                model = child.ChartByExperienceCreator(model);
            }

            return model;
        }
    }
}