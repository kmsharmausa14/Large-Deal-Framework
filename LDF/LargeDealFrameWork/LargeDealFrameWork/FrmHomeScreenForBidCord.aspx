<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FrmHomeScreenForBidCord.aspx.cs" Inherits="LargeDealFrameWork.FrmHomeScreenForBidCord" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <meta  charset="utf-8">
    <link href="Styles/IS.css" rel="stylesheet" type="text/css" />
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
                <asp:Label SkinID="SklblHomeHead" ID="lblOpenCount" runat="server" ></asp:Label>
                <asp:Label SkinID="SklblHomeHead" ID="Label3" runat="server" Text=" Open Opportunities, " ></asp:Label>

                <asp:Label SkinID="SklblHomeHead" ID="lblCloseCount" runat="server" ></asp:Label>
                <asp:Label SkinID="SklblHomeHead" ID="Label2" runat="server" Text=" Close Opportunities, " ></asp:Label>

                <asp:Label SkinID="SklblHomeHead" ID="lblLargeCount" runat="server" ></asp:Label>
                <asp:Label SkinID="SklblHomeHead" ID="Label5" runat="server" Text=" Large Deals, " ></asp:Label>

                <asp:Label SkinID="SklblHomeHead" ID="lblNonLargeCount" runat="server" ></asp:Label>
                <asp:Label SkinID="SklblHomeHead" ID="Label4" runat="server" Text=" Non Large Deals " ></asp:Label>
            </td>
        </tr>
        <tr style="width: 100%; height:65%">
            <td style="width: 100%; height: 100%" valign="top">
                <div id="tabs">
                    <ul>
                        <li><a href="#div_openoppr">Open Opportunities</a></li>
                        <li><a href="#div_closedoppr">Close Opportunities</a></li>
                    </ul>
                    <div id="div_openoppr" class="div" runat="server" align="center">
                       
                        <asp:GridView ID="gvOpenOpportunities" runat="server" AutoGenerateColumns="false" 
                            Width="80%" OnRowDataBound="gvOpenOpportunities_RowDataBound" 
                            OnRowCommand="gvOpenOpportunities_RowCommand" AllowPaging="true" 
                            PageSize="10" onpageindexchanging="gvOpenOpportunities_PageIndexChanging">
                            <PagerStyle CssClass="skGridInnerRow" />
                            <RowStyle CssClass="skGridInnerRow" />
                            <SelectedRowStyle CssClass="skGridInnerSelectedRow"/>
                            <AlternatingRowStyle CssClass="skGridInnerAlternatingRow"/>
                            <HeaderStyle  CssClass="skGridInnerHeader"/>
                            <FooterStyle CssClass="skGridInnerFooter" />
                           

                            <Columns>
                                <asp:TemplateField HeaderText="Sr.No.">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex + 1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Opportunity ID">
                                <ItemTemplate>
                                <asp:LinkButton ID="OppIDLnkButton" SkinId="SklnkSkin" runat="server" Text='<%#Eval("opportnumber") %>' CommandName="OppIdRedirect" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'>
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
                                        <ajax:CalendarExtender SkinID="CalSkin" ID="StartDatCalendarExtender" runat="server" TargetControlID="txtStartDat"
                                            Format="dd/MM/yyyy" ClientIDMode="AutoID" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Submission Date">

                                    <ItemTemplate>
                                        <asp:TextBox ID="txtEditReview" runat="Server" TextMode="SingleLine" Width="160px"
                                            ClientIDMode="AutoID" Text='<%# Eval("submissiondate") %>' DataFormatString="{0:d}" >                                             
                                        </asp:TextBox>
                                        <ajax:CalendarExtender SkinID="CalSkin" ID="CalendarExtender" runat="server" TargetControlID="txtEditReview"
                                            Format="dd/MM/yyyy" ClientIDMode="AutoID" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                            </Columns>
                        </asp:GridView>
                         <asp:Label ID="lblOpenNoRecords" SkinID="SklblLeft" runat="server"  ></asp:Label>
                    </div>
                    <div id="div_closedoppr" class="div" runat="server" align="center">
                       
                        <asp:GridView ID="gvCloseOpportunities" runat="server" 
                            AutoGenerateColumns="false" OnRowCommand="gvCloseOpportunities_RowCommand" 
                            Width="80%"  OnRowDataBound="gvCloseOpportunities_RowDataBound" 
                            onpageindexchanging="gvCloseOpportunities_PageIndexChanging" AllowPaging="true" PageSize="10">
                            <PagerStyle CssClass="skGridInnerRow" />
                            <RowStyle CssClass="skGridInnerRow" />
                            <SelectedRowStyle CssClass="skGridInnerSelectedRow"/>
                            <AlternatingRowStyle CssClass="skGridInnerAlternatingRow"/>
                            <HeaderStyle  CssClass="skGridInnerHeader"/>
                            <FooterStyle CssClass="skGridInnerFooter" />
                          
                            <Columns>
                                <asp:TemplateField HeaderText="Sr.No.">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex + 1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Opportunity ID">
                                <ItemTemplate>
                                <asp:LinkButton ID="OppIDLnkButton" runat="server" ForeColor="#0000ff" Text='<%#Eval("opportnumber") %>' CommandName="OppIdRedirect" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'>
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
                                        <ajax:CalendarExtender SkinID="CalSkin" ID="StartDatCalendarExtender" runat="server" TargetControlID="txtStartDat"
                                            Format="dd/MM/yyyy" ClientIDMode="AutoID" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Submission Date">

                                    <ItemTemplate>
                                        <asp:TextBox ID="txtEditReview" runat="Server" TextMode="SingleLine" Width="160px" enabled="false"
                                            ClientIDMode="AutoID" Text='<%# Eval("submissiondate") %>' DataFormatString="{0:d}" >                                             
                                        </asp:TextBox>
                                        <ajax:CalendarExtender SkinID="CalSkin" ID="CalendarExtender" runat="server" TargetControlID="txtEditReview"
                                            Format="dd/MM/yyyy" ClientIDMode="AutoID" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Close Date">

                                    <ItemTemplate>
                                        <asp:TextBox ID="txtCloseDate" runat="Server" TextMode="SingleLine" Width="160px" enabled="false"
                                            ClientIDMode="AutoID" Text='<%# Eval("closeddate") %>' DataFormatString="{0:d}" >                                             
                                        </asp:TextBox>
                                        <ajax:CalendarExtender SkinID="CalSkin" ID="closeddateCalendarExtender" runat="server" TargetControlID="txtCloseDate"
                                            Format="dd/MM/yyyy" ClientIDMode="AutoID" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                         <asp:Label SkinID="SklblLeft" ID="lblCloseNoRecords" runat="server"></asp:Label>
                         <asp:HiddenField ID="checkpostback" runat="server"/>  
                    </div>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
