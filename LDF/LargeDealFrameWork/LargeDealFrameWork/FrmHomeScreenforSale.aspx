<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="FrmHomeScreenforSale.aspx.cs" Inherits="LargeDealFrameWork.HomeScreenforSale" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<asp:Content ID="ContentHeadHomeScreenSale" ContentPlaceHolderID="HeadContent" runat="server">
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
                //debugger;
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

        function assignCheckGPT() {
            
            var prime = document.getElementById('ddlprimarycnct_GPT');
            var sec = document.getElementById('ddlseccnct_GPT');
            if (prime.value < 1) {
                alert("Enter primary contact");
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

        function UpdateCloseTab() {

        }

        function UpdateOpenTab() {
        }

        function assignCheckDD() {
           // debugger;
            var prime = document.getElementById('ddlprimarycontact');
            var sec = document.getElementById('ddlsecondrycontact');
            if (prime.value < 1) {
                alert("Enter primary contact");
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



        function assignCheckVPSH() {

            var prime = document.getElementById('ddlverticalpresaleshea');

            if (prime.value < 1) {
                alert("Enter the Vertical Pre-sales Head");
                return false;
            }

            else {
                alert("Assigned Successfully");
            }

        }
        function gvBusinessValidate(rowIndex) {

            var grid = document.getElementById('gvOpenOpportunities');
            if (grid != null) {
                var Inputs = grid.rows[rowIndex + 1].getElementsByTagName("input");

                if (Inputs[0].value > Inputs[1].value) {
                    Inputs[1].value = "";
                    alert("Submit date should be greater than start date");
                    return false;
                }



                return true;
            }
        }

        function gvBusinessValidateStartDate(rowIndex, currentdate) {
            //debugger;

            var grid = document.getElementById('gvOpenOpportunities');
            //hidCurrentDate
            //var cur = document.getElementById('HiddenField1').value;
            var cur = document.getElementById('<%= HiddenField1.ClientID %>').value;
            if (grid != null) {
                var Inputs = grid.rows[rowIndex + 1].getElementsByTagName("input");
                var startdate = Inputs[0].value;
                //var currentdate = new Date();
                if (startdate < cur) {
                    Inputs[0].value = "";
                    alert("Start date should be greater than or equal to current date");
                    return false;
                }



                return true;
            }
        }
        function RemoveSpecialChar(txtVal) {
            var startDate = document.getElementById('txtStartDat');
            var EndDate = document.getElementById('txtEditReview');
            if (startDate.value != '' && startDate.value.match(/^[\w ]+$/) == null) {
                startDate.value = startDate.value.replace(/[\W]/g, '');
            }
            if (EndDate.value != '' && EndDate.value.match(/^[\w ]+$/) == null) {
                EndDate.value = EndDate.value.replace(/[\W]/g, '');
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
        
         .modalPopupStatusTracker
        {
            background-color: #FFFFFF;
            border-width: 3px;
            border-style: solid;
            border-color: Gray;
            padding-top: 10px;
            padding-left: 10px;
            font-family: Verdana;
            width: 800px;
            height: 400px;
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
            opacity: 0.9;
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
        .style2
        {
            width: 43px;
        }
    </style>
</asp:Content>
<asp:Content ID="ContentMainHomeScreenSale" ContentPlaceHolderID="MainContent" runat="server">
    <ajax:ToolkitScriptManager ID="ScriptManagerHomeScreenGPT" runat="server">
    </ajax:ToolkitScriptManager>

    <table style="width: 100%; height: 70%">
        <tr style="width: 100%; height: 5%">
            <td style="width: 100%; height: 5%">
                <asp:Label SkinID="SklblHomeHead" ID="lblOpenCount" runat="server" ></asp:Label>
                <asp:Label SkinID="SklblHomeHead" ID="Label3" runat="server" Text=" Open Opportunities "></asp:Label> 
                   
                <asp:Label SkinID="SklblHomeHead" ID="lblCloseCount" runat="server" ></asp:Label>
                <asp:Label SkinID="SklblHomeHead" ID="Label6" runat="server" Text=" Close Opportunities "></asp:Label>
                    
                <asp:Label SkinID="SklblHomeHead" ID="lblLargeCount" runat="server" ></asp:Label>
                <asp:Label SkinID="SklblHomeHead" ID="Label5" runat="server" Text=" Large Deals "></asp:Label>
                
                <asp:Label SkinID="SklblHomeHead" ID="lblNonLargeCount" runat="server"></asp:Label>
                <asp:Label SkinID="SklblHomeHead" ID="Label4" runat="server" Text=" Non Large Deals "></asp:Label>
            </td>
        </tr>
       
        <tr style="width: 100%; height: 55%">
            <td style="width: 100%; height: 100%" valign="top">
                <div id="tabs">
                    <ul>
                        <li><a href="#tabs-1">Open Opportunities</a></li>
                        <li><a href="#tabs-2">Close Opportunities</a></li>
                    </ul>
                    <div id="tabs-1" align="center" style="height: 100%" onclick="UpdateOpenTab">
                        <asp:GridView ID="gvOpenOpportunities" runat="server" AutoGenerateColumns="false"
                            Width="80%" OnRowCommand="gvOpenOpportunities_RowCommand"
                            OnRowDataBound="gvOpenOpportunities_RowDataBound" AllowPaging="true" 
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
                                            ClientIDMode="AutoID" Text='<%# Eval("startdate","{0:MM-dd-yy}")%>'>                                             
                                        </asp:TextBox>
                                        <ajax:CalendarExtender ID="StartDatCalendarExtender" SkinID="CalSkin" runat="server" TargetControlID="txtStartDat"
                                            Format="MM/dd/yyyy" ClientIDMode="AutoID" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Submission Date">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtEditReview" runat="Server" TextMode="SingleLine" Width="160px"
                                            ClientIDMode="AutoID" Text='<%# Eval("submissiondate") %>' DataFormatString="{0:d}">                                             
                                        </asp:TextBox>
                                        <ajax:CalendarExtender ID="CalendarExtender" runat="server" TargetControlID="txtEditReview"
                                            Format="MM/dd/yyyy" ClientIDMode="AutoID" SkinID="CalSkin" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <%--<asp:TemplateField HeaderText="Start Date")%>
                                    <ItemTemplate>
                                        <%#Eval("startdate", "{0:MM-dd-yy}")%> 
                                    </ItemTemplate>
                                </asp:TemplateField>--%>
                                <%--<asp:TemplateField HeaderText="Submission Date")%>
                                    <ItemTemplate>
                                        <%#Eval("submissiondate", "{0:MM-dd-yy}")%>
                                    </ItemTemplate>
                                </asp:TemplateField>--%>
                                <asp:TemplateField HeaderText="Status DD">
                                    <ItemTemplate>
                                        <asp:LinkButton runat="server" SkinId="SklnkSkin" ID="lnkSales_DH" Text='<%#Eval("status Sales_DH") %>'
                                            OnClick="lnkSales_DH_Click" CommandName="Assign" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Status VPSH">
                                    <ItemTemplate>
                                        <asp:LinkButton runat="server" SkinId="SklnkSkin" ID="lnkSales_VPSH" Text='<%#Eval("status Sales_VPSH") %>'
                                            OnClick="lnkSales_VPSH_Click" CommandName="Assign Sales_VPSH" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Status GPTM">
                                    <ItemTemplate>
                                        <asp:LinkButton runat="server" SkinId="SklnkSkin" ID="lnkSales_GPTM" Text='<%#Eval("status Sales_GPTM") %>'
                                            OnClick="lnkSales_GPTM_Click" CommandName="Assign Sales_GPTM" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        <asp:HiddenField ID="HiddenField1" runat="server" />
                        <asp:HiddenField ID="checkpostback" runat="server"/>                        
                        <asp:Label ID="lblOpenNoRecords" SkinID="SklblLeft" runat="server"></asp:Label>
                        <br />
                        <div align="center">
                        <asp:Button ID="ButtonDate" runat="server"  Text="Submit Date" CssClass="SkbtnSkin" OnClick="btnSubmitDate_Click" />&nbsp;&nbsp;
                            </div>
                            <%--<asp:Button ID="ButtonStatus" runat="server" Text="Status" BackColor="#003399"
                            ForeColor="White" Font-Bold="true" Visible="false"/>--%>
                    </div>
                   <div id="tabs-2" align="center" style="height: 100%" onclick="UpdateCloseTab()">
                                <asp:GridView ID="gvCloseOpportunities" runat="server" 
                                    AutoGenerateColumns="false" OnRowCommand="gvCloseOpportunities_RowCommand"
                            Width="80%"  OnRowDataBound="gvCloseOpportunities_RowDataBound" AllowPaging="true" 
                                    PageSize="10" onpageindexchanging="gvCloseOpportunities_PageIndexChanging" DataKeyNames="opportnumber">
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
                                <asp:LinkButton ID="OppIDLnkButton" runat="server" SkinId="SklnkSkin" Text='<%#Eval("opportnumber") %>' CommandName="OppIdRedirect" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'>
                                </asp:LinkButton>
                                </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Opportunity Description">
                                    <ItemTemplate>
                                        <%#Eval("opportdesc") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Status" ItemStyle-Width="100px">
                                    <ItemTemplate>
                                        <asp:DropDownList ID="ddlstatus" runat="server" AppendDataBoundItems="true" DataTextField="status"
                                            Width="100%" Enabled="false" SkinId="SkDrpLst">
                                            <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                            <asp:ListItem Text="Win" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="Loss" Value="2"></asp:ListItem>
                                            <asp:ListItem Text="No Go" Value="3"></asp:ListItem>
                                            <asp:ListItem Text="Hold" Value="4"></asp:ListItem>
                                        </asp:DropDownList>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Start Date">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtStartDat" runat="Server" TextMode="SingleLine" Width="160px"
                                            ClientIDMode="AutoID" Text='<%# Eval("startdate","{0:MM-dd-yy}")%>' enabled="false">                                             
                                        </asp:TextBox>
                                        <ajax:CalendarExtender ID="StartDatCalendarExtender" runat="server" SkinId="CalSkin" TargetControlID="txtStartDat"
                                            Format="dd/MM/yyyy" ClientIDMode="AutoID" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Submission Date">

                                    <ItemTemplate>
                                        <asp:TextBox ID="txtEditReview" runat="Server" TextMode="SingleLine" Width="160px" enabled="false"
                                            ClientIDMode="AutoID" Text='<%# Eval("submissiondate") %>' DataFormatString="{0:d}" >                                             
                                        </asp:TextBox>
                                        <ajax:CalendarExtender ID="CalendarExtender" runat="server" SkinId="CalSkin" TargetControlID="txtEditReview"
                                            Format="dd/MM/yyyy" ClientIDMode="AutoID" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Close Date">

                                    <ItemTemplate>
                                        <asp:TextBox ID="txtCloseDate" runat="Server" TextMode="SingleLine" Width="160px" enabled="false"
                                            ClientIDMode="AutoID" Text='<%# Eval("closeddate") %>' DataFormatString="{0:d}" >                                             
                                        </asp:TextBox>
                                        <ajax:CalendarExtender ID="closeddateCalendarExtender" SkinId="CalSkin" runat="server" TargetControlID="txtCloseDate"
                                            Format="dd/MM/yyyy" ClientIDMode="AutoID" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                         <asp:Label ID="lblClosedNoRecords" SkinId="SklblLeft" runat="server" ></asp:Label>
                                <br />
                               
                                <asp:Button ID="btnSubmit" runat="server" Text="Submit"
                                     OnClick="btnSubmit_Click" CssClass="SkbtnSkin" />
                            </div>
                </div>
            </td>
        </tr>
        <tr style="width: 100%; height: 5%">
            <td style="width: 100%; height: 5%">

                <asp:Label ID="AssignLabel" SkinId="SklblLeft" runat="server" Text=""></asp:Label>

            </td>
        </tr>
        <tr style="width: 100%; height: 5%">
            <td style="width: 100%; height: 5%">
            </td>
        </tr>
      <%--  <tr style="width: 100%; height: 5%">
            <td style="width: 100%; height: 5%">
            </td>
        </tr>--%>
    </table>
    <asp:Button CssClass="SkbtnSkin" runat="server" ID="lnkfake"  Style="display: none" />
    <ajax:ModalPopupExtender ID="ModalPopupExtender_Three" runat="server" PopupControlID="pnl_assign"
        TargetControlID="lnkfake" CancelControlID="btn_cancel_sales" BackgroundCssClass="modalBackground">
    </ajax:ModalPopupExtender>
    <asp:Panel runat="server" ID="pnl_assign">
        <div id="div_assign" class="modalPopup">
            <h1 align="center" style="color: #FF6600">
                Assign Resource</h1>
            <div id="Div1" align="left" style="width: 100%; height: 65%">
                <table style="width: 100%; height: 100%">
                    <tr style="width: 100%; height: 5%">
                        <td style="width: 100%; height: 5%" colspan="3">
                            <font style="font-family: Verdana; font-size: 16px; font-weight: bold; color: #339966">
                                Delivery Directors</font>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label SkinId="SklblLeft" ID="Label1" runat="server" Text="Primary Contact:" ></asp:Label>
                            <asp:Label SkinId="SklblLeft" ID="lbl1asterik" runat="server" Text="*" ForeColor="Red"></asp:Label>
                        </td>
                        
                        <td>
                            <asp:DropDownList ID="ddlprimarycontact" SkinId="SkDrpLst" runat="server"  OnSelectedIndexChanged="ddlprimarycontact_SelectedIndexChanged"
                                AppendDataBoundItems="true">
                                <asp:ListItem Text="Select" Selected="True" Value="0"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td align="left">
                            <asp:Label SkinId="SklblLeft" ID="lblprimarycontact" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label SkinId="SklblLeft" ID="Label2" runat="server" Text="Secondary Contact:" ></asp:Label>
                        </td>
                        
                        <td>
                            <asp:DropDownList ID="ddlsecondrycontact" SkinId="SkDrpLst" runat="server"  OnSelectedIndexChanged="ddlprimarycontact_SelectedIndexChanged"
                                AppendDataBoundItems="true">
                                <asp:ListItem Text="Select" Selected="True" Value="0"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:Label SkinId="SklblLeft" ID="lblsecondrycontact" runat="server" Text=""></asp:Label>

                        </td>
                    </tr>
                    <tr>
                        <td>
                            <br />
                        </td>
                        <td align="center">
                            <input id="btnreassign" type="button" runat="server" visible="false" />
                            <asp:Button CssClass="SkbtnSkin" runat="server" ID="AssignDeliveryDirector" Text="Assign"  onclick="AssignDeliveryDirector_Click" onclientclick="return assignCheckDD();"/>
                            <asp:Button CssClass="SkbtnSkin" runat="server" ID="btn_cancel_sales" Text="Cancel"  />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </asp:Panel>
    <ajax:ModalPopupExtender ID="ModalPopupExtender_One" runat="server" PopupControlID="Panel1"
        TargetControlID="lnkfake" CancelControlID="Button1" BackgroundCssClass="modalBackground">
    </ajax:ModalPopupExtender>
    <asp:Panel runat="server" ID="Panel1">
        <div id="div2" class="modalPopup">
            <h1 align="center" style="color: #FF6600">
                Assign Resource</h1>
            <div id="Div4" align="left" style="width: 100%; height: 65%">
                <table style="width: 100%; height: 100%">
                    <tr style="width: 100%; height: 5%">
                        <td style="width: 100%; height: 5%" colspan="3">
                            <font style="font-family: Verdana; font-size: 16px; font-weight: bold; color: #339966">
                                GPT Manager</font>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label SkinId="SklblLeft" ID="lblprimarycnct_GPT" runat="server" Text="Primary Contact:" ></asp:Label>
                            <asp:Label SkinId="SklblLeft" ID="Label7" runat="server" Text="*" ForeColor="Red"></asp:Label>
                        </td>
                        
                        <td>
                            <asp:DropDownList SkinId="SkDrpLst" ID="ddlprimarycnct_GPT" runat="server"  OnSelectedIndexChanged="ddlprimarycontact_SelectedIndexChanged"
                                AppendDataBoundItems="true">
                                <asp:ListItem Text="Select" Selected="True" Value="0"></asp:ListItem>
                            </asp:DropDownList>
                            <input id="btnreassignGPT" type="button" runat="server" visible="false" />
                            <td>
                            <asp:Label SkinId="SklblLeft" ID="lblpostprimarycnct_GPT" runat="server" Text=""></asp:Label>
                        </td>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label SkinId="SklblLeft" ID="lblseccnct_GPT" runat="server" Text="Secondary Contact:" ></asp:Label>
                        </td>
                        
                        <td>
                            <asp:DropDownList SkinId="SkDrpLst" ID="ddlseccnct_GPT" runat="server"  OnSelectedIndexChanged="ddlprimarycontact_SelectedIndexChanged"
                                AppendDataBoundItems="true">
                                <asp:ListItem Text="Select" Selected="True" Value="0"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:Label SkinId="SklblLeft" ID="lblpostseccnct_GPT" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <br />
                        </td>
                        <td align="right">
                            <%--<input type="button" id="btnAssignGPT" class="assignbutton" runat="server" value="Assign" />--%>
                            <asp:Button CssClass="SkbtnSkin" runat="server" ID="btnAssignGPTM" Text="Assign"  OnClick="btnAssignGPTM_Click" onclientclick="return assignCheckGPT()"/>
                            <asp:Button CssClass="SkbtnSkin" runat="server" ID="Button1" Text="Cancel"  />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </asp:Panel>
    <ajax:ModalPopupExtender ID="ModalPopupExtender_Two" runat="server" PopupControlID="Panel2"
        TargetControlID="lnkfake" CancelControlID="Button2" BackgroundCssClass="modalBackground">
    </ajax:ModalPopupExtender>
    <asp:Panel runat="server" ID="Panel2" CssClass="modalPopup">
        <div id="div3" style="height: 80%">
            <h1 align="center" style="color: #FF6600">
                Assign Resource</h1>
            <div id="tabs-3" align="center" style="width: 100%; height: 80%">
                <table style="width: 100%; height:100%">
                    <tr style="height: 5%">
                        <td style="width: 100%; height: 5%" colspan="3" align="left">
                            <font style="font-family: Verdana; font-size: 16px; font-weight: bold; color: #339966">
                                Vertical Presales Head</font>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 30%">
                            <label SkinId="SklblLeft" id="lblprimarycontactVPH" runat="server" >
                                Primary Contact:</label>
                                <asp:Label SkinId="SklblLeft" ID="Label8" runat="server" Text="*" ForeColor="Red"></asp:Label>
                        </td>
                        
                   
                    
                       
                        <td align="left">
                            <asp:DropDownList runat="server" ID="ddlverticalpresaleshea" SkinId="SkDrpLst">
                                <asp:ListItem Text="Select" Selected="True" Value="0"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                         <td align="center">
                            <asp:Label ID="lblprimarycontact0" runat="server" Text="" SkinId="SklblLeft"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td align="right">
                            <%--<input type="button" id="btnAssignVPH" class="assignbutton" runat="server" value="Assign" />--%>
                            <asp:Button ID="btnAssignVPSH" runat="server" 
                                onclick="btnAssignVPH_Click" onclientclick="return assignCheckVPSH()" 
                                Text="Assign" CssClass="SkbtnSkin"/>
                                </td><td align="left">
                            <asp:Button ID="Button2" runat="server"  Text="Cancel" CssClass="SkbtnSkin" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </asp:Panel>
     <%--<ajax:ModalPopupExtender ID="ModalPopupExtenderStatusTracker" runat="server" PopupControlID="PanelStatusTracker"
        TargetControlID="ButtonStatus" CancelControlID="btnCancelStatusTracker" BackgroundCssClass="modalBackground">
    </ajax:ModalPopupExtender>
    <asp:Panel runat="server" ID="PanelStatusTracker">
        <div id="div5" class="modalPopupStatusTracker">
            <h1 align="center" style="color: #FF6600">
                Opportunity Status</h1>
            <div id="Div6" align="left" style="width: 100%; height: 75%">
                <table style="width: 100%; height: 100%">
                    <tr style="width: 100%; height: 5%">
                        <td style="width: 100%; height: 5%">
                            <font style="font-family: Verdana; font-size: 16px; font-weight: bold; color: #339966">
                                Status Tracker</font>
                        </td>
                    </tr>
                     <tr style="width: 100%; height: 5%">
                        <td style="width: 100%; height: 5%" align="center">
                        <asp:Label ID="lblOppID" runat="server" Text="Opportunity ID:"></asp:Label>&nbsp;&nbsp;&nbsp;
                        <asp:TextBox ID="txtOppID" runat="server"></asp:TextBox>&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnSearch" runat="server" Text="Search"></asp:Button>
                        </td>
                        </tr>
                    <tr style="width: 100%; height: 85%">
                    <td style="width: 100%; height: 85%" align="center" valign="middle">
                     <asp:GridView ID="gvStatusTracker" runat="server" AutoGenerateColumns="false"
                            Width="80%" ShowHeaderWhenEmpty="true">
                            <HeaderStyle Font-Size="12px" BorderColor="Black" BackColor="#999999" HorizontalAlign="Center"
                                VerticalAlign="Middle" ForeColor="Black" Font-Names="Verdana" />
                            <RowStyle Font-Size="13px" HorizontalAlign="Center" VerticalAlign="Middle" ForeColor="Black" />
                            <Columns>
                               
                                <asp:TemplateField HeaderText="Delivery Head">
                                    <ItemTemplate>
                                       
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Delivery Manager">
                                    <ItemTemplate>
                                      
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Vertical Presales Head">
                                    <ItemTemplate>
                                        
                                    </ItemTemplate>
                                </asp:TemplateField>
                              
                                <asp:TemplateField HeaderText="GPT Manager">
                                    <ItemTemplate>
                                      </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Bid Manager">
                                    <ItemTemplate>
                                      </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Bid Coordinator">
                                    <ItemTemplate>
                                      </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="BU Head">
                                    <ItemTemplate>
                                      </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    
                    </td>
                    </tr>
                    <tr style="width: 100%; height: 5%">
                       <td style="width: 100%; height: 5%" align="center">
                            <asp:Button runat="server" ID="btnCancelStatusTracker" Text="Cancel" CssClass="div" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </asp:Panel>--%>
    
</asp:Content>
