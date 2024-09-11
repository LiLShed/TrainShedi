using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Transactions;
using System.Data.Common;

namespace StorageDataBaseBasic
{
    internal class DataAccess
    {
        public static string connectionString = "Server=DESKTOP-H9SIIRN\\SQLEXPRESS;Database=Storage;TrustServerCertificate=True;Integrated Security=True;";
        public DataAccess() { }
        public void UserDataWrite()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                connection.Open();
                Console.WriteLine("Connection to DataBase is successful.");
                Console.Write("Enter USERNAME - ");
                string username = Console.ReadLine();
                Console.Write("Enter user`s password - ");
                string password = Console.ReadLine();
                string hashedPassword = HashPassword(password);//Hashing password
                Console.Write($"Enter user role of {username} (a-admin/u-user) - ");
                string userRole = Console.ReadLine();
                switch (userRole.ToLower())
                {
                    case "a":
                        userRole = "admin"; break;
                    case "u":
                        userRole = "user"; break;
                    case "admin":
                        userRole = "admin"; break;
                    case "user":
                        userRole = "user"; break;
                    default:
                        userRole = "user";
                        break;
                }
                string sql = "INSERT INTO Users (Username, PasswordHash, UserRole) VALUES (@username, @passwordHash, @userRole)";

                using (SqlCommand cmd = new SqlCommand(sql, connection))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@passwordHash", hashedPassword);
                    cmd.Parameters.AddWithValue("@userRole", userRole);

                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Data was recorded.");
                }
                connection.Close();
            }
            Menu.UserMenu();
        }
        public void UserDataRead()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                Console.Write("\nEnter User, whose data u want to read - ");
                string username = Console.ReadLine();
                string sql = "SELECT * FROM Users WHERE Username = @username";
                using (SqlCommand cmd = new SqlCommand(sql, connection))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    SqlDataReader reader = cmd.ExecuteReader();
                    // Call Read before accessing data.
                    while (reader.Read())
                    {
                        Console.WriteLine($"ID - {reader.GetInt32(0)};\nUserName - {reader.GetString(1)};\n" +
                                          $"Password - {reader.GetString(2)};\nUserRole - {reader.GetString(3)};\n" +
                                          $"Created at - { reader.GetDateTime(4)}."); 
                    }
                    reader.Close();
                }
                connection.Close();
            }
            Menu.UserMenu();
        }
        public void UserDataDelete()
        {

            Menu.UserMenu();
        }
        public void UserDataEdit()
        {

            Menu.UserMenu();
        }
        public void ProductDataWrite()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                connection.Open();
                Console.WriteLine("Connection to DataBase is successful.");
                Console.Write("Enter ProductName  - ");
                string productname = Console.ReadLine();

                Console.WriteLine($"Enter CategoryId of  {productname}: ");
                Console.WriteLine("|                                          |\n" +
                                  "|1. __________Fruits and Vegetables_______;|\n" +
                                  "|2. _________________Tools________________;|\n" +
                                  "|3. _________________Goods________________;|\n" +
                                  "|4. ______________Electronics_____________;|\n" +
                                  "|5. ________________Clothing______________;|\n" +
                                  "|   __________________Else________________.|\n");
                int categoryId = 0;
                try
                {
                    categoryId = int.Parse(Console.ReadLine());
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                    categoryId = 6;
                }
                switch (categoryId)
                {
                    case 1:
                        Console.WriteLine("Your category is Fruits and Vegetables.");
                        break;
                    case 2:
                        Console.WriteLine("Your category is Tools.");
                        break;
                    case 3:
                        Console.WriteLine("Your category is Goods.");
                        break;
                    case 4:
                        Console.WriteLine("Your category is Electronics.");
                        break;
                    case 5:
                        Console.WriteLine("Your category is Clothing.");
                        break;
                    default: categoryId = 6; Console.WriteLine("Your category is ELSE."); break;
                }
                Console.Write($"\nEnter quantity of  {productname} - ");
                int quantity = 0;
                try
                {
                    quantity = int.Parse(Console.ReadLine());
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                    quantity = 0;
                }
                Console.Write($"Enter Price of {productname} for 1 item - ");
                float price = 0.0f;
                try
                {
                    price = float.Parse(Console.ReadLine());
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                    price = 0.0f;
                }
                string sql = "INSERT INTO Products (ProductName, CategoryID, Quantity, Price) VALUES (@productname, @categoryId, @quantity, @price)";

                using (SqlCommand cmd = new SqlCommand(sql, connection))
                {
                    cmd.Parameters.AddWithValue("@productname", productname);
                    cmd.Parameters.AddWithValue("@categoryId", categoryId);
                    cmd.Parameters.AddWithValue("@quantity", quantity);
                    cmd.Parameters.AddWithValue("@price", price);
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Data was recorded.");
                }
                connection.Close();
            }
            Menu.UserMenu();
        }
        
        public void ProductDataRead()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                Console.Write("\nEnter Product, which data u want to read - ");
                string Productname = Console.ReadLine();
                string sql = "SELECT * FROM Products WHERE ProductName = @Productname";
                string FindCategoryQuery = "SELECT Categories.CategoryName From Products JOIN Categories ON Products.CategoryID = Categories.CategoryID WHERE ProductName = @Productname";
                string ProductCategory = "";

                using (SqlCommand command = new SqlCommand(FindCategoryQuery, connection))
                {
                    command.Parameters.AddWithValue("@Productname", Productname);
                    try
                    {
                        object result = command.ExecuteScalar();
                        if (result != null)
                        {
                            ProductCategory = result.ToString();  
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"An error occurred: {ex.Message}");
                    }
                }

                using (SqlCommand cmd = new SqlCommand(sql, connection))
                {
                    cmd.Parameters.AddWithValue("@Productname", Productname);
                    SqlDataReader reader = cmd.ExecuteReader();
                    // Call Read before accessing data.
                    while (reader.Read())
                    {
                        Console.WriteLine($"ProductID - {reader.GetInt32(0)};\nProductName - {reader.GetString(1)};\n" +
                                          $"ProductCategory - {ProductCategory};\nCategoryID - {reader.GetInt32(2)};\nQuantity - {reader.GetInt32(3)};\n" +
                                          $"Price - {reader.GetDecimal(4)}.");
                    }
                    reader.Close();
                }
                connection.Close();
            }
            Menu.UserMenu();
        }
        public void ProductDataDelete()
        {

            Menu.UserMenu();
        }
        public void ProductDataEdit()
        {

            Menu.UserMenu();
        }
        public void InventoryDataWrite()
        {
            //make to find a productID by name , and after enter his quantities
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                connection.Open();
                Console.WriteLine("Connection to DataBase is successful.");
                Console.Write("Enter ProductName that ypu want record in Inventory  - ");
                string productName = Console.ReadLine();

                string query = "SELECT ProductID FROM Products WHERE ProductName = @ProductName";

                SqlCommand command = new SqlCommand(query, connection); 
                command.Parameters.AddWithValue("@ProductName", productName);
                int productID = 0;
                try
                {
                    object result = command.ExecuteScalar();  // Выполняем запрос и возвращаем первое значение
                    if (result != null)
                    {
                        productID = Convert.ToInt32(result);  // Преобразуем результат в int
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }
                Console.WriteLine(productID);    
                Console.Write($"\nEnter quantityIN of {productName} in Inventory  - ");
                int quantityIN = 0;
                try
                {
                    quantityIN = int.Parse(Console.ReadLine());
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                    quantityIN = 0;
                }
                Console.Write($"\nEnter quantityOUT of {productName} from Inventory  - ");
                int quantityOUT = 0;
                try
                {
                    quantityOUT = int.Parse(Console.ReadLine());
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                    quantityOUT = 0;
                }
                string sql = "INSERT INTO Inventory (ProductID, QuantityIn, QuantityOut) VALUES (@productid, @quantityIN, @quantityOUT)";
                using (SqlCommand cmd = new SqlCommand(sql, connection))
                {
                    cmd.Parameters.AddWithValue("@productid", productID);
                    cmd.Parameters.AddWithValue("@quantityIN", quantityIN);
                    cmd.Parameters.AddWithValue("@quantityOUT", quantityOUT);
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Data was recorded.");
                }
                connection.Close();
                }
            Menu.UserMenu();
        }

        public void InventoryDataRead()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();                  //If SOMEONE NEED to FIND 1 row

                //Console.Write("\nEnter Product, which data u want to read from inventory - ");
                //string Productname = Console.ReadLine();
                //string FindProductIdByNameQuery = "SELECT Products.ProductID From Inventory \n" +
                //                                    "JOIN Products ON Products.ProductID = Inventory.ProductID" +
                //                                    "\n WHERE ProductName = @Productname";
                //int productid = 0;
                //using (SqlCommand command = new SqlCommand(FindProductIdByNameQuery, connection))
                //{
                //    command.Parameters.AddWithValue("@Productname", Productname);
                //    try
                //    {
                //        object result = command.ExecuteScalar();
                //        if (result != null)
                //        {
                //            productid = Convert.ToInt32(result);
                //        }
                //    }
                //    catch (Exception ex)
                //    {
                //        Console.WriteLine($"An error occurred: {ex.Message}");
                //    }
                //}

                string sql = "SELECT InventoryID, Products.ProductName, Inventory.ProductID, QuantityIn, QuantityOut, TransactionDate From Inventory"+
                            "\nJOIN Products ON Products.ProductID = Inventory.ProductID";

                using (SqlCommand cmd = new SqlCommand(sql, connection))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    // Call Read before accessing data.
                    Console.WriteLine("|InventoryId|ProductName|ProductID|QuantityIn|QuantityOut|TransactionDate____|");
                    while (reader.Read())
                    {
                        int cell0 = reader.GetInt32(0);
                        string cell1 = reader.GetString(1);
                        int cell2 = reader.GetInt32(2);
                        int cell3 = reader.GetInt32(3);
                        int cell4 = reader.GetInt32(4);
                        string cell5 = reader.GetDateTime(5).ToString();
                        Console.WriteLine($"|{cell0.ToString().PadRight(11, '_')}|{cell1.PadRight(11, '_')}|{cell2.ToString().PadRight(9, '_')}|" +
                                          $"{cell3.ToString().PadRight(10, '_')}|{cell4.ToString().PadRight(11, '_')}|{cell5.PadRight(19, '_')}|");
                    }
                }
                connection.Close();
            }
            Menu.UserMenu();
        }
        public void InventoryDataDelete()
        {

            Menu.UserMenu();
        }
        public void InventoryDataEdit()
        {

            Menu.UserMenu();
        }


            static string HashPassword(string password)
            {
                using (SHA256 sha256Hash = SHA256.Create())
                {
                    byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

                    StringBuilder builder = new StringBuilder();
                    foreach (byte b in bytes)
                    {
                        builder.Append(b.ToString("x2"));
                    }
                    return builder.ToString();
                }
            }
    }
}
