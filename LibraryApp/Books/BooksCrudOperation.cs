using LibraryApp.Utils;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibraryApp.Common;

namespace LibraryApp.Books
{
    internal class BooksCrudOperation
    {
        private bool IsSchedulesDataValid(string name, DateTime printDate, int authorsid, int categoriesid)
        {
            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Please type Book Name.");
                return false;
            }

            else if (authorsid == -1)
            {
                MessageBox.Show("Please type categories Name ");
                return false;
            }
            else if (categoriesid == -1)
            {
                MessageBox.Show("Please type Authors name");
                return false;
            }
          
            else
            {
                return true;
            }
        }
        internal void BooksInsert(string name , DateTime printDate, int authorsid,int categoriesid)
        {
            if(IsSchedulesDataValid(name,printDate, authorsid, categoriesid))
            {
                string query = @"INSERT INTO Books (Name, PrintDate, AuthorId, CategoryId)
                                VALUES (@Name, @PrintDate ,@AuthorId, @CategoryId ) ";

                using (SqlConnection cn = new SqlConnection(Tools.GetConnectionString()))
                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    cmd.Parameters.Add("@Name", SqlDbType.VarChar,50).Value=name;
                    cmd.Parameters.Add("@PrintDate", SqlDbType.DateTime).Value = printDate;
                    cmd.Parameters.Add("@AuthorId", SqlDbType.Int).Value =authorsid;
                    cmd.Parameters.Add("@CategoryId", SqlDbType.Int).Value =categoriesid;
                    
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    cn.Close();
                }
            }
        }
        internal void DeleteBooks(int id)
        {
            string query = @"DELETE FROM Books Where id = @id";

            using (SqlConnection cn = new SqlConnection(Tools.GetConnectionString()))
            using (SqlCommand cmd = new SqlCommand(query, cn))
            {
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();

            }
        }
        internal void UpdateBooks(int id, string name, DateTime printDate, int authorsid, int categoriesid)
        {
            string query = @"UPDATE Books SET Name = @name,PrintDate = @printDate, AuthorId = @authorsid, CategoryId = @categoriesid WHERE Id = @id";
            using (SqlConnection cn = new SqlConnection(Tools.GetConnectionString()))
            using (SqlCommand cmd = new SqlCommand(query, cn))
            {
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                cmd.Parameters.Add("@name", SqlDbType.VarChar,50).Value = name;
                cmd.Parameters.Add("@printDate", SqlDbType.DateTime).Value = printDate;
                cmd.Parameters.Add("@authorsid",  SqlDbType.Int).Value = authorsid;
                cmd.Parameters.Add("@categoriesid",SqlDbType.Int).Value = categoriesid;
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
            }
        }
        internal IEnumerable<DataGridiWiewBooks > GetBooks()
        {
            SqlDataAdapter sda;
            DataTable dt = new DataTable();
            using (SqlConnection cn = new SqlConnection(Tools.GetConnectionString()))
            {
                sda = new SqlDataAdapter(@"SELECT *FROM Books", cn);
                sda.Fill(dt);
                return Tools.ConvertDataTable<DataGridiWiewBooks>(dt);
            }
        }
        internal IEnumerable<DataGridiWiewBooks> GetBooksV2()
        {
            SqlDataAdapter sda;
            DataTable dt = new DataTable();
            using (SqlConnection cn = new SqlConnection(Tools.GetConnectionString()))
            {
                sda = new SqlDataAdapter(@"SELECT B.Id,A.Name AS AuthorName, C.Name AS CategoryName , B.Name AS BookName, 
                                            B.PrintDate AS PrintDate FROM Books as B
                                            INNER JOIN Authors as A ON B.AuthorId = A.Id
                                            INNER JOIN Categories as C ON B.CategoryId = C.Id", cn);

                sda.Fill(dt);
                return Tools.ConvertDataTable<DataGridiWiewBooks>(dt);
            }
        }
   
        internal BookWiewModel GetBooksById(int id)
        {
            SqlDataAdapter sda;
            DataTable dt = new DataTable();
            using (SqlConnection cn = new SqlConnection(Tools.GetConnectionString()))
            {
                sda = new SqlDataAdapter(@"SELECT * FROM Books  WHERE Id = @id", cn);
                sda.SelectCommand.Parameters.AddWithValue("@id", id);
                sda.Fill(dt);
                return Tools.ConvertDataTable<BookWiewModel>(dt)[0];
            }
        }
    }
}
