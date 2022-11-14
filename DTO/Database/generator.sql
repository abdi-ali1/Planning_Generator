-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Nov 14, 2022 at 12:30 PM
-- Server version: 10.4.24-MariaDB
-- PHP Version: 8.1.6

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `generator`
--

-- --------------------------------------------------------

--
-- Table structure for table `availibiltystaff_tb`
--

CREATE TABLE `availibiltystaff_tb` (
  `id` int(11) NOT NULL,
  `company_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `company`
--

CREATE TABLE `company` (
  `id` int(11) NOT NULL,
  `name` varchar(50) NOT NULL,
  `addedTime` datetime NOT NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `companyschedule_tb`
--

CREATE TABLE `companyschedule_tb` (
  `id` int(11) NOT NULL,
  `neededWeek` datetime NOT NULL,
  `company_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `degree`
--

CREATE TABLE `degree` (
  `id` int(11) NOT NULL,
  `nameOfDegree` varchar(50) NOT NULL,
  `degreeLevel` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `needed_staff`
--

CREATE TABLE `needed_staff` (
  `id` int(11) NOT NULL,
  `occupation` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `shift`
--

CREATE TABLE `shift` (
  `id` int(11) NOT NULL,
  `dayOfWeek` varchar(50) NOT NULL,
  `kindOfShift` varchar(50) NOT NULL,
  `staffschedule_id` int(11) DEFAULT NULL,
  `availibiltystaff_id` int(11) DEFAULT NULL,
  `companyschedule_id` int(11) DEFAULT NULL,
  `weeklyneed_id` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `staffmember`
--

CREATE TABLE `staffmember` (
  `id` int(11) NOT NULL,
  `name` varchar(50) NOT NULL,
  `gender` varchar(50) NOT NULL,
  `companyrole` varchar(50) NOT NULL,
  `occupation` varchar(50) NOT NULL,
  `age` int(11) NOT NULL,
  `username` varchar(50) NOT NULL,
  `degree_id` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `staffschedule`
--

CREATE TABLE `staffschedule` (
  `id` int(11) NOT NULL,
  `neededWeek` datetime NOT NULL,
  `staffMember_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `weeklyneed`
--

CREATE TABLE `weeklyneed` (
  `id` int(11) NOT NULL,
  `neededWeek` datetime NOT NULL,
  `company_id` int(11) NOT NULL,
  `neededStaff_id` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `availibiltystaff_tb`
--
ALTER TABLE `availibiltystaff_tb`
  ADD PRIMARY KEY (`id`),
  ADD KEY `company_fk` (`company_id`);

--
-- Indexes for table `company`
--
ALTER TABLE `company`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `companyschedule_tb`
--
ALTER TABLE `companyschedule_tb`
  ADD PRIMARY KEY (`id`),
  ADD KEY `company_sh_fk` (`company_id`);

--
-- Indexes for table `degree`
--
ALTER TABLE `degree`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `needed_staff`
--
ALTER TABLE `needed_staff`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `shift`
--
ALTER TABLE `shift`
  ADD PRIMARY KEY (`id`),
  ADD KEY `availibility_sh_fk` (`availibiltystaff_id`),
  ADD KEY `company_she_fk` (`companyschedule_id`),
  ADD KEY `staff_she_fk` (`staffschedule_id`),
  ADD KEY `weeklyneed_fk` (`weeklyneed_id`);

--
-- Indexes for table `staffmember`
--
ALTER TABLE `staffmember`
  ADD PRIMARY KEY (`id`),
  ADD KEY `degree_fk` (`degree_id`) USING BTREE;

--
-- Indexes for table `staffschedule`
--
ALTER TABLE `staffschedule`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `weeklyneed`
--
ALTER TABLE `weeklyneed`
  ADD PRIMARY KEY (`id`),
  ADD KEY `company_wk_fk` (`company_id`),
  ADD KEY `neededstaff_wk_fk` (`neededStaff_id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `availibiltystaff_tb`
--
ALTER TABLE `availibiltystaff_tb`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `company`
--
ALTER TABLE `company`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `companyschedule_tb`
--
ALTER TABLE `companyschedule_tb`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `degree`
--
ALTER TABLE `degree`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `needed_staff`
--
ALTER TABLE `needed_staff`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `shift`
--
ALTER TABLE `shift`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `staffmember`
--
ALTER TABLE `staffmember`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT for table `staffschedule`
--
ALTER TABLE `staffschedule`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `weeklyneed`
--
ALTER TABLE `weeklyneed`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `availibiltystaff_tb`
--
ALTER TABLE `availibiltystaff_tb`
  ADD CONSTRAINT `company_fk` FOREIGN KEY (`company_id`) REFERENCES `company` (`id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `companyschedule_tb`
--
ALTER TABLE `companyschedule_tb`
  ADD CONSTRAINT `company_sh_fk` FOREIGN KEY (`company_id`) REFERENCES `company` (`id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `shift`
--
ALTER TABLE `shift`
  ADD CONSTRAINT `availibility_sh_fk` FOREIGN KEY (`availibiltystaff_id`) REFERENCES `availibiltystaff_tb` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `company_she_fk` FOREIGN KEY (`companyschedule_id`) REFERENCES `companyschedule_tb` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `staff_she_fk` FOREIGN KEY (`staffschedule_id`) REFERENCES `staffschedule` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `weeklyneed_fk` FOREIGN KEY (`weeklyneed_id`) REFERENCES `weeklyneed` (`id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `staffmember`
--
ALTER TABLE `staffmember`
  ADD CONSTRAINT `degree_fk` FOREIGN KEY (`degree_id`) REFERENCES `degree` (`id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `weeklyneed`
--
ALTER TABLE `weeklyneed`
  ADD CONSTRAINT `company_wk_fk` FOREIGN KEY (`company_id`) REFERENCES `company` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `neededstaff_wk_fk` FOREIGN KEY (`neededStaff_id`) REFERENCES `needed_staff` (`id`) ON DELETE CASCADE ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
