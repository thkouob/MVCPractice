<Query Kind="Statements">
  <Connection>
    <ID>49f26c40-44f2-4f2b-ab8f-59bade78d1cd</ID>
    <Persist>true</Persist>
    <Server>.\sqlexpress</Server>
    <Database>Northwind</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

// 取得 Employees 的 name, address, city, region。
//Employees.Dump();

var result = from c in Employees
			 select new { c.FirstName, c.LastName, c.Address, c.City, c.Region };	 
result.Dump();