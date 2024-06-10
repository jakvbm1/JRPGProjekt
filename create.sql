use test1;

Create table Users(
Email varchar(25) not null, 
Password varchar(20) not null,
Username varchar(25) not null,
PlayerOrAdmin bool not null,
PRIMARY KEY(Email),
FOREIGN KEY(Username) REFERENCES Characters(Username)
 );  

Create table Items(
 ItemID INT UNSIGNED NOT NULL AUTO_INCREMENT,
    Sprite VARCHAR(30),
    Cost INT,
    Kind ENUM('weapon', 'armor', 'Accessory', 'Consumable') NOT NULL,
    EquipableFor ENUM('mage', 'warrior', 'ranger', 'everyone'),
    PRIMARY KEY (ItemID)
);


CREATE TABLE Enemies(
Enemy_Name varchar(25) NOT NULL,
Health INT unsigned NOT NULL,
Attack INT unsigned NOT NULL,
SpriteSet VARCHAR(25),
Defense INT unsigned NOT NULL,
Difficulty Enum('easy', 'medium', 'hard'),
PRIMARY KEY (Enemy_Name)
);

CREATE TABLE Classes(
Class_Name varchar(25) NOT NULL,
Health INT unsigned NOT NULL,
Attack INT unsigned NOT NULL,
SpriteSet VARCHAR(25),
Defense INT unsigned NOT NULL,
Difficulty Enum('easy', 'medium', 'hard'),
PRIMARY KEY (Class_Name)
);



CREATE TABLE Characters(
Username varchar(25) not null,
Exp_Level int not null,
Gold int not null,
Class_Name varchar(25) NOT NULL,
Primary Key(Username),
FOREIGN KEY(Class_Name) REFERENCES Classes(Class_Name) 
);


CREATE TABLE EQUIPMENT(
ItemID INT UNSIGNED NOT NULL,
Quantity INT UNSIGNED NOT NULL, 
IsEquipped bool NOT NULL,
Username varchar(25) not null,
foreign key(Username) references Characters(Username),
foreign key(ItemID) references Items(ItemID)
);


