using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryApp.Categories
{
    public partial class frmCategories : Form
    {
        int selectedid = -1;
        CategoriesCrudOperation _categoriesOperation;
        public frmCategories()
        {
            _categoriesOperation = new CategoriesCrudOperation();
            InitializeComponent();
        }
        private void btnSAave_Click_1(object sender, EventArgs e)
        {
            _categoriesOperation.CategoriesInsert(txtName.Text);
            dgvCategories.DataSource = _categoriesOperation.GetCategories();
        }

        private void btnWiev_Click(object sender, EventArgs e)
        {
            dgvCategories.DataSource = _categoriesOperation.GetCategories();
        }

        private void dgvCategories_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                var row = dgvCategories.Rows[e.RowIndex].DataBoundItem;
                var val = (DateGridWievCategories)row;

                var user = _categoriesOperation.GetCategoriesById(val.Id);
                txtName.Text = user.Name;
                selectedid = val.Id;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            _categoriesOperation.CategoriesUpdate (selectedid ,txtName.Text);
            dgvCategories.DataSource = _categoriesOperation.GetCategories();

        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            {
                _categoriesOperation.DeleteCategories(selectedid);
                dgvCategories.DataSource = _categoriesOperation.GetCategories();
            }

        }

       
    }
}
