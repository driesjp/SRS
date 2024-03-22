-- --------------------------------------------------------
-- Host:                         127.0.0.1
-- Server version:               8.3.0 - MySQL Community Server - GPL
-- Server OS:                    Linux
-- HeidiSQL Version:             12.6.0.6765
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

-- Dumping data for table SRS_DB.flashcards: ~10 rows (approximately)
INSERT INTO `flashcards` (`ID`, `question`, `answer`, `weight`, `EF`, `next_review`) VALUES
	(1, 'What is a group of ducks called on the ground?', 'A flock.', 0, 2.5, NULL),
	(2, 'What do ducks eat?', 'Ducks are omnivores; they eat a variety of food such as plants, insects, and small fish.', 0, 2.5, NULL),
	(3, 'How can you tell the difference between a male and female duck?', 'Male ducks (drakes) often have brighter plumage and may have colorful patterns, while female ducks (hens) usually have more subdued colors for camouflage.', 0, 2.5, NULL),
	(4, 'Why do ducks have webbed feet?', 'Webbed feet act as paddles, making ducks efficient swimmers.', 0, 2.5, NULL),
	(5, 'Can ducks fly, and if so, how fast?', 'Yes, ducks can fly. Some species can reach speeds up to 70 mph (113 km/h) during flight.', 0, 2.5, NULL),
	(6, 'What is unique about a duck\'s feathers?', 'Duck feathers are waterproof. This is due to a special gland called the uropygial gland near their tails, which produces oil that ducks spread over their feathers to repel water.', 0, 2.5, NULL),
	(7, 'How do ducks communicate?', 'Ducks communicate through a variety of sounds such as quacks, whistles, and grunts, each with different meanings.', 0, 2.5, NULL),
	(8, 'Where do ducks live?', 'Ducks are found in a wide range of habitats including freshwater lakes, rivers, marshes, and coastal waters. They are adaptable to various environments around the world.', 0, 2.5, NULL),
	(9, 'What is the migration pattern of ducks?', 'Many duck species migrate seasonally, traveling to warmer regions during the winter and returning to their breeding grounds in the spring.', 0, 2.5, NULL),
	(10, 'How long do ducks live?', 'The lifespan of ducks varies by species, but on average, wild ducks live from 5 to 10 years, while domesticated ducks can live longer with proper care.', 0, 2.5, NULL);

/*!40103 SET TIME_ZONE=IFNULL(@OLD_TIME_ZONE, 'system') */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
