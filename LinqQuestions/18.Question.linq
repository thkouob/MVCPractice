<Query Kind="Statements">
  <Connection>
    <ID>49f26c40-44f2-4f2b-ab8f-59bade78d1cd</ID>
    <Persist>true</Persist>
    <Server>.\sqlexpress</Server>
    <Database>Northwind</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

// 按照產品的類別提供產品的平均價格。
// Table：Products
// LINQ：group, Average()
// Tip：Average(c => c.UnitPrice)

//Products.Dump();

var result = from p in Products
			group p by p.CategoryID into subGrp
			select new {Key = subGrp.Key, AvgPrice = subGrp.Average(c => c.UnitPrice)};
		
			
result.Dump();
			