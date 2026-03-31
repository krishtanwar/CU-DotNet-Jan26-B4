using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1
{
    public class EmployeeBonus
    {
        public decimal BaseSalary { get; set; }
        public int PerformanceRating { get; set; }
        public int YearsOfExperience { get; set; }
        public decimal DepartmentMultiplier { get; set; }
        public double AttendancePercentage { get; set; }

        public decimal NetAnnualBonus
        {
            get
            {
                if (BaseSalary == 0) return 0;

                decimal bonus = PerformanceRating switch
                {
                    5 => BaseSalary * 0.25m,
                    4 => BaseSalary * 0.18m,
                    3 => BaseSalary * 0.12m,
                    2 => BaseSalary * 0.05m,
                    1 => 0m,
                    _ => throw new InvalidOperationException("Invalid Rating")
                };


                if (YearsOfExperience > 10)
                    bonus += BaseSalary * 0.05m;
                else if (YearsOfExperience > 5)
                    bonus += BaseSalary * 0.03m;


                if (AttendancePercentage < 85)
                    bonus *= 0.80m;


                bonus *= DepartmentMultiplier;


                decimal maxCap = BaseSalary * 0.40m;
                if (bonus > maxCap)
                    bonus = maxCap;


                decimal taxRate;
                if (bonus <= 150000)
                    taxRate = 0.10m;
                else if (bonus <= 300000)
                    taxRate = 0.20m;
                else
                    taxRate = 0.30m;

                bonus -= bonus * taxRate;


                return Math.Round(bonus, 2);
            }
        }
    }
        //internal class Employee
        //{
        //    public static void Main(string[] args)
        //    {
        //        EmployeeBonus employee = new EmployeeBonus()
        //        {
                     
        //        BaseSalary = 500000,
        //        PerformanceRating = 5,
        //        YearsOfExperience = 6,
        //        DepartmentMultiplier = 1.1m,
        //        AttendancePercentage = 95
            
        //        };
        //        Console.WriteLine(employee.NetAnnualBonus);
        //    }
        //}
    }
