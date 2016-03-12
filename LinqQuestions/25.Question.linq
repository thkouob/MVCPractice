<Query Kind="Statements">
  <Connection>
    <ID>49f26c40-44f2-4f2b-ab8f-59bade78d1cd</ID>
    <Persist>true</Persist>
    <Server>.\sqlexpress</Server>
    <Database>Northwind</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

// 取得 Employees 姓名（FirstName, LastName）。
// 條件：售出的產品中超過 26 家供應商。
// Table：Employees、Orders、OrderDetails
// LINQ Keywork：.Distinct()、.Count()

Orders.Dump();
OrderDetails.Dump();