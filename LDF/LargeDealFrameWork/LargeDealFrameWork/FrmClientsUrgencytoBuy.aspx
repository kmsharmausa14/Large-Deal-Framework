<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FrmClientsUrgencytoBuy.aspx.cs" Inherits="LargeDealFrameWork.ClientsUrgencytoBuy" %>
<asp:Content ID="HeadSyntelUrgencytoBuy" ContentPlaceHolderID="HeadContent" runat="server">
    <link rel="stylesheet" href="Styles/IS.css" />
<script type="text/javascript">
    function Sum() {
        var ddl1 = document.getElementById('<%= ddlscore1.ClientID %>');
        var ddl2 = document.getElementById('<%= ddlscore2.ClientID %>');
        var ddl3 = document.getElementById('<%= ddlScore3.ClientID %>');
        var ddl4 = document.getElementById('<%= ddlScore4.ClientID %>');
      

        var x1 = parseFloat(ddl1.options[ddl1.selectedIndex].text);
        var x2 = parseFloat(ddl2.options[ddl2.selectedIndex].text);
        var x3 = parseFloat(ddl3.options[ddl3.selectedIndex].text);
        var x4 = parseFloat(ddl4.options[ddl4.selectedIndex].text);
      

        document.getElementById('<%= txtTotalScore.ClientID %>').value = x1 + x2 + x3 + x4;
        document.getElementById('<%= hidscoreClientsUrgency.ClientID %>').value = x1 + x2 + x3 + x4;

        /// For flag updation
        if (document.getElementById('<%= HidCounter.ClientID %>').value == "1") {
            document.getElementById('<%= hidUpdateValue.ClientID %>').value = "false";
            document.getElementById('<%= HidCounter.ClientID %>').value = "2";
        }
        else {
            document.getElementById('<%= hidUpdateValue.ClientID %>').value = "true";
        }

        //HidCounter
    }
    function ClearMessages() {
        document.getElementById("lblmsg").innerHTML = "";
    }


    function ValidateDescription(txtfinal) {
        //debugger;
        var final = document.getElementById(txtfinal);
        if (final.value.length > 249) {

            event.returnValue = false;

        }
    }

    function update() {
        //debugger;
        document.getElementById('<%= hidUpdateValue.ClientID %>').value = true;
    }

    function RedirectwithoutSaving() {
        //debugger;
      
        if (document.getElementById('<%= hidUpdateValue.ClientID %>').value == "true") {
            var flag = confirm("Please save the data before navigating further?", "Yes", "No");
            if (flag == true) {
                return false;
            }
            else {
                return true;
            }
        }
    }

    jQuery.fn.ForAlphanumericNumericCommaFullstop =
            function () {
                return this.each(function () {
                    $(this).keypress(function (e) {
                        var regex = new RegExp("^[a-zA-Z0-9., ]+$");

                        // var unregex = new RegExp("^[/.,<>!@#$%^&*()_+={}[]\|?]");
                        var str = String.fromCharCode(!e.charCode ? e.which : e.charCode);
                        if (regex.test(str) || e.keyCode == 8 || e.keyCode == 9) {
                            return true;
                        }
                        else if (e.keyCode == 188 || e.keyCode == 190 || e.keyCode == 46 || e.keyCode == 44 || e.keyCode == 190 || e.keyCode == 32) {
                            return true;
                        }
                        else {
                            e.preventDefault();
                            return false;
                        }
                    });
                });

            };

            $(document).ready(function () {
                Sum();
            });
    </script>
</asp:Content>
<asp:Content ID="ContentSyntelUrgencytoBuy" ContentPlaceHolderID="MainContent" runat="server">
    &nbsp;<table style="width: 100%; height: 100%">
        <tr style="width: 100%; height: 5%">
            <td style="width: 100%; height: 5%">
                <asp:Button ID="btnAccountQualification" runat="server" 
                    Text="Account Qualification" onclick="btnAccountQualification_Click" CausesValidation="false"  Font-Size="14px" Height="30px" Width="180px"
                     CssClass="SkbtnSkin"/>
            </td>
        </tr>
        <tr style="width: 100%; height: 5%">
            <td style="width: 100%; height: 5%; background-color: #CCCCCC;">
                <font style="font-family: Verdana; font-size: 15px; font-weight: bold; color: #000000">
                  Client's Propensity to Buy Now</font>
            </td>
        </tr>
         <tr style="width: 100%; height: 5%">
            <td style="width: 100%; height: 5%;">
              <asp:Label ID="lblmsg" runat="server" ForeColor="Green" Font-Bold="true"
                Font-Size="15px" Font-Names="Verdana"></asp:Label>
                <asp:ValidationSummary ID="validationSummaryScreenClientPropensityBuyNow" runat="server" ForeColor="Red" Font-Bold="true"
                Font-Size="14px" Font-Names="Verdana" />
                
            </td>
        </tr>
        <tr style="width: 100%; height: 55%">
            <td style="width: 100%; height: 55%">
                <table style="width: 100%; height: 100%" border="1">
                    <tr style="background-color: #C4D7FF">
                        <td style="width: 50%; height: 10%" align="center">
                            <font style="font-family: Verdana; font-size: 14px; font-weight: bold; color: #000000">
                                Parameter</font>
                        </td>
                        <td style="width: 20%; height: 10%" align="center">
                            <font style="font-family: Verdana; font-size: 14px; font-weight: bold; color: #000000">
                                Score(*)</font>
                        </td>
                        <td style="width: 30%; height: 10%" align="center">
                            <font style="font-family: Verdana; font-size: 14px; font-weight: bold; color: #000000">
                                Description(*)</font>
                        </td>
                    </tr>

                    <tr style="background-color: #EAF1FF;">
                        <td style="width: 50%; height: 20%; font-family: Verdana; font-size: 13px; color: #000000">
                            <font style="font-family: Verdana; font-size: 14px; color: #000000; font-weight: bold">1. <asp:Label ID="para1" runat="server" Text="How Much?  (From the client's perspective, is the return or potential significant?):"></asp:Label></font>
                            <pre><font style="font-family: Verdana; font-size: 13px; color: #000000">* Avoid high opportunity costs for not pursuing   * Incremental 
business benefits  * Gain competitive leadership  * Short-term and 
long-term gains  * Significant cost reduction or revenue gain</font> </pre>
                        <asp:Label ID="lblScoringRange1" runat="server" Text="Scoring Range : " style="font-weight:bold"></asp:Label>
                        <asp:Label ID="txtScoringRange1" runat="server" style="font-weight:bold"></asp:Label><br />
                        <asp:Label ID="lblScoringRangeDescription1" runat="server"  style="font-style:italic"></asp:Label>
                        </td>
                        <td style="width: 20%; height: 20%" align="center">
                        <asp:DropDownList ID="ddlscore1" runat="server" Width="50px" onchange="Sum()" CssClass="dropDownSkinOpportunityQualification"></asp:DropDownList>
                        </td>
                        <td style="width: 30%; height: 20%">
                        <asp:TextBox ID="txtDescription1" runat="server" TextMode="MultiLine" Height="120px" Width="350px" CssClass="textAreaOpportunityQualification"></asp:TextBox>
                         <script type="text/javascript">
                             $(document).ready(function () {
                                 $('#txtDescription1').ForAlphanumericNumericCommaFullstop();
                             });
                         </script>
                         <asp:RequiredFieldValidator ID="RequiredFieldDescription1" runat="server" ErrorMessage="Please enter description for How Much?" 
                         Text="*" ForeColor="White" ControlToValidate="txtDescription1"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    
                    <tr style="background-color: #EAF1FF;">
                         <td style="width: 50%; height: 20%; font-family: Verdana; font-size: 13px; color: #000000">
                            <font style="font-family: Verdana; font-size: 14px; color: #000000; font-weight: bold">2.<asp:Label ID="para2" runat="server" Text="How Soon?  (From the client's perspective, is the time to benefits compelling?):"></asp:Label> </font>
                            <pre><font style="font-family: Verdana; font-size: 13px; color: #000000">* Short time to recoup investments  * Short time for P&L improvement 
* Quick implementation and/or installation</font> </pre>
                        <asp:Label ID="lblScoringRange2" runat="server" Text="Scoring Range : " style="font-weight:bold"></asp:Label>
                        <asp:Label ID="txtScoringRange2" runat="server" style="font-weight:bold"></asp:Label><br />
                        <asp:Label ID="lblScoringRangeDescription2" runat="server"  style="font-style:italic"></asp:Label>
                        </td>
                        <td style="width: 20%; height: 20%" align="center">
                        <asp:DropDownList ID="ddlscore2" runat="server" Width="50px" onchange="Sum()" CssClass="dropDownSkinOpportunityQualification"></asp:DropDownList>
                        </td>
                        <td style="width: 30%; height: 20%">
                        <asp:TextBox ID="txtDescription2" runat="server" TextMode="MultiLine" Height="120px" Width="350px" CssClass="textAreaOpportunityQualification"></asp:TextBox>
                         <script type="text/javascript">
                             $(document).ready(function () {
                                 $('#txtDescription2').ForAlphanumericNumericCommaFullstop();
                             });
                         </script>
                         <asp:RequiredFieldValidator ID="RequiredFieldDescription2" runat="server" ErrorMessage="Please enter description for How Soon?" 
                         Text="*" ForeColor="White" ControlToValidate="txtDescription2"></asp:RequiredFieldValidator>
                        
                        </td>
                    </tr>

                     <tr style="background-color: #EAF1FF;">
                         <td style="width: 50%; height: 20%; font-family: Verdana; font-size: 13px; color: #000000">
                            <font style="font-family: Verdana; font-size: 14px; color: #000000; font-weight: bold">3.<asp:Label ID="para3" runat="server" Text="How Sure?  (From the client's perspective, how speculative is this?):"></asp:Label> </font>
                            <pre><font style="font-family: Verdana; font-size: 13px; color: #000000">* Too many unpredictable variables   * Unproven solution  * No comparable 
references  * Marginal solution fit  * Track record of vendor/supplier</font> </pre>
                        <asp:Label ID="lblScoringRange3" runat="server" Text="Scoring Range : " style="font-weight:bold"></asp:Label>
                        <asp:Label ID="txtScoringRange3" runat="server" style="font-weight:bold"></asp:Label><br />
                        <asp:Label ID="lblScoringRangeDescription3" runat="server" style="font-style:italic"></asp:Label>
                        </td>
                        <td style="width: 20%; height: 20%" align="center">
                        <asp:DropDownList ID="ddlScore3" runat="server" Width="50px" onchange="Sum()" CssClass="dropDownSkinOpportunityQualification"></asp:DropDownList>
                        </td>
                        <td style="width: 30%; height: 20%">
                        <asp:TextBox ID="txtDescription3" runat="server" TextMode="MultiLine" Height="120px" Width="350px" CssClass="textAreaOpportunityQualification"></asp:TextBox>
                         <script type="text/javascript">
                             $(document).ready(function () {
                                 $('#txtDescription3').ForAlphanumericNumericCommaFullstop();
                             });
                         </script>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidatortxtDescription3" runat="server" ErrorMessage="Please enter description for How sure?" 
                         Text="*" ForeColor="White" ControlToValidate="txtDescription3"></asp:RequiredFieldValidator>
                        
                        </td>
                    </tr>

                     <tr style="background-color: #EAF1FF;">
                         <td style="width: 50%; height: 20%; font-family: Verdana; font-size: 13px; color: #000000">
                            <font style="font-family: Verdana; font-size: 14px; color: #000000; font-weight: bold">4.<asp:Label ID="para4" runat="server" Text="How Ready? (From the client's perspective, how capable are they of buying immediately?):"></asp:Label> </font>
                            <pre><font style="font-family: Verdana; font-size: 13px; color: #000000">* Contract renewal coming up * Sufficient budget allocated  * Sufficient
capability and capacity to be successful * Recent market position movements
* Complies with necessary regulations  * Leverages year-end budget excess * 
All decision makers are on board   * Buying research completed</font> </pre>
                        <asp:Label ID="lblScoringRange4" runat="server" Text="Scoring Range : " style="font-weight:bold"></asp:Label>
                        <asp:Label ID="txtScoringRange4" runat="server" style="font-weight:bold"></asp:Label><br />
                        <asp:Label ID="lblScoringRangeDescription4" runat="server"  style="font-style:italic"></asp:Label>
                        </td>
                        <td style="width: 20%; height: 20%" align="center">
                        <asp:DropDownList ID="ddlScore4" runat="server" Width="50px" onchange="Sum()" CssClass="dropDownSkinOpportunityQualification"></asp:DropDownList>
                        </td>
                        <td style="width: 30%; height: 20%">
                        <asp:TextBox ID="txtDescription4" runat="server" TextMode="MultiLine" Height="120px" Width="350px" CssClass="textAreaOpportunityQualification"></asp:TextBox>
                         <script type="text/javascript">
                             $(document).ready(function () {
                                 $('#txtDescription4').ForAlphanumericNumericCommaFullstop();
                             });
                         </script>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidatortxtDescription4" runat="server" ErrorMessage="Please enter description for How Ready?" 
                         Text="*" ForeColor="White" ControlToValidate="txtDescription4"></asp:RequiredFieldValidator>
                        
                        </td>
                    </tr>

                    <tr style="background-color: #C4D7FF">
                        <td style="width: 50%; height: 10%">
                         <font style="font-family: Verdana; font-size: 14px; font-weight: bold; color: #000000">
                             Client 's Urgency to Buy Scale:</font>
                        </td>
                        <td style="width: 20%; height: 10%" align="center">
                        <asp:TextBox ID="txtTotalScore" runat="server" Font-Bold="true" Font-Size="13px" ForeColor="Black" Height="30px" Width="50px" Enabled="false" CssClass="textSkinOpportunityQualification" style="text-align:left"></asp:TextBox>
                        </td>
                        <td style="width: 30%; height: 10%; font-family:Verdana; font-size:14px; font-weight:bold; color:Maroon">
                        <asp:Label ID="lblScoreDescription" runat="server"></asp:Label>
                        </td>
                        </tr>
                </table>
            </td>
        </tr>
        <tr style="width: 100%; height: 20%">
            <td style="width: 100%; height: 20%; font-size:14px" align="left">
             <asp:GridView ID="gvScaleScore" runat="server" AutoGenerateColumns="false" Width="40%" BorderStyle="Solid" BorderWidth="1px" BorderColor="Black">
            <HeaderStyle Font-Bold="true" ForeColor="White"  Font-Size="14px" CssClass="skGridInnerHeader"/>
                                                <RowStyle ForeColor="Black" Font-Bold="true" Font-Size="12px" CssClass="skGridInnerRow" />
                                                <SelectedRowStyle CssClass="skGridInnerSelectedRow" />
                                                <AlternatingRowStyle CssClass="skGridInnerAlternatingRow" />
                                                <FooterStyle CssClass="skGridInnerFooter" />
            <Columns>
                <asp:TemplateField HeaderText="Scale" ItemStyle-Width="20%" HeaderStyle-HorizontalAlign="Left">
                    <ItemTemplate>
                        <%#Eval("vsScale")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Description" ItemStyle-Width="60%" HeaderStyle-HorizontalAlign="Left">
                    <ItemTemplate>
                        <%#Eval("vsDesc")%>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>

            </td>
        </tr>
        <tr style="width: 100%; height: 10%">
            <td style="width: 100%; height: 10%" align="center">
             <asp:Button ID="btnBack" runat="server" Text="Back" onclick="btnBack_Click" CausesValidation="false" OnClientClick="return RedirectwithoutSaving()" CssClass="SkbtnSkin" Height="30px" 
                    Width="60px"/>&nbsp;&nbsp;
             <asp:Button ID="btnSave" runat="server" Text="Save" Height="30px" Width="60px" onclick="btnSave_Click" OnClientClick="ClearMessages()"  CssClass="SkbtnSkin"/>&nbsp;&nbsp;
             <asp:Button ID="btnNext" runat="server" Text="Next" Height="30px" Width="60px"  onclick="btnNext_Click" CausesValidation="false" OnClientClick="return RedirectwithoutSaving()"  CssClass="SkbtnSkin"/>
             <asp:HiddenField ID="hidscoreClientsUrgency" runat="server" />
             <asp:HiddenField ID="hidInsertOpportunity" runat="server" Value="true"/>
             <asp:HiddenField ID="hidUpdateValue" runat="server" Value="false" />
              <asp:HiddenField ID="HidCounter" runat="server" />
            </td>
           
        </tr>
    </table>
</asp:Content>
