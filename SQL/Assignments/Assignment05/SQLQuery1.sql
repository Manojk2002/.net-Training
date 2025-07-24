Create database Infinitedb

use Infinitedb

-----1. Write a T-Sql based procedure to generate complete payslip of a given employee with respect to the following condition

   ---a) HRA as 10% of Salary
   ---b) DA as 20% of Salary
   ---c) PF as 8% of Salary
   --d) IT as 5% of Salary
   --e) Deductions as sum of PF and IT
   --f) Gross Salary as sum of Salary, HRA, DA
   --g) Net Salary as Gross Salary - Deductions

--Print the payslip neatly with all details

create procedure sp_generatepayslip
    @empno int
as
begin
    set nocount on;

    declare 
        @ename varchar(50),
        @sal int,
        @hra decimal(10,2),
        @da decimal(10,2),
        @pf decimal(10,2),
        @it decimal(10,2),
        @deductions decimal(10,2),
        @gross decimal(10,2),
        @net decimal(10,2);

    -- fetch employee details
    select 
        @ename = ename,
        @sal = sal
    from emp
    where empno = @empno;

    -- calculate components
    set @hra = @sal * 0.10;
    set @da = @sal * 0.20;
    set @pf = @sal * 0.08;
    set @it = @sal * 0.05;

    set @deductions = @pf + @it;
    set @gross = @sal + @hra + @da;
    set @net = @gross - @deductions;

    -- print payslip
    print '========================================';
    print '             payslip details            ';
    print '========================================';
    print 'employee no      : ' + cast(@empno as varchar);
    print 'employee name    : ' + @ename;
    print '----------------------------------------';
    print 'basic salary     : ' + cast(@sal as varchar);
    print 'hra (10%)        : ' + cast(@hra as varchar);
    print 'da (20%)         : ' + cast(@da as varchar);
    print '----------------------------------------';
    print 'gross salary     : ' + cast(@gross as varchar);
    print 'pf (8%)          : ' + cast(@pf as varchar);
    print 'it (5%)          : ' + cast(@it as varchar);
    print 'deductions       : ' + cast(@deductions as varchar);
    print '----------------------------------------';
    print 'net salary       : ' + cast(@net as varchar);
    print '========================================';
end;

exec sp_generatepayslip @empno = 7839;

--2.  Create a trigger to restrict data manipulation on EMP table during General holidays. Display the error message like “Due to Independence day you cannot manipulate data” or "Due To Diwali", you cannot manipulate" etc

--Note: Create holiday table with (holiday_date,Holiday_name). Store at least 4 holiday details. try to match and stop manipulation

create table holiday (
    holiday_date date primary key,
    holiday_name varchar(100)
);

insert into holiday values
('2025-01-26', 'republic day'),
('2025-08-15', 'independence day'),
('2025-10-20', 'diwali'),
('2025-12-25', 'christmas');

create trigger trg_restrict_emp_modification
on emp
after insert, update, delete
as
begin
    declare @today date = cast(getdate() as date);
    declare @holiday_name varchar(100);

    select @holiday_name = holiday_name
    from holiday
    where holiday_date = @today;

    if @holiday_name is not null
    begin
        rollback;
        raiserror('due to %s, you cannot manipulate data', 16, 1, @holiday_name);
    end
end;

----------------simulate a holiday by temporarily setting system date or testing with a future date--------------------

update emp set sal = sal + 100 where empno = 7839;

