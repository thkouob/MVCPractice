<Query Kind="Statements">
  <Connection>
    <ID>49f26c40-44f2-4f2b-ab8f-59bade78d1cd</ID>
    <Persist>true</Persist>
    <Server>.\sqlexpress</Server>
    <Database>Northwind</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

// 取得所有 Customers 的CustomerID、CompanyName。
// 條件：Customers 所有購買的產品裡有 CustomerID 是 "LAZYK"
// Table：Customers, Orders, OrderDetails
// LINQ：Except
// Tip：
// where !allProdsLazyk.Except(allProdsCustomer).Any()

//Customers.Dump();

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
			select new {c.CustomerID, c.CompanyName};
			
query.Dump();