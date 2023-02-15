using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Categories
{
    internal class DateGridWievCategories
    {
        [DisplayName("Ad")]
        public string Name { get; set; }
        [Browsable(false)]
        public int Id { get; set; }

        public bool Status { get; set; }
    }
}
