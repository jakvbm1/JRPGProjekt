-- MySQL dump 10.13  Distrib 8.0.36, for Win64 (x86_64)
--
-- Host: localhost    Database: jrpg
-- ------------------------------------------------------
-- Server version	8.0.37

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `characters`
--

DROP TABLE IF EXISTS `characters`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `characters` (
  `CharId` int unsigned NOT NULL AUTO_INCREMENT,
  `userMail` varchar(25) NOT NULL,
  `Exp_Level` int NOT NULL,
  `Gold` int NOT NULL,
  `Class_Name` varchar(25) NOT NULL,
  PRIMARY KEY (`CharId`),
  KEY `Class_Name` (`Class_Name`),
  KEY `userMail` (`userMail`),
  CONSTRAINT `characters_ibfk_1` FOREIGN KEY (`Class_Name`) REFERENCES `classes` (`Class_Name`),
  CONSTRAINT `characters_ibfk_2` FOREIGN KEY (`userMail`) REFERENCES `users` (`Email`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `characters`
--

LOCK TABLES `characters` WRITE;
/*!40000 ALTER TABLE `characters` DISABLE KEYS */;
INSERT INTO `characters` VALUES (4,'tymek@dybal.pl',1,10,'Warrior'),(6,'damian@knopek.pl',1,10,'Ranger'),(7,'kuba@miarka.pl',1,10,'Mage');
/*!40000 ALTER TABLE `characters` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `classes`
--

DROP TABLE IF EXISTS `classes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `classes` (
  `Class_Name` varchar(25) NOT NULL,
  `Health` int unsigned NOT NULL,
  `Attack` int unsigned NOT NULL,
  `SpriteSet` varchar(25) DEFAULT NULL,
  `Defense` int unsigned NOT NULL,
  `Difficulty` enum('easy','medium','hard') DEFAULT NULL,
  PRIMARY KEY (`Class_Name`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `classes`
--

LOCK TABLES `classes` WRITE;
/*!40000 ALTER TABLE `classes` DISABLE KEYS */;
INSERT INTO `classes` VALUES ('Mage',8,14,'mage',8,'medium'),('Ranger',10,10,'ranger',9,'medium'),('Warrior',12,8,'warrior',11,'medium');
/*!40000 ALTER TABLE `classes` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `enemies`
--

DROP TABLE IF EXISTS `enemies`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `enemies` (
  `Enemy_Name` varchar(25) NOT NULL,
  `Health` int unsigned NOT NULL,
  `Attack` int unsigned NOT NULL,
  `SpriteSet` varchar(25) DEFAULT NULL,
  `Defense` int unsigned NOT NULL,
  `Difficulty` enum('easy','medium','hard') DEFAULT NULL,
  PRIMARY KEY (`Enemy_Name`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `enemies`
--

LOCK TABLES `enemies` WRITE;
/*!40000 ALTER TABLE `enemies` DISABLE KEYS */;
INSERT INTO `enemies` VALUES ('drakon',15,16,'dragonborn',8,'medium'),('Goblin',7,10,'goblin',5,'easy'),('Golem',20,13,'golem',16,'medium'),('szkielet',10,5,'skeleton',7,'easy');
/*!40000 ALTER TABLE `enemies` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `equipment`
--

DROP TABLE IF EXISTS `equipment`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `equipment` (
  `ItemID` int unsigned NOT NULL,
  `Quantity` int unsigned NOT NULL,
  `IsEquipped` tinyint(1) NOT NULL,
  `CharId` int unsigned NOT NULL AUTO_INCREMENT,
  KEY `CharId` (`CharId`),
  KEY `ItemID` (`ItemID`),
  CONSTRAINT `equipment_ibfk_1` FOREIGN KEY (`CharId`) REFERENCES `characters` (`CharId`),
  CONSTRAINT `equipment_ibfk_2` FOREIGN KEY (`ItemID`) REFERENCES `items` (`ItemID`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `equipment`
--

LOCK TABLES `equipment` WRITE;
/*!40000 ALTER TABLE `equipment` DISABLE KEYS */;
INSERT INTO `equipment` VALUES (8,1,1,7),(7,1,0,7),(4,1,0,7);
/*!40000 ALTER TABLE `equipment` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `items`
--

DROP TABLE IF EXISTS `items`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `items` (
  `ItemID` int unsigned NOT NULL AUTO_INCREMENT,
  `Sprite` varchar(30) DEFAULT NULL,
  `Cost` int DEFAULT NULL,
  `Kind` enum('weapon','armor','accessory','consumable') NOT NULL,
  `EquipableFor` enum('mage','warrior','ranger','everyone') DEFAULT NULL,
  `Attack` int DEFAULT '0',
  `Defense` int DEFAULT '0',
  `Max_hp` int DEFAULT '0',
  `Regen_hp` int DEFAULT '0',
  `name` varchar(25) DEFAULT NULL,
  PRIMARY KEY (`ItemID`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `items`
--

LOCK TABLES `items` WRITE;
/*!40000 ALTER TABLE `items` DISABLE KEYS */;
INSERT INTO `items` VALUES (1,'weapons/sword_common',10,'weapon','warrior',5,1,1,0,'zwykły miecz'),(2,'weapons/sword_uncommon',25,'weapon','warrior',8,2,2,0,'niezwykły miecz'),(3,'weapons/sword_rare',100,'weapon','warrior',12,4,3,0,'rzadki miecz'),(4,'weapons/bow_common',10,'weapon','ranger',6,0,1,0,'zwykły łuk'),(5,'weapons/bow_uncommon',25,'weapon','ranger',10,1,1,0,'niezwykły łuk'),(6,'weapons/bow_rare',100,'weapon','ranger',15,2,2,0,'rzadki łuk'),(7,'weapons/staff_common',10,'weapon','mage',7,0,0,0,'zwykła różdżka'),(8,'weapons/staff_uncommon',25,'weapon','mage',12,0,1,0,'niezwykła różdżka'),(9,'weapons/staff_rare',100,'weapon','mage',20,0,2,0,'rzadka różdżka');
/*!40000 ALTER TABLE `items` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `users`
--

DROP TABLE IF EXISTS `users`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `users` (
  `Email` varchar(25) NOT NULL,
  `Password` varchar(20) NOT NULL,
  `Username` varchar(25) NOT NULL,
  `PlayerOrAdmin` tinyint(1) NOT NULL,
  PRIMARY KEY (`Email`),
  UNIQUE KEY `Username` (`Username`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `users`
--

LOCK TABLES `users` WRITE;
/*!40000 ALTER TABLE `users` DISABLE KEYS */;
INSERT INTO `users` VALUES ('damian@knopek.pl','haslodamiana','damian',0),('dybtym@gmail.com','123456','Dybson2',0),('kuba@miarka.pl','haslokuby','kuba',0),('tymdyb@gmail.com','123456','Dybson',0),('tymek@dybal.pl','haslotymka','tymek',0);
/*!40000 ALTER TABLE `users` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2024-06-21 13:25:07
