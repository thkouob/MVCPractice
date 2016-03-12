<Query Kind="Statements">
  <Connection>
    <ID>49f26c40-44f2-4f2b-ab8f-59bade78d1cd</ID>
    <Persist>true</Persist>
    <Server>.\sqlexpress</Server>
    <Database>Northwind</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

// 取得 ProductName 名稱
// 條件：銷售或購買的人是居住在 "London"
// Table：Employees, Customers, Orders, OrderDetails, Products
// LINQ：Union or join


//Employees.Dump();
//Customers.Dump();
//Orders.Dump();
//OrderDetails.Dump();
//Products.Dump();


var query = (from E in Employees.Where(E => E.City == "London")
			from O in E.Orders
			from D in O.OrderDetails
			join P in Products on D.ProductID equals P.ProductID
			select new { P.ProductName })
			.Union(
			from C in Customers.Where( C => C.City == "London" )
			from O in C.Orders
			from D in O.OrderDetails
			join P in Products on D.ProductID equals P.ProductID
			select new { P.ProductName }).Distinct();

query.Dump();


