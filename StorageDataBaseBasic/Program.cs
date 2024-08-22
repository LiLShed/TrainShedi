using System;
using System.IO;
using Microsoft.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;

namespace StorageDataBaseBasic
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello,This is a Storage Database Console Application!");
            string connectionString = "Server=DESKTOP-H9SIIRN;Database=Storage;";

            string username = "Shedi";
            string password = "ShediProDotaGamer";
            string hashedPassword = HashPassword(password);
            string userRole = "user";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                Console.WriteLine("Подключение к базе данных успешно выполнено.");
                string sql = "INSERT INTO Users (Username, PasswordHash, UserRole) VALUES (@username, @passwordHash, @userRole)";

                using (SqlCommand cmd = new SqlCommand(sql, connection))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@passwordHash", hashedPassword);
                    cmd.Parameters.AddWithValue("@userRole", userRole);

                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Данные успешно вставлены.");
                }
            }
        }

        //Hashing a password
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
