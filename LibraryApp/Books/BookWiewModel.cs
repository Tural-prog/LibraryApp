using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Books
{
    internal class BookWiewModel
    {
        [Browsable(false)]

        public int Id { get; set; }
        [DisplayName("Kitab Adı")]
        public string Name { get; set; }
       
        [DisplayName("Müəllif")]
        public int AuthorId { get; set; }
        [DisplayName("Kateqoriya")]
        public int CategoryId { get; set; }
        [DisplayName("Çap ili")]
        public DateTime PrintDate { get; set; }
    }
}
