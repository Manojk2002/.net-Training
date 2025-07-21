use Infinitedb

create table dept (
   deptno int primary key,
   dname varchar(50),
   loc varchar(50)
);

create table emp (
   empno int primary key,
   ename varchar(50),
   job varchar(50),
   mgr_id int,
   hiredate date,
   sal int,
   comm int,
   deptno int,
   foreign key (deptno) references dept(deptno)
);

insert into dept (deptno, dname, loc) values
(10, 'accounting', 'new york'),
(20, 'research', 'dallas'),
(30, 'sales', 'chicago'),
(40, 'operations', 'boston');

insert into emp (empno, ename, job, mgr_id, hiredate, sal, comm, deptno) values
(7369, 'smith', 'clerk', 7902, '1980-12-17', 800, null, 20),
(7499, 'allen', 'salesman', 7698, '1981-02-20', 1600, 300, 30),
(7521, 'ward', 'salesman', 7698, '1981-02-22', 1250, 500, 30),
(7566, 'jones', 'manager', 7839, '1981-04-02', 2975, null, 20),
(7698, 'blake', 'manager', 7839, '1981-05-01', 2850, null, 30),
(7782, 'clark', 'manager', 7839, '1981-06-09', 2450, null, 10),
(7788, 'scott', 'analyst', 7566, '1987-04-19', 3000, null, 20),
(7839, 'king', 'president', null, '1981-11-17', 5000, null, 10),
(7844, 'turner', 'salesman', 7698, '1981-09-08', 1500, 0, 30),
(7876, 'adams', 'clerk', 7788, '1987-05-23', 1100, null, 20),
(7900, 'james', 'clerk', 7698, '1981-12-03', 950, null, 30),
(7902, 'ford', 'analyst', 7566, '1981-12-03', 3000, null, 20),
(7934, 'miller', 'clerk', 7782, '1982-01-23', 1300, null, 10);

----> Q1
select * from emp where job = 'manager';

---->Q2
select ename, sal from emp where sal > 1000;

---->Q3
select ename, sal from emp where ename <> 'james';

---->Q4
select * from emp where ename like 's%';

---->Q5
select ename from emp where ename like '%a%';

---->Q6
select ename from emp where ename like '__l%';

---->Q7
select ename, sal / 30 as daily_salary from emp where ename = 'jones';

---->Q8
select sum(sal) as total_monthly_salary from emp;

---->Q9
select avg(sal) * 12 as avg_annual_salary from emp;

---->Q10
select ename, job, sal, deptno from emp where deptno = 30 and job <> 'salesman';

---->Q11
select distinct deptno from emp;

---->Q12
select ename as employee, sal as monthly_salary 
from emp 
where sal > 1500 and deptno in (10, 30);

---->Q13
select ename, job, sal 
from emp 
where job in ('manager', 'analyst') and sal not in (1000, 3000, 5000);

---->Q14
select ename, sal, comm 
from emp 
where comm is not null and comm > sal * 1.10;

---->Q15
select ename 
from emp 
where ename like '%l%l%' and (deptno = 30 or mgr_id = 7782);

---->Q16
select ename 
from emp 
where datediff(year, hiredate, getdate()) between 30 and 40;


select count(*) as total_employees 
from emp 
where datediff(year, hiredate, getdate()) between 30 and 40;

---->Q17
select d.dname, e.ename 
from dept d 
join emp e on d.deptno = e.deptno 
order by d.dname asc, e.ename desc;

---->Q18
select ename, round(datediff(day, hiredate, getdate()) / 365.0, 2) as experience_years 
from emp 
where ename = 'miller';

















