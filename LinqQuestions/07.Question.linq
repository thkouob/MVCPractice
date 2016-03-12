<Query Kind="Statements">
  <Connection>
    <ID>49f26c40-44f2-4f2b-ab8f-59bade78d1cd</ID>
    <Persist>true</Persist>
    <Server>.\sqlexpress</Server>
    <Database>Northwind</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

// 取的 Employees 的 Title, FirstName, LastName
// 並找出所屬 ReportsTo（負責人、主管）的Title, FirstName, LastName
// Table：Employees
// LINQ：join, DefaultIfEmpty()


//Employees.Dump();

var query = (from e in Employees
select new { MgrId = e.EmployeeID, 
			MgrTitle = e.ReportsToEmployee.Title, 
			MgrFirstName = e.ReportsToEmployee.FirstName, 
			MgrLastName = e.ReportsToEmployee.LastName}).DefaultIfEmpty();

var result = from e in Employees
join rte in query on e.EmployeeID equals rte.MgrId
select new {e.Title, e.FirstName, e.LastName, rte.MgrTitle, rte.MgrFirstName, rte.MgrLastName};

result.Dump();