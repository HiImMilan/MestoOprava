-- phpMyAdmin SQL Dump
-- version 5.0.4
-- https://www.phpmyadmin.net/
--
-- Hostiteľ: 127.0.0.1
-- Čas generovania: Út 09.Feb 2021, 21:42
-- Verzia serveru: 10.4.17-MariaDB
-- Verzia PHP: 8.0.0

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Databáza: `city`
--

-- --------------------------------------------------------

--
-- Štruktúra tabuľky pre tabuľku `bannedip`
--

CREATE TABLE `bannedip` (
  `ip` varchar(24) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Štruktúra tabuľky pre tabuľku `banneduuid`
--

CREATE TABLE `banneduuid` (
  `UUID` varchar(80) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Štruktúra tabuľky pre tabuľku `problems`
--

CREATE TABLE `problems` (
  `creationID` int(11) NOT NULL,
  `creatorUUID` varchar(80) NOT NULL,
  `name` varchar(50) NOT NULL,
  `latitude` decimal(10,8) NOT NULL,
  `longitude` decimal(10,8) NOT NULL,
  `descript` varchar(120) NOT NULL,
  `imageURL` varchar(120) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Štruktúra tabuľky pre tabuľku `users`
--

CREATE TABLE `users` (
  `UUID` varchar(60) NOT NULL,
  `ProfilePic` varchar(60) NOT NULL,
  `BIO` varchar(180) NOT NULL,
  `Reputation` int(20) NOT NULL,
  `Posts` int(30) NOT NULL,
  `Name` varchar(60) NOT NULL,
  `LastActivity` varchar(20) NOT NULL,
  `OTPtoken` varchar(80) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Kľúče pre exportované tabuľky
--

--
-- Indexy pre tabuľku `problems`
--
ALTER TABLE `problems`
  ADD PRIMARY KEY (`creationID`);

--
-- Indexy pre tabuľku `users`
--
ALTER TABLE `users`
  ADD UNIQUE KEY `UUID` (`UUID`);

--
-- AUTO_INCREMENT pre exportované tabuľky
--

--
-- AUTO_INCREMENT pre tabuľku `problems`
--
ALTER TABLE `problems`
  MODIFY `creationID` int(11) NOT NULL AUTO_INCREMENT;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
