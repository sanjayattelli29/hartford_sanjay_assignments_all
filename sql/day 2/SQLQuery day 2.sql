CREATE DATABASE insurance_db;
USE insurance_db;


CREATE TABLE insurance_customers (
    customer_id INT PRIMARY KEY,
    first_name VARCHAR(50) NOT NULL,
    last_name VARCHAR(50) NOT NULL,
    dob DATE NOT NULL,
    phone VARCHAR(15),
    email VARCHAR(100),
    created_at DATE,
    updated_at DATE
);

INSERT INTO insurance_customers
VALUES
(1, 'Sanjay', 'Attelli', '2005-01-29', '8919200290', 'sanjay.attelli@gmail.com', '2024-01-05', '2024-06-10'),
(2, 'manoj', 'Kumar', '2004-05-25', '9123456789', 'manoj.kumar@yahoo.com', '2024-02-12', '2024-07-01');

SELECT * FROM insurance_customers;

CREATE TABLE policies (
    policy_id INT PRIMARY KEY,
    policy_name VARCHAR(50) NOT NULL,
    policy_type VARCHAR(50) NOT NULL,
    pre_amount INT NOT NULL,
    duration_year INT NOT NULL,
    created_at DATE,
    updated_at DATE
);

INSERT INTO policies
VALUES
(101, 'Life Secure Plan', 'Life Insurance', 12000, 20, '2023-12-01', '2024-05-01'),
(102, 'Health Plus Policy', 'Health Insurance', 8500, 1, '2024-01-15', '2024-06-20');

SELECT * FROM policies;

CREATE TABLE agents (
    agent_id INT PRIMARY KEY,
    agent_name VARCHAR(100) NOT NULL,
    phone VARCHAR(15),
    city VARCHAR(50),
    created_at DATE,
    updated_at DATE
);

INSERT INTO agents
VALUES
(5001, 'sanjay kumar', '8919200290', 'Hyderabad', '2023-11-10', '2024-04-12'),
(5002, 'monoj kumar', '9123456781', 'delhi', '2023-10-05', '2024-03-18'),
(5003, 'varshith', '9988776651', 'Chennai', '2023-09-20', '2024-02-25');

SELECT * FROM agents;

CREATE TABLE policy_assignments (
    assignment_id INT PRIMARY KEY,
    customer_id INT,
    policy_id INT,
    agent_id INT,
    start_date DATE,
    end_date DATE,
    created_at DATE,
    updated_at DATE,
    CONSTRAINT fk_customer FOREIGN KEY (customer_id)
        REFERENCES insurance_customers(customer_id),
    CONSTRAINT fk_policy FOREIGN KEY (policy_id)
        REFERENCES policies(policy_id),
    CONSTRAINT fk_agent FOREIGN KEY (agent_id)
        REFERENCES agents(agent_id)
);

INSERT INTO policy_assignments
VALUES
(1, 1, 101, 5001, '2024-01-01', '2044-01-01', '2024-01-02', '2024-06-01'),
(2, 2, 102, 5002, '2024-06-15', '2025-06-15', '2024-06-16', '2024-07-10');

SELECT * FROM policy_assignments;

CREATE TABLE claims (
    claim_id INT PRIMARY KEY,
    assignment_id INT,
    claim_date DATE NOT NULL,
    claim_amount INT NOT NULL,
    claim_status VARCHAR(30) NOT NULL,
    created_at DATE,
    updated_at DATE,
    CONSTRAINT fk_assignment FOREIGN KEY (assignment_id)
        REFERENCES policy_assignments(assignment_id)
);

INSERT INTO claims
VALUES
(1, 1, '2024-03-10', 50000, 'Approved', '2024-03-11', '2024-03-20'),
(2, 2, '2024-08-05', 12000, 'Pending', '2024-08-06', '2024-08-15');

SELECT * FROM claims;


SELECT TOP 1 * FROM insurance_customers
select top 2 * from agents

SELECT TOP 1 *
FROM policies
ORDER BY created_at DESC;

select * from policies 
where duration_year > 5

select * from insurance_customers 
where year(dob) > '2004'


select count(*) as total_claims
from claims

select * from claims
order by claims_amount desc
OFFSET 1 rows fetch next 1 rows only;  

select sum(claims_amount) as sum_claims from claims

select DISTINCT(policy_name) from policies


select * from insurance_customers
where email is null;

select * from insurance_customers
where email like 'sanjay.attelli@gmail.com'

select * from insurance_customers 

select * from insurance_customers
where first_name like 'S%'

select * from insurance_customers
where email like '%@gmail.com'

SELECT *
FROM policies
WHERE pre_amount > 8000
AND duration_year > 5;



SELECT COUNT(*) AS total_customers
FROM insurance_customers;

SELECT SUM(claims_amount) AS total_claim_amount
FROM claims;

SELECT AVG(pre_amount) AS avg_premium
FROM policies;

SELECT 
    MIN(claims_amount) AS minimum_claim,
    MAX(claims_amount) AS maximum_claim
FROM claims;


SELECT GETDATE() AS current_datetime;

SELECT 
    customer_id,
    DATEDIFF(YEAR, dob, GETDATE()) AS age
FROM insurance_customers;

SELECT UPPER(agent_name) AS agent_name_upper
FROM agents;

SELECT agent_name, LEN(agent_name) AS name_length
FROM agents;


INSERT INTO insurance_customers VALUES
(3,'Amit','Sharma','1998-04-12','9000000001','amit.sharma@gmail.com','2024-03-01','2024-06-01'),
(4,'Priya','Singh','1996-09-21','9000000002','priya.singh@gmail.com','2024-03-02','2024-06-02'),
(5,'Rahul','Verma','1994-01-15','9000000003','rahul.verma@yahoo.com','2024-03-03','2024-06-03'),
(6,'Neha','Gupta','2000-11-30','9000000004','neha.gupta@gmail.com','2024-03-04','2024-06-04'),
(7,'Vikas','Reddy','1992-07-18','9000000005','vikas.reddy@gmail.com','2024-03-05','2024-06-05'),
(8,'Pooja','Nair','1999-02-25','9000000006','pooja.nair@gmail.com','2024-03-06','2024-06-06'),
(9,'Arjun','Patel','1991-12-09','9000000007','arjun.patel@yahoo.com','2024-03-07','2024-06-07'),
(10,'Kiran','Das','1997-06-14','9000000008','kiran.das@gmail.com','2024-03-08','2024-06-08'),
(11,'Sneha','Joshi','1995-10-10','9000000009','sneha.joshi@gmail.com','2024-03-09','2024-06-09'),
(12,'Rohit','Mehta','1993-05-05','9000000010','rohit.mehta@gmail.com','2024-03-10','2024-06-10');


INSERT INTO policies VALUES
(103,'Child Secure','Life Insurance',15000,18,'2024-02-01','2024-06-01'),
(104,'Senior Health','Health Insurance',22000,1,'2024-02-02','2024-06-02'),
(105,'Family Health Plus','Health Insurance',18000,2,'2024-02-03','2024-06-03'),
(106,'Term Life Gold','Life Insurance',25000,30,'2024-02-04','2024-06-04'),
(107,'Personal Accident','General Insurance',6000,1,'2024-02-05','2024-06-05'),
(108,'Travel Secure','Travel Insurance',4000,1,'2024-02-06','2024-06-06'),
(109,'Home Safe','Property Insurance',12000,10,'2024-02-07','2024-06-07'),
(110,'Vehicle Protect','Motor Insurance',9000,1,'2024-02-08','2024-06-08'),
(111,'Health Premium','Health Insurance',30000,3,'2024-02-09','2024-06-09'),
(112,'Life Platinum','Life Insurance',35000,25,'2024-02-10','2024-06-10');


INSERT INTO agents VALUES
(5004,'Amit Rao','9011111111','Mumbai','2023-08-01','2024-04-01'),
(5005,'Priya Shah','9011111112','Pune','2023-08-02','2024-04-02'),
(5006,'Rakesh Jain','9011111113','Delhi','2023-08-03','2024-04-03'),
(5007,'Sunita Roy','9011111114','Kolkata','2023-08-04','2024-04-04'),
(5008,'Deepak Mishra','9011111115','Bhopal','2023-08-05','2024-04-05'),
(5009,'Anil Kumar','9011111116','Chennai','2023-08-06','2024-04-06'),
(5010,'Meena Iyer','9011111117','Coimbatore','2023-08-07','2024-04-07'),
(5011,'Suresh Naik','9011111118','Goa','2023-08-08','2024-04-08'),
(5012,'Kavya Shetty','9011111119','Mangalore','2023-08-09','2024-04-09'),
(5013,'Nitin Kulkarni','9011111120','Nagpur','2023-08-10','2024-04-10');


INSERT INTO policy_assignments VALUES
(3,3,103,5004,'2024-01-10','2042-01-10','2024-01-11','2024-06-01'),
(4,4,104,5005,'2024-02-01','2025-02-01','2024-02-02','2024-06-02'),
(5,5,105,5006,'2024-03-01','2026-03-01','2024-03-02','2024-06-03'),
(6,6,106,5007,'2024-04-01','2054-04-01','2024-04-02','2024-06-04'),
(7,7,107,5008,'2024-05-01','2025-05-01','2024-05-02','2024-06-05'),
(8,8,108,5009,'2024-06-01','2025-06-01','2024-06-02','2024-06-06'),
(9,9,109,5010,'2024-07-01','2034-07-01','2024-07-02','2024-06-07'),
(10,10,110,5011,'2024-08-01','2025-08-01','2024-08-02','2024-06-08'),
(11,11,111,5012,'2024-09-01','2027-09-01','2024-09-02','2024-06-09'),
(12,12,112,5013,'2024-10-01','2049-10-01','2024-10-02','2024-06-10');


INSERT INTO claims VALUES
(3,3,'2024-04-15',20000,'Approved','2024-04-16','2024-04-20'),
(4,4,'2024-05-10',15000,'Pending','2024-05-11','2024-05-18'),
(5,5,'2024-06-05',30000,'Rejected','2024-06-06','2024-06-12'),
(6,6,'2024-07-01',50000,'Approved','2024-07-02','2024-07-10'),
(7,7,'2024-08-12',8000,'Pending','2024-08-13','2024-08-20'),
(8,8,'2024-09-18',12000,'Approved','2024-09-19','2024-09-25'),
(9,9,'2024-10-22',25000,'Approved','2024-10-23','2024-10-30'),
(10,10,'2024-11-05',9000,'Rejected','2024-11-06','2024-11-12'),
(11,11,'2024-11-20',40000,'Pending','2024-11-21','2024-11-28'),
(12,12,'2024-12-01',60000,'Approved','2024-12-02','2024-12-10');


SELECT 
    first_name + ' ' + last_name AS full_name
FROM insurance_customers;

select upper(last_name) from insurance_customers

select * from policies
where len(policy_name) > 6

select policy_name , ROUND(pre_amount, 0) as rounded_prem from policies;

select * from policies where ROUND(pre_amount ,0) > 5000;

select claim_id, ABS(claims_amount) AS abs_claim_amt from claims;

select policy_name, pre_amount * 0.10 as tax_amount from policies;

select concat(first_name,' ',last_name) from insurance_customers;

select GETDATE() as current_date;

select * from 
policies
where year(created_at) = 2023;

SELECT assignment_id,
       DATEDIFF(DAY, start_date, end_date) AS duration_days
FROM policy_assignments;

SELECT customer_id,
       DATEDIFF(YEAR, dob, GETDATE()) AS age
FROM insurance_customers;

SELECT SUM(pre_amount) AS total_premium
FROM policies;

SELECT AVG(pre_amount) AS avg_premium
FROM policies;

SELECT GETDATE() AS current_datetime;

SELECT *
FROM policies
WHERE CAST(created_at AS DATE) = CAST(GETDATE() AS DATE);

SELECT *
FROM policy_assignments
WHERE YEAR(start_date) = YEAR(GETDATE());

SELECT *
FROM claims
WHERE MONTH(claim_date) = 3;

SELECT COUNT(*) AS sunday_claims
FROM claims
WHERE DATENAME(WEEKDAY, claim_date) = 'Sunday';

SELECT *
FROM policy_assignments
WHERE MONTH(end_date) = 12;

SELECT claim_id,
       DATENAME(WEEKDAY, claim_date) AS weekday_name
FROM claims;

SELECT claim_id,
       DATENAME(WEEKDAY, claim_date) AS weekday_name
FROM claims;

SELECT claim_id,
       DATENAME(MONTH, claim_date) AS month_name
FROM claims;

SELECT SYSDATETIME() AS system_datetime;

SELECT GETUTCDATE() AS utc_datetime;

SELECT GETUTCDATE() AS utc_datetime;

SELECT *
FROM policy_assignments
WHERE GETDATE() BETWEEN start_date AND end_date;

SELECT *
FROM claims
WHERE claim_date >= DATEADD(MONTH, -6, GETDATE());

SELECT *
FROM insurance_customers
WHERE created_at >= DATEADD(MONTH, DATEDIFF(MONTH, 0, GETDATE()) - 1, 0)
  AND created_at <  DATEADD(MONTH, DATEDIFF(MONTH, 0, GETDATE()), 0);

  SELECT *
FROM agents
WHERE created_at >= DATEADD(YEAR, -2, GETDATE());

SELECT customer_id,
       DATEDIFF(YEAR, dob, GETDATE()) AS age
FROM insurance_customers;

SELECT *
FROM claims
WHERE DATENAME(WEEKDAY, claim_date) IN ('Saturday', 'Sunday');

select * from policies, insurance_customers;


SELECT 
    c.customer_id,
    c.first_name,
    c.last_name,
    p.policy_name
FROM insurance_customers c
INNER JOIN policy_assignments pa
    ON c.customer_id = pa.customer_id
INNER JOIN policies p
    ON pa.policy_id = p.policy_id;


SELECT 
    c.customer_id,
    c.first_name,
    c.last_name,
    p.policy_name
FROM insurance_customers c
LEFT JOIN policy_assignments pa
    ON c.customer_id = pa.customer_id
LEFT JOIN policies p
    ON pa.policy_id = p.policy_id;

SELECT 
    c.first_name,
    c.last_name,
    p.policy_name
FROM insurance_customers c
RIGHT JOIN policy_assignments pa
    ON c.customer_id = pa.customer_id
RIGHT JOIN policies p
    ON pa.policy_id = p.policy_id;


SELECT 
    c.first_name,
    c.last_name,
    p.policy_name
FROM insurance_customers c
FULL JOIN policy_assignments pa
    ON c.customer_id = pa.customer_id
FULL JOIN policies p
    ON pa.policy_id = p.policy_id;

SELECT 
    c.customer_id,
    c.first_name,
    c.last_name,
    pa.policy_id
FROM insurance_customers c
INNER JOIN policy_assignments pa
    ON c.customer_id = pa.customer_id;


SELECT 
    c.customer_id,
    c.first_name,
    pa.assignment_id,
    pa.policy_id
FROM insurance_customers c
FULL JOIN policy_assignments pa
    ON c.customer_id = pa.customer_id;

select c.customer_id, c.first_name, pa.assignment_id, p.policy_id, cl.claims_amount from insurance_customers c
join policy_assignments pa
on c.customer_id = pa.customer_id
join policies p
on p.policy_id = pa.policy_id
join claims cl
on cl.assignment_id = pa.assignment_id


SELECT 
    p.policy_name,
    a.agent_name,
    pa.start_date,
    pa.end_date
FROM policies p
JOIN policy_assignments pa
    ON p.policy_id = pa.policy_id
JOIN agents a
    ON pa.agent_id = a.agent_id;


SELECT * FROM insurance_customers;

SELECT * FROM policies
WHERE policy_type = 'Health Insurance';

SELECT * FROM policies
WHERE pre_amount > 10000 AND duration_year = 1;


SELECT DISTINCT city FROM agents;
SELECT * FROM policies
WHERE policy_type = 'Life Insurance'
   OR policy_type = 'Health Insurance'
   OR policy_type = 'Motor Insurance';

SELECT * FROM policies
WHERE policy_type IN ('Life Insurance','Health Insurance','Motor Insurance');

SELECT * FROM insurance_customers
WHERE dob >= '2001-01-01' AND dob <= '2020-12-31';
SELECT * FROM insurance_customers
WHERE dob BETWEEN '2001-01-01' AND '2020-12-31';


SELECT * FROM claims
WHERE claim_status = 'Rejected';
SELECT * FROM agents
WHERE city LIKE '_a%';

SELECT MIN(claims_amount) AS min_claim,
       MAX(claims_amount) AS max_claim
FROM claims;

SELECT TOP 1 *
FROM claims
ORDER BY claim_date DESC;

UPDATE policies
SET pre_amount = pre_amount * 1.10
WHERE policy_type = 'Health Insurance';
select * from policies

DELETE FROM policy_assignments
WHERE end_date < GETDATE();

SELECT COUNT(*) AS rejected_claims
FROM claims
WHERE claim_status = 'Rejected';

SELECT policy_id,
       policy_name,
       pre_amount,
       pre_amount * 0.06 AS local_taxes,
       pre_amount * 1.06 AS premium_with_tax,
       (pre_amount * 1.06) / 12 AS monthly_premium
FROM policies;

ALTER TABLE insurance_customers
ADD address VARCHAR(200), city VARCHAR(50);

ALTER TABLE agents
ADD DevOfId INT;

select * from agents

ALTER TABLE agents
ADD CONSTRAINT fk_dev_agent
FOREIGN KEY (DevOfId) REFERENCES agents(agent_id);

SELECT p.*
FROM policies p
JOIN policy_assignments pa
ON p.policy_id = pa.policy_id
WHERE pa.customer_id = 5;

SELECT c.first_name, c.last_name, p.policy_name
FROM insurance_customers c
JOIN policy_assignments pa
ON c.customer_id = pa.customer_id
JOIN policies p
ON pa.policy_id = p.policy_id;

SELECT c.first_name, c.last_name, cl.claims_amount
FROM insurance_customers c
JOIN policy_assignments pa
ON c.customer_id = pa.customer_id
JOIN claims cl
ON pa.assignment_id = cl.assignment_id;

SELECT c.first_name,
       p.policy_name,
       a.agent_name,
       pa.start_date,
       pa.end_date
FROM policy_assignments pa
JOIN insurance_customers c ON pa.customer_id = c.customer_id
JOIN policies p ON pa.policy_id = p.policy_id
JOIN agents a ON pa.agent_id = a.agent_id;

SELECT c.first_name,
       p.policy_name,
       cl.claims_amount,
       cl.claim_status,
       cl.claim_date
FROM claims cl
JOIN policy_assignments pa ON cl.assignment_id = pa.assignment_id
JOIN insurance_customers c ON pa.customer_id = c.customer_id
JOIN policies p ON pa.policy_id = p.policy_id;

SELECT c.*
FROM insurance_customers c
LEFT JOIN policy_assignments pa
ON c.customer_id = pa.customer_id;

SELECT DISTINCT c.*
FROM insurance_customers c
LEFT JOIN policy_assignments pa ON c.customer_id = pa.customer_id
LEFT JOIN claims cl ON pa.assignment_id = cl.assignment_id
WHERE cl.claim_id IS NULL;


SELECT a.agent_name,
       COUNT(pa.policy_id) AS policy_count
FROM agents a
JOIN policy_assignments pa ON a.agent_id = pa.agent_id
GROUP BY a.agent_name;




select claim_id, claims_amount from claims
where claims_amount in (select max(claims_amount) from claims)

select max(claims_amount) from claims

use insurance_db

select distinct c.customer_id, c.first_name, c.last_name
from insurance_customers c
join policy_assignments pa on c.customer_id = pa.customer_id
join policies p on pa.policy_id = p.policy_id
where p.pre_amount > (
    select avg(pre_amount)
    from policies
);


select policy_id, policy_name, pre_amount 
from policies
where pre_amount = (
    select max(pre_amount)
    from policies
);

use insurance_db

create table customer
(
	Customer_ID	INT,
	CustomerName varchar(50),
	city varchar(50)
);

create table product
(
	Product_id	INT,
	ProductName varchar(50),
	price int
);

create table orders
(
	orderID int,
	CustomerID int,
	productid int,
	quantity int
);


INSERT INTO Customer VALUES
(1, 'Amit', 'Delhi'),
(2, 'Neha', 'Mumbai'),
(3, 'Rohit', 'Pune'),
(4, 'Karan', 'Delhi');

INSERT INTO Product VALUES
(101, 'Laptop', 40000),
(102, 'Mobile', 15000),
(103, 'Headphones', 3000),
(104, 'Keyboard', 2000);

INSERT INTO Orders VALUES
(1, 1, 103, 2),
(2, 1, 104, 1),
(3, 2, 102, 1),
(4, 2, 103, 2),
(5, 3, 104, 2),
(6, 4, 101, 1);

SELECT
    c.Customer_ID,
    c.CustomerName,
    SUM(p.Price * o.Quantity) AS TotalPurchase
FROM Customer c
JOIN Orders o
    ON c.Customer_ID = o.CustomerID
JOIN Product p
    ON p.Product_ID = o.ProductID
GROUP BY
    c.Customer_ID,
    c.CustomerName;

SELECT
    c.Customer_ID,
    c.CustomerName,
    SUM(p.Price * o.Quantity) AS TotalPurchase,
    CASE
        WHEN SUM(p.Price * o.Quantity) < 10000 THEN 'Regular'
        WHEN SUM(p.Price * o.Quantity) BETWEEN 10000 AND 25000 THEN 'Silver'
        ELSE 'Gold'
    END AS CustomerCategory
FROM Customer c
JOIN Orders o
    ON c.Customer_ID = o.CustomerID
JOIN Product p
    ON o.ProductID = p.Product_ID
GROUP BY
    c.Customer_ID,
    c.CustomerName;

use test
USE insurance_db;

CREATE TABLE Customer_Staging
(
    Customer_ID INT,
    CustomerName VARCHAR(50),
    City VARCHAR(50)
);
INSERT INTO Customer_Staging VALUES
(2, 'Neha', 'Pune'),        -- existing customer (will UPDATE)
(3, 'Rohit', 'Pune'),       -- existing customer (same data)
(5, 'Meenal Shah', 'Ahmedabad');  -- new customer (will INSERT)

MERGE Customer AS T
USING Customer_Staging AS S
ON T.Customer_ID = S.Customer_ID

WHEN MATCHED THEN
    UPDATE SET
        T.CustomerName = S.CustomerName,
        T.City = S.City

WHEN NOT MATCHED BY TARGET THEN
    INSERT (Customer_ID, CustomerName, City)
    VALUES (S.Customer_ID, S.CustomerName, S.City)

WHEN NOT MATCHED BY SOURCE THEN
    DELETE;

SELECT * FROM Customer;
SELECT * FROM Customer_Staging;

SELECT
    CASE
        WHEN GROUPING(c.CustomerName) = 1 THEN 'All Customers'
        ELSE c.CustomerName
    END AS Customer,

    CASE
        WHEN GROUPING(p.ProductName) = 1 THEN 'All Products'
        ELSE p.ProductName
    END AS Product,

    SUM(p.Price * o.Quantity) AS TotalAmount
FROM Customer c
JOIN Orders o
    ON c.Customer_ID = o.CustomerID
JOIN Product p
    ON o.ProductID = p.Product_ID
GROUP BY ROLLUP (c.CustomerName, p.ProductName)
ORDER BY
    GROUPING(c.CustomerName),
    c.CustomerName,
    GROUPING(p.ProductName),
    p.ProductName;


