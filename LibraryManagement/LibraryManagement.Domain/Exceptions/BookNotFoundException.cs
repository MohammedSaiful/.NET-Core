using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Domain.Exceptions
{
    public class BookNotFoundException : Exception
    {
        public BookNotFoundException(int id)
            : base($"Book with ID {id} was not found.") { }
    }
}
