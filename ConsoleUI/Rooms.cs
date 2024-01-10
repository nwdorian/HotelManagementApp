using DataLibrary;
using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI;

internal class Rooms
{
    internal static void ShowMenu()
    {
        bool repeatMenu = true;
        while (repeatMenu)
        {
            repeatMenu = false;
            Console.Clear();
            Console.WriteLine("****** ROOMS *******");
            Console.WriteLine("* 1. Preview       *");
            Console.WriteLine("* 2. Add           *");
            Console.WriteLine("* 3. Update        *");
            Console.WriteLine("* 4. Delete        *");
            Console.WriteLine("* 5. Back          *");
            Console.WriteLine("*********************");
            Console.WriteLine();
            Console.Write("Choose an option: ");
            string menuChoice = Console.ReadLine();

            switch (menuChoice.Trim())
            {
                case "1":
                    Helpers.PrintRooms(DbMethods.GetRooms());
                    Console.WriteLine();
                    Console.Write("Press any key to continue...");
                    Console.ReadKey();
                    ShowMenu();
                    break;
                case "2":
                    Console.WriteLine();
                    Console.WriteLine("ADD ROOM");
                    try
                    {
                        Room newRoom = new Room();
                        int roomNumber = Helpers.PromptUserForNumber("Room number: ");
                        if (roomNumber != 0)
                        {
                            newRoom.Number = roomNumber;
                        }
                        int floor = Helpers.PromptUserForNumber("Floor number: ");
                        if (floor != 0)
                        {
                            newRoom.Floor = floor;
                        }
                        int numberOfBeds = Helpers.PromptUserForNumber("Number of beds: ");
                        if (numberOfBeds != 0)
                        {
                            newRoom.NumBeds = numberOfBeds;
                        }
                        string bedType = Helpers.PromptUserForString("Bed type: ");
                        if (!string.IsNullOrEmpty(bedType))
                        {
                            Bed bed = DbMethods.GetBedByName(bedType);
                            if (bed == null)
                            {
                                bed = new Bed();
                                bed.Name = bedType;
                                DbMethods.AddBed(bed);
                            }
                            newRoom.BedId = bed.Id;
                        }
                        DbMethods.AddRoom(newRoom);
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
                    Console.WriteLine("EDIT ROOM");
                    try
                    {
                        Room editRoom = DbMethods.GetRoom(Helpers.PromptUserForNumber("Enter room ID: "));
                        int newRoomNumber = Helpers.PromptUserForNumber($"Room number ({editRoom.Number}): ");
                        if (newRoomNumber != 0)
                        {
                            editRoom.Number = newRoomNumber;
                        }
                        int newFloor = Helpers.PromptUserForNumber($"Floor number ({editRoom.Floor}): ");
                        if (newFloor != 0)
                        {
                            editRoom.Floor = newFloor;
                        }
                        int newNumberOfBeds = Helpers.PromptUserForNumber($"Number of beds ({editRoom.NumBeds}): ");
                        if (newNumberOfBeds != 0)
                        {
                            editRoom.NumBeds = newNumberOfBeds;
                        }
                        string newBedType = Helpers.PromptUserForString($"Bed type ({editRoom.Bed.Name}): ");
                        if (!string.IsNullOrEmpty(newBedType))
                        {
                            Bed bed = DbMethods.GetBedByName(newBedType);
                            if (bed == null)
                            {
                                bed = new Bed();
                                bed.Name = newBedType;
                                DbMethods.AddBed(bed);
                            }
                            editRoom.BedId = bed.Id;
                        }
                        DbMethods.EditRoom(editRoom);
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
                    Console.WriteLine("DELETE ROOM");
                    try
                    {
                        Room removeRoom = DbMethods.GetRoom(Helpers.PromptUserForNumber("Enter room ID: "));
                        DbMethods.RemoveRoom(removeRoom.Id);
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
