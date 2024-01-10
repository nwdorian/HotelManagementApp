using DataLibrary;
using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI;

internal class Guests
{
    internal static void ShowMenu()
    {
        bool repeatMenu = true;
        while (repeatMenu)
        {
            repeatMenu = false;
            Console.Clear();
            Console.WriteLine("****** GUESTS *******");
            Console.WriteLine("* 1. Preview        *");
            Console.WriteLine("* 2. Add            *");
            Console.WriteLine("* 3. Update         *");
            Console.WriteLine("* 4. Delete         *");
            Console.WriteLine("* 5. Back           *");
            Console.WriteLine("*********************");
            Console.WriteLine();
            Console.Write("Choose an option: ");
            string menuChoice = Console.ReadLine();

            switch (menuChoice.Trim())
            {
                case "1":
                    Helpers.PrintGuests(DbMethods.GetGuests());
                    Console.WriteLine();
                    Console.Write("Press any key to continue...");
                    Console.ReadKey();
                    ShowMenu();
                    break;
                case "2":
                    Console.WriteLine();
                    Console.WriteLine("NEW GUEST");
                    try
                    {
                        Guest newGuest = new Guest();
                        string firstName = Helpers.PromptUserForString("First name: ");
                        if (!string.IsNullOrEmpty(firstName))
                        {
                            newGuest.FirstName = firstName;
                        }
                        string lastName = Helpers.PromptUserForString("Last name: ");
                        if (!string.IsNullOrEmpty(lastName))
                        {
                            newGuest.LastName = lastName;
                        }
                        string phone = Helpers.PromptUserForString("Phone: ");
                        if (!string.IsNullOrEmpty(phone))
                        {
                            newGuest.Phone = phone;
                        }
                        string email = Helpers.PromptUserForString("Email: ");
                        if (!string.IsNullOrEmpty(email))
                        {
                            newGuest.Email = email;
                        }
                        string adress = Helpers.PromptUserForString("Adress: ");
                        if (!string.IsNullOrEmpty(adress))
                        {
                            newGuest.Adress = adress;
                        }
                        string addCity = Helpers.PromptUserForString("City: ");
                        if (!string.IsNullOrEmpty(addCity))
                        {
                            City city = DbMethods.GetCityByName(addCity);
                            if (city == null)
                            {
                                city = new City();
                                city.Name = addCity;
                                city.Id = Helpers.PromptUserForNumber("Postal code:");
                                DbMethods.AddCity(city);

                            }
                            newGuest.CityId = city.Id;
                        }
                        string addCountry = Helpers.PromptUserForString("Country: ");
                        if (!string.IsNullOrEmpty(addCountry))
                        {
                            Country country = DbMethods.GetCountryByName(addCountry);
                            if (country == null)
                            {
                                country = new Country();
                                country.Name = addCountry;
                                DbMethods.AddCountry(country);
                            }
                            newGuest.CountryId = country.Id;
                        }
                        DbMethods.AddGuest(newGuest);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Error! Details: " + e.Message);
                    }
                    Console.WriteLine();
                    Console.Write("Press any key to continue...");
                    Console.ReadKey();
                    ShowMenu();
                    break;
                case "3":
                    Console.WriteLine();
                    Console.WriteLine("NEW GUEST");
                    try
                    {
                        Guest editGuest = DbMethods.GetGuest(Helpers.PromptUserForNumber("Enter Guest ID: "));
                        string newFirstName = Helpers.PromptUserForString($"First name ({editGuest.FirstName}): ");
                        if (!string.IsNullOrEmpty(newFirstName))
                        {
                            editGuest.FirstName = newFirstName;
                        }
                        string newLastName = Helpers.PromptUserForString($"Last name ({editGuest.LastName}): ");
                        if (!string.IsNullOrEmpty(newFirstName))
                        {
                            editGuest.LastName = newLastName;
                        }
                        string newPhone = Helpers.PromptUserForString($"Phone ({editGuest.Phone}): ");
                        if (!string.IsNullOrEmpty(newPhone))
                        {
                            editGuest.Phone = newPhone;
                        }
                        string newEmail = Helpers.PromptUserForString($"Email ({editGuest.Email}): ");
                        if (!string.IsNullOrEmpty(newEmail))
                        {
                            editGuest.Email = newEmail;
                        }
                        string newAdress = Helpers.PromptUserForString($"Adress ({editGuest.Adress}): ");
                        if (!string.IsNullOrEmpty(newAdress))
                        {
                            editGuest.Adress = newAdress;
                        }
                        string newCity = Helpers.PromptUserForString($"City ({editGuest.City.Name}): ");
                        if (!string.IsNullOrEmpty(newCity))
                        {
                            City city = DbMethods.GetCityByName(newCity);
                            if (city == null)
                            {
                                city = new City();
                                city.Name = newCity;
                                city.Id = Helpers.PromptUserForNumber("Postal code: ");
                                DbMethods.AddCity(city);
                            }
                            editGuest.CityId = city.Id;
                        }
                        string newCountry = Helpers.PromptUserForString($"Country ({editGuest.Country.Name}): ");
                        if (!string.IsNullOrEmpty(newCountry))
                        {
                            Country country = DbMethods.GetCountryByName(newCountry);
                            if (country == null)
                            {
                                country = new Country();
                                country.Name = newCountry;
                                DbMethods.AddCountry(country);
                            }
                            editGuest.CountryId = country.Id;
                        }
                        DbMethods.EditGuest(editGuest);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Error! Details: " + e.Message);
                    }
                    Console.WriteLine();
                    Console.Write("Press any key to continue...");
                    Console.ReadKey();
                    ShowMenu();
                    break;
                case "4":
                    Console.WriteLine();
                    Console.WriteLine("REMOVE GUEST");
                    try
                    {
                        Guest removeGuest = DbMethods.GetGuest(Helpers.PromptUserForNumber("Enter Guest ID: "));
                        DbMethods.RemoveGuest(removeGuest.Id);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Error! Details: " + e.Message);
                    }
                    break;
                case "5":
                    Menu.ShowMenu();
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
