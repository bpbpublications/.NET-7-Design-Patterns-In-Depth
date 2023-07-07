using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet_Design_Patterns.Chapter1.SOLID
{
    public class WrongOCP
    {
        public string Name { get; set; }
        public string UserType { get; set; }
        public decimal CalculateSalary(decimal hours)
        {
            if (UserType == "Manager")
                return hours * 1500;
            return hours * 1000;
        }
    }
    public abstract class OCP
    {
        protected OCP(string name) => Name = name;
        public string Name { get; set; }
        public abstract decimal CalculateSalary(decimal hours);
    }
    public class Manager : OCP
    {
        public Manager(string name) : base(name) { }
        public override decimal CalculateSalary(decimal hours) => hours * 1500;
    }
    public class Employee : OCP
    {
        public Employee(string name) : base(name) { }
        public override decimal CalculateSalary(decimal hours) => hours * 1000;
    }

}
