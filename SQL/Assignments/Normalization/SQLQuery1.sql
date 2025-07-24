create database normalization;

use normalization;

-- 1nf
create table rentals (
    rentalid int primary key,
    clientno varchar(5),
    cname varchar(50),
    propertyno varchar(5),
    paddress varchar(100),
    rentstart date,
    rentfinish date,
    rent decimal(10, 2),
    ownerno varchar(5),
    oname varchar(50)
);

insert into rentals (rentalid, clientno, cname, propertyno, paddress, rentstart, rentfinish, rent, ownerno, oname)
values
    (1, 'cr76', 'john kay', 'pg4', '6 lawrence st, glasgow', '2000-07-01', '2001-08-31', 350, 'c040', 'tina murphy'),
    (2, 'cr76', 'john kay', 'pg16', '5 novar dr, glasgow', '2002-09-01', '2002-09-01', 450, 'c093', 'tony shaw'),
    (3, 'cr56', 'aline stewart', 'pg4', '6 lawrence st, glasgow', '1999-09-01', '2000-06-10', 350, 'c040', 'tina murphy'),
    (4, 'cr56', 'aline stewart', 'pg36', '2 manor rd, glasgow', '2000-10-10', '2001-12-01', 370, 'c093', 'tony shaw'),
    (5, 'cr56', 'aline stewart', 'pg16', '5 novar dr, glasgow', '2002-11-01', '2003-08-03', 450, 'c093', 'tony shaw');

select * from rentals;

-- 2nf

-- clients table
create table clients (
    clientno varchar(5) primary key,
    cname varchar(50)
);

insert into clients (clientno, cname)
values
    ('cr76', 'john kay'),
    ('cr56', 'aline stewart');

-- properties table
create table properties (
    propertyno varchar(5) primary key,
    paddress varchar(100),
    rent decimal(10, 2),
    ownerno varchar(5)
);

insert into properties (propertyno, paddress, rent, ownerno)
values
    ('pg4', '6 lawrence st, glasgow', 350, 'c040'),
    ('pg16', '5 novar dr, glasgow', 450, 'c093'),
    ('pg36', '2 manor rd, glasgow', 370, 'c093');

-- owners table
create table owners (
    ownerno varchar(5) primary key,
    oname varchar(50)
);

insert into owners (ownerno, oname)
values
    ('c040', 'tina murphy'),
    ('c093', 'tony shaw');

-- rentals table
create table rentals (
    rentalid int primary key,
    clientno varchar(5),
    propertyno varchar(5),
    rentstart date,
    rentfinish date,
    foreign key (clientno) references clients(clientno),
    foreign key (propertyno) references properties(propertyno)
);

insert into rentals (rentalid, clientno, propertyno, rentstart, rentfinish)
values
    (1, 'cr76', 'pg4', '2000-07-01', '2001-08-31'),
    (2, 'cr76', 'pg16', '2002-09-01', '2002-09-01'),
    (3, 'cr56', 'pg4', '1999-09-01', '2000-06-10'),
    (4, 'cr56', 'pg36', '2000-10-10', '2001-12-01'),
    (5, 'cr56', 'pg16', '2002-11-01', '2003-08-03');

select * from clients;
select * from properties;
select * from owners;
select * from rentals;
