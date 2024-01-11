using DataLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary;

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
                Guest removeGuest = context.Guest.Include(x => x.Reservation).ThenInclude(x => x.RoomReservation).FirstOrDefault(x => x.Id == id);
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

    public static List<Room> GetRooms()
    {
        List<Room> rooms = new List<Room>();
        try
        {
            using (HotelManagementContext context = new HotelManagementContext())
            {
                rooms = context.Room.Include(x => x.Bed).ToList();
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Error! Details: " + e.Message);
        }
        return rooms;
    }

    public static void AddRoom(Room newRoom)
    {
        try
        {
            using (HotelManagementContext context = new HotelManagementContext())
            {
                context.Room.Add(newRoom);
                context.SaveChanges();
            }
            Console.WriteLine("New room was succesfully added!");
        }
        catch (Exception e)
        {
            Console.WriteLine("Error! Details: " + e.Message);
        }
    }

    public static Room GetRoom(int id)
    {
        try
        {
            using (HotelManagementContext context = new HotelManagementContext())
            {
                Room room = context.Room.Include(x => x.Bed).FirstOrDefault(x => x.Id == id);
                if (room != default)
                {
                    return room;
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Error! Details: " + e.Message);
        }
        return null;
    }

    public static void EditRoom(Room room)
    {
        try
        {
            using (HotelManagementContext context = new HotelManagementContext())
            {
                Room editRoom = context.Room.FirstOrDefault(x => x.Id == room.Id);
                if (editRoom != default)
                {
                    editRoom.Number = room.Number;
                    editRoom.Floor = room.Floor;
                    editRoom.NumBeds = room.NumBeds;
                    editRoom.BedId = room.BedId;
                    context.SaveChanges();
                }
            }
            Console.WriteLine("Room was successfully updated!");
        }
        catch (Exception e)
        {
            Console.WriteLine("Error! Details: " + e.Message);
        }
    }

    public static void RemoveRoom(int id)
    {
        try
        {
            using (HotelManagementContext context = new HotelManagementContext())
            {
                Room removeRoom = context.Room.FirstOrDefault(x => x.Id == id);
                if (removeRoom != default)
                {
                    context.Remove(removeRoom);
                    context.SaveChanges();
                }
            }
            Console.WriteLine("Room was successfully deleted!");
        }
        catch (Exception e)
        {
            Console.WriteLine("Error! Details: " + e.Message);
        }
    }

    public static Bed GetBedByName(string bedName)
    {
        try
        {
            using (HotelManagementContext context = new HotelManagementContext())
            {
                Bed bed = context.Bed.FirstOrDefault(x => x.Name == bedName);
                if (bed != default)
                {
                    return bed;
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Error! Details: " + e.Message);
        }
        return null;
    }

    public static void AddBed(Bed newBed)
    {
        try
        {
            using (HotelManagementContext context = new HotelManagementContext())
            {
                context.Bed.Add(newBed);
                context.SaveChanges();
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Error! Details: " + e.Message);
        }
    }

    public static List<RoomReservation> GetReservations()
    {
        List<RoomReservation> reservations = new List<RoomReservation>();
        try
        {
            using (HotelManagementContext context = new HotelManagementContext())
            {
                reservations = context.RoomReservation.Include(x => x.Reservation).ToList();
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Error! Details: " + e.Message);
        }
        return reservations;
    }

    public static void AddReservation(Reservation newReservation)
    {
        try
        {
            using (HotelManagementContext context = new HotelManagementContext())
            {
                context.Reservation.Add(newReservation);
                context.SaveChanges();
            }
            Console.WriteLine("New reservation was succesfully added!");
        }
        catch (Exception e)
        {
            Console.WriteLine("Error! Details: " + e.Message);
        }
    }

    public static Reservation GetReservation(int id)
    {
        try
        {
            using (HotelManagementContext context = new HotelManagementContext())
            {
                Reservation reservation = context.Reservation.FirstOrDefault(x => x.Id == id);
                if (reservation != default)
                {
                    return reservation;
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Error! Details: " + e.Message);
        }
        return null;
    }

    public static void RemoveReservation(int id)
    {
        try
        {
            using (HotelManagementContext context = new HotelManagementContext())
            {
                Reservation removeReservation = context.Reservation.Include(x => x.RoomReservation).FirstOrDefault(x => x.Id == id);
                if (removeReservation != default)
                {
                    context.Remove(removeReservation);
                    context.SaveChanges();
                }
            }
            Console.WriteLine("Reservation was successfully deleted!");
        }
        catch (Exception e)
        {
            Console.WriteLine("Error! Details: " + e.Message);
        }
    }
}

