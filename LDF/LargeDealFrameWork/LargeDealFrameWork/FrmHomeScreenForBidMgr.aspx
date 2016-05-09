<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FrmHomeScreenForBidMgr.aspx.cs" Inherits="LargeDealFrameWork.FrmHomeScreenForBidMgr" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
<meta charset="utf-8">
      <link rel="stylesheet" type="text/css" href="Styles/IS.css" />
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
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
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

    
        <tr style="width: 100%; height: 65%">
            <td style="width: 100%; height: 100%" valign="top">
                <div id="tabs">
                    <ul>
                        <li><a href="#div_openoppr">Open Opportunities</a></li>
                        <li><a href="#div_closedoppr">Close Opportunities</a></li>
                    </ul>
                    <div id="div_openoppr" class="div" runat="server" align="center">
                        <asp:GridView ID="gvOpenOpportunities" runat="server" 
                            AutoGenerateColumns="false" AllowPaging="true"
                            Width="80%" ShowHeaderWhenEmpty="false" 
                            OnRowDataBound="gvOpenOpportunities_RowDataBound" 
                            OnRowCommand="gvOpenOpportunities_RowCommand" 
                            onpageindexchanging="gvOpenOpportunities_PageIndexChanging"  PageSize="10" CssClass="grid" >
                                    <HeaderStyle CssClass= "skGridInnerHeader" />
                                    <RowStyle CssClass="skGridInnerRow"/> 
                                    <SelectedRowStyle CssClass="skGridInnerSelectedRow" /> 
                                    <AlternatingRowStyle CssClass="skGridInnerAlternatingRow" /> 
                                    <FooterStyle CssClass="skGridInnerFooter" /> 
                                    <PagerStyle CssClass="skGridInnerRow" /> 
 
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
                                        <asp:TextBox ID="txtStartDat" runat="Server" TextMode="SingleLine" CssClass="textSkin"
                                            ClientIDMode="AutoID" Text='<%# Eval("startdate","{0:MM-dd-yy}")%>' >                                             
                                        </asp:TextBox>
                                        <ajax:CalendarExtender ID="StartDatCalendarExtender" runat="server" TargetControlID="txtStartDat"
                                            Format="dd/MM/yyyy" ClientIDMode="AutoID" SkinID="CalSkin"/>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Submission Date">

                                    <ItemTemplate>
                                        <asp:TextBox ID="txtEditReview" runat="Server" TextMode="SingleLine" CssClass="textSkin"
                                            ClientIDMode="AutoID" Text='<%# Eval("submissiondate") %>' DataFormatString="{0:d}" >                                             
                                        </asp:TextBox>
                                        <ajax:CalendarExtender ID="CalendarExtender" runat="server" TargetControlID="txtEditReview"
                                            Format="dd/MM/yyyy" ClientIDMode="AutoID" SkinID="CalSkin"  />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                            </Columns>
                        </asp:GridView>
                         <asp:Label ID="lblOpenNoRecords" SkinId= "SklblLeft" runat="server"></asp:Label>
                    </div>
                    <div id="div_closedoppr" class="div" runat="server" align="center">
                        <asp:GridView ID="gvCloseOpportunities" runat="server" 
                            AutoGenerateColumns="false" OnRowCommand="gvCloseOpportunities_RowCommand"
                            Width="80%" ShowHeaderWhenEmpty="false" 
                            OnRowDataBound="gvCloseOpportunities_RowDataBound" AllowPaging="true"
                            PageSize="10"
                            onpageindexchanging="gvCloseOpportunities_PageIndexChanging">
                                    <HeaderStyle CssClass= "skGridInnerHeader" />
                                    <RowStyle CssClass="skGridInnerRow"/> 
                                    <SelectedRowStyle CssClass="skGridInnerSelectedRow" /> 
                                    <AlternatingRowStyle CssClass="skGridInnerAlternatingRow" /> 
                                    <FooterStyle CssClass="skGridInnerFooter" /> 
                                    <PagerStyle CssClass="skGridInnerRow" /> 
 
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
                                <asp:TemplateField HeaderText="Status">
                                    <ItemTemplate>
                                        <%#Eval("status")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Start Date">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtStartDat" runat="Server" TextMode="SingleLine" CssClass= "textSkin"
                                            ClientIDMode="AutoID" Text='<%# Eval("startdate","{0:MM-dd-yy}")%>' enabled="false">                                             
                                        </asp:TextBox>
                                        <ajax:CalendarExtender ID="StartDatCalendarExtender" runat="server" TargetControlID="txtStartDat"
                                            Format="dd/MM/yyyy" ClientIDMode="AutoID" SkinID="CalSkin" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Submission Date">

                                    <ItemTemplate>
                                        <asp:TextBox ID="txtEditReview" runat="Server" TextMode="SingleLine" CssClass="textSkin" enabled="false"
                                            ClientIDMode="AutoID" Text='<%# Eval("submissiondate") %>' DataFormatString="{0:d}" >                                             
                                        </asp:TextBox>
                                        <ajax:CalendarExtender ID="CalendarExtender" runat="server" TargetControlID="txtEditReview"
                                            Format="dd/MM/yyyy" ClientIDMode="AutoID" SkinID="CalSkin" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Close Date">

                                    <ItemTemplate>
                                        <asp:TextBox ID="txtCloseDate" runat="Server" TextMode="SingleLine" CssClass="textSkin" enabled="false"
                                            ClientIDMode="AutoID" Text='<%# Eval("closeddate") %>' DataFormatString="{0:d}" >                                             
                                        </asp:TextBox>
                                        <ajax:CalendarExtender ID="closeddateCalendarExtender" runat="server" TargetControlID="txtCloseDate"
                                            Format="dd/MM/yyyy" ClientIDMode="AutoID" SkinID="CalSkin" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                         <asp:Label ID="lblClosedNoRecords" runat="server" CssClass= "SklblLeft"></asp:Label>
                       <asp:HiddenField ID="checkpostback" runat="server"/>  
                    </div>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
