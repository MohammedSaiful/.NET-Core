using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystemConsole
{
    internal class LibraryItem
    {
        public string Title { get; set; }
        public int ItemId { get; set; }
        public bool IsAvailable { get; set; }

        public LibraryItem(string title, int id, bool check)
        {
            Title = title;
            ItemId = id;
            IsAvailable = check;
        }

        public virtual void DisplayInfo()
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
        }
    }
}
