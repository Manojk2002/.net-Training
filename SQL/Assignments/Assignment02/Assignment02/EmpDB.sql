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

--> query 1: employees whose name starts with 's'
select * from emp where ename like 's%';

--> query 2: employees who don't have a manager
select * from emp where mgr_id is null;

--> query 3: employees with salary between 1200 and 1400
select ename, sal from emp where sal between 1200 and 1400;


--> query 4: 10% salary increase for research dept, show before and after 
-- before
select * from emp where deptno = (select deptno from dept where dname = 'research');

-- apply increment
update emp set sal = sal * 1.10 where deptno = (select deptno from dept where dname = 'research');

-- after
select * from emp where deptno = (select deptno from dept where dname = 'research');

--> query 5: list clerks in descending name order
select * from emp where job = 'clerk' order by ename desc;

--> query 6: job title with number of employees
select job, count(*) as num_employees from emp group by job;

--> query 7: employee with lowest and highest salary
select * from emp where sal = (select min(sal) from emp);
select * from emp where sal = (select max(sal) from emp);

--> query 8: department names with number of employees
select d.dname, count(e.empno) as num_emp
from dept d
left join emp e on d.deptno = e.deptno
group by d.dname;

--> query 9: employees with sal > 1200 in dept 20, ordered by ename
select * from emp where sal > 1200 and deptno = 20 order by ename;

--> query 10: total salary paid to each department
select dname, sum(sal) as total_sal
from dept d
join emp e on d.deptno = e.deptno
group by dname;

--> query 11: salary of miller and smith
select ename, sal from emp where ename in ('miller', 'smith');

--> query 12: employees whose names start with 'a' or 'r'
select * from emp where ename like 'a%' or ename like 'r%';

--> query 13: employees whose salary not in range 1500–2850
select *, sal from emp where sal not between 1500 and 2850;

--> query 14: managers with more than 2 employees reporting to them
select e.empno, e.ename, count(*) as num_reports
from emp e
join emp m on e.empno = m.mgr_id
group by e.empno, e.ename
having count(*) > 2;




