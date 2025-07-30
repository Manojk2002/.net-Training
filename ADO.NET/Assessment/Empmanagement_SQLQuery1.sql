----ICS-LT-7Y6G7V3\\SQLEXPRESS

CREATE DATABASE EmployeeeManagement

use EmployeeeManagement

----Create Table
create table employee_details (
    empid int primary key identity(1,1),
    name varchar(100),
    salary decimal(10,2),
    gender char(1)
);

----1) Stored Procedure to Insert Employeee
create procedure insertemployee
    @name varchar(100),
    @givensalary decimal(10,2),
    @gender char(1),
    @generatedempid int output,
    @calculatedsalary decimal(10,2) output
as
begin
    set nocount on;

    declare @salary decimal(10,2)
    set @salary = @givensalary - (@givensalary * 0.10)

    insert into employee_details (name, salary, gender)
    values (@name, @salary, @gender)

    set @generatedempid = scope_identity()
    set @calculatedsalary = @salary
end

----2) Stored Procedure to Update Salary
create procedure updatesalary
    @empid int,
    @updatedsalary decimal(10,2) output,
    @netsalary decimal(10,2) output
as
begin
    set nocount on;

    update employee_details
    set salary = salary + 100
    where empid = @empid

    select @updatedsalary = salary from employee_details where empid = @empid
    set @netsalary = @updatedsalary - (@updatedsalary * 0.10)
end

select * from employee_details;




