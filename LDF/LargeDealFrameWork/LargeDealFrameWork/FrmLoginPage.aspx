<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmLoginPage.aspx.cs" Inherits="LargeDealFrameWork.LoginPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
      <link href="~/Styles/Site.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server" style="width: 100%; height: 100%">
    <table class="mainTable">
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
            <td style="width: 100%; height: 3%; background-color: #003399;" colspan="2">
            </td>
        </tr>
        <tr style="width: 100%; height: 9%">
            <td style="width: 100%; height: 9%" colspan="2">
            </td>
        </tr>
        <tr style="width: 100%; height: 57%">
            <td style="width: 100%; height: 57%" colspan="2">
                <table style="width: 100%; height: 100%">
                    <tr style="width: 100%; height: 100%">
                        <td style="width: 50%; height: 100%" align="center" valign="middle">
                            <asp:Image ID="img1" runat="server" Height="300px" Width="500px" ImageUrl="~/Images/deal1.png" />
                        </td>
                        <td style="width: 50%; height: 100%">
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr style="width: 100%; height: 13%">
            <td style="width: 100%; height: 13%" colspan="2">
            </td>
        </tr>
        <tr style="width: 100%; height: 2%">
            <td style="width: 100%; height: 2%; background-color: #003399;" colspan="2" valign="middle" class="mainfooter"
                align="center">
                <span style="color:White; font-family:Verdana; font-size:12px">
                Best viewed in IE8.0.76,IE9,1152*864 resolution © Copyright Syntel Inc.
               </span>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
