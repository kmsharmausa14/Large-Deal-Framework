<%@ Page Title="" Language="C#" MasterPageFile="~/Login/LoginMaster.Master" AutoEventWireup="true" CodeBehind="ForgotPassword.aspx.cs" Inherits="LargeDealFrameWork.Login.ForgotPassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table  style="border: 1px Solid #E6E2D8; background-color:#F7F6F3; border-collapse:collapse; height: 254px; width: 383px;">
        <tr>
            <td style="color:White; background-color:#5D7B9D; font-size:5em; font-weight:bold; font-family:Verdana; font-size:0.8em" valign="middle"  
                align="center" >
                Forgot Your Password?
            </td>
        </tr>
        <tr>
            <td >
                <br />
            </td>
        </tr>
        <tr>
            <td style="font-style:italic; font-family:Verdana; font-size:1
                em">
                Enter your User ID to reset your password
            </td>
        </tr>
        <tr>
            <td >
                <br />
            </td>
        </tr>
        <tr>
            <td style="color:Black; font-family:Verdana; font-size:1em">
            User ID:  
                <asp:TextBox ID="txtUserName" runat="server" Font-Size="1em" 
                    ValidationGroup="ResetPassword"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvUserID" runat="server" 
                    ControlToValidate="txtUserName" ErrorMessage="RequiredFieldValidator" 
                    ForeColor="Red" ValidationGroup="ResetPassword">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td >
                <br />
            </td>
        </tr>
        <tr>
            <td valign="bottom" align="right">
                <asp:Button ID="btnBack" runat="server" Text="Back" 
                    style="color:#284775;background-color:#FFFBFF;border-color:#CCCCCC;border-width:1px;border-style:Solid;font-family:Verdana;font-size:1em;" 
                    onclick="btnBack_Click"/>
                &nbsp;<asp:Button ID="btnSubmit" runat="server" Text="Submit" style="color:#284775;background-color:#FFFBFF;border-color:#CCCCCC;border-width:1px;border-style:Solid;font-family:Verdana;font-size:1em;"
                    onclick="btnSubmit_Click" ValidationGroup="ResetPassword" />                
            </td>
        </tr>
        <tr>
            <td >
                <br />
            </td>
        </tr>
        <tr >
            <td >
                <asp:Label ID="lblMessage" runat="server" Text="" Visible="false" style="font-family:Verdana; font-size:1em"></asp:Label>                
            </td>
        </tr>
    </table>   

</asp:Content>
