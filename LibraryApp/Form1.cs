using LibraryApp.Authors;
using LibraryApp.Books;
using LibraryApp.Categories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void categoriesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frmCategories = new frmCategories();
            frmCategories.Show();
        }

        private void authorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frmAuthors = new frmAuthors();
            frmAuthors.Show();
        }

        private void booksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frmBooks = new frmBooks();
            frmBooks.Show();
        }
    }
}
