Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Data
Imports System.Data.OleDb

Namespace NwindDataAdapter
	Public Class NwindHelper
		Public Shared Function GetInvoices(ByVal fileName As String) As DataTable
			Dim dataTableInvoices As New DataTable()
			Using connection As OleDbConnection = GetConnection(fileName)
				Dim adapter As New OleDbDataAdapter(String.Empty, connection)
				adapter.SelectCommand.CommandText = "SELECT * FROM [Invoices] WHERE OrderDate < #06/06/1995# "
				adapter.Fill(dataTableInvoices)
			End Using
			Return dataTableInvoices
		End Function

		Private Shared Function GetConnection(ByVal fileName As String) As OleDbConnection
			Dim connection As New OleDbConnection()
			'Jet 4
			'connection.ConnectionString = string.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0}", fileName));
			'OLEDB 12
			connection.ConnectionString = String.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0}", fileName)
			Return connection
		End Function


	End Class


End Namespace