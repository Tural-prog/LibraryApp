using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using LibraryApp.Utils;
using System.Windows.Forms;
using LibraryApp.Common;

namespace LibraryApp.Categories
{
    internal class CategoriesCrudOperation
    {
        private bool IsCategoriesDataValid(string name)
        {
            if(string.IsNullOrEmpty( name ))
            {
                MessageBox.Show("Please type name");
                return false;
            }
            else
            {
                return true;
            }
               
        }
        internal void CategoriesInsert (string name)
        {   
            if (IsCategoriesDataValid(name))
            {
                string query = @"INSERT INTO Categories (Name)
                                VALUES (@Name) ";

                using (SqlConnection cn = new SqlConnection(Tools.GetConnectionString()))
                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    cmd.Parameters.Add("@Name", SqlDbType.VarChar, 50).Value = name;
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    cn.Close();
                }
            }
        }
        internal void CategoriesUpdate ( int id,string name) 
        {
            string query = @"UPDATE Categories SET Name = @name WHERE Id =@id";
            
            using (SqlConnection cn = new SqlConnection (Tools.GetConnectionString()))
            using (SqlCommand cmd = new SqlCommand(query, cn))
            {
                cmd.Parameters.Add(@"Id" , SqlDbType.Int).Value = id;
                cmd.Parameters.Add("@Name ", SqlDbType.VarChar, 50).Value = name;
                cn.Open();
                cmd.ExecuteNonQuery(); 
                cn.Close();
            }
        }
        internal void DeleteCategories(int id)
        {
            string query = @"DELETE FROM Categories WHERE id=@id";

            using (SqlConnection cn = new SqlConnection(Tools.GetConnectionString()))
            using(SqlCommand cmd = new SqlCommand(query, cn))
            {
                cmd.Parameters.Add(@"id", SqlDbType.Int).Value=id;
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
            }
           
        }
        internal IEnumerable<DateGridWievCategories> GetCategories()
        {
            SqlDataAdapter sda;
            DataTable dt = new DataTable();
            using (SqlConnection cn = new SqlConnection(Tools.GetConnectionString()))
            {
                sda = new SqlDataAdapter(@"SELECT Id, Name FROM Categories  ", cn);
                sda.Fill(dt);
                return Tools.ConvertDataTable<DateGridWievCategories>(dt);
            }
        }
        internal IEnumerable<IdName> GetCategoriesByIdName()
        {
            SqlDataAdapter sda;
            DataTable dt = new DataTable();
            using (SqlConnection cn = new SqlConnection(Tools.GetConnectionString()))
            {
                sda = new SqlDataAdapter(@"SELECT * FROM Categories  ", cn);
                sda.Fill(dt);
                return Tools.ConvertDataTable<IdName>(dt);
            }
        }
        internal DateGridWievCategories GetCategoriesById(int id)
        {
            SqlDataAdapter sda;
            DataTable dt = new DataTable();
            using (SqlConnection cn = new SqlConnection(Tools.GetConnectionString()))
            {
                sda = new SqlDataAdapter(@"SELECT Name FROM Categories WHERE Id = @id ", cn);
                sda.SelectCommand.Parameters.AddWithValue("@id", id);
                sda.Fill(dt);
                return Tools.ConvertDataTable<DateGridWievCategories>(dt)[0];
            }
        }

    }
}
