using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI;

internal class Menu
{
    internal static void ShowMenu()
    {
        bool repeatMenu = true;
        while (repeatMenu)
        {
            repeatMenu = false;
            Console.Clear();
            Console.WriteLine("****** ROOM BOOKING *******");
            Console.WriteLine("* 1. Reservations         *");
            Console.WriteLine("* 2. Guests               *");
            Console.WriteLine("* 3. Rooms                *");
            Console.WriteLine("* 4. Exit                 *");
            Console.WriteLine("***************************");
            Console.WriteLine();
            Console.Write("Choose an option: ");
            string menuChoice = Console.ReadLine();

            switch (menuChoice.Trim())
            {
                case "1":
                    Reservations.ShowMenu();
                    break;
                case "2":
                    Guests.ShowMenu();
                    break;
                case "3":
                    Rooms.ShowMenu();
                    break;
                case "4":
                    Console.WriteLine();
                    Console.Write("Are you sure you want to exit? (y/n): ");
                    string userInput = Console.ReadLine();
                    while (userInput.ToLower().Trim() != "y" && userInput.ToLower().Trim() != "n")
                    {
                        Console.Write("Please select 'y' or 'n': ");
                        userInput = Console.ReadLine();
                    }
                    if (userInput.ToLower().Trim() == "n")
                    {
                        repeatMenu = true;
                    }
                    Console.WriteLine("Goodbye!");
                    break;
                default:
                    Console.WriteLine();
                    Console.Write("Invalid input! Press any key to continue... ");
                    Console.ReadKey();
                    repeatMenu = true;
                    break;
            }
        }
    }
}

