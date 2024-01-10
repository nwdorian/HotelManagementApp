﻿using DataLibrary;
using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI;

internal class Helpers
{
    internal static void PrintGuests(List<Guest> guestList)
    {
        Console.WriteLine();
        Console.WriteLine("GUEST LIST");
        foreach (Guest g in DbMethods.GetGuests())
        {
            Console.WriteLine($"{g.Id}. Name: {g.FirstName} {g.LastName}, Phone: {g.Phone}, Email: {g.Email}, Adress: {g.Adress}, {g.City.Name} {g.CityId}, {g.Country.Name}");
        }
    }

    internal static string PromptUserForString(string prompt)
    {
        Console.Write(prompt);
        string userInput = Console.ReadLine();
        return userInput;
    }

    internal static int PromptUserForNumber(string prompt)
    {
        Console.Write(prompt);
        int readValue;
        if (int.TryParse(Console.ReadLine(), out readValue))
        {
            return readValue;
        }
        return 0;
    }
}
