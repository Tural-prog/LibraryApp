using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Books
{
    internal class DataGridiWiewBooks
    {
        [Browsable(false)]
        public int Id { get; set; }
        [DisplayName("Kitab Adı")]
        public string BookName { get; set; }
       
        [DisplayName("Müəllif")]
        public string AuthorName { get; set; }
        [DisplayName("Kateqoriya")]
        public string CategoryName { get; set; }
        [DisplayName("Çap ili")]
        public DateTime PrintDate { get; set; }
    }
}
