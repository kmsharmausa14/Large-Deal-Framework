<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FrmSyntelBusinessPriorityScale.aspx.cs" Inherits="LargeDealFrameWork.SyntelBusinessPriorityScale" %>
<asp:Content ID="headSyntelBusinessPriorityScale" ContentPlaceHolderID="HeadContent" runat="server">
<link rel="stylesheet" href="Styles/IS.css" />
 <script type="text/javascript">
     function Sum() {
         var ddl1 = document.getElementById('<%= ddlscore1.ClientID %>');
         var ddl2 = document.getElementById('<%= ddlscore2.ClientID %>');
         var ddl3 = document.getElementById('<%= ddlScore3.ClientID %>');
         var ddl4 = document.getElementById('<%= ddlScore4.ClientID %>');
         var ddl5 = document.getElementById('<%= ddlScore5.ClientID %>');
         var ddl6 = document.getElementById('<%= ddlScore6.ClientID %>');
         var ddl7 = document.getElementById('<%= ddlScore7.ClientID %>');

         var x1 = parseFloat(ddl1.options[ddl1.selectedIndex].text);
         var x2 = parseFloat(ddl2.options[ddl2.selectedIndex].text);
         var x3 = parseFloat(ddl3.options[ddl3.selectedIndex].text);
         var x4 = parseFloat(ddl4.options[ddl4.selectedIndex].text);
         var x5 = parseFloat(ddl5.options[ddl5.selectedIndex].text);
         var x6 = parseFloat(ddl6.options[ddl6.selectedIndex].text);
         var x7 = parseFloat(ddl7.options[ddl7.selectedIndex].text);

         document.getElementById('<%= txtTotalScore.ClientID %>').value = x1 + x2 + x3 + x4 + x5 + x6 + x7;
         document.getElementById('<%= hidScoreSyntelBusiness.ClientID %>').value = x1 + x2 + x3 + x4 + x5 + x6 + x7;

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
         document.getElementById("lblMsg").innerHTML = "";
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
     function ValidateDescription(txtfinal) {
         //debugger;
         var final = document.getElementById(txtfinal);
         if (final.value.length > 249) {

             event.returnValue = false;

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
<asp:Content ID="ContentSyntelBusinessPriorityScale" ContentPlaceHolderID="MainContent" runat="server">
    &nbsp;<table style="width: 100%; height: 100%">
        <tr style="width: 100%; height: 5%">
            <td style="width: 20%; height: 5%">
                <asp:Button ID="btnAccountQualification" runat="server" 
                    Text="Account Qualification" onclick="btnAccountQualification_Click" CausesValidation="false" CssClass="SkbtnSkin" Font-Size="14px" Height="30px" Width="180px"/>
            </td>
              <td style="width: 80%; height: 5%" align="center">
                <asp:Label ID="lblHeaderMsg" runat="server" Font-Bold="true" Font-Size="14px" Font-Names="Verdana" ForeColor="#003399"></asp:Label>
            </td>
        </tr>
        <tr style="width: 100%; height: 5%">
            <td colspan="2" style="width: 100%; height: 5%; background-color: #CCCCCC;">
                <font style="font-family: Verdana; font-size: 15px; font-weight: bold; color: #000000">
                  Syntel's Propensity to Sell</font>
            </td>
        </tr>
         <tr style="width: 100%; height: 5%">
            <td colspan="2" style="width: 100%; height: 5%;">
              <asp:Label ID="lblMsg" runat="server" ForeColor="Green" Font-Bold="true"
                Font-Size="15px" Font-Names="Verdana"></asp:Label>
                <asp:ValidationSummary ID="validationSummaryScreenSyntelPropensitySell" runat="server" ForeColor="Red" Font-Bold="true"
                Font-Size="14px" Font-Names="Verdana" />
                
            </td>
        </tr>
        <tr style="width: 100%; height: 55%">
            <td colspan="2" style="width: 100%; height: 55%">
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
                            <font style="font-family: Verdana; font-size: 14px; color: #000000; font-weight: bold">1. <asp:Label ID="para1" runat="server" Text="Initial Revenue:"></asp:Label></font>
                            <pre><font style="font-family: Verdana; font-size: 13px; color: #000000">* Size of deal relative to Syntel's average deal </font> </pre>
                        <asp:Label ID="lblScoringRange1" runat="server" Text="Scoring Range : " style="font-weight:bold"></asp:Label>
                        <asp:Label ID="txtScoringRange1" runat="server" style="font-weight:bold"></asp:Label><br />
                        <asp:Label ID="lblScoringRangeDescription1" runat="server" style="font-style:italic"></asp:Label>
                        </td>
                        <td style="width: 20%; height: 20%" align="center">
                        <asp:DropDownList ID="ddlscore1" runat="server" Width="50px" onchange="Sum()" Enabled="false" CssClass="dropDownSkinOpportunityQualification"></asp:DropDownList>
                        </td>
                        <td style="width: 30%; height: 20%">
                        <asp:TextBox ID="txtDescription1" runat="server" TextMode="MultiLine" Width="350px" CssClass="textAreaOpportunityQualification" Enabled="false"></asp:TextBox>
                         <script type="text/javascript">
                             $(document).ready(function () {
                                 $('#txtDescription1').ForAlphanumericNumericCommaFullstop();
                             });
                         </script>
                         <asp:RequiredFieldValidator ID="RequiredFieldDescription1" runat="server" ErrorMessage="Please enter description for Initial Revenue" 
                         Text="*" ForeColor="White" ControlToValidate="txtDescription1"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    
                    <tr style="background-color: #EAF1FF;">
                         <td style="width: 50%; height: 20%; font-family: Verdana; font-size: 13px; color: #000000">
                            <font style="font-family: Verdana; font-size: 14px; color: #000000; font-weight: bold">2.<asp:Label ID="para2" runat="server" Text="Potential Revenue Growth:"></asp:Label> </font>
                            <pre><font style="font-family: Verdana; font-size: 13px; color: #000000">* Repeat business  * Cross-selling  * Upselling  * Percent of 
client's available budget * Growing client * Stated M&A strategy 
* Other needy divisions or affiliates</font> </pre>
                        <asp:Label ID="lblScoringRange2" runat="server" Text="Scoring Range : " style="font-weight:bold"></asp:Label>
                        <asp:Label ID="txtScoringRange2" runat="server" style="font-weight:bold"></asp:Label><br />
                        <asp:Label ID="lblScoringRangeDescription2" runat="server" style="font-style:italic"></asp:Label>
                        </td>
                        <td style="width: 20%; height: 20%" align="center">
                        <asp:DropDownList ID="ddlscore2" runat="server" Width="50px" onchange="Sum()" Enabled="false" CssClass="dropDownSkinOpportunityQualification"></asp:DropDownList>
                        </td>
                        <td style="width: 30%; height: 20%">
                        <asp:TextBox ID="txtDescription2" runat="server" TextMode="MultiLine" CssClass="textAreaOpportunityQualification" Width="350px" Enabled="false"></asp:TextBox>
                         <script type="text/javascript">
                             $(document).ready(function () {
                                 $('#txtDescription2').ForAlphanumericNumericCommaFullstop();
                             });
                         </script>
                         <asp:RequiredFieldValidator ID="RequiredFieldDescription2" runat="server" ErrorMessage="Please enter description for Potential Revenue Growth" 
                         Text="*" ForeColor="White" ControlToValidate="txtDescription2"></asp:RequiredFieldValidator>
                        
                        </td>
                    </tr>

                     <tr style="background-color: #EAF1FF;">
                         <td style="width: 50%; height: 20%; font-family: Verdana; font-size: 13px; color: #000000">
                            <font style="font-family: Verdana; font-size: 14px; color: #000000; font-weight: bold">3.<asp:Label ID="para3" runat="server" Text="Risk:"></asp:Label> </font>
                            <pre><font style="font-family: Verdana; font-size: 13px; color: #000000">* Adequate capacity  * Level of project complexity  * Internal resource 
availability  * Timeline  * Success probability  * Solution stability 
* Other needy divisions or affiliates</font> </pre>
                        <asp:Label ID="lblScoringRange3" runat="server" Text="Scoring Range : " style="font-weight:bold"></asp:Label>
                        <asp:Label ID="txtScoringRange3" runat="server" style="font-weight:bold"></asp:Label><br />
                        <asp:Label ID="lblScoringRangeDescription3" runat="server" style="font-style:italic"></asp:Label>
                        </td>
                        <td style="width: 20%; height: 20%" align="center">
                        <asp:DropDownList ID="ddlScore3" runat="server" Width="50px" onchange="Sum()" Enabled="false" CssClass="dropDownSkinOpportunityQualification"></asp:DropDownList>
                        </td>
                        <td style="width: 30%; height: 20%">
                        <asp:TextBox ID="txtDescription3" runat="server" TextMode="MultiLine" CssClass="textAreaOpportunityQualification" Width="350px" Enabled="false"></asp:TextBox>
                         <script type="text/javascript">
                             $(document).ready(function () {
                                 $('#txtDescription3').ForAlphanumericNumericCommaFullstop();
                             });
                         </script>
                       <%--  <asp:RequiredFieldValidator ID="RequiredFieldValidatortxtDescription3" runat="server" ErrorMessage="Please enter description for Risk" 
                         Text="*" ForeColor="White" ControlToValidate="txtDescription3"></asp:RequiredFieldValidator>--%>
                        
                        </td>
                    </tr>

                     <tr style="background-color: #EAF1FF;">
                         <td style="width: 50%; height: 20%; font-family: Verdana; font-size: 13px; color: #000000">
                            <font style="font-family: Verdana; font-size: 14px; color: #000000; font-weight: bold">4.<asp:Label ID="para4" runat="server" Text="Profitability:"></asp:Label> </font>
                            <pre><font style="font-family: Verdana; font-size: 13px; color: #000000">* Specific margin projection  * Amount of cost of sales required to close deal 
* Levels of support costs  * High maintenance client 
* Uses our underutilized resources</font> </pre>
                        <asp:Label ID="lblScoringRange4" runat="server" Text="Scoring Range : " style="font-weight:bold"></asp:Label>
                        <asp:Label ID="txtScoringRange4" runat="server" style="font-weight:bold"></asp:Label><br />
                        <asp:Label ID="lblScoringRangeDescription4" runat="server" style="font-style:italic"></asp:Label>
                        </td>
                        <td style="width: 20%; height: 20%" align="center">
                        <asp:DropDownList ID="ddlScore4" runat="server" Width="50px" onchange="Sum()" Enabled="false" CssClass="dropDownSkinOpportunityQualification"></asp:DropDownList>
                        </td>
                        <td style="width: 30%; height: 20%">
                        <asp:TextBox ID="txtDescription4" runat="server" TextMode="MultiLine" CssClass="textAreaOpportunityQualification" Width="350px" Enabled="false"></asp:TextBox>
                         <script type="text/javascript">
                             $(document).ready(function () {
                                 $('#txtDescription4').ForAlphanumericNumericCommaFullstop();
                             });
                         </script>
                     <%--    <asp:RequiredFieldValidator ID="RequiredFieldValidatortxtDescription4" runat="server" ErrorMessage="Please enter description for Profitability" 
                         Text="*" ForeColor="White" ControlToValidate="txtDescription4"></asp:RequiredFieldValidator>--%>
                        
                        </td>
                    </tr>

                     <tr style="background-color: #EAF1FF;">
                         <td style="width: 50%; height: 20%; font-family: Verdana; font-size: 13px; color: #000000">
                            <font style="font-family: Verdana; font-size: 14px; color: #000000; font-weight: bold">5.<asp:Label ID="para5" runat="server" Text="Market Penetration:"></asp:Label> </font>
                            <pre><font style="font-family: Verdana; font-size: 13px; color: #000000">* New logo for Syntel * New industry for Syntel * Expanded depth 
within the account * New geography for Syntel</font> </pre>
                        <asp:Label ID="lblScoringRange5" runat="server" Text="Scoring Range : " style="font-weight:bold"></asp:Label>
                        <asp:Label ID="txtScoringRange5" runat="server" style="font-weight:bold"></asp:Label><br />
                        <asp:Label ID="lblScoringRangeDescription5" runat="server" style="font-style:italic"></asp:Label>
                        </td>
                        <td style="width: 20%; height: 20%" align="center">
                        <asp:DropDownList ID="ddlScore5" runat="server" Width="50px" onchange="Sum()" Enabled="false" CssClass="dropDownSkinOpportunityQualification"></asp:DropDownList>
                        </td>
                        <td style="width: 30%; height: 20%">
                        <asp:TextBox ID="txtDescription5" runat="server" TextMode="MultiLine" CssClass="textAreaOpportunityQualification" Width="350px" Enabled="false"></asp:TextBox>
                         <script type="text/javascript">
                             $(document).ready(function () {
                                 $('#txtDescription5').ForAlphanumericNumericCommaFullstop();
                             });
                         </script>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidatortxtDescription5" runat="server" ErrorMessage="Please enter description for Market Penetration" 
                         Text="*" ForeColor="White" ControlToValidate="txtDescription5"></asp:RequiredFieldValidator>
                        
                        </td>
                    </tr>

                     <tr style="background-color: #EAF1FF;">
                         <td style="width: 50%; height: 20%; font-family: Verdana; font-size: 13px; color: #000000">
                            <font style="font-family: Verdana; font-size: 14px; color: #000000; font-weight: bold">6.<asp:Label ID="para6" runat="server" Text="Marketing Advantages:"></asp:Label> </font>
                            <pre><font style="font-family: Verdana; font-size: 13px; color: #000000">* Marquee player  * Reference ability  * Demonstration site  * Up and performing </font> </pre>
                        <asp:Label ID="lblScoringRange6" runat="server" Text="Scoring Range : " style="font-weight:bold"></asp:Label>
                        <asp:Label ID="txtScoringRange6" runat="server" style="font-weight:bold"></asp:Label><br />
                        <asp:Label ID="lblScoringRangeDescription6" runat="server" style="font-style:italic"></asp:Label>
                        </td>
                        <td style="width: 20%; height: 20%" align="center">
                        <asp:DropDownList ID="ddlScore6" runat="server" Width="50px" onchange="Sum()" Enabled="false" CssClass="dropDownSkinOpportunityQualification"></asp:DropDownList>
                        </td>
                        <td style="width: 30%; height: 20%">
                        <asp:TextBox ID="txtDescription6" runat="server" TextMode="MultiLine" CssClass="textAreaOpportunityQualification" Width="350px" Enabled="false"></asp:TextBox>
                         <script type="text/javascript">
                             $(document).ready(function () {
                                 $('#txtDescription6').ForAlphanumericNumericCommaFullstop();
                             });
                         </script>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidatortxtDescription6" runat="server" ErrorMessage="Please enter description for Marketing Advantages" 
                         Text="*" ForeColor="White" ControlToValidate="txtDescription6"></asp:RequiredFieldValidator>
                        
                        </td>
                    </tr>

                     <tr style="background-color: #EAF1FF;">
                         <td style="width: 50%; height: 20%; font-family: Verdana; font-size: 13px; color: #000000">
                            <font style="font-family: Verdana; font-size: 14px; color: #000000; font-weight: bold">7.<asp:Label ID="para7" runat="server" Text="New Solution Development:"></asp:Label> </font>
                            <pre><font style="font-family: Verdana; font-size: 13px; color: #000000">* Laboratory  * Experimental  * Co-development  * Partners to market  
* Strategic solution  * Self funding or Co-funding </font> </pre>
                        <asp:Label ID="lblScoringRange7" runat="server" Text="Scoring Range : " style="font-weight:bold"></asp:Label>
                        <asp:Label ID="txtScoringRange7" runat="server" style="font-weight:bold"></asp:Label><br />
                        <asp:Label ID="lblScoringRangeDecription7" runat="server" style="font-style:italic"></asp:Label>
                        </td>
                        <td style="width: 20%; height: 20%" align="center">
                        <asp:DropDownList ID="ddlScore7" runat="server" Width="50px" onchange="Sum()" Enabled="false" CssClass="dropDownSkinOpportunityQualification"></asp:DropDownList>
                        </td>
                        <td style="width: 30%; height: 20%">
                        <asp:TextBox ID="txtDecription7" runat="server" TextMode="MultiLine" CssClass="textAreaOpportunityQualification" Width="350px" Enabled="false"></asp:TextBox>
                         <script type="text/javascript">
                             $(document).ready(function () {
                                 $('#txtDecription7').ForAlphanumericNumericCommaFullstop();
                             });
                         </script>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidatortxtDecription7" runat="server" ErrorMessage="Please enter description for New Solution Development" 
                         Text="*" ForeColor="White" ControlToValidate="txtDecription7"></asp:RequiredFieldValidator>
                        
                        </td>
                    </tr>

                    <tr style="background-color: #C4D7FF">
                        <td style="width: 50%; height: 10%">
                         <font style="font-family: Verdana; font-size: 14px; font-weight: bold; color: #000000">
                              Syntel 's Business Priority Scale :</font>
                        </td>
                        <td style="width: 20%; height: 10%" align="center">
                        <asp:TextBox ID="txtTotalScore" runat="server" CssClass="textAreaOpportunityQualification" Height="30px" Width="50px" Enabled="false"></asp:TextBox>
                        </td>
                        <td style="width: 30%; height: 10%; font-family:Verdana; font-size:14px; font-weight:bold; color:Maroon">
                        <asp:Label ID="lblScoreDescription" runat="server"></asp:Label>
                        </td>
                        </tr>
                </table>
            </td>
        </tr>
        <tr style="width: 100%; height: 20%">
            <td colspan="2" style="width: 100%; height: 20%; font-size:14px" align="left">
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
            <td colspan="2" style="width: 100%; height: 10%" align="center">
             <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="SkbtnSkin" Height="30px" Width="60px" onclick="btnBack_Click" CausesValidation="false" OnClientClick="return RedirectwithoutSaving()"/>&nbsp;&nbsp;
            <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="SkbtnSkin" Height="30px" Width="60px" onclick="btnSave_Click" OnClientClick="ClearMessages()"/>&nbsp;&nbsp;
             <asp:Button ID="btnNext" runat="server" Text="Next" CssClass="SkbtnSkin" Height="30px" Width="60px" onclick="btnNext_Click" CausesValidation="false" OnClientClick="return RedirectwithoutSaving()"/>
             <asp:HiddenField ID="hidScoreSyntelBusiness" runat="server" />
             <asp:HiddenField ID="hidSaveClickbySale" runat="server" Value="true"/>
              <asp:HiddenField ID="hidSaveClickbyDD" runat="server" Value="true"/>
               <asp:HiddenField ID="hidDisablecontrolsOnSubmit" runat="server" Value="true"/>
                <asp:HiddenField ID="hidUpdateValue" runat="server" Value="false" />
              <asp:HiddenField ID="HidCounter" runat="server" />
            </td>
           
        </tr>
    </table>
</asp:Content>
