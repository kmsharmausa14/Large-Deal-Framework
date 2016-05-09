<%@ Page Title="" Language="C#" MasterPageFile="~/maintab.Master" AutoEventWireup="true" CodeBehind="FrmQualificationmain.aspx.cs" Inherits="LargeDealFrameWork.Qualificationmain" %>
<asp:Content ID="Contentheadmaintab" ContentPlaceHolderID="HeadContentMainTab" runat="server">
   
    <link rel="stylesheet" href="Styles/IS.css" />
       <style type="text/css">
        .style1
        {
            height: 5%;
            width: 5%;
        }
        .style2
        {
            height: 50%;
            width: 5%;
        }
        .style3
        {
            height: 5%;
            width: 1%;
        }
        .style4
        {
            height: 5%;
            width: 2%;
            color: #000000;
        }
        .style5
        {
           
            border:solid thin black;
           
        }
    </style>
</asp:Content>
<asp:Content ID="ContentQualificationmain" ContentPlaceHolderID="MainContentMainTab" runat="server">

    <div style="width: 100%; height: 80%; background:#EAF1FF">
                <table id="tblMain" style="height: 100%; width: 100%; font-family: Verdana; font-size: 14px; background :#EAF1FF"><%--#EAF1FF  #EBEBEB--%>
                <tr style="height: 5%">
                <td style="height: 5%; width:50%" colspan="2" align="left">
                <asp:Label ID="lblmsg" runat="server" ForeColor="Red" Font-Names="Verdana" Font-Bold="true"></asp:Label><br />
               <asp:Label ID="Label5" Text="Opportunity Id " runat="server" Width="150px" style="text-align:left"></asp:Label>:
                 <asp:Label ID="Label6" runat="server" Width="170px" style="text-align:left"></asp:Label><br />
              
               <asp:Label ID="Label7" Text="Opportunity Name " runat="server" Width="150px" style="text-align:left"></asp:Label>:
               <asp:Label ID="Label8" runat="server" Width="300px" style="text-align:left"></asp:Label>
               </td>
                <td style="height: 5%; width:50%" colspan="2" align="right">
               <table  id="tblStatusDealType" visible="false" runat="server"  style="height: 100%; width:100%">
               <tr style="height: 100%; width:100%">
               <td style="height: 100%; width:100%">
             <asp:Label ID="lblSignOff" Text="Sign OFF " runat="server" Width="100px" style="text-align:left"></asp:Label>:
               <asp:Label ID="lblBUHead" runat="server" Width="170px" style="text-align:left"></asp:Label>
               </td>
               </tr>
                 <tr style="height: 100%; width:100%">
               <td style="height: 100%; width:100%">
                <asp:Label ID="lblStatusforBUHead" Text="Status " runat="server" Width="100px" style="text-align:left"></asp:Label>:
                 <asp:Label ID="lblStatusbyBUHead" runat="server" Width="170px" style="text-align:left"></asp:Label>
               </td>
               </tr>
               <tr style="height: 100%; width:100%">
               <td style="height: 100%; width:100%">
               <asp:Label ID="lblDeal" Text="Deal Type " runat="server" Width="100px" style="text-align:left"></asp:Label>:
                 <asp:Label ID="lblDealTypebyBUHead" runat="server" Width="170px" style="text-align:left"></asp:Label>
               </td>
               </tr>
              
               </table>
                </td>
                </tr>
                    <tr style="height: 5%">
                        <td style="height: 5%; background-color: #BAE2C8;" colspan="4">
                            <font style="font-family: Verdana; font-size: 16px; font-weight: bold; color: #000000">Account Qualifications(Key
                                Scores)</font>
                        </td>
                    </tr>
                    <tr style="height: 5%; width: 80%">
                        <td class="style1" style="font-family: Verdana; font-size: 15px; color: #000000; background-color: #EAF1FF;">
                            <asp:LinkButton ID="lnkClientPresenceScale" runat="server" Text="Client's Demand Presence Scale"
                                OnClick="lnkClientPresenceScale_Click" CssClass="HyperLinkOpportunityQualification"></asp:LinkButton>
                        </td>
                        <td class="style3" align="center" style="font-family: Verdana; font-size: 13px; color: #000000; background-color: #EAF1FF;">
                           <%-- <asp:TextBox ID="txtClientPresenceScale" runat="server" Width="50px"  Enabled="false" style="text-align:right"></asp:TextBox>--%>
                           <asp:TextBox ID="txtClientPresenceScale" runat="server" Width="50px"  Enabled="false" CssClass="textSkinOpportunityQualification"></asp:TextBox>
                        </td>
                        <td class="style4" style="font-family: Verdana; font-size: 15px; color: #000000; background-color: #EAF1FF;">
                            <asp:Label ID="lblscore1" runat="server" Text="Out of "></asp:Label>
                             <asp:Label runat="server" ID="lblClientPresenceScale" Text="12"></asp:Label>
                        </td>
                        <td style="height: 5%; width: 5%;font-family: Verdana; font-size: 13px; color: #000000; background-color: #EAF1FF;" rowspan="9">
                            <table id="tblOpportunityScale" style="height: 100%; width: 100%;font-family: Verdana; font-size: 13px; color: #000000; background-color: #EAF1FF;">
                                <tr style="height: 50%; width: 100%;">
                                    <td style="height: 50px; width: 30%;border-style: solid;border-width: thin; " align="left" 
                                        valign="middle" bgcolor="#DADADA">
                                        <asp:Label runat="server" ID="lblOpportunityScale" Text="Opportunity Probability Scale: " ForeColor="Black" Font-Bold="true" Font-Size="15px" Height="20px"></asp:Label>
                                    </td>
                                    <td style="border-style: solid; border-width: thin; height: 50px; width: 20%;" 
                                        valign="middle" align="center" bgcolor="White">
                                    <asp:Label ID="lblOpportunityScalePercenatge" runat="server" Height="20px" Width="20px" Font-Bold="true" ForeColor="Black" Font-Size="17px"></asp:Label>
                                    <asp:Label Text="%" runat="server" Font-Bold="true" ForeColor="Black" Font-Size="17px"></asp:Label>
                                      </td>
                                   
                                </tr>
                                <tr style="height: 10%; width: 100%">
                                    <td style="height: 10%; width: 40%;" colspan="2" align="left">
                                    </td>
                                </tr>
                                <tr style="height: 10%; width: 100%">
                                    <td style="height: 10%; width: 40%;" colspan="2" align="left">
                                    </td>
                                </tr>
                                <tr style="height: 10%; width: 100%">
                                    <td style="height:50px; width: 40%;color:Black;border-style: solid; border-width: thin;" colspan="2" align="center">
                                        <asp:Label ID="lblProbability" runat="server"  ForeColor="Black" BorderColor="Black" Font-Bold="true" Font-Size="15px"></asp:Label>
                                    </td>
                                </tr>
                                <tr style="height: 20%; width: 100%">
                                    <td style="height: 30%; width: 40%;" colspan="2" align="left">
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr style="height: 5%; width: 80%">
                        <td class="style1" style="font-family: Verdana; font-size: 13px; color: #000000; background-color: #EAF1FF;">
                        </td>
                        <td colspan="2"  style="font-family: Verdana; font-size: 13px; color: #000000; background-color: #EAF1FF;">
                        </td>
                    </tr>
                    <tr style="height: 5%; width: 40%;font-family: Verdana; font-size: 15px; color: #000000; background-color: #EAF1FF;">
                        <td class="style1" style="font-family: Verdana; font-size: 15px; color: #000000; background-color: #EAF1FF;">
                            <asp:LinkButton ID="lnkBusinessPriority" runat="server" 
                                Text="Syntel's Business Priority Scale" onclick="lnkBusinessPriority_Click" CssClass="HyperLinkOpportunityQualification"></asp:LinkButton>
                        </td>
                        <td class="style3" align="center">
                            <asp:TextBox ID="txtBusinessPriority" runat="server" Width="50px" Enabled="false" CssClass="textSkinOpportunityQualification"></asp:TextBox>
                        </td>
                        <td class="style4">
                            <asp:Label ID="Label1" runat="server" Text="Out of "></asp:Label>
                             <asp:Label runat="server" ID="lblBusinessPriority" Text="29"></asp:Label>
                        </td>
                    </tr>
                    <tr style="height: 5%; width: 80%">
                        <td class="style1" style="font-family: Verdana; font-size: 13px; color: #000000; background-color: #EAF1FF;">
                        </td>
                        <td colspan="2"  style="font-family: Verdana; font-size: 13px; color: #000000; background-color: #EAF1FF;">
                        </td>
                    </tr>
                    <tr style="height: 5%; width: 40%;font-family: Verdana; font-size: 15px; color: #000000; background-color: #EAF1FF;">
                        <td class="style1" style="font-family: Verdana; font-size: 15px; color: #000000; background-color: #EAF1FF;">
                            <asp:LinkButton ID="lnkUrgencyBuy" runat="server" 
                                Text="Client's Urgency to Buy" onclick="lnkUrgencyBuy_Click" CssClass="HyperLinkOpportunityQualification"></asp:LinkButton>
                        </td>
                        <td class="style3" align="center">
                            <asp:TextBox ID="txtUrgencybuy" runat="server" Width="50px" Enabled="false" CssClass="textSkinOpportunityQualification"></asp:TextBox>
                        </td>
                        <td class="style4">
                            <asp:Label ID="Label2" runat="server" Text="Out of "></asp:Label>
                             <asp:Label runat="server" ID="lblUrgencyBuyTotalScore" Text="20"></asp:Label>
                        </td>
                    </tr>
                    <tr style="height: 5%; width: 80%">
                        <td class="style1" style="font-family: Verdana; font-size: 15px; color: #000000; background-color: #EAF1FF;">
                        </td>
                        <td colspan="2"  style="font-family: Verdana; font-size: 15px; color: #000000; background-color: #EAF1FF;">
                        </td>
                    </tr>
                    <tr style="height: 5%; width: 40%;font-family: Verdana; font-size: 15px; color: #000000; background-color: #EAF1FF;">
                        <td class="style1" style="font-family: Verdana; font-size: 15px; color: #000000; background-color: #EAF1FF;">
                            <asp:LinkButton ID="lnkCompetitiveAdvantage" runat="server" 
                                Text="Syntel's Competitive Advantage" onclick="lnkCompetitiveAdvantage_Click" CssClass="HyperLinkOpportunityQualification"></asp:LinkButton>
                        </td>
                        <td class="style3" align="center">
                            <asp:TextBox ID="txtCompetiiveAdvantage" runat="server" Width="50px" Enabled="false" CssClass="textSkinOpportunityQualification"></asp:TextBox>
                        </td>
                        <td class="style4">
                            <asp:Label ID="Label3" runat="server" Text="Out of "></asp:Label>
                             <asp:Label runat="server" ID="lblCompAdvanTotalScore" Text="49"></asp:Label>
                        </td>
                    </tr>
                    <tr style="height: 5%; width: 80%">
                        <td class="style1" style="font-family: Verdana; font-size: 13px; color: #000000; background-color: #EAF1FF;">
                        </td>
                        <td colspan="2"  style="font-family: Verdana; font-size: 13px; color: #000000; background-color: #EAF1FF;">
                        </td>
                    </tr>
                    <tr style="height: 5%; width: 40%;font-family: Verdana; font-size: 15px; color: #000000; background-color: #EAF1FF;">
                        <td class="style1" style="font-family: Verdana; font-size: 15px; color: #000000; background-color: #EAF1FF;">
                            <asp:Label ID="lbltotalSummary" runat="server" Text="Total Summary Score :" ForeColor="Black" Font-Bold="true" Width="" ></asp:Label>
                            &nbsp;
                        </td>
                        <td class="style3" align="center">
                            <asp:TextBox ID="txttotalSummary" runat="server" Width="50px" Enabled="false" Font-Size="16px" Font-Bold="true" ForeColor="Black" CssClass="textSkinOpportunityQualification"></asp:TextBox>
                        </td>
                        <td class="style4">
                            <asp:Label ID="Label4" runat="server" Text="Out of "></asp:Label>
                            <asp:Label runat="server" ID="lbltotal" Text="110"></asp:Label>
                        </td>
                    </tr>
                    <tr style="height: 40%; width: 70%">
                        <td class="style2" colspan="4" valign="middle">
                            <div style="height: 98%; width: 100%;background-color: #EAF1FF" >
                                <br />
                                <br />
                                <br/>
                                <table id="tblScaleScore" style="border: 2px solid #000000; height: 120px; width: 100%">
                                    <tr style="height: 100%; width: 50%">
                                        <td style="height: 100%; width: 1%">
                                        </td>
                                        <td style="height:10px; width: 49%" valign="middle">
                                            <asp:GridView ID="gvScaleScore" runat="server" AutoGenerateColumns="false" Width="80%" Height="100px"
                                                BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" >
                                                <HeaderStyle Font-Bold="true" ForeColor="White"  Font-Size="14px" CssClass="skGridInnerHeader"/>
                                                <RowStyle ForeColor="Black" Font-Bold="true" Font-Size="12px" CssClass="skGridInnerRow" />
                                                <SelectedRowStyle CssClass="skGridInnerSelectedRow" />
                                                <AlternatingRowStyle CssClass="skGridInnerAlternatingRow" />
                                                <FooterStyle CssClass="skGridInnerFooter" />
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Scale" ItemStyle-Width="20%">
                                                        <ItemTemplate>
                                                            <%#Eval("vsScale")%>   
                                                        </ItemTemplate>
                                                        <ItemStyle Width="20%"></ItemStyle>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Description" ItemStyle-Width="60%">
                                                        <ItemTemplate>
                                                            <%#Eval("vsDesc")%>
                                                        </ItemTemplate>
                                                        <ItemStyle Width="60%"></ItemStyle>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </td>
                                        <td style="height: 100%; width: 50%">
                                            <table id="tblStatus" runat="server" visible="false" style="width: 100%; height: 100%;" >
                                               <%-- <tr style="width: 100%; height: 10%">
                                                    <td style="width: 100%; height: 10%; color:Black" align="left">
                                                        <asp:Label ID="lblSignoff" runat="server" Text="SIGNOFF "  Font-Size="15px"></asp:Label>
                                                       
                                                        <asp:Label ID="lblBUHead" runat="server" Text=" BU Head/Leadership Team " Font-Size="15px"></asp:Label>
                                                       
                                                        <asp:Label ID="lblApprove" runat="server" Text=" Approved"  Font-Size="15px"></asp:Label>
                                                    </td>
                                                </tr>--%>
                                                <tr style="width: 100%; height: 10%">
                                                    <td style="width: 50%; height: 10%; color:Black; font-weight:bold">
                                                        <asp:Label ID="lblStatus" runat="server" Text="Status :" Width="90px" style="vertical-align:top"></asp:Label>
                                                        &nbsp; &nbsp; &nbsp;
                                                        <asp:DropDownList ID="ddlApproveReject" runat="server" AppendDataBoundItems="true"
                                                            Width="115px" CssClass="dropDownSkinOpportunityQualification">
                                                            <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                        </asp:DropDownList>
                                                        <%--<asp:Button ID="btnNoGo" runat="server" Text="No Go" BackColor="#003399" Font-Bold="true"
                                                    ForeColor="White" />--%>
                                                    </td>
                                                    <td rowspan="2" style="width: 50%;color:Black; font-weight:bold; font-size:12px">
                                                      <asp:Label ID="lblComments" runat="server" Text="Comments :" Width="90px"  style="vertical-align:top"></asp:Label>
                                                        &nbsp; &nbsp; &nbsp;
                                                        <asp:TextBox  ID="txtComments" runat="server" Width="130px" Height="50px" TextMode="MultiLine" CssClass="textAreaOpportunityQualification"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr style="width: 100%; height: 10%">
                                                    <td style="width: 100%; height: 10%; color:Black; font-weight:bold" colspan="2">
                                                        <asp:Label ID="lblDealType" runat="server" Text="Deal Type :" Width="90px"></asp:Label>
                                                        &nbsp; &nbsp; &nbsp;
                                                        <asp:DropDownList ID="ddlLargeDeal" runat="server" AppendDataBoundItems="true" Width="115px" CssClass="dropDownSkinOpportunityQualification">
                                                            <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>

                                    </tr>
                                </table>
                                &nbsp; &nbsp; &nbsp;
                                <center style="height: 105px">
                                <table id="tblButtons" cellpadding="20%">
                                    <tr style="width: 100%; height: 10%">
                                         <td style="width: 100%; height: 10%">
                                           <%-- <asp:Button ID="btnSubmit" runat="server" Text="Submit" BackColor="#003399" Font-Bold="true"
                                                            ForeColor="White" valign="middle" Visible="false" style="vertical-align:middle"
                                                 onclick="btnSubmit_Click"/>--%>

                                                  <asp:Button ID="btnSubmit" runat="server" Text="Submit"  Visible="false" onclick="btnSubmit_Click" CssClass="SkbtnSkin"/>
                                        </td>
                                    </tr>
                                </table>
                                </center>
                            </div>
                        </td>
                    </tr>
                </table>
            </div>    
</asp:Content>
