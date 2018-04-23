Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Linq
Imports System.Windows.Forms
Imports DevExpress.XtraEditors
Imports DevExpress.DashboardWin
Imports DevExpress.DashboardCommon
Imports DevExpress.DataAccess.ConnectionParameters

Namespace WinFormsProject
	Partial Public Class ViewerForm
		Inherits DevExpress.XtraEditors.XtraForm
		Public Sub New()
			InitializeComponent()
		End Sub
		Public Sub New(ByVal fileName As String)
			Me.New()
			dashboardViewer1.LoadDashboard(fileName)
		End Sub

		Private nwindFileName As String = "../../../nwind.mdb"
        Private Sub dashboardViewer1_ConfigureDataConnection(ByVal sender As Object, ByVal e As DashboardConfigureDataConnectionEventArgs) Handles dashboardViewer1.ConfigureDataConnection
            Select Case e.ConnectionName
                Case "nwindConnection"
                    Dim access As Access97ConnectionParameters = TryCast(e.ConnectionParameters, Access97ConnectionParameters)
                    If access IsNot Nothing Then
                        access.FileName = nwindFileName
                    End If
            End Select
        End Sub


		Private Sub UpdateDashboard(ByVal dashboard As Dashboard)
			dashboard.DataSources.Clear()
			Dim invoiceDataSource As New DataSource("RuntimeInvoices")
			dashboard.DataSources.Add(invoiceDataSource)
			For Each item In dashboard.Items.Where(Function(i) TryCast(i, DataDashboardItem) IsNot Nothing).Cast(Of DataDashboardItem)()
				item.DataSource = invoiceDataSource
			Next item
		End Sub

        Private Sub dashboardViewer1_DataLoading(ByVal sender As Object, ByVal e As DataLoadingEventArgs) Handles dashboardViewer1.DataLoading
            If e.DataSourceName = "RuntimeInvoices" Then
                e.Data = NwindDataAdapter.NwindHelper.GetInvoices(nwindFileName)
            End If
        End Sub



        Private Sub dashboardViewer1_DashboardLoaded(sender As Object, e As DashboardLoadedEventArgs) Handles dashboardViewer1.DashboardLoaded
            Dim viewer As DashboardViewer = CType(sender, DashboardViewer)
            UpdateDashboard(viewer.Dashboard)
        End Sub
    End Class
End Namespace