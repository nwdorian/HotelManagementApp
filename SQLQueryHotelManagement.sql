CREATE DATABASE HotelManagement
GO

USE HotelManagement
GO

CREATE TABLE city(
id			INT PRIMARY KEY,
name		NVARCHAR(50) NOT NULL
)
GO

CREATE TABLE country(
id			INT PRIMARY KEY IDENTITY(1,1),
name		NVARCHAR(50) NOT NULL
)


CREATE TABLE guest(
id					INT PRIMARY KEY IDENTITY(1,1),
cityId				INT FOREIGN KEY REFERENCES city(id) NOT NULL,
countryId			INT FOREIGN KEY REFERENCES country(id) NOT NULL,
firstName			NVARCHAR(50) NOT NULL,
lastName			NVARCHAR(50) NOT NULL,
email				NVARCHAR(100) NOT NULL,
phone				NVARCHAR(20) NOT NULL,
adress				NVARCHAR(50) NOT NULL
)
GO

CREATE TABLE reservation(
id			INT PRIMARY KEY IDENTITY(1,1),
guestId		INT FOREIGN KEY REFERENCES guest(id) NOT NULL,
checkIn		DATETIME NOT NULL,
checkOut	DATETIME NOT NULL
)
GO

CREATE TABLE bed(
id			INT PRIMARY KEY IDENTITY(1,1),
name		NVARCHAR(50) NOT NULL
)
GO

CREATE TABLE room(
id			INT PRIMARY KEY IDENTITY(1,1),
bedId		INT FOREIGN KEY REFERENCES bed(id) NOT NULL,
numBeds		INT NOT NULL,
number		INT NOT NULL,
floor		INT NOT NULL
)
GO

CREATE TABLE roomReservation(
id				INT PRIMARY KEY IDENTITY(1,1),
reservationId	INT FOREIGN KEY REFERENCES reservation(id) NOT NULL,
roomId			INT FOREIGN KEY REFERENCES room(id) NOT NULL
)
GO

INSERT INTO city (id, name) VALUES (10000, 'Zagreb')
INSERT INTO city (id, name) VALUES (31000, 'Osijek')
INSERT INTO city (id, name) VALUES (51000, 'Rijeka')
INSERT INTO city (id, name) VALUES (21000, 'Split')
INSERT INTO city (id, name) VALUES (20000, 'Dubrovnik')
INSERT INTO city (id, name) VALUES (35000, 'Slavonski Brod')

INSERT INTO country (name) VALUES ('Croatia')
INSERT INTO country (name) VALUES ('Slovenia')
INSERT INTO country (name) VALUES ('England')
INSERT INTO country (name) VALUES ('France')
INSERT INTO country (name) VALUES ('Germany')
INSERT INTO country (name) VALUES ('Austria')


INSERT INTO guest (firstName, lastName, email, phone, adress, cityId, countryId) 
			VALUES ('Karlo', 'Horvat', 'khorvat@gmail.com', '091123456', 'Osječka cesta 32', 10000, 1)
INSERT INTO guest (firstName, lastName, email, phone, adress, cityId, countryId) 
			VALUES ('Petra', 'Mirković', 'pmirkovic@gmail.com', '091987654', 'Ljudevita Gaja 18', 31000, 1)
INSERT INTO guest (firstName, lastName, email, phone, adress, cityId, countryId) 
			VALUES ('Luka', 'Modrić', 'lmodric@gmail.com', '098456123', 'Miroslava Krleže 63', 21000, 1)
INSERT INTO guest (firstName, lastName, email, phone, adress, cityId, countryId) 
			VALUES ('Ana', 'Stanić', 'astanic@gmail.com', '098654321', 'Stjepana Radića 5', 51000, 1)
INSERT INTO guest (firstName, lastName, email, phone, adress, cityId, countryId) 
			VALUES ('Dario', 'Perić', 'dperic@gmail.com', '095817263', 'Ante Starčevića 22', 20000, 1)
INSERT INTO guest (firstName, lastName, email, phone, adress, cityId, countryId) 
			VALUES ('Ivan', 'Ivić', 'iivic@gmail.com', '095128764', 'Sunčana ulica 123', 35000, 1)

INSERT INTO reservation(guestId, checkIn, checkOut)
			VALUES(1, '2024-01-13 16:00', '2024-01-20 12:00')
INSERT INTO reservation(guestId, checkIn, checkOut)
			VALUES(2, '2024-01-20 16:00', '2024-01-27 12:00')
INSERT INTO reservation(guestId, checkIn, checkOut)
			VALUES(3, '2024-01-10 16:00', '2024-01-24 12:00')
INSERT INTO reservation(guestId, checkIn, checkOut)
			VALUES(4, '2024-01-22 16:00', '2024-01-28 12:00')
INSERT INTO reservation(guestId, checkIn, checkOut)
			VALUES(5, '2024-02-03 16:00', '2024-02-10 12:00')
INSERT INTO reservation(guestId, checkIn, checkOut)
			VALUES(6, '2024-02-03 16:00', '2024-02-17 12:00')

INSERT INTO bed(name) VALUES ('single')
INSERT INTO bed(name) VALUES ('double')
INSERT INTO bed(name) VALUES ('king')

INSERT INTO room(bedId, numBeds, number, floor) VALUES (1, 2, 1, 1)
INSERT INTO room(bedId, numBeds, number, floor) VALUES (1, 2, 2, 1)
INSERT INTO room(bedId, numBeds, number, floor) VALUES (1, 2, 3, 1)
INSERT INTO room(bedId, numBeds, number, floor) VALUES (2, 2, 1, 2)
INSERT INTO room(bedId, numBeds, number, floor) VALUES (2, 2, 2, 2)
INSERT INTO room(bedId, numBeds, number, floor) VALUES (2, 2, 3, 2)
INSERT INTO room(bedId, numBeds, number, floor) VALUES (3, 1, 1, 3)
INSERT INTO room(bedId, numBeds, number, floor) VALUES (3, 1, 2, 3)

INSERT INTO roomReservation(reservationId, roomId)
				VALUES(1, 2)
INSERT INTO roomReservation(reservationId, roomId)
				VALUES(2, 1)
INSERT INTO roomReservation(reservationId, roomId)
				VALUES(3, 4)
INSERT INTO roomReservation(reservationId, roomId)
				VALUES(4, 3)
INSERT INTO roomReservation(reservationId, roomId)
				VALUES(5, 5)
INSERT INTO roomReservation(reservationId, roomId)
				VALUES(5, 6)
INSERT INTO roomReservation(reservationId, roomId)
				VALUES(6, 7)
INSERT INTO roomReservation(reservationId, roomId)
				VALUES(6, 8)