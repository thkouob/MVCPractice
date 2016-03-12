<Query Kind="Statements">
  <Connection>
    <ID>49f26c40-44f2-4f2b-ab8f-59bade78d1cd</ID>
    <Persist>true</Persist>
    <Server>.\sqlexpress</Server>
    <Database>Northwind</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

// 取得 Employees 的 FirstName, LastName, City
// 條件：Employees 居住的 City 與 Employees 銷售給 Customers 的 City 是同一個。
// Table：Employees, Orders
// LINQ：Distinct()

Employees.Dump();
Orders.Dump();

var result = from e in Employees
join o in Orders on e.EmployeeID equals o.EmployeeID
join c in Customers on o.CustomerID equals c.CustomerID
where e.City == c.City
select new {e.FirstName, e.LastName, e.City};

var query = (from r in result
select r).Distinct();

query.Dump();