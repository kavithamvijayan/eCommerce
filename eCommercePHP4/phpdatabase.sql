-- phpMyAdmin SQL Dump
-- version 4.9.0.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Dec 04, 2019 at 09:35 PM
-- Server version: 10.3.15-MariaDB
-- PHP Version: 7.3.6

SET SQL_MODE
= "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT
= 0;
START TRANSACTION;
SET time_zone
= "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `phpdatabase`
--

-- --------------------------------------------------------

--
-- Table structure for table `reviews`
--

CREATE TABLE `reviews`
(
  `Id` int
(11) NOT NULL,
  `userId` int
(11) NOT NULL,
  `itemId` int
(11) NOT NULL,
  `commentTitle` text NOT NULL,
  `commentBody` text NOT NULL,
  `rating` decimal
(10,0) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `reviews`
--

INSERT INTO `reviews` (`
Id`,
`userId
`, `itemId`, `commentTitle`, `commentBody`, `rating`) VALUES
(1, 3, 2, 'my title 1', 'comment body 1', '5');

-- --------------------------------------------------------

--
-- Table structure for table `gifts`
--

CREATE TABLE `gifts`
(
  `Id` int
(11) NOT NULL,
  `name` varchar
(100) NOT NULL,
  `price` float NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `gifts`
--

INSERT INTO `gifts` (`
Id`,
`name
`, `price`) VALUES
(1, 'Prada', 200),
(2, 'Nike', 500);

-- --------------------------------------------------------

--
-- Table structure for table `purchasegifts`
--

CREATE TABLE `purchasegifts`
(
  `Id` int
(11) NOT NULL,
  `quantity` int
(11) NOT NULL,
  `orderId` int
(11) NOT NULL,
  `itemId` int
(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `purchase`
--

CREATE TABLE `purchase`
(
  `grandTotal` float NOT NULL DEFAULT 0,
  `Id` int
(11) NOT NULL,
  `userId` int
(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `customers`
--

CREATE TABLE `customers`
(
  `Id` int
(11) NOT NULL,
  `email` varchar
(100) NOT NULL,
  `firstName` text DEFAULT NULL,
  `lastName` text DEFAULT NULL,
  `password` varchar
(300) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `customers`
--

INSERT INTO `customers` (`
Id`,
`email
`, `firstName`, `lastName`, `password`) VALUES
(3, 'r@k.com', NULL, NULL, '$2y$10$DnuaafPUJeLDGYkqSGM43OogNLOVTY5Knm1FIR/A50roAMJjghBkG');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `reviews`
--
ALTER TABLE `reviews`
ADD PRIMARY KEY
(`Id`),
ADD KEY `itemId`
(`itemId`),
ADD KEY `userId`
(`userId`);

--
-- Indexes for table `gifts`
--
ALTER TABLE `gifts`
ADD PRIMARY KEY
(`Id`);

--
-- Indexes for table `purchasegifts`
--
ALTER TABLE `purchasegifts`
ADD PRIMARY KEY
(`Id`),
ADD KEY `itemId`
(`itemId`),
ADD KEY `orderId`
(`orderId`);

--
-- Indexes for table `purchase`
--
ALTER TABLE `purchase`
ADD PRIMARY KEY
(`Id`),
ADD KEY `userId`
(`userId`);

--
-- Indexes for table `customers`
--
ALTER TABLE `customers`
ADD PRIMARY KEY
(`Id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `reviews`
--
ALTER TABLE `reviews`
  MODIFY `Id` int
(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT for table `gifts`
--
ALTER TABLE `gifts`
  MODIFY `Id` int
(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT for table `purchasegifts`
--
ALTER TABLE `purchasegifts`
  MODIFY `Id` int
(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `purchase`
--
ALTER TABLE `purchase`
  MODIFY `Id` int
(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `customers`
--
ALTER TABLE `customers`
  MODIFY `Id` int
(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `reviews`
--
ALTER TABLE `reviews`
ADD CONSTRAINT `reviews_ibfk_1` FOREIGN KEY
(`itemId`) REFERENCES `gifts`
(`Id`),
ADD CONSTRAINT `reviews_ibfk_2` FOREIGN KEY
(`userId`) REFERENCES `customers`
(`Id`);

--
-- Constraints for table `purchasegifts`
--
ALTER TABLE `purchasegifts`
ADD CONSTRAINT `purchasegifts_ibfk_1` FOREIGN KEY
(`itemId`) REFERENCES `gifts`
(`Id`),
ADD CONSTRAINT `purchasegifts_ibfk_2` FOREIGN KEY
(`orderId`) REFERENCES `purchase`
(`Id`);

--
-- Constraints for table `purchase`
--
ALTER TABLE `purchase`
ADD CONSTRAINT `purchase_ibfk_1` FOREIGN KEY
(`userId`) REFERENCES `customers`
(`Id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
