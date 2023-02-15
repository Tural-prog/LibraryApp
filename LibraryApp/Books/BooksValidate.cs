using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Common
{
    internal class BooksValidate
    {
        bool IsValid(object obj)
        {
            return obj != null;
        }
        internal bool Validate( object name, object printDate, object authorsid, object categoriesid)
        {
            return IsValid(name) & IsValid(printDate) & IsValid(authorsid) & IsValid(categoriesid);
        }
    }
}
