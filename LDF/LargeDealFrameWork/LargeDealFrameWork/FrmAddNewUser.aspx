<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPages/Admin.Master" AutoEventWireup="true" CodeBehind="FrmAddNewUser.aspx.cs" Inherits="LargeDealFrameWork.AdminPages.AddNewUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
<link rel="Stylesheet" href="Styles/IS.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table>
        <tr>
            <td align="right">First Name:
            </td>
            <td align="left">
                <asp:TextBox ID="txtFirstName" runat="server" Width="200px" CssClass="textSkin"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvFirstName" runat="server" 
                    ControlToValidate="txtFirstName" ErrorMessage="Please Enter First Name." 
                    ForeColor="Red" ValidationGroup="AddUser">*</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="revFirstName" runat="server"  ControlToValidate="txtFirstName"
                ErrorMessage="First Name should be Alphabetic only." ForeColor="Red" ValidationGroup="AddUser" 
                    ValidationExpression="^[A-z]+$">*</asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td align="right">Middle Name:
            </td>
            <td align="left">
                <asp:TextBox ID="txtMiddleName" runat="server" Width="200px" CssClass="textSkin"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"  ControlToValidate="txtMiddleName"
                ErrorMessage="Middle Name should be Alphabetic only." ForeColor="Red" ValidationGroup="AddUser" 
                    ValidationExpression="^[A-z]+$">*</asp:RegularExpressionValidator>                
            </td>
        </tr>
        <tr>
            <td align="right">Last Name:
            </td>
            <td align="left">
                <asp:TextBox ID="txtLastName" runat="server" Width="200px" CssClass="textSkin"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvLastName" runat="server" 
                    ControlToValidate="txtLastName" ErrorMessage="Please Enter Last Name." 
                    ForeColor="Red" ValidationGroup="AddUser">*</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server"  ControlToValidate="txtLastName"
                ErrorMessage="Last Name should be Alphabetic only." ForeColor="Red" ValidationGroup="AddUser" 
                    ValidationExpression="^[A-z]+$">*</asp:RegularExpressionValidator>    
            </td>
        </tr>
        <tr>
            <td align="right">Employee ID:
            </td>
            <td align="left">
                <asp:TextBox ID="txtEmpID" runat="server" Width="200px" CssClass="textSkin"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvEmployeeID" runat="server" 
                    ControlToValidate="txtEmpID" ErrorMessage="Please Enter Employee ID." 
                    ForeColor="Red" ValidationGroup="AddUser">*</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="revEmployeeID" runat="server"  ControlToValidate="txtEmpID"
                ErrorMessage="Employee ID should be numeric only." ForeColor="Red" ValidationGroup="AddUser" 
                    ValidationExpression="^[0-9]+$">*</asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td align="right">Email ID:
            </td>
            <td align="left">
                <asp:TextBox ID="txtEmailID" runat="server" Width="200px" CssClass="textSkin"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvEmailID" runat="server" 
                    ControlToValidate="txtEmailID" ErrorMessage="Please Enter Email ID." 
                    ForeColor="Red" ValidationGroup="AddUser">*</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="revEmailID" runat="server"  ControlToValidate="txtEmailID"
                ErrorMessage="Not valid email ID." ForeColor="Red" ValidationGroup="AddUser" 
                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td align="right">Vertical:
            </td>
            <td align="left">
                <asp:DropDownList ID="ddlVertical" runat="server" Width="200px" 
                    AutoPostBack="True" CssClass="dropDownSkinOpportunityQualification">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfvVertical" runat="server" ControlToValidate="ddlVertical" ForeColor="Red"
                 ErrorMessage="Please Select Vertical." InitialValue="0" ValidationGroup="AddUser">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td align="right">Designation:
            </td>
            <td align="left">
                <asp:DropDownList ID="ddlDesignation" runat="server" Width="200px" 
                    AutoPostBack="True" CssClass="dropDownSkinOpportunityQualification">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfvDesignation" runat="server" ControlToValidate="ddlDesignation" ForeColor="Red"
                 ErrorMessage="Please Select Designation." InitialValue="0" ValidationGroup="AddUser">*</asp:RequiredFieldValidator>
            </td>
        </tr>  
        
         <tr>
            <td align="right">Location:
            </td>
            <td align="left">
                <asp:DropDownList ID="ddlLocation" runat="server" Width="200px" 
                    AutoPostBack="True" CssClass="dropDownSkinOpportunityQualification">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfvLocation" runat="server" ControlToValidate="ddlLocation" ForeColor="Red"
                 ErrorMessage="Please Select Location." InitialValue="0" ValidationGroup="AddUser">*</asp:RequiredFieldValidator>
            </td>
        </tr>       
        
        <tr>            
            <td colspan="2" align="right">
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" onclick="btnCancel_Click" CssClass="SkbtnSkin"
                    />
                <asp:Button ID="btnCreate" runat="server" Text="Add User" 
                    onclick="btnCreate_Click" ValidationGroup="AddUser" CssClass="SkbtnSkin"/>
                
            </td>
        </tr>
        <tr>            
            <td colspan="2" align="left">
                <asp:Label ID="lblMessage" runat="server" ForeColor="#009933"></asp:Label>
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="AddUser" ForeColor="Red"/>
            </td>
        </tr>
    </table>
</asp:Content>
