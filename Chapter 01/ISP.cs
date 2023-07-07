using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet_Design_Patterns.Chapter1.SOLID
{
    public interface IWorker
    {
        public string Name { get; set; }
        public int MonthlySalary { get; set; }
        public int HourlySalary { get; set; }
        public int HoursInMonth { get; set; }
        int CalculateSalary();
    }
    //public class FullTimeWorker : IWorker
    //{
    //    public string Name { get; set; }
    //    public int MonthlySalary { get; set; }
    //    public int HourlySalary { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    //    public int HoursInMonth { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    //    public int CalculateSalary() => MonthlySalary + (MonthlySalary * 10 / 100);
    //}
    //public class PartTimeWorker : IWorker
    //{
    //    public string Name { get; set; }
    //    public int MonthlySalary { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    //    public int HourlySalary { get; set; }
    //    public int HoursInMonth { get; set; }
    //    public int CalculateSalary() => HourlySalary * HoursInMonth;
    //}
    public interface IBaseWorker
    {
        public string Name { get; set; }
        int CalculateSalary();
    }
    public interface IFullTimeWorker : IBaseWorker
    {
        public int MonthlySalary { get; set; }
    }
    public interface IPartTimeWorker : IBaseWorker
    {
        public int HourlySalary { get; set; }
        public int HoursInMonth { get; set; }
    }
    public class FullTimeWorker : IFullTimeWorker
    {
        public string Name { get; set; }
        public int MonthlySalary { get; set; }
        public int CalculateSalary() => MonthlySalary + (MonthlySalary * 10 / 100);
    }
    public class PartTimeWorker : IPartTimeWorker
    {
        public string Name { get; set; }
        public int HourlySalary { get; set; }
        public int HoursInMonth { get; set; }
        public int CalculateSalary() => HourlySalary * HoursInMonth;
    }
}
