using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using Microsoft.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

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
        }
        public void UserDataRead()
        {

        }
        public void UserDataDelete()
        {

        }
        public void UserDataEdit()
        {

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
        }
        
            public void ProductDataRead()
            {

            }
            public void ProductDataDelete()
            {

            }
            public void ProductDataEdit()
            {

            }
            public void InventoryDataWrite()
            {
            //make to find a productID by name , and after enter his quantities
            }
            public void InventoryDataRead()
            {

            }
            public void InventoryDataDelete()
            {

            }
            public void InventoryDataEdit()
            {

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
