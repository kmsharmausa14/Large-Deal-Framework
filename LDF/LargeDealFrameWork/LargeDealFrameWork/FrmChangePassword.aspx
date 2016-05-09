<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FrmChangePassword.aspx.cs" Inherits="LargeDealFrameWork.ChangePassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">


    <table border="0" cellpadding="10" cellspacing="10"
                    >
                    <tr>
                        <td>
                            <table border="0" cellpadding="0">
                                <tr>
                                    <td align="center" colspan="2" style="font-weight:bold; color:Black;">
                                        Change Password</td>
                                </tr>
                                <tr>
                                    <td colspan="2"> <br />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="Label2" runat="server" Font-Bold="true" ForeColor="Black"
                                            AssociatedControlID="CurrentPassword">User ID: </asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtUserID" runat="server" ForeColor="Black" Enabled="false"></asp:TextBox>                                        
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="CurrentPasswordLabel" runat="server" Font-Bold="true" ForeColor="Black"
                                            AssociatedControlID="CurrentPassword">Current Password: </asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="CurrentPassword" runat="server" TextMode="Password"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="CurrentPasswordRequired" runat="server"
                                            ControlToValidate="CurrentPassword" ErrorMessage="Password is required."
                                            ToolTip="Password is required." ValidationGroup="ChangePassword1" 
                                            ForeColor="Red">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="NewPasswordLabel" runat="server" Font-Bold="true" ForeColor="Black"
                                            AssociatedControlID="NewPassword">New Password: </asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="NewPassword" runat="server" TextMode="Password"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="NewPasswordRequired" runat="server"
                                            ControlToValidate="NewPassword" ErrorMessage="New Password is required."
                                            ToolTip="New Password is required." ValidationGroup="ChangePassword1" 
                                            ForeColor="Red">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="ConfirmNewPasswordLabel" runat="server" Font-Bold="true" ForeColor="Black"
                                            AssociatedControlID="ConfirmNewPassword">Confirm Password: </asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="ConfirmNewPassword" runat="server" TextMode="Password"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="ConfirmNewPasswordRequired" runat="server"
                                            ControlToValidate="ConfirmNewPassword"
                                            ErrorMessage="Confirm New Password is required."
                                            ToolTip="Confirm New Password is required." 
                                            ValidationGroup="ChangePassword1" ForeColor="Red">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="2">
                                        <asp:CompareValidator ID="NewPasswordCompare" runat="server"
                                            ControlToCompare="NewPassword" ControlToValidate="ConfirmNewPassword"
                                            Display="Dynamic" ForeColor="Red"
                                            ErrorMessage="The Confirm New Password must match the New Password entry."
                                            ValidationGroup="ChangePassword1"></asp:CompareValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="2" style="color:Red;">
                                        <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2"> <br />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" colspan="2">
                                        <asp:Button ID="ChangePasswordPushButton" runat="server"
                                            CommandName="ChangePassword" Text="Change Password"
                                            ValidationGroup="ChangePassword1"
                                            onclick="ChangePasswordPushButton_Click" />
                                    
                                        <asp:Button ID="CancelPushButton" runat="server" CausesValidation="False" 
                                            CommandName="Cancel" Text="Cancel" onclick="CancelPushButton_Click" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
    <asp:Label ID="Label1" ForeColor="Red" runat="server"></asp:Label>


</asp:Content>
