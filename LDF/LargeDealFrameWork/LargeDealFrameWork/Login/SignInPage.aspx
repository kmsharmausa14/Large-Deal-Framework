<%@ Page Title="" Language="C#" MasterPageFile="~/Login/LoginMaster.Master" AutoEventWireup="true" CodeBehind="SignInPage.aspx.cs" Inherits="LargeDealFrameWork.Login.SignInPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1
        {
            height: 457px;
        }
        .style3
        {
            height: 457px;
            width: 380px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">    

    <table style="width: 931px; height: 402px"> <td class="style3"> 
    <img src="../Images/loginLDF.jpg" style="width: 97%; height: 266px;"/></td> <td class="style1">
    <asp:Login ID="Login1" runat="server" BackColor="#F7F6F3" BorderColor="#E6E2D8" 
        Width="457px" Height="252px"
        BorderPadding="4" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" 
        Font-Size="Medium" ForeColor="#333333" 
     onauthenticate="Login1_Authenticate" 
    PasswordRecoveryText="Forgot Password?" 
    PasswordRecoveryUrl="~/Login/ForgotPassword.aspx" 
        FailureText="Invalid Login Id or Password." UserNameLabelText="User ID:" 
        DisplayRememberMe="False">
        <InstructionTextStyle Font-Italic="True" ForeColor="Black" />
        <LoginButtonStyle BackColor="#FFFBFF" BorderColor="#CCCCCC" BorderStyle="Solid" 
            BorderWidth="1px" Font-Names="Verdana" Font-Size="0.9em" ForeColor="#284775" />
        <TextBoxStyle Font-Size="0.9em" />
        <TitleTextStyle BackColor="#5D7B9D" Font-Bold="True" Font-Size="1em" 
            ForeColor="White" />
            <ValidatorTextStyle ForeColor="Red" />   
            <HyperLinkStyle ForeColor="Red" />         
    </asp:Login>
   
    </td>
   
    </table>
</asp:Content>
