<Query Kind="Statements">
  <Connection>
    <ID>49f26c40-44f2-4f2b-ab8f-59bade78d1cd</ID>
    <Persist>true</Persist>
    <Server>.\sqlexpress</Server>
    <Database>Northwind</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

// 取得所有 Employees 所銷售的產品的 ProductName。
// Table：Products, OrderDetails, Orders, Employees
// LINQ：Except(), Any()
//Employees.Dump();

var query = from p in Products
			let allEmployees = from e in Employees
							  select e.EmployeeID
			where !allEmployees.Except(from d in p.OrderDetails
							  join o in Orders on d.OrderID equals o.OrderID
							  join e in Employees on o.EmployeeID equals e.EmployeeID
							  select e.EmployeeID).Any()
			select new{p.ProductName};
									  
query.Dump();