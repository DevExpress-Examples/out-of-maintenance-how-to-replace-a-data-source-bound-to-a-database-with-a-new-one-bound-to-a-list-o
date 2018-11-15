<!-- default file list -->
*Files to look at*:

* [Default.aspx.cs](./CS/AspProject/Default.aspx.cs) (VB: [Default.aspx.vb](./VB/AspProject/Default.aspx.vb))
* [ViewerForm.cs](./CS/WinFormsProject/ViewerForm.cs) (VB: [ViewerForm.vb](./VB/WinFormsProject/ViewerForm.vb))
<!-- default file list end -->
# How to replace a data source bound to a database with a new one bound to a list of objects


<p>Update:<br>This example is now obsolete. Refer to the following examples demonstrating how to implement this functionality in the newer control versions:<br>WinForms: <a href="https://www.devexpress.com/Support/Center/p/T556647">T556647: How to replace DashboardSqlDataSource with DashboardObjectDataSource and filter loaded data manually</a><br>ASP.NET: <a href="https://www.devexpress.com/Support/Center/p/T556759">T556759: How to replace DashboardSqlDataSource with DashboardObjectDataSource and filter loaded data manually</a><br><br><br>This example demonstrates how to replace <a href="https://documentation.devexpress.com/Dashboard/clsDevExpressDashboardCommonDashboardSqlDataSourcetopic.aspx">Sql Data Source</a> with <a href="https://documentation.devexpress.com/Dashboard/clsDevExpressDashboardCommonDashboardObjectDataSourcetopic.aspx">Object Data Source</a> using the <a href="https://documentation.devexpress.com/#Dashboard/DevExpressDashboardWinDashboardViewer_DashboardLoadedtopic">DashboardLoaded</a> event. This approach can be used in WinForms, ASP.NET and MVC projects. Generally, all you need is to create a new data source and bind all existing items to it using the <a href="https://documentation.devexpress.com/#Dashboard/DevExpressDashboardCommonDataDashboardItem_DataSourcetopic">DataDashboardItem.DataSource Property</a>. It is necessary that data members of the new data source match data members of the old one.</p>

<br/>


