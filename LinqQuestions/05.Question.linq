<Query Kind="Statements">
  <Connection>
    <ID>49f26c40-44f2-4f2b-ab8f-59bade78d1cd</ID>
    <Persist>true</Persist>
    <Server>.\sqlexpress</Server>
    <Database>Northwind</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

// 取得 Employees 的FirstName, LastName 與 Customers 的 CompanyName
// 條件為：
// 1. 貨運商（Shippers）為的 CompanyName 為 "Speedy Express"
// 2. Customers 位於（City）"Bruxelles"
// Table：Employees, Orders, Customers, Shippers
// LINQ：join

//Customers.Dump();
//Shippers.Dump();
//Orders.Dump();
//Employees.Dump();


var result = from e in Employees
from o in e.Orders
join s in Shippers on o.ShipViaShipper.CompanyName equals "Speedy Express"
join c in Customers on o.Customer.City equals "Bruxelles"
where c.City == "Bruxelles"
where s.CompanyName == "Speedy Express"
select new {e.FirstName, e.LastName, o.Customer.CompanyName};

//var result = from e in Employees
//join o in Orders on e.EmployeeID equals o.EmployeeID
//join c in Customers on o.CustomerID equals c.CustomerID
//join s in Shippers on o.ShipViaShipper.CompanyName equals "Speedy Express"
//where c.City == "Bruxelles"
//where s.CompanyName == "Speedy Express"

//select new {e.FirstName, e.LastName, c.CompanyName};




result.Dump();