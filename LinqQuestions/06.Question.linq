<Query Kind="Statements">
  <Connection>
    <ID>49f26c40-44f2-4f2b-ab8f-59bade78d1cd</ID>
    <Persist>true</Persist>
    <Server>.\sqlexpress</Server>
    <Database>Northwind</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

// 取的 Employees 的 Title, FirstName, LastName
// 條件：至少銷售過一個 "Gravad Lax" 或 "Mishi Kobe Niku" 產品（ProductName）
// Table：Employees, Orders, OrderDetails, Products
// LINQ：join, Distinct()

//Employees.Dump();
//Orders.Dump();
//OrderDetails.Dump();
//Products.Dump();

var result = from e in Employees
join o in Orders on e.EmployeeID equals o.EmployeeID
join d in OrderDetails on o.OrderID equals d.OrderID
join p in Products on d.ProductID equals p.ProductID
where p.ProductName == "Gravad Lax" || p.ProductName == "Mishi Kobe Niku"
select new {e.Title, e.FirstName, e.LastName};

var query = (from r in result
select r).Distinct();

query.Dump();