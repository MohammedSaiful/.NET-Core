using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystemConsole
{
    internal class Book : LibraryItem
    {
        public string Author { get; set; }
        public Book(string title, int id, bool check, string author) : base(title, id, check)
        {
            Author = author;
        }


        public override void DisplayInfo()
        {
            Console.WriteLine("Title: " + Title);
            Console.WriteLine("Item Id: " + ItemId);
            if (IsAvailable)
            {
                Console.WriteLine("Available");
            }
            else
            {
                Console.WriteLine("Unavailable");
            }

            Console.WriteLine("Author: " + Author);
        }
    }
}
