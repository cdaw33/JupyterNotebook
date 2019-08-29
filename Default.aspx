<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="webAppNotebook.Default" %>

<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:TextBox ID="textBox" runat="server" /><asp:Button ID="submitButton" runat="server" Text="Submit" OnClick="submitButton_Click" />
    <asp:Label ID="label1" runat="server" Text="Enter a year from 2015 to 2019" />
    </div>
        <div>
        <asp:Label ID="titleLabel" runat="server" Font-Size="X-Large" /><br/>
            
        <asp:Chart ID="Chart1" runat="server">
            <chartareas>
                <asp:ChartArea Name="ChartArea1">
                </asp:ChartArea>
            </chartareas>
        </asp:Chart>
        </div>
        <br />
        <div>
        <asp:Label runat="server" Text="Crimes Commited in Years" Font-Size="X-Large" /><br/>
        <asp:Chart ID="Chart2" runat="server">
            <chartareas>
                <asp:ChartArea Name="ChartArea1">
                </asp:ChartArea>
            </chartareas>
        </asp:Chart>
        </div>
        <div><asp:Label runat="server" Text="Crimes commited by district" Font-Size="X-Large" /><br />
        <asp:Chart ID="Chart3" runat="server">
            <chartareas>
                <asp:ChartArea Name="ChartArea1">
                </asp:ChartArea>
            </chartareas>
        </asp:Chart>
        </div>
    </form>
</body>
</html>
