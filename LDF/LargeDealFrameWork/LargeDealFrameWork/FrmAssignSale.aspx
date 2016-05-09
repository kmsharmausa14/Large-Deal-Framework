<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="FrmAssignSale.aspx.cs" Inherits="LargeDealFrameWork.AssignSale" %>

<asp:Content ID="ContentHeadAssignSale" ContentPlaceHolderID="HeadContent" runat="server">
    <meta charset="utf-8">
    <link rel="stylesheet" href="/resources/demos/style.css" />
    <script type="text/javascript">
        $(function () { $("#tabs").tabs(); });
        $(document).ready(function () {

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

            $("#ddlsecondrycontact").change(function () {
                var contact = $("#ddlprimarycontact option:selected").text();
                var seccontact = $("#ddlsecondrycontact option:selected").text();

                if (contact == seccontact) {
                    if (contact == "Select") {
                        $('#lblsecondrycontact').text("");
                    }
                    else {


                        alert(seccontact + " is already chosen as primary contact.");
                        $("#ddlsecondrycontact").val(0);
                        $('#lblsecondrycontact').text("");
                    }
                }
                else {
                    $('#lblsecondrycontact').text(seccontact + " is the Delivery Director Secondry contact.");
                }
            });

            $("#ddlprimarycnct_GPT").change(function () {
                var contact = $("#ddlprimarycnct_GPT option:selected").text();
                var seccontact = $("#ddlseccnct_GPT option:selected").text();

                if (contact == seccontact) {

                    if (contact == "Select") {
                        $('lblpostprimarycnct_GPT').text("");
                    }
                    else {

                        alert(contact + " is already chosen as GPT Manager secondry contact.");
                        $("#ddlprimarycnct_GPT").val(0);
                        $('#lblpostprimarycnct_GPT').text("");
                    }
                }

                else {
                    $('#lblpostprimarycnct_GPT').text(contact + " is the GPT Manager primary contact");
                }

            });

            $("#ddlseccnct_GPT").change(function () {

                var contact = $("#ddlprimarycnct_GPT option:selected").text();
                var seccontact = $("#ddlseccnct_GPT option:selected").text();
                if (contact == seccontact) {

                    if (contact == "Select") {
                        $('#lblpostseccnct_GPT').text("");
                    }
                    else {
                        alert(seccontact + " is already chosen as GPT Manager primary contact.");
                        $("#ddlseccnct_GPT").val(0);
                        $('#lblpostseccnct_GPT').text("");
                    }
                }
                else {
                    $('#lblpostseccnct_GPT').text(seccontact + " is the GPT Manager secondry contact");
                }

            });


            $('.assignbutton').click(function () {
                return confirm('Are you sure you want assign the Opportunity?');
            });



        });
    </script>
</asp:Content>
<asp:Content ID="ContentMainAssignSale" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width: 100%; height: 70%">
        <tr style="width: 100%; height: 5%">
            <td style="width: 100%; height: 5%">
                <asp:ImageButton ID="homeSale" runat="server" ImageUrl="~/Images/home.png" Height="30px"
                    Width="30px" OnClick="homeSale_Click" />
            </td>
        </tr>
        <tr style="width: 100%; height: 5%">
            <td style="width: 100%; height: 5%">
                <asp:Label ID="lblCountOpportunities" runat="server" Text="# Open Opportunities, # Large Deals, # Non Large Deals"
                    Font-Bold="True" ForeColor="Black" Font-Size="15px"></asp:Label>
            </td>
        </tr>
        <tr style="width: 100%; height: 5%">
            <td style="width: 100%; height: 5%">
            </td>
        </tr>
        <tr style="width: 100%; height: 100%">
            <td style="width: 100%; height: 100%" valign="top">
                <div id="tabs" style="width: 98%; height: 65%">
                    <ul>
                        <li><a href="#tabs-1">Delivery</a></li>
                        <li><a href="#tabs-2">GPT</a></li>
                        <li><a href="#tabs-3">Vertical</a></li>
                    </ul>
                    <div id="tabs-1" align="left" style="width: 100%; height: 65%">
                        <table style="width: 100%; height: 100%">
                            <tr style="width: 100%; height: 5%">
                                <td style="width: 100%; height: 5%" colspan="3">
                                    <font style="font-family: Verdana; font-size: 16px; font-weight: bold; color: #000000">
                                        Delivery Directors</font>
                                </td>
                            </tr>
                          <tr>
                                <td>
                                    <asp:Label ID="Label1" runat="server" Text="Primary Contact"></asp:Label><span style="color:Red">*</span>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:DropDownList ID="ddlprimarycontact" runat="server" 
                                         
                                        style="margin-left: 0px" Width="150px" 
                                        onselectedindexchanged="ddlprimarycontact_SelectedIndexChanged" AppendDataBoundItems="true">
                                        <asp:ListItem Text="Select" Selected="True" Value="0"></asp:ListItem>
                                       
                                    </asp:DropDownList>
                                    
                                    
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:Label ID="lblprimarycontact" runat="server" Text=""></asp:Label>
                                    
                                    
                                    <br />
                                    <br />
                                    <br />
                                    <br />
                                    <br />
                                    
                                    
                                </td>
                                
                            </tr>
                          <tr>
                          <td>
                                    <asp:Label ID="Label2" runat="server" Text="Secondary Contact"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:DropDownList ID="ddlsecondrycontact" runat="server" 
                                         Width="150px" onselectedindexchanged="ddlprimarycontact_SelectedIndexChanged" AppendDataBoundItems="true">
                                        <asp:ListItem Text="Select" Selected="True" Value="0"></asp:ListItem>
                                        
                                    </asp:DropDownList>
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:Label ID="lblsecondrycontact" runat="server" Text=""></asp:Label>
                                    <input  id="btnreassign" type="button" runat="server"/>
                                    <br />
                                    <br />
                                    <br />
                                    <br />
                                    <br />
                                    <br />
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   <%-- <asp:Button ID="btassign" CssClass="assignbutton" runat="server" Text="Assign" onclick="btassign_Click" />--%>
                                    <input  type="button" runat="server" id="btnassignDD" class="assignbutton" value="Assign"/>
                                    
                                 </td>
                          </tr>
                        </table>
                    </div>
                    <div id="tabs-2" align="left" style="width: 100%; height: 65%">

                     <table style="width: 100%; height: 100%">
                            <tr style="width: 100%; height: 5%">
                                <td style="width: 100%; height: 5%" colspan="3">
                                    <font style="font-family: Verdana; font-size: 16px; font-weight: bold; color: #000000">
                                        GPT</font>
                                </td>
                            </tr>
                             <tr>
                                <td>
                                    <asp:Label ID="lblprimarycnct_GPT" runat="server" Text="Primary Contact"></asp:Label><span style="color:Red">*</span>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:DropDownList ID="ddlprimarycnct_GPT" runat="server" 
                                         
                                        style="margin-left: 0px" Width="150px"
                                        onselectedindexchanged="ddlprimarycontact_SelectedIndexChanged" AppendDataBoundItems="true">
                                        <asp:ListItem Text="Select" Selected="True" Value="0"></asp:ListItem>
                                        
                                    </asp:DropDownList>
                                    
                                    
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:Label ID="lblpostprimarycnct_GPT" runat="server" Text=""></asp:Label>
                                    
                                    <input  id="btnreassignGPT" type="button" runat="server"/>
                                    <br />
                                    <br />
                                    <br />
                                    <br />
                                    <br />
                                    
                                    
                                </td>
                                
                            </tr>
                          <tr>
                          <td>
                                    <asp:Label ID="lblseccnct_GPT" runat="server" Text="Secondary Contact"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:DropDownList ID="ddlseccnct_GPT" runat="server" 
                                         Width="150px"
                                         onselectedindexchanged="ddlprimarycontact_SelectedIndexChanged" AppendDataBoundItems="true">
                                        <asp:ListItem Text="Select" Selected="True" Value="0"></asp:ListItem>
                                        
                                    </asp:DropDownList>
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:Label ID="lblpostseccnct_GPT" runat="server" Text=""></asp:Label>
                                    <br />
                                    <br />
                                    <br />
                                    <br />
                                    <br />
                                    <br />
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   <%-- <asp:Button ID="btnassign_GPT" CssClass="assignbutton" runat="server" Text="Assign" />--%>
                                   <input type="button" id="btnAssignGPT" class="assignbutton" runat="server" value="Assign"/>
                                 </td>
                          </tr>
                     </table>
                    </div>
                    <div id="tabs-3" align="center" style="width: 100%; height: 65%">
                     <table style="width: 100%;">
                        <tr style="height: 5%">
                                <td style="width: 100%; height: 5%" colspan="3" align="left">
                                    <font style="font-family: Verdana; font-size: 16px; font-weight: bold; color: #000000">
                                        Vertical Presales Head</font>
                                </td>
                            </tr>
                           <tr>
                                <td style="width:20%">
                                    <label id="lblprimarycontactVPH" runat="server">Vertical PreSales Head:</label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList runat="server" ID="ddlverticalpresaleshea"></asp:DropDownList>
                                </td>
                           </tr>
                           <tr>
                            <td>
                                
                            </td>
                           </tr>
                           <tr>
                                <td>
                                
                                </td>
                           </tr>
                           <tr>
                            <td>
                                 <input type="button" id="btnAssignVPH" class="assignbutton" runat="server" value="Assign"/>

                            </td>
                           </tr>
                        </table>
                    </div>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
