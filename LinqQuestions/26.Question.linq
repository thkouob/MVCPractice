<Query Kind="Statements">
  <Connection>
    <ID>49f26c40-44f2-4f2b-ab8f-59bade78d1cd</ID>
    <Persist>true</Persist>
    <Server>.\sqlexpress</Server>
    <Database>Northwind</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

// 取得 Customers 的 CompanyName 與 ProductName。
// 條件：找出單一個訂單中客戶購買此產品的數量是大於單一個訂單所有客戶購買此產品的平均數量 5 倍。
// Table：Customers、Orders、OrderDetails
// Linq Keyword：Cast&lt;int&gt;()、Average()

// Tip:
// (from d1 in OrderDetails
// where d1.ProductID == p.ProductID
// select d1.Quantity).Cast&lt;int&gt;().Average()