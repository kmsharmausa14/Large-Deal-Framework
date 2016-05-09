<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPages/Admin.Master" AutoEventWireup="true" CodeBehind="FrmEditDeleteUser.aspx.cs" Inherits="LargeDealFrameWork.AdminPages.EditDeleteUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
  <link rel="stylesheet" href="Styles/IS.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="divSearch">
       <table>
       <tr>
            <td align="right">User ID:
            </td>
            <td>
                <asp:TextBox ID="txtUserID" runat="server" Width="200px" TabIndex="1" CssClass="textSkinOpportunityQualification"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvUserID" runat="server" 
                    ControlToValidate="txtUserID" ErrorMessage="RequiredFieldValidator" 
                    ForeColor="Red" ValidationGroup="UserID">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr align="right">
            <td colspan="2">
                 <asp:Button ID="btnSearch" runat="server" Text="Search" 
                    onclick="btnSearch_Click" ValidationGroup="UserID" TabIndex="2" CssClass="SkbtnSkin"/>
                <asp:Button ID="btnClear" runat="server" Text="Clear" 
                    onclick="btnClear_Click" TabIndex="3" CssClass="SkbtnSkin" />
               
                
            </td>
        </tr>
        </table>
    </div>
    <div id="divSearchResult" runat="server" visible="false">
    <table>
        <tr>
            <td align="right">Employee ID:
            </td>
            <td align="left">
                <asp:TextBox ID="txtEmpID" runat="server" Width="200px" Enabled="false" CssClass="textSkinOpportunityQualification"></asp:TextBox>
            </td>
        </tr>
       <tr>
            <td align="right">First Name:
            </td>
            <td align="left">
                <asp:TextBox ID="txtFirstName" runat="server" Width="200px" Enabled="false" CssClass="textSkinOpportunityQualification"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvFirstName" runat="server" 
                    ControlToValidate="txtFirstName" ErrorMessage="Please Enter First Name." 
                    ForeColor="Red" ValidationGroup="EditUser">*</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="revFirstName" runat="server"  ControlToValidate="txtFirstName"
                ErrorMessage="First Name should be Alphabetic only." ForeColor="Red" ValidationGroup="EditUser" 
                    ValidationExpression="^[A-z]+$">*</asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td align="right">Middle Name:
            </td>
            <td align="left">
                <asp:TextBox ID="txtMiddleName" runat="server" Width="200px" Enabled="false" CssClass="textSkinOpportunityQualification"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"  ControlToValidate="txtMiddleName"
                ErrorMessage="Middle Name should be Alphabetic only." ForeColor="Red" ValidationGroup="EditUser" 
                    ValidationExpression="^[A-z]+$">*</asp:RegularExpressionValidator>       
            </td>
        </tr>
        <tr>
            <td align="right">Last Name:
            </td>
            <td align="left">
                <asp:TextBox ID="txtLastName" runat="server" Width="200px" Enabled="false" CssClass="textSkinOpportunityQualification"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvLastName" runat="server" 
                    ControlToValidate="txtLastName" ErrorMessage="Please Enter Last Name." 
                    ForeColor="Red" ValidationGroup="EditUser">*</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server"  ControlToValidate="txtLastName"
                ErrorMessage="Last Name should be Alphabetic only." ForeColor="Red" ValidationGroup="EditUser" 
                    ValidationExpression="^[A-z]+$">*</asp:RegularExpressionValidator> 
            </td>
        </tr>        
        <tr>
            <td align="right">Email ID:
            </td>
            <td align="left">
                <asp:TextBox ID="txtEmailID" runat="server" Width="200px" Enabled="false" CssClass="textSkinOpportunityQualification"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvEmailID" runat="server" 
                    ControlToValidate="txtEmailID" ErrorMessage="Please Enter Email ID." 
                    ForeColor="Red" ValidationGroup="EditUser">*</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="revEmailID" runat="server"  ControlToValidate="txtEmailID"
                ErrorMessage="Not valid email ID." ForeColor="Red" ValidationGroup="EditUser" 
                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td align="right">Vertical:
            </td>
            <td align="left">
                <asp:TextBox ID="txtVertical" runat="server" Enabled="false" Width="200px" CssClass="textSkinOpportunityQualification"></asp:TextBox>
                <asp:DropDownList ID="ddlVertical" runat="server" Width="200px" 
                    AutoPostBack="True" Visible="false" CssClass="dropDownSkinOpportunityQualification">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfvVertical" runat="server" ControlToValidate="ddlVertical" ForeColor="Red"
                 ErrorMessage="Please Select Vertical." InitialValue="0" ValidationGroup="EditUser">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td align="right">Designation:
            </td>
            <td align="left">
                <asp:TextBox ID="txtDesignation" runat="server" Enabled="false" Width="200px" CssClass="textSkinOpportunityQualification"></asp:TextBox>
                <asp:DropDownList ID="ddlDesignation" runat="server" Width="200px" 
                    AutoPostBack="True" Visible="false" CssClass="dropDownSkinOpportunityQualification">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfvDesignation" runat="server" ControlToValidate="ddlDesignation" ForeColor="Red"
                 ErrorMessage="Please Select Designation." InitialValue="0" ValidationGroup="EditUser">*</asp:RequiredFieldValidator>
            </td>
        </tr>        
        <tr align="right">
            <td colspan="2">
                <asp:Button ID="btnEdit" runat="server" Text="Edit" onclick="btnEdit_Click" Visible="true" TabIndex="4" CssClass="SkbtnSkin"
                    />
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" Visible="false" onclick="btnCancel_Click"
                    TabIndex="5" CssClass="SkbtnSkin"/>
                <asp:Button ID="btnSave" runat="server" Text="Save" onclick="btnSave_Click" Visible="false" ValidationGroup="EditUser"
                   TabIndex="6" CssClass="SkbtnSkin"/>
                &nbsp;<asp:Button ID="btnDelete" runat="server" Text="Delete User" 
                    onclick="btnDelete_Click" TabIndex="7" CssClass="SkbtnSkin"/>
                
            </td>
        </tr>
        <tr>            
            <td colspan="2" align="center">
               <asp:Label ID="lblMessage1" runat="server" ForeColor="#009933"></asp:Label>
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="EditUser" ForeColor="Red"/>
            </td>
        </tr>
    </table>
    </div>
    <asp:Label ID="lblMessage" runat="server" ForeColor="#009933"></asp:Label>
     
</asp:Content>
