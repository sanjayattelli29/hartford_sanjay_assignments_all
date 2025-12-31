CREATE DATABASE ABC_Airlines;
GO
USE ABC_Airlines;
GO
CREATE TABLE Customers (
    profile_id INT PRIMARY KEY,
    first_name VARCHAR(50),
    last_name VARCHAR(50),
    dob DATE,
    phone VARCHAR(15),
    address VARCHAR(100)
);

CREATE TABLE Flights (
    flight_id INT PRIMARY KEY,
    from_location VARCHAR(50),
    to_location VARCHAR(50)
);

CREATE TABLE Flight_Schedule (
    schedule_id INT PRIMARY KEY,
    flight_id INT,
    departure_date DATE,
    ticket_price INT
);

CREATE TABLE Bookings (
    booking_id INT PRIMARY KEY,
    profile_id INT,
    flight_id INT,
    departure_date DATE,
    tickets INT
);





INSERT INTO Customers VALUES
(1, 'Sanjay', 'Kumar', '2005-01-29', '8919200290', 'Chennai'),
(2, 'Manoj', 'Reddy', '2004-05-11', '9123456711', 'Hyderabad'),
(3, 'Varshith', 'Naik', '2003-08-19', '9001122334', 'Bangalore'),
(4, 'Mani', 'Kumar', '2002-12-02', '9876543210', 'Vijayawada'),
(5, 'Shaaz', 'Ali', '2004-03-14', '8899776655', 'Mumbai'),
(6, 'Bharath', 'Raj', '2001-07-25', '9988776655', 'Delhi');


INSERT INTO Flights VALUES
(101, 'Chennai', 'Hyderabad'),
(102, 'Chennai', 'Delhi'),
(103, 'Mumbai', 'Hyderabad'),
(104, 'Bangalore', 'Chennai');



INSERT INTO Flight_Schedule VALUES
(1, 101, '2025-04-10', 4500),
(2, 101, '2025-04-21', 4800),
(3, 102, '2025-03-15', 6200),
(4, 103, '2025-04-05', 5100),
(5, 104, '2025-02-18', 3900);


INSERT INTO Bookings VALUES
(1, 1, 101, '2025-04-10', 2),
(2, 1, 101, '2025-04-21', 1),
(3, 2, 102, '2025-03-15', 1),
(4, 3, 103, '2025-04-05', 3),
(5, 4, 101, '2025-04-10', 1),
(6, 5, 104, '2025-02-18', 2),
(7, 6, 103, '2025-04-05', 1);



SELECT 
    f.flight_id,
    f.from_location,
    f.to_location,
    DATENAME(MONTH, s.departure_date) AS Month_Name,
    AVG(s.ticket_price) AS Average_Price
FROM Flights f
JOIN Flight_Schedule s ON f.flight_id = s.flight_id
GROUP BY f.flight_id, f.from_location, f.to_location, DATENAME(MONTH, s.departure_date)
ORDER BY f.flight_id, Month_Name;



SELECT 
    c.profile_id,
    c.first_name,
    c.address,
    SUM(b.tickets) AS No_of_Tickets
FROM Customers c
JOIN Bookings b ON c.profile_id = b.profile_id
GROUP BY c.profile_id, c.first_name, c.address
HAVING SUM(b.tickets) = (
    SELECT MIN(tcount)
    FROM (
        SELECT SUM(tickets) AS tcount
        FROM Bookings
        GROUP BY profile_id
    ) x
)
ORDER BY c.first_name;


SELECT 
    f.from_location,
    f.to_location,
    DATENAME(MONTH, s.departure_date) AS Month_Name,
    COUNT(s.departure_date) AS No_of_Services
FROM Flights f
JOIN Flight_Schedule s
    ON f.flight_id = s.flight_id
GROUP BY 
    f.from_location,
    f.to_location,
    DATENAME(MONTH, s.departure_date)
ORDER BY 
    f.from_location,
    f.to_location,
    Month_Name;


SELECT 
    c.profile_id,
    c.first_name,
    c.address,
    SUM(b.tickets) AS No_of_Tickets
FROM Customers c
JOIN Bookings b
    ON c.profile_id = b.profile_id
GROUP BY 
    c.profile_id,
    c.first_name,
    c.address
HAVING SUM(b.tickets) = (
    SELECT MAX(total_tickets)
    FROM (
        SELECT SUM(tickets) AS total_tickets
        FROM Bookings
        GROUP BY profile_id
    ) x
)
ORDER BY c.first_name;


SELECT 
    c.profile_id,
    c.first_name,
    c.last_name,
    b.flight_id,
    b.departure_date,
    b.tickets AS No_of_Tickets
FROM Bookings b
JOIN Customers c
    ON b.profile_id = c.profile_id
JOIN Flights f
    ON b.flight_id = f.flight_id
WHERE f.from_location = 'Chennai'
  AND f.to_location = 'Hyderabad'
ORDER BY 
    c.profile_id,
    b.flight_id,
    b.departure_date;

SELECT 
    f.flight_id,
    f.from_location,
    f.to_location,
    s.ticket_price
FROM Flights f
JOIN Flight_Schedule s
    ON f.flight_id = s.flight_id
WHERE MONTH(s.departure_date) = 4;

SELECT 
    f.flight_id,
    f.from_location,
    f.to_location,
    AVG(s.ticket_price) AS Price
FROM Flights f
JOIN Flight_Schedule s
    ON f.flight_id = s.flight_id
GROUP BY 
    f.flight_id,
    f.from_location,
    f.to_location
ORDER BY 
    f.flight_id,
    f.from_location,
    f.to_location;

SELECT DISTINCT
    c.profile_id,
    c.first_name + ',' + c.last_name AS customer_name,
    c.address
FROM Customers c
JOIN Bookings b
    ON c.profile_id = b.profile_id
JOIN Flights f
    ON b.flight_id = f.flight_id
WHERE f.from_location = 'Chennai'
  AND f.to_location = 'Hyderabad'
ORDER BY c.profile_id;


SELECT profile_id
FROM Bookings
GROUP BY profile_id
HAVING SUM(tickets) = (
    SELECT MAX(total_tickets)
    FROM (
        SELECT SUM(tickets) AS total_tickets
        FROM Bookings
        GROUP BY profile_id
    ) y
)
ORDER BY profile_id;

SELECT 
    f.flight_id,
    f.from_location,
    f.to_location,
    SUM(b.tickets) AS No_of_Tickets
FROM Flights f
JOIN Bookings b
    ON f.flight_id = b.flight_id
GROUP BY 
    f.flight_id,
    f.from_location,
    f.to_location
HAVING SUM(b.tickets) >= 1
ORDER BY f.flight_id;

use test

CREATE TABLE Regions (
    region_id INT PRIMARY KEY,
    region_name VARCHAR(50)
);
INSERT INTO Regions VALUES
(1, 'Asia'),
(2, 'Europe'),
(3, 'America');
CREATE TABLE Jobs (
    job_id INT PRIMARY KEY,
    job_title VARCHAR(20) NOT NULL,
    min_salary DECIMAL(10,2),
    max_salary DECIMAL(10,2),
    CONSTRAINT chk_salary CHECK (min_salary <= max_salary)
);

INSERT INTO Jobs VALUES
(101, 'Manager', 50000, 100000),
(102, 'Developer', 30000, 80000),
(103, 'Tester', 25000, 60000);

CREATE TABLE Countries (
    country_id CHAR(5) PRIMARY KEY,
    country_name VARCHAR(50),
    region_id INT NOT NULL,
    FOREIGN KEY (region_id) REFERENCES Regions(region_id)
);


INSERT INTO Countries VALUES
('IN', 'India', 1),
('UK', 'United Kingdom', 2),
('US', 'United States', 3);


CREATE TABLE Locations (
    location_id INT PRIMARY KEY,
    street_address VARCHAR(100),
    postal_code VARCHAR(20),
    city VARCHAR(15) NOT NULL,
    state_province VARCHAR(50),
    country_id CHAR(5),
    FOREIGN KEY (country_id) REFERENCES Countries(country_id)
);


INSERT INTO Locations VALUES
(1, 'MG Road', '500001', 'Hyderabad', 'Telangana', 'IN'),
(2, 'Oxford Street', 'W1D', 'London', 'England', 'UK'),
(3, '5th Avenue', '10001', 'New York', 'NY', 'US');

CREATE TABLE Departments (
    department_id INT PRIMARY KEY,
    department_name VARCHAR(50) NOT NULL,
    manager_id INT NULL,
    location_id INT,
    FOREIGN KEY (location_id) REFERENCES Locations(location_id)
);


INSERT INTO Departments VALUES
(10, 'HR', NULL, 1),
(20, 'IT', NULL, 2),
(30, 'Finance', NULL, 3);

CREATE TABLE Employees (
    employee_id INT PRIMARY KEY,
    first_name VARCHAR(100),
    last_name VARCHAR(100),
    email VARCHAR(50),
    phone_number VARCHAR(20),
    hire_date DATE,
    job_id INT,
    salary DECIMAL(10,2),
    commission_pct DECIMAL(10,2),
    manager_id INT NULL,
    department_id INT NULL,
    FOREIGN KEY (job_id) REFERENCES Jobs(job_id),
    FOREIGN KEY (department_id) REFERENCES Departments(department_id),
    FOREIGN KEY (manager_id) REFERENCES Employees(employee_id)
);

INSERT INTO Employees VALUES
(1, 'Sanjay', 'Kumar', 'sanjay@mail.com', '900000001', '2024-01-10', 102, 60000, NULL, NULL, 20),
(2, 'Ravi', 'Sharma', 'ravi@mail.com', '900000002', '2023-03-15', 101, 90000, NULL, 1, 10),
(3, 'Neha', 'Singh', 'neha@mail.com', '900000003', '2022-06-20', 103, 40000, NULL, 2, 30);


CREATE TABLE Job_history (
    employee_id INT,
    start_date DATE,
    end_date DATE,
    job_id INT,
    department_id INT,
    PRIMARY KEY (employee_id, start_date),
    FOREIGN KEY (employee_id) REFERENCES Employees(employee_id),
    FOREIGN KEY (job_id) REFERENCES Jobs(job_id),
    FOREIGN KEY (department_id) REFERENCES Departments(department_id)
);

INSERT INTO Job_history VALUES
(1, '2022-01-01', '2023-12-31', 103, 30),
(2, '2021-05-01', '2022-12-31', 102, 20);







SELECT * FROM Regions;
SELECT * FROM Jobs;

SELECT * FROM Countries;
SELECT * FROM Locations;

SELECT * FROM Departments;
SELECT * FROM Employees;

SELECT * FROM Job_history;
