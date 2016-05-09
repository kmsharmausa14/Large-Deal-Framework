<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="FrmHomeScreenForDeliveryHead.aspx.cs" Inherits="LargeDealFrameWork.HomeScreenForDeliveryHead" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <meta charset="utf-8">
  
    <link rel="stylesheet" href="/resources/demos/style.css" />
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

        function assignCheckBC() {
            //debugger;
            var prime = document.getElementById('ddlprimarycontact');
            var sec = document.getElementById('ddlsecondarycontact');
            if (prime.value < 1) {
                alert("Enter Primary Contact");
                return false;
            }
            else {
                if (prime.value == sec.value) {
                    alert("Please select different contacts");
                    return false;
                }
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
    <ajax:ToolkitScriptManager ID="ScriptManager" runat="server">
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
                    <td style="width: 100%; height: 5%">
                        <asp:Label runat="server" ID="lblselectsales" Text="Select Sales Member:" SkinID="SklblLeft"></asp:Label>
                        <asp:DropDownList runat="server" ID="ddlselectsales" AutoPostBack="True" OnSelectedIndexChanged="ddlselectsales_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr style="width: 100%; height: 60%">
                    <td style="width: 100%; height: 100%" valign="top">
                        <div id="tabs">
                            <ul>
                                <li><a href="#div_openopprDH">Open Opportunities</a></li>
                                <li><a href="#div_closedopprDH">Close Opportunities</a></li>
                            </ul>
                            <div id="div_openopprDH"  runat="server" align="center">
                                <asp:GridView ID="gvOpenOpportunities" runat="server" AutoGenerateColumns="False"
                                    OnRowCommand="gvOpenOpportunities_RowCommand" Width="80%" 
                                    OnRowDataBound="gvOpenOpportunities_RowDataBound" 
                                    onpageindexchanging="gvOpenOpportunities_PageIndexChanging" AllowPaging="true" 
                            PageSize="10">
                                    <HeaderStyle CssClass= "skGridInnerHeader" />
                                    <RowStyle CssClass="skGridInnerRow"/> 
                                    <SelectedRowStyle CssClass="skGridInnerSelectedRow" /> 
                                    <AlternatingRowStyle CssClass="skGridInnerAlternatingRow" /> 
                                    <FooterStyle CssClass="skGridInnerFooter" /> 
                                    <PagerStyle CssClass="skGridInnerRow" /> 
 
                                    <Columns>
                                        <asp:TemplateField HeaderText="Sr. No.">
                                            <ItemTemplate>
                                                <%# Container.DataItemIndex + 1 %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Opportunity ID">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="OppIDLnkButton" runat="server" CssClass="HyperLink" Text='<%#Eval("opportnumber") %>'
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
                                                <asp:TextBox ID="txtStartDat" runat="Server" TextMode="SingleLine" CssClass="textSkin"
                                                    ClientIDMode="AutoID" Text='<%# Eval("startdate","{0:MM-dd-yy}")%>'>                                             
                                                </asp:TextBox>
                                                <ajax:CalendarExtender ID="StartDatCalendarExtender" runat="server" TargetControlID="txtStartDat"
                                                    Format="dd/MM/yyyy" ClientIDMode="AutoID" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Submission Date">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtEditReview" runat="Server" TextMode="SingleLine" CssClass="textSkin"
                                                    ClientIDMode="AutoID" Text='<%# Eval("submissiondate") %>' DataFormatString="{0:d}">                                             
                                                </asp:TextBox>
                                                <ajax:CalendarExtender ID="CalendarExtender" runat="server" TargetControlID="txtEditReview"
                                                    Format="dd/MM/yyyy" ClientIDMode="AutoID" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Status">
                                            <ItemTemplate>
                                                <asp:LinkButton runat="server" ID="lnkCustomer" CssClass="HyperLink" Text='<%#Eval("status") %>' OnClick="lnkCustomer_Click"
                                                    CommandName="Assign" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                                <asp:Label ID="lblOpenNoRecords" SkinID="SklblLeft" Visible="false"
                                    runat="server"></asp:Label>
                            </div>
                            <div id="div_closedopprDH" runat="server" align="center">
                                <asp:GridView ID="gvCloseOpportunities" runat="server" AutoGenerateColumns="false"
                                    OnRowCommand="gvCloseOpportunities_RowCommand" Width="80%" ShowHeaderWhenEmpty="false"
                                    OnRowDataBound="gvCloseOpportunities_RowDataBound" 
                                    OnSelectedIndexChanged="gvCloseOpportunities_SelectedIndexChanged" AllowPaging="true" 
                            PageSize="10" onpageindexchanging="gvCloseOpportunities_PageIndexChanging" >
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
                                                <asp:LinkButton ID="OppIDLnkButton" runat="server" CssClass="HyperLink" Text='<%#Eval("opportnumber") %>'
                                                    CommandName="OppIdRedirect" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'>
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
                                                <asp:TextBox ID="txtStartDat" runat="Server" TextMode="SingleLine" CssClass="textSkin"
                                                    ClientIDMode="AutoID" Text='<%# Eval("startdate","{0:MM-dd-yy}")%>' Enabled="false">                                             
                                                </asp:TextBox>
                                                <ajax:CalendarExtender ID="StartDatCalendarExtender" runat="server" TargetControlID="txtStartDat"
                                                    Format="dd/MM/yyyy" ClientIDMode="AutoID" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Submission Date">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtEditReview" runat="Server" TextMode="SingleLine" CssClass="textSkin"
                                                    Enabled="false" ClientIDMode="AutoID" Text='<%# Eval("submissiondate") %>' DataFormatString="{0:d}">                                             
                                                </asp:TextBox>
                                                <ajax:CalendarExtender ID="CalendarExtender" runat="server" TargetControlID="txtEditReview"
                                                    Format="dd/MM/yyyy" ClientIDMode="AutoID" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Close Date">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtCloseDate" runat="Server" TextMode="SingleLine" CssClass="textSkin"
                                                    Enabled="false" ClientIDMode="AutoID" Text='<%# Eval("closeddate") %>' DataFormatString="{0:d}">                                             
                                                </asp:TextBox>
                                                <ajax:CalendarExtender ID="closeddateCalendarExtender" runat="server" TargetControlID="txtCloseDate"
                                                    Format="dd/MM/yyyy" ClientIDMode="AutoID" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                                <asp:Label ID="lblClosedNoRecords" runat="server" SkinID="SklblLeft" Visible="false"></asp:Label>
                                <br />
                                <asp:HiddenField ID="checkpostback" runat="server"/>  
                            </div>
                        </div>
                    </td>
                </tr>
            </table>
            <asp:Button runat="server" ID="lnkfake" CssClass="SkbtnSkin" Style="display: none" />
            <ajax:ModalPopupExtender ID="modal_assign" runat="server" PopupControlID="pnl_assign"
                TargetControlID="lnkfake" CancelControlID="btn_cancels" BackgroundCssClass="modalBackground">
            </ajax:ModalPopupExtender>
            <asp:Panel runat="server" ID="pnl_assign">
                <div id="div_assign" class="modalPopup">
                    <h1 align="center" style="color: #FF6600">
                        Assign Resource</h1>
                    <div>
                        <table align="left">
                             <tr style="height: 5%">
                        <td style="width: 100%; height: 5%" colspan="3" align="left">
                            <font style="font-family: Verdana; font-size: 16px; font-weight: bold; color: #339966">
                                Delivery Manager</font>
                        </td>
                    </tr>
                            <tr>
                                <td>
                                    <asp:Label runat="server" ID="lblprimarycntct" Text="Primary Contact:" SkinID="SklblLeft"></asp:Label><span style="color:Red">*</span>
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
                                    <asp:Label runat="server" ID="lblsecondarycntct" Text="Secondary Contact:" SkinID="SklblLeft"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlsecondarycontact" CssClass="div" runat="server">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:Label runat="server" ID="lbldisplaySecondaryContact" SkinID="SklblLeft"></asp:Label>
                                </td>
                            </tr>
                            <%-- <tr>
        <td>
            <asp:Label runat="server" ID="lblDeliveryManagerSpoc"  Text="Delivery Manager Spoc:" ForeColor="#999966"></asp:Label>
         </td>
         <td>   
            <asp:DropDownList ID="ddlDeliveryManagerSpoc" CssClass="div" runat="server"></asp:DropDownList>
        </td>
        <td>
            <asp:Label runat="server" ID="lbldisplayDeliveryManagerSpoc"></asp:Label>
        </td>
    </tr>--%>
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
                                    <%--<input type="button" id="btn_assigns"  runat="server" class="assignbutton" value="Assign"/>--%>
                                    <asp:Button runat="server" ID="btnassigns" Text="Assign" CssClass="SkbtnSkin" OnClick="btnAssign_Click"
                                        OnClientClick="return assignCheckBC()" />
                                    <%--<asp:Button runat="server" ID="btnReassign" Text="Reassign" Visible="false" CssClass="div"
                               onclick="btnReassign_Click" />--%>
                                    <span>&nbsp;&nbsp;&nbsp;&nbsp;</span>
                                    <input type="button" id="btn_cancels" runat="server" class="SkbtnSkin" value="Cancel" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
                </asp:Panel>
</asp:Content>
