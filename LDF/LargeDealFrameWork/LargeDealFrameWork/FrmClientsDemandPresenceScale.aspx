<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="FrmClientsDemandPresenceScale.aspx.cs" Inherits="LargeDealFrameWork.ClientDemandPressenceScale" %>

<%@ Register TagPrefix="ajax" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>
<asp:Content ID="headClientDemandPresenceScale" ContentPlaceHolderID="HeadContent"
    runat="server">
    <link rel="stylesheet" href="Styles/IS.css" />

    <script type="text/javascript">
        function Sum() {
            //debugger;
            var text1 = document.getElementById('<%= ddlscore1.ClientID %>');
            var text2 = document.getElementById('<%= ddlscore2.ClientID %>');
            var x = parseFloat(text1.options[text1.selectedIndex].text);
            var y = parseFloat(text2.options[text2.selectedIndex].text);

            document.getElementById('<%= txtTotalScore.ClientID %>').value = x + y;
            document.getElementById('<%= hidScoreClientsDemand.ClientID %>').value = x + y;

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

         $(document).ready(function(){
         Sum();
         });

    </script>
</asp:Content>
<asp:Content ID="ContentClientDemandPresenceScale" ContentPlaceHolderID="MainContent"
    runat="server">
    &nbsp;&nbsp;<table style="width: 100%; height: 100%">
        <tr style="width: 100%; height: 5%">
            <td style="width: 100%; height: 5%">
                <asp:Button ID="btnAccountQualification" runat="server" Font-Size="14px" Height="30px" Width="180px"
                    Text="Account Qualification" onclick="btnAccountQualification_Click" CausesValidation="false" CssClass="SkbtnSkin"/>
            </td>
        </tr>
        <tr style="width: 100%; height: 5%">
            <td style="width: 100%; height: 5%; background-color: #CCCCCC;">
                <font style="font-family: Verdana; font-size: 15px; font-weight: bold; color: #000000">
                    Client's Propensity to Buy</font>
            </td>
        </tr>
         <tr style="width: 100%; height: 5%">
            <td style="width: 100%; height: 5%;">
              <asp:Label ID="lblmsg" runat="server" CssClass="SklblLeft"></asp:Label>
                <asp:ValidationSummary ID="validationSummaryClientsDemand" runat="server" ForeColor="Red" Font-Bold="true"
                Font-Size="14px" Font-Names="Verdana" />                
            </td>
        </tr>
        <tr style="width: 100%; height: 55%">
            <td style="width: 100%; height: 55%">
                <table style="width: 100%; height: 100%;" border="1">
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
                    <tr>
                        <td style="width: 50%; height: 20%; font-family: Verdana; font-size: 13px; color: #000000; background-color: #EAF1FF;">
                            <font style="font-family: Verdana; font-size: 14px; color: #000000; font-weight: bold">1. <asp:Label ID="para1" runat="server" Text="Emotional Need:" CssClass="SklblLeft"></asp:Label></font>
                            <pre><font style="font-family: Verdana; font-size: 13px; color: #000000">*Feels of urgency *Pent-up demand *General Interest 
*Senior management&#39;s vocal banking *Strong receptivity to the solution</font> </pre>
                        <asp:Label ID="lblScoringRange1" runat="server" Text="Scoring Range : " CssClass="SklblLeft"></asp:Label>
                        <asp:Label ID="txtScoringRange1" runat="server" style="font-weight:bold"></asp:Label><br />
                        <asp:Label ID="lblScoringRangeDescription1" runat="server" style="font-style:italic"></asp:Label>
                        </td>
                        <td style="width: 20%; height: 20%; background-color: #EAF1FF;" align="center">
                        <asp:DropDownList ID="ddlscore1" runat="server" Width="50px" onchange="Sum()" CssClass="dropDownSkinOpportunityQualification"></asp:DropDownList>
                        </td>
                        <td style="width: 30%; height: 20%; background-color: #EAF1FF;">
                        <asp:TextBox ID="txtDescription1" runat="server" TextMode="MultiLine" CssClass="textAreaOpportunityQualification" Width="350px"></asp:TextBox>
                         <script type="text/javascript">
                            $(document).ready(function () {
                                $('#txtDescription1').ForAlphanumericNumericCommaFullstop();
                                         });
                         </script>
                         <asp:RequiredFieldValidator ID="RequiredFieldDescription1" runat="server" ErrorMessage="Please enter description for Emotional Need" 
                         Text="*" ForeColor="White" ControlToValidate="txtDescription1"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                         <td style="width: 50%; height: 20%; font-family: Verdana; font-size: 13px; color: #000000; background-color: #EAF1FF;">
                            <font style="font-family: Verdana; font-size: 14px; color: #000000; font-weight: bold">2.<asp:Label ID="para2" runat="server" Text="Business Logic based Need:"></asp:Label> </font>
                            <pre><font style="font-family: Verdana; font-size: 13px; color: #000000">*Client's business and financial rationalization for obtaining a product   
or service* Specific critical business problem is being addressed  * Mission critical 
and strategic alignment * Significant impact to critical business metrics</font> </pre>
                        <asp:Label ID="lblScoringRange2" runat="server" Text="Scoring Range : " style="font-weight:bold"></asp:Label>
                        <asp:Label ID="txtScoringRange2" runat="server" style="font-weight:bold"></asp:Label><br />
                        <asp:Label ID="lblScoringRangeDescription2" runat="server"  style="font-style:italic"></asp:Label>
                        </td>
                        <td style="width: 20%; height: 20%; background-color: #EAF1FF;" align="center">
                        <asp:DropDownList ID="ddlscore2" runat="server" Width="50px" onchange="Sum();" CssClass="dropDownSkinOpportunityQualification"></asp:DropDownList>
                        </td>
                        <td style="width: 30%; height: 20%; background-color: #EAF1FF;">
                        <asp:TextBox ID="txtDescription2" runat="server" TextMode="MultiLine" CssClass="textAreaOpportunityQualification" Width="350px"></asp:TextBox>
                         <script type="text/javascript">
                             $(document).ready(function () {
                                 $('#txtDescription2').ForAlphanumericNumericCommaFullstop();
                             });
                         </script>
                         <asp:RequiredFieldValidator ID="RequiredFieldDescription2" runat="server" ErrorMessage="Please enter description for Business Logic based Need" 
                         Text="*" ForeColor="White" ControlToValidate="txtDescription2"></asp:RequiredFieldValidator>
                        
                        </td>
                    </tr>
                    <tr style="background-color: #C4D7FF">
                        <td style="width: 50%; height: 10%">
                         <font style="font-family: Verdana; font-size: 14px; font-weight: bold; color: #000000">
                               Client 's Demand Presence Scale :</font>
                        </td>
                        <td style="width: 20%; height: 10%" align="center">
                        <asp:TextBox ID="txtTotalScore" runat="server" CssClass="textAreaOpportunityQualification" Width="50px" 
                              Height="30px" Enabled="false"></asp:TextBox>
                        </td>
                        <td style="width: 30%; height: 10%; font-family:Verdana; font-size:14px; font-weight:bold; color:Maroon">
                        <asp:Label ID="lblScoreDescription" runat="server" SkinID="SklblLeft"></asp:Label>
                        </td>
                        </tr>
                </table>
            </td>
        </tr>
        <tr style="width: 100%; height: 20%">
            <td style="width: 100%; height: 20%; font-size:14px" align="left">
             <asp:GridView ID="gvScaleScore" runat="server" AutoGenerateColumns="false" Width="40%" BorderWidth="1px" >
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

                <asp:HiddenField ID="HidCounter" runat="server" />

            </td>
        </tr>
        <tr style="width: 100%; height: 10%">
            <td style="width: 100%; height: 10%" align="center">
            <asp:Button ID="btnSave" runat="server" Text="Save" Height="30px" Width="60px"  
                    onclick="btnSave_Click" OnClientClick="ClearMessages()" CssClass="SkbtnSkin"/>
             <asp:Button ID="btnNext" runat="server" Text="Next" CssClass="SkbtnSkin" Height="30px" Width="60px"
                    onclick="btnNext_Click" CausesValidation="false" OnClientClick="return RedirectwithoutSaving()"  />
              
             <asp:HiddenField ID="hidScoreClientsDemand" runat="server" />
              <asp:HiddenField ID="hidSaveClick" runat="server" Value="true" />
               <asp:HiddenField ID="hidNext" runat="server" Value="true" />
               <asp:HiddenField ID="hidUpdateValue" runat="server" Value="false" />
            </td>
           
        </tr>
    </table>
</asp:Content>
