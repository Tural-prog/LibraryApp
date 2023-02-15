using LibraryApp.Authors;
using LibraryApp.Categories;
using LibraryApp.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryApp.Books
{
    public partial class frmBooks : Form
    {
        int selectedid = -1;
        BooksCrudOperation _booksOperation;
        AuthorsCrudOperatin  _authorsOperation;
        CategoriesCrudOperation _categoriesOperation;
        BooksValidate _validation;

        public frmBooks()
        {
            _booksOperation = new BooksCrudOperation();
            _authorsOperation = new AuthorsCrudOperatin();
           _categoriesOperation = new CategoriesCrudOperation();
            _validation = new BooksValidate();
            InitializeComponent();

            cmbAuthors.DataSource = _authorsOperation.GetAuthorsByIdName();
            cmbCategories.DataSource =_categoriesOperation.GetCategoriesByIdName();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_validation.Validate(txtName.Text, dateTimePicker1.Value,cmbAuthors.SelectedItem, cmbCategories.SelectedItem))
            {
                _booksOperation.BooksInsert( txtName.Text, dateTimePicker1.Value, cmbAuthors.SelectedItem.AsInt(), cmbCategories.SelectedItem.AsInt());

                dgvBooks.DataSource = _booksOperation.GetBooksV2();
            }
        }

        private void dgvBooks_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                var row = dgvBooks.Rows[e.RowIndex].DataBoundItem;
                var val = (DataGridiWiewBooks)row;

                var books = _booksOperation.GetBooksById(val.Id);
                cmbAuthors.SelectedValue = books.AuthorId;
                cmbCategories.SelectedValue = books.CategoryId;
                txtName.Text = books.Name;
                dateTimePicker1.Value = books.PrintDate;
                selectedid = val.Id;

            }
        }

        private void btnWiew_Click(object sender, EventArgs e)
        {
            dgvBooks.DataSource = _booksOperation.GetBooksV2();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            _booksOperation.DeleteBooks(selectedid);
            dgvBooks.DataSource =_booksOperation.GetBooksV2();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            _booksOperation.UpdateBooks(selectedid, txtName.Text, dateTimePicker1.Value, cmbAuthors.SelectedItem.AsInt(), cmbCategories.SelectedItem.AsInt());
            dgvBooks.DataSource = _booksOperation.GetBooksV2();
        }
    }
}
