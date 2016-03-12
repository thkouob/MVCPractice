<Query Kind="Statements">
  <Connection>
    <ID>49f26c40-44f2-4f2b-ab8f-59bade78d1cd</ID>
    <Persist>true</Persist>
    <Server>.\sqlexpress</Server>
    <Database>Northwind</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

// 取得Suppliers 的 SupplierID、CompanyName。
// 條件：當此 Suppliers 提供超過三種產品時。
// Table：Suppliers、Products
// LINQ Keyword：Count()


Suppliers.Dump();

var result = from  p in Products
group p by p.SupplierID into subGrp
select new {Key = subGrp.Key, Count = subGrp.Count()};

var query = from q in Suppliers
join r in result on q.SupplierID equals r.Key
where r.Count > 3
select new {q.SupplierID, q.CompanyName};

query.Dump();