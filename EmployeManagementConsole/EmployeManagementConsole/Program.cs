namespace EmployeManagementConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Manager manager = new Manager(1, "Kuddus Mia", 40000.0, 10000.0);
            Developer developer=new Developer(2, "Kabir singh", 50000.0, 10000.0);

            Console.WriteLine("Manager Details");
            manager.DisplayDetails();

            Console.WriteLine(" ");

            Console.WriteLine("Developer Details");
            developer.DisplayDetails();

            Console.WriteLine(" ");
            Console.WriteLine(" ");

            Console.WriteLine("Manager Total Salary: "+ manager.CalculateSalary());
            Console.WriteLine("Developer Total Salary: " + developer.CalculateSalary());

        }
    }
}
