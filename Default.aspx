<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <!--Import materialize.css-->
    <link type="text/css" rel="stylesheet" href="Content/css/materialize.min.css"  media="screen,projection"/>
</head>
<body>
    <form id="form1" runat="server">
        
        <%--Logo and Nav--%>
        <nav class="light-blue lighten-1" role="navigation">
            <div class="container">
              <div class="nav-wrapper"><a id="logo-container" href="#" class="brand-logo" style="padding-top: 5px;">
                  <img src="Content/image/bcitsearchstar.png" style="width: 50px;"/>
              </a></div>
            </div>
        </nav>
        
        <%--Main--%>
        <div class="container">
        
            <div class="section">
            
                <div class="row">
                    <%--Search--%>
                    <div class="col s12 m10 l10">
                        <asp:TextBox ID="SearchBox" runat="server" placeholder="Enter query here" ></asp:TextBox>
                    </div>
                    <div class="col s12 m2 l2 right">
                        <asp:Button ID="SearchButton" runat="server" OnClick="SearchButton_Click" Text="Search" CssClass="btn" />
                    </div>
                </div>

                <div class="row">
                    <%--Document Navigation--%>
                    <div class="col s12 m12 l12">
                        <asp:LinkButton ID="First" runat="server" OnClick="First_Click" CssClass="btn" ToolTip="First" Visible="False" ><i class="mdi-navigation-arrow-back"></i></asp:LinkButton>
                        <asp:LinkButton ID="Prev" runat="server" OnClick="Prev_Click" CssClass="btn" ToolTip="Previous" Visible="False" ><i class="mdi-navigation-chevron-left"></i></asp:LinkButton>
                        <asp:LinkButton ID="Next" runat="server" OnClick="Next_Click" CssClass="btn" ToolTip="Next" Visible="False" ><i class="mdi-navigation-chevron-right"></i></asp:LinkButton>
                        <asp:LinkButton ID="Last" runat="server" OnClick="Last_Click" CssClass="btn" ToolTip="Last" Visible="False" ><i class="mdi-navigation-arrow-forward"></i></asp:LinkButton>
                    </div>
                </div>
            
                <%--Document name and number of results--%>
                <div class="row">
                    <div class="col s12 m10 l10">
                        <asp:Label ID="Title" runat="server" Visible="False" ></asp:Label>
                    </div>
                    <div class="col s12 m2 l2 right right-align">
                        <asp:Label ID="SearchCount" runat="server" Visible="False" ></asp:Label>
                    </div>
                </div>
                <div id="divider" class="divider"></div>

            </div>

            <div class="section">
            
                <%--Document Content--%>
                <div class="row">
                    <div class="col s12 m12 l12">
                        <asp:Label ID="Text" runat="server"></asp:Label>
                    </div>
                </div>
            
                <%--Print and Download--%>
                <div class="row">
                    <div class="col s12 m12 l12 right">
                        <asp:LinkButton ID="printButton" runat="server"
                            OnClientClick="javascript:window.print();"
                            OnClick="printButton_Click"
                            CssClass="btn" ToolTip="Print"
                            Visible="False" ><i class="mdi-action-print"></i></asp:LinkButton>
                        <asp:LinkButton ID="Download" runat="server"
                            OnClick="Download_Click" 
                            CssClass="btn" ToolTip="Save"
                            Visible="False" ><i class="mdi-content-save"></i></asp:LinkButton>
                    </div>
                </div>

            </div>

        </div>
        
    </form>
    
    <!--Import jQuery before materialize.js-->
    <script type="text/javascript" src="Scripts/jquery-2.1.1.min.js"></script>
    <script type="text/javascript" src="Scripts/materialize.min.js"></script>
</body>
</html>
