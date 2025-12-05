using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeManagementConsole
{
    internal class Developer: Employee
    {
        public double ProjectAllowance { get; set; }
        public Developer(int id, string name, double salary, double project_allowance) : base(id, name, salary)
        {
            ProjectAllowance = project_allowance;
        }

        public override double CalculateSalary()
        {
            return BasicSalary + ProjectAllowance;
        }

        public override void DisplayDetails()
        {
            base.DisplayDetails();
            Console.WriteLine("Project Allowance: " + ProjectAllowance);
            Console.WriteLine("Salary with Project Allowance: " + CalculateSalary());
        }
    }
}
