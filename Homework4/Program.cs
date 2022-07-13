using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Net;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Data;

namespace Homework4
{
    internal class Program
    {
        private static readonly string connectionString = ConfigurationManager.ConnectionStrings["NorthwindDb"].ConnectionString;

        public void Main(string[] args)
        {
            InsertData(8,"Northwoods Cranberry Sauce" ,  3 ,  2 ,   "12 - 12 oz jars", 40  , 6,  0  , 0  , false);
            DeleteData(2);
            UpdateData(3, 5, 100);
        }

        private void InsertData(int productId, string productName, int supplierId, int categoryId, string quantityPerUnit, decimal unitPrice, short unitInStock, short unitsOnOrder, short reorderLevel, bool discontinued)
        {

            using (var sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();

                var sql = @"INSERT INTO Products (ProductId,ProductName,SupplierId,CategoryId,QuantityPerUnit,UnitPrice,UnitsInStock,UnitsOnOrder,ReorderLevel,Discontinued)" 
        + "VALUES (@ProductId,@ProductName,@SupplierId,@CategoryId,@QuantityPerUnit,@UnitPrice,@UnitsInStock,@UnitsOnOrder,@ReorderLevel,@Discontinued)";

                using (var sqlCommand = new SqlCommand(sql, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@ProductId", productId);
                    sqlCommand.Parameters.AddWithValue("@ProductName", productName);
                    sqlCommand.Parameters.AddWithValue("@SupplierId", supplierId);
                    sqlCommand.Parameters.AddWithValue("@CategoryId", categoryId);
                    sqlCommand.Parameters.AddWithValue("@QuantityPerUnit", quantityPerUnit);
                    sqlCommand.Parameters.AddWithValue("@UnitPrice", unitPrice);
                    sqlCommand.Parameters.AddWithValue("@UnitsInStock", unitInStock);
                    sqlCommand.Parameters.AddWithValue("@UnitsOnOrder", unitsOnOrder);
                    sqlCommand.Parameters.AddWithValue("@ReorderLevel", reorderLevel);
                    sqlCommand.Parameters.AddWithValue("@Discontinued", discontinued);


                    var rowsAffected = sqlCommand.ExecuteNonQuery();
                }
            }



        }
        private void UpdateData(int productId, int categoryId, int unitPrice)
        {

            using (var sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();

                var sql = "UPDATE Products SET UnitPrice = @UnitPrice WHERE ProductID = @ProductID AND CategoryID = @CategoryID";
                using (var sqlCommand = new SqlCommand(sql, sqlConnection))
                {

                    sqlCommand.Parameters.AddWithValue("@CategoryId", categoryId);

                    sqlCommand.Parameters.AddWithValue("@ProductId", productId);
                    
                    sqlCommand.Parameters.AddWithValue("@UnitPrice", unitPrice);


                    var rowsAffected = sqlCommand.ExecuteNonQuery();
                }
            }

        }

        private void DeleteData(int productId)
        {

            using (var sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();

                var sql = "DELETE FROM Products WHERE [ProductId] = @ProductId";
                using (var sqlCommand = new SqlCommand(sql, sqlConnection))
                {
                    var rowsAffected = sqlCommand.ExecuteNonQuery();
                }
            }

        }

       


    }
}
