-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Хост: 127.0.0.1
-- Время создания: Июн 20 2025 г., 20:20
-- Версия сервера: 10.4.32-MariaDB
-- Версия PHP: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- База данных: `shop`
--

-- --------------------------------------------------------

--
-- Структура таблицы `clients`
--

CREATE TABLE `clients` (
  `Id` int(11) NOT NULL,
  `Name` longtext NOT NULL,
  `Phone` longtext NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Дамп данных таблицы `clients`
--

INSERT INTO `clients` (`Id`, `Name`, `Phone`) VALUES
(1, 'Ivan Petrov', '0503566423'),
(2, 'Maria Ivanova', '0671234567'),
(3, 'Oleg Sidorov', '0951234567'),
(4, 'Ivan Ivanov', '0661336447'),
(5, 'Ivan Petrov', '0503566423'),
(6, 'Maria Ivanova', '0671234567'),
(7, 'Oleg Sidorov', '0951234567'),
(8, 'Ivan Ivanov', '0661336446');

-- --------------------------------------------------------

--
-- Структура таблицы `orderdetails`
--

CREATE TABLE `orderdetails` (
  `Id` int(11) NOT NULL,
  `OrderId` int(11) NOT NULL,
  `ProductId` int(11) NOT NULL,
  `Quanity` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Дамп данных таблицы `orderdetails`
--

INSERT INTO `orderdetails` (`Id`, `OrderId`, `ProductId`, `Quanity`) VALUES
(1, 1, 1, 1),
(2, 1, 4, 2),
(3, 2, 2, 1),
(4, 3, 3, 1),
(5, 3, 5, 3),
(6, 4, 2, 1);

-- --------------------------------------------------------

--
-- Структура таблицы `orders`
--

CREATE TABLE `orders` (
  `Id` int(11) NOT NULL,
  `ClientId` int(11) NOT NULL,
  `OrderDate` datetime(6) NOT NULL,
  `Status` longtext NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Дамп данных таблицы `orders`
--

INSERT INTO `orders` (`Id`, `ClientId`, `OrderDate`, `Status`) VALUES
(1, 1, '2025-03-01 00:00:00.000000', 'Pending'),
(2, 2, '2025-03-02 00:00:00.000000', 'Shipped'),
(3, 3, '2025-03-03 00:00:00.000000', 'Delivered'),
(4, 1, '2025-03-04 00:00:00.000000', 'Delivered'),
(5, 2, '2025-03-05 00:00:00.000000', 'Shipped'),
(6, 1, '2025-03-01 00:00:00.000000', 'Pending'),
(7, 2, '2025-03-02 00:00:00.000000', 'Shipped'),
(8, 1, '2025-03-03 00:00:00.000000', 'Delivered'),
(9, 1, '2025-03-04 00:00:00.000000', 'Delivered'),
(10, 2, '2025-03-05 00:00:00.000000', 'Shipped'),
(11, 1, '2025-03-04 00:00:00.000000', 'Delivered');

-- --------------------------------------------------------

--
-- Структура таблицы `payments`
--

CREATE TABLE `payments` (
  `Id` int(11) NOT NULL,
  `Amount` double NOT NULL,
  `PaymentMethod` longtext NOT NULL,
  `Date` datetime(6) NOT NULL,
  `OrderId` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Дамп данных таблицы `payments`
--

INSERT INTO `payments` (`Id`, `Amount`, `PaymentMethod`, `Date`, `OrderId`) VALUES
(1, 16200, 'Credit Card', '2025-01-01 00:00:00.000000', 1),
(2, 8000, 'PayPal', '2023-12-02 00:00:00.000000', 2),
(3, 8800, 'Bank Transfer', '2024-03-03 00:00:00.000000', 3),
(4, 5000, 'Debit Card', '2025-03-04 00:00:00.000000', 1),
(5, 12000, 'Cryptocurrency', '2025-03-05 00:00:00.000000', 2),
(6, 4500, 'Cash', '2025-06-20 00:00:00.000000', 3),
(7, 7000, 'Bank Transfer', '2023-02-07 00:00:00.000000', 3);

-- --------------------------------------------------------

--
-- Структура таблицы `products`
--

CREATE TABLE `products` (
  `Id` int(11) NOT NULL,
  `Name` longtext NOT NULL,
  `Price` double NOT NULL,
  `Category` longtext NOT NULL,
  `InStock` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Дамп данных таблицы `products`
--

INSERT INTO `products` (`Id`, `Name`, `Price`, `Category`, `InStock`) VALUES
(1, 'Laptop', 15000, 'Electronics', 10),
(2, 'Smartphone', 8000, 'Electronics', 15),
(3, 'Tablet', 7000, 'Electronics', 5),
(4, 'Headphones', 1200, 'Accessories', 20),
(5, 'Mouse', 600, 'Accessories', 4),
(6, 'Laptop', 15000, 'Electronics', 10),
(7, 'Smartphone', 18000, 'Electronics', 15),
(8, 'Tablet', 7000, 'Electronics', 5),
(9, 'Headphones', 1200, 'Accessories', 20),
(10, 'Mouse', 600, 'Accessories', 30);

-- --------------------------------------------------------

--
-- Структура таблицы `__efmigrationshistory`
--

CREATE TABLE `__efmigrationshistory` (
  `MigrationId` varchar(150) NOT NULL,
  `ProductVersion` varchar(32) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Дамп данных таблицы `__efmigrationshistory`
--

INSERT INTO `__efmigrationshistory` (`MigrationId`, `ProductVersion`) VALUES
('20250609162535_firstlyHere', '7.0.20'),
('20250609165809_HelloStudent', '7.0.20'),
('20250611154232_HelloWorld', '7.0.20'),
('20250611161953_addStatus', '7.0.20'),
('20250616151706_UpdateToStudents', '7.0.20'),
('20250616151821_UpdateToStudent', '7.0.20'),
('20250618153828_StartExam', '7.0.20');

--
-- Индексы сохранённых таблиц
--

--
-- Индексы таблицы `clients`
--
ALTER TABLE `clients`
  ADD PRIMARY KEY (`Id`);

--
-- Индексы таблицы `orderdetails`
--
ALTER TABLE `orderdetails`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IX_OrderDetails_OrderId` (`OrderId`),
  ADD KEY `IX_OrderDetails_ProductId` (`ProductId`);

--
-- Индексы таблицы `orders`
--
ALTER TABLE `orders`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IX_Orders_ClientId` (`ClientId`);

--
-- Индексы таблицы `payments`
--
ALTER TABLE `payments`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IX_Payments_OrderId` (`OrderId`);

--
-- Индексы таблицы `products`
--
ALTER TABLE `products`
  ADD PRIMARY KEY (`Id`);

--
-- Индексы таблицы `__efmigrationshistory`
--
ALTER TABLE `__efmigrationshistory`
  ADD PRIMARY KEY (`MigrationId`);

--
-- AUTO_INCREMENT для сохранённых таблиц
--

--
-- AUTO_INCREMENT для таблицы `clients`
--
ALTER TABLE `clients`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;

--
-- AUTO_INCREMENT для таблицы `orderdetails`
--
ALTER TABLE `orderdetails`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- AUTO_INCREMENT для таблицы `orders`
--
ALTER TABLE `orders`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=12;

--
-- AUTO_INCREMENT для таблицы `payments`
--
ALTER TABLE `payments`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- AUTO_INCREMENT для таблицы `products`
--
ALTER TABLE `products`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- Ограничения внешнего ключа сохраненных таблиц
--

--
-- Ограничения внешнего ключа таблицы `orderdetails`
--
ALTER TABLE `orderdetails`
  ADD CONSTRAINT `FK_OrderDetails_Orders_OrderId` FOREIGN KEY (`OrderId`) REFERENCES `orders` (`Id`) ON DELETE CASCADE,
  ADD CONSTRAINT `FK_OrderDetails_Products_ProductId` FOREIGN KEY (`ProductId`) REFERENCES `products` (`Id`) ON DELETE CASCADE;

--
-- Ограничения внешнего ключа таблицы `orders`
--
ALTER TABLE `orders`
  ADD CONSTRAINT `FK_Orders_Clients_ClientId` FOREIGN KEY (`ClientId`) REFERENCES `clients` (`Id`) ON DELETE CASCADE;

--
-- Ограничения внешнего ключа таблицы `payments`
--
ALTER TABLE `payments`
  ADD CONSTRAINT `FK_Payments_Orders_OrderId` FOREIGN KEY (`OrderId`) REFERENCES `orders` (`Id`) ON DELETE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
