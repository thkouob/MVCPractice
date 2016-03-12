<Query Kind="Statements">
  <Connection>
    <ID>49f26c40-44f2-4f2b-ab8f-59bade78d1cd</ID>
    <Persist>true</Persist>
    <Server>.\sqlexpress</Server>
    <Database>Northwind</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

// 1. 取得 Employees 的 EmployeeID、FirstName、LastName，還有每個員工的訂單總數量。
// 2. 使用員工編號進行排序。
// Table：Employees、Orders
// LINQ Keyword：Count()

Employees.Dump();

var result = from o in Orders
group o by o.EmployeeID into subGrp
select new {Key = subGrp.Key, Count = subGrp.Count()};

var query = from e in Employees
join r in result on e.EmployeeID equals r.Key
orderby e.EmployeeID
select new {e.EmployeeID, e.FirstName, e.LastName, r.Count};

query.Dump();