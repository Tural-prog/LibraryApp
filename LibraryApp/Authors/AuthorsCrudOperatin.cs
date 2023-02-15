using LibraryApp.Categories;
using LibraryApp.Common;
using LibraryApp.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryApp.Authors
{
    internal class AuthorsCrudOperatin
    {
        private bool IsCategoriesDataValid (string name)
        {
            if(string.IsNullOrEmpty(name))
            {
                MessageBox.Show("please type name");
                return false;
            }     
            else
            {
                return true;
            }
        }

        internal void  AuthorsInsert(string name)
        {
            if(IsCategoriesDataValid(name))
            {
                string query = @"INSERT INTO Authors (Name)
                                VALUES(@Name) ";

                using (SqlConnection cn = new SqlConnection(Tools.GetConnectionString()))
                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    cmd.Parameters.Add("@Name" , SqlDbType.VarChar,50).Value=  name;
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    cn.Close();
                }

            }
        }
        internal void AuthorsUpdate(int id, string name)
        {
            string query = @"UPDATE Authors SET Name = @name WHERE Id=@id";
            using (SqlConnection cn = new SqlConnection(Tools.GetConnectionString()))
            using (SqlCommand cmd = new SqlCommand(query, cn))
            {
                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = id;
                cmd.Parameters.Add("@Name", SqlDbType.VarChar,50).Value = name;
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
            }

        }
        internal void DeleteAuthors(int id)
        {
            string query = @"DELETE Authors  WHERE Id=@id";
            using (SqlConnection cn = new SqlConnection(Tools.GetConnectionString()))
            using (SqlCommand cmd = new SqlCommand(query, cn))
            {
                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = id;             
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
            }

        }
        internal IEnumerable<DataGridWiewAuthors> GetAuthors()
        {
            SqlDataAdapter sda;
            DataTable dt = new DataTable();
            using (SqlConnection cn = new SqlConnection(Tools.GetConnectionString()))
            {
                sda = new SqlDataAdapter(@"SELECT * FROM Authors  ", cn);
                sda.Fill(dt);
                return Tools.ConvertDataTable<DataGridWiewAuthors>(dt);
            }

        }
        internal IEnumerable<IdName> GetAuthorsByIdName()
        {
            SqlDataAdapter sda;
            DataTable dt = new DataTable();
            using (SqlConnection cn = new SqlConnection(Tools.GetConnectionString()))
            {
                sda = new SqlDataAdapter(@"SELECT * FROM Authors  ", cn);
                sda.Fill(dt);
                return Tools.ConvertDataTable<IdName>(dt);
            }

        }

        internal DataGridWiewAuthors GetAuthorsById(int id)
        {
            SqlDataAdapter sda;
            DataTable dt = new DataTable();
            using (SqlConnection cn = new SqlConnection(Tools.GetConnectionString()))
            {
                sda = new SqlDataAdapter(@"SELECT * FROM Authors WHERE Id = @id ", cn);
                sda.SelectCommand.Parameters.AddWithValue("@id", id);
                sda.Fill(dt);
                return Tools.ConvertDataTable<DataGridWiewAuthors>(dt)[0];
            }
        }



    }
}
