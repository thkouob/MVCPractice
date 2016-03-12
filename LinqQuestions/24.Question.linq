<Query Kind="Statements">
  <Connection>
    <ID>49f26c40-44f2-4f2b-ab8f-59bade78d1cd</ID>
    <Persist>true</Persist>
    <Server>.\sqlexpress</Server>
    <Database>Northwind</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

// 1. 取得 Employees 的編號、姓名（Employees、LastName）還有此員工“銷售總額”。
// 2. 使用員工編號進行排序。
// 3. 誰已售出超過70種不同的產品。
// Table：Employees, Orders, OrderDetails
// LINQ Keyword：Distinct(), Count(), Sum()

var result = from o in Orders
			 from d in o.OrderDetails
			 let Total = System.Convert.ToDouble(d.UnitPrice) * d.Quantity * (1 - d.Discount) 
			 select new {Key = o.EmployeeID, Total = Total};
//result.Dump();

var query = from e in Employees
join r in result on e.EmployeeID equals r.Key into ODGroup
let Total = (from od in ODGroup
             select od.Total).Sum()
orderby e.EmployeeID
select new {e.EmployeeID, e.FirstName, e.LastName, Total};

//query.Dump();

var productquery = from e in Employees
select new {
e.EmployeeID, 
e.FirstName, 
e.LastName,
ProductCount = (from o in Orders
				join d in OrderDetails on o.OrderID equals d.OrderID
				where o.EmployeeID == e.EmployeeID
				select d.Product).Distinct().Count()
};

var final = from q in query
join p in productquery on q.EmployeeID equals p.EmployeeID
where p.ProductCount > 70
select new {q.EmployeeID, q.FirstName, q.LastName, q.Total};

final.Dump();