<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FrmHomeScreenForDeliveryMgr.aspx.cs" Inherits="LargeDealFrameWork.FrmHomeScreenForDeliveryMgr" %>
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
        function assignCheckBC() {

            var prime = document.getElementById('ddlprimarycontact');

            if (prime.value < 1) {
                alert("Enter the Delivery Manager SPoC");
                return false;
            }

            else {
                alert("Assigned Successfully");
            }

        }

        
    </script>
    <style type="text/css">
        .modalPopup
        {
            background-color: #FFFFFF;
            border-width: 3px;
            border-style: solid;
            border-color: Gray;
            padding-top: 10px;
            padding-left: 10px;
            font-family: Verdana;
            width: 500px;
            height: 200px;
            border: 1px solid;
            border-bottom-left-radius: 1em;
            border-top-left-radius: 1em;
            border-top-right-radius: 1em;
            border-bottom-right-radius: 1em;
        }
        .aplha
        {
        }
        
        .modalBackground
        {
            background-color: ThreeDShadow;
            filter: alpha(opacity=80);
            opacity: 0.8;
            z-index: 10000;
        }
        .div
        {
            border: 1px solid;
            border-bottom-left-radius: 0.40em;
            border-top-left-radius: 0.40em;
            border-top-right-radius: 0.40em;
            border-bottom-right-radius: 0.40em;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<ajax:ToolkitScriptManager ID="ScriptManager" runat="server"></ajax:ToolkitScriptManager>
<asp:Button runat="server" ID="lnkfake" BackColor="White" BorderStyle="None" Style="display: none" />
<ajax:ModalPopupExtender ID="modal_assign" runat="server" PopupControlID="pnl_assign"
        TargetControlID="lnkfake" CancelControlID="btn_cancel_sales" BackgroundCssClass="modalBackground">
    </ajax:ModalPopupExtender>
    
<table style="width: 90%; height: 70%">
        <tr style="width: 100%; height: 5%">
            <td style="width: 100%; height: 5%">
                 <asp:Label ID="lblOpenCount" runat="server"  SkinID="SklblHomeHead" ></asp:Label>
                <asp:Label ID="Label3" runat="server" Text=" Open Opportunities, "  SkinID="SklblHomeHead" ></asp:Label>
                    <asp:Label ID="lblCloseCount" runat="server"  SkinID="SklblHomeHead" ></asp:Label>
                <asp:Label ID="Label2" runat="server" Text=" Close Opportunities, "  SkinID="SklblHomeHead" ></asp:Label>
                <asp:Label ID="lblLargeCount" runat="server"  SkinID="SklblHomeHead" ></asp:Label>
                <asp:Label ID="Label5" runat="server" Text=" Large Deals, " SkinID="SklblHomeHead" ></asp:Label>
                <asp:Label ID="lblNonLargeCount" runat="server"  SkinID="SklblHomeHead" ></asp:Label>
                <asp:Label ID="Label4" runat="server" Text=" Non Large Deals "  SkinID="SklblHomeHead" ></asp:Label>
            </td>
        </tr>
        
        <tr style="width: 100%; height: 65%">
            <td style="width: 100%; height: 100%" valign="top">
                <div id="tabs">
                    <ul>
                        <li><a href="#div_openoppr">Open Opportunities</a></li>
                        <li><a href="#div_closedoppr">Close Opportunities</a></li>
                    </ul>
                    <div id="div_openoppr" class="div" runat="server" style="width:100%;height:75%" align="center">
                        <asp:GridView ID="gvOpenOpportunities" runat="server" 
                            AutoGenerateColumns="false" OnRowDataBound="gvOpenOpportunities_RowDataBound"
                            Width="80%" ShowHeaderWhenEmpty="false" 
                            OnRowCommand="gvOpenOpportunities_RowCommand" AllowPaging="true" 
                            PageSize="10" onpageindexchanging="gvOpenOpportunities_PageIndexChanging">
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
                                                <asp:LinkButton ID="OppIDLnkButton" runat="server"  Text='<%#Eval("opportnumber") %>'
                                                    CommandName="OppIdRedirect" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' SkinId="SklnkSkin">
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
                                <asp:TemplateField HeaderText="Status">
                                    <ItemTemplate>
                                        <asp:LinkButton runat="server" ID="lnkCustomer" Text='<%#Eval("status") %>' OnClick="lnkCustomer_Click"
                                            CommandName="Assign" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' SkinId="SklnkSkin"></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                         <asp:Label ID="lblOpenNoRecords" SkinID="SklblLeft" runat="server"></asp:Label>
                    </div>
                    <div id="div_closedoppr" class="div" runat="server" style="width:100%;height:40%" align="center">
                        <asp:GridView ID="gvCloseOpportunities" runat="server" 
                            AutoGenerateColumns="false" OnRowCommand="gvCloseOpportunities_RowCommand"
                            Width="80%" ShowHeaderWhenEmpty="false" 
                            OnRowDataBound="gvCloseOpportunities_RowDataBound" AllowPaging="true" 
                                    PageSize="10" 
                            onpageindexchanging="gvCloseOpportunities_PageIndexChanging">
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
                                <asp:LinkButton ID="OppIDLnkButton" runat="server" SkinId="SklnkSkin" Text='<%#Eval("opportnumber") %>' CommandName="OppIdRedirect" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'>
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
                                       <%-- <asp:DropDownList ID="ddlstatus" runat="server" AppendDataBoundItems="true" DataTextField="status"
                                            Width="90%" Enabled="false">
                                            <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                            <asp:ListItem Text="Win" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="Loss" Value="2"></asp:ListItem>
                                            <asp:ListItem Text="No Go" Value="3"></asp:ListItem>
                                            <asp:ListItem Text="Hold" Value="4"></asp:ListItem>
                                        </asp:DropDownList>--%>
                                        <%#Eval("status")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Start Date">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtStartDat" runat="Server" TextMode="SingleLine" Width="160px"
                                            ClientIDMode="AutoID" Text='<%# Eval("startdate","{0:MM-dd-yy}")%>' enabled="false">                                             
                                        </asp:TextBox>
                                        <ajax:CalendarExtender ID="StartDatCalendarExtender" runat="server" TargetControlID="txtStartDat"
                                            Format="dd/MM/yyyy" ClientIDMode="AutoID" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Submission Date">

                                    <ItemTemplate>
                                        <asp:TextBox ID="txtEditReview" runat="Server" TextMode="SingleLine" Width="160px" enabled="false"
                                            ClientIDMode="AutoID" Text='<%# Eval("submissiondate") %>' DataFormatString="{0:d}" >                                             
                                        </asp:TextBox>
                                        <ajax:CalendarExtender ID="CalendarExtender" runat="server" TargetControlID="txtEditReview"
                                            Format="dd/MM/yyyy" ClientIDMode="AutoID" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Close Date">

                                    <ItemTemplate>
                                        <asp:TextBox ID="txtCloseDate" runat="Server" TextMode="SingleLine" Width="160px" enabled="false"
                                            ClientIDMode="AutoID" Text='<%# Eval("closeddate") %>' DataFormatString="{0:d}" >                                             
                                        </asp:TextBox>
                                        <ajax:CalendarExtender ID="closeddateCalendarExtender" runat="server" TargetControlID="txtCloseDate"
                                            Format="dd/MM/yyyy" ClientIDMode="AutoID" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                         <asp:Label ID="lblClosedNoRecords" runat="server" ForeColor="#003399" Font-Bold="true" Font-Size="12px"></asp:Label>
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
    <asp:Panel runat="server" ID="pnl_assign">
        <div id="div_assign" class="modalPopup">
            <h1 align="center" style="color: #FF6600">
                Assign Resource</h1>
            <div>
                <table align="left">
                    <tr style="height: 5%">
                        <td style="width: 100%; height: 5%" colspan="3" align="left">
                            <font style="font-family: Verdana; font-size: 16px; font-weight: bold; color: #339966">
                                Delivery Manager SPoc</font>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label runat="server" ID="lblprimarycntct" Text="Primary Contact:" SkinID="SklblLeft"></asp:Label><span style="color:Red">*</span>
                        </td>
                        <td>
                        <br />
                        <br />
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlprimarycontact" runat="server" CssClass="div">
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:Label runat="server" ID="lbldisplayPrimaryContact" SkinID="SklblLeft"></asp:Label>
                        </td>
                    </tr>
                    
                    <tr>
                        <td>
                            <span>
                                <br />
                            </span>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td colspan="2">
                        <asp:Button runat="server" ID="btnassignBC" Text="Assign" CssClass="SkbtnSkin" OnClick="btnassignBC_Click" onclientclick="return assignCheckBC()"/>
                            
                            <asp:Button runat="server" ID="btn_cancel_sales" Text="Cancel" CssClass="SkbtnSkin" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </asp:Panel>
</asp:Content>
