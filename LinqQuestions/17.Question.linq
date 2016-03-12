<Query Kind="Statements">
  <Connection>
    <ID>fef49cf6-f097-46a8-a8fe-8b2b4ee42639</ID>
    <Persist>true</Persist>
    <Server>bruce</Server>
    <Database>Northwind</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

// 取得所有 Customers 的 CustomerID, CompanyName。
// 條件：Customers 買了相同產品且 CustomerID 都是 "LAZYK"
// Table：Customers, Orders, OrderDetails
// LINQ：Except()
// Tips：
// where !allProdsLazyk.Except(allProdsCustomer).Any()
// where !allProdsCustomer.Except(allProdsLazyk).Any()
// 注意，Northwind 未含有符合本題意之資料。return 0 items。