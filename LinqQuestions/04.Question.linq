<Query Kind="Statements">
  <Connection>
    <ID>49f26c40-44f2-4f2b-ab8f-59bade78d1cd</ID>
    <Persist>true</Persist>
    <Server>.\sqlexpress</Server>
    <Database>Northwind</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

// 取得 Employees 的 Name、Address、City、Region
// 條件：完成出貨（ShipCountry）至 "Belgium" 的訂單。
// Table：Employees, Orders
// LINQ：join
// Tip: 可用 from ~ from，也可用 join。


//Employees.Dump();

var result = from c in Employees
			 from o in c.Orders
			 where o.ShipCountry == "Belgium"
			 select new { c.FirstName, c.LastName, c.Address, c.City, c.Region};
			 
result.Dump();