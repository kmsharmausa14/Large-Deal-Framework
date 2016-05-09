<%@ Page Title="BidWinability" Language="C#" MasterPageFile="~/maintab.Master" AutoEventWireup="true"
    CodeBehind="FrmBidWinability.aspx.cs" Inherits="LargeDealFrameWork.BidWinability" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<asp:Content ID="ContentBidWinabilityHead" ContentPlaceHolderID="HeadContentMainTab"
    runat="server">
    <link rel="stylesheet" href="Styles/IS.css"/>
    <style type="text/css">
        .style3
        {
            height: 10%;
            width: 54%;
        }
        .style4
        {
            height: 20%;
            width: 54%;
        }
        .style5
        {
        }
    </style>
    <script type="text/javascript">

        function show_alert() {
            var answer=(confirm("Please confirm it is OK to proceed...?"));
            if (answer == true)
                return true;
            else {
                return false;
            }
        }

    </script>
</asp:Content>
<asp:Content ID="ContentBidWinability" ContentPlaceHolderID="MainContentMainTab"
    runat="server">
    <div style="width: 100%; height: 74%; background: #EAF1FF;">  <%--overflow: scroll--%>
        <table style="height: 100%; width: 100%; font-family: Verdana; font-size: 14px; background: #EAF1FF"
            cellpadding="0" cellspacing="0">
            
            <tr style="height: 10%; width: 100%">
                <td style="height: 10%; width: 100%" colspan="2" align="center">
                    <font style="font-family:Book Antiqua; font-size: 18px; font-weight: bold;
                        color:Navy">Bid Winability</font>
                </td>
            </tr>
            
            <tr style="width: 100%; height: 2%">
                <td style="height: 2%; width: 100%" colspan="2">
                    <asp:Label ID="lblMessage" runat="server" Font-Size="13px" ForeColor="Green"></asp:Label><br />
                     <asp:Label ID="lblOppID" Text="Opportunity ID" runat="server" ></asp:Label>:
                      <asp:Label ID="txtOppID" runat="server" Font-Size="15px"></asp:Label><br />
                        <asp:Label ID="lblOppDesc" Text="Opportunity Name" runat="server" ></asp:Label>:
                         <asp:Label ID="txtOppDesc" runat="server" Font-Size="15px"></asp:Label><br /><br />
                </td>
            </tr>
        
            <tr style="width: 100%; height: 2%">
                <td style="background-color: #403636; height: 1%; width: 60%;" valign="middle" align="left">
                    <font style="font-family: Verdana; font-size: 14px; text-transform: uppercase; 
                        font-weight: bold; color: #FFFFFF">Uniqueness</font>
                </td>
                <td style="height: 100%; width: 30%;" rowspan="4">
                    <table style="height: 100%; width: 100%; border-left-color: Black; border-bottom-color: Black;"
                        cellpadding="0" cellspacing="0">
                        <tr style="width: 100%; height: 4%;">
                            <td style="border-right: 4px solid #000000; border-top: #000000; background-color: #003399;
                                height: 4%; width: 100%;" align="center">
                                <font style="text-transform: uppercase; font-weight: bold; font-family: Verdana;
                                    font-size: 14px; color: #FFFFFF">References</font>
                            </td>
                        </tr>
                        <tr style="height: 40%; width: 100%">
                            <td style="height: 47%; width: 100%;" valign="middle" align="center">
                                <table style="height: 100%; width: 100%; border-color: Black; color: Black; font-family: Verdana;
                                    font-size: 11px;" border="1" cellpadding="0" cellspacing="0">
                                    <tr style="width: 100%">
                                        <td style="width: 100%; background-color: #CCCCCC;" colspan="10">
                                            <font style="font-weight: bold; font-family: Verdana; font-size: 13px; color: #000000;">
                                                Opportunity Qualification</font>
                                        </td>
                                    </tr>
                                    <tr style="width: 100%">
                                        <td style="width: 60%">
                                            <font style="font-weight: bold; font-family: Verdana; font-size: 12px; color: #000000;">
                                                Criteria</font>
                                        </td>
                                        <td style="width: 15%">
                                            <font style="font-weight: bold; font-family: Verdana; font-size: 12px; color: #000000;">
                                                Performance</font>
                                        </td>
                                        <td style="width: 25%">
                                            <font style="font-weight: bold; font-family: Verdana; font-size: 12px; color: #000000;">
                                                Out of</font>
                                        </td>
                                    </tr>
                                    <tr style="width: 100%; background-color: #DDDDDD;">
                                        <td style="width: 60%" align="left">
                                            <asp:Label ID="lblCrit1" runat="server"></asp:Label>
                                        </td>
                                        <td style="width: 20%">
                                            <asp:Label ID="lblPer1" runat="server" Width="30px"></asp:Label>
                                        </td>
                                        <td style="width: 20%">
                                            <asp:Label ID="lblOut1" runat="server" Width="30px"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr style="width: 100%">
                                        <td style="width: 60%" align="left">
                                            <asp:Label ID="lblCrit2" runat="server"></asp:Label>
                                        </td>
                                        <td style="width: 20%">
                                            <asp:Label ID="lblPer2" runat="server" Width="30px"></asp:Label>
                                        </td>
                                        <td style="width: 20%">
                                            <asp:Label ID="lblOut2" runat="server" Width="30px"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr style="width: 100%; background-color: #DDDDDD;">
                                        <td style="width: 60%" align="left">
                                            <asp:Label ID="lblCrit3" runat="server"></asp:Label>
                                        </td>
                                        <td style="width: 20%">
                                            <asp:Label ID="lblPer3" runat="server" Width="30px"></asp:Label>
                                        </td>
                                        <td style="width: 20%">
                                            <asp:Label ID="lblOut3" runat="server" Width="30px" Height="16px"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr style="width: 100%">
                                        <td style="width: 60%" align="left">
                                            <asp:Label ID="lblCrit4" runat="server"></asp:Label>
                                        </td>
                                        <td style="width: 20%">
                                            <asp:Label ID="lblPer4" runat="server" Width="30px"></asp:Label>
                                        </td>
                                        <td style="width: 20%">
                                            <asp:Label ID="lblOut4" runat="server" Width="30px"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr style="width: 100%; background-color: #DDDDDD;">
                                        <td style="width: 60%" align="left">
                                            <asp:Label ID="lblCrit5" runat="server"></asp:Label>
                                        </td>
                                        <td style="width: 20%">
                                            <asp:Label ID="lblPer5" runat="server" Width="30px"></asp:Label>
                                        </td>
                                        <td style="width: 20%">
                                            <asp:Label ID="lblOut5" runat="server" Width="30px"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr style="height: 1%; width: 100%">
                            <td style="height: 1%; width: 100%">
                            </td>
                        </tr>
                        <tr style="height: 48%; width: 100%">
                            <td style="height: 48%; width: 100%; overflow: hidden" valign="top" align="center">
                                <table style="height: 100%; width: 100%; font-family: Verdana; font-size: 11px; color: #000000;
                                    border-color: Black" border="1" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td colspan="3" style="background-color: #CCCCCC;">
                                            <font style="font-weight: bold; font-family: Verdana; font-size: 13px; color: #000000;">
                                                RGY Checklist </font>
                                        </td>
                                    </tr>
                                    <tr style="width: 60%">
                                        <td align="center" style="width: 40%">
                                            <font style="font-weight: bold; font-family: Verdana; font-size: 12px; color: #000000;">
                                                Category</font>
                                        </td>
                                        <td align="center" style="width: 20%">
                                            <font style="font-weight: bold; font-family: Verdana; font-size: 12px; color: #000000;">
                                                Score</font>
                                        </td>
                                    </tr>
                                    <tr style="width: 60%; background-color: #DDDDDD;">
                                        <td align="left" style="width: 40%">
                                            Business Solution
                                        </td>
                                        <td style="width: 20%">
                                            <asp:Label ID="lbl1" runat="server" Text="0" Width="30px"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" style="width: 40%">
                                            Technical Solution
                                        </td>
                                        <td style="width: 20%">
                                            <asp:Label ID="lbl2" runat="server" Text="0" Width="30px"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr style="background-color: #DDDDDD;">
                                        <td align="left" style="width: 40%">
                                            Service Delivery Model
                                        </td>
                                        <td style="width: 20%">
                                            <asp:Label ID="lbl3" runat="server" Text="0" Width="30px"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" style="width: 40%">
                                            Transition Planning
                                        </td>
                                        <td style="width: 20%">
                                            <asp:Label ID="lbl4" runat="server" Text="0" Width="30px"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr style="background-color: #DDDDDD;">
                                        <td align="left" style="width: 40%">
                                            Governance/Engagement Model
                                        </td>
                                        <td style="width: 20%">
                                            <asp:Label ID="lbl5" runat="server" Text="0" Width="30px"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" style="width: 40%">
                                            Process and Methodologies
                                        </td>
                                        <td style="width: 20%">
                                            <asp:Label ID="lbl6" runat="server" Text="0" Width="30px"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr style="background-color: #DDDDDD;">
                                        <td align="left" style="width: 40%">
                                            HR and change management
                                        </td>
                                        <td style="width: 20%">
                                            <asp:Label ID="lbl7" runat="server" Text="0" Width="30px"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" style="width: 40%">
                                            Commercial & Pricing
                                        </td>
                                        <td style="width: 20%">
                                            <asp:Label ID="lbl8" runat="server" Text="0" Width="30px"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr style="background-color: #DDDDDD;">
                                        <td align="left" style="width: 40%">
                                            Integration
                                        </td>
                                        <td style="width: 20%">
                                            <asp:Label ID="lbl9" runat="server" Text="0" Width="30px"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" style="width: 40%">
                                            Total Score
                                        </td>
                                        <td style="width: 20%">
                                            <asp:Label ID="lblTotalScore" runat="server" Text="0" Width="30px"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr style="height: 25%; width: 60%">
                <td valign="top" align="left" class="style3" >
                    <table style="height: 100%; width: 100%" border="1">
                        <tr style="height: 30%; width: 40%; background-color: #ED9121;">
                            <td style="height: 30%; width: 40%; font-family: Verdana; font-size: 12px; color: white;"
                                align="center" valign="middle">
                                Opportunity Qualification Score
                            </td>
                            <td style="height: 30%; width: 30%; font-family: Verdana; font-size: 12px; color: white;"
                                align="center" valign="middle">
                                Unique to Win(Non Commercial)
                            </td>
                            <td style="height: 30%; width: 30%; font-family: Verdana; font-size: 12px; color: white;"
                                align="center" valign="middle">
                                Undifferentiated
                            </td>
                        </tr>
                        <tr style="height: 20%; width: 40%;background-color:#EBEBEB ">
                            <td style="height: 20%; width: 40%; font-family: Verdana; font-size: 13px; color: #000000;"
                                align="center" valign="middle">
                                <asp:Label ID="lblLowOppQua" runat="server" Text="Low(<60%)"></asp:Label>
                            </td>
                            <td style="height: 20%; width: 30%; font-family: Verdana; font-size: 13px; color: #000000;"
                                align="center" valign="middle">
                                <asp:Button ID="btnLowOppQuaC" runat="server" Text="C" Width="130px" OnClick="btnLowOppQuaC_Click"
                                    Enabled="false" OnClientClick="return show_alert() " ToolTip="60" CssClass="SkbtnSkinBidWinability"/>
                            </td>
                            <td style="height: 20%; width: 30%; font-family: Verdana; font-size: 13px; color: #000000;"
                                align="center" valign="middle">
                                <asp:Button ID="btnLowOppQuaA" runat="server" Text="A" Width="130px" OnClick="btnLowOppQuaA_Click"
                                    Enabled="false" OnClientClick=" return show_alert()"  ToolTip="20" CssClass="SkbtnSkinBidWinability"/>
                            </td>
                        </tr>
                        <tr style="height: 20%; width: 40%;background-color: #CCCCCC">
                            <td style="height: 20%; width: 40%; font-family: Verdana; font-size: 13px; color: #000000;"
                                align="center" valign="middle">
                                <asp:Label ID="lblHighOppQua" runat="server" Text="High(>60%)"></asp:Label>
                            </td>
                            <td style="height: 20%; width: 30%" align="center" valign="middle">
                                <asp:Button ID="btnHighOppQuaD" runat="server" Text="D" Width="130px" OnClick="btnHighOppQuaD_Click"
                                    Enabled="false" OnClientClick=" return show_alert()"  ToolTip="90" CssClass="SkbtnSkinBidWinability"/>
                            </td>
                            <td style="height: 20%; width: 30%" align="center" valign="middle">
                                <asp:Button ID="btnHighOppQuaB" runat="server" Text="B" Width="130px" OnClick="btnHighOppQuaB_Click"
                                    Enabled="false" OnClientClick=" return show_alert()"  ToolTip="40" CssClass="SkbtnSkinBidWinability"/>
                            </td>
                        </tr>
                        <tr style="height: 30%; width: 40%;background-color:#EBEBEB ">
                            <td style="height: 30%; width: 40%; font-family: Verdana; font-size: 13px; color: #000000;"
                                align="center" valign="middle">
                                <font style="font-family: Verdana; font-size: 12px; color: #000000">Inputs by Bid Manager</font>
                            </td>
                            <td style="height: 30%; width: 30%; font-family: Verdana; font-size: 13px; color: #000000;
                                font-weight: bold" align="center" valign="middle" colspan="2">
                                <font style="font-family: Verdana; font-size: 13px; color: #000000">Uniqueness Score:</font>
                                <asp:Label ID="lblScore4" runat="server"></asp:Label>
                            </td>
                            <%-- <td style="height: 30%; width: 30%; font-family: Verdana; font-size: 13px; 
                                color: #000000" align="center" valign="middle">
                               
                            </td>--%>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr style="width: 60%">
                <td style="background-color: #403636; height: 1%; width: 30%;" align="left" valign="middle">
                    <font style="font-family: Verdana; font-size: 14px; text-transform: uppercase; 
                        font-weight: bold; color: #FFFFFF">Innovation</font>
                </td>
            </tr>
            <tr style="height: 25%; width: 60%">
                <td valign="top" align="left" class="style3">
                    <table style="height: 60%; width: 100%" border="1">
                        <tr style="height: 30%; width: 40%; background-color:#ED9121">
                            <td style="height: 30%; width: 40%; font-family: Verdana; font-size: 12px; color:white;"
                                align="center" valign="middle">
                                Skin in the Game/Risk
                            </td>
                            <td style="height: 30%; width: 30%; font-family: Verdana; font-size: 12px; color: white;"
                                align="center" valign="middle">
                                &nbsp;Unique(Non price) Commercial value
                            </td>
                            <td style="height: 30%; width: 30%; font-family: Verdana; font-size: 12px; color: white;"
                                align="center" valign="middle">
                                Undifferentiated
                            </td>
                        </tr>
                        <tr style="height: 20%; width: 40%;background-color:#EBEBEB">
                            <td style="height: 20%; width: 40%; font-family: Verdana; font-size: 13px; color: #000000;"
                                align="center" valign="middle">
                                <asp:Label ID="lblLowScore" runat="server" Text="Low(<60%)"></asp:Label>
                            </td>
                            <td style="height: 20%; width: 30%" align="center" valign="middle">
                                <asp:Button ID="btnLowC" runat="server" Text="C" Width="130px" OnClick="btnLowC_Click"
                                    Enabled="false" OnClientClick=" return show_alert()" ToolTip="65" CssClass="SkbtnSkinBidWinability"/>
                            </td>
                            <td style="height: 20%; width: 30%" align="center" valign="middle">
                                <asp:Button ID="btnLowA" runat="server" Text="A" Width="130px" OnClick="btnLowA_Click"
                                    Enabled="false" OnClientClick=" return show_alert()" ToolTip="35" CssClass="SkbtnSkinBidWinability"/>
                            </td>
                        </tr>
                        <tr style="height: 20%; width: 40%; background-color:#CCCCCC">
                            <td style="height: 20%; width: 40%; font-family: Verdana; font-size: 13px; color: #000000;"
                                align="center" valign="middle">
                                <asp:Label ID="lblHighRiskD" runat="server" Text="High(>60%)"></asp:Label>
                            </td>
                            <td style="height: 20%; width: 30%" align="center" valign="middle">
                                <asp:Button ID="btnHighD" runat="server" Text="D" Width="130px" OnClick="btnHighD_Click"
                                    Enabled="false" OnClientClick=" return show_alert()" ToolTip="90" CssClass="SkbtnSkinBidWinability"/>
                            </td>
                            <td style="height: 20%; width: 30%" align="center" valign="middle">
                                <asp:Button ID="btnHighB" runat="server" Text="B" Width="130px" OnClick="btnHighB_Click"
                                    Enabled="false" OnClientClick=" return show_alert()" ToolTip="50" CssClass="SkbtnSkinBidWinability"/>
                            </td>
                        </tr>
                        <tr style="height: 30%; width: 40%; background-color:#EBEBEB">
                            <td style="height: 30%; width: 40%; font-family: Verdana; font-size: 13px; color: #000000;"
                                align="center" valign="middle">
                                <font style="font-family: Verdana; font-size: 12px; color: #000000">Inputs by BUHead</font>
                            </td>
                            <td style="height: 30%; width: 30%; font-family: Verdana; font-size: 13px; color: #000000;
                                font-weight: bold" align="center" valign="middle" colspan="2">
                                <font style="font-family: Verdana; font-size: 13px; color: #000000">Innovation Score:</font>
                                <asp:Label ID="lblScore3" runat="server"></asp:Label>
                            </td>
                            <%--   <td style="height: 30%; width: 30%; font-family: Verdana; font-size: 13px; 
                                color: #000000" align="center" valign="middle">
                                <asp:Label ID="lblScore3" runat="server"></asp:Label>
                            </td>--%>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr style="height: 20%; width: 60%">
                <td align="center" class="style4" valign="top">
                    <asp:Button ID="btntest" runat="server" BackColor="#EAF1FF" BorderColor="#EAF1FF"
                        BorderStyle="None" Style="display: none" />
                    <asp:Button ID="btnShow" runat="server" Text="Show Graph" OnClick="btnShow_Click" Height="26px" Visible="false" Width="100px" CssClass="SkbtnSkin"/>&nbsp;&nbsp;
                    <asp:Button ID="btnApprove" runat="server" Text="Approve" Visible="false" OnClick="btnApprove_Click" Height="26px" Width="100px" CssClass="SkbtnSkin"/>&nbsp;&nbsp;
                    <asp:Button ID="btnReject" runat="server" Text="Reject" Height="26px" Visible="false" OnClick="btnReject_Click" Width="100px" CssClass="SkbtnSkin"/>&nbsp;&nbsp;
                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" Visible="false" OnClick="btnSubmit_Click" Height="26px" Width="100px" CssClass="SkbtnSkin"/>
                    <ajax:ModalPopupExtender ID="modalPopupGraph" runat="server" PopupControlID="panelGraph"
                        TargetControlID="btntest" CancelControlID="btnClose" BackgroundCssClass="modalBackground">
                    </ajax:ModalPopupExtender>
                    <asp:Panel ID="panelGraph" runat="server" Style="display: none; width:70%" CssClass="modalPopup"> 
                        <table style="height: 90%; width: 90%">
                            <tr style="height: 5%; width: 100%">
                                <td style="height: 5%; width: 99%" align="center">
                                    <font style="font-family: Century; font-size: 15px; font-weight: bold; text-transform: uppercase;
                                        color: #000000">Bid Win Score</font>
                                </td>
                                <td style="height: 5%; width: 1%" align="right">
                                    <asp:Button ID="btnClose" runat="server" Text="X" />
                                </td>
                            </tr>
                            <tr style="height: 20%; width: 100%">
                                <td style="height: 20%; width: 75%" align="left" colspan="2">
                                    <table style="height: 100%; width: 75%" align="left" border="1">
                                        <tr style="width:25%;background-color:#ED9121;">
                                            <td align="center" style="color:White">
                                                Parameters
                                            </td>
                                            <td align="center" style="color:White">
                                                Scores (in %)
                                            </td>
                                            <td align="center" style="color:White">
                                                Bid Win Score (in %)
                                            </td>
                                        </tr>
                                        <tr style="background-color:#EBEBEB">
                                            <td>
                                                Opportunity Score
                                            </td>
                                            <td align="right">
                                                <asp:Label ID="lblOpportunityScore" runat="server"></asp:Label>
                                            </td>
                                            <td rowspan="4" align="center" valign="middle" style="font-size: 25px; font-weight: bold;
                                                color: #000000">
                                                <asp:Label ID="lblBidWinScore" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr style="background-color:#CCCCCC">
                                            <td>
                                                RGY Score
                                            </td>
                                            <td align="right">
                                                <asp:Label ID="lblRGYScore" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr style="background-color:#EBEBEB">
                                            <td>
                                                Innovation
                                            </td>
                                            <td align="right">
                                                <asp:Label ID="lblInnovation" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr style="background-color:#CCCCCC">
                                            <td>
                                                Uniqueness
                                            </td>
                                            <td align="right">
                                                <asp:Label ID="lblUniqueness" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                               
                            </tr>
                            <tr style="height: 40%; width: 100%" align="left">
                                <td style="height: 40%; width: 100%" align="left" colspan="2">
                                    <asp:Chart ID="ChartBidWinability" runat="server" Height="300px" Width="500px" BorderDashStyle="Solid"
                                        BackSecondaryColor="White" BackGradientStyle="TopBottom" BorderWidth="2px" BackColor="211, 223, 240"
                                        BorderColor="#1A3B69" OnDataBinding="ChartBidWinability_DataBinding">
                                        <Titles>
                                            <asp:Title Text="Bid Win Score" />
                                        </Titles>
                                        <Series>
                                            <asp:Series BorderColor="180, 26, 59, 105" ChartType="Column">
                                                <Points>
                                                    <asp:DataPoint AxisLabel="Opportunity Qualification" XValue="0" />
                                                    <asp:DataPoint AxisLabel="RGYChecklist" XValue="10" />
                                                    <asp:DataPoint AxisLabel="Innovation" XValue="20" />
                                                    <asp:DataPoint AxisLabel="Uniqueness" XValue="30" />
                                                </Points>
                                            </asp:Series>
                                        </Series>
                                        <ChartAreas>
                                            <asp:ChartArea Name="ChartAreaBidWinability" BorderColor="64, 64, 64, 64" BorderDashStyle="Solid"
                                                BackSecondaryColor="White" BackColor="64, 165, 191, 228" ShadowColor="Transparent"
                                                BackGradientStyle="TopBottom">
                                                <AxisY LineColor="64, 64, 64, 64">
                                                    <LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" />
                                                    <MajorGrid LineColor="64, 64, 64, 64" />
                                                </AxisY>
                                                <AxisX LineColor="64, 64, 64, 64">
                                                    <LabelStyle Font="Trebuchet MS, 10pt, style=Bold" />
                                                    <MajorGrid LineColor="64, 64, 64, 64" />
                                                </AxisX>
                                            </asp:ChartArea>
                                        </ChartAreas>
                                    </asp:Chart>
                                </td>
                            </tr>
                            <tr style="height: 25%; width: 100%" align="left">
                             <td style="height: 20%; width: 40%" align="left" colspan="2">
                                <asp:GridView ID="gvBidWinScaleScore" runat="server" AutoGenerateColumns="false" Width="40%" Height="80%"
                                                 BorderStyle="Solid" BorderWidth="1px" BorderColor="Black">
                                                <RowStyle  Font-Size="12px" CssClass="skGridInnerRow"/> <%--ForeColor="Black" Font-Bold="true"--%>
                                                <SelectedRowStyle CssClass="skGridInnerSelectedRow" />
                                                <AlternatingRowStyle CssClass="skGridInnerAlternatingRow" />
                                                <HeaderStyle CssClass="skGridInnerHeader"/>
                                                <FooterStyle CssClass="skGridInnerFooter" />
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Scale" ItemStyle-Width="30%">
                                                        <ItemTemplate>
                                                            <%#Eval("vsScale")%>   
                                                        </ItemTemplate>
                                                        <ItemStyle Width="30%"></ItemStyle>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Description" ItemStyle-Width="70%">
                                                        <ItemTemplate>
                                                            <%#Eval("vsDesc")%>
                                                        </ItemTemplate>
                                                        <ItemStyle Width="70%"></ItemStyle>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
