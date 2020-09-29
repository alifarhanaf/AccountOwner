-- phpMyAdmin SQL Dump
-- version 4.9.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Sep 29, 2020 at 02:10 PM
-- Server version: 10.4.8-MariaDB
-- PHP Version: 7.3.11

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `accountowner`
--

-- --------------------------------------------------------

--
-- Table structure for table `account`
--

CREATE TABLE `account` (
  `AccountId` char(36) NOT NULL,
  `DateCreated` date NOT NULL,
  `AccountType` varchar(45) NOT NULL,
  `OwnerId` char(36) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `account`
--

INSERT INTO `account` (`AccountId`, `DateCreated`, `AccountType`, `OwnerId`) VALUES
('03e91478-5608-4132-a753-d494dafce00b', '2003-12-15', 'Domestic', 'f98e4d74-0f68-4aac-89fd-047f1aaca6b6'),
('356a5a9b-64bf-4de0-bc84-5395a1fdc9c4', '1996-02-15', 'Domestic', '261e1685-cf26-494c-b17c-3546e65f5620'),
('371b93f2-f8c5-4a32-894a-fc672741aa5b', '1999-05-04', 'Domestic', '24fd81f8-d58a-4bcc-9f35-dc6cd5641906'),
('670775db-ecc0-4b90-a9ab-37cd0d8e2801', '1999-12-21', 'Savings', '24fd81f8-d58a-4bcc-9f35-dc6cd5641906'),
('a3fbad0b-7f48-4feb-8ac0-6d3bbc997bfc', '2010-05-28', 'Domestic', 'a3c1880c-674c-4d18-8f91-5d3608a2c937'),
('aa15f658-04bb-4f73-82af-82db49d0fbef', '1999-05-12', 'Foreign', '24fd81f8-d58a-4bcc-9f35-dc6cd5641906'),
('c6066eb0-53ca-43e1-97aa-3c2169eec659', '1996-02-16', 'Foreign', '261e1685-cf26-494c-b17c-3546e65f5620'),
('eccadf79-85fe-402f-893c-32d3f03ed9b1', '2010-06-20', 'Foreign', 'a3c1880c-674c-4d18-8f91-5d3608a2c937');

-- --------------------------------------------------------

--
-- Table structure for table `owner`
--

CREATE TABLE `owner` (
  `OwnerId` char(36) NOT NULL,
  `Name` varchar(60) NOT NULL,
  `DateOfBirth` date NOT NULL,
  `Address` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `owner`
--

INSERT INTO `owner` (`OwnerId`, `Name`, `DateOfBirth`, `Address`) VALUES
('08d863c2-c167-4f05-8c15-cd0f1231c6fd', 'Johnson Sunny', '2020-10-08', 'Street 8 Canrnia'),
('24fd81f8-d58a-4bcc-9f35-dc6cd5641906', 'John Keen', '1980-12-05', '61 Wellfield Road'),
('261e1685-cf26-494c-b17c-3546e65f5620', 'Anna Bosh', '1974-11-14', '27 Colored Row'),
('66774006-2371-4d5b-8518-2177bcf3f73e', 'Nick Somion', '1998-12-15', 'North sunny address 102'),
('a3c1880c-674c-4d18-8f91-5d3608a2c937', 'Sam Query', '1990-04-22', '91 Western Roads'),
('f98e4d74-0f68-4aac-89fd-047f1aaca6b6', 'Martin Miller', '1983-05-21', '3 Edgar Buildings');

-- --------------------------------------------------------

--
-- Table structure for table `property`
--

CREATE TABLE `property` (
  `PropertyId` char(36) NOT NULL,
  `Name` text NOT NULL,
  `Location` text NOT NULL,
  `Contact` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `property`
--

INSERT INTO `property` (`PropertyId`, `Name`, `Location`, `Contact`) VALUES
('24fd81f8-d58a-4bcc-9f35-dc6cd5641906', 'Infinity Heights', 'Allama Iqbal Town', '03047689054'),
('261e1685-cf26-494c-b17c-3546e65f5620', 'AlGhani Heights', 'Main Market Gulberg', '045-980967908');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `account`
--
ALTER TABLE `account`
  ADD PRIMARY KEY (`AccountId`),
  ADD KEY `fk_Account_Owner_idx` (`OwnerId`);

--
-- Indexes for table `owner`
--
ALTER TABLE `owner`
  ADD PRIMARY KEY (`OwnerId`);

--
-- Indexes for table `property`
--
ALTER TABLE `property`
  ADD PRIMARY KEY (`PropertyId`);

--
-- Constraints for dumped tables
--

--
-- Constraints for table `account`
--
ALTER TABLE `account`
  ADD CONSTRAINT `fk_Account_Owner` FOREIGN KEY (`OwnerId`) REFERENCES `owner` (`OwnerId`) ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
