use PracticaSQL
go

--Ejercicio 1
select	ID, 
		LAST_NAME as Apellido, 
		SALARY as Salario, 
		HIRE_DATE as 'Fecha de contratación' 
from Test.EMPLOYEES 

--Ejercicio 2/3
select	ID, 
		LAST_NAME as Apellido, 
		SALARY * 12 as 'Sueldo Anual', 
		HIRE_DATE as 'Fecha de contratación' 
from Test.EMPLOYEES 

--Ejercicio 4
select	ID, 
		FIRST_NAME + ' || ' + LAST_NAME as 'Nombre y Apellido', 
		SALARY * 12 as 'Salario Anual', 
		HIRE_DATE as 'Fecha de contratación' 
from Test.EMPLOYEES 

--Ejercicio 5.a
select	e.FIRST_NAME + ' ' + e.LAST_NAME as 'Nombre y Apellido',  
		d.DEPARTMENT_NAME 'Departamento'
from Test.EMPLOYEES e join TEST.DEPARTMENTS d on e.DEPARTMENT_ID = d.ID

--Ejercicio 5.b
select	distinct e.FIRST_NAME + ' ' + e.LAST_NAME as 'Nombre y Apellido',  
		d.DEPARTMENT_NAME 'Departamento'
from Test.EMPLOYEES e join TEST.DEPARTMENTS d on e.DEPARTMENT_ID = d.ID

--Ejercicio 6
select	FIRST_NAME as 'Nombre', 
		LAST_NAME as 'Apellido', 
		SALARY as 'Salario '
from test.employees 
where salary < 2000

--Ejercicio 7 
select	FIRST_NAME as 'Nombre', 
		LAST_NAME as 'Apellido', 
		SALARY as 'Salario '
from test.employees 
where salary between 1800 and 3000

--Ejercicio 8
select	FIRST_NAME as 'Nombre', 
		LAST_NAME as 'Apellido', 
		DEPARTMENT_ID as 'Número de departamento'
from test.employees 
where DEPARTMENT_ID in (10,30,31)

--Ejercicio 9
select	FIRST_NAME + ' ' + LAST_NAME as 'Nombre y Apellido', 
		SALARY as 'Salario'
from test.EMPLOYEES 
where LAST_NAME like 'f%'

--Ejercicio 10.a
select	FIRST_NAME + ' ' + LAST_NAME as 'Nombre y Apellido', 
		SALARY as 'Salario', 
		JOB_ID from TEST.EMPLOYEES
where JOB_ID is null

--Ejercicio 10.b
select	FIRST_NAME + ' ' + LAST_NAME as 'Nombre y Apellido', 
		SALARY as 'Salario', 
		JOB_ID from TEST.EMPLOYEES
where JOB_ID is not null

--Ejercicio 11/12
select	FIRST_NAME + ' ' + LAST_NAME as 'Nombre y Apellido', 
		SALARY as 'Salario', 
		JOB_ID 
from Test.employees where (JOB_ID like '%AD_CTB%' or JOB_ID like '%FQ_GRT%') and SALARY > 1900

--Ejercicio 13
select	FIRST_NAME + ' ' + LAST_NAME as 'Nombre y Apellido', 
		HIRE_DATE as 'Fecha de Ingreso'
from TEST.EMPLOYEES order by [Fecha de Ingreso] asc

--Ejercicio 14
select	FIRST_NAME + ' ' + LAST_NAME as 'Nombre y Apellido', 
		HIRE_DATE as 'Fecha de Ingreso'
from TEST.EMPLOYEES 
order by [Fecha de Ingreso] desc, LAST_NAME asc

--Ejercicio 15/16
select	LAST_NAME as 'Apellido', 
		SALARY * 12 as 'Salario Anual' 
from test.employees
order by [Salario Anual] asc

--Ejercicio 17 
select	e.FIRST_NAME + ' ' + e.LAST_NAME as 'Nombre y Apellido',  
		d.DEPARTMENT_NAME 'Departamento',
		d.DEPARTMENT_DESCRIPTION 'Descripción de Departamento'
from Test.EMPLOYEES e join TEST.DEPARTMENTS d on e.DEPARTMENT_ID = d.ID



--Ejercicio 18 
select * from test.employees e
select e.FIRST_NAME + ' ' + e.LAST_NAME as 'Nombre y Apellido',  
		d.DEPARTMENT_NAME 'Departamento',
		d.DEPARTMENT_DESCRIPTION 'Descripción de Departamento'
from test.EMPLOYEES e left join TEST.DEPARTMENTS d on e.DEPARTMENT_ID = d.ID

--Ejercicio 19
select	e.FIRST_NAME + ' ' + e.LAST_NAME as 'Nombre y Apellido',  
		d.DEPARTMENT_NAME 'Departamento',
		d.DEPARTMENT_DESCRIPTION 'Descripción de Departamento'
from TEST.DEPARTMENTS d left join test.EMPLOYEES e on d.ID = e.DEPARTMENT_ID

--Ejercicio 20
select distinct	e.FIRST_NAME + ' ' + e.LAST_NAME as 'Nombre y Apellido', 
				m.MANAGER_ID 
from TEST.EMPLOYEES e left join test.employees m on e.id = m.manager_id where m.MANAGER_ID is not null

--Ejercicio 21
select
		MIN(SALARY) as 'Salario Mínimo Total',
		MAX(SALARY) as 'Salario Máximo Total',
		AVG(SALARY) as 'Salario Promedio Total',
		SUM(SALARY) as 'Salario Total',
		count(salary) as 'Cantidad de Salarios'
from test.employees 

--Ejercicio 22 (Debido al tipo de dato datetime, no podemos utilizar funciones de agregado)
select
		MIN(hire_date) as 'Fecha de Contratación Mínima',
		MAX(hire_date) as 'Fecha de Contratación Máxima',
		AVG(hire_date) as 'Fecha de Contratación Promedio',
		SUM(hire_date) as 'Fecha de Contratación Total'
from test.employees

--Ejercicio 23
select	d.DEPARTMENT_NAME as 'Departamento',
		COUNT(e.ID) as 'Cantidad de empleados'
	from test.departments d join test.employees e on d.ID = e.DEPARTMENT_ID
group by d.DEPARTMENT_NAME

--Ejercicio 24
select	d.DEPARTMENT_NAME as 'Departamento',
		j.JOB_NAME as 'Puesto',
		count(j.ID) as 'Cantidad de empleados por Puesto'
	from test.employees e join test.jobs j on j.id = e.job_id join TEST.DEPARTMENTS d on e.DEPARTMENT_ID = d.ID
group by j.JOB_NAME,d.DEPARTMENT_NAME

--Ejercicio 25
select	d.[DEPARTMENT_NAME] as Departamento,
		avg(e.salary) as 'Salario Promedio'
from test.employees e join test.departments d on e.department_id = d.id
group by d.[DEPARTMENT_NAME]
having avg(e.salary) < 1200

--Ejercicio 26
insert into Test.Employees(ID,FIRST_NAME, LAST_NAME, SALARY, DEPARTMENT_ID, JOB_ID, HIRE_DATE, MANAGER_ID) 
values(20, 'Federico', 'Gordillo', 1450.00,10, 'FQ_GRT', '2008-10-01 00:00:00.000', 1)

--Ejercicio 27/28 (Campos obligatorios: ID, FIRST_NAME, LAST_NAME, HIRE_DATE)
insert into Test.Employees(ID,FIRST_NAME, LAST_NAME,  DEPARTMENT_ID, HIRE_DATE) 
values(22, 'Juan', 'Férnandez', 10, '2008-10-01 00:00:00.000')

--Ejercicio 29
update test.employees set First_name = 'Boulettte', Last_Name = 'Gustavo', SALARY = SALARY + 200 where ID = (select ID from TEST.EMPLOYEES where FIRST_NAME ='Gustavo' and LAST_NAME = 'Boulette')

--Ejercicio 30
update TEST.EMPLOYEES set SALARY = 1100 where ID = 10

--Ejercicio 30.1
update test.employees set SALARY = SALARY * 1.1 where DEPARTMENT_ID = 40  

--Ejercicio 30.2
delete test.departments where id > (select ID from TEST.DEPARTMENTS where ID > 50)

--Ejercicio 30.3
delete test.departments where id = 40

--Ejercicio 31.2
create table [TEST].Auditoria(
ID int identity not null,
Operacion varchar(max),
Fecha datetime
constraint pk_auditoria primary key(ID)
)
