CREATE DATABASE sales_db;
USE sales_db;

CREATE TABLE Client_Master (
    ClientNo   VARCHAR(6) PRIMARY KEY,
    Name       VARCHAR(20) NOT NULL,
    Address1  VARCHAR(30),
    Address2  VARCHAR(30),
    City       VARCHAR(15),
    Pincode    INT,
    State      VARCHAR(15),
    BalDue     DECIMAL(10,2)
);
CREATE TABLE Product_Master (
    ProductNo      VARCHAR(6) PRIMARY KEY,
    Description    VARCHAR(20) NOT NULL,
    ProfitPercent  DECIMAL(6,2) NOT NULL,
    UnitMeasure    VARCHAR(10) NOT NULL,
    QtyOnHand      INT NOT NULL,
    ReorderLevel   INT NOT NULL,
    SellPrice      DECIMAL(8,2) NOT NULL,
    CostPrice      DECIMAL(8,2) NOT NULL
);

CREATE TABLE Salesman_Master (
    SalesmanNo   VARCHAR(6) PRIMARY KEY,
    SalesmanName VARCHAR(20) NOT NULL,
    Address1     VARCHAR(30),
    Address2     VARCHAR(30),
    City         VARCHAR(20),
    Pincode      INT,
    State        VARCHAR(20),
    SalAmt       DECIMAL(8,2) NOT NULL,
    TgtToGet     DECIMAL(6,2) NOT NULL,
    YTDSales     DECIMAL(6,2) NOT NULL,
    Remarks      VARCHAR(60)
);


CREATE TABLE Sales_Order (
    OrderNo     VARCHAR(6) PRIMARY KEY,
    ClientNo    VARCHAR(6),
    OrderDate   DATE,
    DelAddr     VARCHAR(25),
    SalesmanNo  VARCHAR(6),
    DelyType    CHAR(1) CHECK (DelyType IN ('P','F')),
    BilledYN    CHAR(1) CHECK (BilledYN IN ('Y','N')),
    DelyDate    DATE,
    OrderStatus VARCHAR(15),

    FOREIGN KEY (ClientNo) REFERENCES Client_Master(ClientNo),
    FOREIGN KEY (SalesmanNo) REFERENCES Salesman_Master(SalesmanNo)
);



CREATE TABLE Sales_Order_Details (
    OrderNo     VARCHAR(6),
    ProductNo   VARCHAR(6),
    QtyOrdered  INT,
    QtyDisp     INT,
    ProductRate DECIMAL(10,2),

    PRIMARY KEY (OrderNo, ProductNo),
    FOREIGN KEY (OrderNo) REFERENCES Sales_Order(OrderNo),
    FOREIGN KEY (ProductNo) REFERENCES Product_Master(ProductNo)
);


INSERT INTO Client_Master VALUES
('C00001','Sanjay','Ameerpet',NULL,'Hyderabad',500016,'Telangana',12000),
('C00002','Manoj','BTM',NULL,'Bangalore',560029,'Karnataka',8000),
('C00003','Varshith','Gachibowli',NULL,'Hyderabad',500032,'Telangana',15000),
('C00004','Shaaz','Andheri',NULL,'Mumbai',400053,'Maharashtra',6000),
('C00005','Nanda','Velachery',NULL,'Chennai',600042,'Tamil Nadu',10000);

select * from Client_Master

INSERT INTO Product_Master VALUES
('P00001','Laptop',10,'Piece',50,10,60000,54000),
('P00002','Mobile',8,'Piece',80,20,30000,27600),
('P00003','Headphones',12,'Piece',150,30,3000,2640),
('P00004','Keyboard',15,'Piece',100,25,2000,1700);
select * from Product_Master

INSERT INTO Salesman_Master VALUES
('S00001','Ritwhik','Madhapur',NULL,'Hyderabad',500081,'Telangana',2500,5000,3000,'Good'),
('S00002','Nanda','Whitefield',NULL,'Bangalore',560066,'Karnataka',2200,4500,2800,'Average');
select * from Salesman_Master

INSERT INTO Sales_Order VALUES
('O19001','C00001','2024-06-10','Hyderabad','S00001','P','N','2024-06-20','In Process'),
('O19002','C00002','2024-06-12','Bangalore','S00002','F','Y','2024-06-18','Fulfilled');

select * from Sales_Order

INSERT INTO Sales_Order_Details VALUES
('O19001','P00001',1,1,60000),
('O19001','P00003',2,2,3000),
('O19002','P00002',1,1,30000);

select * from Sales_Order


SELECT Name
FROM Client_Master;
SELECT *
FROM Client_Master
WHERE City = 'Mumbai';

SELECT *
FROM Product_Master
WHERE SellPrice > 2000
AND SellPrice < 5000;
SELECT Name, City, State
FROM Client_Master
WHERE State <> 'Maharashtra';

SELECT *
FROM Client_Master
WHERE ClientNo IN ('C00001','C00002');

UPDATE Product_Master
SET SellPrice = 1150.50
WHERE Description = '1.44 drive';

select * from Product_Master

DELETE FROM Client_Master
WHERE ClientNo = 'C00005';

select * from Client_Master

SELECT *
FROM Client_Master
WHERE City LIKE '_a%';

SELECT COUNT(*) AS Product_Count
FROM Product_Master
WHERE SellPrice >= 1500;

SELECT QtyOrdered,
       QtyDisp,
       (QtyOrdered - QtyDisp) AS BalanceQty
FROM Sales_Order_Details;

ALTER TABLE Client_Master
ADD PRIMARY KEY (ClientNo);

ALTER TABLE Client_Master
ADD Phone_No VARCHAR(15);

select * from Client_Master

ALTER TABLE Product_Master
ALTER COLUMN Description VARCHAR(20) NOT NULL;
select * from Product_Master

ALTER TABLE Product_Master
ALTER COLUMN ProfitPercent DECIMAL(6,2) NOT NULL;
select * from Product_Master

ALTER TABLE Product_Master
ALTER COLUMN SellPrice DECIMAL(8,2) NOT NULL;
select * from Product_Master
ALTER TABLE Product_Master
ALTER COLUMN CostPrice DECIMAL(8,2) NOT NULL;
select * from Product_Master

ALTER TABLE Client_Master
ALTER COLUMN Name VARCHAR(60);
select * from Client_Master

ALTER TABLE Client_Master
DROP COLUMN Pincode;
select * from Client_Master

DROP TABLE IF EXISTS Sales_Order_Details;
DROP TABLE IF EXISTS Sales_Order;
DROP TABLE IF EXISTS Product_Master;
DROP TABLE IF EXISTS Salesman_Master;
DROP TABLE IF EXISTS Client_Master;




CREATE TABLE Client_Master (
    ClientNo   VARCHAR(6) PRIMARY KEY,
    Name       VARCHAR(30),
    Address1  VARCHAR(30),
    Address2  VARCHAR(30),
    City       VARCHAR(20),
    Pincode    INT,
    State      VARCHAR(20),
    BalDue     DECIMAL(10,2)
);
CREATE TABLE Product_Master (
    ProductNo      VARCHAR(6) PRIMARY KEY,
    Description    VARCHAR(30),
    ProfitPercent  DECIMAL(6,2),
    UnitMeasure    VARCHAR(10),
    QtyOnHand      INT,
    ReorderLevel   INT,
    SellPrice      DECIMAL(10,2),
    CostPrice      DECIMAL(10,2)
);


CREATE TABLE Salesman_Master (
    SalesmanNo   VARCHAR(6) PRIMARY KEY,
    SalesmanName VARCHAR(30),
    Address1     VARCHAR(30),
    Address2     VARCHAR(30),
    City         VARCHAR(20),
    Pincode      INT,
    State        VARCHAR(20),
    SalAmt       DECIMAL(10,2),
    TgtToGet     DECIMAL(10,2),
    YTDSales     DECIMAL(10,2),
    Remarks      VARCHAR(60)
);
CREATE TABLE Sales_Order (
    OrderNo     VARCHAR(6) PRIMARY KEY,
    ClientNo    VARCHAR(6),
    OrderDate   DATE,
    DelAddr     VARCHAR(30),
    SalesmanNo  VARCHAR(6),
    DelyType    CHAR(1),
    BilledYN    CHAR(1),
    DelyDate    DATE,
    OrderStatus VARCHAR(15)
);
CREATE TABLE Sales_Order_Details (
    OrderNo     VARCHAR(6),
    ProductNo   VARCHAR(6),
    QtyOrdered  INT,
    QtyDisp     INT,
    ProductRate DECIMAL(10,2)
);


INSERT INTO Client_Master VALUES
('C00001','Ivan Bayross','Andheri',NULL,'Mumbai',400053,'Maharashtra',5000),
('C00002','Sanjay','Ameerpet',NULL,'Hyderabad',500016,'Telangana',8000),
('C00003','Manoj','BTM',NULL,'Bangalore',560029,'Karnataka',3000),
('C00004','Varshith','Gachibowli',NULL,'Hyderabad',500032,'Telangana',12000),
('C00005','Shaaz','Velachery',NULL,'Chennai',600042,'Tamil Nadu',2000),
('C00006','Nanda','Kothrud',NULL,'Pune',411038,'Maharashtra',9000);
INSERT INTO Product_Master VALUES
('P00001','Trousers',10,'Piece',100,20,2500,2200),
('P00002','Pull Overs',12,'Piece',80,15,1800,1500),
('P00003','Shirts',8,'Piece',150,30,2200,2000),
('P00004','Jeans',15,'Piece',90,25,3000,2600),
('P00005','Jackets',20,'Piece',60,10,4500,4000),
('P00006','Caps',5,'Piece',200,50,800,700);
INSERT INTO Salesman_Master VALUES
('S00001','Aman','MG Road',NULL,'Mumbai',400001,'Maharashtra',5000,10000,50,'Good'),
('S00002','Ritwhik','Madhapur',NULL,'Hyderabad',500081,'Telangana',6000,12000,70,'Average'),
('S00003','Nanda','Whitefield',NULL,'Bangalore',560066,'Karnataka',5500,11000,60,'Good');
INSERT INTO Sales_Order VALUES
('O19001','C00001','2024-12-05','Mumbai','S00001','P','N','2026-01-10','In Process'),
('O19002','C00002','2026-01-01','Hyderabad','S00002','F','Y','2026-01-15','Fulfilled'),
('O19003','C00003','2024-11-10','Bangalore','S00003','P','Y','2024-11-18','Fulfilled'),
('O19004','C00001','2026-01-03','Mumbai','S00001','F','N','2026-01-20','In Process'),
('O19005','C00004','2024-10-10','Hyderabad','S00002','P','Y','2024-10-20','Cancelled');

INSERT INTO Sales_Order_Details VALUES
('O19001','P00001',3,3,2500),
('O19001','P00002',2,2,1800),
('O19002','P00001',6,6,2500),
('O19002','P00003',1,1,2200),
('O19003','P00004',4,4,3000),
('O19004','P00002',3,3,1800),
('O19005','P00005',2,2,4500);


SELECT p.Description
FROM Client_Master c
JOIN Sales_Order s ON c.ClientNo = s.ClientNo
JOIN Sales_Order_Details d ON s.OrderNo = d.OrderNo
JOIN Product_Master p ON d.ProductNo = p.ProductNo
WHERE c.Name = 'Ivan Bayross';
SELECT p.Description, d.QtyOrdered
FROM Sales_Order s
JOIN Sales_Order_Details d ON s.OrderNo = d.OrderNo
JOIN Product_Master p ON d.ProductNo = p.ProductNo
WHERE MONTH(s.DelyDate) = MONTH(GETDATE())
  AND YEAR(s.DelyDate) = YEAR(GETDATE());

select * from Sales_Order

SELECT p.ProductNo, p.Description
FROM Product_Master p
JOIN Sales_Order_Details d ON p.ProductNo = d.ProductNo
GROUP BY p.ProductNo, p.Description
HAVING COUNT(d.ProductNo) > 1;
SELECT DISTINCT c.Name
FROM Client_Master c
JOIN Sales_Order s ON c.ClientNo = s.ClientNo
JOIN Sales_Order_Details d ON s.OrderNo = d.OrderNo
JOIN Product_Master p ON d.ProductNo = p.ProductNo
WHERE p.Description = 'Trousers';


SELECT s.OrderNo, p.Description, d.QtyOrdered
FROM Sales_Order s
JOIN Sales_Order_Details d ON s.OrderNo = d.OrderNo
JOIN Product_Master p ON d.ProductNo = p.ProductNo
WHERE p.Description = 'Pull Overs'
  AND d.QtyOrdered < 5;

SELECT *
FROM Product_Master
WHERE ProductNo NOT IN (
    SELECT ProductNo FROM Sales_Order_Details
);

SELECT Name, Address1, Address2, City, State, Pincode
FROM Client_Master
WHERE ClientNo = (
    SELECT ClientNo
    FROM Sales_Order
    WHERE OrderNo = 'O19001'
);



SELECT *
FROM Client_Master
WHERE ClientNo IN (
    SELECT ClientNo
    FROM Sales_Order
    WHERE OrderDate < '2002-05-01'
);
select * from Client_Master


SELECT FORMAT('2012-02-11','dddd, MMMM dd, yyyy') AS SystemDate;
SELECT FORMAT(BalDue,'$99,999.99') AS BalanceDue
FROM Client_Master;

SELECT 'Salesman Aman sold goods of 50 while given target was 100.' AS Message;

SELECT DATEDIFF(YEAR,'2005-01-29',GETDATE()) AS Age;


SELECT FORMAT(CAST('2012-02-11' AS DATE),'dddd, MMMM dd, yyyy') AS SystemDate;


SELECT *
FROM Client_Master
WHERE ClientNo IN (
    SELECT ClientNo
    FROM Sales_Order
    WHERE OrderDate < '2002-05-02'
);
select * from Sales_Order

INSERT INTO Client_Master VALUES
('C00007','Ramesh','Ashok Nagar',NULL,'Delhi',110001,'Delhi',4000),
('C00008','Suresh','Alkapuri',NULL,'Vadodara',390007,'Gujarat',6000),
('C00009','Mahesh','Navrangpura',NULL,'Ahmedabad',380009,'Gujarat',3500),
('C00010','Kiran','Banashankari',NULL,'Bangalore',560070,'Karnataka',7200),
('C00011','Prakash','Karve Nagar',NULL,'Pune',411052,'Maharashtra',9100);
INSERT INTO Sales_Order VALUES
('O18001','C00007','2001-03-15','Delhi','S00001','P','Y','2001-03-20','Fulfilled'),
('O18002','C00008','2002-01-10','Vadodara','S00002','F','Y','2002-01-15','Fulfilled'),
('O18003','C00009','2000-11-05','Ahmedabad','S00003','P','Y','2000-11-12','Fulfilled'),
('O18004','C00010','2002-04-25','Bangalore','S00001','F','Y','2002-04-30','Fulfilled'),
('O18005','C00011','1999-08-18','Pune','S00002','P','Y','1999-08-25','Fulfilled');

SELECT *
FROM Client_Master
WHERE ClientNo IN (
    SELECT ClientNo
    FROM Sales_Order
    WHERE OrderDate < '2002-05-01'
);
ALTER TABLE Client_Master
ADD Phone_No VARCHAR(15);
select * from Client_Master
