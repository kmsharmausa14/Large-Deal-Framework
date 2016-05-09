<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FrmHomeScreenForBUHead.aspx.cs" Inherits="LargeDealFrameWork.HomeScreenBUHead" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<asp:Content ID="ContentHeadHomeScreenBUHead" ContentPlaceHolderID="HeadContent" runat="server">
    <meta charset="utf-8">

    <link href="Styles/IS.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="/resources/demos/style.css" />
    <script type="text/javascript">

        $(function () {
            //  jQueryUI 1.10 and HTML5 ready
            //  Documentation
            //  Define friendly index name
            var index = 'key';
            //  Define friendly data store name
            var dataStore = window.sessionStorage;
            //  Start magic!
            try {
                // getter: Fetch previous value
                var oldIndex = dataStore.getItem(index);
                var status = document.getElementById("checkpostback");
                var postback = status.value;
                if (postback == 1) {
                     oldIndex = 0;
                    postback = 0;
                }
            } catch (e) {
                // getter: Always default to first tab in error state
                var oldIndex = 0;
            }
            $('#tabs').tabs({
                // The zero-based index of the panel that is active (open)
                active: oldIndex,
                // Triggered after a tab has been activated
                activate: function (event, ui) {
                    //  Get future value
                    var newIndex = ui.newTab.parent().children().index(ui.newTab);
                    //  Set future value
                    dataStore.setItem(index, newIndex)
                }
            });
        }); 
     
      </script>
</asp:Content>
<asp:Content ID="ContentMainHomeScreenBUHead" ContentPlaceHolderID="MainContent" runat="server">
    <ajax:ToolkitScriptManager ID="ScriptManagerHomeScreenGPT" runat="server">
    </ajax:ToolkitScriptManager>
    <table style="width: 100%; height: 70%">
       <tr style="width: 100%; height: 5%">
            <td style="width: 100%; height: 5%">
                  <asp:Label ID="lblOpenCount" runat="server" SkinID="SklblHomeHead"></asp:Label>
                <asp:Label ID="Label3" runat="server" Text=" Open Opportunities, " SkinID="SklblHomeHead"></asp:Label>
                    <asp:Label ID="lblCloseCount" runat="server" SkinID="SklblHomeHead"></asp:Label>
                <asp:Label ID="Label2" runat="server" Text=" Close Opportunities, " SkinID="SklblHomeHead"></asp:Label>
                <asp:Label ID="lblLargeCount" runat="server" SkinID="SklblHomeHead"></asp:Label>
                <asp:Label ID="Label5" runat="server" Text=" Large Deals, " SkinID="SklblHomeHead"></asp:Label>
                <asp:Label ID="lblNonLargeCount" runat="server" SkinID="SklblHomeHead"></asp:Label>
                <asp:Label ID="Label4" runat="server" Text=" Non Large Deals " SkinID="SklblHomeHead"></asp:Label>
            </td>
        </tr>
 <tr style="width: 100%; height: 5%">
 
            <td>
            <label id="lblselectvertical" runat="server" Font-Bold="True" ForeColor="Black" Font-Size="15px" style="color: #420042">
                                Select Sales Member:</label>
            <asp:DropDownList ID="ddlSalesPeople" runat="server" 
                    onselectedindexchanged="ddlSalesPeople_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
            </td>
        </tr>
 <tr style="width: 100%; height: 60%">
            <td style="width: 100%; height: 60%" valign="top">
             <div id="tabs">
                    <ul>
                        <li><a href="#tabs-1" runat="server" id="Opp1">Open Opportunities</a></li>
                        <li><a href="#tabs-2" runat="server" id="Opp2">Close Opportunities</a></li>
                    </ul>
<div id="tabs-1" align="center">
                        <asp:GridView ID="gvOpenOpportunities" runat="server" 
                            AutoGenerateColumns="false" 
                            Width="80%" ShowHeaderWhenEmpty="false" 
                            OnRowDataBound="gvOpenOpportunities_RowDataBound" 
                            OnRowCommand="gvOpenOpportunities_RowCommand" onpageindexchanging="gvOpenOpportunities_PageIndexChanging" AllowPaging="true" PageSize="10">
                            <RowStyle CssClass="skGridInnerRow"/>
                            <SelectedRowStyle CssClass="skGridInnerSelectedRow" />
                            <PagerStyle CssClass="skGridInnerRow" />
                            <AlternatingRowStyle CssClass="skGridInnerAlternatingRow" />
                            <HeaderStyle CssClass="skGridInnerHeader" />
                            <FooterStyle CssClass="skGridInnerFooter" />
                            <Columns>
                                <asp:TemplateField HeaderText="Sr.No.">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex + 1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Opportunity ID">
                                <ItemTemplate>
                                <asp:LinkButton ID="OppIDLnkButton" runat="server" CssClass="HyperLink" Text='<%#Eval("opportnumber") %>' CommandName="OppIdRedirect" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'>
                                </asp:LinkButton>
                                </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Opportunity Description">
                                    <ItemTemplate>
                                        <%#Eval("opportdesc") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Start Date">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtStartDat" runat="Server" TextMode="SingleLine" Width="160px"
                                            ClientIDMode="AutoID" Text='<%# Eval("startdate","{0:MM-dd-yy}")%>' >                                             
                                        </asp:TextBox>
                                        <ajax:CalendarExtender ID="StartDatCalendarExtender" SkinID="CalSkin" runat="server" TargetControlID="txtStartDat"
                                            Format="dd/MM/yyyy" ClientIDMode="AutoID" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Submission Date">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtEditReview" runat="Server" TextMode="SingleLine" Width="160px"
                                            ClientIDMode="AutoID" Text='<%# Eval("submissiondate") %>' DataFormatString="{0:d}" >                                             
                                        </asp:TextBox>
                                        <ajax:CalendarExtender ID="CalendarExtender" SkinID="CalSkin" runat="server" TargetControlID="txtEditReview"
                                            Format="dd/MM/yyyy" ClientIDMode="AutoID" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                         <asp:Label ID="lblOpenNoRecords" ForeColor="#003399" Font-Bold="true" Font-Size="12px" runat="server"></asp:Label>
                    </div>
<div id="tabs-2" align="center">
                        <asp:GridView ID="gvCloseOpportunities" runat="server" 
                            AutoGenerateColumns="false" OnRowCommand="gvCloseOpportunities_RowCommand"
                            Width="80%" ShowHeaderWhenEmpty="false" 
                            OnRowDataBound="gvCloseOpportunities_RowDataBound" 
                            onpageindexchanging="gvCloseOpportunities_PageIndexChanging" AllowPaging="true" PageSize="10">
                            <RowStyle CssClass="skGridInnerRow"/>
                            <PagerStyle CssClass="skGridInnerRow" />
                            <SelectedRowStyle CssClass="skGridInnerSelectedRow" />
                            <AlternatingRowStyle CssClass="skGridInnerAlternatingRow" />
                            <HeaderStyle CssClass="skGridInnerHeader" />
                            <FooterStyle CssClass="skGridInnerFooter" />
                            <Columns>
                                <asp:TemplateField HeaderText="Sr.No.">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex + 1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Opportunity ID">
                                <ItemTemplate>
                                <asp:LinkButton ID="ClosedOppIDLnkButton" runat="server" ForeColor="#0000ff" Text='<%#Eval("opportnumber") %>' CommandName="OppIdRedirect" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'>
                                </asp:LinkButton>
                                </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Opportunity Description">
                                    <ItemTemplate>
                                        <%#Eval("opportdesc") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Status">
                                    <ItemTemplate>
                                        <%#Eval("status")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Start Date">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtStartDat" runat="Server" TextMode="SingleLine" Width="160px"
                                            ClientIDMode="AutoID" Text='<%# Eval("startdate","{0:MM-dd-yy}")%>' enabled="false">                                             
                                        </asp:TextBox>
                                        <ajax:CalendarExtender ID="StartDatCalendarExtender" SkinID="CalSkin" runat="server" TargetControlID="txtStartDat"
                                            Format="dd/MM/yyyy" ClientIDMode="AutoID" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Submission Date">

                                    <ItemTemplate>
                                        <asp:TextBox ID="txtEditReview" runat="Server" TextMode="SingleLine" Width="160px" enabled="false"
                                            ClientIDMode="AutoID" Text='<%# Eval("submissiondate") %>' DataFormatString="{0:d}" >                                             
                                        </asp:TextBox>
                                        <ajax:CalendarExtender ID="CalendarExtender" SkinID="CalSkin" runat="server" TargetControlID="txtEditReview"
                                            Format="dd/MM/yyyy" ClientIDMode="AutoID" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Close Date">

                                    <ItemTemplate>
                                        <asp:TextBox ID="txtCloseDate" runat="Server" TextMode="SingleLine" Width="160px" enabled="false"
                                            ClientIDMode="AutoID" Text='<%# Eval("closeddate") %>' DataFormatString="{0:d}" >                                             
                                        </asp:TextBox>
                                        <ajax:CalendarExtender ID="closeddateCalendarExtender" SkinID="CalSkin" runat="server" TargetControlID="txtCloseDate"
                                            Format="dd/MM/yyyy" ClientIDMode="AutoID" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        <asp:Label ID="lblClosedNoRecords" runat="server" CssClass="HyperLink" Font-Bold="true" Font-Size="12px"></asp:Label>
                        <br />
                         <asp:HiddenField ID="checkpostback" runat="server"/>  
                    </div>
                     </div>
                    </td>
                    </tr>
                    </table>
                   
</asp:Content>
