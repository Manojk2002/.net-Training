
create table books (
   id int primary key,
   title varchar(150),
   author varchar(100),
   isbn varchar(20) unique,
   published_date datetime
);

insert into books (id, title, author, isbn, published_date) values
(1, 'My First SQL book', 'Mary Parker', '981483029127', '2012-02-22 12:08:17'),
(2, 'My Second SQL book', 'John Mayer', '857300923713', '1972-07-03 09:22:45'),
(3, 'My Third SQL book', 'Cary Flint', '523120967812', '2015-10-18 14:05:44');


-- Q1. fetch books written by author whose name ends with 'er'
select * from books
where author like '%er';

create table reviews (
   book_id int,
   reviewer_name varchar(100),
   content text,
   rating int,
   published_date datetime,
   foreign key (book_id) references books(id)
);

insert into reviews (book_id, reviewer_name, content, rating, published_date) values
(1, 'John Smith', 'My first review', 4, '2017-12-10 05:50:11.1'),
(2, 'John Smith', 'My second review', 5, '2017-10-13 15:05:12.6'),
(2, 'Alice Walker', 'Another review', 1, '2017-10-22 23:47:10');

-- Q2. display Title, Author, ReviewerName for all books
select b.title, b.author, r.reviewer_name
from books b
join reviews r on b.id = r.book_id;

-- Q3. display reviewer name who reviewed more than one book
select reviewer_name
from reviews
group by reviewer_name
having count(distinct book_id) > 1;



create table customer (
   id int primary key,
   name varchar(100),
   age int,
   address varchar(100),
   salary decimal(10,2)
);

insert into customer (id, name, age, address, salary) values
(1, 'Ramesh', 32, 'Ahmedabad', 2000.00),
(2, 'Khilan', 25, 'Delhi', 1500.00),
(3, 'Kaushik', 23, 'Kota', 2000.00),
(4, 'Chaitali', 25, 'Mumbai', 6500.00),
(5, 'Hardik', 27, 'Bhopal', 8500.00),
(6, 'Komal', 22, 'MP', 4500.00),
(7, 'Muffy', 24, 'Indore', 10000.00);

-- Q4. display Name for customer who live in same address which has 'a' anywhere
select name
from customer
where address like '%a%';
 
create table orders (
   oid int primary key,
   date datetime,
   customer_id int,
   amount decimal(10,2)
);

insert into orders (oid, date, customer_id, amount) values
(102, '2009-10-08 00:00:00', 3, 3000),
(100, '2009-10-08 00:00:00', 2, 1500),
(101, '2009-11-20 00:00:00', 4, 1560);

-- Q5. display date, total no of customers placed order on same date
select date, count(distinct customer_id) as total_customers
from orders
group by date;

create table employee (
   id int primary key,
   name varchar(100),
   age int,
   address varchar(100),
   salary decimal(10,2)
);

insert into employee (id, name, age, address, salary) values
(1, 'Ramesh', 32, 'Ahmedabad', 2000.00),
(2, 'Khilan', 25, 'Delhi', 1500.00),
(3, 'Kaushik', 23, 'Kota', 2000.00),
(4, 'Chaitali', 25, 'Mumbai', null),
(5, 'Hardik', 27, 'Bhopal', 8500.00),
(6, 'Komal', 22, 'MP', null),
(7, 'Muffy', 24, 'Indore', 10000.00);


-- Q6. display names of employees in lowercase whose salary is null
select lower(name) as name
from employee
where salary is null;

create table studentdetails (
   registerno int primary key,
   name varchar(100),
   age int,
   qualification varchar(50),
   mobileno varchar(20),
   mail_id varchar(100),
   location varchar(100),
   gender varchar(1)
);

insert into studentdetails (registerno, name, age, qualification, mobileno, mail_id, location, gender) values
(2, 'Sai', 22, 'B.E', '9952836777', 'Sai@gmail.com', 'Chennai', 'M'),
(3, 'Kumar', 22, 'BSC', '7890125648', 'Kumar@gmail.com', 'Madurai', 'M'),
(4, 'Selvi', 22, 'B.Tech', '8904567342', 'selvi@gmail.com', 'Selam', 'F'),
(5, 'Nisha', 25, 'M.E', '7834672310', 'Nisha@gmail.com', 'Theni', 'F'),
(6, 'Saisaran', 22, 'B.A', '7890345678', 'saran@gmail.com', 'Madurai', 'M'),
(7, 'Tom', 23, 'BCA', '8901234675', 'Tom@gmail.com', 'Pune', 'M');

-- Q7. display gender and total no. of male and female from studentdetails
select gender, count(*) as total
from studentdetails
group by gender;
