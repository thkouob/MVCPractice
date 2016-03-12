<Query Kind="Statements">
  <Connection>
    <ID>49f26c40-44f2-4f2b-ab8f-59bade78d1cd</ID>
    <Persist>true</Persist>
    <Server>.\sqlexpress</Server>
    <Database>Northwind</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

// 取得產品類別在每一分類的平均價格。
// Table：Products, Categories
// LINQ Keyword：join, group, Average()

// Tip：
// Average(c =&gt; c.UnitPrice)

Categories.Dump();

var result = from p in Products
			group p by p.CategoryID into subGrp
			select new {Key = subGrp.Key, AvgPrice = subGrp.Average(c => c.UnitPrice)};
			
var query = from c in Categories
join r in result on c.CategoryID equals r.Key
select new {c.CategoryName, r.AvgPrice};
		
			
query.Dump();