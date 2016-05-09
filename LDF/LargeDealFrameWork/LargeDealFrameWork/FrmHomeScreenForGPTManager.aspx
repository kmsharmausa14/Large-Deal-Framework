<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="FrmHomeScreenForGPTManager.aspx.cs" Inherits="LargeDealFrameWork.HomeScreenForGPTManager" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<asp:Content ID="ContentHeadHomeScreenGPT" ContentPlaceHolderID="HeadContent" runat="server">
    <meta charset="utf-8">
    <link href="Styles/IS.css" rel="stylesheet" type="text/css" />
    <%--<script type="text/javascript" src="jquery-ui-1.8.9.custom.min.js"></script>--%>
    <script src="<%= ResolveUrl ("~/Scripts/UserValidation.js") %>"></script>
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
    <script type="text/javascript">
        function assignCheckBM() {
            //debugger;
            var prime = document.getElementById('ddlprimarycontactsales');
            var sec = document.getElementById('ddlsecondarycontactsales');
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

        function ClearDropdownBC() {
            //debugger;
            var GPTPrimary = document.getElementById('ddlprimarycontact');
            var GPTsec = document.getElementById('ddlsecondarycontact');
            GPTPrimary.value = 0;
            GPTsec.value = 0;
        }

        $("#ddlprimarycontact").change(function () {

            var contact = $("#ddlprimarycontact option:selected").text();
            var seccontact = $("#ddlsecondrycontact option:selected").text();

            if (contact == seccontact) {
                if (contact == "Select") {
                    $('#lblprimarycontact').text("");
                }
                else {

                    alert(contact + " is already chosen as Delivery Director secondry contact.");
                    $("#ddlprimarycontact").val(0);
                    $('#lblprimarycontact').text("");
                }
            }
            else {
                $('#lblprimarycontact').text(contact + " is the Delivery Director primary contact.");
            }

        });

        $("#ddlprimarycontactsales").change(function () {

            var contact = $("#ddlprimarycontactsales option:selected").text();
            var seccontac = $("#ddlsecondrycontactsales option:selected").text();

            if (contact == seccontact) {
                if (contact == "Select") {
                    $('#lblprimarycontactsales').text("");
                }
                else {

                    alert(contact + " is already chosen as Delivery Director secondry contact.");
                    $("#ddlprimarycontactsales").val(0);
                    $('#lblprimarycontactsales').text("");
                }
            }
            else {
                $('#lblprimarycontactsales').text(contact + " is the Delivery Director primary contact.");
            }

        });




        function ClearDropdownBM() {
            //debugger;
            var GPTPrimary1 = document.getElementById('ddlprimarycontactsales');
            var GPTsec2 = document.getElementById('ddlsecondarycontactsales');
            GPTPrimary1.value = 0;
            GPTsec2.value = 0;
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
<asp:Content ID="ContentMainHomeScreenGPT" ContentPlaceHolderID="MainContent" runat="server">
    <ajax:ToolkitScriptManager ID="ScriptManagerHomeScreenGPT" runat="server">
    </ajax:ToolkitScriptManager>
    <table style="width: 100%; height: 70%">
        <tr style="width: 100%; height: 5%" class="HeadContentTD" >
            <td style="width: 100%; height: 5%" class="HeadContentTD">
                <asp:Label ID="lblOpenCount" runat="server" SkinID="SklblHomeHead"></asp:Label>
                <asp:Label ID="Label3" runat="server" Text=" Open Opportunities, " SkinID="SklblHomeHead" ></asp:Label>
                <asp:Label ID="lblCloseCount" runat="server" SkinID="SklblHomeHead"></asp:Label>
                <asp:Label ID="Label2" runat="server" Text=" Close Opportunities, " SkinID="SklblHomeHead" ></asp:Label>
                <asp:Label ID="lblLargeCount" runat="server" SkinID="SklblHomeHead"></asp:Label>
                <asp:Label ID="Label5" runat="server" Text=" Large Deals, " SkinID="SklblHomeHead"></asp:Label>
                <asp:Label ID="lblNonLargeCount" runat="server" SkinID="SklblHomeHead"></asp:Label>
                <asp:Label ID="Label4" runat="server" Text=" Non Large Deals " SkinID="SklblHomeHead"></asp:Label>
            </td>
        </tr>
        <tr style="width: 100%; height: 5%">
            <td colspan="5">
                <table style="width: 80%; height: 5%">
                    <tr>
                        <td>
                            <label id="lblselectvertical" runat="server" SkinID="SklblLeft">
                                Select Vertical:</label>
                            <asp:DropDownList ID="ddlVerticalWithOpportunity" runat="server" AutoPostBack="true"
                                OnSelectedIndexChanged="ddlVerticalWithOpportunity_SelectedIndexChanged">
                                <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>
                            <label id="lblselectsales" runat="server" SkinID="SklblLeft">
                                Select Sales Member:</label>
                            <asp:DropDownList ID="ddlSalesPersonwithOpportunity" runat="server" AutoPostBack="true"
                                OnSelectedIndexChanged="ddlSalesPersonwithOpportunity_SelectedIndexChanged">
                                <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                            </asp:DropDownList>
                             <asp:Label runat="server" ID="lblselect" Text="Please select a Sales Member" SkinID="SklblLeft"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr style="width: 100%; height: 60%">
            <td style="width: 100%; height: 100%" valign="top">
                <div id="tabs" runat="server">
                    <ul>
                        <li><a href="#div_openoppr">Open Opportunities</a></li>
                        <li><a href="#div_closedoppr">Close Opportunities</a></li>
                    </ul>
                    <div id="div_openoppr" class="div" runat="server" align="center">
                        <asp:GridView ID="gvOpenOpportunities" runat="server" AutoGenerateColumns="false"
                            Width="80%" ShowHeaderWhenEmpty="false" OnRowCommand="gvOpenOpportunities_RowCommand"
                            OnRowDataBound="gvOpenOpportunities_RowDataBound" AllowPaging="true" 
                            PageSize="10" onpageindexchanging="gvOpenOpportunities_PageIndexChanging" >
                            <PagerStyle CssClass="skGridInnerRow" />
                            <RowStyle CssClass="skGridInnerRow"/>
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
                                        <asp:LinkButton ID="OppIDLnkButton" runat="server" CssClass="HyperLink" Text='<%#Eval("OpportunityNo") %>'
                                            CommandName="OppIdRedirect" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'>
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
                                            ClientIDMode="AutoID" Text='<%# Eval("StartDate","{0:MM-dd-yy}")%>'>                                             
                                        </asp:TextBox>
                                        <ajax:CalendarExtender ID="StartDatCalendarExtender" SkinID="CalSkin" runat="server" TargetControlID="txtStartDat"
                                            Format="dd/MM/yyyy" ClientIDMode="AutoID" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Submission Date">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtEditReview" runat="Server" TextMode="SingleLine" Width="160px"
                                            ClientIDMode="AutoID" Text='<%# Eval("SubmissionDate") %>' DataFormatString="{0:d}">                                             
                                        </asp:TextBox>
                                        <ajax:CalendarExtender ID="CalendarExtender" SkinID="CalSkin" runat="server" TargetControlID="txtEditReview"
                                            Format="dd/MM/yyyy" ClientIDMode="AutoID" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Status">
                                    <ItemTemplate>
                                        <asp:LinkButton runat="server" ID="lnkCustomer" Text='<%#Eval("OppStatus") %>' OnClick="lnkCustomer_Click" CssClass="HyperLink"
                                            CommandName="Assign" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        <asp:Label ID="lblOpenNoRecords" ForeColor="#003399" Font-Bold="true" Font-Size="12px"
                            runat="server" Visible="false"></asp:Label>
                    </div>
                    <div id="div_closedoppr" class="div" runat="server" align="center">
                        <asp:GridView ID="gvCloseOpportunities" runat="server" AutoGenerateColumns="false"
                            Width="80%" ShowHeaderWhenEmpty="false"
                            OnRowCommand="gvClosedOpportunities_RowCommand" 
                            OnRowDataBound="gvCloseOpportunities_RowDataBound" AllowPaging="true" 
                            PageSize="10" onpageindexchanging="gvCloseOpportunities_PageIndexChanging" >
                            <PagerStyle CssClass="skGridInnerRow" />
                           <RowStyle CssClass="skGridInnerRow"/>
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
                                        <asp:LinkButton ID="ClosedOppIDLnkButton" runat="server" CssClass="HyperLink" Text='<%#Eval("OpportunityNo") %>'
                                            CommandName="OppIdRedirect" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'>
                                        </asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Opportunity Description">
                                    <ItemTemplate>
                                        <%#Eval("OpportunityDescription")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Status">
                                    <ItemTemplate>
                                        <%#Eval("OppStatus")%>
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
                                        <ajax:CalendarExtender ID="CalendarExtender" SkinID="CalSkin" runat="server" TargetControlID="txtEditReview"
                                            Format="dd/MM/yyyy" ClientIDMode="AutoID" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Close Date">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtCloseDate" runat="Server" TextMode="SingleLine" Width="160px"
                                            Enabled="false" ClientIDMode="AutoID" Text='<%# Eval("ClosedDate") %>' DataFormatString="{0:d}">                                             
                                        </asp:TextBox>
                                        <ajax:CalendarExtender ID="closeddateCalendarExtender" SkinID="CalSkin" runat="server" TargetControlID="txtCloseDate"
                                            Format="dd/MM/yyyy" ClientIDMode="AutoID" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        <asp:Label ID="lblClosedNoRecords" runat="server" ForeColor="#003399" Font-Bold="true"
                            Font-Size="12px"></asp:Label>
                            <asp:HiddenField ID="checkpostback" runat="server"/>
                    </div>
                </div>
            </td>
        </tr>
    </table>
    <asp:Button runat="server" ID="lnkfake" BackColor="White" BorderStyle="None" Style="display: none" />
    <ajax:ModalPopupExtender ID="modal_assign" runat="server" PopupControlID="pnl_assign"
        TargetControlID="lnkfake" CancelControlID="btn_cancel_sales" BackgroundCssClass="modalBackground">
    </ajax:ModalPopupExtender>
    <ajax:ModalPopupExtender ID="modal_assign_sales" runat="server" PopupControlID="pnl_assign_sales"
        TargetControlID="lnkfake" CancelControlID="btncancelsales" BackgroundCssClass="modalBackground">
    </ajax:ModalPopupExtender>
    <asp:Panel runat="server" ID="pnl_assign" CssClass="modalPopup">
        <div id="div_assign" >
            <h1 align="center" style="color: #FF6600">
                Assign Resource</h1>
            <div>
                <table align="left">
                    <tr style="height: 5%">
                        <td style="width: 100%; height: 5%" colspan="3" align="left">
                            <font style="font-family: Verdana; font-size: 16px; font-weight: bold; color: #339966">
                                Bid Co-ordinator</font>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label runat="server" ID="lblprimarycntct" Text="Primary Contact:" SkinID="SklblLeft"></asp:Label><span
                                style="color: Red">*</span>
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
                            <asp:Label runat="server" ID="lblsecondarycntct" Text="Secondary Contact:" SkinID="SklblLeft"></asp:Label>
                        </td>
                        <td>
                            <br />
                            <br />
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlsecondarycontact" CssClass="div" runat="server">
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:Label runat="server" ID="lbldisplaySecondaryContact"></asp:Label>
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
                            <asp:Button runat="server" ID="btnassignBC" Text="Assign" CssClass="SkbtnSkin" OnClick="btnassignBC_Click"
                                OnClientClick="return assignCheckBC()" />
                            <%--<input runat="server" id="btnassign" type="button" value="Assign" class="div" />
                            <span>&nbsp;&nbsp;&nbsp;&nbsp;</span>--%>
                            <asp:Button runat="server" ID="btn_cancel_sales" Text="Cancel" CssClass="SkbtnSkin" OnClientClick="return ClearDropdownBC()" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </asp:Panel>
    <asp:Panel runat="server" ID="pnl_assign_sales">
        <div id="div1" class="modalPopup">
            <h1 align="center" style="color: #FF6600">
                Assign Resource</h1>
            <div>
                <table align="left">
                    <tr style="height: 5%">
                        <td style="width: 100%; height: 5%" colspan="3" align="left">
                            <font style="font-family: Verdana; font-size: 16px; font-weight: bold; color: #339966">
                                Bid Manager</font>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label runat="server" ID="lblprimarycontactsales" Text="Primary Contact:" SkinID="SklblLeft"></asp:Label><span
                                style="color: Red">*</span>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlprimarycontactsales" runat="server" CssClass="div">
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:Label runat="server" ID="lbldisplayprimarycontactsales" SkinID="SklblLeft"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label runat="server" ID="lblsecondarycontactsales" Text="Secondary Contact:"
                               SkinID="SklblLeft"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlsecondarycontactsales" CssClass="div" runat="server">
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:Label runat="server" ID="lbldisplaysecondarycontactsales" SkinID="SklblLeft"></asp:Label>
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
                            <asp:Button runat="server" ID="btnassignBM" Text="Assign" CssClass="SkbtnSkin" OnClick="btnassignBM_Click"
                                OnClientClick="return assignCheckBM()" />
                            <asp:Button runat="server" ID="btncancelsales" Text="Cancel" CssClass="SkbtnSkin" OnClientClick="return ClearDropdownBM()" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </asp:Panel>
</asp:Content>
