use Infinitedb

-----> 1. Factorial program
declare @num int = 8;
declare @fact bigint = 1;
while @num > 1
begin
   set @fact = @fact * @num;
   set @num = @num - 1;
end
print 'factorial is: ' + cast(@fact as varchar);

-----> 2. stored procedure for multiplication table
create or alter procedure sp_multiplicationtable
   @num int,
   @limit int
as
begin
   declare @i int = 1;
   while @i <= @limit
   begin
       print cast(@num as varchar) + ' x ' + cast(@i as varchar) + ' = ' + cast(@num * @i as varchar);
       set @i = @i + 1;
   end
end
go
go

-----> 3. Create a function to calculate the status of the student. If student score >=50 then pass, else fail. Display the data neatly
create table student (
   sid int primary key,
   sname varchar(50)
);

insert into student (sid, sname) values
(1, 'jack'),
(2, 'rithvik'),
(3, 'jaspreeth'),
(4, 'praveen'),
(5, 'bisa'),
(6, 'suraj');
go

----->. create marks table and insert data
create table marks (
   mid int,
   sid int,
   score int,
   foreign key (sid) references student(sid)
);

insert into marks (mid, sid, score) values
(1, 1, 23),
(2, 6, 95),
(3, 4, 98),
(4, 2, 17),
(5, 3, 53),
(6, 5, 13);
go

--------> Function to return pass/fail
create or alter function fn_getstatus (@score int)
returns varchar(10)
as
begin
   return (case when @score >= 50 then 'pass' else 'fail' end)
end;
go

------> Final output: student name, score, and status all in one
select
   s.sname,
   m.score,
   dbo.fn_getstatus(m.score) as status
from
   student s
join
   marks m on s.sid = m.sid
order by
   s.sname;



