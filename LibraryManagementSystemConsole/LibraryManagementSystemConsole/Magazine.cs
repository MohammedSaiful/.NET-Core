using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystemConsole
{
    internal class Magazine: LibraryItem
    {
        public int IssuedNumber { get; set; }
        public Magazine(string title, int id, bool check, int issued_number) : base(title, id, check)
        {
            IssuedNumber = issued_number;
        }

        public override void DisplayInfo()
        {
            base.DisplayInfo();

            Console.WriteLine("Issued Number: " + IssuedNumber);
        }
    }
}
