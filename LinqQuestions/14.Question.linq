<Query Kind="Statements">
  <Connection>
    <ID>49f26c40-44f2-4f2b-ab8f-59bade78d1cd</ID>
    <Persist>true</Persist>
    <Server>.\sqlexpress</Server>
    <Database>Northwind</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

// 取得所有 Customers 的CustomerID, CompanyName。
// 條件：客戶所買的產品中有價格低於 5 元。
// Table：Customers, Products
// LINQ：Except(), Any()

var query = from c in Customers
			let allProducts = from P in Products.Where(P => P.UnitPrice < 5) 
							  select P.ProductID
			where !allProducts.Except(from o in c.Orders
									  from d in o.OrderDetails
									  select d.ProductID).Any()
			select new{c.CustomerID, c.CompanyName};
									  
query.Dump();