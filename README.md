# HotelManagementApp
Console based CRUD application for management of rooms, guests and reservations of a hotel.

Developed using C# and SQL Server Express.

# Features
* Console based UI where users can navigate the menus by key presses
  - ![image](https://github.com/nwdorian/HotelManagementApp/assets/118033138/4a1582ce-7b2b-4d62-b2ca-8e6926846a46)

* Database-first approach
  - database was designed in SSMS using SQL statements and seeded with initial data
  - [SQL File](https://github.com/nwdorian/HotelManagementApp/blob/master/SQLQueryHotelManagement.sql) is included in the repository
  - EC Core scaffolding is used to create a DbContext class based on the database schema:
    
   ![image](https://github.com/nwdorian/HotelManagementApp/assets/118033138/295886b0-aeec-4be8-b1f1-ed5e5780a281)

* CRUD DB Operations
  - in the sub-menus users can Create, Read, Update or Delete entries for Guests, Rooms and Reservations
  - Country or City entries for a Guest are added if they don't already exist in the respective table, same is true for Bed type when adding or updating Room information
  - Cascade Delete behavior is configured for deleting a Guest so that dependent entities (Reservation, RoomReservation) are deleted aswell
   
