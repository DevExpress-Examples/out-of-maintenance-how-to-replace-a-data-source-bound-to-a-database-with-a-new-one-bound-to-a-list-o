Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports DevExpress.DataAccess.ConnectionParameters
Imports DevExpress.DashboardCommon

Namespace AspProject
	Partial Public Class [Default]
		Inherits System.Web.UI.Page
		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)

		End Sub

		Protected Sub ASPxDashboardViewer1_ConfigureDataConnection(ByVal sender As Object, ByVal e As DevExpress.DashboardWeb.ConfigureDataConnectionWebEventArgs)
			Select Case e.ConnectionName
				Case "nwindConnection"
					Dim access As Access97ConnectionParameters = TryCast(e.ConnectionParameters, Access97ConnectionParameters)
					If access IsNot Nothing Then
						access.FileName = Server.MapPath("~/App_Data/nwind.mdb")
					End If
			End Select
		End Sub

		Protected Sub ASPxDashboardViewer1_DashboardLoaded(ByVal sender As Object, ByVal e As DevExpress.DashboardWeb.DashboardLoadedWebEventArgs)
			e.Dashboard.DataSources.Clear()
			Dim invoiceDataSource As New DataSource("RuntimeInvoices")
			e.Dashboard.DataSources.Add(invoiceDataSource)
			For Each item In e.Dashboard.Items.Where(Function(i) TryCast(i, DataDashboardItem) IsNot Nothing).Cast(Of DataDashboardItem)()
				item.DataSource = invoiceDataSource
			Next item
		End Sub

		Protected Sub ASPxDashboardViewer1_DataLoading(ByVal sender As Object, ByVal e As DevExpress.DashboardWeb.DataLoadingWebEventArgs)
			If e.DataSourceName = "RuntimeInvoices" Then
				e.Data = NwindDataAdapter.NwindHelper.GetInvoices(Server.MapPath("~/App_Data/nwind.mdb"))
			End If
		End Sub
	End Class
End Namespace