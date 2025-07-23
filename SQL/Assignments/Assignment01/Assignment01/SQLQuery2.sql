CREATE TABLE Clients (
   Client_ID INT PRIMARY KEY,
   Cname VARCHAR(40) NOT NULL,
   Address VARCHAR(30),
   Email VARCHAR(30) UNIQUE,
   Phone VARCHAR(10), 
   Business VARCHAR(20) NOT NULL
);

-- Insert data into Clients
INSERT INTO Clients VALUES (1001, 'ACME Utilities', 'Noida', 'contact@acmeutil.com', '9567880032', 'Manufacturing');
INSERT INTO Clients VALUES (1002, 'Trackon Consultants', 'Mumbai', 'consult@trackon.com', '8734210090', 'Consultant');
INSERT INTO Clients VALUES (1003, 'MoneySaver Distributors', 'Kolkata', 'save@moneysaver.com', '7799886655', 'Reseller');
INSERT INTO Clients VALUES (1004, 'Lawful Corp', 'Chennai', 'justice@lawful.com', '9210342219', 'Professional');

CREATE TABLE Departments (
   Deptno INT PRIMARY KEY,
   Dname VARCHAR(15) NOT NULL,
   Loc VARCHAR(20)
);

-- Insert data into Departments
INSERT INTO Departments VALUES (10, 'Design', 'Pune');
INSERT INTO Departments VALUES (20, 'Development', 'Pune');
INSERT INTO Departments VALUES (30, 'Testing', 'Mumbai');
INSERT INTO Departments VALUES (40, 'Document', 'Mumbai');



CREATE TABLE Employees (
   Empno INT PRIMARY KEY,
   Ename VARCHAR(20) NOT NULL,
   Job VARCHAR(15),
   Salary INT CHECK (Salary > 0),
   Deptno INT,
   FOREIGN KEY (Deptno) REFERENCES Departments(Deptno)
);

-- Insert data into Employees
INSERT INTO Employees VALUES (7001, 'Sandeep', 'Analyst', 25000, 10);
INSERT INTO Employees VALUES (7002, 'Rajesh', 'Designer', 30000, 10);
INSERT INTO Employees VALUES (7003, 'Madhav', 'Developer', 40000, 20);
INSERT INTO Employees VALUES (7004, 'Manoj', 'Developer', 40000, 20);
INSERT INTO Employees VALUES (7005, 'Abhay', 'Designer', 35000, 10);
INSERT INTO Employees VALUES (7006, 'Uma', 'Tester', 30000, 30);
INSERT INTO Employees VALUES (7007, 'Gita', 'Tech. Writer', 30000, 40);
INSERT INTO Employees VALUES (7008, 'Priya', 'Tester', 35000, 30);
INSERT INTO Employees VALUES (7009, 'Nutan', 'Developer', 45000, 20);
INSERT INTO Employees VALUES (7010, 'Smita', 'Analyst', 20000, 10);
INSERT INTO Employees VALUES (7011, 'Anand', 'Project Mgr', 65000, 10);



CREATE TABLE Projects (
   Project_ID INT PRIMARY KEY,
   Descr VARCHAR(30) NOT NULL,
   Start_Date DATE,
   Planned_End_Date DATE,
   Actual_End_Date DATE,
   Budget INT CHECK (Budget > 0),
   Client_ID INT,
   FOREIGN KEY (Client_ID) REFERENCES Clients(Client_ID),
   CHECK (Actual_End_Date > Planned_End_Date)
);

-- Insert data into Projects
INSERT INTO Projects VALUES (401, 'Inventory', '2011-04-01', '2011-10-01', '2011-10-31', 150000, 1001);
INSERT INTO Projects VALUES (402, 'Accounting', '2011-08-01', '2012-01-01', NULL, 500000, 1002);
INSERT INTO Projects VALUES (403, 'Payroll', '2011-10-01', '2011-12-31', NULL, 75000, 1003);
INSERT INTO Projects VALUES (404, 'Contact Mgmt', '2011-11-01', '2011-12-31', NULL, 50000, 1004);



CREATE TABLE EmpProjectTasks (
   Project_ID INT,
   Empno INT,
   Start_Date DATE,
   End_Date DATE,
   Task VARCHAR(25) NOT NULL,
   Status VARCHAR(15) NOT NULL,
   PRIMARY KEY (Project_ID, Empno),
   FOREIGN KEY (Project_ID) REFERENCES Projects(Project_ID),
   FOREIGN KEY (Empno) REFERENCES Employees(Empno)
);

-- Insert data into EmpProjectTasks
INSERT INTO EmpProjectTasks VALUES (401, 7001, '2011-04-01', '2011-04-20', 'System Analysis', 'Completed');
INSERT INTO EmpProjectTasks VALUES (401, 7002, '2011-04-21', '2011-05-30', 'System Design', 'Completed');
INSERT INTO EmpProjectTasks VALUES (401, 7003, '2011-06-01', '2011-07-15', 'Coding', 'Completed');
INSERT INTO EmpProjectTasks VALUES (401, 7004, '2011-07-18', '2011-09-01', 'Coding', 'Completed');
INSERT INTO EmpProjectTasks VALUES (401, 7006, '2011-09-03', '2011-09-15', 'Testing', 'Completed');
INSERT INTO EmpProjectTasks VALUES (401, 7009, '2011-09-18', '2011-10-05', 'Code Change', 'Completed');
INSERT INTO EmpProjectTasks VALUES (401, 7008, '2011-10-06', '2011-10-16', 'Testing', 'Completed');
INSERT INTO EmpProjectTasks VALUES (401, 7007, '2011-10-06', '2011-10-22', 'Documentation', 'Completed');
INSERT INTO EmpProjectTasks VALUES (401, 7011, '2011-10-22', '2011-10-31', 'Sign off', 'Completed');
INSERT INTO EmpProjectTasks VALUES (402, 7010, '2011-08-01', '2011-08-20', 'System Analysis', 'Completed');
INSERT INTO EmpProjectTasks VALUES (402, 7002, '2011-08-22', '2011-09-30', 'System Design', 'Completed');
INSERT INTO EmpProjectTasks VALUES (402, 7004, '2011-10-01', NULL, 'Coding', 'In Progress');

-- 1. List all clients
SELECT * FROM Clients;

-- 2. List all employees with their department name
SELECT E.Ename, D.Dname
from Employees E
JOIN Departments D ON E.Deptno = D.Deptno;


-- 3. List all projects with their client name
SELECT P.Descr, C.Cname
FROM Projects P
JOIN Clients C ON P.Client_ID = C.Client_ID;

-- 4. Show tasks assigned to employee named 'Rajesh'
SELECT T.Task, T.Status
FROM EmpProjectTasks T
JOIN Employees E ON T.Empno = E.Empno
WHERE E.Ename = 'Rajesh';

-- 5. Show employees working on the 'Inventory' project
SELECT E.Ename, T.Task
FROM EmpProjectTasks T
JOIN Employees E ON T.Empno = E.Empno
JOIN Projects P ON T.Project_ID = P.Project_ID
WHERE P.Descr = 'Inventory';





