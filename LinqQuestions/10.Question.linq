<Query Kind="Statements">
  <Connection>
    <ID>49f26c40-44f2-4f2b-ab8f-59bade78d1cd</ID>
    <Persist>true</Persist>
    <Server>.\sqlexpress</Server>
    <Database>Northwind</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

// 取得 Employees 的 FirstName, LastName, BirthDate。

// 第一題
// 條件(a)：找出所有 Employees 裡年紀比【居住在 "London" 的員工年紀中最年輕的人】還大的人
// Table：Employees
// LINQ：Max()
// Tip："London" 最年輕是 1966/1/27 上午 12:00:00 這一位



// 第二題
// 條件(b)：找出所有 Employees 裡年紀比【居住在 "London" 的員工年紀最年長的人】還大的人
// Table：Employees
// LINQ：Min()
// Tip："London" 最年長是 1955/3/4 上午 12:00:00 這一位


//Employees.Dump();

//1
var result1 = from e in Employees
where e.City == "London"
select e;

var maxValue = result1.Max(x => x.BirthDate);

var query1 = from q in Employees
where q.BirthDate < maxValue
select new {q.FirstName, q.LastName, q.BirthDate};

query1.Dump();

//2
var result2 = from e in Employees
where e.City == "London"
select e;

var minValue = result2.Min(x => x.BirthDate);

var query2 = from q in Employees
where q.BirthDate < minValue
select new {q.FirstName, q.LastName, q.BirthDate};

query2.Dump();


