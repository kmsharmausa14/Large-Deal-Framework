<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Qualification.aspx.cs"
    Inherits="LargeDealFrameWork.Qualification" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
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
        }
    </style>
    <script type="text/javascript">



        function Sum() {
            //debugger;
            var text1 = document.getElementById('<%= txtClientPresenceScale.ClientID %>');
            var text2 = document.getElementById('<%= txtBusinessPriority.ClientID %>');
            var text3 = document.getElementById('<%= txtUrgencybuy.ClientID %>');
            var text4 = document.getElementById('<%= txtCompetiiveAdvantage.ClientID %>');

            if (text1.value.length == 0) {
                text1.value = 0;
            }
            if (text2.value.length == 0) {
                text2.value = 0;
            }

            if (text3.value.length == 0) {
                text3.value = 0;
            }
            if (text4.value.length == 0) {
                text4.value = 0;
            }


            var x = parseFloat(text1.value);
            var y = parseFloat(text2.value);
            var z = parseFloat(text3.value);
            var a = parseFloat(text4.value);

            document.getElementById('<%= txttotalSummary.ClientID %>').value = x + y + z + a;
            percent();
        }

        function percent() {
            //debugger;
            var text1 = document.getElementById('<%= txttotalSummary.ClientID %>');
            var totalsummary = parseFloat(text1.value);
            var lbl1 = document.getElementById('<%= lbltotal.ClientID %>');
            var outOfTotalSummary = parseFloat(lbl1.innerText);
            document.getElementById('<%= txtOpportunityScale.ClientID %>').value = (100 * totalsummary) / outOfTotalSummary;
        }
    </script>
</head>
<body>
    <form id="form1Qualification" runat="server" style="height: 100%; width: 100%; font-size: 14px">
  
            <div>
                <table style="height: 100%; width: 100%; font-family: Verdana; font-size: 14px">
                    <tr style="height: 5%">
                        <td style="height: 5%" colspan="4">
                            <font style="font-family: Verdana; font-size: 14px; font-weight: bold">Account Qualifications(Key
                                Scores)</font>
                        </td>
                    </tr>
                    <tr style="height: 5%; width: 80%">
                        <td class="style1">
                            <asp:LinkButton ID="lnkClientPresenceScale" runat="server" Text="Client's Demand Presence Scale"
                                OnClick="lnkClientPresenceScale_Click"></asp:LinkButton>
                        </td>
                        <td class="style3" align="center">
                            <asp:TextBox ID="txtClientPresenceScale" runat="server" Width="50px" onchange="Sum()"
                                Enabled="false"></asp:TextBox>
                        </td>
                        <td class="style4">
                            <asp:Label ID="lblscore1" runat="server" Text="Out of "></asp:Label>
                             <asp:Label runat="server" ID="lblClientPresenceScale" Text="12"></asp:Label>
                        </td>
                        <td style="height: 5%; width: 5%" rowspan="9">
                            <table style="height: 100%; width: 100%">
                                <tr style="height: 50%; width: 100%">
                                    <td style="height: 50%; width: 40%;" align="left" valign="middle">
                                        <asp:Label runat="server" ID="lblOpportunityScale" Text="Opportunity Probability Scale: "></asp:Label>
                                    </td>
                                    <td style="height: 50%; width: 20%" valign="middle">
                                        <asp:TextBox ID="txtOpportunityScale" runat="server" Width="50px" Enabled="false"></asp:TextBox>
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
                                    <td style="height: 10%; width: 40%;" colspan="2" align="left">
                                        <asp:Label ID="lblProbability" runat="server" Text="You have Opportunity to Win"></asp:Label>
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
                        <td class="style1">
                        </td>
                    </tr>
                    <tr style="height: 5%; width: 40%">
                        <td class="style1">
                            <asp:LinkButton ID="lnkBusinessPriority" runat="server" 
                                Text="Syntel's Business Priority Scale" onclick="lnkBusinessPriority_Click"></asp:LinkButton>
                        </td>
                        <td class="style3" align="center">
                            <asp:TextBox ID="txtBusinessPriority" runat="server" Width="50px" onchange="Sum()"
                                Enabled="false"></asp:TextBox>
                        </td>
                        <td class="style4">
                            <asp:Label ID="Label1" runat="server" Text="Out of "></asp:Label>
                             <asp:Label runat="server" ID="lblBusinessPriority" Text="29"></asp:Label>
                        </td>
                    </tr>
                    <tr style="height: 5%; width: 80%">
                        <td class="style1">
                        </td>
                    </tr>
                    <tr style="height: 5%; width: 40%">
                        <td class="style1">
                            <asp:LinkButton ID="lnkUrgencyBuy" runat="server" 
                                Text="Client's Urgency to Buy" onclick="lnkUrgencyBuy_Click"></asp:LinkButton>
                        </td>
                        <td class="style3" align="center">
                            <asp:TextBox ID="txtUrgencybuy" runat="server" Width="50px" onchange="Sum()" Enabled="false"></asp:TextBox>
                        </td>
                        <td class="style4">
                            <asp:Label ID="Label2" runat="server" Text="Out of "></asp:Label>
                             <asp:Label runat="server" ID="lblUrgencyBuyTotalScore" Text="20"></asp:Label>
                        </td>
                    </tr>
                    <tr style="height: 5%; width: 80%">
                        <td class="style1">
                        </td>
                    </tr>
                    <tr style="height: 5%; width: 40%">
                        <td class="style1">
                            <asp:LinkButton ID="lnkCompetitiveAdvantage" runat="server" 
                                Text="Syntel's Competitive Advantage" onclick="lnkCompetitiveAdvantage_Click"></asp:LinkButton>
                        </td>
                        <td class="style3" align="center">
                            <asp:TextBox ID="txtCompetiiveAdvantage" runat="server" Width="50px" onchange="Sum()"
                                Enabled="false"></asp:TextBox>
                        </td>
                        <td class="style4">
                            <asp:Label ID="Label3" runat="server" Text="Out of "></asp:Label>
                             <asp:Label runat="server" ID="lblCompAdvanTotalScore" Text="48"></asp:Label>
                        </td>
                    </tr>
                    <tr style="height: 5%; width: 80%">
                        <td class="style1">
                        </td>
                    </tr>
                    <tr style="height: 5%; width: 40%">
                        <td class="style1">
                            <asp:Label ID="lbltotalSummary" runat="server" Text="Total Summary Score"></asp:Label>
                            &nbsp;:
                        </td>
                        <td class="style3" align="center">
                            <asp:TextBox ID="txttotalSummary" runat="server" Width="50px" Enabled="false"></asp:TextBox>
                        </td>
                        <td class="style4">
                            <asp:Label ID="Label4" runat="server" Text="Out of "></asp:Label>
                            <asp:Label runat="server" ID="lbltotal" Text="109"></asp:Label>
                        </td>
                    </tr>
                    <tr style="height: 40%; width: 70%">
                        <td class="style2" colspan="4" valign="middle">
                            <div style="height: 100%; width: 100%">
                                <table style="border: 2px solid #000000; height: 100%; width: 100%">
                                    <tr style="height: 100%; width: 50%">
                                        <td style="height: 100%; width: 1%">
                                        </td>
                                        <td style="height: 100%; width: 49%" valign="top">
                                            <asp:GridView ID="gvScaleScore" runat="server" AutoGenerateColumns="false" Width="80%"
                                                BorderColor="Black" BorderStyle="Solid" BorderWidth="1px">
                                                <HeaderStyle BackColor="#003399" Font-Bold="true" ForeColor="White" />
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Scale" ItemStyle-Width="20%">
                                                        <ItemTemplate>
                                                            <%#Eval("Scale") %>
                                                        </ItemTemplate>
                                                        <ItemStyle Width="20%"></ItemStyle>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Description" ItemStyle-Width="60%">
                                                        <ItemTemplate>
                                                            <%#Eval("Description")%>
                                                        </ItemTemplate>
                                                        <ItemStyle Width="60%"></ItemStyle>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </td>
                                        <td style="height: 100%; width: 50%">
                                            <table style="width: 100%; height: 100%">
                                                <tr style="width: 100%; height: 10%">
                                                    <td style="width: 100%; height: 10%" align="left">
                                                        <asp:Label ID="lblSignoff" runat="server" Text="SIGNOFF " BackColor="#0066CC"></asp:Label>&nbsp;
                                                        &nbsp;
                                                        <asp:Label ID="lblBUHead" runat="server" Text=" BU Head/Leadership Team " BackColor="#CEFF3C"></asp:Label>&nbsp;
                                                        &nbsp;
                                                        <asp:Label ID="lblApprove" runat="server" Text=" Approved" BackColor="#99CC00"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr style="width: 100%; height: 10%">
                                                    <td style="width: 100%; height: 10%">
                                                        <asp:Label ID="lblStatus" runat="server" Text="Status :" Width="80px"></asp:Label>
                                                        &nbsp; &nbsp; &nbsp;
                                                        <asp:DropDownList ID="ddlApproveReject" runat="server" AppendDataBoundItems="true"
                                                            Width="115px">
                                                            <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                            <asp:ListItem Text="Approve" Value="1"></asp:ListItem>
                                                            <asp:ListItem Text="Not Approved" Value="2"></asp:ListItem>
                                                        </asp:DropDownList>
                                                        <%--<asp:Button ID="btnNoGo" runat="server" Text="No Go" BackColor="#003399" Font-Bold="true"
                                                    ForeColor="White" />--%>
                                                    </td>
                                                </tr>
                                                <tr style="width: 100%; height: 10%">
                                                    <td style="width: 100%; height: 10%">
                                                        <asp:Label ID="Label5" runat="server" Text="Deal Type :"></asp:Label>
                                                        &nbsp; &nbsp; &nbsp;
                                                        <asp:DropDownList ID="ddlLargeDeal" runat="server" AppendDataBoundItems="true">
                                                            <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                            <asp:ListItem Text="Large Deal" Value="1"></asp:ListItem>
                                                            <asp:ListItem Text="Non Large Deal" Value="2"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr style="width: 100%; height: 20%">
                                                    <td style="width: 100%; height: 20%" align="center">
                                                        <asp:Button ID="btnNoGo" runat="server" Text="No Go" BackColor="#003399" Font-Bold="true"
                                                            ForeColor="White" />&nbsp; &nbsp; &nbsp;
                                                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" BackColor="#003399" Font-Bold="true"
                                                            ForeColor="White" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </td>
                    </tr>
                </table>
            </div>
       
    </form>
</body>
</html>
