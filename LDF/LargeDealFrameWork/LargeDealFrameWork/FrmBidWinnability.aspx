<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPages/Admin.Master" AutoEventWireup="true" CodeBehind="FrmBidWinnability.aspx.cs" Inherits="LargeDealFrameWork.AdminPages.BidWinnability" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
<link rel="stylesheet" href="Styles/IS.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table >
        <tr>
            <td style="color:Black; font-size:small; font-weight:bold;" align="center">Scale Setting
            </td>        
        </tr>
        <tr>
            <td align="center">
                <asp:GridView ID="gvBidWinabilityScale" DataKeyNames="IpkScaleId" runat="server" 
                    AutoGenerateColumns="false" CssClass="Gridview" 
                    onrowcancelingedit="gvBidWinabilityScale_RowCancelingEdit" 
                    onrowediting="gvBidWinabilityScale_RowEditing" onrowupdating="gvBidWinabilityScale_RowUpdating"                     
                    >
                    <%--HeaderStyle-BackColor="#61A6F8" 
                    HeaderStyle-Font-Bold="true" 
                    HeaderStyle-ForeColor="White" --%>
                    <RowStyle CssClass="skGridInnerRow" />
                    <SelectedRowStyle CssClass="skGridInnerSelectedRow" />
                    <AlternatingRowStyle CssClass="skGridInnerAlternatingRow" />
                    <HeaderStyle CssClass="skGridInnerHeader" />
                    <FooterStyle CssClass="skGridInnerFooter" />
                    <Columns> 
                    <asp:TemplateField><EditItemTemplate><asp:LinkButton ID="lbUpdate" runat="server" 
                            CommandName="Update" ToolTip="Update" Height="20px" Width="43px" 
                            ValidationGroup="NumericScaleValueOnly">Update</asp:LinkButton><asp:LinkButton ID="lbCancel" runat="server"  CommandName="Cancel" ToolTip="Cancel" Height="20px" Width="43px">Cancel</asp:LinkButton></EditItemTemplate><ItemTemplate><asp:LinkButton ID="lbEdit" runat="server" CommandName="Edit" ToolTip="Edit" Height="20px" Width="43px">Edit</asp:LinkButton></ItemTemplate></asp:TemplateField> 
                    <asp:TemplateField HeaderText="Description"><EditItemTemplate><asp:Label ID="lblDescription" runat="server" Text='<%#Eval("vsDesc") %>'/></EditItemTemplate><ItemTemplate><asp:Label ID="lblitemDescription" runat="server" Text='<%#Eval("vsDesc") %>'/></ItemTemplate><ItemStyle HorizontalAlign="Left" /></asp:TemplateField> 
                    <asp:TemplateField HeaderText="Min Value"><EditItemTemplate>
                        <asp:TextBox ID="txtMinValueScale" Width="30px" runat="server" 
                            Text='<%#Eval("IMinVal") %>' 
                            ValidationGroup="NumericScaleValueOnly" onkeypress="return IsNumeric(event);" ondrop="return false;" onpaste="return false;" />
                        <asp:RegularExpressionValidator ID="revMinValueScale" runat="server" 
                            ControlToValidate="txtMinValueScale" 
                            ErrorMessage="Min Value should be numeric only." ForeColor="Red" 
                            ValidationExpression="^[0-9]+$" ValidationGroup="NumericScaleValueOnly">*</asp:RegularExpressionValidator>
                        <asp:RequiredFieldValidator ID="rfvMinValueScale" runat="server"
                            ControlToValidate="txtMinValueScale"  ForeColor="Red"
                            ErrorMessage="Please Enter Min Value." ValidationGroup="NumericScaleValueOnly">*</asp:RequiredFieldValidator>
                        </EditItemTemplate>
                        <ItemTemplate><asp:Label ID="lblMinValue" runat="server" Text='<%#Eval("IMinVal") %>'/></ItemTemplate></asp:TemplateField> 
                    <asp:TemplateField HeaderText="Max Value">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtMaxValueScale" Width="30px" runat="server" Text='<%#Eval("IMaxVal") %>' ValidationGroup="NumericScaleValueOnly" onkeypress="return IsNumeric(event);" ondrop="return false;" onpaste="return false;"/>
                        <asp:RegularExpressionValidator ID="revMaxValueScale" runat="server" 
                            ControlToValidate="txtMaxValueScale" 
                            ErrorMessage="Max Value should be numeric only." ForeColor="Red" 
                            ValidationExpression="^[0-9]+$" ValidationGroup="NumericScaleValueOnly">*</asp:RegularExpressionValidator>
                        <asp:RequiredFieldValidator ID="rfvMaxValueScale" runat="server"
                            ControlToValidate="txtMaxValueScale"  ForeColor="Red"
                            ErrorMessage="Please Enter Max Value." ValidationGroup="NumericScaleValueOnly">*</asp:RequiredFieldValidator>
                        </EditItemTemplate><ItemTemplate><asp:Label ID="lblMaxValue" runat="server" Text='<%#Eval("IMaxVal") %>'/></ItemTemplate></asp:TemplateField> 
                    </Columns> 
                    <%--<HeaderStyle BackColor="#61A6F8" Font-Bold="True" ForeColor="White" />--%>
                </asp:GridView>
            </td>        
        </tr>
        <tr>
            <td>
                <br />
            </td>
        </tr>
        <tr>
            <td style="color:Black; font-size:small; font-weight:bold;" align="center">Weightage Setting
            </td>        
        </tr>
        <tr>
            <td align="center">
                <asp:GridView ID="gvBidWinWeightage" DataKeyNames="IpkWtId" runat="server" 
                    AutoGenerateColumns="false" CssClass="Gridview" 
                    onrowcancelingedit="gvBidWinWeightage_RowCancelingEdit" 
                    onrowediting="gvBidWinWeightage_RowEditing" onrowupdating="gvBidWinWeightage_RowUpdating" 
                                    
                    >
                    <RowStyle CssClass="skGridInnerRow" />
                    <SelectedRowStyle CssClass="skGridInnerSelectedRow" />
                    <AlternatingRowStyle CssClass="skGridInnerAlternatingRow" />
                    <HeaderStyle CssClass="skGridInnerHeader" />
                    <FooterStyle CssClass="skGridInnerFooter" />
                    <Columns> 
                    <asp:TemplateField><EditItemTemplate><asp:LinkButton ID="lbUpdateWeightage" runat="server" 
                            CommandName="Update" ToolTip="Update" Height="20px" Width="43px" 
                            ValidationGroup="NumericValueOnly">Update</asp:LinkButton><asp:LinkButton ID="lbCancelWeightage" runat="server"  CommandName="Cancel" ToolTip="Cancel" Height="20px" Width="43px">Cancel</asp:LinkButton></EditItemTemplate><ItemTemplate><asp:LinkButton ID="lbEditWeightage" runat="server" CommandName="Edit" ToolTip="Edit" Height="20px" Width="43px">Edit</asp:LinkButton></ItemTemplate></asp:TemplateField> 
                    <asp:TemplateField HeaderText="Description"><EditItemTemplate><asp:Label ID="lblDescriptionWeightage" runat="server" Text='<%#Eval("vsWtDesc") %>'/></EditItemTemplate><ItemTemplate><asp:Label ID="lblitemDescriptionWeightage" runat="server" Text='<%#Eval("vsWtDesc") %>'/></ItemTemplate><ItemStyle HorizontalAlign="Left" /></asp:TemplateField> 
                    <asp:TemplateField HeaderText="Approved Weightage"><EditItemTemplate><asp:Label ID="lblApprovedWeightageWeightage" runat="server" Text='<%#Eval("dAppWt") %>'/></EditItemTemplate><ItemTemplate><asp:Label ID="lblitemApprovedWeightageWeightage" runat="server" Text='<%#Eval("dAppWt") %>'/></ItemTemplate><ItemStyle HorizontalAlign="Center" /></asp:TemplateField> 
                    <asp:TemplateField HeaderText="Pending Weightage"><EditItemTemplate>
                        <asp:TextBox ID="txtValueWeightage" Width="30px" runat="server" 
                            Text='<%#Eval("dnulPendWt") %>' 
                            ValidationGroup="NumericValueOnly" onkeypress="return IsNumeric(event);" ondrop="return false;" onpaste="return false;" />
                        <asp:RegularExpressionValidator ID="revValueWeightage" runat="server" 
                            ControlToValidate="txtValueWeightage" 
                            ErrorMessage="Value should be numeric only." ForeColor="Red" 
                            ValidationExpression="^\d+(\.\d{1,2})?$" ValidationGroup="NumericValueOnly">*</asp:RegularExpressionValidator>
                        <asp:RequiredFieldValidator ID="rfvValueWeightage" runat="server"
                            ControlToValidate="txtValueWeightage"  ForeColor="Red"
                            ErrorMessage="Please Enter Value." ValidationGroup="NumericValueOnly">*</asp:RequiredFieldValidator>
                        </EditItemTemplate>
                        <ItemTemplate><asp:Label ID="lblValueWeightage" runat="server" Text='<%#Eval("dnulPendWt") %>'/></ItemTemplate>
                    </asp:TemplateField>                                         
                    <asp:TemplateField HeaderText="Pending Date"><EditItemTemplate><asp:Label ID="lblPendingDateWeightage" runat="server" Text='<%#Eval("dtnulPendDt") %>'/></EditItemTemplate><ItemTemplate><asp:Label ID="lblitemPendingDateWeightage" runat="server" Text='<%#Eval("dtnulPendDt") %>'/></ItemTemplate><ItemStyle HorizontalAlign="Left" /></asp:TemplateField> 
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
            <td style="color:Black; font-size:small; font-weight:bold;" align="center">Uniqueness Matrix
            </td>        
        </tr>
        <tr>
            <td align="center">
                <asp:GridView ID="gvBidWinUniqueness" DataKeyNames="IpkScoreID" runat="server" 
                    AutoGenerateColumns="false" CssClass="Gridview"
                    onrowcancelingedit="gvBidWinUniqueness_RowCancelingEdit" 
                    onrowediting="gvBidWinUniqueness_RowEditing" onrowupdating="gvBidWinUniqueness_RowUpdating" 
                    >
                    <RowStyle CssClass="skGridInnerRow" />
                    <SelectedRowStyle CssClass="skGridInnerSelectedRow" />
                    <AlternatingRowStyle CssClass="skGridInnerAlternatingRow" />
                    <HeaderStyle CssClass="skGridInnerHeader" />
                    <FooterStyle CssClass="skGridInnerFooter" /> 
                    <Columns> 
                    <asp:TemplateField><EditItemTemplate><asp:LinkButton ID="lbUpdateUniqueness" runat="server" 
                            CommandName="Update" ToolTip="Update" Height="20px" Width="43px" 
                            ValidationGroup="NumericValueOnly">Update</asp:LinkButton><asp:LinkButton ID="lbCancelUniqueness" runat="server"  CommandName="Cancel" ToolTip="Cancel" Height="20px" Width="43px">Cancel</asp:LinkButton></EditItemTemplate><ItemTemplate><asp:LinkButton ID="lbEditUniqueness" runat="server" CommandName="Edit" ToolTip="Edit" Height="20px" Width="43px">Edit</asp:LinkButton></ItemTemplate></asp:TemplateField>                     
                    <asp:TemplateField HeaderText="Approved Score"><EditItemTemplate><asp:Label ID="lblApprovedScoreUniqueness" runat="server" Text='<%#Eval("IAppScore") %>'/></EditItemTemplate><ItemTemplate><asp:Label ID="lblitemApprovedScoreUniqueness" runat="server" Text='<%#Eval("IAppScore") %>'/></ItemTemplate><ItemStyle HorizontalAlign="Center" /></asp:TemplateField> 
                    <asp:TemplateField HeaderText="Pending Score"><EditItemTemplate>
                        <asp:TextBox ID="txtValueUniqueness" Width="30px" runat="server" 
                            Text='<%#Eval("InulPendScore") %>' 
                            ValidationGroup="NumericValueOnly" onkeypress="return IsNumeric(event);" ondrop="return false;" onpaste="return false;" />
                        <asp:RegularExpressionValidator ID="revValue" runat="server" 
                            ControlToValidate="txtValueUniqueness" 
                            ErrorMessage="Value should be numeric only." ForeColor="Red" 
                            ValidationExpression="^\d+(\.\d{1,2})?$" ValidationGroup="NumericValueOnly">*</asp:RegularExpressionValidator>
                        <asp:RequiredFieldValidator ID="rfvValue" runat="server"
                            ControlToValidate="txtValueUniqueness"  ForeColor="Red"
                            ErrorMessage="Please Enter Value." ValidationGroup="NumericValueOnly">*</asp:RequiredFieldValidator>
                        </EditItemTemplate>
                        <ItemTemplate><asp:Label ID="lblValueUniqueness" runat="server" Text='<%#Eval("InulPendScore") %>'/></ItemTemplate>
                    </asp:TemplateField>                                         
                    <asp:TemplateField HeaderText="Pending Date"><EditItemTemplate><asp:Label ID="lblPendingDateUniqueness" runat="server" Text='<%#Eval("dtnulPendDt") %>'/></EditItemTemplate><ItemTemplate><asp:Label ID="lblitemPendingDateUniqueness" runat="server" Text='<%#Eval("dtnulPendDt") %>'/></ItemTemplate><ItemStyle HorizontalAlign="Left" /></asp:TemplateField> 
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
            <td style="color:Black; font-size:small; font-weight:bold;" align="center">Innovation Matrix
            </td>        
        </tr>
        <tr>
            <td align="center">
                <asp:GridView ID="gvBidWinInnovation" DataKeyNames="IpkScoreID" runat="server" 
                    AutoGenerateColumns="false" CssClass="Gridview"
                    onrowcancelingedit="gvBidWinInnovation_RowCancelingEdit" 
                    onrowediting="gvBidWinInnovation_RowEditing" onrowupdating="gvBidWinInnovation_RowUpdating" 
                    >
                    <RowStyle CssClass="skGridInnerRow" />
                    <SelectedRowStyle CssClass="skGridInnerSelectedRow" />
                    <AlternatingRowStyle CssClass="skGridInnerAlternatingRow" />
                    <HeaderStyle CssClass="skGridInnerHeader" />
                    <FooterStyle CssClass="skGridInnerFooter" /> 
                    <Columns> 
                    <asp:TemplateField><EditItemTemplate><asp:LinkButton ID="lbUpdateInnovation" runat="server" 
                            CommandName="Update" ToolTip="Update" Height="20px" Width="43px" 
                            ValidationGroup="NumericValueOnly">Update</asp:LinkButton><asp:LinkButton ID="lbCancelInnovation" runat="server"  CommandName="Cancel" ToolTip="Cancel" Height="20px" Width="43px">Cancel</asp:LinkButton></EditItemTemplate><ItemTemplate><asp:LinkButton ID="lbEditInnovation" runat="server" CommandName="Edit" ToolTip="Edit" Height="20px" Width="43px">Edit</asp:LinkButton></ItemTemplate></asp:TemplateField>                     
                    <asp:TemplateField HeaderText="Approved Score"><EditItemTemplate><asp:Label ID="lblApprovedScoreInnovation" runat="server" Text='<%#Eval("IAppScore") %>'/></EditItemTemplate><ItemTemplate><asp:Label ID="lblitemApprovedScoreInnovation" runat="server" Text='<%#Eval("IAppScore") %>'/></ItemTemplate><ItemStyle HorizontalAlign="Center" /></asp:TemplateField> 
                    <asp:TemplateField HeaderText="Pending Score"><EditItemTemplate>
                        <asp:TextBox ID="txtValueInnovation" Width="30px" runat="server" 
                            Text='<%#Eval("InulPendScore") %>' 
                            ValidationGroup="NumericValueOnly" onkeypress="return IsNumeric(event);" ondrop="return false;" onpaste="return false;" />
                        <asp:RegularExpressionValidator ID="revValueInnovation" runat="server" 
                            ControlToValidate="txtValueInnovation" 
                            ErrorMessage="Value should be numeric only." ForeColor="Red" 
                            ValidationExpression="^\d+(\.\d{1,2})?$" ValidationGroup="NumericValueOnly">*</asp:RegularExpressionValidator>
                        <asp:RequiredFieldValidator ID="rfvValueInnovation" runat="server"
                            ControlToValidate="txtValueInnovation"  ForeColor="Red"
                            ErrorMessage="Please Enter Value." ValidationGroup="NumericValueOnly">*</asp:RequiredFieldValidator>
                        </EditItemTemplate>
                        <ItemTemplate><asp:Label ID="lblValueInnovation" runat="server" Text='<%#Eval("InulPendScore") %>'/></ItemTemplate>
                    </asp:TemplateField>                                         
                    <asp:TemplateField HeaderText="Pending Date"><EditItemTemplate><asp:Label ID="lblPendingDateInnovation" runat="server" Text='<%#Eval("dtnulPendDt") %>'/></EditItemTemplate><ItemTemplate><asp:Label ID="lblitemPendingDateInnovation" runat="server" Text='<%#Eval("dtnulPendDt") %>'/></ItemTemplate><ItemStyle HorizontalAlign="Left" /></asp:TemplateField> 
                    </Columns> 
                </asp:GridView>
            </td>        
        </tr>
        <tr>
            <td align="center"> 
                <asp:Label ID="lblBidWinability" runat="server" Text="" ForeColor="Red"></asp:Label>                
            </td>
        </tr>
        <tr>
            <td> 
                <br />
            </td>
        </tr> 
    </table>

    <script type="text/javascript">
        var specialKeys = new Array();
        specialKeys.push(8); //Backspace
        function IsNumeric(e) {
            var keyCode = e.which ? e.which : e.keyCode
            var ret = ((keyCode >= 48 && keyCode <= 57) || (keyCode == 46) || specialKeys.indexOf(keyCode) != -1);
            return ret;
        }
    </script>

</asp:Content>
