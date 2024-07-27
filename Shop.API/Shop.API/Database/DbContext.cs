using Microsoft.Data.SqlClient;
using Shop_CSharp.Models;
using System.Data;

namespace Shop.API.Database
{
    public class DbContext
    {
        string connectionString = @"Server=leonascim\mssqlserver01;Database=SHOP_CSHARP;Trusted_Connection=yes;Encrypt=False;";
        public Product AddProduct(Product p)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    var sql = $"Products.InsertProduct";
                    command.CommandText = sql;
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("Name", p.Name));
                    command.Parameters.Add(new SqlParameter("Description", p.Description));
                    command.Parameters.Add(new SqlParameter("Quantity", p.Quantity));
                    command.Parameters.Add(new SqlParameter("Price", p.Price));
                    command.Parameters.Add(new SqlParameter("Markdown", p.Markdown));
                    command.Parameters.Add(new SqlParameter("Bogo", p.Bogo));
                    var id = new SqlParameter("Id", p.Id);
                    id.Direction = ParameterDirection.Output;
                    command.Parameters.Add(id);

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
            return p;
        }
        public Product UpdateProduct(Product p)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    var sql = $"Products.UpdateProduct";
                    command.CommandText = sql;
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("Name", p.Name));
                    command.Parameters.Add(new SqlParameter("Description", p.Description));
                    command.Parameters.Add(new SqlParameter("Quantity", p.Quantity));
                    command.Parameters.Add(new SqlParameter("Price", p.Price));
                    command.Parameters.Add(new SqlParameter("Markdown", p.Markdown));
                    command.Parameters.Add(new SqlParameter("Bogo", p.Bogo));
                    command.Parameters.Add(new SqlParameter("Id", p.Id));

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
            return p;
        }
        public int DeleteProduct(int productId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    var sql = $"Products.DeleteProduct";
                    command.CommandText = sql;
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("Id", productId));

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    connection.Close();
                }
            }
            return productId;
        }

        public List<Product> GetProducts()
        {
            List<Product> products = new List<Product>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    var sql = $"SELECT Id, Name, Description, Quantity, Price, Markdown, Bogo FROM PRODUCTS";
                    command.CommandText = sql;
                    command.CommandType = CommandType.Text;

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Product product = new Product
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                Description = reader.GetString(2),
                                Quantity = reader.GetInt32(3),
                                Price = reader.GetDecimal(4),
                                Markdown = reader.GetDouble(5),
                                Bogo = reader.GetBoolean(6)
                            };
                            products.Add(product);
                        }
                    }
                    connection.Close();
                }
            }

            return products;
        }
    }  
}



