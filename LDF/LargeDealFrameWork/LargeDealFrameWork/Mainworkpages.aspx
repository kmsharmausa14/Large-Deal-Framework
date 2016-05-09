<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Mainworkpages.aspx.cs" Inherits="LargeDealFrameWork.Mainworkpages" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <meta charset="utf-8">
    <link rel="stylesheet" href="http://code.jquery.com/ui/1.10.3/themes/smoothness/jquery-ui.css" />
    <script type="text/javascript" src="http://code.jquery.com/jquery-1.9.1.js"></script>
    <script type="text/javascript" src="http://code.jquery.com/ui/1.10.3/jquery-ui.js"></script>
    <link rel="stylesheet" href="/resources/demos/style.css" />
    <script type="text/javascript">        $(function () { $("#tabs").tabs(); });  </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width: 99%; height: 80%">
        <tr style="width: 100%; height: 5%">
            <td style="width: 100%; height: 5%">
                <asp:ImageButton ID="homeSale" runat="server" ImageUrl="~/Images/home.png" Height="30px"
                    Width="30px" OnClick="homeSale_Click" />
            </td>
        </tr>
        <tr style="width: 100%; height: 94%">
            <td style="width: 100%; height: 94%" valign="top">
                <div id="tabs">
                    <ul>
                        <li><a id="l1" runat="server" href="Qualification.aspx">Qualification Analysis</a><asp:HiddenField ID="h1"
                            runat="server" />
                            <asp:HiddenField ID="h2" runat="server" />
                        </li>
                        <li><a href="#">RGY Ckecklist</a> </li>
                        <li><a href="#">Bid Winability</a> </li>
                    </ul>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
