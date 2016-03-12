<Query Kind="Statements">
  <Connection>
    <ID>49f26c40-44f2-4f2b-ab8f-59bade78d1cd</ID>
    <Persist>true</Persist>
    <Server>.\sqlexpress</Server>
    <Database>Northwind</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

// 取得 Employees 的 FirstName, LastName, HireDate（年資）。
// 條件：找出所有 Employees 裡年資比居住在 "London" 的員工年資最資深還資深的人
// Table：Employees
// LINQ：Min()
// Tip："London" 最資深是 1993/10/17 上午 12:00:00 這一位

var result2 = from e in Employees
where e.City == "London"
select e;

var minValue = result2.Min(x => x.HireDate);

var query2 = from q in Employees
where q.HireDate < minValue
select new {q.FirstName, q.LastName, q.HireDate};

query2.Dump();