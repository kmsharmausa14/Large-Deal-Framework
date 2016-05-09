<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="FrmHomeScreenTopMgmt.aspx.cs" Inherits="LargeDealFrameWork.FrmHomeScreenTopMgmt" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <meta charset="utf-8">
    
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
<asp:Content ID="ContentMainHomeScreenTopMgmt" ContentPlaceHolderID="MainContent"
    runat="server">
    <ajax:ToolkitScriptManager ID="ScriptManagerHomeScreenGPT" runat="server">
    </ajax:ToolkitScriptManager>
    <table style="width: 100%; height: 70%">
        <tr style="width: 100%; height: 5%">
            <td style="width: 100%; height: 5%">
                 <asp:Label ID="lblOpenCount" runat="server"  SkinID="SklblHomeHead" ></asp:Label>
                 <asp:Label ID="Label3" runat="server" Text=" Open Opportunities" SkinID="SklblHomeHead"></asp:Label>
                 <asp:Label ID="lblCloseCount" runat="server"  SkinID="SklblHomeHead"></asp:Label>
                 <asp:Label ID="Label2" runat="server" Text=" Close Opportunities" SkinID="SklblHomeHead"></asp:Label>
                 <asp:Label ID="lblLargeCount" runat="server" SkinID="SklblHomeHead"></asp:Label>
                 <asp:Label ID="Label5" runat="server" Text=" Large Deals" SkinID="SklblHomeHead"></asp:Label>
                <asp:Label ID="lblNonLargeCount" runat="server"  SkinID="SklblHomeHead"></asp:Label>
                <asp:Label ID="Label4" runat="server" Text=" Non Large Deals " SkinID="SklblHomeHead"></asp:Label>
            </td>
        </tr>
        <tr style="width: 100%; height: 5%">
            <td style="width: 100%; height: 5%">
                <table style="width: 80%; height: 100%">
                    <tr>
                        <td>
                            <label id="lblselectvertical" runat="server" SkinID="SklblLeft">
                                Select Vertical:</label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlVerticalWithOpportunity" runat="server" AutoPostBack="true"
                                OnSelectedIndexChanged="ddlVerticalWithOpportunity_SelectedIndexChanged" SkinId="SkDrpLst">
                                <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>
                            <label id="lblselectsales" runat="server" SkinID="SklblLeft" >
                                Select Sales Member:</label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlSalesPersonwithOpportunity" runat="server" AutoPostBack="true"
                                OnSelectedIndexChanged="ddlSalesPersonwithOpportunity_SelectedIndexChanged" SkinId="SkDrpLst">
                                <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:LinkButton runat="server" ID="lnkadmin" Text="Work as Admin" onclick="lnkadmin_Click" SkinId="SklnkSkin" ></asp:LinkButton>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr style="width: 100%; height: 60%">
            <td style="width: 100%; height: 100%" valign="top">
                <div id="tabs">
                    <ul>
                        <li><a href="#div_openoppr" >Open Opportunities</a></li>
                        <li><a href="#div_closedoppr">Close Opportunities</a></li>
                    </ul>
                    
                    <div id="div_openoppr" class="div" runat="server" align="center">
                        <asp:GridView ID="gvOpenOpportunities" runat="server" 
                            AutoGenerateColumns="false" OnRowDataBound="gvOpenOpportunities_RowDataBound"
                            Width="80%" ShowHeaderWhenEmpty="false" 
                            OnRowCommand="gvOpenOpportunities_RowCommand" AllowPaging="true" 
                            PageSize="10" onpageindexchanging="gvOpenOpportunities_PageIndexChanging" >
                            <RowStyle CssClass="skGridInnerRow"/>
                            <SelectedRowStyle CssClass="skGridInnerSelectedRow" />
                            <AlternatingRowStyle CssClass="skGridInnerAlternatingRow" />
                            <HeaderStyle CssClass="skGridInnerHeader" />
                            <FooterStyle CssClass="skGridInnerFooter" />
                            <PagerStyle       CssClass="skGridInnerRow" />
                            <Columns>
                                <asp:TemplateField HeaderText="Sr.No.">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex + 1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                               <asp:TemplateField HeaderText="Opportunity ID">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="OppIDLnkButton" SkinId="SklnkSkin" runat="server"  Text='<%#Eval("opportnumber") %>'
                                                    CommandName="OppIdRedirect" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'>
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
                                        <ajax:CalendarExtender ID="StartDatCalendarExtender" runat="server" TargetControlID="txtStartDat"
                                            Format="dd/MM/yyyy" ClientIDMode="AutoID" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Submission Date">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtEditReview" runat="Server" TextMode="SingleLine" Width="160px"
                                            ClientIDMode="AutoID" Text='<%# Eval("submissiondate") %>' DataFormatString="{0:d}" >                                             
                                        </asp:TextBox>
                                        <ajax:CalendarExtender ID="CalendarExtender" runat="server" TargetControlID="txtEditReview"
                                            Format="dd/MM/yyyy" ClientIDMode="AutoID" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                            </Columns>
                        </asp:GridView>
                        <asp:Label ID="lblOpenNoRecords" runat="server" SkinID="SklblLeft"></asp:Label>
                    </div>
                    <div id="div_closedoppr" class="div" runat="server" align="center">
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" 
                            AllowPaging="true" PageSize="10"
                            Width="80%" ShowHeaderWhenEmpty="false" 
                            OnRowCommand="gvClosedOpportunities_RowCommand" 
                            OnRowDataBound="gvCloseOpportunities_RowDataBound" 
                            onpageindexchanging="GridView1_PageIndexChanging">
                           <RowStyle CssClass="skGridInnerRow"/>
                            <SelectedRowStyle CssClass="skGridInnerSelectedRow" />
                            <AlternatingRowStyle CssClass="skGridInnerAlternatingRow" />
                            <HeaderStyle CssClass="skGridInnerHeader" />
                            <FooterStyle CssClass="skGridInnerFooter" />
                            <PagerStyle       CssClass="skGridInnerRow" />
                            <Columns>
                             <asp:TemplateField HeaderText="Sr.No.">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex + 1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Opportunity Number">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="ClosedOppIDLnkButton" runat="server" SkinId="SklnkSkin"  Text='<%#Eval("OpportunityNo") %>'
                                                    CommandName="OppIdRedirect" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' >
                                                </asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                               <asp:TemplateField HeaderText="Opportunity Description">
                                    <ItemTemplate>
                                        <%#Eval("OpportunityDescription")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Start Date">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtStartDat" runat="Server" TextMode="SingleLine" Width="160px"
                                            ClientIDMode="AutoID" Text='<%# Eval("StartDate","{0:MM-dd-yy}")%>' Enabled="false">                                             
                                        </asp:TextBox>
                                        <ajax:CalendarExtender ID="StartDatCalendarExtender" runat="server" TargetControlID="txtStartDat"
                                            Format="dd/MM/yyyy" ClientIDMode="AutoID" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Submission Date">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtEditReview" runat="Server" TextMode="SingleLine" Width="160px"
                                            Enabled="false" ClientIDMode="AutoID" Text='<%# Eval("SubmissionDate") %>' DataFormatString="{0:d}">                                             
                                        </asp:TextBox>
                                        <ajax:CalendarExtender ID="CalendarExtender" runat="server" TargetControlID="txtEditReview"
                                            Format="dd/MM/yyyy" ClientIDMode="AutoID" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Close Date">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtCloseDate" runat="Server" TextMode="SingleLine" Width="160px"
                                            Enabled="false" ClientIDMode="AutoID" Text='<%# Eval("ClosedDate") %>' DataFormatString="{0:d}">                                             
                                        </asp:TextBox>
                                        <ajax:CalendarExtender ID="closeddateCalendarExtender" runat="server" TargetControlID="txtCloseDate"
                                            Format="dd/MM/yyyy" ClientIDMode="AutoID" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                 
                            </Columns>
                        </asp:GridView>
                        <asp:Label ID="lblClosedNoRecords" runat="server"  SkinID="SklblLeft"></asp:Label>
                         <asp:HiddenField ID="checkpostback" runat="server"/>  
                         <%--<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="true"
                            Width="80%" ShowHeaderWhenEmpty="true">
                            <HeaderStyle Font-Size="12px" BorderColor="Black" 
                                BackColor="#999999" HorizontalAlign="Center" VerticalAlign="Middle" ForeColor="Black"
                                Font-Names="Verdana" />
                            <RowStyle Font-Size="13px" HorizontalAlign="Center" VerticalAlign="Middle" ForeColor="Black" />
                            <Columns>
                             
                            </Columns>
                        </asp:GridView>--%>
                    </div>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
