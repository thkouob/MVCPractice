<Query Kind="Statements">
  <Connection>
    <ID>fef49cf6-f097-46a8-a8fe-8b2b4ee42639</ID>
    <Persist>true</Persist>
    <Server>bruce</Server>
    <Database>Northwind</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

// Give the name of customers who bought exactly the same products as 
// the company whose identifier is ‘LAZYK’

// 取得所有 Customers 的 CustomerID, CompanyName。
// 條件：Customers 買了相同產品且 CustomerID 都是 "LAZYK"
// Table：Customers, Orders, OrderDetails
// LINQ：Except()
// Tips：
// where !allProdsLazyk.Except(allProdsCustomer).Any()
// where !allProdsCustomer.Except(allProdsLazyk).Any()

var query = from c in Customers
			where c.CustomerID != "LAZYK"
			let allProdsCustomer =
					from o in c.Orders
					from d in o.OrderDetails
					select d.ProductID
			let allProdsLazyk =
					from c1 in Customers
					where c1.CustomerID == "LAZYK"
					from o1 in c1.Orders
					from d1 in o1.OrderDetails
					select d1.ProductID
			where !allProdsLazyk.Except(allProdsCustomer).Any()
			where !allProdsCustomer.Except(allProdsLazyk).Any()
			select new {c.CustomerID, c.CompanyName};

// return 0 items
query.Dump();