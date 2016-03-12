<Query Kind="Statements">
  <Connection>
    <ID>49f26c40-44f2-4f2b-ab8f-59bade78d1cd</ID>
    <Persist>true</Persist>
    <Server>.\sqlexpress</Server>
    <Database>Northwind</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

// 取得沒有購買任何產品的 Customers 的 CompanyName。
// Table：Orders, CompanyName
// LINQ：Count() or Any()

Orders.Dump();
Customers.Dump();

var result = from c in Customers
select new {Id = c.CustomerID, Order = c.Orders};

var query = from c in Customers
join r in result on c.CustomerID equals r.Id
where r.Order.Count() == 0
select new {c.CompanyName};
query.Dump();

