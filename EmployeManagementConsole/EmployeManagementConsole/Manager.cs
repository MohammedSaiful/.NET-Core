using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeManagementConsole
{
    internal class Manager: Employee
    {
        public double Bonus { get; set; }
        public Manager(int id, string name, double salary, double bonus): base(id, name, salary) 
        { 
            this.Bonus = bonus;
        }

        public override double CalculateSalary()
        {
            return BasicSalary + Bonus;
        }

        public override void DisplayDetails()
        {
            base.DisplayDetails();
            Console.WriteLine("Bonus: " + Bonus);
            Console.WriteLine("Salary with Bonus: "+ CalculateSalary());
        }
    }
}
