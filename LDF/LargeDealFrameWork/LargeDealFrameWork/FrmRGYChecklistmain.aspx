<%@ Page Title="" Language="C#" MasterPageFile="~/maintab.Master" AutoEventWireup="true" CodeBehind="FrmRGYChecklistmain.aspx.cs" Inherits="LargeDealFrameWork.RGYChecklistmain"%>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentMainTab" runat="server">
    <meta charset="utf-8">
    <link rel="stylesheet" href="http://code.jquery.com/ui/1.10.3/themes/smoothness/jquery-ui.css" />
    <script type="text/javascript" src="http://code.jquery.com/jquery-1.9.1.js"></script>
    <script type="text/javascript" src="http://code.jquery.com/ui/1.10.3/jquery-ui.js"></script>
    <link href="Styles/Site.css" rel="stylesheet" type="text/css" />
     <link href="Styles/IS.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="/resources/demos/style.css" />
    <script src="<%= ResolveUrl ("~/Scripts/UserValidation.js") %>" ></script>
<script type="text/javascript">
    $(function () {
        $("#progressbar").progressbar({
            value: 50
        });
    });
    $(function () {
        $("#menu").menu();
    });
    $(function () {

        var date = new Date();

        var currentMonth = date.getMonth();

        var currentDate = date.getDate();

        var currentYear = date.getFullYear();

        $('.nex').datepicker({

            minDate: new Date(currentYear, currentMonth, currentDate)

        });

    });



    $(document).ready(function () {
        var active = $('#<%= hidAccordionIndex.ClientID %>').val();
        var currentindex = 0;
        if (active != '') {
            currentindex = active;
        }

        $("#accordion").accordion(
 {
     change: function (event, ui) {
         var i = $("#accordion").accordion("option", "active");
         $('#<%= hidAccordionIndex.ClientID %>').val(i);
     }
 }

 );

        $("#accordion").accordion({ active: parseInt(currentindex) });
        $("#accordion div").css({ 'height': 'auto' });


    });

   

    $(document).ready(function () {
        $('.hightlight').change(function () {
            var len = this.value.length;
            if (len >= 250) {
                this.value = this.value.substring(0, 250);
                event.returnValue = false;
                alert("250 characters exceeded")
            }
        });
    });

    $(document).ready(function () {

        $('.nex').bind('keypress', function (e) {
            if (e.keyCode != 0) {
                e.preventDefault();
            }
        });
    });




    $(document).ready(function () {
        $("#txtEditReview").datepicker();
    });

    
</script>

<style  type="text/css">
.ui-menu { width: 200px; }

.buttons
{
    border-top-left-radius:0.5em;
    border-top-right-radius:0.5em;
    border-bottom-left-radius:0.5em;
    border-bottom-right-radius:0.5em;    
}

.hightlight{
 
}
.hightlightgreen {
  background:green;
}
.hightlightyellow {
  background:yellow;
}

.alinment
{
   margin:0 auto;
}

.grid
{
 table-layout:fixed; 
 width="1000px"   
}

.itemstyle
{
  word-wrap:break-word;
  word-break: break-all;

}

.div
{
border: 1px solid;
border-bottom-left-radius: 0.40em;
border-top-left-radius: 0.40em;
border-top-right-radius: 0.40em;
border-bottom-right-radius: 0.40em;
}

.modalPopup
        {
            background-color: #FFFFFF;
            border-width: 3px;
            border-style: solid;
            border-color: Gray;
            padding-top: 10px;
            padding-left: 10px;
            font-family: Verdana;
            width: 800px;
            height: 480px;
            border: 1px solid;
            border-bottom-left-radius: 1em;
            border-top-left-radius: 1em;
            border-top-right-radius: 1em;
            border-bottom-right-radius: 1em;
        }

.modalBackground
        {
            background-color: ThreeDShadow;
            filter: alpha(opacity=80);
            opacity: 0.9;
            z-index: 10000;
        }

</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentMainTab" ClientIDMode="Static" runat="server">
    <%--<ajax:ToolkitScriptManager ID="ScriptManagerRGY" runat="server">
    </ajax:ToolkitScriptManager>--%>
    <div style="width:1100px;  font-weight: bolder;" class="alinment">
        <asp:Panel ID="pan" runat="server" BorderStyle="solid" BorderWidth="1px" Width="100%" CssClass="div" >
            <table>
            
                <tr>
                <td colspan="4" align="left">
                    <table width="100%">
                        <tr>
                            <td align="left" >
                    
                        <asp:Label ID="lblRgyType" runat="server" Text="RGY Type:"  valign="top" ViewStateMode="Enabled" SkinID="SklblLeft"></asp:Label>
                      </td> 
                      <td align="left" > <asp:DropDownList ID="ddlrgytype" runat="server" 
                            onselectedindexchanged="ddlrgytype_SelectedIndexChanged1" TabIndex="1"
                            AutoPostBack="True" ClientValidationFunction="return ifFinalChecklist();">
                            <asp:ListItem Text="" Value="0"></asp:ListItem>
                            <asp:ListItem Text="Iterative" Value="1"></asp:ListItem>
                            <asp:ListItem Text="Final" Value="2"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td  align="center" width="85%" style="background-color:#CCCCCC;">                       
                    <asp:Label ID="lblIterativeCount" runat="server" BackColor="#CCCCCC" 
                            Font-Bold="True" Font-Size="Medium"></asp:Label>
                    </td>
                        </tr>
                    </table>
                </td>
                    
                    
                </tr>
                <tr>
                    <td>
                        <span>
                        </span>
                    </td>
                </tr>
                <tr>
                    <td colspan="4" width="100%" align="left">
                        <table width="100%">
                            <tr>
                                <td valign="top" align="left" width="8%">
                        <asp:Label ID="lblWinTheme" runat="server" Text="Win Theme:"  valign="top" SkinID="SklblLeft"></asp:Label>
                    </td>
                    <td colspan="2" align="left">
                        <asp:TextBox ID="txtwinthemetext" runat="server" class="hightlight" TextMode="MultiLine"  SkinId="SkTxtAreaSkin"></asp:TextBox>
                    </td>
                    <td align="right" width="35%">
                        <asp:Label ID="lblSubmissionDate" runat="server" Text=" RGY Submission Date:" SkinID="SklblLeft"></asp:Label>
                        
                    </td>
                    <td style="width:90px" align="right">
                    <asp:Label ID="SubDate" runat="server" SkinID="SklblLeft" ></asp:Label>
                    </td>
                            </tr>
                        </table>
                    </td>
                    
                </tr>
                <tr>

                <td colspan="3"><asp:HiddenField runat="server" ID="hidAccordionIndex"/>
                    
                </td>
                
                    <td  align="right" colspan="2">
                    <table style="width:30%">
                        <tr>
                            <td>SIGNOFF</td>
                            <td align="center">Bid Manager:<asp:Label ID="lblBidCoordinatorName" runat="server"></asp:Label></td>
                            <td style="color: #000000; font-weight: bold"><asp:Label ID="lblApprovedResult" runat="server" Text=""></asp:Label></td>
                        </tr>
                    </table>
                    </td>
                   
                </tr>
                <tr>
                    <td align="left" >
                    
                        <asp:Label ID="Label1" runat="server" Text="Opportunity Id:"  valign="top" ViewStateMode="Enabled" SkinID="SklblLeft"></asp:Label>
                      </td> <td align="left" colspan="3" > 
                       <asp:Label ID="Label5" runat="server"  
                            SkinID="SklblLeft"></asp:Label>
                    </td>
                    </tr>
                <tr>    
                    <td  align="left" width="11%" >
                        <asp:Label ID="Label2" runat="server"  Text="Opportunity Name: "
                           SkinID="SklblLeft"></asp:Label>
                    </td>
                    <td colspan="3">
                        <asp:Label ID="Label4" runat="server" Width="600px" 
                           SkinID="SklblLeft"></asp:Label>
                    </td>
                    
                </tr>
                <tr>
                    <td width="100%" colspan="4" align="right">
                         <asp:LinkButton runat="server" ID="lnkguidlines" Text="GUIDELINES" SkinId="SklnkSkin"  ></asp:LinkButton>
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <table align="left">
            <tr>
                <td>
                    <asp:Label ID="lblSavedFillMandatoryMessages" runat="server" SkinID="SklblLeft"></asp:Label>
                </td>
                <td>
                    <asp:Button runat="server" ID="btnmodifychecklist" Text="New Checklist" CssClass="SkbtnSkin"  onclick="btnmodifychecklist_Click" />
                </td>
            </tr>
        </table>
       <div id="accordion" >
            <h3 id="hbussol">
               <asp:Label ID="lblBusinessSolutionCategory" runat="server" Width="500px" SkinID="SklblLeft">Business Solution</asp:Label>
               <asp:Label ID="lblBusinessSolutionWeightage" runat="server" Width="250px" SkinID="SklblLeft"></asp:Label>
                Average Score:
               <asp:Label ID="lblBusinessSolutionAverageScore" runat="server"  Text="0" 
                   SkinID="SklblLeft"></asp:Label>
            </h3>
            <div id="divbussol" >
                <table id="tblbussinesssolutuions" style="top: auto; empty-cells: hide; vertical-align: top">
                <tr>
                    <td valign="top">
                    <asp:Literal runat="server" SkinID="SklblLeft" >Key Client Requirerment:<font color="red" size="1">*</font></asp:Literal>
                    &nbsp;</td>
                    <td valign="top">
                        <asp:TextBox ID="txtkeybusi" runat="server" class="hightlight" TextMode="MultiLine" 
                           onkeypress="return ValidText(event,this.value)" onpaste='return maxLengthPaste(this,"250");'  SkinId="SkTxtAreaSkin" ></asp:TextBox>
                    </td>
                    <td></td>
                    <td></td>
                    <td valign="top"><asp:Literal ID="Literal1" runat="server" SkinID="SklblLeft">Impacting which Part Proposal:<font color="red" size="1">*</font></asp:Literal></td>
                    <td valign="top">
                        <asp:TextBox ID="txtimpact" runat="server" class="hightlight" TextMode="MultiLine"  
                            onkeypress="return ValidText(event,this.value)" onpaste='return maxLengthPaste(this,"250");' SkinId="SkTxtAreaSkin"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                    <asp:Literal ID="Literal2" runat="server" SkinID="SklblLeft">Gaps/Improvement Areas:<font color="red" size="1">*</font></asp:Literal>
                    
                    </td>
                    <td valign="top">
                        <asp:TextBox ID="txtgaps" runat="server"  TextMode="MultiLine" 
                        onkeypress="return ValidText(event,this.value)" onpaste='return maxLengthPaste(this,"250");' SkinId="SkTxtAreaSkin"></asp:TextBox>
                    </td>
                    <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                    <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                    <td valign="top"><asp:Literal ID="Literal3" runat="server" SkinID="SklblLeft">Owner To Address Gaps:<font color="red" size="1">*</font></asp:Literal></td>
                    <td valign="top"><asp:TextBox ID="txtowner" class="hightlight" runat="server" 
                    onkeypress="return ValidText(event,this.value)" onpaste='return maxLengthPaste(this,"250");' TextMode="MultiLine"  SkinId="SkTxtAreaSkin" ></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                    <asp:Literal ID="Literal4" runat="server" SkinID="SklblLeft">Level to which addressed in proposal:<font color="red" size="1">*</font></asp:Literal>
                    
                    </td>
                    <td valign="top">
                       <asp:DropDownList ID="ddllevel" runat="server" Width="200px" SkinId="SkDrpLst">
                        <asp:ListItem Text=""></asp:ListItem>
                       </asp:DropDownList>
                       
                    </td>
                    <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                    <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                    <td valign="top"><asp:Literal ID="Literal5" runat="server" SkinID="SklblLeft">Review Date:<font color="red" size="1">*</font></asp:Literal></td>
                    <td  valign="top"><asp:TextBox ID="datepicker" runat="server" TextMode="SingleLine" Width="200px" CssClass="nex" ></asp:TextBox></td>
                </tr>
                <tr>
                    <td width="100%" colspan="6" align="center">
                        <asp:Button id="btnAddBusinessSolution" Text="Add" runat="server" CssClass="SkbtnSkin" 
                             OnClick="btnAddBusinessSolution_Click" OnClientClick="javascript:return userValidBusiness();"/>
                            <asp:Button id="btnClearBusinessSolution" Text="Clear" runat="server" CssClass="SkbtnSkin"  
                            Width="120px" OnClick="btnClearBusinessSolution_Click"  />
                    </td>
                </tr>
                <tr>
                    <td width="100%" colspan="7" align="center">
                        <asp:Label runat="server" ID="lblBusinessSolutionError" ForeColor="Red" Font-Bold="True"></asp:Label>
                        <asp:GridView ID="gridbusiness" runat="server" AutoGenerateColumns="False"
                            OnRowCancelingEdit="gridbusiness_RowCancelingEdit" 
                            OnRowDeleting="gridbusiness_rowdeleting"
                            OnRowEditing="gridbusiness_RowEditing"
                            OnRowCommand="gridbusiness_RowCommand" 
                            onrowdatabound="gridbusiness_RowDataBound" >   
                           <RowStyle CssClass="skGridInnerRow"/>
                            <SelectedRowStyle CssClass="skGridInnerSelectedRow" />
                            <AlternatingRowStyle CssClass="skGridInnerAlternatingRow" />
                            <HeaderStyle CssClass="skGridInnerHeader" />
                            <FooterStyle CssClass="skGridInnerFooter" />
                            <PagerStyle       CssClass="skGridInnerRow" />
                            
                            <Columns>
                                 <asp:TemplateField HeaderText="Edit" ItemStyle-CssClass="itemstyle" >                                   
                                    <ItemTemplate>
                                       <asp:LinkButton ID="lnkEdit" Text="Edit" CommandName="Edit" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' runat="server" SkinId="SklnkSkin"></asp:LinkButton>
                                   </ItemTemplate>



                        
                                    <EditItemTemplate>
                                        <asp:LinkButton ID="lnkUpdate" CommandName="UpdateRow" Text="Update" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' runat="server" Width="100px" SkinId="SklnkSkin"></asp:LinkButton>   
                                        &nbsp;<asp:LinkButton ID="lnkCancel" CommandName="Cancel" Text="Cancel" runat="server" SkinId="SklnkSkin"></asp:LinkButton>
                                    </EditItemTemplate>

<ItemStyle CssClass="itemstyle"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField  HeaderText="Remove" ControlStyle-CssClass="itemstyle" ItemStyle-CssClass="itemstyle">
                                   <ItemTemplate>
                                       <asp:LinkButton ID="lnkDeleteBusi" Text="Remove" CommandName="Delete" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' runat="server" OnClientClick="return show_alert()"></asp:LinkButton>
                                   </ItemTemplate>


<ControlStyle CssClass="itemstyle"></ControlStyle>


<ItemStyle CssClass="itemstyle"></ItemStyle>
                                </asp:TemplateField>  
                                <asp:TemplateField HeaderText="Key Client Requirement" ItemStyle-Wrap="true" ControlStyle-CssClass="itemstyle" ItemStyle-CssClass="itemstyle">
                                   <ItemTemplate >
                                        <%#Eval("keyclientrequirement")%>
                                   </ItemTemplate>



<ControlStyle CssClass="itemstyle"></ControlStyle>



                                   <ItemStyle CssClass="itemstyle"/>
                                   <EditItemTemplate>
                                        <asp:TextBox id="txtEditKey" Runat="Server" Text='<%# Eval("keyclientrequirement") %>'/>
                                    </EditItemTemplate>

<ItemStyle Wrap="True"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Impacting which part of Proposal"  ItemStyle-Wrap="true" ControlStyle-CssClass="itemstyle" ItemStyle-CssClass="itemstyle">
                                   <ItemTemplate>
                                        <%#Eval("impactonwhichpart")%>
                                   </ItemTemplate>



<ControlStyle CssClass="itemstyle"></ControlStyle>



                                   <ItemStyle CssClass="itemstyle"/>
                                   <EditItemTemplate>
                                        <asp:TextBox id="txtEditImpact" Runat="Server"  Text='<%# Eval("impactonwhichpart") %>'/>
                                    </EditItemTemplate>

<ItemStyle  Wrap="True"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Gaps/Improvement Area"  ItemStyle-Wrap="true" ControlStyle-CssClass="itemstyle" ItemStyle-CssClass="itemstyle">
                                   <ItemTemplate >
                                        <%#Eval("improvementarea")%>
                                   </ItemTemplate>

<ControlStyle CssClass="itemstyle"></ControlStyle>

                                   <ItemStyle CssClass="itemstyle"/>
                                   <EditItemTemplate>
                                        <asp:TextBox id="txtEditGaps" Runat="Server"  Text='<%# Eval("improvementarea") %>'/>
                                    </EditItemTemplate>

<ItemStyle Wrap="True"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Owner to address gaps"  ItemStyle-Wrap="true" ControlStyle-CssClass="itemstyle" ItemStyle-CssClass="itemstyle">
                                   <ItemTemplate>
                                        <%#Eval("ownertoaddressarea")%>
                                   </ItemTemplate>

<ControlStyle CssClass="itemstyle"></ControlStyle>

                                   <ItemStyle CssClass="itemstyle"/>
                                   <EditItemTemplate>
                                        <asp:TextBox id="txtEditOwner" Runat="Server"  Text='<%# Eval("ownertoaddressarea") %>'/>
                                    </EditItemTemplate>

<ItemStyle Wrap="True"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Level to which addressed in proposal"  ItemStyle-Wrap="true" ControlStyle-Width="170px" ItemStyle-CssClass="itemstyle" ControlStyle-CssClass="itemstyle">
                                   <ItemTemplate>
                                        <%#Eval("level")%>
                                   </ItemTemplate>
                                   <ItemStyle CssClass="itemstyle"/>
                                   <EditItemTemplate>
                                        <asp:DropDownList id="ddlEditBusinessLevel"  AppendDataBoundItems="true" Runat="Server" >

                                         </asp:DropDownList>
                                         
                                    </EditItemTemplate>

<ControlStyle Width="170px"></ControlStyle>

<ItemStyle Wrap="True"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Review Date" ControlStyle-CssClass="itemstyle" ItemStyle-CssClass="itemstyle">
                                   <ItemTemplate>
                                        <%#Eval("reviewdate","{0:MM-dd-yy}")%>
                                   </ItemTemplate>

<ControlStyle CssClass="itemstyle"></ControlStyle>

                                   <ItemStyle CssClass="itemstyle"/>
                                   <EditItemTemplate>
                                       <asp:TextBox id="txtEditReview" Runat="Server" TextMode="SingleLine" Width="160px" Text='<%#Bind("reviewdate","{0:MM-dd-yy}") %>'  CssClass="nex"/>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                               
                            </Columns>
                            
                            <RowStyle BorderColor="Silver" 
                                BorderWidth="1px" />
                            
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td>
                        
                    </td>
                </tr>
               </table> 
            </div>
            <h3 id="htechsol">
                <asp:label ID="lblTechnicalSolutionCategory" runat="server" Width="500px" SkinID="SklblLeft">Technical Solution</asp:label>
                <asp:Label runat="server" ID="lblTechnicalSolutionWeightage" Width="250px" SkinID="SklblLeft"></asp:Label>
                Average Score:
                <asp:Label ID="lblTechnicalSolutionAverageScore" runat="server"  Text="0" SkinID="SklblLeft"></asp:Label>
               </h3>
            <div id="divtechsol">
            <table  id="tbltechnical">
                <tr>
                    <td valign="top">
                    <asp:Literal ID="Literal6" runat="server" SkinID="SklblLeft">Key Client Requirerment:<font color="red" size="1">*</font></asp:Literal>
                    </td>
                    <td valign="top">
                        <asp:TextBox ID="txtKeyReqTech" runat="server" onkeypress="return ValidText(event,this.value)" onpaste='return maxLengthPaste(this,"250");' 
                         TextMode="MultiLine"  SkinId="SkTxtAreaSkin" ></asp:TextBox>
                    </td>
                    <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                    <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                    <td valign="top"><asp:Literal ID="Literal7" runat="server" SkinID="SklblLeft">Impacting which Part Proposal:<font color="red" size="1">*</font></asp:Literal></td>
                    <td valign="top"><asp:TextBox ID="txtImpactTech"  runat="server" onkeypress="return ValidText(event,this.value)" 
                    onpaste='return maxLengthPaste(this,"250");' TextMode="MultiLine"  SkinId="SkTxtAreaSkin" ></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                    <asp:Literal ID="Literal8" runat="server" SkinID="SklblLeft">Gaps/Improvement Areas:<font color="red" size="1">*</font></asp:Literal>
                    </td>
                    <td valign="top">
                        <asp:TextBox ID="txtGapsTech" runat="server"  TextMode="MultiLine" 
                        onkeypress="return ValidText(event,this.value)" onpaste='return maxLengthPaste(this,"250");'  SkinId="SkTxtAreaSkin" ></asp:TextBox>
                    </td>
                    <td></td>
                    <td></td>
                    <td valign="top"><asp:Literal ID="Literal9" runat="server" SkinID="SklblLeft">Owner To Address Gaps:<font color="red" size="1">*</font></asp:Literal></td>
                    <td valign="top"><asp:TextBox ID="txtOwnerTech" onkeypress="return ValidText(event,this.value)" onpaste='return maxLengthPaste(this,"250");' 
                     runat="server" TextMode="MultiLine"  SkinId="SkTxtAreaSkin" ></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                    <asp:Literal ID="Literal10" runat="server" SkinID="SklblLeft">Level to which addressed in proposal:<font color="red" size="1">*</font></asp:Literal>
                    </td>
                    <td valign="top">
                       <asp:DropDownList ID="ddLevelTech" runat="server" Width="200px" SkinId="SkDrpLst"><asp:ListItem Text=""></asp:ListItem></asp:DropDownList>
                    </td>
                    <td></td>
                    <td></td>
                    <td valign="top"><asp:Literal ID="Literal11" runat="server" SkinID="SklblLeft">Review Date:<font color="red" size="1">*</font></asp:Literal></td>
                    <td  valign="top"><asp:TextBox ID="txtDateTech" runat="server" TextMode="SingleLine" Width="200px" CssClass="nex"></asp:TextBox></td>
                </tr>
                <tr>
                    <td width="100%" colspan="6" align="center">
                        <asp:Button ID="btnAddTechnicalSolution" Text="Add" runat="server" CssClass="SkbtnSkin"  
                            Width="120px"  onclick="btnAddTechnicalSolution_Click" OnClientClick="javascript:return userValidTechnical();" />
                            <asp:Button id="btnClearTechnicalSolution" Text="Clear" runat="server" CssClass="SkbtnSkin" 
                            Width="120px" onclick="btnClearTechnicalSolution_Click"  />
                    </td>
                </tr>
                <tr>
                    <td width="100%" colspan="7" align="center">
                        <asp:Label runat="server" ID="lblTechnicalSolutionError" ForeColor="Red" Font-Bold="True"></asp:Label>
                        <asp:GridView ID="gridtechnical" runat="server" AutoGenerateColumns="False" 
                            OnRowDeleting="gridtechnical_rowdeleting" 
                            onrowcancelingedit="gridtechnical_RowCancelingEdit" 
                            onrowediting="gridtechnical_RowEditing" 
                            onrowcommand="gridtechnical_RowCommand" 
                            onrowdatabound="gridtechnical_RowDataBound"  >
                            <RowStyle CssClass="skGridInnerRow"/>
                            <SelectedRowStyle CssClass="skGridInnerSelectedRow" />
                            <AlternatingRowStyle CssClass="skGridInnerAlternatingRow" />
                            <HeaderStyle CssClass="skGridInnerHeader" />
                            <FooterStyle CssClass="skGridInnerFooter" />
                            <PagerStyle       CssClass="skGridInnerRow" />

                            <Columns>
                                 <asp:TemplateField HeaderText="Edit">                                   
                                    <ItemTemplate>
                                       <asp:LinkButton ID="lnkEdit" Text="Edit" CommandName="Edit" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' runat="server" SkinId="SklnkSkin"></asp:LinkButton>
                                   </ItemTemplate>
                                   <ControlStyle CssClass="itemstyle"></ControlStyle>
                                    <ItemStyle CssClass="itemstyle"/>
                                    <EditItemTemplate>
                                    <asp:LinkButton ID="lnkUpdate" CommandName="UpdateRow" Text="Update" Width="100px" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' runat="server" SkinId="SklnkSkin"></asp:LinkButton>   
                                        <asp:LinkButton ID="lnkCancel" CommandName="Cancel" Text="Cancel" runat="server" SkinId="SklnkSkin"></asp:LinkButton>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Remove">
                                   <ItemTemplate>
                                       <asp:LinkButton ID="lnkDeleteTech" Text="Remove" CommandName="Delete" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' SkinId="SklnkSkin" runat="server" OnClientClick="return show_alert()"></asp:LinkButton>
                                   </ItemTemplate>
                                </asp:TemplateField>  
                               <asp:TemplateField HeaderText="Key Client Requirement">
                                   <ItemTemplate>
                                        <%#Eval("keyclientrequirement")%>
                                   </ItemTemplate>
                                    <ItemStyle CssClass="itemstyle"/>
                                   <EditItemTemplate>
                                        <asp:TextBox id="txtEditKey" Runat="Server" Text='<%# Eval("keyclientrequirement") %>'/>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Impacting which part of Proposal">
                                   <ItemTemplate>
                                        <%#Eval("impactonwhichpart")%>
                                   </ItemTemplate>
                                    <ItemStyle CssClass="itemstyle"/>
                                   <EditItemTemplate>
                                        <asp:TextBox id="txtEditImpact" Runat="Server"  Text='<%# Eval("impactonwhichpart") %>'/>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Gaps/Improvement Area">
                                   <ItemTemplate>
                                        <%#Eval("improvementarea")%>
                                   </ItemTemplate>
                                    <ItemStyle CssClass="itemstyle"/>
                                   <EditItemTemplate>
                                        <asp:TextBox id="txtEditGaps" Runat="Server"  Text='<%# Eval("improvementarea") %>'/>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Owner to address gaps">
                                   <ItemTemplate>
                                        <%#Eval("ownertoaddressarea")%>
                                   </ItemTemplate>
                                    <ItemStyle CssClass="itemstyle"/>
                                   <EditItemTemplate>
                                        <asp:TextBox id="txtEditOwner" Runat="Server"  Text='<%# Eval("ownertoaddressarea") %>'/>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Level to which addressed in proposal" ItemStyle-Wrap="true" ControlStyle-Width="170px">
                                   <ItemTemplate>
                                        <%#Eval("level")%>
                                   </ItemTemplate>

<ControlStyle Width="170px"></ControlStyle>

                                    <ItemStyle CssClass="itemstyle"/>
                                   <EditItemTemplate>
                                        <asp:DropDownList id="ddlEditTechnicalLevel" AppendDataBoundItems="true" Runat="Server">
                                         
                                         </asp:DropDownList>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Review Date">
                                   <ItemTemplate>
                                        <%#Eval("reviewdate","{0:MM-dd-yy}")%>
                                   </ItemTemplate>
                                    <ItemStyle CssClass="itemstyle"/>
                                   <EditItemTemplate>
                                       <asp:TextBox id="txtEditReview" Runat="Server" Text='<%#Bind("reviewdate","{0:MM-dd-yy}") %>'  TextMode="SingleLine" Width="160px" CssClass="nex"/>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                               
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
               </table>
            </div>
            <h3 id="hserdel">
                <asp:label  runat="server" Width="500px">Service Delivery Model</asp:label>
                <asp:Label runat="server" ID="serweight" Width="250px"></asp:Label>
                Average Score:
                <asp:Label ID="seravscore" runat="server" BackColor="White" Text="0"></asp:Label>
            </h3>
            <div id="divserdel" >
                <table  id="tblservice">
                <tr>
                    <td valign="top">
                   <asp:Literal ID="Literal12" runat="server" SkinID="SklblLeft">Key Client Requirerment:<font color="red" size="1">*</font></asp:Literal>
                    </td>
                    <td valign="top">
                        <asp:TextBox ID="txtKeyReqServ" runat="server" TextMode="MultiLine" 
                        onkeypress="return ValidText(event,this.value)" onpaste='return maxLengthPaste(this,"250");'  SkinId="SkTxtAreaSkin" ></asp:TextBox>
                    </td>
                    <td></td>
                    <td></td>
                    <td valign="top"><asp:Literal ID="Literal13" runat="server" SkinID="SklblLeft">Impacting which Part Proposal:<font color="red" size="1">*</font></asp:Literal></td>
                    <td valign="top"><asp:TextBox ID="txtImpactServ"  runat="server" TextMode="MultiLine" 
                    onkeypress="return ValidText(event,this.value)" onpaste='return maxLengthPaste(this,"250");'  SkinId="SkTxtAreaSkin" ></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                    <asp:Literal ID="Literal14" runat="server" SkinID="SklblLeft">Gaps/Improvement Areas:<font color="red" size="1">*</font></asp:Literal>
                    </td>
                    <td valign="top">
                        <asp:TextBox ID="txtGapServ" runat="server" TextMode="MultiLine" 
                        onkeypress="return ValidText(event,this.value)" onpaste='return maxLengthPaste(this,"250");'  SkinId="SkTxtAreaSkin" ></asp:TextBox>
                    </td>
                    <td></td>
                    <td></td>
                    <td valign="top"><asp:Literal ID="Literal15" runat="server" SkinID="SklblLeft">Owner To Address Gaps:<font color="red" size="1">*</font></asp:Literal></td>
                    <td valign="top"><asp:TextBox ID="txtOwnerServ" runat="server" TextMode="MultiLine" 
                    onkeypress="return ValidText(event,this.value)" onpaste='return maxLengthPaste(this,"250");'  SkinId="SkTxtAreaSkin" ></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                    <asp:Literal ID="Literal16" runat="server" SkinID="SklblLeft">Level to which addressed in proposal:<font color="red" size="1">*</font></asp:Literal>
                    </td>
                    <td valign="top">
                       <asp:DropDownList ID="ddLevelServ" runat="server" Width="200px" SkinId="SkDrpLst"><asp:ListItem Text=""></asp:ListItem></asp:DropDownList>
                    </td>
                    <td></td>
                    <td></td>
                    <td valign="top"><asp:Literal ID="Literal17" runat="server" SkinID="SklblLeft">Review Date:<font color="red" size="1">*</font></asp:Literal></td>
                    <td  valign="top"><asp:TextBox ID="txtDateServ" runat="server" TextMode="SingleLine" Width="200px" CssClass="nex" ></asp:TextBox></td>
                </tr>
                <tr>
                    <td width="100%" colspan="6" align="center">
                        <asp:Button ID="btnAddServiceDeliveryModel" Text="Add" runat="server" CssClass="SkbtnSkin" 
                            Width="120px" onclick="btnAddServiceDeliveryModel_Click" OnClientClick="javascript:return userValidService();" />
                            <asp:Button id="btnClearServiceDeliveryModel" Text="Clear" runat="server" CssClass="SkbtnSkin"  
                            Width="120px" onclick="btnClearServiceDeliveryModel_Click"  />
                    </td>
                </tr>
                <tr>
                    <td width="100%" colspan="7" align="center">
                        <asp:Label runat="server" ID="lblgridsererr" ForeColor="Red"></asp:Label>
                        <asp:GridView ID="gridservice" runat="server" AutoGenerateColumns="False" 
                            OnRowDeleting="gridservice_rowdeleting" 
                            onrowcancelingedit="gridservice_RowCancelingEdit" 
                            onrowcommand="gridservice_RowCommand" 
                            onrowediting="gridservice_RowEditing" 
                            onrowdatabound="gridservice_RowDataBound"  >
                            <RowStyle CssClass="skGridInnerRow"/>
                            <SelectedRowStyle CssClass="skGridInnerSelectedRow" />
                            <AlternatingRowStyle CssClass="skGridInnerAlternatingRow" />
                            <HeaderStyle CssClass="skGridInnerHeader" />
                            <FooterStyle CssClass="skGridInnerFooter" />
                            <PagerStyle       CssClass="skGridInnerRow" />
                            
                            <Columns>
                                 <asp:TemplateField HeaderText="Edit">                                   
                                    <ItemTemplate>
                                       <asp:LinkButton ID="lnkEdit" Text="Edit" CommandName="Edit" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' runat="server" SkinId="SklnkSkin"></asp:LinkButton>
                                   </ItemTemplate>
                                    <EditItemTemplate>
                                    <asp:LinkButton ID="lnkUpdate" CommandName="UpdateRow" Text="Update" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' runat="server"></asp:LinkButton>   
                                        <asp:LinkButton ID="lnkCancel" CommandName="Cancel" Width="100px" Text="Cancel" runat="server"></asp:LinkButton>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Remove">
                                   <ItemTemplate>
                                       <asp:LinkButton ID="lnkDeleteServ" Text="Remove" CommandName="Delete" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' runat="server" OnClientClick="return show_alert()"></asp:LinkButton>
                                   </ItemTemplate>
                                </asp:TemplateField>  
                               <asp:TemplateField HeaderText="Key Client Requirement">
                                   <ItemTemplate>
                                        <%#Eval("keyclientrequirement")%>
                                   </ItemTemplate>
                                   <ItemStyle CssClass="itemstyle"/>
                                   <EditItemTemplate>
                                        <asp:TextBox id="txtEditKey" Runat="Server" Text='<%# Eval("keyclientrequirement") %>'/>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Impacting which part of Proposal">
                                   <ItemTemplate>
                                        <%#Eval("impactonwhichpart")%>
                                   </ItemTemplate>
                                   <ItemStyle CssClass="itemstyle"/>
                                   <EditItemTemplate>
                                        <asp:TextBox id="txtEditImpact" Runat="Server"  Text='<%# Eval("impactonwhichpart") %>'/>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Gaps/Improvement Area">
                                   <ItemTemplate>
                                        <%#Eval("improvementarea")%>
                                   </ItemTemplate>
                                   <ItemStyle CssClass="itemstyle"/>
                                   <EditItemTemplate>
                                        <asp:TextBox id="txtEditGaps" Runat="Server"  Text='<%# Eval("improvementarea") %>'/>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Owner to address gaps">
                                   <ItemTemplate>
                                        <%#Eval("ownertoaddressarea")%>
                                   </ItemTemplate>
                                   <ItemStyle CssClass="itemstyle"/>
                                   <EditItemTemplate>
                                        <asp:TextBox id="txtEditOwner" Runat="Server"  Text='<%# Eval("ownertoaddressarea") %>'/>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Level to which addressed in proposal" ItemStyle-Wrap="true" ControlStyle-Width="170px">
                                   <ItemTemplate>
                                        <%#Eval("level")%>
                                   </ItemTemplate>
                                   <ItemStyle CssClass="itemstyle"/>
                                   <EditItemTemplate>
                                        <asp:DropDownList id="ddlEditServiceLevel" AppendDataBoundItems="true" Runat="Server">
                                         
                                         </asp:DropDownList>
                                    </EditItemTemplate>

<ControlStyle Width="170px"></ControlStyle>

<ItemStyle Wrap="True"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Review Date">
                                   <ItemTemplate>
                                        <%#Eval("reviewdate","{0:MM-dd-yy}")%>
                                   </ItemTemplate>
                                   <EditItemTemplate>
                                       <asp:TextBox id="txtEditReview" Runat="Server" Text='<%#Bind("reviewdate","{0:MM-dd-yy}") %>'  TextMode="SingleLine" Width="160px" CssClass="nex"/>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                               
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
               </table>
            </div>
            <h3 id="htranpla">
                <asp:label  runat="server" Width="500px">Transition Planning</asp:label>
                <asp:Label runat="server" ID="transweight" Width="250px"></asp:Label>
                Average Score:
                <asp:Label ID="tranavscore" runat="server" BackColor="White" Text="0"></asp:Label>
            </h3>
            <div id="divtranpla" >
            <table id="tbltransition" >
                <tr>
                    <td valign="top">
                    <asp:Literal ID="Literal18" runat="server" SkinID="SklblLeft">Key Client Requirerment:<font color="red" size="1">*</font></asp:Literal>
                    </td>
                    <td valign="top">
                        <asp:TextBox ID="txtKeyReqTrans" runat="server" TextMode="MultiLine" 
                        onkeypress="return ValidText(event,this.value)" onpaste='return maxLengthPaste(this,"250");'  SkinId="SkTxtAreaSkin" ></asp:TextBox>
                    </td>
                    <td></td>
                    <td></td>
                    <td valign="top"><asp:Literal ID="Literal19" runat="server" SkinID="SklblLeft">Impacting which Part Proposal:<font color="red" size="1">*</font></asp:Literal></td>
                    <td valign="top"><asp:TextBox ID="txtImpactTrans" runat="server"  TextMode="MultiLine" 
                    onkeypress="return ValidText(event,this.value)" onpaste='return maxLengthPaste(this,"250");'  SkinId="SkTxtAreaSkin" ></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                    <asp:Literal ID="Literal20" runat="server">Gaps/Improvement Areas:<font color="red" size="1">*</font></asp:Literal>
                    </td>
                    <td valign="top">
                        <asp:TextBox ID="txtGapsTrans" runat="server"  TextMode="MultiLine" 
                        onkeypress="return ValidText(event,this.value)" onpaste='return maxLengthPaste(this,"250");'  SkinId="SkTxtAreaSkin" ></asp:TextBox>
                    </td>
                    <td></td>
                    <td></td>
                    <td valign="top"><asp:Literal ID="Literal21" runat="server" SkinID="SklblLeft">Owner To Address Gaps:<font color="red" size="1">*</font></asp:Literal></td>
                    <td valign="top"><asp:TextBox ID="txtOwnrTrans" runat="server" TextMode="MultiLine" 
                    onkeypress="return ValidText(event,this.value)" onpaste='return maxLengthPaste(this,"250");'  SkinId="SkTxtAreaSkin" ></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                    <asp:Literal ID="Literal22" runat="server" SkinID="SklblLeft">Level to which addressed in proposal:<font color="red" size="1">*</font></asp:Literal>
                    </td>
                    <td valign="top">
                       <asp:DropDownList ID="ddLevelTrans" runat="server" Width="200px" SkinId="SkDrpLst"><asp:ListItem Text=""></asp:ListItem></asp:DropDownList>
                    </td>
                    <td></td>
                    <td></td>
                    <td valign="top"><asp:Literal ID="Literal23" runat="server" SkinID="SklblLeft">Review Date:<font color="red" size="1">*</font></asp:Literal></td>
                    <td  valign="top"><asp:TextBox ID="txtDateTrans" runat="server" TextMode="SingleLine" Width="200px" CssClass="nex" ></asp:TextBox></td>
                </tr>
                <tr>
                    <td width="100%" colspan="6" align="center">
                        <asp:Button ID="btnAddTransitionPlanning" Text="Add" runat="server" CssClass="SkbtnSkin" 
                            Width="120px" onclick="btnAddTransitionPlanning_Click" OnClientClick="javascript:return userValidTransition();" />
                            <asp:Button id="btnClearTransitionPlanning" Text="Clear" runat="server" CssClass="SkbtnSkin"  
                             onclick="btnClearTransitionPlanning_Click"  />
                    </td>
                </tr>
                <tr>
                    <td width="100%" colspan="7" align="center">
                        <asp:Label runat="server" ID="lblgridtransitionerror" ForeColor="Red"></asp:Label>
                        <asp:GridView ID="gridtransition" runat="server" AutoGenerateColumns="False" 
                            OnRowDeleting="gridtransition_rowdeleting" 
                            onrowcancelingedit="gridtransition_RowCancelingEdit" 
                            onrowcommand="gridtransition_RowCommand" 
                            onrowediting="gridtransition_RowEditing" 
                            onrowdatabound="gridtransition_RowDataBound"  >
                            <RowStyle CssClass="skGridInnerRow"/>
                            <SelectedRowStyle CssClass="skGridInnerSelectedRow" />
                            <AlternatingRowStyle CssClass="skGridInnerAlternatingRow" />
                            <HeaderStyle CssClass="skGridInnerHeader" />
                            <FooterStyle CssClass="skGridInnerFooter" />
                            <PagerStyle       CssClass="skGridInnerRow" />
                            
                            <Columns>
                             <asp:TemplateField HeaderText="Edit">                                   
                                    <ItemTemplate>
                                       <asp:LinkButton ID="lnkEdit" Text="Edit" CommandName="Edit" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' runat="server" SkinId="SklnkSkin"></asp:LinkButton>
                                   </ItemTemplate>
                                    <EditItemTemplate>
                                    <asp:LinkButton ID="lnkUpdate" CommandName="UpdateRow" Text="Update" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' runat="server" SkinId="SklnkSkin"></asp:LinkButton>   
                                        &nbsp;<asp:LinkButton ID="lnkCancel" CommandName="Cancel" Width="100px" Text="Cancel" runat="server" SkinId="SklnkSkin"></asp:LinkButton>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Remove">
                                   <ItemTemplate>
                                       <asp:LinkButton ID="lnkDeleteTrans" Text="Remove" CommandName="Delete" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' runat="server" SkinId="SklnkSkin" OnClientClick="return show_alert()"></asp:LinkButton>
                                   </ItemTemplate>
                                </asp:TemplateField>  
                               <asp:TemplateField HeaderText="Key Client Requirement">
                                   <ItemTemplate>
                                        <%#Eval("keyclientrequirement")%>
                                   </ItemTemplate>
                                   <ItemStyle CssClass="itemstyle"/>
                                   <EditItemTemplate>
                                        <asp:TextBox id="txtEditKey" Runat="Server" Text='<%# Eval("keyclientrequirement") %>'/>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Impacting which part of Proposal">
                                   <ItemTemplate>
                                        <%#Eval("impactonwhichpart")%>
                                   </ItemTemplate>
                                   <ItemStyle CssClass="itemstyle"/>
                                   <EditItemTemplate>
                                        <asp:TextBox id="txtEditImpact" Runat="Server"  Text='<%# Eval("impactonwhichpart") %>'/>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Gaps/Improvement Area">
                                   <ItemTemplate>
                                        <%#Eval("improvementarea")%>
                                   </ItemTemplate>
                                   <ItemStyle CssClass="itemstyle"/>
                                   <EditItemTemplate>
                                        <asp:TextBox id="txtEditGaps" Runat="Server"  Text='<%# Eval("improvementarea") %>'/>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Owner to address gaps">
                                   <ItemTemplate>
                                        <%#Eval("ownertoaddressarea")%>
                                   </ItemTemplate>
                                   <ItemStyle CssClass="itemstyle"/>
                                   <EditItemTemplate>
                                        <asp:TextBox id="txtEditOwner" Runat="Server"  Text='<%# Eval("ownertoaddressarea") %>'/>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Level to which addressed in proposal" ItemStyle-Wrap="true" ControlStyle-Width="170px">
                                   <ItemTemplate>
                                        <%#Eval("level")%>
                                   </ItemTemplate>
                                   <ItemStyle CssClass="itemstyle"/>
                                   <EditItemTemplate>
                                        <asp:DropDownList id="ddlEditTransitionLevel" AppendDataBoundItems="true" Runat="Server">
                                         
                                         </asp:DropDownList>
                                    </EditItemTemplate>

<ControlStyle Width="170px"></ControlStyle>

<ItemStyle Wrap="True"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Review Date">
                                   <ItemTemplate>
                                        <%#Eval("reviewdate","{0:MM-dd-yy}")%>
                                   </ItemTemplate>
                                   <EditItemTemplate>
                                       <asp:TextBox id="txtEditReview" Text='<%#Bind("reviewdate","{0:MM-dd-yy}") %>' Runat="Server"  TextMode="SingleLine" Width="160px" CssClass="nex"/>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                               
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
               </table>
            </div>
            <h3 id="hgov">
                <asp:label  runat="server"  SkinID="SklblLeft" Width="500px">Governance and Engagement Model</asp:label>
                <asp:Label runat="server" ID="govweight" Width="250px"  SkinID="SklblLeft"></asp:Label>
                 Average Score:
                <asp:Label ID="govavscore" runat="server" BackColor="White" Text="0"></asp:Label>
            </h3>
            <div id="divgov">
                <table  id="tblgovern">
                <tr>
                    <td valign="top">
                    <asp:Literal ID="Literal24" runat="server" SkinID="SklblLeft">Key Client Requirerment:<font color="red" size="1">*</font></asp:Literal>
                    </td>
                    <td valign="top">
                        <asp:TextBox ID="txtKeyReqGov" runat="server"  TextMode="MultiLine" 
                        onkeypress="return ValidText(event,this.value)" onpaste='return maxLengthPaste(this,"250");' SkinId="SkTxtAreaSkin" ></asp:TextBox>
                    </td>
                    <td></td>
                    <td></td>
                    <td valign="top"><asp:Literal ID="Literal25" runat="server" SkinID="SklblLeft">Impacting which Part Proposal:<font color="red" size="1">*</font></asp:Literal></td>
                    <td valign="top"><asp:TextBox ID="txtImpactGov"  runat="server" TextMode="MultiLine" 
                    onkeypress="return ValidText(event,this.value)" onpaste='return maxLengthPaste(this,"250");'  SkinId="SkTxtAreaSkin" ></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                    <asp:Literal ID="Literal26" runat="server" SkinID="SklblLeft">Gaps/Improvement Areas:<font color="red" size="1">*</font></asp:Literal>
                    </td>
                    <td valign="top">
                        <asp:TextBox ID="txtGapsGov" runat="server" TextMode="MultiLine" 
                        onkeypress="return ValidText(event,this.value)" onpaste='return maxLengthPaste(this,"250");'  SkinId="SkTxtAreaSkin" ></asp:TextBox>
                    </td>
                    <td></td>
                    <td></td>
                    <td valign="top"><asp:Literal ID="Literal27" runat="server" SkinID="SklblLeft">Owner To Address Gaps:<font color="red" size="1">*</font></asp:Literal></td>
                    <td valign="top"><asp:TextBox ID="txtOwnrGov"  runat="server" TextMode="MultiLine" 
                    onkeypress="return ValidText(event,this.value)" onpaste='return maxLengthPaste(this,"250");'  SkinId="SkTxtAreaSkin" ></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                    <asp:Literal ID="Literal28" runat="server" SkinID="SklblLeft">Level to which addressed in proposal:<font color="red" size="1">*</font></asp:Literal>
                    </td>
                    <td valign="top">
                       <asp:DropDownList ID="ddLevelGov" runat="server" Width="200px" SkinId="SkDrpLst"><asp:ListItem Text=""></asp:ListItem></asp:DropDownList>
                    </td>
                    <td></td>
                    <td></td>
                    <td valign="top"><asp:Literal ID="Literal29" runat="server" SkinID="SklblLeft">Review Date:<font color="red" size="1">*</font></asp:Literal></td>
                    <td  valign="top"><asp:TextBox ID="txtDateGov" runat="server" TextMode="SingleLine" Width="200px" CssClass="nex" ></asp:TextBox></td>
                </tr>
                <tr>
                    <td width="100%" colspan="6" align="center">
                        <asp:Button ID="btnAddGovernance" Text="Add" runat="server" CssClass="SkbtnSkin" 
                            Width="120px" onclick="btnAddGovernance_Click" OnClientClick="javascript:return userValidGovernance();"  />
                            <asp:Button id="btnClearGovernance" Text="Clear" runat="server" CssClass="SkbtnSkin" 
                            Width="120px" onclick="btnClearGovernance_Click"  />
                    </td>
                </tr>
                <tr>
                    <td width="100%" colspan="7" align="center">
                    <asp:Label runat="server" ID="lblgridgovernerror" ForeColor="Red" ></asp:Label>
                        <asp:GridView ID="gridgovern" runat="server" AutoGenerateColumns="False" 
                            OnRowDeleting="gridgovern_rowdeleting" 
                            onrowcancelingedit="gridgovern_RowCancelingEdit" 
                            onrowcommand="gridgovern_RowCommand" onrowediting="gridgovern_RowEditing" 
                            onrowdatabound="gridgovern_RowDataBound" >
                            <RowStyle CssClass="skGridInnerRow"/>
                            <SelectedRowStyle CssClass="skGridInnerSelectedRow" />
                            <AlternatingRowStyle CssClass="skGridInnerAlternatingRow" />
                            <HeaderStyle CssClass="skGridInnerHeader" />
                            <FooterStyle CssClass="skGridInnerFooter" />
                            <PagerStyle       CssClass="skGridInnerRow" />
                            
                            <Columns>
                            <asp:TemplateField HeaderText="Edit">                                   
                                    <ItemTemplate>
                                       <asp:LinkButton ID="lnkEdit" Text="Edit" CommandName="Edit" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' runat="server" SkinId="SklnkSkin"></asp:LinkButton>
                                   </ItemTemplate>
                                    <EditItemTemplate>
                                    <asp:LinkButton ID="lnkUpdate" CommandName="UpdateRow" Width="100px" Text="Update" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' runat="server" SkinId="SklnkSkin"></asp:LinkButton>   
                                        &nbsp;<asp:LinkButton ID="lnkCancel" CommandName="Cancel" Text="Cancel" runat="server" SkinId="SklnkSkin"></asp:LinkButton>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Remove">
                                   <ItemTemplate>
                                       <asp:LinkButton ID="lnkDeleteGovern" Text="Remove" CommandName="Delete" OnClientClick="return show_alert()" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' runat="server" SkinId="SklnkSkin"></asp:LinkButton>
                                   </ItemTemplate>
                                </asp:TemplateField>  
                               <asp:TemplateField HeaderText="Key Client Requirement">
                                   <ItemTemplate>
                                        <%#Eval("keyclientrequirement")%>
                                   </ItemTemplate>
                                   <ItemStyle CssClass="itemstyle"/>
                                   <EditItemTemplate>
                                        <asp:TextBox id="txtEditKey" Runat="Server" Text='<%# Eval("keyclientrequirement") %>'/>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Impacting which part of Proposal">
                                   <ItemTemplate>
                                        <%#Eval("impactonwhichpart")%>
                                   </ItemTemplate>
                                   <ItemStyle CssClass="itemstyle"/>
                                   <EditItemTemplate>
                                        <asp:TextBox id="txtEditImpact" Runat="Server"  Text='<%# Eval("impactonwhichpart") %>'/>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Gaps/Improvement Area">
                                   <ItemTemplate>
                                        <%#Eval("improvementarea")%>
                                   </ItemTemplate>
                                   <ItemStyle CssClass="itemstyle"/>
                                   <EditItemTemplate>
                                        <asp:TextBox id="txtEditGaps" Runat="Server"  Text='<%# Eval("improvementarea") %>' />
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Owner to address gaps">
                                   <ItemTemplate>
                                        <%#Eval("ownertoaddressarea")%>
                                   </ItemTemplate>
                                   <ItemStyle CssClass="itemstyle"/>
                                   <EditItemTemplate>
                                        <asp:TextBox id="txtEditOwner" Runat="Server"  Text='<%# Eval("ownertoaddressarea") %>'/>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Level to which addressed in proposal" ItemStyle-Wrap="true" ControlStyle-Width="170px">
                                   <ItemTemplate>
                                        <%#Eval("level")%>
                                   </ItemTemplate>
                                   <ItemStyle CssClass="itemstyle"/>
                                   <EditItemTemplate>
                                        <asp:DropDownList id="ddlEditGovernLevel" AppendDataBoundItems="true" Runat="Server">
                                        
                                         </asp:DropDownList>
                                    </EditItemTemplate>

<ControlStyle Width="170px"></ControlStyle>

<ItemStyle Wrap="True"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Review Date">
                                   <ItemTemplate>
                                        <%#Eval("reviewdate","{0:MM-dd-yy}")%>
                                   </ItemTemplate>
                                   <EditItemTemplate>
                                       <asp:TextBox id="txtEditReview" Runat="Server" Text='<%#Bind("reviewdate","{0:MM-dd-yy}") %>'  TextMode="SingleLine" Width="160px" CssClass="nex"/>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
               </table>
            </div>
            <h3 id="hpro">
                <asp:label ID="Label3"  runat="server" Width="500px" SkinID="SklblLeft">Process Methodologies</asp:label>
                <asp:Label runat="server" ID="proweight" Width="250px" SkinID="SklblLeft"></asp:Label>
                Average Score:
                <asp:Label ID="proavscore" runat="server" BackColor="White" Text="0"></asp:Label>    
            </h3>
            <div id="divpro" >
            <table id="tblprocess" >
                <tr>
                    <td valign="top">
                    <asp:Literal ID="Literal30" runat="server"  SkinID="SklblLeft" >Key Client Requirerment:<font color="red" size="1">*</font></asp:Literal>
                    </td>
                    <td valign="top">
                        <asp:TextBox ID="txtKeyReqProc" runat="server" TextMode="MultiLine"
                        onkeypress="return ValidText(event,this.value)" onpaste='return maxLengthPaste(this,"250");'  SkinId="SkTxtAreaSkin" ></asp:TextBox>
                    </td>
                    <td></td>
                    <td></td>
                    <td valign="top"><asp:Literal ID="Literal31" runat="server" SkinID="SklblLeft">Impacting which Part Proposal:<font color="red" size="1">*</font></asp:Literal></td>
                    <td valign="top"><asp:TextBox ID="txtImpactProc"  runat="server" TextMode="MultiLine" 
                    onkeypress="return ValidText(event,this.value)" onpaste='return maxLengthPaste(this,"250");'  SkinId="SkTxtAreaSkin" ></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                    <asp:Literal ID="Literal32" runat="server" SkinID="SklblLeft">Gaps/Improvement Areas:<font color="red" size="1">*</font></asp:Literal>
                    </td>
                    <td valign="top">
                        <asp:TextBox ID="txtGapsProc" runat="server"  TextMode="MultiLine" 
                        onkeypress="return ValidText(event,this.value)" onpaste='return maxLengthPaste(this,"250");' SkinId="SkTxtAreaSkin" ></asp:TextBox>
                    </td>
                    <td></td>
                    <td></td>
                    <td valign="top"><asp:Literal ID="Literal33" runat="server" SkinID="SklblLeft">Owner To Address Gaps:<font color="red" size="1">*</font></asp:Literal></td>
                    <td valign="top"><asp:TextBox ID="txtOwnrProc"  runat="server" TextMode="MultiLine"
                    onkeypress="return ValidText(event,this.value)" onpaste='return maxLengthPaste(this,"250");'  SkinId="SkTxtAreaSkin" ></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                    <asp:Literal ID="Literal34" runat="server" SkinID="SklblLeft">Level to which addressed in proposal:<font color="red" size="1">*</font></asp:Literal>
                    </td>
                    <td valign="top">
                       <asp:DropDownList ID="ddLevelProc" runat="server" Width="200px" SkinId="SkDrpLst"><asp:ListItem Text=""></asp:ListItem></asp:DropDownList>
                    </td>
                    <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                    <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                    <td valign="top"><asp:Literal ID="Literal35" runat="server" SkinID="SklblLeft">Review Date:<font color="red" size="1">*</font></asp:Literal></td>
                    <td  valign="top"><asp:TextBox ID="txtDateProc" runat="server" TextMode="SingleLine" Width="200px" CssClass="nex" ></asp:TextBox></td>
                </tr>
                <tr>
                    <td width="100%" colspan="6" align="center">
                        <asp:Button ID="btnAddProcess" Text="Add" runat="server" CssClass="SkbtnSkin" 
                            onclick="btnAddProcess_Click" OnClientClick="javascript:return userValidProcess();" />
                             <asp:Button id="btnClearProcess" Text="Clear" runat="server" CssClass="SkbtnSkin" 
                            Width="120px" onclick="btnClearProcess_Click"  />
                    </td>
                </tr>
                <tr>
                    <td width="100%" colspan="7" align="center">
                    <asp:Label runat="server" ID="lblgridprocesserror" ForeColor="Red"></asp:Label>
                        <asp:GridView ID="gridprocess" runat="server" AutoGenerateColumns="False" 
                            OnRowDeleting="gridprocess_rowdeleting" 
                            onrowcancelingedit="gridprocess_RowCancelingEdit" 
                            onrowcommand="gridprocess_RowCommand" 
                            onrowediting="gridprocess_RowEditing" 
                            onrowdatabound="gridprocess_RowDataBound" >
                            <RowStyle CssClass="skGridInnerRow"/>
                            <SelectedRowStyle CssClass="skGridInnerSelectedRow" />
                            <AlternatingRowStyle CssClass="skGridInnerAlternatingRow" />
                            <HeaderStyle CssClass="skGridInnerHeader" />
                            <FooterStyle CssClass="skGridInnerFooter" />
                            <PagerStyle       CssClass="skGridInnerRow" />
                            <Columns>
                                 <asp:TemplateField HeaderText="Edit">                                   
                                    <ItemTemplate>
                                       <asp:LinkButton ID="lnkEdit" Text="Edit" CommandName="Edit" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' runat="server" SkinId="SklnkSkin"></asp:LinkButton>
                                   </ItemTemplate>
                                    <EditItemTemplate>
                                    <asp:LinkButton ID="lnkUpdate" CommandName="UpdateRow" Width="100px" Text="Update" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' runat="server" SkinId="SklnkSkin"></asp:LinkButton>   
                                        &nbsp;<asp:LinkButton ID="lnkCancel" CommandName="Cancel" Text="Cancel" runat="server" SkinId="SklnkSkin"></asp:LinkButton>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Remove">
                                   <ItemTemplate>
                                       <asp:LinkButton ID="lnkDeleteProcess" Text="Remove" CommandName="Delete" OnClientClick="return show_alert()" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' runat="server" SkinId="SklnkSkin"></asp:LinkButton>
                                   </ItemTemplate>
                                </asp:TemplateField>  
                               <asp:TemplateField HeaderText="Key Client Requirement">
                                   <ItemTemplate>
                                        <%#Eval("keyclientrequirement")%>
                                   </ItemTemplate>
                                   <ItemStyle CssClass="itemstyle"/>
                                   <EditItemTemplate>
                                        <asp:TextBox id="txtEditKey" Runat="Server" Text='<%# Eval("keyclientrequirement") %>'/>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Impacting which part of Proposal">
                                   <ItemTemplate>
                                        <%#Eval("impactonwhichpart")%>
                                   </ItemTemplate>
                                   <ItemStyle CssClass="itemstyle"/>
                                   <EditItemTemplate>
                                        <asp:TextBox id="txtEditImpact" Runat="Server"  Text='<%# Eval("impactonwhichpart") %>'/>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Gaps/Improvement Area">
                                   <ItemTemplate>
                                        <%#Eval("improvementarea")%>
                                   </ItemTemplate>
                                   <ItemStyle CssClass="itemstyle"/>
                                   <EditItemTemplate>
                                        <asp:TextBox id="txtEditGaps" Runat="Server"  Text='<%# Eval("improvementarea") %>'/>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Owner to address gaps">
                                   <ItemTemplate>
                                        <%#Eval("ownertoaddressarea")%>
                                   </ItemTemplate>
                                   <ItemStyle CssClass="itemstyle"/>
                                   <EditItemTemplate>
                                        <asp:TextBox id="txtEditOwner" Runat="Server"  Text='<%# Eval("ownertoaddressarea") %>'/>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Level to which addressed in proposal" ItemStyle-Wrap="true" ControlStyle-Width="170px">
                                   <ItemTemplate>
                                        <%#Eval("level")%>
                                   </ItemTemplate>
                                   <ItemStyle CssClass="itemstyle"/>
                                   <EditItemTemplate>
                                        <asp:DropDownList id="ddlEditProcessLevel" AppendDataBoundItems="true" Runat="Server">
                                        
                                         </asp:DropDownList>
                                    </EditItemTemplate>

<ControlStyle Width="170px"></ControlStyle>

<ItemStyle Wrap="True"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Review Date">
                                   <ItemTemplate>
                                        <%#Eval("reviewdate","{0:MM-dd-yy}")%>
                                   </ItemTemplate>
                                   
                                   <EditItemTemplate>
                                       <asp:TextBox id="txtEditReview" Runat="Server" Text='<%#Bind("reviewdate","{0:MM-dd-yy}") %>'  TextMode="SingleLine" Width="160px" CssClass="nex"/>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                               
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
               </table>
            </div>
            <h3 id="hhr">
                <asp:label runat="server" Width="500px">HR and Change Management</asp:label>
                <asp:Label runat="server" ID="hrweight" Width="250px"></asp:Label>
                Average Score:
                <asp:Label ID="hravscore" runat="server" BackColor="White" Text="0"></asp:Label>

            </h3>
            <div id="divhr" >
                <table id="tblhr" >
                <tr>
                    <td valign="top">
                   <asp:Literal ID="Literal36" runat="server" SkinID="SklblLeft">Key Client Requirerment:<font color="red" size="1">*</font></asp:Literal>
                    </td>
                    <td valign="top">
                        <asp:TextBox ID="txtKeyReqHR" runat="server" TextMode="MultiLine" 
                        onkeypress="return ValidText(event,this.value)" onpaste='return maxLengthPaste(this,"250");' SkinId="SkTxtAreaSkin"></asp:TextBox>
                    </td>
                    <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                    <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                    <td valign="top"><asp:Literal ID="Literal37" runat="server" SkinID="SklblLeft">Impacting which Part Proposal:<font color="red" size="1">*</font></asp:Literal></td>
                    <td valign="top"><asp:TextBox ID="txtImpactHR" runat="server" TextMode="MultiLine"  
                    onkeypress="return ValidText(event,this.value)" onpaste='return maxLengthPaste(this,"250");' SkinId="SkTxtAreaSkin"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                    <asp:Literal ID="Literal38" runat="server" SkinID="SklblLeft">Gaps/Improvement Areas:<font color="red" size="1">*</font></asp:Literal>
                    </td>
                    <td valign="top">
                        <asp:TextBox ID="txtGapsHR" runat="server" TextMode="MultiLine" 
                        onkeypress="return ValidText(event,this.value)" onpaste='return maxLengthPaste(this,"250");' SkinId="SkTxtAreaSkin"></asp:TextBox>
                    </td>
                    <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                    <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                    <td valign="top"><asp:Literal ID="Literal39" runat="server" SkinID="SklblLeft">Owner To Address Gaps:<font color="red" size="1">*</font></asp:Literal></td>
                    <td valign="top"><asp:TextBox ID="txtOwnrHR" runat="server"  TextMode="MultiLine" 
                    onkeypress="return ValidText(event,this.value)" onpaste='return maxLengthPaste(this,"250");' SkinId="SkTxtAreaSkin"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                    <asp:Literal ID="Literal40" runat="server" SkinID="SklblLeft">Level to which addressed in proposal:<font color="red" size="1">*</font></asp:Literal>
                    </td>
                    <td valign="top">
                       <asp:DropDownList ID="ddLevelHR" runat="server" Width="200px" SkinId="SkDrpLst"><asp:ListItem Text=""></asp:ListItem></asp:DropDownList>
                    </td>
                    <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                    <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                    <td valign="top"><asp:Literal ID="Literal41" runat="server" SkinID="SklblLeft">Review Date:<font color="red" size="1">*</font></asp:Literal></td>
                    <td  valign="top"><asp:TextBox ID="txtDateHR" runat="server" TextMode="SingleLine" Width="200px" CssClass="nex"></asp:TextBox></td>
                </tr>
                <tr>
                    <td width="100%" colspan="6" align="center">
                        <asp:Button ID="btnAddHrChangeManagement" Text="Add" runat="server" CssClass="SkbtnSkin" 
                            Width="120px" onclick="btnAddHrChangeManagement_Click" OnClientClick="javascript:return userValidHR();" />
                             <asp:Button id="btnClearHrChangeManagement" Text="Clear" runat="server" CssClass="SkbtnSkin" 
                            Width="120px" onclick="btnClearHrChangeManagement_Click"  />
                    </td>
                </tr>
                <tr>
                    <td width="100%" colspan="7" align="center">
                    <asp:Label runat="server" ID="lblgridhrerror" ForeColor="Red"></asp:Label>
                        <asp:GridView ID="gridhr" runat="server" AutoGenerateColumns="False" 
                            OnRowDeleting="gridhr_rowdeleting" onrowcancelingedit="gridhr_RowCancelingEdit" 
                            onrowcommand="gridhr_RowCommand" onrowediting="gridhr_RowEditing" 
                            onrowdatabound="gridhr_RowDataBound" >
                            <RowStyle CssClass="skGridInnerRow"/>
                            <SelectedRowStyle CssClass="skGridInnerSelectedRow" />
                            <AlternatingRowStyle CssClass="skGridInnerAlternatingRow" />
                            <HeaderStyle CssClass="skGridInnerHeader" />
                            <FooterStyle CssClass="skGridInnerFooter" />
                            <PagerStyle       CssClass="skGridInnerRow" />
                           
                            <Columns>
                            <asp:TemplateField HeaderText="Edit">                                   
                                    <ItemTemplate>
                                       <asp:LinkButton ID="lnkEdit" Text="Edit" CommandName="Edit" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' runat="server" SkinId="SklnkSkin"></asp:LinkButton>
                                   </ItemTemplate>
                                    <EditItemTemplate>
                                    <asp:LinkButton ID="lnkUpdate" CommandName="UpdateRow" Width="100px" Text="Update" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' runat="server" SkinId="SklnkSkin"></asp:LinkButton>   
                                        &nbsp;<asp:LinkButton ID="lnkCancel" CommandName="Cancel" Text="Cancel" runat="server"></asp:LinkButton>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Remove">
                                   <ItemTemplate>
                                       <asp:LinkButton ID="lnkDeletehr" Text="Remove" CommandName="Delete" OnClientClick="return show_alert()" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' runat="server" SkinId="SklnkSkin"></asp:LinkButton>
                                   </ItemTemplate>
                                </asp:TemplateField>  
                               <asp:TemplateField HeaderText="Key Client Requirement">
                                   <ItemTemplate>
                                        <%#Eval("keyclientrequirement")%>
                                   </ItemTemplate>
                                   <ItemStyle CssClass="itemstyle"/>
                                   <EditItemTemplate>
                                        <asp:TextBox id="txtEditKey" Runat="Server" Text='<%# Eval("keyclientrequirement") %>'/>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Impacting which part of Proposal">
                                   <ItemTemplate>
                                        <%#Eval("impactonwhichpart")%>
                                   </ItemTemplate>
                                   <ItemStyle CssClass="itemstyle"/>
                                   <EditItemTemplate>
                                        <asp:TextBox id="txtEditImpact" Runat="Server"  Text='<%# Eval("impactonwhichpart") %>'/>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Gaps/Improvement Area">
                                   <ItemTemplate>
                                        <%#Eval("improvementarea")%>
                                   </ItemTemplate>
                                   <ItemStyle CssClass="itemstyle"/>
                                   <EditItemTemplate>
                                        <asp:TextBox id="txtEditGaps" Runat="Server"  Text='<%# Eval("improvementarea") %>'/>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Owner to address gaps">
                                   <ItemTemplate>
                                        <%#Eval("ownertoaddressarea")%>
                                   </ItemTemplate>
                                   <ItemStyle CssClass="itemstyle"/>
                                   <EditItemTemplate>
                                        <asp:TextBox id="txtEditOwner" Runat="Server"  Text='<%# Eval("ownertoaddressarea") %>'/>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Level to which addressed in proposal" ItemStyle-Wrap="true" ControlStyle-Width="170px">
                                   <ItemTemplate>
                                        <%#Eval("level")%>
                                   </ItemTemplate>
                                   <ItemStyle CssClass="itemstyle"/>
                                   <EditItemTemplate>
                                        <asp:DropDownList id="ddlEditHrLevel" AppendDataBoundItems="true" Runat="Server">
                                         
                                         </asp:DropDownList>
                                    </EditItemTemplate>

<ControlStyle Width="170px"></ControlStyle>

<ItemStyle Wrap="True"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Review Date">
                                   <ItemTemplate>
                                        <%#Eval("reviewdate","{0:MM-dd-yy}")%>
                                   </ItemTemplate>
                                   <EditItemTemplate>
                                       <asp:TextBox id="txtEditReview" Runat="Server" Text='<%#Bind("reviewdate","{0:MM-dd-yy}") %>'  TextMode="SingleLine" Width="160px" CssClass="nex"/>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
               </table>
            </div>
            <h3 id="hcom">
               <asp:label runat="server" Width="500px">Commercial and Pricing</asp:label>
               <asp:Label runat="server" ID="commweight" Width="250px"></asp:Label>
               Average Score:
               <asp:Label ID="comavscore" runat="server" BackColor="White" Text="0"></asp:Label> 
            </h3>
            <div id="divcom" >         
            <table id="tblcommercial" >
                <tr>
                    <td valign="top">
                    <asp:Literal ID="Literal42" runat="server" SkinID="SklblLeft">Key Client Requirerment:<font color="red" size="1">*</font></asp:Literal>
                    </td>
                    <td valign="top">
                        <asp:TextBox ID="txtKeyReqCom" runat="server"  TextMode="MultiLine" 
                        onkeypress="return ValidText(event,this.value)" onpaste='return maxLengthPaste(this,"250");' SkinId="SkTxtAreaSkin"></asp:TextBox>
                    </td>
                    <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                    <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                    <td valign="top"><asp:Literal ID="Literal43" runat="server" SkinID="SklblLeft">Impacting which Part Proposal:<font color="red" size="1">*</font></asp:Literal></td>
                    <td valign="top"><asp:TextBox ID="txtImpactCom"  runat="server" TextMode="MultiLine" 
                    onkeypress="return ValidText(event,this.value)" onpaste='return maxLengthPaste(this,"250");' SkinId="SkTxtAreaSkin"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                    <asp:Literal ID="Literal44" runat="server" SkinID="SklblLeft">Gaps/Improvement Areas:<font color="red" size="1">*</font></asp:Literal>
                    </td>
                    <td valign="top">
                        <asp:TextBox ID="txtGapsCom" runat="server"  TextMode="MultiLine" 
                        onkeypress="return ValidText(event,this.value)" onpaste='return maxLengthPaste(this,"250");' SkinId="SkTxtAreaSkin"></asp:TextBox>
                    </td>
                    <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                    <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                    <td valign="top"><asp:Literal ID="Literal45" runat="server" SkinID="SklblLeft">Owner To Address Gaps:<font color="red" size="1">*</font></asp:Literal></td>
                    <td valign="top"><asp:TextBox ID="txtOwnrCom"  runat="server" TextMode="MultiLine" 
                    onkeypress="return ValidText(event,this.value)" onpaste='return maxLengthPaste(this,"250");' SkinId="SkTxtAreaSkin"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                    <asp:Literal ID="Literal46" runat="server" SkinID="SklblLeft">Level to which addressed in proposal:<font color="red" size="1">*</font></asp:Literal>
                    </td>
                    <td valign="top">
                       <asp:DropDownList ID="ddLevelCom" runat="server" Width="200px" SkinId="SkDrpLst"><asp:ListItem Text=""></asp:ListItem></asp:DropDownList>
                    </td>
                    <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                    <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                    <td valign="top"><asp:Literal ID="Literal47" runat="server" SkinID="SklblLeft">Review Date:<font color="red" size="1">*</font></asp:Literal></td>
                    <td  valign="top"><asp:TextBox ID="txtDateCom" runat="server" TextMode="SingleLine" Width="200px" CssClass="nex" ></asp:TextBox></td>
                </tr>
                <tr>
                    <td width="100%" colspan="6" align="center">
                        <asp:Button ID="btnAddCommercialsPricing" Text="Add" runat="server" CssClass="SkbtnSkin" 
                            Width="120px" onclick="btnAddCommercialsPricing_Click" OnClientClick="javascript:return userValidCommercial();"/>
                             <asp:Button id="btnClearCommercialsPricing" Text="Clear" runat="server" CssClass="SkbtnSkin" 
                            Width="120px" onclick="btnClearCommercialsPricing_Click"  />
                    </td>
                </tr>
                <tr>
                    <td width="100%" colspan="7" align="center" valign="top">
                    <asp:Label runat="server" ID="lblgridcommercialerror" ForeColor="Red"></asp:Label>
                        <asp:GridView ID="gridcommercial" runat="server" AutoGenerateColumns="False" 
                            OnRowDeleting="gridcommercial_rowdeleting" 
                            onrowcancelingedit="gridcommercial_RowCancelingEdit" 
                            onrowcommand="gridcommercial_RowCommand" 
                            onrowediting="gridcommercial_RowEditing" 
                            onrowdatabound="gridcommercial_RowDataBound" >
                            <RowStyle CssClass="skGridInnerRow"/>
                            <SelectedRowStyle CssClass="skGridInnerSelectedRow" />
                            <AlternatingRowStyle CssClass="skGridInnerAlternatingRow" />
                            <HeaderStyle CssClass="skGridInnerHeader" />
                            <FooterStyle CssClass="skGridInnerFooter" />
                            <PagerStyle       CssClass="skGridInnerRow" />
                            
                            <Columns>
                                <asp:TemplateField HeaderText="Edit">                                   
                                    <ItemTemplate>
                                       <asp:LinkButton ID="lnkEdit" Text="Edit" CommandName="Edit" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' runat="server" SkinId="SklnkSkin"></asp:LinkButton>
                                   </ItemTemplate>
                                    <EditItemTemplate>
                                    <asp:LinkButton ID="lnkUpdate" CommandName="UpdateRow" Width="100px" Text="Update" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' runat="server" SkinId="SklnkSkin"></asp:LinkButton>   
                                        &nbsp;<asp:LinkButton ID="lnkCancel" CommandName="Cancel" Text="Cancel" runat="server" SkinId="SklnkSkin"></asp:LinkButton>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Remove">
                                   <ItemTemplate>
                                       <asp:LinkButton ID="lnkDeleteCommer" Text="Remove" CommandName="Delete" OnClientClick="return show_alert()" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' runat="server" SkinId="SklnkSkin"></asp:LinkButton>
                                   </ItemTemplate>
                                </asp:TemplateField>  
                               <asp:TemplateField HeaderText="Key Client Requirement">
                                   <ItemTemplate>
                                        <%#Eval("keyclientrequirement")%>
                                   </ItemTemplate>
                                   <ItemStyle CssClass="itemstyle"/>
                                   <EditItemTemplate>
                                        <asp:TextBox id="txtEditKey" Runat="Server" Text='<%# Eval("keyclientrequirement") %>'/>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Impacting which part of Proposal">
                                   <ItemTemplate>
                                        <%#Eval("impactonwhichpart")%>
                                   </ItemTemplate>
                                   <ItemStyle CssClass="itemstyle"/>
                                   <EditItemTemplate>
                                        <asp:TextBox id="txtEditImpact" Runat="Server"  Text='<%# Eval("impactonwhichpart") %>'/>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Gaps/Improvement Area">
                                   <ItemTemplate>
                                        <%#Eval("improvementarea")%>
                                   </ItemTemplate>
                                   <ItemStyle CssClass="itemstyle"/>
                                   <EditItemTemplate>
                                        <asp:TextBox id="txtEditGaps" Runat="Server"  Text='<%# Eval("improvementarea") %>'/>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Owner to address gaps">
                                   <ItemTemplate>
                                        <%#Eval("ownertoaddressarea")%>
                                   </ItemTemplate>
                                   <ItemStyle CssClass="itemstyle"/>
                                   <EditItemTemplate>
                                        <asp:TextBox id="txtEditOwner" Runat="Server"  Text='<%# Eval("ownertoaddressarea") %>'/>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Level to which addressed in proposal" ItemStyle-Wrap="true" ControlStyle-Width="170px">
                                   <ItemTemplate>
                                        <%#Eval("level")%>
                                   </ItemTemplate>
                                   <ItemStyle CssClass="itemstyle"/>
                                   <EditItemTemplate>
                                        <asp:DropDownList id="ddlEditCommercialLevel" AppendDataBoundItems="true" Runat="Server">
                                         
                                         </asp:DropDownList>
                                    </EditItemTemplate>

<ControlStyle Width="170px"></ControlStyle>

<ItemStyle Wrap="True"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Review Date">
                                   <ItemTemplate>
                                        <%#Eval("reviewdate","{0:MM-dd-yy}")%>
                                   </ItemTemplate>
                                   <EditItemTemplate>
                                       <asp:TextBox id="txtEditReview" Runat="Server"  Text='<%#Bind("reviewdate","{0:MM-dd-yy}") %>' TextMode="SingleLine" Width="160px" CssClass="nex"/>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
               </table>
            </div>
            <h3 id="hinte">
                <asp:label runat="server" Width="500px" SkinID="SklblLeft">Integrations</asp:label>
                <asp:Label runat="server" ID="intweight" Width="250px" SkinID="SklblLeft"></asp:Label>
                Average Score:
                <asp:Label ID="intavscore" runat="server" BackColor="White" Text="0"></asp:Label>
            </h3>
            <div id="divhinte">
                <table id="tblintegration" >
                <tr>
                    <td valign="top">
                    <asp:Literal ID="Literal48" runat="server" SkinID="SklblLeft">Key Client Requirerment:<font color="red" size="1">*</font></asp:Literal>
                    </td>
                    <td valign="top">
                        <asp:TextBox ID="txtKeyReqInt" runat="server" class="hightlight" TextMode="MultiLine" Width="200px" Height="50px"
                        onkeypress="return ValidText(event,this.value)" onpaste='return maxLengthPaste(this,"250");'></asp:TextBox>
                    </td>
                    <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                    <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                    <td valign="top"><asp:Literal ID="Literal49" runat="server" SkinID="SklblLeft">Impacting which Part Proposal:<font color="red" size="1">*</font></asp:Literal></td>
                    <td valign="top"><asp:TextBox ID="txtImpactInt" runat="server"  TextMode="MultiLine" 
                    onkeypress="return ValidText(event,this.value)" onpaste='return maxLengthPaste(this,"250");' SkinId="SkTxtAreaSkin"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                    <asp:Literal ID="Literal50" runat="server" SkinID="SklblLeft">Gaps/Improvement Areas:<font color="red" size="1">*</font></asp:Literal>
                    </td>
                    <td valign="top">
                        <asp:TextBox ID="txtGapsInt" runat="server" TextMode="MultiLine"
                        onkeypress="return ValidText(event,this.value)" onpaste='return maxLengthPaste(this,"250");' SkinId="SkTxtAreaSkin"></asp:TextBox>
                    </td>
                    <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                    <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                    <td valign="top"><asp:Literal ID="Literal51" runat="server" SkinID="SklblLeft">Owner To Address Gaps:<font color="red" size="1">*</font></asp:Literal></td>
                    <td valign="top"><asp:TextBox ID="txtOwnrInt"  runat="server" TextMode="MultiLine" 
                    onkeypress="return ValidText(event,this.value)" onpaste='return maxLengthPaste(this,"250");' SkinId="SkTxtAreaSkin"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                    <asp:Literal ID="Literal52" runat="server" SkinID="SklblLeft">Level to which addressed in proposal:<font color="red" size="1">*</font></asp:Literal>
                    </td>
                    <td valign="top">
                       <asp:DropDownList ID="ddLevelInt" runat="server" Width="200px"><asp:ListItem Text=""></asp:ListItem></asp:DropDownList>
                    </td>
                    <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                    <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                    <td valign="top"><asp:Literal ID="Literal53" runat="server" SkinID="SklblLeft">Review Date:<font color="red" size="1">*</font></asp:Literal></td>
                    <td  valign="top"><asp:TextBox ID="txtDateInt" runat="server" TextMode="SingleLine" Width="200px" CssClass="nex" ></asp:TextBox></td>
                </tr>
                <tr>
                    <td width="100%" colspan="6" align="center">
                        <asp:Button ID="btnAddIntegration" Text="Add" runat="server" CssClass="SkbtnSkin" 
                            onclick="btnAddIntegration_Click" OnClientClick="javascript:return userValidIntegration();"/>
                             <asp:Button id="btnClearIntegration" Text="Clear" runat="server" CssClass="SkbtnSkin" 
                             onclick="btnClearIntegration_Click"  />
                    </td>
                </tr>
                <tr>
                    <td width="100%" colspan="7" align="center">
                    <asp:Label runat="server" ID="lblgridintegrationerror" ForeColor="Red"></asp:Label>
                    <asp:GridView ID="gridintegration" runat="server" AutoGenerateColumns="False" 
                            OnRowDeleting="gridintegration_rowdeleting" 
                            onrowcancelingedit="gridintegration_RowCancelingEdit" 
                            onrowcommand="gridintegration_RowCommand" 
                            onrowediting="gridintegration_RowEditing" 
                            onrowdatabound="gridintegration_RowDataBound" >
                            <RowStyle CssClass="skGridInnerRow"/>
                            <SelectedRowStyle CssClass="skGridInnerSelectedRow" />
                            <AlternatingRowStyle CssClass="skGridInnerAlternatingRow" />
                            <HeaderStyle CssClass="skGridInnerHeader" />
                            <FooterStyle CssClass="skGridInnerFooter" />
                            <PagerStyle       CssClass="skGridInnerRow" />
                            <Columns>
                                <asp:TemplateField HeaderText="Edit">                                   
                                    <ItemTemplate>
                                       <asp:LinkButton ID="lnkEdit" Text="Edit" CommandName="Edit" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' runat="server"></asp:LinkButton>
                                   </ItemTemplate>
                                    <EditItemTemplate>
                                    <asp:LinkButton ID="lnkUpdate" CommandName="UpdateRow" Width="100px" Text="Update" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' runat="server"></asp:LinkButton>   
                                        &nbsp;<asp:LinkButton ID="lnkCancel" CommandName="Cancel" Text="Cancel" runat="server"></asp:LinkButton>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Remove">
                                   <ItemTemplate>
                                       <asp:LinkButton ID="lnkDeleteInteg" Text="Remove" CommandName="Delete" OnClientClick="return show_alert()" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' runat="server"></asp:LinkButton>
                                   </ItemTemplate>
                                </asp:TemplateField>  
                               <asp:TemplateField HeaderText="Key Client Requirement">
                                   <ItemTemplate>
                                        <%#Eval("keyclientrequirement")%>
                                   </ItemTemplate>
                                   <ItemStyle CssClass="itemstyle"/>
                                   <EditItemTemplate>
                                        <asp:TextBox id="txtEditKey" Runat="Server" Text='<%# Eval("keyclientrequirement") %>'/>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Impacting which part of Proposal">
                                   <ItemTemplate>
                                        <%#Eval("impactonwhichpart")%>
                                   </ItemTemplate>
                                   <ItemStyle CssClass="itemstyle"/>
                                   <EditItemTemplate>
                                        <asp:TextBox id="txtEditImpact" Runat="Server"  Text='<%# Eval("impactonwhichpart") %>'/>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Gaps/Improvement Area">
                                   <ItemTemplate>
                                        <%#Eval("improvementarea")%>
                                   </ItemTemplate>
                                   <ItemStyle CssClass="itemstyle"/>
                                   <EditItemTemplate>
                                        <asp:TextBox id="txtEditGaps" Runat="Server"  Text='<%# Eval("improvementarea") %>'/>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Owner to address gaps">
                                   <ItemTemplate>
                                        <%#Eval("ownertoaddressarea")%>
                                   </ItemTemplate>
                                   <ItemStyle CssClass="itemstyle"/>
                                   <EditItemTemplate>
                                        <asp:TextBox id="txtEditOwner" Runat="Server"  Text='<%# Eval("ownertoaddressarea") %>'/>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Level to which addressed in proposal" ItemStyle-Wrap="true" ControlStyle-Width="170px">
                                   <ItemTemplate>
                                        <%#Eval("level")%>
                                   </ItemTemplate>
                                   <ItemStyle CssClass="itemstyle"/>
                                   <EditItemTemplate>
                                        <asp:DropDownList id="ddlEditIntegrationLevel" AppendDataBoundItems="true" Runat="Server">
                                         
                                         </asp:DropDownList>
                                    </EditItemTemplate>

<ControlStyle Width="170px"></ControlStyle>

<ItemStyle Wrap="True"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Review Date">
                                   <ItemTemplate>
                                        <%#Eval("reviewdate","{0:MM-dd-yy}")%>
                                   </ItemTemplate>
                                   <EditItemTemplate>
                                       <asp:TextBox id="txtEditReview" Runat="Server" Text='<%#Bind("reviewdate","{0:MM-dd-yy}") %>'  TextMode="SingleLine" Width="160px" CssClass="nex"/>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                
                            </Columns>
                        </asp:GridView>
                        </td>
                        
                </tr>
                <tr>
                    <td>
                        
                    </td>
                </tr>
                <tr>
                    <td>
                        <%--<asp:Button ID="btnSaveInt" Text="Save" runat="server" BackColor="#003399" ForeColor="White" 
                            Width="120px" onclick="btnSaveInt_Click" />--%>
                            &nbsp;&nbsp;&nbsp;
                        </td>
                </tr>
               </table>
            </div>
            <h3 id="hfin">Final RGY Score</h3>
            <div id="divfin" >
                <table border="1">
                    <tr>
                        <td width="100%" style="width:1100px; font-weight: bold; font-size: medium;" colspan="2" align="center" >
                            Final RGY Score
                        </td>
                    </tr>
                    <tr>
                        <td style="background-color: #009933" >
                            For RGY score > 70%, the response is Rigorous, Relevant and Believable.
Indicates high chances of winning.
                        </td>
                        <td rowspan="3" style="font-size: large; font-weight: bold" bgcolor="#CCCCCC">
                            <asp:Label runat="server" ID="finallbl"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="background-color: #FFFF00" >
                            When 50 < RGY score < 70, the Cogency of Response is medium with even chances of winning
                        </td>
                    </tr>
                    <tr>
                        <td style="background-color: #FF0000" >
                            When RGY Score < 50, the Cogency of Response is low with slim chances of winning.
                        </td>
                    </tr>
                    
                </table>
                <table>
                    <tr>
                        <td>
                            <span></span>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <span></span>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <span></span>
                        </td>
                    </tr>
                    
                    <tr>
                        <td>
                            <span>
                                <br />
                                <br />
                            </span>
                        </td>
                    </tr>
                    <tr>
                    <td>
                    <table border="1" style="border-color:Black; color:Black;" >
                        <tr>
                            <td style="background-color: #999999; border-color:Black " >
                            Qualitiy of Response
                            </td>
                        </tr>
                        <tr>
                            <td style="background-color:Red ;border-color:Black">
                            Null-Red-Bad
                            </td>
                        </tr>
                        <tr>
                            <td style="background-color:Yellow;border-color:Black">
                            1-3- Yellow Needs Improvement
                            </td>
                        </tr>
                        <tr>
                            <td style="background-color:Green;border-color:Black">
                                4-5- Green- Good To Go
                            </td>
                        </tr>
                       </table> 
                       </td>
                    </tr>
                </table>
            </div>
       </div>
       <table>
        <tr>
            <td>
                <br />
            </td>
        </tr>
       </table> 
       <table align="center" >
       <tr>
                    <td width="30%">
                    </td>
                        <td>
                           <asp:Label runat="server" ID="lblapproval" Text="Approval:" SkinID="SklblLeft"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlapproval" runat="server" 
                                onselectedindexchanged="ddlapproval_SelectedIndexChanged" 
                                AutoPostBack="true" CausesValidation="True">
                                <asp:ListItem Value="0" Text=""></asp:ListItem>
                                <asp:ListItem Value="1" Text="Approved"></asp:ListItem>
                                <asp:ListItem Value="2" Text="Not Approved"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td   >
                            <asp:label runat="server" ID="lblcomments"  SkinID="SklblLeft">Comments for Non-Approval:</asp:label>
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtcomments" TextMode="MultiLine" ></asp:TextBox>
                          
                        </td>
                    </tr>
                    </table>
                    <table>
        <tr>
            <td>
                <br />
            </td>
        </tr>
       </table> 
                    <table>
                       <tr>
                        <td colspan="3" align="center">
                            <asp:Button ID="btnLastSave" Text="Save" runat="server" CssClass="SkbtnSkin" 
                            onclick="btnLastSave_Click" OnClientClick="return checkRGYtype()"  />     
                        </td>
                        <td>
                            <span></span>
                        </td>
                        <td>
                            <asp:Button ID="btnLastClear" Text="Clear" runat="server" CssClass="SkbtnSkin" 
                             onclick="btnLastClear_Click" />
                        </td>
                        <td>
                            <span></span>
                        </td>
                        <td>
                            <asp:Button ID="btnSubmit" Text="Submit" runat="server" CssClass="SkbtnSkin" 
                             onclick="btnSubmit_Click" OnClientClick="return show_submit_alert()" CausesValidation="true"  />
                        </td>
                    </tr>  
                    </table>
                    <table>
        <tr>
            <td>
                <br />
            </td>
        </tr>
       </table> 
      </div>
    <ajax:ModalPopupExtender runat="server" ID="guidlinespopup" PopupControlID="guidlinespanel"
        TargetControlID="lnkguidlines" BackgroundCssClass="modalBackground" CancelControlID="btnhtmcancel"></ajax:ModalPopupExtender>
    <asp:Panel runat="server" ID="guidlinespanel" class="modalPopup">
        <div id="div2" class="modalPopup" >
            <h3 align="center" style="color: Blue">
                Guidelines &nbsp;&nbsp;&nbsp;</h3>
            <div id="divguidlines" align="left" style="width: 100%; height: 65%">
                <table width="100%">
                    <tr style="width:100%">
                        <td style="width:100%">
                            <h5><font style="color:Green">Description for RGY Score</font></h5>
                                RGY score stands for <b>‘Cogency of Response’</b> this response is complete w.r.t Key Client requirements<br />
                                Conforms to Syntel Standards of Disclosure and Presentation<br />
                                It does not include Uniqueness of Solution or Commercials<br />
                                Key Client Requirement Should be aligned to WIN Theme.SLA for Platinum/Gold deals<h5 style="color:Green">Output for Typical RFP timeframe of Platinum/Gold deals</h5>
                                Output of <b>Bid qualification</b> and <b>Bid/No Bid Decision</b> for Typical RFP timeframe(1 weeks) is T+1<br />
                                Output of <b>Synthesis of Customer requirements</b> for Typical RFP timeframe(1 weeks)is T+2<br />
                                Output of <b>High-level win strategy</b> for Typical RFP timeframe(1 weeks) is T+3<br />
                                Output of <b>Budgeting,bid team composition and work plan</b> for Typical RFP timeframe(1 weeks) is T+4<br />
                                Output of <b>Sign-off win strategy,proposal approach/Draft executive summary + business case(incl.Blue Review)</b> for Typical RFP timeframe(1 weeks) is T+5<br />
                                Output of <b>Technical & Commercial Solution by Tower & Integration</b> for Typical RFP timeframe(2-4 weeks) is T+8<br />
                                Output of <b>Customer/Advisor workshops(MVD,yellow pad etc.)</b> for Typical RFP timeframe(2-4 weeks) is linked to client/advisor schedule<br />
                                Output of <b>First draft of integrated solution/proposal(incl.internal review)</b> for Typical RFP timeframe(2-4 weeks) is T+10<br />
                                Output of <b>Near-final version of solution/proposal</b> for Typical RFP timeframe(2-4 weeks) is D-5<br />
                                Output of <b>Red review complete</b> for Typical RFP timeframe(2-4 weeks) is D-4<br />
                                Output of <b>RFP document finalized and submitted</b> for Typical RFP timeframe(2-4 weeks) is D
                           </td>
                        </tr>
                        <tr>
                        <td>
                            <br />
                        </td>
                            
                        </tr>
                        <tr>
                        <td>
                            <br />
                        </td>
                            
                        </tr>
                        <tr>
                             <td align="center">
                               <%-- <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="div" />--%>
                                <input type="button" id="btnhtmcancel" value="Cancel"  Class="div"/>
                             </td>
                        </tr>
                </table>
            </div>
        </div>

    </asp:Panel>
</asp:Content>
