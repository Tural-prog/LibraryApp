using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryApp.Authors
{
    public partial class frmAuthors : Form
    {
         int selectedeid = -1;
        AuthorsCrudOperatin _aouthorsOperation;
        public frmAuthors()
        {
            _aouthorsOperation = new AuthorsCrudOperatin();
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _aouthorsOperation.AuthorsInsert(txtName.Text);
            dgvAuthors.DataSource = _aouthorsOperation.GetAuthors();

        }

        private void btnWiew_Click(object sender, EventArgs e)
        {
            dgvAuthors.DataSource = _aouthorsOperation.GetAuthors();
        }

        private void dgvAuthors_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex>-1)
            {
                var row = dgvAuthors.Rows[e.RowIndex].DataBoundItem;
                var val = (DataGridWiewAuthors)row;

                var authors = _aouthorsOperation.GetAuthorsById(val.Id);
                txtName.Text = authors.Name;
                selectedeid = val.Id;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            _aouthorsOperation.AuthorsUpdate(selectedeid, txtName.Text);
            dgvAuthors.DataSource = _aouthorsOperation.GetAuthors();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            _aouthorsOperation.DeleteAuthors(selectedeid);
            dgvAuthors.DataSource = _aouthorsOperation.GetAuthors();
        }
    }
}
