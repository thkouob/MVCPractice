<Query Kind="Statements">
  <Connection>
    <ID>49f26c40-44f2-4f2b-ab8f-59bade78d1cd</ID>
    <Persist>true</Persist>
    <Server>.\sqlexpress</Server>
    <Database>Northwind</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

// 取得 Employees 的 name, address, city 和 region。
// 條件：超過 65 歲（BirthDate）
// Table：Employees
// Tip：http://mvc.tw/002n

//Employees.Dump();
//where (DateTime.Today.Year-65) < ((DateTime)c.BirthDate).Year

var result = from c in Employees
			 where ((DateTime)c.BirthDate).AddYears(65) <= DateTime.Today
			 select new { c.FirstName, c.LastName, c.Address, c.City, c.Region};	 
result.Dump();