<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmErrorPage.aspx.cs" Inherits="LargeDealFrameWork.frmErrorPage"%>

<%@ Register TagPrefix="ajax" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="~/Styles/Site.css" rel="stylesheet" type="text/css" />
    <link href="Styles/Site.css" rel="stylesheet" type="text/css" />

    <style type="text/css">
        .pnlCSS
        {
            font-weight: bold;
            cursor: pointer;
            border: solid 1px #c0c0c0;
            }
    </style>
</head>
<body>
    <form id="frmErrorPage" runat="server">
    <ajax:ToolkitScriptManager ID="scriptManagerErrorPage" runat="server">
    </ajax:ToolkitScriptManager>
    <div>
        <table align="center" style="height: 842px; width: 1150px; background-color: White">
            <tr style="width: 100%; height: 15%">
                <td style="width: 20%; height: 15%">
                    <img alt="Syntel" src="Images/syntel logo.png" style="width: 234px; height: 71px" />
                </td>
                <td style="width: 80%; height: 15%" align="right">
                    <font style="text-transform: capitalize; font-size: 40px; font-weight: bold;">large
                        deal framework</font>
                </td>
            </tr>
            <tr style="width: 100%; height: 3%">
            <td style="width: 100%; height: 3%; background-color: #003399; color:White; font-weight:bold" colspan="2" align="right">
            <asp:Label ID="userName" runat="server" ForeColor="White" 
                    Font-Bold="True" Font-Size="14px"></asp:Label>&nbsp;&nbsp;|
             <asp:LinkButton ID="lnkHome" runat="server" Text="Home" ForeColor="White" Font-Bold="True"
                    Font-Size="14px" onclick="lnkHome_Click" CausesValidation="true"></asp:LinkButton>&nbsp;&nbsp;|
           <asp:LinkButton ID="lnkbuttonHelp" runat="server" Text="Help" ForeColor="White" 
                    Font-Bold="True" Font-Size="14px" CausesValidation="true"></asp:LinkButton>&nbsp;&nbsp;|
             <asp:LinkButton ID="lnkbuttonSignout" runat="server" Text="Sign out" 
                    ForeColor="White" Font-Bold="True" Font-Size="14px" 
                    onclick="lnkbuttonSignout_Click" CausesValidation="true"></asp:LinkButton>
            </td>
        </tr>
            <tr style="width: 100%; height: 3%">
                <td style="width: 100%; height: 3%; background-color: #003399; color: White; font-weight: bold"
                    colspan="2" align="right">
                </td>
            </tr>
            <tr style="width: 100%; height: 20%">
                <td colspan="2" style="width: 100%; height: 20%" valign="top">
                </td>
            </tr>
            <tr style="width: 100%; height: 5%">
                <td colspan="2" style="width: 100%; height: 5%; font-family: Verdana; font-size: 15px;
                    font-weight: bold; color: #FF0000;" valign="middle" align="center">
                    <asp:Label ID="lblErrorMessage" runat="server" Text="The application is under heavy load right now. Please try after few minutes"></asp:Label>
                </td>
            </tr>
            <tr style="width: 100%; height: 35%">
                <td colspan="2" style="width:100%; height: 35%" align="center" valign="top">
                <div style="font-family: Verdana; width:30%; height: 100%" align="center">
                    <asp:Panel ID="pnlClick" runat="server" CssClass="pnlCSS" Height="10%" Width="100%"
                        BorderColor="Black">
                        <div style="height: 116%; width: 100%; vertical-align: middle">
                            <div style="float: left; color: Black; padding: 5px 5px 0 0; width: 100%" align="left">
                                <asp:Label ID="lblMessage" runat="server" Text="Label" />
                            </div>
                            <div style="clear: both">
                            </div>
                        </div>
                    </asp:Panel>
                    <asp:Panel ID="pnlCollapsable" runat="server" Height="90%" Width="99%" CssClass="pnlCSS"
                        BorderColor="Black" BorderWidth="1px">
                        <table style="width: 100%; height: 100%; border-width: 1px;">
                            <tr style="width: 100%; height: 100%">
                                <td style="width: 100%; height: 100%" valign="middle">
                                    <asp:Label ID="lblExceptionMessage" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <ajax:CollapsiblePanelExtender ID="CollapsiblePanelExtender1" runat="server" CollapseControlID="pnlClick"
                        Collapsed="true" ExpandControlID="pnlClick" TextLabelID="lblMessage" CollapsedText="Show Details >>>"
                        ExpandedText="Hide Details <<<" ImageControlID="imgArrows" ExpandDirection="Vertical"
                        TargetControlID="pnlCollapsable" ScrollContents="false">
                    </ajax:CollapsiblePanelExtender>
                </div>
                </td>
            </tr>
            <tr style="width: 100%; height: 20%">
                <td colspan="2" style="width: 100%; height: 20%" valign="top">
                </td>
            </tr>
            <tr style="width: 100%; height: 2%">
                <td style="width: 100%; height: 2%; background-color: #003399;" colspan="2" valign="middle"
                    class="mainfooter" align="center">
                    <span style="color: White; font-family: Verdana; font-size: 12px">Best viewed in IE8.0.76,IE9,1152*864
                        resolution © Copyright Syntel Inc. </span>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
