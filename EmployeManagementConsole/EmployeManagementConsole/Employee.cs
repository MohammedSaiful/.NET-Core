using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeManagementConsole
{
    internal class Employee
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public double BasicSalary { get; set; }

        public Employee(int id, string name, double salary) 
        {
            EmployeeId = id;
            Name = name;
            BasicSalary = salary;
        }

        public virtual double CalculateSalary()
        {
            return BasicSalary;
        }

        public virtual void DisplayDetails()
        {
            Console.WriteLine("Employee Id: " + EmployeeId);
            Console.WriteLine("Name: "+ Name);
            Console.WriteLine("Basic Salary: "+ BasicSalary);
        }
    }
}
