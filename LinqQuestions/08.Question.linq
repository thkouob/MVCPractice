<Query Kind="Statements">
  <Connection>
    <ID>49f26c40-44f2-4f2b-ab8f-59bade78d1cd</ID>
    <Persist>true</Persist>
    <Server>.\sqlexpress</Server>
    <Database>Northwind</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

// 取得 Customers 的 CompanyName，Products 的 ProductName 和 Suppliers 的 CompanyName 名稱。
// 條件：
// 1. Customers 居住在 "London"
// 2. Suppliers 名稱是 "Pavlova, Ltd." 或 "Karkki Oy"
// Table：Suppliers, Products, OrderDetails, Orders, Customers
// LINQ：join, Distinct()

Suppliers.Dump();
Products.Dump();
OrderDetails.Dump();
Orders.Dump();
Customers.Dump();

var suppliers = (from s in Suppliers
select new { MgrId = s.SupplierID, MgrCompanyName = s.CompanyName}).DefaultIfEmpty();

var result = from s in Suppliers
join p in Products on s.SupplierID equals p.SupplierID
join d in OrderDetails on p.ProductID equals d.ProductID
join o in Orders on d.OrderID equals o.OrderID
join c in Customers on o.CustomerID equals c.CustomerID
join u in suppliers on s.SupplierID equals u.MgrId
where (s.CompanyName == "Pavlova, Ltd." || s.CompanyName == "Karkki Oy") && c.City == "London"
select new {c.CompanyName, p.ProductName, u.MgrCompanyName};

var query = (from r in result
select r).Distinct();

query.Dump();