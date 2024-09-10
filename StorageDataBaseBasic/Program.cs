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
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Menu.UserMenu();
        }
    }
}
