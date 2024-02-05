-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Feb 05, 2024 at 01:07 PM
-- Server version: 10.4.28-MariaDB
-- PHP Version: 8.2.4

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `sim`
--

DELIMITER $$
--
-- Procedures
--
CREATE DEFINER=`root`@`localhost` PROCEDURE `TotalCountOfTransactionsTillNow` ()   begin
	select count(`sim`.transactions.TransactionID) as Total from  `sim`.transactions;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `TotalCustomersTillNow` ()   begin
	select count(`sim`.customers.CustomerID) as Total from  `sim`.customers;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `TotalProductsTillNow` ()   begin
	select count(`sim`.products.ProductID) as Total from `sim`.products;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `TotalSumOfTransactions` ()   begin
select
	sum(TotalAmount) as Total
from
	`sim`.`transactions`;
END$$

DELIMITER ;

-- --------------------------------------------------------

--
-- Stand-in structure for view `billed_products`
-- (See below for the actual view)
--
CREATE TABLE `billed_products` (
`TransactionDate` datetime
,`TransactionID` int(11)
,`TransactionDetailID` int(11)
,`BillNumber` varchar(50)
,`ProductCode` varchar(255)
,`ProductName` varchar(255)
,`Quantity` decimal(10,3)
,`UnitOfMeasurement` varchar(50)
,`UnitPrice` decimal(10,2)
,`Subtotal` decimal(10,2)
);

-- --------------------------------------------------------

--
-- Table structure for table `bill_return_item`
--

CREATE TABLE `bill_return_item` (
  `ReturnID` bigint(20) NOT NULL,
  `BillNumber` varchar(50) NOT NULL,
  `TransactionDetailId` int(11) NOT NULL,
  `ReturnedQuantity` decimal(10,3) NOT NULL,
  `Unit` varchar(50) NOT NULL,
  `Reason` varchar(255) NOT NULL,
  `UserID` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_bin;

--
-- Dumping data for table `bill_return_item`
--

INSERT INTO `bill_return_item` (`ReturnID`, `BillNumber`, `TransactionDetailId`, `ReturnedQuantity`, `Unit`, `Reason`, `UserID`) VALUES
(1, '202312280101', 4, 1.000, 'jar', 'Damaged', 2),
(2, '202312280101', 4, 1.000, 'jar', 'Damaged', 2),
(3, '202312280101', 4, 1.000, 'jar', 'Damaged', 2),
(4, '202312280101', 4, 2.000, 'jar', 'Damaged', 2),
(7, '20240107140944', 15, 0.250, 'kg', 'Bad', 2);

-- --------------------------------------------------------

--
-- Stand-in structure for view `bill_transaction_payments`
-- (See below for the actual view)
--
CREATE TABLE `bill_transaction_payments` (
`TransactionDate` datetime
,`BillNumber` varchar(50)
,`CashierName` varchar(255)
,`CustomerName` varchar(255)
,`LoyaltyNumber` varchar(20)
,`BilledValue` decimal(11,2)
,`TotalDiscount` decimal(10,2)
,`TotalAmount` decimal(10,2)
,`PaidAmount` decimal(12,2)
,`Name` varchar(50)
,`Remark` varchar(255)
,`TotalPaidAmount` decimal(10,2)
,`TotalChange` decimal(10,2)
);

-- --------------------------------------------------------

--
-- Table structure for table `categories`
--

CREATE TABLE `categories` (
  `CategoryCode` varchar(3) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `CategoryName` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_bin;

--
-- Dumping data for table `categories`
--

INSERT INTO `categories` (`CategoryCode`, `CategoryName`) VALUES
('ALC', 'Alcohol'),
('BCC', 'Baby and Child Care'),
('BEV', 'Beverages'),
('BKY', 'Bakery'),
('CER', 'Cereal and Breakfast Foods'),
('CON', 'Condiments'),
('CPG', 'Canned and Packaged Goods'),
('CTP', 'Cigarettes and Tobacco Products'),
('DIR', 'Dairy'),
('ELC', 'Electronics'),
('FRT', 'Fruit'),
('FRZ', 'Frozen Foods'),
('HCL', 'Household Cleaning'),
('HKW', 'Home and Kitchenware'),
('HLW', 'Health and Wellness'),
('MAP', 'Meat and Poultry'),
('OSS', 'Office and School Supplies'),
('PER', 'Personal Care'),
('PET', 'Pet Supplies'),
('PRO', 'Other Produces'),
('SNK', 'Snacks'),
('STA', 'Stationary Items'),
('VEG', 'Vegetable');

-- --------------------------------------------------------

--
-- Stand-in structure for view `combined_billed_retuned_products`
-- (See below for the actual view)
--
CREATE TABLE `combined_billed_retuned_products` (
`BillNumber` varchar(50)
,`TransactionDetailID` int(11)
,`ProductCode` varchar(255)
,`ProductName` varchar(255)
,`BilledQuantity` decimal(10,3)
,`ReturnedQuantity` decimal(32,3)
,`Reason` mediumtext
,`UnitOfMeasurement` varchar(50)
);

-- --------------------------------------------------------

--
-- Table structure for table `customers`
--

CREATE TABLE `customers` (
  `CustomerID` int(11) NOT NULL,
  `UserID` int(11) DEFAULT NULL,
  `LoyaltyNumber` varchar(20) NOT NULL,
  `LoyaltyPoints` decimal(10,2) NOT NULL DEFAULT 0.00,
  `DateOfJoin` datetime NOT NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_bin;

--
-- Dumping data for table `customers`
--

INSERT INTO `customers` (`CustomerID`, `UserID`, `LoyaltyNumber`, `LoyaltyPoints`, `DateOfJoin`) VALUES
(1, 1, '0000000000', 0.00, '2023-01-01 00:00:00'),
(5, 8, '12345', 96.25, '2023-12-01 00:00:00'),
(7, 10, '1234', 9.70, '2023-12-22 00:00:00');

-- --------------------------------------------------------

--
-- Stand-in structure for view `customer_bills`
-- (See below for the actual view)
--
CREATE TABLE `customer_bills` (
`TransactionID` int(11)
,`UserID` int(11)
,`CustomerID` int(11)
,`CustomerUserID` int(11)
,`UserFullName` varchar(255)
,`CustomerFullName` varchar(255)
,`TransactionDate` datetime
,`TotalLineCount` bigint(21)
,`TotalAmount` decimal(10,2)
,`TotalDiscount` decimal(10,2)
,`TotalPaidAmount` decimal(10,2)
,`TotalChange` decimal(10,2)
,`BillNumber` varchar(50)
);

-- --------------------------------------------------------

--
-- Stand-in structure for view `customer_bill_summary`
-- (See below for the actual view)
--
CREATE TABLE `customer_bill_summary` (
`CustomerID` int(11)
,`FullName` varchar(255)
,`LastBillNumber` varchar(50)
,`LastBillDate` datetime
,`LastBillTotalAmount` decimal(10,2)
,`LastBillTotalDiscount` decimal(10,2)
,`LastBillTotalPaidAmount` decimal(10,2)
,`LastBillTotalChange` decimal(10,2)
,`CreditedLoyaltyPoints` decimal(10,2)
,`DebitedLoyaltyPoints` decimal(10,2)
,`BillCount` bigint(21)
,`TotalLoyaltyPointsCredit` decimal(32,2)
,`TotalLoyaltyPointsDebit` decimal(32,2)
,`LoyaltyPointsBalance` decimal(10,2)
);

-- --------------------------------------------------------

--
-- Stand-in structure for view `customer_details`
-- (See below for the actual view)
--
CREATE TABLE `customer_details` (
`UserID` int(11)
,`Username` varchar(255)
,`AccessLevel` varchar(50)
,`FullName` varchar(255)
,`State` varchar(100)
,`CustomerID` int(11)
,`LoyaltyNumber` varchar(20)
,`LoyaltyPoints` decimal(10,2)
,`DateOfJoin` datetime
);

-- --------------------------------------------------------

--
-- Table structure for table `loyaltypoints_transactions`
--

CREATE TABLE `loyaltypoints_transactions` (
  `TransactionID` bigint(20) NOT NULL,
  `BillNumber` text NOT NULL,
  `LoyaltyNumber` varchar(20) NOT NULL,
  `TransactionDate` timestamp NOT NULL DEFAULT current_timestamp(),
  `Amount` decimal(10,2) NOT NULL,
  `State` enum('Credit','Debit') NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_bin;

--
-- Dumping data for table `loyaltypoints_transactions`
--

INSERT INTO `loyaltypoints_transactions` (`TransactionID`, `BillNumber`, `LoyaltyNumber`, `TransactionDate`, `Amount`, `State`) VALUES
(1, '202312281243', '12345', '2023-12-28 07:13:39', 32.50, 'Credit'),
(2, '202401070251', '12345', '2024-01-06 21:21:04', 20.00, 'Credit'),
(3, '202401070302', '12345', '2024-01-06 21:32:52', 15.00, 'Credit'),
(4, '20240107140944', '12345', '2024-01-07 08:39:44', 50.00, 'Debit'),
(5, '20240107140944', '12345', '2024-01-07 08:39:45', 3.05, 'Credit'),
(6, '20240112213743', '12345', '2024-01-12 16:07:44', 16.20, 'Credit'),
(7, '20240113153010', '12345', '2024-01-13 10:00:10', 16.50, 'Credit'),
(8, '20240122033135', '1234', '2024-01-21 22:01:36', 9.70, 'Credit'),
(9, '20240202061331', '12345', '2024-02-02 00:43:31', 43.00, 'Credit');

--
-- Triggers `loyaltypoints_transactions`
--
DELIMITER $$
CREATE TRIGGER `update_loyalty_points` AFTER INSERT ON `loyaltypoints_transactions` FOR EACH ROW BEGIN
    DECLARE points_change DECIMAL(10,2);

    IF NEW.State = 'Credit' THEN
        SET points_change = NEW.Amount; -- Add points for Credit transactions
    ELSEIF NEW.State = 'Debit' THEN
        SET points_change = -NEW.Amount; -- Remove points for Debit transactions
    ELSE
        SET points_change = 0; -- No change for other states
    END IF;

    -- Update LoyaltyPoints in customers table
    UPDATE customers
    SET LoyaltyPoints = LoyaltyPoints + points_change
    WHERE LoyaltyNumber = NEW.LoyaltyNumber;
END
$$
DELIMITER ;

-- --------------------------------------------------------

--
-- Table structure for table `main_inventory`
--

CREATE TABLE `main_inventory` (
  `InventoryID` int(11) NOT NULL,
  `ProductID` int(11) NOT NULL,
  `Quantity` int(11) NOT NULL DEFAULT 0,
  `Location` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
  `Remark` varchar(255) DEFAULT 'Authorized Vendor'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_bin;

--
-- Dumping data for table `main_inventory`
--

INSERT INTO `main_inventory` (`InventoryID`, `ProductID`, `Quantity`, `Location`, `Remark`) VALUES
(1, 1, 40, 'Section A', 'Authorized Vendor'),
(8, 8, 50, 'Section B', 'Authorized Vendor'),
(11, 8, 50, 'Section C', 'Authorized Vendor');

-- --------------------------------------------------------

--
-- Stand-in structure for view `main_product_inventory`
-- (See below for the actual view)
--
CREATE TABLE `main_product_inventory` (
`InventoryID` int(11)
,`TransactionDate` datetime
,`ProductID` int(11)
,`ProductCode` varchar(255)
,`ProductName` varchar(255)
,`ExpiryDate` date
,`InventoryQuantity` int(11)
,`StockLocation` varchar(50)
,`Remark` varchar(2555)
,`TransactionID` int(11)
);

-- --------------------------------------------------------

--
-- Table structure for table `payment_methods`
--

CREATE TABLE `payment_methods` (
  `PaymentMethodID` int(11) NOT NULL,
  `Name` varchar(50) NOT NULL,
  `Description` text DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_bin;

--
-- Dumping data for table `payment_methods`
--

INSERT INTO `payment_methods` (`PaymentMethodID`, `Name`, `Description`) VALUES
(1, 'Cash', 'Cash Payments'),
(2, 'Card', 'VISA / Master / Amex Card payments'),
(3, 'Loyalty Points', 'Loyalty Points');

-- --------------------------------------------------------

--
-- Table structure for table `products`
--

CREATE TABLE `products` (
  `ProductID` int(11) NOT NULL,
  `ProductCode` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `Barcode` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `Name` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `Price` decimal(10,2) NOT NULL,
  `UnitOfMeasurement` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `CategoryCode` varchar(3) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_bin;

--
-- Dumping data for table `products`
--

INSERT INTO `products` (`ProductID`, `ProductCode`, `Barcode`, `Name`, `Price`, `UnitOfMeasurement`, `CategoryCode`) VALUES
(1, 'FRT001', '1234567890123', 'Apple', 150.00, 'kg', 'FRT'),
(2, 'VEG002', '2345678901234', 'Carrot', 80.00, 'kg', 'VEG'),
(3, 'PRO003', '3456789012345', 'Potato', 60.00, 'kg', 'PRO'),
(4, 'DIR004', '4567890123456', 'Milk', 200.00, 'liter', 'DIR'),
(5, 'MAP005', '5678901234567', 'Chicken Breast', 350.00, 'kg', 'MAP'),
(6, 'BKY006', '6789012345678', 'Bread', 120.00, 'loaf', 'BKY'),
(7, 'FRZ007', '7890123456789', 'Frozen Pizza', 250.00, 'piece', 'FRZ'),
(8, 'CPG008', '8901234567890', 'Canned Soup', 80.00, 'can', 'CPG'),
(9, 'BEV009', '9012345678901', 'Orange Juice', 180.00, 'liter', 'BEV'),
(10, 'SNK010', '0123456789012', 'Potato Chips', 90.00, 'pack', 'SNK'),
(11, 'CER011', '1234567890123', 'Oatmeal', 100.00, 'kg', 'CER'),
(12, 'CON012', '2345678901234', 'Ketchup', 70.00, 'bottle', 'CON'),
(13, 'PER013', '3456789012345', 'Shampoo', 220.00, 'bottle', 'PER'),
(14, 'HCL014', '4567890123456', 'All-Purpose Cleaner', 120.00, 'bottle', 'HCL'),
(15, 'BCC015', '5678901234567', 'Diapers', 300.00, 'pack', 'BCC'),
(16, 'HLW016', '6789012345678', 'Multivitamin', 150.00, 'bottle', 'HLW'),
(17, 'PET017', '7890123456789', 'Dog Food', 180.00, 'kg', 'PET'),
(18, 'CTP018', '8901234567890', 'Cigarettes', 250.00, 'pack', 'CTP'),
(19, 'ELC019', '9012345678901', 'Smartphone', 50000.00, 'unit', 'ELC'),
(20, 'OSS020', '0123456789012', 'Notebook', 150.00, 'unit', 'OSS'),
(21, 'HKW021', '1234567890123', 'Cookware Set', 1000.00, 'set', 'HKW'),
(22, 'ALC022', '2345678901234', 'Wine', 350.00, 'bottle', 'ALC'),
(23, 'FRT023', '3456789012345', 'Banana', 120.00, 'kg', 'FRT'),
(24, 'VEG024', '4567890123456', 'Broccoli', 100.00, 'kg', 'VEG'),
(25, 'PRO025', '5678901234567', 'Onion', 50.00, 'kg', 'PRO'),
(26, 'DIR026', '6789012345678', 'Cheese', 180.00, 'kg', 'DIR'),
(27, 'MAP027', '7890123456789', 'Beef Steak', 400.00, 'kg', 'MAP'),
(28, 'BKY028', '8901234567890', 'Croissant', 150.00, 'piece', 'BKY'),
(29, 'FRZ029', '9012345678901', 'Ice Cream', 200.00, 'liter', 'FRZ'),
(30, 'CPG030', '0123456789012', 'Pasta Sauce', 120.00, 'jar', 'CPG'),
(31, 'BEV031', '1234567890123', 'Soda', 60.00, 'bottle', 'BEV'),
(32, 'SNK032', '2345678901234', 'Chocolate Bar', 40.00, 'bar', 'SNK'),
(33, 'CER033', '3456789012345', 'Granola', 120.00, 'kg', 'CER'),
(34, 'CON034', '4567890123456', 'Mustard', 80.00, 'bottle', 'CON'),
(35, 'PER035', '5678901234567', 'Toothpaste', 50.00, 'tube', 'PER'),
(36, 'HCL036', '6789012345678', 'Disinfectant Wipes', 70.00, 'pack', 'HCL'),
(37, 'BCC037', '7890123456789', 'Baby Formula', 200.00, 'can', 'BCC'),
(38, 'HLW038', '8901234567890', 'Vitamin C', 80.00, 'bottle', 'HLW'),
(39, 'PET039', '9012345678901', 'Cat Litter', 150.00, 'bag', 'PET'),
(40, 'CTP040', '0123456789012', 'Cigar', 30.00, 'pack', 'CTP'),
(41, 'ELC041', '1234567890123', 'Laptop', 60000.00, 'unit', 'ELC'),
(42, 'OSS042', '2345678901234', 'Pens', 10.00, 'pack', 'OSS'),
(43, 'HKW043', '3456789012345', 'Dinnerware Set', 500.00, 'set', 'HKW'),
(44, 'ALC044', '4567890123456', 'Beer', 120.00, 'bottle', 'ALC'),
(45, 'FRT045', '5678901234567', 'Grapes', 200.00, 'kg', 'FRT'),
(46, 'VEG046', '6789012345678', 'Cucumber', 70.00, 'kg', 'VEG'),
(47, 'PRO047', '7890123456789', 'Garlic', 30.00, 'kg', 'PRO'),
(48, 'DIR048', '8901234567890', 'Yogurt', 120.00, 'kg', 'DIR'),
(49, 'MAP049', '9012345678901', 'Turkey', 300.00, 'kg', 'MAP'),
(50, 'BKY050', '0123456789012', 'Muffins', 180.00, 'pack', 'BKY'),
(51, 'FRZ051', '1234567890123', 'Frozen Vegetables Mix', 120.00, 'kg', 'FRZ'),
(52, 'CPG052', '2345678901234', 'Cereal Bars', 60.00, 'box', 'CPG'),
(53, 'BEV053', '3456789012345', 'Coffee Beans', 250.00, 'kg', 'BEV'),
(54, 'SNK054', '4567890123456', 'Pretzels', 80.00, 'pack', 'SNK'),
(55, 'CER055', '5678901234567', 'Cornflakes', 90.00, 'box', 'CER'),
(56, 'CON056', '6789012345678', 'Mayonnaise', 100.00, 'jar', 'CON'),
(57, 'PER057', '7890123456789', 'Deodorant', 120.00, 'bottle', 'PER'),
(58, 'HCL058', '8901234567890', 'Laundry Detergent', 180.00, 'bottle', 'HCL'),
(59, 'BCC059', '9012345678901', 'Baby Shampoo', 150.00, 'bottle', 'BCC'),
(60, 'HLW060', '0123456789012', 'Fish Oil Supplements', 200.00, 'bottle', 'HLW'),
(61, 'PET061', '1234567890123', 'Fish Food', 50.00, 'pack', 'PET'),
(62, 'CTP062', '2345678901234', 'Lighter', 20.00, 'pack', 'CTP'),
(63, 'ELC063', '3456789012345', 'Bluetooth Speaker', 3000.00, 'unit', 'ELC'),
(64, 'OSS064', '4567890123456', 'Notebook Paper', 15.00, 'pack', 'OSS'),
(65, 'HKW065', '5678901234567', 'Cutlery Set', 250.00, 'set', 'HKW'),
(66, 'ALC066', '6789012345678', 'Whiskey', 400.00, 'bottle', 'ALC'),
(67, 'FRT067', '7890123456789', 'Pineapple', 180.00, 'each', 'FRT'),
(68, 'VEG068', '8901234567890', 'Zucchini', 60.00, 'kg', 'VEG'),
(69, 'PRO069', '9012345678901', 'Cabbage', 40.00, 'each', 'PRO'),
(70, 'DIR070', '0123456789012', 'Butter', 160.00, 'kg', 'DIR'),
(71, 'MAP071', '1234567890123', 'Pork Chops', 300.00, 'kg', 'MAP'),
(72, 'BKY072', '2345678901234', 'Baguette', 80.00, 'piece', 'BKY'),
(73, 'FRZ073', '3456789012345', 'Ice Pops', 30.00, 'pack', 'FRZ'),
(74, 'CPG074', '4567890123456', 'Instant Noodles', 50.00, 'pack', 'CPG'),
(75, 'BEV075', '5678901234567', 'Lemonade', 120.00, 'bottle', 'BEV'),
(76, 'SNK076', '6789012345678', 'Popcorn', 40.00, 'pack', 'SNK'),
(77, 'CER077', '7890123456789', 'Rice Krispies', 80.00, 'box', 'CER'),
(78, 'CON078', '8901234567890', 'Hot Sauce', 30.00, 'bottle', 'CON'),
(79, 'PER079', '9012345678901', 'Sunscreen', 200.00, 'bottle', 'PER'),
(80, 'HCL080', '0123456789012', 'Glass Cleaner', 70.00, 'bottle', 'HCL'),
(81, 'BCC081', '1234567890123', 'Baby Wipes', 40.00, 'pack', 'BCC'),
(82, 'HLW082', '2345678901234', 'Protein Powder', 250.00, 'jar', 'HLW'),
(83, 'PET083', '3456789012345', 'Dog Toy', 80.00, 'unit', 'PET'),
(84, 'CTP084', '4567890123456', 'Cigarillos', 25.00, 'pack', 'CTP'),
(85, 'ELC085', '5678901234567', 'Headphones', 1500.00, 'unit', 'ELC'),
(86, 'OSS086', '6789012345678', 'Stapler', 15.00, 'unit', 'OSS'),
(87, 'HKW087', '7890123456789', 'Bakeware Set', 800.00, 'set', 'HKW'),
(88, 'ALC088', '8901234567890', 'Vodka', 300.00, 'bottle', 'ALC'),
(89, 'FRT089', '9012345678901', 'Strawberries', 250.00, 'kg', 'FRT'),
(90, 'VEG090', '0123456789012', 'Bell Pepper', 120.00, 'kg', 'VEG'),
(91, 'PRO091', '1234567890123', 'Lettuce', 30.00, 'each', 'PRO'),
(92, 'DIR092', '2345678901234', 'Sour Cream', 80.00, 'kg', 'DIR'),
(93, 'MAP093', '3456789012345', 'Salmon Fillet', 450.00, 'kg', 'MAP'),
(94, 'BKY094', '4567890123456', 'Donuts', 100.00, 'dozen', 'BKY'),
(95, 'FRZ095', '5678901234567', 'Frozen Fries', 70.00, 'kg', 'FRZ'),
(96, 'CPG096', '6789012345678', 'Peanut Butter', 120.00, 'jar', 'CPG'),
(97, 'BEV097', '7890123456789', 'Iced Tea', 90.00, 'bottle', 'BEV'),
(98, 'SNK098', '8901234567890', 'Trail Mix', 60.00, 'pack', 'SNK'),
(99, 'CER099', '9012345678901', 'Granola Bars', 70.00, 'box', 'CER'),
(100, 'CON100', '0123456789012', 'Soy Sauce', 40.00, 'bottle', 'CON'),
(101, 'PER101', '1234567890123', 'Body Wash', 180.00, 'bottle', 'PER'),
(102, 'HCL102', '2345678901234', 'Dish Soap', 80.00, 'bottle', 'HCL'),
(103, 'BCC103', '3456789012345', 'Baby Diapers', 250.00, 'pack', 'BCC'),
(104, 'HLW104', '4567890123456', 'Multivitamin Gummies', 120.00, 'bottle', 'HLW'),
(105, 'PET105', '5678901234567', 'Cat Food', 150.00, 'kg', 'PET'),
(106, 'CTP106', '6789012345678', 'Rolling Papers', 10.00, 'pack', 'CTP'),
(107, 'ELC107', '7890123456789', 'Smartwatch', 20000.00, 'unit', 'ELC'),
(108, 'OSS108', '8901234567890', 'Highlighters', 5.00, 'pack', 'OSS'),
(109, 'HKW109', '9012345678901', 'Wine Glasses', 300.00, 'set', 'HKW'),
(110, 'ALC110', '0123456789012', 'Rum', 350.00, 'bottle', 'ALC'),
(111, 'FRT111', '1234567890123', 'Mango', 180.00, 'each', 'FRT'),
(112, 'VEG112', '2345678901234', 'Spinach', 50.00, 'kg', 'VEG'),
(113, 'PRO113', '3456789012345', 'Cauliflower', 80.00, 'each', 'PRO'),
(114, 'DIR114', '4567890123456', 'Sour Milk', 100.00, 'liter', 'DIR'),
(115, 'MAP115', '5678901234567', 'Turkey Bacon', 200.00, 'pack', 'MAP'),
(116, 'BKY116', '6789012345678', 'Pita Bread', 70.00, 'pack', 'BKY'),
(117, 'FRZ117', '7890123456789', 'Frozen Berries', 150.00, 'kg', 'FRZ'),
(118, 'CPG118', '8901234567890', 'Chocolate Spread', 120.00, 'jar', 'CPG'),
(119, 'BEV119', '9012345678901', 'Sparkling Water', 40.00, 'bottle', 'BEV'),
(120, 'SNK120', '0123456789012', 'Pretzel Sticks', 60.00, 'pack', 'SNK'),
(121, 'CER121', '1234567890123', 'Quinoa', 200.00, 'kg', 'CER'),
(122, 'CON122', '2345678901234', 'Barbecue Sauce', 80.00, 'bottle', 'CON'),
(123, 'PER123', '3456789012345', 'Hand Sanitizer', 25.00, 'bottle', 'PER'),
(124, 'HCL124', '4567890123456', 'Fabric Softener', 150.00, 'bottle', 'HCL'),
(125, 'BCC125', '5678901234567', 'Baby Onesies', 120.00, 'set', 'BCC'),
(126, 'HLW126', '6789012345678', 'Omega-3 Supplements', 250.00, 'bottle', 'HLW'),
(127, 'PET127', '7890123456789', 'Hamster Bedding', 30.00, 'bag', 'PET'),
(128, 'CTP128', '8901234567890', 'Cigar Cutter', 15.00, 'unit', 'CTP'),
(129, 'ELC129', '9012345678901', 'Digital Camera', 15000.00, 'unit', 'ELC'),
(130, 'OSS130', '0123456789012', 'Scissors', 8.00, 'unit', 'OSS'),
(131, 'HKW131', '1234567890123', 'Dish Set', 400.00, 'set', 'HKW'),
(132, 'ALC132', '2345678901234', 'Tequila', 250.00, 'bottle', 'ALC'),
(133, 'FRT133', '3456789012345', 'Kiwi', 100.00, 'each', 'FRT'),
(134, 'VEG134', '4567890123456', 'Cabbage', 60.00, 'each', 'VEG'),
(135, 'PRO135', '5678901234567', 'Eggplant', 80.00, 'each', 'PRO'),
(136, 'DIR136', '6789012345678', 'Greek Yogurt', 120.00, 'kg', 'DIR'),
(137, 'MAP137', '7890123456789', 'Duck Breast', 350.00, 'kg', 'MAP'),
(138, 'BKY138', '8901234567890', 'Bagels', 90.00, 'pack', 'BKY'),
(139, 'FRZ139', '9012345678901', 'Frozen Shrimp', 180.00, 'kg', 'FRZ'),
(140, 'CPG140', '0123456789012', 'Instant Coffee', 50.00, 'jar', 'CPG'),
(141, 'BEV141', '1234567890123', 'Energy Drink', 70.00, 'can', 'BEV'),
(142, 'SNK142', '2345678901234', 'Peanuts', 40.00, 'pack', 'SNK'),
(143, 'CER143', '3456789012345', 'Muesli', 120.00, 'box', 'CER'),
(144, 'CON144', '4567890123456', 'Soy Milk', 60.00, 'liter', 'CON'),
(145, 'PER145', '5678901234567', 'Dental Floss', 8.00, 'pack', 'PER'),
(146, 'HCL146', '6789012345678', 'Window Cleaner', 50.00, 'bottle', 'HCL'),
(147, 'BCC147', '7890123456789', 'Baby Blanket', 150.00, 'each', 'BCC'),
(148, 'HLW148', '8901234567890', 'Fish Oil Capsules', 120.00, 'bottle', 'HLW'),
(149, 'PET149', '9012345678901', 'Bird Cage', 200.00, 'unit', 'PET'),
(150, 'CTP150', '0123456789012', 'Cigarette Case', 10.00, 'unit', 'CTP'),
(151, 'ELC151', '1234567890123', 'USB Flash Drive', 40.00, 'unit', 'ELC'),
(152, 'OSS152', '2345678901234', 'Calculator', 25.00, 'unit', 'OSS'),
(153, 'HKW153', '3456789012345', 'Food Storage Containers', 120.00, 'set', 'HKW'),
(154, 'ALC154', '4567890123456', 'Gin', 300.00, 'bottle', 'ALC'),
(155, 'FRT155', '5678901234567', 'Watermelon', 80.00, 'each', 'FRT'),
(156, 'VEG156', '6789012345678', 'Asparagus', 120.00, 'kg', 'VEG'),
(157, 'PRO157', '7890123456789', 'Radish', 30.00, 'kg', 'PRO'),
(158, 'DIR158', '8901234567890', 'Sliced Cheese', 100.00, 'pack', 'DIR'),
(159, 'MAP159', '9012345678901', 'Lamb Chops', 400.00, 'kg', 'MAP'),
(160, 'BKY160', '0123456789012', 'Cupcakes', 150.00, 'dozen', 'BKY'),
(161, 'FRZ161', '1234567890123', 'Frozen Fish Fillet', 250.00, 'kg', 'FRZ'),
(162, 'CPG162', '2345678901234', 'Peanut Brittle', 60.00, 'pack', 'CPG'),
(163, 'BEV163', '3456789012345', 'Coconut Water', 90.00, 'bottle', 'BEV'),
(164, 'SNK164', '4567890123456', 'Trail Mix', 70.00, 'pack', 'SNK'),
(165, 'CER165', '5678901234567', 'Pancake Mix', 80.00, 'box', 'CER'),
(166, 'CON166', '6789012345678', 'Salad Dressing', 40.00, 'bottle', 'CON'),
(167, 'PER167', '7890123456789', 'Hand Cream', 120.00, 'tube', 'PER'),
(168, 'HCL168', '8901234567890', 'Floor Cleaner', 60.00, 'bottle', 'HCL'),
(169, 'BCC169', '9012345678901', 'Baby Powder', 25.00, 'bottle', 'BCC'),
(170, 'HLW170', '0123456789012', 'Vitamin D Supplements', 180.00, 'bottle', 'HLW'),
(171, 'PET171', '1234567890123', 'Fish Tank Filter', 50.00, 'unit', 'PET'),
(172, 'CTP172', '2345678901234', 'Cigarette Lighter Fluid', 15.00, 'bottle', 'CTP'),
(173, 'ELC173', '3456789012345', 'Wireless Mouse', 1200.00, 'unit', 'ELC'),
(174, 'OSS174', '4567890123456', 'Index Cards', 5.00, 'pack', 'OSS'),
(175, 'HKW175', '5678901234567', 'Knife Set', 180.00, 'set', 'HKW'),
(176, 'ALC176', '6789012345678', 'Tea', 30.00, 'box', 'ALC'),
(177, 'FRT177', '7890123456789', 'Raspberry', 150.00, 'each', 'FRT'),
(178, 'VEG178', '8901234567890', 'Artichoke', 100.00, 'each', 'VEG'),
(179, 'PRO179', '9012345678901', 'Turnip', 20.00, 'kg', 'PRO'),
(180, 'DIR180', '0123456789012', 'Sour Cream', 80.00, 'kg', 'DIR'),
(181, 'MAP181', '1234567890123', 'Lamb Leg', 350.00, 'kg', 'MAP'),
(182, 'BKY182', '2345678901234', 'Danish Pastry', 120.00, 'piece', 'BKY'),
(183, 'FRZ183', '3456789012345', 'Frozen Peas', 40.00, 'pack', 'FRZ'),
(184, 'CPG184', '4567890123456', 'Salsa', 70.00, 'jar', 'CPG'),
(185, 'BEV185', '5678901234567', 'Iced Coffee', 100.00, 'bottle', 'BEV'),
(186, 'SNK186', '6789012345678', 'Pretzel Bites', 50.00, 'pack', 'SNK'),
(187, 'CER187', '7890123456789', 'Chia Seeds', 120.00, 'kg', 'CER'),
(188, 'CON188', '8901234567890', 'Worcestershire Sauce', 30.00, 'bottle', 'CON'),
(189, 'PER189', '9012345678901', 'Body Lotion', 150.00, 'bottle', 'PER'),
(190, 'HCL190', '0123456789012', 'Oven Cleaner', 80.00, 'bottle', 'HCL'),
(191, 'BCC191', '1234567890123', 'Baby Bibs', 40.00, 'pack', 'BCC'),
(192, 'HLW192', '2345678901234', 'Probiotic Supplements', 200.00, 'bottle', 'HLW'),
(193, 'PET193', '3456789012345', 'Pet Bed', 120.00, 'unit', 'PET'),
(194, 'CTP194', '4567890123456', 'Cigarette Holder', 8.00, 'unit', 'CTP'),
(195, 'ELC195', '5678901234567', 'Wireless Earbuds', 1800.00, 'unit', 'ELC'),
(196, 'OSS196', '6789012345678', 'Binder Clips', 3.00, 'pack', 'OSS'),
(197, 'HKW197', '7890123456789', 'Coffee Mug Set', 150.00, 'set', 'HKW'),
(198, 'ALC198', '8901234567890', 'Rum Punch', 120.00, 'bottle', 'ALC'),
(199, 'FRT199', '9012345678901', 'Blueberries', 200.00, 'kg', 'FRT'),
(200, 'VEG200', '0123456789012', 'Cauliflower Rice', 70.00, 'pack', 'VEG'),
(201, 'SNK201', '1234567890123', 'Pita Chips', 50.00, 'pack', 'SNK'),
(202, 'CER202', '2345678901234', 'Instant Oatmeal', 60.00, 'box', 'CER'),
(203, 'CON203', '3456789012345', 'Soy Sauce', 40.00, 'bottle', 'CON'),
(204, 'PER204', '4567890123456', 'Lip Balm', 15.00, 'tube', 'PER'),
(205, 'HCL205', '5678901234567', 'Stain Remover', 25.00, 'bottle', 'HCL'),
(206, 'BCC206', '6789012345678', 'Baby Oil', 30.00, 'bottle', 'BCC'),
(207, 'HLW207', '7890123456789', 'Sleep Aid Supplements', 100.00, 'bottle', 'HLW'),
(208, 'PET208', '8901234567890', 'Fish Tank Gravel', 20.00, 'bag', 'PET'),
(209, 'CTP209', '9012345678901', 'Cigar Ashtray', 10.00, 'unit', 'CTP'),
(210, 'ELC210', '0123456789012', 'External Hard Drive', 1200.00, 'unit', 'ELC'),
(211, 'OSS211', '1234567890123', 'Sticky Notes', 5.00, 'pack', 'OSS'),
(212, 'HKW212', '2345678901234', 'Wok', 300.00, 'unit', 'HKW'),
(213, 'ALC213', '3456789012345', 'Craft Beer', 80.00, 'bottle', 'ALC'),
(214, 'FRT214', '4567890123456', 'Cantaloupe', 100.00, 'each', 'FRT'),
(215, 'VEG215', '5678901234567', 'Leeks', 50.00, 'kg', 'VEG'),
(216, 'PRO216', '6789012345678', 'Brussels Sprouts', 80.00, 'kg', 'PRO'),
(217, 'DIR217', '7890123456789', 'Buttermilk', 60.00, 'liter', 'DIR'),
(218, 'MAP218', '8901234567890', 'Veal Chops', 450.00, 'kg', 'MAP'),
(219, 'BKY219', '9012345678901', 'Cinnamon Rolls', 120.00, 'pack', 'BKY'),
(220, 'FRZ220', '0123456789012', 'Frozen Corn', 40.00, 'pack', 'FRZ'),
(221, 'CPG221', '1234567890123', 'Peanut Sauce', 80.00, 'bottle', 'CPG'),
(222, 'BEV222', '2345678901234', 'Limeade', 70.00, 'bottle', 'BEV'),
(223, 'SNK223', '3456789012345', 'Mixed Nuts', 90.00, 'pack', 'SNK'),
(224, 'CER224', '4567890123456', 'Bran Flakes', 60.00, 'box', 'CER'),
(225, 'CON225', '5678901234567', 'Teriyaki Sauce', 30.00, 'bottle', 'CON'),
(226, 'PER226', '6789012345678', 'Sunblock', 200.00, 'bottle', 'PER'),
(227, 'HCL227', '7890123456789', 'Air Freshener', 40.00, 'can', 'HCL'),
(228, 'BCC228', '8901234567890', 'Baby Lotion', 25.00, 'bottle', 'BCC'),
(229, 'HLW229', '9012345678901', 'Vitamin E Oil', 80.00, 'bottle', 'HLW'),
(230, 'PET230', '0123456789012', 'Pet Grooming Brush', 15.00, 'unit', 'PET'),
(231, 'CTP231', '1234567890123', 'Cigar Punch', 5.00, 'unit', 'CTP'),
(232, 'ELC232', '2345678901234', 'Tablet', 25000.00, 'unit', 'ELC'),
(233, 'OSS233', '3456789012345', 'Ballpoint Pens', 2.00, 'pack', 'OSS'),
(234, 'HKW234', '4567890123456', 'Cooking Utensil Set', 150.00, 'set', 'HKW'),
(235, 'ALC235', '5678901234567', 'White Wine', 200.00, 'bottle', 'ALC'),
(236, 'FRT236', '6789012345678', 'Passion Fruit', 180.00, 'each', 'FRT'),
(237, 'VEG237', '7890123456789', 'Radicchio', 40.00, 'each', 'VEG'),
(238, 'PRO238', '8901234567890', 'Swiss Chard', 30.00, 'bunch', 'PRO'),
(239, 'DIR239', '9012345678901', 'Almond Milk', 70.00, 'liter', 'DIR'),
(240, 'MAP240', '0123456789012', 'Salmon Steak', 400.00, 'kg', 'MAP'),
(241, 'BKY241', '1234567890123', 'Sourdough Bread', 80.00, 'loaf', 'BKY'),
(242, 'FRZ242', '2345678901234', 'Frozen Strawberries', 120.00, 'kg', 'FRZ'),
(243, 'CPG243', '3456789012345', 'Pasta', 50.00, 'kg', 'CPG'),
(244, 'BEV244', '4567890123456', 'Ginger Beer', 60.00, 'bottle', 'BEV'),
(245, 'SNK245', '5678901234567', 'Rice Cakes', 30.00, 'pack', 'SNK'),
(246, 'CER246', '6789012345678', 'Steel-Cut Oats', 70.00, 'kg', 'CER'),
(247, 'CON247', '7890123456789', 'Taco Seasoning', 20.00, 'jar', 'CON'),
(248, 'PER248', '8901234567890', 'Perfume', 150.00, 'bottle', 'PER'),
(249, 'HCL249', '9012345678901', 'Carpet Cleaner', 50.00, 'bottle', 'HCL'),
(250, 'BCC250', '0123456789012', 'Baby Pacifiers', 15.00, 'pack', 'BCC');

--
-- Triggers `products`
--
DELIMITER $$
CREATE TRIGGER `update_category_code` BEFORE INSERT ON `products` FOR EACH ROW SET NEW.CategoryCode = LEFT(NEW.ProductCode, 3)
$$
DELIMITER ;

-- --------------------------------------------------------

--
-- Stand-in structure for view `products_details`
-- (See below for the actual view)
--
CREATE TABLE `products_details` (
`ProductID` int(11)
,`ProductCode` varchar(255)
,`Barcode` varchar(50)
,`Name` varchar(255)
,`CategoryCode` varchar(3)
,`CategoryName` varchar(50)
,`Price` decimal(10,2)
,`UnitOfMeasurement` varchar(50)
);

-- --------------------------------------------------------

--
-- Stand-in structure for view `returned_billed_products`
-- (See below for the actual view)
--
CREATE TABLE `returned_billed_products` (
`ReturnID` bigint(20)
,`TransactionDate` datetime
,`BillNumber` varchar(50)
,`TransactionID` int(11)
,`TransactionDetailId` int(11)
,`ProductCode` varchar(255)
,`ProductName` varchar(255)
,`BillQuantity` decimal(10,3)
,`ReturnedQuantity` decimal(10,3)
,`Reason` varchar(255)
,`UnitOfMeasurement` varchar(50)
);

-- --------------------------------------------------------

--
-- Table structure for table `stock_transactions`
--

CREATE TABLE `stock_transactions` (
  `TransactionID` int(11) NOT NULL,
  `InventoryID` int(11) NOT NULL,
  `Date` datetime NOT NULL,
  `Type` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `Quantity` int(11) NOT NULL,
  `Vendor` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
  `ExpiryDate` date DEFAULT NULL,
  `Remark` varchar(2555) DEFAULT NULL,
  `Table` varchar(100) DEFAULT 'Main Inventory'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_bin;

--
-- Dumping data for table `stock_transactions`
--

INSERT INTO `stock_transactions` (`TransactionID`, `InventoryID`, `Date`, `Type`, `Quantity`, `Vendor`, `ExpiryDate`, `Remark`, `Table`) VALUES
(1, 1, '2023-12-20 00:00:00', 'Stock Out', 10, 'ABC-MAIN-001', '2024-12-31', 'December Release', 'Main Inventory'),
(2, 8, '2024-01-14 00:00:00', 'Stock Out', 50, 'ABC-MAIN-001', '2024-12-31', 'January Release', 'Main Inventory'),
(3, 8, '2024-01-14 00:00:00', 'Stock In', 100, 'PRIMA PVT Company', '2024-12-31', 'January Intake', 'Main Inventory'),
(4, 1, '2024-01-14 00:00:00', 'Stock Out', 100, 'ABC-MAIN-001', '2024-12-31', 'January Release', 'Main Inventory'),
(5, 11, '2024-02-01 00:00:00', 'Stock In', 50, 'PRIMA PVT Company', '2024-12-31', 'February Intake', 'Main Inventory'),
(6, 1, '2023-12-01 00:00:00', 'Stock In', 50, 'Green Apple Farmers', '2024-12-31', 'December Intake', 'Main Inventory');

-- --------------------------------------------------------

--
-- Stand-in structure for view `store_bill_returned_product_inverntory`
-- (See below for the actual view)
--
CREATE TABLE `store_bill_returned_product_inverntory` (
`ProductID` int(11)
,`ProductCode` varchar(255)
,`ProductName` varchar(255)
,`ReturnedQuantity` decimal(32,3)
,`UnitOfMeasurement` varchar(50)
);

-- --------------------------------------------------------

--
-- Table structure for table `store_details`
--

CREATE TABLE `store_details` (
  `storeId` varchar(12) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `storeName` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `storeAddress` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `storeStartDate` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_bin;

--
-- Dumping data for table `store_details`
--

INSERT INTO `store_details` (`storeId`, `storeName`, `storeAddress`, `storeStartDate`) VALUES
('ABC-MAIN-001', 'ABC Super Store', 'Main St, Colombo 1', '2023-01-01');

-- --------------------------------------------------------

--
-- Table structure for table `store_inventory`
--

CREATE TABLE `store_inventory` (
  `StoreInventoryID` int(11) NOT NULL,
  `ProductID` int(11) NOT NULL,
  `Quantity` int(11) NOT NULL,
  `TransactionID` int(11) DEFAULT NULL,
  `StockLocation` varchar(255) DEFAULT 'RACK-1 BOX-1',
  `Remark` varchar(100) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_bin;

--
-- Dumping data for table `store_inventory`
--

INSERT INTO `store_inventory` (`StoreInventoryID`, `ProductID`, `Quantity`, `TransactionID`, `StockLocation`, `Remark`) VALUES
(1, 1, 10, 1, 'RACK-1 BOX-1', NULL),
(2, 8, 50, 2, 'RACK-1 BOX-2', NULL),
(3, 1, 20, 4, 'RACK-1 BOX-1', NULL);

-- --------------------------------------------------------

--
-- Stand-in structure for view `store_product_inventory`
-- (See below for the actual view)
--
CREATE TABLE `store_product_inventory` (
`StoreInventoryID` int(11)
,`Date` datetime
,`ProductID` int(11)
,`ProductCode` varchar(255)
,`Name` varchar(255)
,`ExpiryDate` date
,`Quantity` int(11)
,`StockLocation` varchar(255)
,`Remark` varchar(2555)
);

-- --------------------------------------------------------

--
-- Stand-in structure for view `store_product_sums`
-- (See below for the actual view)
--
CREATE TABLE `store_product_sums` (
`ProductID` int(11)
,`ProductCode` varchar(255)
,`Name` varchar(255)
,`TotalQuantity` decimal(54,0)
,`TotalSoldQuantity` decimal(32,3)
,`TotalReturnedQuantity` decimal(32,3)
,`Balance` decimal(58,3)
);

-- --------------------------------------------------------

--
-- Stand-in structure for view `store_sold_product_inventory`
-- (See below for the actual view)
--
CREATE TABLE `store_sold_product_inventory` (
`ProductID` int(11)
,`ProductCode` varchar(255)
,`ProductName` varchar(255)
,`SoldQuantity` decimal(32,3)
,`UnitOfMeasurement` varchar(50)
);

-- --------------------------------------------------------

--
-- Table structure for table `transactions`
--

CREATE TABLE `transactions` (
  `TransactionID` int(11) NOT NULL,
  `UserID` int(11) NOT NULL,
  `CustomerID` int(11) NOT NULL,
  `TransactionDate` datetime NOT NULL DEFAULT current_timestamp(),
  `TotalAmount` decimal(10,2) NOT NULL,
  `TotalDiscount` decimal(10,2) NOT NULL,
  `TotalPaidAmount` decimal(10,2) NOT NULL,
  `TotalChange` decimal(10,2) NOT NULL,
  `BillNumber` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_bin;

--
-- Dumping data for table `transactions`
--

INSERT INTO `transactions` (`TransactionID`, `UserID`, `CustomerID`, `TransactionDate`, `TotalAmount`, `TotalDiscount`, `TotalPaidAmount`, `TotalChange`, `BillNumber`) VALUES
(1, 2, 1, '2023-12-27 18:29:34', 37.50, 0.00, 37.50, 0.00, '202312271829'),
(2, 2, 1, '2023-12-28 01:01:32', 1300.00, 0.00, 1500.00, 200.00, '202312280101'),
(3, 2, 1, '2023-12-28 09:53:01', 150.00, 0.00, 150.00, 0.00, '202312280953'),
(4, 2, 5, '2023-12-28 12:43:38', 2925.00, 325.00, 3000.00, 75.00, '202312281243'),
(5, 2, 5, '2024-01-07 02:51:04', 1800.00, 200.00, 2000.00, 200.00, '202401070251'),
(6, 2, 5, '2024-01-07 03:02:51', 1350.00, 150.00, 1500.00, 150.00, '202401070302'),
(7, 2, 1, '2024-01-07 10:02:10', 1620.00, 0.00, 1620.00, 0.00, '202401071002'),
(8, 2, 1, '2024-01-07 10:16:22', 1620.00, 0.00, 1620.00, 0.00, '202401071016'),
(9, 2, 1, '2024-01-07 10:21:00', 1500.00, 0.00, 2000.00, 500.00, '202401071021'),
(10, 2, 5, '2024-01-07 14:09:44', 274.50, 30.50, 274.50, 0.00, '20240107140944'),
(11, 2, 5, '2024-01-12 21:37:43', 1458.00, 162.00, 1500.00, 42.00, '20240112213743'),
(12, 2, 5, '2024-01-13 15:30:10', 1650.00, 0.00, 1650.00, 0.00, '20240113153010'),
(13, 2, 1, '2024-01-14 13:58:52', 0.00, 0.00, 0.00, 0.00, '20240114135852'),
(14, 12, 7, '2024-01-22 03:31:35', 873.00, 97.00, 900.00, 27.00, '20240122033135'),
(15, 12, 5, '2024-02-02 06:13:31', 4300.00, 0.00, 4300.00, 0.00, '20240202061331');

-- --------------------------------------------------------

--
-- Table structure for table `transactions_payment`
--

CREATE TABLE `transactions_payment` (
  `TRPaymentID` int(11) NOT NULL,
  `TransactionID` int(11) DEFAULT NULL,
  `PaymentMethodID` int(11) DEFAULT NULL,
  `PaidAmount` decimal(12,2) DEFAULT NULL,
  `Remark` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_bin;

--
-- Dumping data for table `transactions_payment`
--

INSERT INTO `transactions_payment` (`TRPaymentID`, `TransactionID`, `PaymentMethodID`, `PaidAmount`, `Remark`) VALUES
(1, 1, 1, 37.50, 'Cash '),
(2, 2, 1, 1500.00, 'Cash '),
(3, 3, 1, 150.00, 'Cash '),
(4, 4, 1, 3000.00, 'Cash '),
(5, 5, 1, 2000.00, 'Cash '),
(6, 6, 1, 1500.00, 'Cash '),
(7, 7, 1, 1620.00, 'Cash '),
(8, 8, 1, 1620.00, 'Cash '),
(9, 9, 1, 2000.00, 'Cash '),
(10, 10, 3, 50.00, 'Loyalty Points '),
(11, 10, 1, 24.50, 'Cash '),
(12, 10, 2, 200.00, 'Card 1242'),
(13, 11, 1, 1500.00, 'Cash '),
(14, 12, 2, 1650.00, 'Card 1234'),
(15, 14, 1, 900.00, 'Cash '),
(16, 15, 2, 4300.00, 'Card 1234');

-- --------------------------------------------------------

--
-- Table structure for table `transaction_details`
--

CREATE TABLE `transaction_details` (
  `TransactionDetailID` int(11) NOT NULL,
  `TransactionID` int(11) NOT NULL,
  `ProductID` int(11) NOT NULL,
  `Quantity` decimal(10,3) NOT NULL,
  `UnitPrice` decimal(10,2) NOT NULL,
  `Subtotal` decimal(10,2) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_bin;

--
-- Dumping data for table `transaction_details`
--

INSERT INTO `transaction_details` (`TransactionDetailID`, `TransactionID`, `ProductID`, `Quantity`, `UnitPrice`, `Subtotal`) VALUES
(1, 1, 1, 0.250, 150.00, 37.50),
(2, 2, 3, 5.000, 60.00, 300.00),
(3, 2, 4, 2.000, 200.00, 400.00),
(4, 2, 30, 5.000, 120.00, 600.00),
(5, 3, 1, 1.000, 150.00, 150.00),
(6, 4, 1, 10.000, 150.00, 1500.00),
(7, 4, 5, 5.000, 350.00, 1750.00),
(8, 5, 7, 8.000, 250.00, 2000.00),
(9, 6, 1, 10.000, 150.00, 1500.00),
(10, 7, 1, 10.000, 150.00, 1500.00),
(11, 7, 23, 1.000, 120.00, 120.00),
(12, 8, 1, 10.000, 150.00, 1500.00),
(13, 8, 23, 1.000, 120.00, 120.00),
(14, 9, 1, 10.000, 150.00, 1500.00),
(15, 10, 1, 0.500, 150.00, 75.00),
(16, 10, 23, 0.500, 120.00, 60.00),
(17, 10, 111, 0.500, 180.00, 90.00),
(18, 10, 155, 1.000, 80.00, 80.00),
(19, 11, 6, 1.000, 120.00, 120.00),
(20, 11, 1, 10.000, 150.00, 1500.00),
(21, 12, 1, 10.000, 150.00, 1500.00),
(22, 12, 40, 5.000, 30.00, 150.00),
(23, 14, 10, 10.000, 90.00, 900.00),
(24, 14, 12, 1.000, 70.00, 70.00),
(25, 15, 22, 10.000, 350.00, 3500.00),
(26, 15, 240, 2.000, 400.00, 800.00);

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

CREATE TABLE `users` (
  `UserID` int(11) NOT NULL,
  `FullName` varchar(255) NOT NULL,
  `AccessLevel` varchar(50) NOT NULL,
  `Username` varchar(255) NOT NULL,
  `PasswordHash` varchar(64) NOT NULL,
  `State` varchar(100) NOT NULL DEFAULT 'Active'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_bin;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`UserID`, `FullName`, `AccessLevel`, `Username`, `PasswordHash`, `State`) VALUES
(1, 'Default Customer', 'Customer', 'DCustomer', '$2a$10$D9NSOQNoV/q8HzT0xNAOR.JjSc45QPG2lggXKRctPX5lYYNepZk7C', 'Active'),
(2, 'Default User', 'User', 'DUser', '$2a$10$o.IG8YWJOgXvispOcId91eH51UJQ3TB1WXcL5E22TCm6/LmLgZ6hS', 'Active'),
(3, 'Default Manager', 'Manager', 'DManager', '$2a$10$o.IG8YWJOgXvispOcId91eH51UJQ3TB1WXcL5E22TCm6/LmLgZ6hS', 'Active'),
(4, 'Default Inventory Manager', 'Inventory', 'DIManager', '$2a$10$o.IG8YWJOgXvispOcId91eH51UJQ3TB1WXcL5E22TCm6/LmLgZ6hS', 'Active'),
(8, 'Pamudu De Silva', 'Customer', 'P123', '$2a$10$GR0vPfNHtTxhky3alj5zUubD3crPW26zUhjyBZhcvpTux5UVNilue', 'Deactive'),
(10, 'Savinda', 'Customer', 'S1234', '$2a$10$95Xj7M/Q4NtDKH7x/3trRu.xq46Sy1W9xuz3CCcPBJ.AobvEDo8Ne', 'Deactive'),
(12, 'Pamudu De Silva', 'Manager', 'Admin', '$2a$10$eLW.3nYxjABjp0CLZIO5NOQD/XoWkNvAcoEUqVxcfT7fhfBBw9JeO', 'Active'),
(13, 'Pamudu De Silva', 'Inventory', 'IAdmin', '$2a$10$vA6Kv85SAWlRn9k6NNuHfe1kya42WfEmwQQ.GZaXOJxUdAJKquhdK', 'Active'),
(19, 'Savinda', 'User', 'SAdmin', '$2a$10$lTvBFETb9MgxYBRBBaJis.avW.M0lX1VMIPTE1xMj7byVW8A8d93q', 'Active');

-- --------------------------------------------------------

--
-- Stand-in structure for view `user_accessview`
-- (See below for the actual view)
--
CREATE TABLE `user_accessview` (
`UserID` int(11)
,`Username` varchar(255)
,`AccessLevel` varchar(50)
,`FullName` varchar(255)
,`State` varchar(100)
);

-- --------------------------------------------------------

--
-- Table structure for table `_accesslevels`
--

CREATE TABLE `_accesslevels` (
  `ID` int(11) NOT NULL,
  `AccessLevel` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_bin;

--
-- Dumping data for table `_accesslevels`
--

INSERT INTO `_accesslevels` (`ID`, `AccessLevel`) VALUES
(2, 'Customer'),
(4, 'Inventory'),
(3, 'Manager'),
(1, 'User');

-- --------------------------------------------------------

--
-- Structure for view `billed_products`
--
DROP TABLE IF EXISTS `billed_products`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `billed_products`  AS SELECT `t`.`TransactionDate` AS `TransactionDate`, `t`.`TransactionID` AS `TransactionID`, `td`.`TransactionDetailID` AS `TransactionDetailID`, `t`.`BillNumber` AS `BillNumber`, `p`.`ProductCode` AS `ProductCode`, `p`.`Name` AS `ProductName`, `td`.`Quantity` AS `Quantity`, `p`.`UnitOfMeasurement` AS `UnitOfMeasurement`, `td`.`UnitPrice` AS `UnitPrice`, `td`.`Subtotal` AS `Subtotal` FROM (((`transaction_details` `td` join `transactions` `t` on(`td`.`TransactionID` = `t`.`TransactionID`)) join `products` `p` on(`td`.`ProductID` = `p`.`ProductID`)) join `users` `u` on(`t`.`UserID` = `u`.`UserID`)) ;

-- --------------------------------------------------------

--
-- Structure for view `bill_transaction_payments`
--
DROP TABLE IF EXISTS `bill_transaction_payments`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `bill_transaction_payments`  AS SELECT `t`.`TransactionDate` AS `TransactionDate`, `t`.`BillNumber` AS `BillNumber`, `u`.`FullName` AS `CashierName`, `u2`.`FullName` AS `CustomerName`, `c`.`LoyaltyNumber` AS `LoyaltyNumber`, `t`.`TotalAmount`+ `t`.`TotalDiscount` AS `BilledValue`, `t`.`TotalDiscount` AS `TotalDiscount`, `t`.`TotalAmount` AS `TotalAmount`, `tp`.`PaidAmount` AS `PaidAmount`, `pm`.`Name` AS `Name`, `tp`.`Remark` AS `Remark`, `t`.`TotalPaidAmount` AS `TotalPaidAmount`, `t`.`TotalChange` AS `TotalChange` FROM (((((`transactions_payment` `tp` join `payment_methods` `pm` on(`tp`.`PaymentMethodID` = `pm`.`PaymentMethodID`)) join `transactions` `t` on(`t`.`TransactionID` = `tp`.`TransactionID`)) join `users` `u` on(`u`.`UserID` = `t`.`UserID`)) join `customers` `c` on(`c`.`CustomerID` = `t`.`CustomerID`)) join `users` `u2` on(`c`.`UserID` = `u2`.`UserID`)) ORDER BY `t`.`TransactionDate` DESC ;

-- --------------------------------------------------------

--
-- Structure for view `combined_billed_retuned_products`
--
DROP TABLE IF EXISTS `combined_billed_retuned_products`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `combined_billed_retuned_products`  AS SELECT `bp`.`BillNumber` AS `BillNumber`, `bp`.`TransactionDetailID` AS `TransactionDetailID`, `bp`.`ProductCode` AS `ProductCode`, `bp`.`ProductName` AS `ProductName`, `bp`.`Quantity` AS `BilledQuantity`, coalesce(sum(`rbp`.`ReturnedQuantity`),0.0) AS `ReturnedQuantity`, coalesce(group_concat(distinct `rbp`.`Reason` separator ', '),'') AS `Reason`, `bp`.`UnitOfMeasurement` AS `UnitOfMeasurement` FROM (`billed_products` `bp` left join `returned_billed_products` `rbp` on(`bp`.`BillNumber` = `rbp`.`BillNumber` and `bp`.`TransactionDetailID` = `rbp`.`TransactionDetailId`)) GROUP BY `bp`.`BillNumber`, `bp`.`TransactionDetailID`, `bp`.`ProductCode`, `bp`.`ProductName`, `bp`.`UnitOfMeasurement` ;

-- --------------------------------------------------------

--
-- Structure for view `customer_bills`
--
DROP TABLE IF EXISTS `customer_bills`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `customer_bills`  AS SELECT `t`.`TransactionID` AS `TransactionID`, `t`.`UserID` AS `UserID`, `t`.`CustomerID` AS `CustomerID`, `cu`.`UserID` AS `CustomerUserID`, `uu`.`FullName` AS `UserFullName`, `uc`.`FullName` AS `CustomerFullName`, `t`.`TransactionDate` AS `TransactionDate`, count(`td`.`ProductID`) AS `TotalLineCount`, `t`.`TotalAmount` AS `TotalAmount`, `t`.`TotalDiscount` AS `TotalDiscount`, `t`.`TotalPaidAmount` AS `TotalPaidAmount`, `t`.`TotalChange` AS `TotalChange`, `t`.`BillNumber` AS `BillNumber` FROM ((((`transactions` `t` left join `transaction_details` `td` on(`t`.`TransactionID` = `td`.`TransactionID`)) join `users` `uu` on(`t`.`UserID` = `uu`.`UserID`)) join `customers` `cu` on(`t`.`CustomerID` = `cu`.`CustomerID`)) join `users` `uc` on(`cu`.`UserID` = `uc`.`UserID`)) GROUP BY `t`.`TransactionID`, `t`.`UserID`, `t`.`CustomerID`, `cu`.`UserID`, `uu`.`FullName`, `uc`.`FullName`, `t`.`TransactionDate`, `t`.`TotalAmount`, `t`.`TotalDiscount`, `t`.`TotalPaidAmount`, `t`.`TotalChange`, `t`.`BillNumber` ;

-- --------------------------------------------------------

--
-- Structure for view `customer_bill_summary`
--
DROP TABLE IF EXISTS `customer_bill_summary`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `customer_bill_summary`  AS SELECT `cd`.`CustomerID` AS `CustomerID`, `cd`.`FullName` AS `FullName`, (select `t`.`BillNumber` from `transactions` `t` where `t`.`CustomerID` = `cd`.`CustomerID` order by `t`.`TransactionDate` desc limit 1) AS `LastBillNumber`, (select `t`.`TransactionDate` from `transactions` `t` where `t`.`CustomerID` = `cd`.`CustomerID` order by `t`.`TransactionDate` desc limit 1) AS `LastBillDate`, (select `t`.`TotalAmount` from `transactions` `t` where `t`.`CustomerID` = `cd`.`CustomerID` order by `t`.`TransactionDate` desc limit 1) AS `LastBillTotalAmount`, (select `t`.`TotalDiscount` from `transactions` `t` where `t`.`CustomerID` = `cd`.`CustomerID` order by `t`.`TransactionDate` desc limit 1) AS `LastBillTotalDiscount`, (select `t`.`TotalPaidAmount` from `transactions` `t` where `t`.`CustomerID` = `cd`.`CustomerID` order by `t`.`TransactionDate` desc limit 1) AS `LastBillTotalPaidAmount`, (select `t`.`TotalChange` from `transactions` `t` where `t`.`CustomerID` = `cd`.`CustomerID` order by `t`.`TransactionDate` desc limit 1) AS `LastBillTotalChange`, (select `lp`.`Amount` from `loyaltypoints_transactions` `lp` where `lp`.`LoyaltyNumber` = `cd`.`LoyaltyNumber` and `lp`.`State` = 'Credit' order by `lp`.`TransactionDate` desc limit 1) AS `CreditedLoyaltyPoints`, (select `lp`.`Amount` from `loyaltypoints_transactions` `lp` where `lp`.`LoyaltyNumber` = `cd`.`LoyaltyNumber` and `lp`.`State` = 'Debit' order by `lp`.`TransactionDate` desc limit 1) AS `DebitedLoyaltyPoints`, count(distinct `t`.`BillNumber`) AS `BillCount`, sum(case when `lp`.`State` = 'Credit' then `lp`.`Amount` else 0 end) AS `TotalLoyaltyPointsCredit`, sum(case when `lp`.`State` = 'Debit' then `lp`.`Amount` else 0 end) AS `TotalLoyaltyPointsDebit`, `cd`.`LoyaltyPoints` AS `LoyaltyPointsBalance` FROM ((`customer_details` `cd` left join `transactions` `t` on(`cd`.`CustomerID` = `t`.`CustomerID`)) left join `loyaltypoints_transactions` `lp` on(`cd`.`LoyaltyNumber` = `lp`.`LoyaltyNumber`)) GROUP BY `cd`.`CustomerID`, `cd`.`FullName`, `cd`.`LoyaltyPoints` ;

-- --------------------------------------------------------

--
-- Structure for view `customer_details`
--
DROP TABLE IF EXISTS `customer_details`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `customer_details`  AS SELECT `uav`.`UserID` AS `UserID`, `uav`.`Username` AS `Username`, `uav`.`AccessLevel` AS `AccessLevel`, `uav`.`FullName` AS `FullName`, `uav`.`State` AS `State`, `c`.`CustomerID` AS `CustomerID`, `c`.`LoyaltyNumber` AS `LoyaltyNumber`, `c`.`LoyaltyPoints` AS `LoyaltyPoints`, `c`.`DateOfJoin` AS `DateOfJoin` FROM (`user_accessview` `uav` join `customers` `c` on(`uav`.`UserID` = `c`.`UserID`)) ;

-- --------------------------------------------------------

--
-- Structure for view `main_product_inventory`
--
DROP TABLE IF EXISTS `main_product_inventory`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `main_product_inventory`  AS SELECT `si`.`InventoryID` AS `InventoryID`, `st`.`Date` AS `TransactionDate`, `si`.`ProductID` AS `ProductID`, `p`.`ProductCode` AS `ProductCode`, `p`.`Name` AS `ProductName`, `st`.`ExpiryDate` AS `ExpiryDate`, `si`.`Quantity` AS `InventoryQuantity`, `si`.`Location` AS `StockLocation`, `st`.`Remark` AS `Remark`, `st`.`TransactionID` AS `TransactionID` FROM ((`main_inventory` `si` join `products` `p` on(`si`.`ProductID` = `p`.`ProductID`)) left join (select `st`.`Date` AS `Date`,`st`.`ExpiryDate` AS `ExpiryDate`,`st`.`Remark` AS `Remark`,`st`.`TransactionID` AS `TransactionID`,`st`.`InventoryID` AS `InventoryID` from `stock_transactions` `st` where `st`.`Type` = 'Stock In' order by `st`.`Date`) `st` on(`si`.`InventoryID` = `st`.`InventoryID`)) GROUP BY `si`.`InventoryID` ORDER BY `si`.`InventoryID` ASC ;

-- --------------------------------------------------------

--
-- Structure for view `products_details`
--
DROP TABLE IF EXISTS `products_details`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `products_details`  AS SELECT `p`.`ProductID` AS `ProductID`, `p`.`ProductCode` AS `ProductCode`, `p`.`Barcode` AS `Barcode`, `p`.`Name` AS `Name`, `p`.`CategoryCode` AS `CategoryCode`, `c`.`CategoryName` AS `CategoryName`, `p`.`Price` AS `Price`, `p`.`UnitOfMeasurement` AS `UnitOfMeasurement` FROM (`products` `p` join `categories` `c` on(`p`.`CategoryCode` = `c`.`CategoryCode`)) ;

-- --------------------------------------------------------

--
-- Structure for view `returned_billed_products`
--
DROP TABLE IF EXISTS `returned_billed_products`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `returned_billed_products`  AS SELECT `bri`.`ReturnID` AS `ReturnID`, `bp`.`TransactionDate` AS `TransactionDate`, `bri`.`BillNumber` AS `BillNumber`, `bp`.`TransactionID` AS `TransactionID`, `bri`.`TransactionDetailId` AS `TransactionDetailId`, `bp`.`ProductCode` AS `ProductCode`, `bp`.`ProductName` AS `ProductName`, `bp`.`Quantity` AS `BillQuantity`, `bri`.`ReturnedQuantity` AS `ReturnedQuantity`, `bri`.`Reason` AS `Reason`, `bp`.`UnitOfMeasurement` AS `UnitOfMeasurement` FROM (`bill_return_item` `bri` join `billed_products` `bp` on(`bri`.`BillNumber` = `bp`.`BillNumber` and `bri`.`TransactionDetailId` = `bp`.`TransactionDetailID`)) ;

-- --------------------------------------------------------

--
-- Structure for view `store_bill_returned_product_inverntory`
--
DROP TABLE IF EXISTS `store_bill_returned_product_inverntory`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `store_bill_returned_product_inverntory`  AS SELECT `p`.`ProductID` AS `ProductID`, `p`.`ProductCode` AS `ProductCode`, `p`.`Name` AS `ProductName`, sum(`bri`.`ReturnedQuantity`) AS `ReturnedQuantity`, `p`.`UnitOfMeasurement` AS `UnitOfMeasurement` FROM ((`products` `p` join `transaction_details` `td` on(`p`.`ProductID` = `td`.`ProductID`)) join `bill_return_item` `bri` on(`bri`.`TransactionDetailId` = `td`.`TransactionDetailID`)) GROUP BY `p`.`ProductID`, `p`.`ProductCode`, `p`.`Barcode`, `p`.`Name`, `p`.`Price`, `p`.`UnitOfMeasurement` ;

-- --------------------------------------------------------

--
-- Structure for view `store_product_inventory`
--
DROP TABLE IF EXISTS `store_product_inventory`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `store_product_inventory`  AS SELECT `si`.`StoreInventoryID` AS `StoreInventoryID`, `st`.`Date` AS `Date`, `si`.`ProductID` AS `ProductID`, `p`.`ProductCode` AS `ProductCode`, `p`.`Name` AS `Name`, `st`.`ExpiryDate` AS `ExpiryDate`, `si`.`Quantity` AS `Quantity`, `si`.`StockLocation` AS `StockLocation`, `st`.`Remark` AS `Remark` FROM ((`store_inventory` `si` join `products` `p` on(`si`.`ProductID` = `p`.`ProductID`)) join `stock_transactions` `st` on(`si`.`TransactionID` = `st`.`TransactionID`)) ;

-- --------------------------------------------------------

--
-- Structure for view `store_product_sums`
--
DROP TABLE IF EXISTS `store_product_sums`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `store_product_sums`  AS SELECT `p`.`ProductID` AS `ProductID`, `p`.`ProductCode` AS `ProductCode`, `p`.`Name` AS `Name`, coalesce(sum(`sp`.`Quantity`),0) AS `TotalQuantity`, coalesce(`sspi`.`SoldQuantity`,0) AS `TotalSoldQuantity`, coalesce(`sbrpi`.`ReturnedQuantity`,0) AS `TotalReturnedQuantity`, coalesce(sum(`sp`.`Quantity`),0) - coalesce(`sspi`.`SoldQuantity`,0) AS `Balance` FROM (((`products` `p` left join (select `store_product_inventory`.`ProductID` AS `ProductID`,sum(`store_product_inventory`.`Quantity`) AS `Quantity` from `store_product_inventory` group by `store_product_inventory`.`ProductID`) `sp` on(`p`.`ProductID` = `sp`.`ProductID`)) left join `store_sold_product_inventory` `sspi` on(`p`.`ProductID` = `sspi`.`ProductID`)) left join `store_bill_returned_product_inverntory` `sbrpi` on(`p`.`ProductID` = `sbrpi`.`ProductID`)) GROUP BY `p`.`ProductID`, `p`.`ProductCode`, `p`.`Name`, `sspi`.`SoldQuantity`, `sbrpi`.`ReturnedQuantity` ;

-- --------------------------------------------------------

--
-- Structure for view `store_sold_product_inventory`
--
DROP TABLE IF EXISTS `store_sold_product_inventory`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `store_sold_product_inventory`  AS SELECT `p`.`ProductID` AS `ProductID`, `p`.`ProductCode` AS `ProductCode`, `p`.`Name` AS `ProductName`, sum(`t`.`Quantity`) AS `SoldQuantity`, `p`.`UnitOfMeasurement` AS `UnitOfMeasurement` FROM (`products` `p` join `transaction_details` `t` on(`p`.`ProductID` = `t`.`ProductID`)) GROUP BY `p`.`ProductID`, `p`.`ProductCode`, `p`.`Barcode`, `p`.`Name`, `p`.`Price`, `p`.`UnitOfMeasurement` ;

-- --------------------------------------------------------

--
-- Structure for view `user_accessview`
--
DROP TABLE IF EXISTS `user_accessview`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `user_accessview`  AS SELECT `u`.`UserID` AS `UserID`, `u`.`Username` AS `Username`, `u`.`AccessLevel` AS `AccessLevel`, `u`.`FullName` AS `FullName`, `u`.`State` AS `State` FROM (`users` `u` join `_accesslevels` `a` on(`u`.`AccessLevel` = `a`.`AccessLevel`)) ;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `bill_return_item`
--
ALTER TABLE `bill_return_item`
  ADD PRIMARY KEY (`ReturnID`),
  ADD KEY `BillNumber` (`BillNumber`),
  ADD KEY `TransactionDetailId` (`TransactionDetailId`),
  ADD KEY `UserID` (`UserID`);

--
-- Indexes for table `categories`
--
ALTER TABLE `categories`
  ADD PRIMARY KEY (`CategoryCode`);

--
-- Indexes for table `customers`
--
ALTER TABLE `customers`
  ADD PRIMARY KEY (`CustomerID`),
  ADD UNIQUE KEY `LoyaltyNumber` (`LoyaltyNumber`),
  ADD KEY `UserID` (`UserID`);

--
-- Indexes for table `loyaltypoints_transactions`
--
ALTER TABLE `loyaltypoints_transactions`
  ADD PRIMARY KEY (`TransactionID`),
  ADD KEY `loyaltypoints_transactions_ibfk_1` (`LoyaltyNumber`);

--
-- Indexes for table `main_inventory`
--
ALTER TABLE `main_inventory`
  ADD PRIMARY KEY (`InventoryID`),
  ADD KEY `ProductID` (`ProductID`);

--
-- Indexes for table `payment_methods`
--
ALTER TABLE `payment_methods`
  ADD PRIMARY KEY (`PaymentMethodID`),
  ADD UNIQUE KEY `Name` (`Name`);

--
-- Indexes for table `products`
--
ALTER TABLE `products`
  ADD PRIMARY KEY (`ProductID`),
  ADD UNIQUE KEY `ProductCode` (`ProductCode`),
  ADD KEY `CategoryCode` (`CategoryCode`);

--
-- Indexes for table `stock_transactions`
--
ALTER TABLE `stock_transactions`
  ADD PRIMARY KEY (`TransactionID`),
  ADD KEY `InventoryID` (`InventoryID`);

--
-- Indexes for table `store_details`
--
ALTER TABLE `store_details`
  ADD PRIMARY KEY (`storeId`);

--
-- Indexes for table `store_inventory`
--
ALTER TABLE `store_inventory`
  ADD PRIMARY KEY (`StoreInventoryID`),
  ADD KEY `ProductID` (`ProductID`),
  ADD KEY `store_inventory_ibfk_2` (`TransactionID`);

--
-- Indexes for table `transactions`
--
ALTER TABLE `transactions`
  ADD PRIMARY KEY (`TransactionID`),
  ADD UNIQUE KEY `BillNumber` (`BillNumber`),
  ADD KEY `UserID` (`UserID`),
  ADD KEY `CustomerID` (`CustomerID`);

--
-- Indexes for table `transactions_payment`
--
ALTER TABLE `transactions_payment`
  ADD PRIMARY KEY (`TRPaymentID`),
  ADD KEY `PaymentMethodID` (`PaymentMethodID`),
  ADD KEY `TransactionID` (`TransactionID`);

--
-- Indexes for table `transaction_details`
--
ALTER TABLE `transaction_details`
  ADD PRIMARY KEY (`TransactionDetailID`),
  ADD KEY `TransactionID` (`TransactionID`),
  ADD KEY `ProductID` (`ProductID`);

--
-- Indexes for table `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`UserID`),
  ADD UNIQUE KEY `Username` (`Username`),
  ADD KEY `AccessLevel` (`AccessLevel`);

--
-- Indexes for table `_accesslevels`
--
ALTER TABLE `_accesslevels`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `AccessLevel` (`AccessLevel`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `bill_return_item`
--
ALTER TABLE `bill_return_item`
  MODIFY `ReturnID` bigint(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- AUTO_INCREMENT for table `customers`
--
ALTER TABLE `customers`
  MODIFY `CustomerID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=13;

--
-- AUTO_INCREMENT for table `loyaltypoints_transactions`
--
ALTER TABLE `loyaltypoints_transactions`
  MODIFY `TransactionID` bigint(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;

--
-- AUTO_INCREMENT for table `main_inventory`
--
ALTER TABLE `main_inventory`
  MODIFY `InventoryID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=12;

--
-- AUTO_INCREMENT for table `payment_methods`
--
ALTER TABLE `payment_methods`
  MODIFY `PaymentMethodID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT for table `products`
--
ALTER TABLE `products`
  MODIFY `ProductID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=251;

--
-- AUTO_INCREMENT for table `stock_transactions`
--
ALTER TABLE `stock_transactions`
  MODIFY `TransactionID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT for table `store_inventory`
--
ALTER TABLE `store_inventory`
  MODIFY `StoreInventoryID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT for table `transactions`
--
ALTER TABLE `transactions`
  MODIFY `TransactionID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=16;

--
-- AUTO_INCREMENT for table `transactions_payment`
--
ALTER TABLE `transactions_payment`
  MODIFY `TRPaymentID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=17;

--
-- AUTO_INCREMENT for table `transaction_details`
--
ALTER TABLE `transaction_details`
  MODIFY `TransactionDetailID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=27;

--
-- AUTO_INCREMENT for table `users`
--
ALTER TABLE `users`
  MODIFY `UserID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=20;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `bill_return_item`
--
ALTER TABLE `bill_return_item`
  ADD CONSTRAINT `bill_return_item_ibfk_1` FOREIGN KEY (`BillNumber`) REFERENCES `transactions` (`BillNumber`),
  ADD CONSTRAINT `bill_return_item_ibfk_2` FOREIGN KEY (`TransactionDetailId`) REFERENCES `transaction_details` (`TransactionDetailID`),
  ADD CONSTRAINT `bill_return_item_ibfk_3` FOREIGN KEY (`TransactionDetailId`) REFERENCES `transaction_details` (`TransactionDetailID`),
  ADD CONSTRAINT `bill_return_item_ibfk_4` FOREIGN KEY (`UserID`) REFERENCES `users` (`UserID`);

--
-- Constraints for table `customers`
--
ALTER TABLE `customers`
  ADD CONSTRAINT `customers_ibfk_1` FOREIGN KEY (`UserID`) REFERENCES `users` (`UserID`);

--
-- Constraints for table `loyaltypoints_transactions`
--
ALTER TABLE `loyaltypoints_transactions`
  ADD CONSTRAINT `loyaltypoints_transactions_ibfk_1` FOREIGN KEY (`LoyaltyNumber`) REFERENCES `customers` (`LoyaltyNumber`) ON UPDATE CASCADE;

--
-- Constraints for table `main_inventory`
--
ALTER TABLE `main_inventory`
  ADD CONSTRAINT `main_inventory_ibfk_1` FOREIGN KEY (`ProductID`) REFERENCES `products` (`ProductID`);

--
-- Constraints for table `products`
--
ALTER TABLE `products`
  ADD CONSTRAINT `products_ibfk_1` FOREIGN KEY (`CategoryCode`) REFERENCES `categories` (`CategoryCode`);

--
-- Constraints for table `stock_transactions`
--
ALTER TABLE `stock_transactions`
  ADD CONSTRAINT `stock_transactions_ibfk_1` FOREIGN KEY (`InventoryID`) REFERENCES `main_inventory` (`InventoryID`);

--
-- Constraints for table `store_inventory`
--
ALTER TABLE `store_inventory`
  ADD CONSTRAINT `store_inventory_ibfk_1` FOREIGN KEY (`ProductID`) REFERENCES `products` (`ProductID`),
  ADD CONSTRAINT `store_inventory_ibfk_2` FOREIGN KEY (`TransactionID`) REFERENCES `stock_transactions` (`TransactionID`);

--
-- Constraints for table `transactions`
--
ALTER TABLE `transactions`
  ADD CONSTRAINT `transactions_ibfk_1` FOREIGN KEY (`UserID`) REFERENCES `users` (`UserID`),
  ADD CONSTRAINT `transactions_ibfk_2` FOREIGN KEY (`CustomerID`) REFERENCES `customers` (`CustomerID`);

--
-- Constraints for table `transactions_payment`
--
ALTER TABLE `transactions_payment`
  ADD CONSTRAINT `transactions_payment_ibfk_1` FOREIGN KEY (`PaymentMethodID`) REFERENCES `payment_methods` (`PaymentMethodID`),
  ADD CONSTRAINT `transactions_payment_ibfk_2` FOREIGN KEY (`TransactionID`) REFERENCES `transactions` (`TransactionID`);

--
-- Constraints for table `transaction_details`
--
ALTER TABLE `transaction_details`
  ADD CONSTRAINT `transaction_details_ibfk_1` FOREIGN KEY (`TransactionID`) REFERENCES `transactions` (`TransactionID`),
  ADD CONSTRAINT `transaction_details_ibfk_2` FOREIGN KEY (`ProductID`) REFERENCES `products` (`ProductID`);

--
-- Constraints for table `users`
--
ALTER TABLE `users`
  ADD CONSTRAINT `users_ibfk_1` FOREIGN KEY (`AccessLevel`) REFERENCES `_accesslevels` (`AccessLevel`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
