using DataLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary
{
    public class DbMethods
    {
        public static List<Guest> GetGuests()
        {
            List<Guest> guests = new List<Guest>();
            try
            {
                using (HotelManagementContext context = new HotelManagementContext())
                {
                    guests = context.Guest.Include(x => x.City).Include(x => x.Country).ToList();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error! Details: " + e.Message);
            }
            return guests;
        }

        public static void AddGuest(Guest newGuest)
        {
            try
            {
                using (HotelManagementContext context = new HotelManagementContext())
                {
                    context.Guest.Add(newGuest);
                    context.SaveChanges();
                }
                Console.WriteLine("New guest was succesfully added!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error! Details: " + e.Message);
            }
        }

        public static Guest GetGuest(int id)
        {
            try
            {
                using (HotelManagementContext context = new HotelManagementContext())
                {
                    Guest guest = context.Guest.Include(x => x.City).Include(x => x.Country).FirstOrDefault(x => x.Id == id);
                    if (guest != default)
                    {
                        return guest;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error! Details: " + e.Message);
            }
            return null;
        }

        public static void EditGuest(Guest guest)
        {
            try
            {
                using (HotelManagementContext context = new HotelManagementContext())
                {
                    Guest editGuest = context.Guest.FirstOrDefault(x => x.Id == guest.Id);
                    if (editGuest != default)
                    {
                        editGuest.FirstName = guest.FirstName;
                        editGuest.LastName = guest.LastName;
                        editGuest.Phone = guest.Phone;
                        editGuest.Email = guest.Email;
                        editGuest.Adress = guest.Adress;
                        editGuest.CityId = guest.CityId;
                        editGuest.CountryId = guest.CountryId;
                        context.SaveChanges();
                    }
                }
                Console.WriteLine("Guest was successfully updated!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error! Details: " + e.Message);
            }
        }

        public static void RemoveGuest(int id)
        {
            try
            {
                using (HotelManagementContext context = new HotelManagementContext())
                {
                    Guest removeGuest = context.Guest.FirstOrDefault(x => x.Id == id);
                    if (removeGuest != default)
                    {
                        context.Remove(removeGuest);
                        context.SaveChanges();
                    }
                }
                Console.WriteLine("Guest was successfully deleted!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error! Details: " + e.Message);
            }
        }

        public static void AddCity(City newCity)
        {
            try
            {
                using (HotelManagementContext context = new HotelManagementContext())
                {
                    context.City.Add(newCity);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error! Details: " + e.Message);
            }
        }

        public static City GetCityByName(string cityName)
        {
            try
            {
                using (HotelManagementContext context = new HotelManagementContext())
                {
                    City city = context.City.FirstOrDefault(x => x.Name == cityName);
                    if (city != default)
                    {
                        return city;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error! Details: " + e.Message);
            }
            return null;
        }

        public static void AddCountry(Country newCountry)
        {
            try
            {
                using (HotelManagementContext context = new HotelManagementContext())
                {
                    context.Country.Add(newCountry);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error! Details: " + e.Message);
            }
        }

        public static Country GetCountryByName(string countryName)
        {
            try
            {
                using (HotelManagementContext context = new HotelManagementContext())
                {
                    Country country = context.Country.FirstOrDefault(x => x.Name == countryName);
                    if (country != default)
                    {
                        return country;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error! Details: " + e.Message);
            }
            return null;
        }

        
    }
}
