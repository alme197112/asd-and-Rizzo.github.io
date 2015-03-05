

SQL
===

SQL can update, delete, create databases, tables, rows.

SQL is case insensitive.

Next statements use Northwind database

You can get data
```
-- Retrieves all data rows from Customer table
SELECT * FROM Customers;
```

```
-- uses ; to execute 2 queires in one call do database
select * from Customers;
select * from Customers;

sql retunrs data into result table(result set)

We can filter what columns data to retrieve by name
```
select column_name, column_name
from table_name
```

```
select CustomerName, City from Customers
```

Most database allow navigation in resulted set.


```
-- allows to  eliminate return of duplicates on database server side before returning result set
select distinct city from customers
```

```
select *
from customers
-- allows return only records with specific criteria
-- where column_name operator value
where country = 'Mexico'
```

```
select *
from customers
-- combines several filter criteria
where country= 'Germany'  and (city = 'Berlin' or city = 'Leipzig')
```

Sorting result
```
select *
from customers
-- sort descending by contry
order by country DESC, 
-- then by name ascending
customername ASC
```

Adding new records/rows
---

```
-- will try to insert new row with 3 first columns data, but fail cause there are more columnts
insert into customers
values ('a', 'b', 'c')
```

```
-- will try to insert new row with only city specified
insert into customers (city)
values ('a')
```


```
-- changes existing row
update customers 
-- sets specified columnt to value - column selector
set country = 'hell'
-- is mostly must to aboid update all items - rows selector
where customerid = 13
```

Removing records/rows
---



```
-- delete rows
delete from customers
-- specified by clause
where city = 'Berlin'
```

Q:How can you remove one record from a table?
A: Use unique id


How to remove all records from a table?
```
--delete all rows
delete from customers
```

```
--delete all rows
delete * from customers
```

SQL injection
====

Q +  or 1 = 1
----
select * from customers where customerid = 
+
1 or 1 = 1
=
```
select * from customers where customerid = 1 or 1 = 1
```

Q + " or ""=""
---
Q + ` or ""=""

select * from customers where customername = 'Blauer See Delikatessen' and country = 'Germany'
select * from customers where customername = '' or ""="" and country = '' or ""=""


several statements via ;
---
select * from customers;
drop table customers

```
select * from customers; drop table customers
```

Avoid injection - use @ - parameters



```tsql
-- select only several rows
select top 2 * from customers;
select top 2 percent * from customers;
```

Pattern matching
```
select * from customers
where city 
-- starts with B and finished with any characters
like 'B%`
```

Wildcards
%lin    - any start any characters and ends with specified
_erling  - any start one and ends with specified
B_er_ing 
Ber%
Berli_
[bac]%  - starts from any of 3 characters
[!bac]% - not starts


Includes
```
select * from customers where city
in ('Paris','Berlin')
-- not in ('Paris','Berlin')
```

Range
```
select * from products 
where price 
between 10 and 20
-- not between 10 and 20
```



Aliases
---

- Columns

```
-- renames columns to better one
SELECT CustomerId as Id, CustomerName as [The Name]
FROM Customers;
```

```
-- not works....
select CustomerId, (CustomerName +', '+ City) as GeoName
from customers
```


Join(combine)
---
inner (simple) - at least one match in BOTH tables. If there is now match - not row will be resulted
inner join  = join

```
select Customers.CustomerId, Customers.CustomerName, Orders.OrderId, Orders.OrderDate
from Orders
inner join Customers
on Orders.CustomerId=Customers.CustomerId
```

left (outer) - all rows are returned from left table, if there is no match in right then NULL returned

select *
from left
left join on right
on join.Id = right.LeftIf

```
select Customers.CustomerName, Orders.OrderId
-- Customers is left
from Customers 
-- orders is right
left join orders
on orders.customerid = customers.customerid
order by customers.CustomerName
```


right (outer) - right is fully returned, left is NULL if no match
```
select Orders.OrderId, Customers.CustomerName
from Orders
right join customers
on orders.customerid = customers.customerid
```



full  - return all records, when there is no match on left or right - null returned
```
SELECT Customers.CustomerName, Orders.OrderID
FROM Customers
FULL OUTER JOIN Orders
ON Customers.CustomerID=Orders.CustomerID
ORDER BY Customers.CustomerName;
```

Union (set or bag of 2 tables)
---

```
-- select coulumn of customers
select City from Customers
union -- create set(distinct values) of 2 tables 
-- should have EXACTLY THE SAME COLUMNS
select City from Suppliers
```

```
union all -- create bag (with duplicates)
```


Copying and backup
---

Creates new table
```
select columns
into mytable [in mydatabase]
from  othertable
```

Copy just scheme - create new empty table
```
select columns
into mytable [in mydatabase]
from  othertable
where 1 = 2
```

Copy data into existing
```
insert into table2 [column name]
select * from table1
```

```
insert into customers (CustomerName, Country)
select SupplierName, Country from Suppliers
```


Creating if new databases and tables
---

```
create database mydb
```

```
create table mytable
(id int,
name varchar(100)
)
```





Q&A:
What parts SQL query consists of (i.e. SELECT then filed list, then FROM then table list and so on)
---
SELECT WHAT (all, specific)
FROM (existing table, joined table, view, alias tables, just tables, (SELECT) )
[JOIN ON]
[WHERE (filters of any kind)]
[ORDER BY]

Is it possible to put multiple table names in the FROM part of SQL query?
---
Yes, via join or several but joins is defined via where. Or via temporal selected table. SELECT * FROM (SELECT * FROM A).
```
select c.CustomerId, c.CustomerName, o.OrderId, o.OrderDate
-- shorthands access
from Customers as c, Orders as o
-- join
where c.customerid = o.customerid
```


```
select c.CustomerId, c.CustomerName, o.OrderId, o.OrderDate
-- shorthands access
from Customers as c, Orders as o
-- join
where c.customerid = o.customerid
```

```
select Customers.CustomerId, Customers.CustomerName, Orders.OrderId, Orders.OrderDate
-- 2 tables in from
from Customers, Orders 
-- join
where Customers.customerid = Orders.customerid
```

```
-- next query will return Cartesian product
select c.CustomerId, c.CustomerName, o.OrderId, o.OrderDate
from Customers as c, Orders as o
```


Q:What is a query plan? How can you get it from SQL Server?
A:
SQL is declarative. 
Many ways to execute the same statement (different order or algorithms).
Query plan is view of what is executed. 
Starts from data produced by parameterless query parts. Then data is feed into dependant query parts. Algorithms are named and shown.
http://en.wikipedia.org/wiki/Query_plan



Difference between HAVING and WHERE clause
---
HAVING is used with aggregate function, where cannot be used

```
CREATE TABLE Neuron (NeuronId int PRIMARY KEY, NeuronPotential decimal);
```


Q:What is a clustered (and a non-clustered) index?
A: Why clustered index is usually created over a Primary Key? Can it be created over any other field?
Index is logical.
Clustered index reorders real row data in database.
There can be only one Clustered Index to avoid data duplication.
Primary Keys have good properties to be used for Clustered Index. But Clustered Index can be created over other fields.

- What are the advantages and disadvantages of having GUID as a primary key in table?
GUID is 128 bit. Long integer is 64 bit. 
GUID useful to split unique data into several severs.

- DB dead-locks. How to avoid and now to fix when happen
First transaction locks for update table A then B.
Seconds transaction locks  for update B then A.
If First done with A and asks for B. B is still in Second Transaction. First waits.
If Second finishes with B and wants A. But A in scope of First transaction and cannot be changed until finishes.
Use the same order of updates.

- Is it possible to use aggregation functions without GROUP BY in SQL statement? E.g. SELECT a, SUM(b) FROM table
may be yes, but it will aggregate for all rows which is useless.

- Are indexes are always good?
If we update Indexed fields often then Indexes have to be recalculated then having index is bad. 

- What is normalization/denormalization? What are their purposes/goals?
Source code rule do not repeat yourself rule for database. 
- less size of database
- easier to support consistent updates and re factoring
- improves query performance because less size and *


Q: Given table
Id Name CityId
1  Bob     1
2  Alice   2
3  Jane    2
4  Cat     3

Select all with distinct cities.  There should be only one row resulted with CityId = 2. E.g. skip Jane because she repeats CityId 2. Use SQL. Do not retrieve data to client to filter in programming language.
You should get  like:
1  Bob     1
2  Alice   2
4  Cat     3

A:

SQL Server:

```
drop table persons;

create table persons
(
Id int Identity(1,1) PRIMARY KEY NOT NULL,
Name varchar(255),
CityId int
);

insert into persons values (1,'Bob',1);
insert into persons values (2,'Alice',2);
insert into persons values (3,'Jane',2);
insert into persons values (4,'Cat',3);
```

```
select * from persons
group by cityid -- unite on cityid, if 2 duplicates skip rest rows except 1
```

http://stackoverflow.com/questions/966176/select-distinct-on-one-column



Q: Given table with Id and Name. Calculate number of times Name is in table.
I.e. obtain next table

Name Count
Bob 1
Alice 3
Joe 2

A:

```
drop table persons;

create table persons
(
Id int Identity(1,1) PRIMARY KEY NOT NULL,
Name varchar(255)
)
insert into persons values (1,'Bob');
insert into persons values (1,'Alice');
insert into persons values (1,'Joe');
insert into persons values (1,'Alice');
insert into persons values (1,'Alice');
insert into persons values (1,'Joe');
```

```
SELECT Name, Count(Name) FROM Persons
group by Name
```






