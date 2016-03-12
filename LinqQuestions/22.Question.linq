<Query Kind="Statements">
  <Connection>
    <ID>49f26c40-44f2-4f2b-ab8f-59bade78d1cd</ID>
    <Persist>true</Persist>
    <Server>.\sqlexpress</Server>
    <Database>Northwind</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

// 取得 Employees 的 EmployeeID、FirstName、LastName，還有此員工售出的不重覆產品數量。
// 使用 EmployeeID 進行排序。
// Table：Employees、Orders、OrderDetails
// LINQ Keyword：Distinct()、Count()


//Orders.Dump();
//Employees.Dump();

var query = from e in Employees
select new {
e.EmployeeID, 
e.FirstName, 
e.LastName,
ProductCount = (from o in Orders
				join d in OrderDetails on o.OrderID equals d.OrderID
				where o.EmployeeID == e.EmployeeID
				select d.Product).Distinct().Count()
};

query.Dump();
