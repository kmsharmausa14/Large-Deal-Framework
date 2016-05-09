<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPages/Admin.Master" AutoEventWireup="true" CodeBehind="FrmOpportunityQualification.aspx.cs" Inherits="LargeDealFrameWork.AdminPages.OpportunityQualification" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
<link rel="stylesheet" href="Styles/IS.css" />
    <style type="text/css">
      .Initial
      {
            background-color: #D8E1BF;
            color: #000;
            text-align: center;
            height: 30px;
            line-height: 30px;
            margin-right: 2px;
            border-bottom-style: groove;
            
      }
      .Initial:hover
      {
            background-color: #A5B970;
            color: #fff;
      }
      .Clicked
      {
            background-color: #A5B970;
            color: #fff;
            text-align: center;
            height: 30px;
            line-height: 30px;
            margin-right: 2px;
            border-bottom-style: groove;
            
      }
      </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">  

    <table width="100%" align="center">
      <tr>
        <td align="left">
          <asp:Button Text="Account Qualification" BorderStyle="None" ID="Tab0" 
                CssClass="SkbtnSkin" runat="server" onclick="Tab0_Click" 
              />
          <asp:Button Text="Client's Demand Presence" BorderStyle="None" ID="Tab1" 
                CssClass="SkbtnSkin" runat="server" onclick="Tab1_Click"
              />
          <asp:Button Text="Syntel's Business Priority" BorderStyle="None" ID="Tab2" 
               CssClass="SkbtnSkin" runat="server" onclick="Tab2_Click"
               />
          <asp:Button Text="Client's Urgency to Buy" BorderStyle="None" ID="Tab3" 
               CssClass="SkbtnSkin" runat="server" onclick="Tab3_Click"
               />
          <asp:Button Text="Syntel's Competetive Advantage" BorderStyle="None" ID="Tab4" 
               CssClass="SkbtnSkin" runat="server" onclick="Tab4_Click"
               />
        
          <asp:MultiView ID="MainView" runat="server" ActiveViewIndex="0">
            <asp:View ID="View0" runat="server">
              <table style="width: 100%; border-width: 1px; border-color: #666; border-style: solid" align="center">
                    <tr>
                        <td style="color:Black; font-size:small; font-weight:bold;" align="center">Scale Setting
                        </td>        
                    </tr>
                    <tr>
                        <td align="center">
                            <asp:GridView ID="gvAccountQualification" DataKeyNames="IpkScaleId" runat="server" 
                                AutoGenerateColumns="False" onrowcancelingedit="gvAccountQualification_RowCancelingEdit" 
                                onrowediting="gvAccountQualification_RowEditing" onrowupdating="gvAccountQualification_RowUpdating"> 
                                 <SelectedRowStyle CssClass="skGridInnerSelectedRow" />
                                 <AlternatingRowStyle CssClass="skGridInnerAlternatingRow" />
                                 <HeaderStyle CssClass="skGridInnerHeader" />
                                 <FooterStyle CssClass="skGridInnerFooter" />
                                 <RowStyle CssClass="skGridInnerRow" />
                                <Columns> 
                                <asp:TemplateField><EditItemTemplate><asp:LinkButton ID="lbUpdate" runat="server" 
                                        CommandName="Update" ToolTip="Update" Height="20px" Width="43px" 
                                        ValidationGroup="NumericScoreValueOnly">Update</asp:LinkButton><asp:LinkButton ID="lbCancel" runat="server"  CommandName="Cancel" ToolTip="Cancel" Height="20px" Width="43px">Cancel</asp:LinkButton></EditItemTemplate><ItemTemplate><asp:LinkButton ID="lbEdit" runat="server" CommandName="Edit" ToolTip="Edit" Height="20px" Width="43px">Edit</asp:LinkButton></ItemTemplate></asp:TemplateField> 
                                <asp:TemplateField HeaderText="Description"><EditItemTemplate><asp:Label ID="lblDescription" runat="server" Text='<%#Eval("vsDesc") %>'/></EditItemTemplate><ItemTemplate><asp:Label ID="lblitemDescription" runat="server" Text='<%#Eval("vsDesc") %>'/></ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:TemplateField> 
                                <asp:TemplateField HeaderText="Approved Min Value"><EditItemTemplate><asp:Label ID="lblApprovedMinValue" runat="server" Text='<%#Eval("IAppMinVal") %>'/></EditItemTemplate><ItemTemplate><asp:Label ID="lblitemApprovedMinValue" runat="server" Text='<%#Eval("IAppMinVal") %>'/></ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField> 
                                <asp:TemplateField HeaderText="Pending Min Value"><EditItemTemplate>
                                    <asp:TextBox ID="txtMinValueScale" Width="30px" runat="server" 
                                        Text='<%#Eval("InulPendMinVal") %>' 
                                        ValidationGroup="NumericScoreValueOnly" onkeypress="return IsNumeric(event);" ondrop="return false;" onpaste="return false;" />

                                    <%--<asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="CompareValidator"></asp:CompareValidator>--%>                                    
                                    <asp:RegularExpressionValidator ID="revMinValueScore" runat="server" 
                                        ControlToValidate="txtMinValueScale" 
                                        ErrorMessage="Min Value should be numeric only." ForeColor="Red" 
                                        ValidationExpression="^[0-9]+$" ValidationGroup="NumericScoreValueOnly">*</asp:RegularExpressionValidator>
                                    </EditItemTemplate>
                                    <ItemTemplate><asp:Label ID="lblMinValue" runat="server" Text='<%#Eval("InulPendMinVal") %>'/></ItemTemplate>
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Approved Max Value"><EditItemTemplate><asp:Label ID="lblApprovedMaxValue" runat="server" Text='<%#Eval("IAppMaxVal") %>'/></EditItemTemplate><ItemTemplate><asp:Label ID="lblitemApprovedMaxValue" runat="server" Text='<%#Eval("IAppMaxVal") %>'/></ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField> 
                                <asp:TemplateField HeaderText="Pending Max Value">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtMaxValueScale" Width="30px" runat="server" Text='<%#Eval("InulPendMaxVal") %>' ValidationGroup="NumericScoreValueOnly" onkeypress="return IsNumeric(event);" ondrop="return false;" onpaste="return false;"/>                                    
                                    <asp:RegularExpressionValidator ID="revMaxValueScore" runat="server" 
                                        ControlToValidate="txtMaxValueScale" 
                                        ErrorMessage="Min Value should be numeric only." ForeColor="Red" 
                                        ValidationExpression="^[0-9]+$" ValidationGroup="NumericScoreValueOnly">*</asp:RegularExpressionValidator>
                                    </EditItemTemplate><ItemTemplate><asp:Label ID="lblMaxValue" runat="server" Text='<%#Eval("InulPendMaxVal") %>'/></ItemTemplate>
                                </asp:TemplateField> 
                                <asp:TemplateField HeaderText="Pending Date"><EditItemTemplate><asp:Label ID="lblPendingDate" runat="server" Text='<%#Eval("dtnulPendDt") %>'/></EditItemTemplate><ItemTemplate><asp:Label ID="lblitemPendingDate" runat="server" Text='<%#Eval("dtnulPendDt") %>'/></ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField> 
                                </Columns> 
                                
                            </asp:GridView>
                        </td>        
                    </tr>                                      
                    <tr>
                        <td align="center"> 
                            <asp:Label ID="lblAccountQualification" runat="server" Text="" ForeColor="Red"></asp:Label>                
                        </td>
                    </tr>
                    <tr>
                        <td> 
                            <br />
                        </td>
                    </tr> 
                </table>  
            </asp:View>
            <asp:View ID="View1" runat="server">
              <table style="width: 100%; border-width: 1px; border-color: #666; border-style: solid" align="center">
                    <tr>
                        <td style="color:Black; font-size:small; font-weight:bold;" align="center">Score Setting
                        </td>        
                    </tr>
                    <tr>
                        <td align="center">
                            <asp:GridView ID="gvClientDemandPresale" DataKeyNames="IpkScoreId" runat="server" 
                                AutoGenerateColumns="False" onrowcancelingedit="gvClientDemandPresale_RowCancelingEdit"          
                                onrowediting="gvClientDemandPresale_RowEditing"        
                                onrowupdating="gvClientDemandPresale_RowUpdating"> 
                                  <SelectedRowStyle CssClass="skGridInnerSelectedRow" />
                                 <AlternatingRowStyle CssClass="skGridInnerAlternatingRow" />
                                 <HeaderStyle CssClass="skGridInnerHeader" />
                                 <FooterStyle CssClass="skGridInnerFooter" />
                                 <RowStyle CssClass="skGridInnerRow" />
                                <Columns> 
                                <asp:TemplateField><EditItemTemplate><asp:LinkButton ID="lbUpdate" runat="server" 
                                        CommandName="Update" ToolTip="Update" Height="20px" Width="43px" 
                                        ValidationGroup="NumericScoreValueOnly">Update</asp:LinkButton><asp:LinkButton ID="lbCancel" runat="server"  CommandName="Cancel" ToolTip="Cancel" Height="20px" Width="43px">Cancel</asp:LinkButton></EditItemTemplate><ItemTemplate><asp:LinkButton ID="lbEdit" runat="server" CommandName="Edit" ToolTip="Edit" Height="20px" Width="43px">Edit</asp:LinkButton></ItemTemplate></asp:TemplateField> 
                                <asp:TemplateField HeaderText="Title"><EditItemTemplate><asp:Label ID="lblTitle" runat="server" Text='<%#Eval("vsTitle") %>'/></EditItemTemplate><ItemTemplate><asp:Label ID="lblitemTitle" runat="server" Text='<%#Eval("vsTitle") %>'/></ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" />
                                    </asp:TemplateField> 
                                <asp:TemplateField HeaderText="Min Value"><EditItemTemplate>
                                    <asp:TextBox ID="txtMinValueScore" Width="30px" runat="server" 
                                        Text='<%#Eval("IMinVal") %>' 
                                        ValidationGroup="NumericScoreValueOnly" onkeypress="return IsNumeric(event);" ondrop="return false;" onpaste="return false;" />

                                    <%--<asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="CompareValidator"></asp:CompareValidator>--%>

                                    <asp:RequiredFieldValidator ID="rfvMinValueScore" runat="server"
                                        ControlToValidate="txtMinValueScore"  ForeColor="Red"
                                        ErrorMessage="Please Enter Min Value." ValidationGroup="NumericScoreValueOnly">*</asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="revMinValueScore" runat="server" 
                                        ControlToValidate="txtMinValueScore" 
                                        ErrorMessage="Min Value should be numeric only." ForeColor="Red" 
                                        ValidationExpression="^[0-9]+$" ValidationGroup="NumericScoreValueOnly">*</asp:RegularExpressionValidator>
                                    </EditItemTemplate>
                                    <ItemTemplate><asp:Label ID="lblMinValue" runat="server" Text='<%#Eval("IMinVal") %>'/></ItemTemplate></asp:TemplateField> 
                                <asp:TemplateField HeaderText="Max Value">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtMaxValueScore" Width="30px" runat="server" Text='<%#Eval("IMaxVal") %>' ValidationGroup="NumericScoreValueOnly" onkeypress="return IsNumeric(event);" ondrop="return false;" onpaste="return false;"/>
                                    <asp:RequiredFieldValidator ID="rfvMaxValueScore" runat="server"
                                        ControlToValidate="txtMaxValueScore"  ForeColor="Red"
                                        ErrorMessage="Please Enter Max Value." ValidationGroup="NumericScoreValueOnly">*</asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="revMaxValueScore" runat="server" 
                                        ControlToValidate="txtMaxValueScore" 
                                        ErrorMessage="Min Value should be numeric only." ForeColor="Red" 
                                        ValidationExpression="^[0-9]+$" ValidationGroup="NumericScoreValueOnly">*</asp:RegularExpressionValidator>
                                    </EditItemTemplate><ItemTemplate><asp:Label ID="lblMaxValue" runat="server" Text='<%#Eval("IMaxVal") %>'/></ItemTemplate></asp:TemplateField> 
                                </Columns> 
                               
                            </asp:GridView>
                        </td>        
                    </tr>
                    <tr>
                        <td>
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td style="color:Black; font-size:small; font-weight:bold;" align="center">Scale Setting
                        </td>        
                    </tr>
                    <tr>
                        <td align="center">
                            <asp:GridView ID="gvClientDemandPresaleScale" DataKeyNames="IpkScaleId" runat="server" 
                                AutoGenerateColumns="false" onrowcancelingedit="gvClientDemandPresaleScale_RowCancelingEdit" 
                                onrowediting="gvClientDemandPresaleScale_RowEditing" onrowupdating="gvClientDemandPresaleScale_RowUpdating"> 
                                  <SelectedRowStyle CssClass="skGridInnerSelectedRow" />
                                 <AlternatingRowStyle CssClass="skGridInnerAlternatingRow" />
                                 <HeaderStyle CssClass="skGridInnerHeader" />
                                 <FooterStyle CssClass="skGridInnerFooter" />
                                 <RowStyle CssClass="skGridInnerRow" />
                                <Columns> 
                                <asp:TemplateField><EditItemTemplate><asp:LinkButton ID="lbUpdate" runat="server" 
                                        CommandName="Update" ToolTip="Update" Height="20px" Width="43px" 
                                        ValidationGroup="NumericScaleValueOnly">Update</asp:LinkButton><asp:LinkButton ID="lbCancel" runat="server"  CommandName="Cancel" ToolTip="Cancel" Height="20px" Width="43px">Cancel</asp:LinkButton></EditItemTemplate><ItemTemplate><asp:LinkButton ID="lbEdit" runat="server" CommandName="Edit" ToolTip="Edit" Height="20px" Width="43px">Edit</asp:LinkButton></ItemTemplate></asp:TemplateField> 
                                <asp:TemplateField HeaderText="Description"><EditItemTemplate><asp:Label ID="lblDescription" runat="server" Text='<%#Eval("vsDesc") %>'/></EditItemTemplate><ItemTemplate><asp:Label ID="lblitemDescription" runat="server" Text='<%#Eval("vsDesc") %>'/></ItemTemplate><ItemStyle HorizontalAlign="Left" /></asp:TemplateField> 
                                <asp:TemplateField HeaderText="Min Value"><EditItemTemplate>
                                    <asp:TextBox ID="txtMinValueScale" Width="30px" runat="server" 
                                        Text='<%#Eval("IMinVal") %>' 
                                        ValidationGroup="NumericScaleValueOnly" onkeypress="return IsNumeric(event);" ondrop="return false;" onpaste="return false;"/>
                                    <asp:RequiredFieldValidator ID="rfvMinValueScale" runat="server"
                                        ControlToValidate="txtMinValueScale"  ForeColor="Red"
                                        ErrorMessage="Please Enter Min Value." ValidationGroup="NumericScaleValueOnly">*</asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="revMinValueScale" runat="server" 
                                        ControlToValidate="txtMinValueScale" 
                                        ErrorMessage="Min Value should be numeric only." ForeColor="Red" 
                                        ValidationExpression="^[0-9]+$" ValidationGroup="NumericScaleValueOnly">*</asp:RegularExpressionValidator>
                                    </EditItemTemplate>
                                    <ItemTemplate><asp:Label ID="lblMinValue" runat="server" Text='<%#Eval("IMinVal") %>'/></ItemTemplate></asp:TemplateField> 
                                <asp:TemplateField HeaderText="Max Value">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtMaxValueScale" Width="30px" runat="server" Text='<%#Eval("IMaxVal") %>' ValidationGroup="NumericScaleValueOnly" onkeypress="return IsNumeric(event);" ondrop="return false;" onpaste="return false;"/>
                                    <asp:RequiredFieldValidator ID="rfvMaxValueScale" runat="server"
                                        ControlToValidate="txtMaxValueScale"  ForeColor="Red"
                                        ErrorMessage="Please Enter Max Value." ValidationGroup="NumericScaleValueOnly">*</asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="revMaxValueScale" runat="server" 
                                        ControlToValidate="txtMaxValueScale" 
                                        ErrorMessage="Min Value should be numeric only." ForeColor="Red" 
                                        ValidationExpression="^[0-9]+$" ValidationGroup="NumericScaleValueOnly">*</asp:RegularExpressionValidator>
                                    </EditItemTemplate><ItemTemplate><asp:Label ID="lblMaxValue" runat="server" Text='<%#Eval("IMaxVal") %>'/></ItemTemplate></asp:TemplateField> 
                                </Columns> 
                            </asp:GridView>
                        </td>        
                    </tr>
                    <tr>
                        <td align="center"> 
                            <asp:Label ID="lblClientDemandPresale" runat="server" Text="" ForeColor="Red"></asp:Label>                
                        </td>
                    </tr>
                    <tr>
                        <td> 
                            <br />
                        </td>
                    </tr> 
                </table>  
            </asp:View>
            <asp:View ID="View2" runat="server">
              <table style="width: 100%; border-width: 1px; border-color: #666; border-style: solid" align="center">
                    <tr>
                        <td style="color:Black; font-size:small; font-weight:bold;" align="center">Score Setting
                        </td>        
                    </tr>
                    <tr>
                        <td align="center">
                            <asp:GridView ID="gvSyntelBusinessScore" DataKeyNames="IpkScoreId" runat="server" 
                                AutoGenerateColumns="false" onrowcancelingedit="gvSyntelBusinessScore_RowCancelingEdit" 
                                onrowediting="gvSyntelBusinessScore_RowEditing" onrowupdating="gvSyntelBusinessScore_RowUpdating" 
                                > 
                                  <SelectedRowStyle CssClass="skGridInnerSelectedRow" />
                                 <AlternatingRowStyle CssClass="skGridInnerAlternatingRow" />
                                 <HeaderStyle CssClass="skGridInnerHeader" />
                                 <FooterStyle CssClass="skGridInnerFooter" />
                                 <RowStyle CssClass="skGridInnerRow" />
                                <Columns> 
                                <asp:TemplateField><EditItemTemplate><asp:LinkButton ID="lbUpdate" runat="server" 
                                        CommandName="Update" ToolTip="Update" Height="20px" Width="43px" 
                                        ValidationGroup="NumericScoreValueOnly">Update</asp:LinkButton><asp:LinkButton ID="lbCancel" runat="server"  CommandName="Cancel" ToolTip="Cancel" Height="20px" Width="43px">Cancel</asp:LinkButton></EditItemTemplate><ItemTemplate><asp:LinkButton ID="lbEdit" runat="server" CommandName="Edit" ToolTip="Edit" Height="20px" Width="43px">Edit</asp:LinkButton></ItemTemplate></asp:TemplateField> 
                                <asp:TemplateField HeaderText="Title"><EditItemTemplate><asp:Label ID="lblTitle" runat="server" Text='<%#Eval("vsTitle") %>'/></EditItemTemplate><ItemTemplate><asp:Label ID="lblitemTitle" runat="server" Text='<%#Eval("vsTitle") %>'/></ItemTemplate><ItemStyle HorizontalAlign="Left" /></asp:TemplateField> 
                                <asp:TemplateField HeaderText="Min Value"><EditItemTemplate>
                                    <asp:TextBox ID="txtMinValueScore" Width="30px" runat="server" 
                                        Text='<%#Eval("IMinVal") %>' 
                                        ValidationGroup="NumericScoreValueOnly" onkeypress="return IsNumeric(event);" ondrop="return false;" onpaste="return false;"/>
                                    <asp:RequiredFieldValidator ID="rfvMinValueScore" runat="server"
                                        ControlToValidate="txtMinValueScore"  ForeColor="Red"
                                        ErrorMessage="Please Enter Min Value." ValidationGroup="NumericScoreValueOnly">*</asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="revMinValueScore" runat="server" 
                                        ControlToValidate="txtMinValueScore" 
                                        ErrorMessage="Min Value should be numeric only." ForeColor="Red" 
                                        ValidationExpression="^[0-9]+$" ValidationGroup="NumericScoreValueOnly">*</asp:RegularExpressionValidator>
                                    </EditItemTemplate>
                                    <ItemTemplate><asp:Label ID="lblMinValue" runat="server" Text='<%#Eval("IMinVal") %>'/></ItemTemplate></asp:TemplateField> 
                                <asp:TemplateField HeaderText="Max Value">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtMaxValueScore" Width="30px" runat="server" Text='<%#Eval("IMaxVal") %>' ValidationGroup="NumericScoreValueOnly" onkeypress="return IsNumeric(event);" ondrop="return false;" onpaste="return false;"/>
                                    <asp:RequiredFieldValidator ID="rfvMaxValueScore" runat="server"
                                        ControlToValidate="txtMaxValueScore"  ForeColor="Red"
                                        ErrorMessage="Please Enter Max Value." ValidationGroup="NumericScoreValueOnly">*</asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="revMaxValueScore" runat="server" 
                                        ControlToValidate="txtMaxValueScore" 
                                        ErrorMessage="Min Value should be numeric only." ForeColor="Red" 
                                        ValidationExpression="^[0-9]+$" ValidationGroup="NumericScoreValueOnly">*</asp:RegularExpressionValidator>
                                    </EditItemTemplate><ItemTemplate><asp:Label ID="lblMaxValue" runat="server" Text='<%#Eval("IMaxVal") %>'/></ItemTemplate></asp:TemplateField> 
                                </Columns> 
                            </asp:GridView>
                        </td>        
                    </tr>
                    <tr>
                        <td>
                            <br />
                        </td>        
                    </tr>
                    <tr>
                        <td style="color:Black; font-size:small; font-weight:bold;" align="center">Scale Setting
                        </td>        
                    </tr>
                    <tr>
                        <td align="center">
                            <asp:GridView ID="gvSyntelBusinessScale" DataKeyNames="IpkScaleId" runat="server" 
                                AutoGenerateColumns="false" onrowcancelingedit="gvSyntelBusinessScale_RowCancelingEdit" 
                                onrowediting="gvSyntelBusinessScale_RowEditing" onrowupdating="gvSyntelBusinessScale_RowUpdating"> 
                                  <SelectedRowStyle CssClass="skGridInnerSelectedRow" />
                                 <AlternatingRowStyle CssClass="skGridInnerAlternatingRow" />
                                 <HeaderStyle CssClass="skGridInnerHeader" />
                                 <FooterStyle CssClass="skGridInnerFooter" />
                                 <RowStyle CssClass="skGridInnerRow" />
                                <Columns> 
                                <asp:TemplateField><EditItemTemplate><asp:LinkButton ID="lbUpdate" runat="server" 
                                        CommandName="Update" ToolTip="Update" Height="20px" Width="43px" 
                                        ValidationGroup="NumericScaleValueOnly">Update</asp:LinkButton><asp:LinkButton ID="lbCancel" runat="server"  CommandName="Cancel" ToolTip="Cancel" Height="20px" Width="43px">Cancel</asp:LinkButton></EditItemTemplate><ItemTemplate><asp:LinkButton ID="lbEdit" runat="server" CommandName="Edit" ToolTip="Edit" Height="20px" Width="43px">Edit</asp:LinkButton></ItemTemplate></asp:TemplateField> 
                                <asp:TemplateField HeaderText="Description"><EditItemTemplate><asp:Label ID="lblDescription" runat="server" Text='<%#Eval("vsDesc") %>'/></EditItemTemplate><ItemTemplate><asp:Label ID="lblitemDescription" runat="server" Text='<%#Eval("vsDesc") %>'/></ItemTemplate><ItemStyle HorizontalAlign="Left" /></asp:TemplateField> 
                                <asp:TemplateField HeaderText="Min Value"><EditItemTemplate>
                                    <asp:TextBox ID="txtMinValueScale" Width="30px" runat="server" 
                                        Text='<%#Eval("IMinVal") %>' 
                                        ValidationGroup="NumericScaleValueOnly" onkeypress="return IsNumeric(event);" ondrop="return false;" onpaste="return false;"/>
                                    <asp:RequiredFieldValidator ID="rfvMinValueScale" runat="server"
                                        ControlToValidate="txtMinValueScale"  ForeColor="Red"
                                        ErrorMessage="Please Enter Min Value." ValidationGroup="NumericScaleValueOnly">*</asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="revMinValueScale" runat="server" 
                                        ControlToValidate="txtMinValueScale" 
                                        ErrorMessage="Min Value should be numeric only." ForeColor="Red" 
                                        ValidationExpression="^[0-9]+$" ValidationGroup="NumericScaleValueOnly">*</asp:RegularExpressionValidator>
                                    </EditItemTemplate>
                                    <ItemTemplate><asp:Label ID="lblMinValue" runat="server" Text='<%#Eval("IMinVal") %>'/></ItemTemplate></asp:TemplateField> 
                                <asp:TemplateField HeaderText="Max Value">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtMaxValueScale" Width="30px" runat="server" Text='<%#Eval("IMaxVal") %>' ValidationGroup="NumericScaleValueOnly" onkeypress="return IsNumeric(event);" ondrop="return false;" onpaste="return false;"/>
                                    <asp:RequiredFieldValidator ID="rfvMaxValueScale" runat="server"
                                        ControlToValidate="txtMaxValueScale"  ForeColor="Red"
                                        ErrorMessage="Please Enter Max Value." ValidationGroup="NumericScaleValueOnly">*</asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="revMaxValueScale" runat="server" 
                                        ControlToValidate="txtMaxValueScale" 
                                        ErrorMessage="Min Value should be numeric only." ForeColor="Red" 
                                        ValidationExpression="^[0-9]+$" ValidationGroup="NumericScaleValueOnly">*</asp:RegularExpressionValidator>
                                    </EditItemTemplate><ItemTemplate><asp:Label ID="lblMaxValue" runat="server" Text='<%#Eval("IMaxVal") %>'/></ItemTemplate></asp:TemplateField> 
                                </Columns> 
                            </asp:GridView>
                        </td>    
                    </tr>
                    <tr>
                        <td align="center"> 
                            <asp:Label ID="lblSyntelBusiness" runat="server" Text="" ForeColor="Red"></asp:Label>                
                        </td>
                    </tr> 
                    <tr>
                        <td> 
                            <br />
                        </td>
                    </tr>                    
                </table> 
            </asp:View>
            <asp:View ID="View3" runat="server">
              <table style="width: 100%; border-width: 1px; border-color: #666; border-style: solid" align="center">
                    <tr>
                        <td style="color:Black; font-size:small; font-weight:bold;" align="center">Score Setting
                        </td>        
                    </tr>
                    <tr>
                        <td align="center">
                            <asp:GridView ID="gvClientUrgencyToBuyScore" DataKeyNames="IpkScoreId" runat="server" 
                                AutoGenerateColumns="false"  onrowcancelingedit="gvClientUrgencyToBuyScore_RowCancelingEdit" 
                                onrowediting="gvClientUrgencyToBuyScore_RowEditing" onrowupdating="gvClientUrgencyToBuyScore_RowUpdating"> 
                                  <SelectedRowStyle CssClass="skGridInnerSelectedRow" />
                                 <AlternatingRowStyle CssClass="skGridInnerAlternatingRow" />
                                 <HeaderStyle CssClass="skGridInnerHeader" />
                                 <FooterStyle CssClass="skGridInnerFooter" />
                                 <RowStyle CssClass="skGridInnerRow" />
                                <Columns> 
                                <asp:TemplateField><EditItemTemplate><asp:LinkButton ID="lbUpdate" runat="server" 
                                        CommandName="Update" ToolTip="Update" Height="20px" Width="43px" 
                                        ValidationGroup="NumericScoreValueOnly">Update</asp:LinkButton><asp:LinkButton ID="lbCancel" runat="server"  CommandName="Cancel" ToolTip="Cancel" Height="20px" Width="43px">Cancel</asp:LinkButton></EditItemTemplate><ItemTemplate><asp:LinkButton ID="lbEdit" runat="server" CommandName="Edit" ToolTip="Edit" Height="20px" Width="43px">Edit</asp:LinkButton></ItemTemplate></asp:TemplateField> 
                                <asp:TemplateField HeaderText="Title"><EditItemTemplate><asp:Label ID="lblTitle" runat="server" Text='<%#Eval("vsTitle") %>'/></EditItemTemplate><ItemTemplate><asp:Label ID="lblitemTitle" runat="server" Text='<%#Eval("vsTitle") %>'/></ItemTemplate><ItemStyle HorizontalAlign="Left" /></asp:TemplateField> 
                                <asp:TemplateField HeaderText="Min Value"><EditItemTemplate>
                                    <asp:TextBox ID="txtMinValueScore" Width="30px" runat="server" 
                                        Text='<%#Eval("IMinVal") %>' 
                                        ValidationGroup="NumericScoreValueOnly" onkeypress="return IsNumeric(event);" ondrop="return false;" onpaste="return false;"/>
                                    <asp:RequiredFieldValidator ID="rfvMinValueScore" runat="server"
                                        ControlToValidate="txtMinValueScore"  ForeColor="Red"
                                        ErrorMessage="Please Enter Min Value." ValidationGroup="NumericScoreValueOnly">*</asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="revMinValueScore" runat="server" 
                                        ControlToValidate="txtMinValueScore" 
                                        ErrorMessage="Min Value should be numeric only." ForeColor="Red" 
                                        ValidationExpression="^[0-9]+$" ValidationGroup="NumericScoreValueOnly">*</asp:RegularExpressionValidator>
                                    </EditItemTemplate>
                                    <ItemTemplate><asp:Label ID="lblMinValue" runat="server" Text='<%#Eval("IMinVal") %>'/></ItemTemplate></asp:TemplateField> 
                                <asp:TemplateField HeaderText="Max Value">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtMaxValueScore" Width="30px" runat="server" Text='<%#Eval("IMaxVal") %>' ValidationGroup="NumericScoreValueOnly" onkeypress="return IsNumeric(event);" ondrop="return false;" onpaste="return false;"/>
                                    <asp:RequiredFieldValidator ID="rfvMaxValueScore" runat="server"
                                        ControlToValidate="txtMaxValueScore"  ForeColor="Red"
                                        ErrorMessage="Please Enter Max Value." ValidationGroup="NumericScoreValueOnly">*</asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="revMaxValueScore" runat="server" 
                                        ControlToValidate="txtMaxValueScore" 
                                        ErrorMessage="Min Value should be numeric only." ForeColor="Red" 
                                        ValidationExpression="^[0-9]+$" ValidationGroup="NumericScoreValueOnly">*</asp:RegularExpressionValidator>
                                    </EditItemTemplate><ItemTemplate><asp:Label ID="lblMaxValue" runat="server" Text='<%#Eval("IMaxVal") %>'/></ItemTemplate></asp:TemplateField> 
                                </Columns> 
                            </asp:GridView>
                        </td>        
                    </tr>
                    <tr>
                        <td>
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td style="color:Black; font-size:small; font-weight:bold;" align="center">Scale Setting
                        </td>        
                    </tr>
                    <tr>
                        <td align="center">
                            <asp:GridView ID="gvClientUrgencyToBuyScale" DataKeyNames="IpkScaleId" runat="server" 
                                AutoGenerateColumns="false" onrowcancelingedit="gvClientUrgencyToBuyScale_RowCancelingEdit" 
                                onrowediting="gvClientUrgencyToBuyScale_RowEditing" onrowupdating="gvClientUrgencyToBuyScale_RowUpdating" 
                                > 
                                  <SelectedRowStyle CssClass="skGridInnerSelectedRow" />
                                 <AlternatingRowStyle CssClass="skGridInnerAlternatingRow" />
                                 <HeaderStyle CssClass="skGridInnerHeader" />
                                 <FooterStyle CssClass="skGridInnerFooter" />
                                 <RowStyle CssClass="skGridInnerRow" />
                                <Columns> 
                                <asp:TemplateField><EditItemTemplate><asp:LinkButton ID="lbUpdate" runat="server" 
                                        CommandName="Update" ToolTip="Update" Height="20px" Width="43px" 
                                        ValidationGroup="NumericScaleValueOnly">Update</asp:LinkButton><asp:LinkButton ID="lbCancel" runat="server"  CommandName="Cancel" ToolTip="Cancel" Height="20px" Width="43px">Cancel</asp:LinkButton></EditItemTemplate><ItemTemplate><asp:LinkButton ID="lbEdit" runat="server" CommandName="Edit" ToolTip="Edit" Height="20px" Width="43px">Edit</asp:LinkButton></ItemTemplate></asp:TemplateField> 
                                <asp:TemplateField HeaderText="Description"><EditItemTemplate><asp:Label ID="lblDescription" runat="server" Text='<%#Eval("vsDesc") %>'/></EditItemTemplate><ItemTemplate><asp:Label ID="lblitemDescription" runat="server" Text='<%#Eval("vsDesc") %>'/></ItemTemplate><ItemStyle HorizontalAlign="Left" /></asp:TemplateField> 
                                <asp:TemplateField HeaderText="Min Value"><EditItemTemplate>
                                    <asp:TextBox ID="txtMinValueScale" Width="30px" runat="server" 
                                        Text='<%#Eval("IMinVal") %>' 
                                        ValidationGroup="NumericScaleValueOnly" onkeypress="return IsNumeric(event);" ondrop="return false;" onpaste="return false;"/>
                                    <asp:RequiredFieldValidator ID="rfvMinValueScale" runat="server"
                                        ControlToValidate="txtMinValueScale"  ForeColor="Red"
                                        ErrorMessage="Please Enter Min Value." ValidationGroup="NumericScaleValueOnly">*</asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="revMinValueScale" runat="server" 
                                        ControlToValidate="txtMinValueScale" 
                                        ErrorMessage="Min Value should be numeric only." ForeColor="Red" 
                                        ValidationExpression="^[0-9]+$" ValidationGroup="NumericScaleValueOnly">*</asp:RegularExpressionValidator>
                                    </EditItemTemplate>
                                    <ItemTemplate><asp:Label ID="lblMinValue" runat="server" Text='<%#Eval("IMinVal") %>'/></ItemTemplate></asp:TemplateField> 
                                <asp:TemplateField HeaderText="Max Value">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtMaxValueScale" Width="30px" runat="server" Text='<%#Eval("IMaxVal") %>' ValidationGroup="NumericScaleValueOnly" onkeypress="return IsNumeric(event);" ondrop="return false;" onpaste="return false;"/>
                                    <asp:RequiredFieldValidator ID="rfvMaxValueScale" runat="server"
                                        ControlToValidate="txtMaxValueScale"  ForeColor="Red"
                                        ErrorMessage="Please Enter Max Value." ValidationGroup="NumericScaleValueOnly">*</asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="revMaxValueScale" runat="server" 
                                        ControlToValidate="txtMaxValueScale" 
                                        ErrorMessage="Min Value should be numeric only." ForeColor="Red" 
                                        ValidationExpression="^[0-9]+$" ValidationGroup="NumericScaleValueOnly">*</asp:RegularExpressionValidator>
                                    </EditItemTemplate><ItemTemplate><asp:Label ID="lblMaxValue" runat="server" Text='<%#Eval("IMaxVal") %>'/></ItemTemplate></asp:TemplateField> 
                                </Columns> 
                            </asp:GridView>
                        </td>        
                    </tr>
                    <tr>
                        <td align="center"> 
                            <asp:Label ID="lblClientUrgencyToBuy" runat="server" Text="" ForeColor="Red"></asp:Label>                
                        </td>
                    </tr>
                    <tr>
                        <td> 
                            <br />
                        </td>
                    </tr> 
                </table>
            </asp:View>
            <asp:View ID="View4" runat="server">
              <table style="width: 100%; border-width: 1px; border-color: #666; border-style: solid" align="center">
                    <tr>
                        <td style="color:Black; font-size:small; font-weight:bold;" align="center">Score Setting
                        </td>        
                    </tr>
                    <tr>
                        <td align="center">
                            <asp:GridView ID="gvSyntelCompetitiveAdvantageScore" DataKeyNames="IpkScoreId" runat="server" 
                                AutoGenerateColumns="false" onrowcancelingedit="gvSyntelCompetitiveAdvantageScore_RowCancelingEdit" 
                                onrowediting="gvSyntelCompetitiveAdvantageScore_RowEditing" onrowupdating="gvSyntelCompetitiveAdvantageScore_RowUpdating">
                                  <SelectedRowStyle CssClass="skGridInnerSelectedRow" />
                                 <AlternatingRowStyle CssClass="skGridInnerAlternatingRow" />
                                 <HeaderStyle CssClass="skGridInnerHeader" />
                                 <FooterStyle CssClass="skGridInnerFooter" />
                                 <RowStyle CssClass="skGridInnerRow" /> 
                                <Columns> 
                                <asp:TemplateField><EditItemTemplate><asp:LinkButton ID="lbUpdate" runat="server" 
                                        CommandName="Update" ToolTip="Update" Height="20px" Width="43px" 
                                        ValidationGroup="NumericScoreValueOnly">Update</asp:LinkButton><asp:LinkButton ID="lbCancel" runat="server"  CommandName="Cancel" ToolTip="Cancel" Height="20px" Width="43px">Cancel</asp:LinkButton></EditItemTemplate><ItemTemplate><asp:LinkButton ID="lbEdit" runat="server" CommandName="Edit" ToolTip="Edit" Height="20px" Width="43px">Edit</asp:LinkButton></ItemTemplate></asp:TemplateField> 
                                <asp:TemplateField HeaderText="Title"><EditItemTemplate><asp:Label ID="lblTitle" runat="server" Text='<%#Eval("vsTitle") %>' /></EditItemTemplate><ItemTemplate><asp:Label ID="lblitemTitle" runat="server" Text='<%#Eval("vsTitle") %>'/></ItemTemplate><ItemStyle HorizontalAlign="Left" /></asp:TemplateField> 
                                <asp:TemplateField HeaderText="Min Value"><EditItemTemplate>
                                    <asp:TextBox ID="txtMinValueScore" Width="30px" runat="server" 
                                        Text='<%#Eval("IMinVal") %>' 
                                        ValidationGroup="NumericScoreValueOnly" onkeypress="return IsNumeric(event);" ondrop="return false;" onpaste="return false;"/>
                                    <asp:RequiredFieldValidator ID="rfvMinValueScore" runat="server"
                                        ControlToValidate="txtMinValueScore"  ForeColor="Red"
                                        ErrorMessage="Please Enter Min Value." ValidationGroup="NumericScoreValueOnly">*</asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="revMinValueScore" runat="server" 
                                        ControlToValidate="txtMinValueScore" 
                                        ErrorMessage="Min Value should be numeric only." ForeColor="Red" 
                                        ValidationExpression="^[0-9]+$" ValidationGroup="NumericScoreValueOnly">*</asp:RegularExpressionValidator>
                                    </EditItemTemplate>
                                    <ItemTemplate><asp:Label ID="lblMinValue" runat="server" Text='<%#Eval("IMinVal") %>'/></ItemTemplate></asp:TemplateField> 
                                <asp:TemplateField HeaderText="Max Value">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtMaxValueScore" Width="30px" runat="server" Text='<%#Eval("IMaxVal") %>' ValidationGroup="NumericScoreValueOnly" onkeypress="return IsNumeric(event);" ondrop="return false;" onpaste="return false;"/>
                                    <asp:RequiredFieldValidator ID="rfvMaxValueScore" runat="server"
                                        ControlToValidate="txtMaxValueScore"  ForeColor="Red"
                                        ErrorMessage="Please Enter Max Value." ValidationGroup="NumericScoreValueOnly">*</asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="revMaxValueScore" runat="server" 
                                        ControlToValidate="txtMaxValueScore" 
                                        ErrorMessage="Min Value should be numeric only." ForeColor="Red" 
                                        ValidationExpression="^[0-9]+$" ValidationGroup="NumericScoreValueOnly">*</asp:RegularExpressionValidator>
                                    </EditItemTemplate><ItemTemplate><asp:Label ID="lblMaxValue" runat="server" Text='<%#Eval("IMaxVal") %>'/></ItemTemplate></asp:TemplateField> 
                                </Columns> 
                            </asp:GridView>
                        </td>        
                    </tr>
                    <tr>
                        <td>
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td style="color:Black; font-size:small; font-weight:bold;" align="center">Scale Setting
                        </td>        
                    </tr>
                    <tr>
                        <td align="center">
                            <asp:GridView ID="gvSyntelCompetitiveAdvantageScale" DataKeyNames="IpkScaleId" runat="server" 
                                AutoGenerateColumns="false" onrowcancelingedit="gvSyntelCompetitiveAdvantageScale_RowCancelingEdit" 
                                onrowediting="gvSyntelCompetitiveAdvantageScale_RowEditing" onrowupdating="gvSyntelCompetitiveAdvantageScale_RowUpdating"
                                >
                                  <SelectedRowStyle CssClass="skGridInnerSelectedRow" />
                                 <AlternatingRowStyle CssClass="skGridInnerAlternatingRow" />
                                 <HeaderStyle CssClass="skGridInnerHeader" />
                                 <FooterStyle CssClass="skGridInnerFooter" />
                                 <RowStyle CssClass="skGridInnerRow" /> 
                                <Columns> 
                                <asp:TemplateField><EditItemTemplate><asp:LinkButton ID="lbUpdate" runat="server" 
                                        CommandName="Update" ToolTip="Update" Height="20px" Width="43px" 
                                        ValidationGroup="NumericScaleValueOnly">Update</asp:LinkButton><asp:LinkButton ID="lbCancel" runat="server"  CommandName="Cancel" ToolTip="Cancel" Height="20px" Width="43px">Cancel</asp:LinkButton></EditItemTemplate><ItemTemplate><asp:LinkButton ID="lbEdit" runat="server" CommandName="Edit" ToolTip="Edit" Height="20px" Width="43px">Edit</asp:LinkButton></ItemTemplate></asp:TemplateField> 
                                <asp:TemplateField HeaderText="Description"><EditItemTemplate><asp:Label ID="lblDescription" runat="server" Text='<%#Eval("vsDesc") %>'/></EditItemTemplate><ItemTemplate><asp:Label ID="lblitemDescription" runat="server" Text='<%#Eval("vsDesc") %>'/></ItemTemplate><ItemStyle HorizontalAlign="Left" /></asp:TemplateField> 
                                <asp:TemplateField HeaderText="Min Value"><EditItemTemplate>
                                    <asp:TextBox ID="txtMinValueScale" Width="30px" runat="server" 
                                        Text='<%#Eval("IMinVal") %>' 
                                        ValidationGroup="NumericScaleValueOnly" onkeypress="return IsNumeric(event);" ondrop="return false;" onpaste="return false;"/>
                                    <asp:RequiredFieldValidator ID="rfvMinValueScale" runat="server"
                                        ControlToValidate="txtMinValueScale"  ForeColor="Red"
                                        ErrorMessage="Please Enter Min Value." ValidationGroup="NumericScaleValueOnly">*</asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="revMinValueScale" runat="server" 
                                        ControlToValidate="txtMinValueScale" 
                                        ErrorMessage="Min Value should be numeric only." ForeColor="Red" 
                                        ValidationExpression="^[0-9]+$" ValidationGroup="NumericScaleValueOnly">*</asp:RegularExpressionValidator>
                                    </EditItemTemplate>
                                    <ItemTemplate><asp:Label ID="lblMinValue" runat="server" Text='<%#Eval("IMinVal") %>'/></ItemTemplate></asp:TemplateField> 
                                <asp:TemplateField HeaderText="Max Value">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtMaxValueScale" Width="30px" runat="server" Text='<%#Eval("IMaxVal") %>' ValidationGroup="NumericScaleValueOnly" onkeypress="return IsNumeric(event);" ondrop="return false;" onpaste="return false;"/>
                                    <asp:RequiredFieldValidator ID="rfvMaxValueScale" runat="server"
                                        ControlToValidate="txtMaxValueScale"  ForeColor="Red"
                                        ErrorMessage="Please Enter Max Value." ValidationGroup="NumericScaleValueOnly">*</asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="revMaxValueScale" runat="server" 
                                        ControlToValidate="txtMaxValueScale" 
                                        ErrorMessage="Min Value should be numeric only." ForeColor="Red" 
                                        ValidationExpression="^[0-9]+$" ValidationGroup="NumericScaleValueOnly">*</asp:RegularExpressionValidator>
                                    </EditItemTemplate><ItemTemplate><asp:Label ID="lblMaxValue" runat="server" Text='<%#Eval("IMaxVal") %>'/></ItemTemplate></asp:TemplateField> 
                                </Columns> 
                            </asp:GridView>
                        </td>          
                    </tr>
                    <tr>
                        <td align="center"> 
                            <asp:Label ID="lblSyntelCompetitiveAdvantage" runat="server" Text="" ForeColor="Red"></asp:Label>                
                        </td>
                    </tr> 
                     <tr>
                        <td> 
                            <br />
                        </td>
                    </tr>
                </table>
            </asp:View>
          </asp:MultiView>
        </td>
      </tr>     
    </table>

    <script type="text/javascript">
        var specialKeys = new Array();
        specialKeys.push(8); //Backspace
        function IsNumeric(e) {
            var keyCode = e.which ? e.which : e.keyCode
            var ret = ((keyCode >= 48 && keyCode <= 57) || specialKeys.indexOf(keyCode) != -1);            
            return ret;
        }
    </script>
</asp:Content>
