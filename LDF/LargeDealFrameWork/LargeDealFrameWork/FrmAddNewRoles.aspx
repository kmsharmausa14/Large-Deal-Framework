<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPages/Admin.Master" AutoEventWireup="true"
    CodeBehind="FrmAddNewRoles.aspx.cs" Inherits="LargeDealFrameWork.FrmAddNewRoles" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
<link rel="stylesheet" href="Styles/IS.css" />
<script type="text/javascript">
    function ValidateData(txt, name) {
       // debugger;
        var str = txt.value;
        str = str.replace(/\s+/g, "");
        if (str.length > 0) {
            return true;
        }
        else {
            txt.value = "";
            alert('Please enter ' + name);
            return false;
        }
    }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <fieldset class="clsRole">
        <legend>Role Information</legend>
        <table>
            <tr>
                <td align="right">
                    <asp:Label ID="lblRole" runat="server" Text="Role Name:"></asp:Label>
                </td>
                <td align="left">
                    <asp:TextBox ID="txtRoleName" runat="server" Width="200px" CssClass="textSkin"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvRoleName" runat="server" ControlToValidate="txtRoleName"
                        ErrorMessage="Please Enter Role." ForeColor="Red" ValidationGroup="AddUser">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="revRoleName" runat="server" ControlToValidate="txtRoleName"
                        ErrorMessage="Role should be Alphabetic only." ForeColor="Red" ValidationGroup="AddUser"
                        ValidationExpression="^[A-z]+$">*</asp:RegularExpressionValidator>
                    <asp:Button ID="btnAddRole" runat="server" Width="120px" Text="Add Role" OnClick="btnAddRole_Click"  CssClass="SkbtnSkin"/>
                </td>
            </tr>
        </table>
    </fieldset>
    <div>
    </div>
    <fieldset class="clsVertical">
        <legend>Vertical Information</legend>
        <table>
            <tr>
                <td align="right">
                    <asp:Label ID="lblVertical" runat="server" Text="Vertical Name:"></asp:Label>
                </td>
                <td align="left">
                    <asp:TextBox ID="txtVertical" runat="server" Width="200px" CssClass="textSkin"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtVertical"
                        ErrorMessage="Please Enter Vertical." ForeColor="Red" ValidationGroup="AddUser">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtVertical"
                        ErrorMessage="Vertical should be Alphabetic only." ForeColor="Red" ValidationGroup="AddUser"
                        ValidationExpression="^[A-z]+$">*</asp:RegularExpressionValidator>
                    <asp:Button ID="btnAddVertical" runat="server" Width="120px" Text="Add Vertical"
                        OnClick="btnAddVertical_Click" CssClass="SkbtnSkin"/>
                </td>
            </tr>
        </table>
    </fieldset>
    <div>
    </div>
    <fieldset class="clsLocation">
        <legend>Location Information</legend>
        <table>
            <tr>
                <td align="right">
                    <asp:Label ID="lblLocation" runat="server" Text="Location Name:"></asp:Label>
                </td>
                <td align="left">
                    <asp:TextBox ID="txtLocation" runat="server" Width="200px" CssClass="textSkin"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtLocation"
                        ErrorMessage="Please Enter Location." ForeColor="Red" ValidationGroup="AddUser">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtLocation"
                        ErrorMessage="Location should be Alphabetic only." ForeColor="Red" ValidationGroup="AddUser"
                        ValidationExpression="^[A-z]+$">*</asp:RegularExpressionValidator>
                    <asp:Button ID="btnAddLocation" runat="server" Width="120px" Text="Add Location"
                        OnClick="btnAddLocation_Click" CssClass="SkbtnSkin"/>
                </td>
            </tr>
        </table>
    </fieldset>
    <div>
    </div>
    <fieldset class="clsDesignation">
        <legend>Designation Information</legend>
        <table>
            <tr>
                <td align="right">
                    <asp:Label ID="lblDesignation" runat="server" Text="Designation Name:"></asp:Label>
                </td>
                <td align="left">
                    <asp:TextBox ID="txtDesignation" runat="server" Width="200px" CssClass="textSkin"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtDesignation"
                        ErrorMessage="Please Enter Designation." ForeColor="Red" ValidationGroup="AddUser">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtDesignation"
                        ErrorMessage="Designation should be Alphabetic only." ForeColor="Red" ValidationGroup="AddUser"
                        ValidationExpression="^[A-z]+$">*</asp:RegularExpressionValidator>
                    <asp:Button ID="btnAddDesignation" Width="120px" runat="server" Text="Add Designation"
                        OnClick="btnAddDesignation_Click" CssClass="SkbtnSkin" />
                </td>
            </tr>
        </table>
    </fieldset>
    <table>
        <tr>
            <td colspan="2" align="left">
                <asp:Label ID="lblErrMsg" runat="server" ForeColor="#009933"></asp:Label>
                <asp:ValidationSummary ID="vsAddRolDesgnLocVert" runat="server" ValidationGroup="AddRolDesgnLocVert"
                    ForeColor="Red" />
            </td>
        </tr>
    </table>
</asp:Content>
