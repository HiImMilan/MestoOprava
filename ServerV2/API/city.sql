-- phpMyAdmin SQL Dump
-- version 5.0.3
-- https://www.phpmyadmin.net/
--
-- Hostiteľ: 127.0.0.1
-- Čas generovania: Št 27.Máj 2021, 19:27
-- Verzia serveru: 10.4.14-MariaDB
-- Verzia PHP: 7.2.34

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
  `title` varchar(50) NOT NULL,
  `latitude` decimal(10,8) NOT NULL,
  `longitude` decimal(10,8) NOT NULL,
  `city` text NOT NULL,
  `description` varchar(120) NOT NULL,
  `adress` text NOT NULL,
  `rating` int(20) NOT NULL,
  `imageURL` varchar(120) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Sťahujem dáta pre tabuľku `problems`
--

INSERT INTO `problems` (`creationID`, `creatorUUID`, `title`, `latitude`, `longitude`, `city`, `description`, `adress`, `rating`, `imageURL`) VALUES
(9, '{aaaaa-aaa-a-aa-a-a-}', 'ヤロスラフ', '14.69000000', '18.42040000', '', 'ヤロスラフ', 'U jara doma', 0, 'a'),
(10, '{aaaaa-aaa-a-aa-a-a-}', 'ヤロスラフ', '14.69000000', '18.42040000', '', 'ヤロスラフ', 'U jara doma', 0, 'a'),
(11, '{aaaaa-aaa-a-aa-a-a-}', 'ヤロスラフ', '14.69000000', '18.42040000', '', 'ヤロスラフ', 'U jara doma', 0, 'a'),
(12, '{aaaaa-aaa-a-aa-a-a-}', 'ヤロスラフ', '14.69000000', '18.42040000', '', 'ヤロスラフ', 'U jara doma', 0, 'a'),
(13, '{aaaaa-aaa-a-aa-a-a-}', 'ヤロスラフ', '49.00000000', '18.00000000', '', 'ヤロスラフ', 'U jara doma', 0, 'a');

-- --------------------------------------------------------

--
-- Štruktúra tabuľky pre tabuľku `users`
--

CREATE TABLE `users` (
  `UUID` varchar(60) NOT NULL,
  `ProfilePic` varchar(60) NOT NULL,
  `BIO` text NOT NULL,
  `Reputation` int(20) NOT NULL,
  `Name` text NOT NULL,
  `LoginToken` text NOT NULL,
  `email` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Sťahujem dáta pre tabuľku `users`
--

INSERT INTO `users` (`UUID`, `ProfilePic`, `BIO`, `Reputation`, `Name`, `LoginToken`, `email`) VALUES
('aaa', '', '', 0, '', 'so4md2d27coeiyepjgvxwddqelimty5p272wprp7owtypowafvl2dsf7', '');

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
  MODIFY `creationID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=43;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
