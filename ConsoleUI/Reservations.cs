using DataLibrary;
using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI;

internal class Reservations
{
    internal static void ShowMenu()
    {
        bool repeatMenu = true;
        while (repeatMenu)
        {
            repeatMenu = false;
            Console.Clear();
            Console.WriteLine("****** RESERVATIONS *******");
            Console.WriteLine("* 1. Preview              *");
            Console.WriteLine("* 2. Add                  *");
            Console.WriteLine("* 3. Delete               *");
            Console.WriteLine("* 4. Back                 *");
            Console.WriteLine("***************************");
            Console.WriteLine();
            Console.Write("Choose an option: ");
            string menuChoice = Console.ReadLine();

            switch (menuChoice)
            {
                case "1":
                    Helpers.PrintReservations(DbMethods.GetReservations());
                    Console.WriteLine();
                    Console.Write("Press any key to continue...");
                    Console.ReadKey();
                    ShowMenu();
                    break;
                case "2":
                    Console.WriteLine();
                    Console.WriteLine("NEW RESERVATION");
                    Reservation reservation = new Reservation();
                    Helpers.PrintGuests(DbMethods.GetGuests());
                    Console.WriteLine();
                    int guestId = Helpers.PromptUserForNumber("Enter guest ID: ");
                    if (guestId != 0)
                    {
                        reservation.GuestId = guestId;
                    }
                    DateTime checkInDate = Helpers.PromptUserForDateTime("Enter check in date: ");
                    if (checkInDate != DateTime.MinValue)
                    {
                        reservation.CheckIn = checkInDate;
                    }
                    DateTime checkOutDate = Helpers.PromptUserForDateTime("Enter check out date: ");
                    if (checkOutDate != DateTime.MinValue)
                    {
                        reservation.CheckOut = checkOutDate;
                    }
                    RoomReservation roomReservation = new RoomReservation();
                    bool addRoom = false;
                    do
                    {
                        roomReservation.Reservation = reservation;
                        Console.WriteLine();
                        Helpers.PrintRooms(DbMethods.GetRooms());
                        Console.WriteLine();
                        int roomId = Helpers.PromptUserForNumber("Enter Room ID: ");
                        if (roomId != 0)
                        {
                            roomReservation.RoomId = roomId;
                        }
                        Console.WriteLine("Would you like to add more rooms (y/n)? ");
                        string addMore = Console.ReadLine();
                        addRoom = addMore.ToLower() == "y" ? true : false;
                    } while (addRoom);
                    reservation.RoomReservation.Add(roomReservation);
                    DbMethods.AddReservation(reservation);
                    Console.WriteLine();
                    Console.Write("Press any key to continue...");
                    Console.ReadKey();
                    ShowMenu();
                    break;
                case "3":
                    Console.WriteLine();
                    Console.WriteLine("DELETE RESERVATION");
                    try
                    {
                        Reservation removeReservation = DbMethods.GetReservation(Helpers.PromptUserForNumber("Enter reservation ID: "));
                        DbMethods.RemoveReservation(removeReservation.Id);
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

