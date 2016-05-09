<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FrmHome.aspx.cs" Inherits="LargeDealFrameWork.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<div>
<asp:Label ID="lblOpportunityCount" runat="server" Text="# Open Opportunities , # Large Opptunities , # Non-Large Opportunities" CssClass="opportunityHead"></asp:Label>
</div>
<div>
<asp:label id="lblopenopp" runat="server" Text="Open Opportunities" class="homeheads"></asp:label>
</div>
</asp:Content>
