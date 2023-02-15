using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Authors
{
    internal class DataGridWiewAuthors
    {
        [Browsable(false)]
        public int Id { get; set; }
        [DisplayName("Adı")]
        public string Name { get; set; }
    }
}
