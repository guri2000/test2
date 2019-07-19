<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PopUp.aspx.cs" Inherits="PopUp" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
     <asp:ScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ScriptManager>
    <div>
    <telerik:RadNotification EnableRoundedCorners="true" ID="radMessage" Position="BottomCenter" EnableShadow="true" Text="" Title=""  Height="100" runat="server">
        
        </telerik:RadNotification>
    </div>
    </form>
</body>
</html>
