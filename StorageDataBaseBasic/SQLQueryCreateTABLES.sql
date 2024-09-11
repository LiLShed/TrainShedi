/*Таблиця Юзерів яка зберігає інформацію про користувачів з хешованими паролями*/
CREATE TABLE Users (
    UserID INT PRIMARY KEY IDENTITY(1,1),
    Username VARCHAR(50) NOT NULL UNIQUE,
    PasswordHash VARCHAR(255) NOT NULL,
    UserRole VARCHAR(10) NOT NULL CHECK (UserRole IN ('admin', 'user')),
    CreatedAt DATETIME2 DEFAULT GETDATE()
);
INSERT INTO Users (Username, PasswordHash, UserRole)
VALUES 
('admin', 'e99a18c428cb38d5f260853678922e03', 'admin'), -- Пароль: 'abc123'
('user1', '5f4dcc3b5aa765d61d8327deb882cf99', 'user'),  -- Пароль: 'password'
('user2', '25f9e794323b453885f5181f1b624d0b', 'user');  -- Пароль: '123456'


/*Таблиця Категорій продуктів складу*/
CREATE TABLE Categories (
    CategoryID INT PRIMARY KEY IDENTITY(1,1),
    CategoryName VARCHAR(50) NOT NULL UNIQUE
);
INSERT INTO Categories (CategoryName)
VALUES 
('Fruits and Vegetables'),
('Tools'),
('Goods');

/*Таблиця Продуктів яка зберігає інформацію про продукти та їх категорії*/
CREATE TABLE Products (
    ProductID INT PRIMARY KEY IDENTITY(1,1),
    ProductName VARCHAR(100) NOT NULL,
    CategoryID INT NOT NULL,
    Quantity INT NOT NULL,
    Price DECIMAL(10, 2) NOT NULL,
    FOREIGN KEY (CategoryID) REFERENCES Categories(CategoryID)
);
INSERT INTO Products (ProductName, CategoryID, Quantity, Price)
VALUES 
('Apple', 1, 100, 0.50),
('Hammer', 2, 25, 12.99),
('T-shirt', 3, 50, 9.99);

/*Таблиця Інвентаризації яка зберігає інформацію про оборот продуктів з складу*/
CREATE TABLE Inventory (
    InventoryID INT PRIMARY KEY IDENTITY(1,1),
    ProductID INT NOT NULL,
    QuantityIn INT DEFAULT 0,
    QuantityOut INT DEFAULT 0,
    TransactionDate DATETIME2 DEFAULT GETDATE()
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID)
);
INSERT INTO Inventory (ProductID, QuantityIn, QuantityOut)
VALUES 
(1, 100, 0),  -- Apple
(2, 25, 0),   -- Hammer
(3, 50, 0);   -- T-shirt
