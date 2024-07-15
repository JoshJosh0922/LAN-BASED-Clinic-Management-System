-- phpMyAdmin SQL Dump
-- version 5.1.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Apr 05, 2023 at 08:19 AM
-- Server version: 10.4.18-MariaDB
-- PHP Version: 8.0.3

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `inventory`
--

-- --------------------------------------------------------

--
-- Table structure for table `archivebatch`
--

CREATE TABLE `archivebatch` (
  `id` int(12) NOT NULL DEFAULT 0,
  `code` varchar(50) NOT NULL,
  `name` varchar(50) NOT NULL,
  `description` text NOT NULL,
  `date_received` date DEFAULT NULL,
  `expiry_date` date DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `archivebatch`
--

INSERT INTO `archivebatch` (`id`, `code`, `name`, `description`, `date_received`, `expiry_date`) VALUES
(4, 'fds', 'fdsf', 'fds', '2023-03-31', '2023-03-25'),
(2, 'BA102', 'Batch February 2023', 'None', '2023-02-08', '2025-02-08');

-- --------------------------------------------------------

--
-- Table structure for table `archiveproductstocks`
--

CREATE TABLE `archiveproductstocks` (
  `id` int(12) NOT NULL,
  `code` varchar(50) NOT NULL,
  `consumed` int(12) NOT NULL,
  `stocks` int(12) NOT NULL,
  `batch` varchar(50) NOT NULL,
  `date_received` date NOT NULL,
  `expiry_date` date DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `archiveproductstocks`
--

INSERT INTO `archiveproductstocks` (`id`, `code`, `consumed`, `stocks`, `batch`, `date_received`, `expiry_date`) VALUES
(52, 'fd', 0, 1, 'Batch January 2023', '0000-00-00', '2023-04-05'),
(54, 'cxzc', 0, 1, 'Batch January 2023', '0000-00-00', '2023-04-05'),
(55, 'gfdg', 0, 1, 'Batch January 2023', '0000-00-00', '2023-04-05'),
(56, 'fd', 0, 1, 'Batch January 2023', '0000-00-00', '2023-04-05'),
(57, 'ffr', 0, 1, 'Batch January 2023', '0000-00-00', '2023-04-05'),
(58, 'gfddf', 0, 1, 'Batch January 2023', '0000-00-00', '2023-04-05'),
(59, 'dssss', 0, 1, 'Batch January 2023', '0000-00-00', '2023-04-05'),
(60, 'sawakas', 0, 1, 'Batch January 2023', '0000-00-00', '2023-04-05'),
(61, 'frfdf', 0, 1, 'Batch January 2023', '0000-00-00', '2023-04-05'),
(62, '1', 0, 1, 'Batch January 2023', '0000-00-00', '2023-04-05'),
(63, '13', 0, 1, 'Batch January 2023', '0000-00-00', '2023-04-05');

-- --------------------------------------------------------

--
-- Table structure for table `archiveuniqueproductlist`
--

CREATE TABLE `archiveuniqueproductlist` (
  `id` int(12) NOT NULL,
  `code` varchar(50) NOT NULL,
  `name` varchar(50) NOT NULL,
  `unit` varchar(50) NOT NULL,
  `category` varchar(100) NOT NULL,
  `description` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `archiveuniqueproductlist`
--

INSERT INTO `archiveuniqueproductlist` (`id`, `code`, `name`, `unit`, `category`, `description`) VALUES
(2, 'HK59299', 'Acetaminophen', '200 mg', 'Medication', 'None'),
(39, '1', '12', '', 'Medication', ''),
(40, '13', '1', '', 'Medication', '');

-- --------------------------------------------------------

--
-- Table structure for table `batch`
--

CREATE TABLE `batch` (
  `id` int(12) NOT NULL,
  `code` varchar(50) NOT NULL,
  `name` varchar(50) NOT NULL,
  `description` text NOT NULL,
  `date_received` date DEFAULT NULL,
  `expiry_date` date DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `batch`
--

INSERT INTO `batch` (`id`, `code`, `name`, `description`, `date_received`, `expiry_date`) VALUES
(1, 'BA101', 'Batch January 2023', 'None', '2023-01-11', '2023-03-25'),
(3, 'BA103', 'Batch March 2023', 'None', '2023-03-09', '2028-03-11');

-- --------------------------------------------------------

--
-- Table structure for table `category`
--

CREATE TABLE `category` (
  `id` int(11) NOT NULL,
  `name` varchar(20) NOT NULL,
  `description` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `category`
--

INSERT INTO `category` (`id`, `name`, `description`) VALUES
(1, 'Medication', 'None'),
(2, 'Cream', 'None');

-- --------------------------------------------------------

--
-- Table structure for table `productstocks`
--

CREATE TABLE `productstocks` (
  `id` int(12) NOT NULL,
  `code` varchar(50) NOT NULL,
  `consumed` int(12) NOT NULL,
  `stocks` int(12) NOT NULL,
  `batch` varchar(50) NOT NULL,
  `date_received` date NOT NULL,
  `expiry_date` date DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `uniqueproductlist`
--

CREATE TABLE `uniqueproductlist` (
  `id` int(12) NOT NULL,
  `code` varchar(50) NOT NULL,
  `name` varchar(50) NOT NULL,
  `unit` varchar(50) NOT NULL,
  `category` varchar(100) NOT NULL,
  `description` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `unit`
--

CREATE TABLE `unit` (
  `id` int(11) NOT NULL,
  `unit_name` varchar(50) NOT NULL,
  `unit` varchar(12) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `unit`
--

INSERT INTO `unit` (`id`, `unit_name`, `unit`) VALUES
(1, 'Milligram', 'mg'),
(2, 'Milliliter', 'ml');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `archiveproductstocks`
--
ALTER TABLE `archiveproductstocks`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `archiveuniqueproductlist`
--
ALTER TABLE `archiveuniqueproductlist`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `code` (`code`);

--
-- Indexes for table `batch`
--
ALTER TABLE `batch`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `category`
--
ALTER TABLE `category`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `productstocks`
--
ALTER TABLE `productstocks`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `uniqueproductlist`
--
ALTER TABLE `uniqueproductlist`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `code` (`code`);

--
-- Indexes for table `unit`
--
ALTER TABLE `unit`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `archiveproductstocks`
--
ALTER TABLE `archiveproductstocks`
  MODIFY `id` int(12) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=64;

--
-- AUTO_INCREMENT for table `archiveuniqueproductlist`
--
ALTER TABLE `archiveuniqueproductlist`
  MODIFY `id` int(12) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=41;

--
-- AUTO_INCREMENT for table `batch`
--
ALTER TABLE `batch`
  MODIFY `id` int(12) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT for table `category`
--
ALTER TABLE `category`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT for table `productstocks`
--
ALTER TABLE `productstocks`
  MODIFY `id` int(12) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=64;

--
-- AUTO_INCREMENT for table `uniqueproductlist`
--
ALTER TABLE `uniqueproductlist`
  MODIFY `id` int(12) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=41;

--
-- AUTO_INCREMENT for table `unit`
--
ALTER TABLE `unit`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
