using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageDataBaseBasic
{
    static internal class Menu
    {
        private static DataAccess dataAccess = new DataAccess();
        public static void UserMenu()
        {
            Console.WriteLine("\n|___________________MENU___________________|\n");
              Console.WriteLine("|1.Work With User Data                     |\n" +
                                "|2.Work With Products Data                 |\n" +
                                "|3.Work With Inventory Data                |\n" +
                                "|4.Exit                                    |\n" +
                                "|Else. Clear Window                        |\n");
            int i = 0;
            try
            {
                i = int.Parse(Console.ReadLine());
            }
            catch (FormatException e)
            { 
                Console.WriteLine(e.Message); 
                UserMenu();
            }
            switch (i)
            {
                case 1:
                    UserSwitchMenu(i);
                    break;
                case 2:
                    ProductsSwitchMenu(i);
                    break;
                case 3:
                    InventorySwitchMenu(i);
                    break;
                case 4:
                    break;
                default:
                    Console.Clear();
                    UserMenu();
                    break;
            }
        }
        public static void UserSwitchMenu(int i)
        {
            Console.WriteLine("\n|______________User MENU___________________|\n");
            Console.WriteLine("|1.Write new User Data                     |\n" +
                              "|2.Read User Data                          |\n" +
                              "|3.Delete User Data                        |\n" +
                              "|4.Edit User Data                          |\n" +
                              "|5.Back                                    |\n" +
                              "|Else. Clear Window                        |\n");
            try
            {
                i = int.Parse(Console.ReadLine());
            }
            catch (FormatException e)
            { 
                Console.WriteLine(e.Message);
                UserSwitchMenu(i);
            }
            switch (i)
            {
                case 1:
                    dataAccess.UserDataWrite();
                    break;
                case 2:
                    dataAccess.UserDataRead();
                    break;
                case 3:
                    dataAccess.UserDataDelete();
                    break;
                case 4:
                    dataAccess.UserDataEdit();
                    break;
                case 5:
                    Console.Clear();
                    UserMenu();
                    break;
                default :
                    Console.Clear();
                    UserSwitchMenu(i);
                    break;

            }
        }
        public static void ProductsSwitchMenu(int i)
        {
            Console.WriteLine("\n|__________Products MENU___________________|\n");
            Console.WriteLine("|1.Write new Products Data                 |\n" +
                              "|2.Read Products Data                      |\n" +
                              "|3.Delete Products Data                    |\n" +
                              "|4.Edit Products Data                      |\n" +
                              "|5.Back                                    |\n" +
                              "|Else. Clear Window                        |\n");
            try
            {
                i = int.Parse(Console.ReadLine());
            }
            catch (FormatException e)
            { 
                Console.WriteLine(e.Message);
                ProductsSwitchMenu(i);
            }
            switch (i)
            {
                case 1:
                    dataAccess.ProductDataWrite();
                    break;
                case 2:
                    dataAccess.ProductDataRead();
                    break;
                case 3:
                    dataAccess.ProductDataDelete();
                    break;
                case 4:
                    dataAccess.ProductDataEdit();
                    break;
                case 5:
                    Console.Clear();
                    UserMenu();
                    break;
                default:
                    Console.Clear();
                    ProductsSwitchMenu(i);
                    break;

            }
        }
        public static void InventorySwitchMenu(int i)
        {
            Console.WriteLine("\n|_________Inventory MENU___________________|\n");
            Console.WriteLine("|1.Write new Inventory Data                |\n" +
                              "|2.Read Inventory Data                     |\n" +
                              "|3.Delete Inventory Data                   |\n" +
                              "|4.Edit Inventory Data                     |\n" +
                              "|5.Back                                    |\n" +
                              "|Else. Clear Window                        |\n");
            try
            {
                i = int.Parse(Console.ReadLine());
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
                InventorySwitchMenu(i);
            }
            switch (i)
            {
                case 1:
                    dataAccess.InventoryDataWrite();
                    break;
                case 2:
                    dataAccess.InventoryDataRead();
                    break;
                case 3:
                    dataAccess.InventoryDataDelete();
                    break;
                case 4:
                    dataAccess.InventoryDataEdit();
                    break;
                case 5:
                    Console.Clear();
                    UserMenu();
                    break;
                default:
                    Console.Clear();
                    InventorySwitchMenu(i);
                    break;

            }
        }
    }   
}
