<%@ Page Language="vb" AutoEventWireup="true" CodeBehind="Default.aspx.vb" Inherits="AspProject.Default" %>

<%@ Register assembly="DevExpress.Dashboard.v14.1.Web, Version=14.1.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.DashboardWeb" tagprefix="dx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title></title>
</head>
<body>
	<form id="form1" runat="server">
	<div>

		<dx:ASPxDashboardViewer ID="ASPxDashboardViewer1" runat="server" 
			DashboardSource="~/Dashboards/Invoices.xml" FullscreenMode="True" 
			onconfiguredataconnection="ASPxDashboardViewer1_ConfigureDataConnection" 
			RegisterJQuery="True" 
			ondashboardloaded="ASPxDashboardViewer1_DashboardLoaded" 
			ondataloading="ASPxDashboardViewer1_DataLoading">
		</dx:ASPxDashboardViewer>

	</div>
	</form>
</body>
</html>