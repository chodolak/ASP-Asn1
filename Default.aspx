<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:TextBox ID="SearchBox" runat="server" Width="341px"></asp:TextBox>
        <asp:Button ID="SearchButton" runat="server" OnClick="SearchButton_Click" Text="Search" />
    
        <asp:Label ID="SearchCount" runat="server"></asp:Label>
        <asp:Button ID="Prev" runat="server" OnClick="Prev_Click" Text="Prev" />
        <asp:Button ID="Next" runat="server" OnClick="Next_Click" Text="Next" />
        <asp:Button ID="printButton" runat="server" Text="Print" OnClientClick="javascript:window.print();" OnClick="printButton_Click" style="height: 26px" />
    
        <asp:Button ID="Download" runat="server" OnClick="Download_Click" Text="Download" />
    
    </div>
        <asp:Label ID="Title" runat="server"></asp:Label>
        <p>
            <asp:Label ID="Text" runat="server"></asp:Label>
        </p>
    </form>
</body>
</html>
