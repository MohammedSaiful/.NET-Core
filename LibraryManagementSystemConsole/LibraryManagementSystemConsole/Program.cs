namespace LibraryManagementSystemConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Book book1 = new Book("Fundamentals of OOP", 1, true, "Salman khan");
            Book book2 = new Book("Applied Chemistry", 2, true, "Saiful khan");

            Magazine magazine1 =new Magazine("Daily Star", 1, true, 20);

            book1.DisplayInfo();
            Console.WriteLine("");

            book2.DisplayInfo();
            Console.WriteLine("");

            magazine1.DisplayInfo();
            Console.WriteLine("");

            book1.IsAvailable = false;
            book1.DisplayInfo();

        }
    }
}
