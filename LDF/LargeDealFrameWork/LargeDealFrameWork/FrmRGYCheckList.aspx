<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPages/Admin.Master" AutoEventWireup="true" CodeBehind="FrmRGYCheckList.aspx.cs" Inherits="LargeDealFrameWork.AdminPages.RGYCheckList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
<link rel="stylesheet" href="Styles/IS.css" />
 <script src="<%= ResolveUrl ("~/Scripts/UserValidation.js") %>" ></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <table >
        <tr>
            <td style="color:Black; font-size:small; font-weight:bold;" align="center">Scale Setting
            </td>        
        </tr>
        <tr>
            <td align="center">
                <asp:GridView ID="gvRGYCheckListScale" DataKeyNames="IpkScaleId" runat="server" 
                    AutoGenerateColumns="False" 
                    onrowcancelingedit="gvRGYCheckListScale_RowCancelingEdit" 
                    onrowediting="gvRGYCheckListScale_RowEditing" 
                    onrowupdating="gvRGYCheckListScale_RowUpdating"> 
                    <HeaderStyle CssClass="skGridInnerHeader"/>
            <RowStyle  CssClass="skGridInnerRow"/>
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
               
                <asp:GridView ID="gvRGYWeightage"  runat="server" 
                    AutoGenerateColumns="false" 
                    onrowediting="gvRGYWeightage_RowEditing" 
                    onrowcancelingedit="gvRGYWeightage_RowCancelingEdit"
                    onrowupdating="gvRGYWeightage_RowUpdating"           
                    >
                    <HeaderStyle CssClass="skGridInnerHeader"/>
            <RowStyle  CssClass="skGridInnerRow"/>
            <SelectedRowStyle CssClass="skGridInnerSelectedRow" /> 
<AlternatingRowStyle CssClass="skGridInnerAlternatingRow" /> 
<HeaderStyle CssClass="skGridInnerHeader" /> 
<FooterStyle CssClass="skGridInnerFooter" /> 
                    <Columns>
                        <asp:TemplateField><EditItemTemplate><asp:LinkButton ID="lbUpdate" runat="server" 
                            CommandName="Update" ToolTip="Update" Height="20px" Width="43px" 
                            ValidationGroup="NumericValueOnly" OnClientClick="return Calculate()">Update</asp:LinkButton><asp:LinkButton ID="lbCancel" runat="server"  CommandName="Cancel" ToolTip="Cancel" Height="20px" Width="43px">Cancel</asp:LinkButton></EditItemTemplate><ItemTemplate><asp:LinkButton ID="lbEdit" runat="server" CommandName="Edit" ToolTip="Edit" Height="20px" Width="43px">Edit</asp:LinkButton></ItemTemplate></asp:TemplateField> 
                        <asp:TemplateField HeaderText="Business Solutions">
                            <EditItemTemplate>
                            <asp:TextBox ID="txtValuebus" Width="30px" runat="server" 
                            Text='<%#Eval("[Business Solution]") %>' 
                            ValidationGroup="NumericValueOnly" onkeypress="return IsNumeric(event);" ondrop="return false;" onpaste="return false;" />
                            </EditItemTemplate>
                            <ItemTemplate><asp:Label ID="lblValuebus" runat="server" Text='<%#Eval("[Business Solution]") %>'/></ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Technical Solution">
                            <EditItemTemplate>
                            <asp:TextBox ID="txtValuetech" Width="30px" runat="server" 
                            Text='<%#Eval("[Technical Solution]") %>' 
                            ValidationGroup="NumericValueOnly" onkeypress="return IsNumeric(event);" ondrop="return false;" onpaste="return false;" />
                            </EditItemTemplate>
                            <ItemTemplate><asp:Label ID="lblValuetech" runat="server" Text='<%#Eval("[Technical Solution]") %>'/></ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Service Delivery Model">
                            <EditItemTemplate>
                            <asp:TextBox ID="txtValueser" Width="30px" runat="server" 
                            Text='<%#Eval("[Service Delivery Model]") %>' 
                            ValidationGroup="NumericValueOnly" onkeypress="return IsNumeric(event);" ondrop="return false;" onpaste="return false;" />
                            </EditItemTemplate>
                            <ItemTemplate><asp:Label ID="lblValueser" runat="server" Text='<%#Eval("[Service Delivery Model]") %>'/></ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Transition Planning">
                            <EditItemTemplate>
                            <asp:TextBox ID="txtValuetrans" Width="30px" runat="server" 
                            Text='<%#Eval("[Transition Planning]") %>' 
                            ValidationGroup="NumericValueOnly" onkeypress="return IsNumeric(event);" ondrop="return false;" onpaste="return false;" />
                            </EditItemTemplate>
                            <ItemTemplate><asp:Label ID="lblValuetrans" runat="server" Text='<%#Eval("[Transition Planning]") %>'/></ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Governance Engagement Model">
                            <EditItemTemplate>
                            <asp:TextBox ID="txtValuegov" Width="30px" runat="server" 
                            Text='<%#Eval("[Governance Engagement Model]") %>' 
                            ValidationGroup="NumericValueOnly" onkeypress="return IsNumeric(event);" ondrop="return false;" onpaste="return false;" />
                            </EditItemTemplate>
                            <ItemTemplate><asp:Label ID="lblValuegov" runat="server" Text='<%#Eval("[Governance Engagement Model]") %>'/></ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Process Methodologies">
                            <EditItemTemplate>
                            <asp:TextBox ID="txtValuepro" Width="30px" runat="server" 
                            Text='<%#Eval("[Process Methodologies]") %>' 
                            ValidationGroup="NumericValueOnly" onkeypress="return IsNumeric(event);" ondrop="return false;" onpaste="return false;" />
                            </EditItemTemplate>
                            <ItemTemplate><asp:Label ID="lblValuepro" runat="server" Text='<%#Eval("[Process Methodologies]") %>'/></ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="HR and Change Management">
                            <EditItemTemplate>
                            <asp:TextBox ID="txtValuehr" Width="30px" runat="server" 
                            Text='<%#Eval("[HR and Change Management]") %>' 
                            ValidationGroup="NumericValueOnly" onkeypress="return IsNumeric(event);" ondrop="return false;" onpaste="return false;" />
                            </EditItemTemplate>
                            <ItemTemplate><asp:Label ID="lblValuehr" runat="server" Text='<%#Eval("[HR and Change Management]") %>'/></ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Commercials and Pricing">
                            <EditItemTemplate>
                            <asp:TextBox ID="txtValuecom" Width="30px" runat="server" 
                            Text='<%#Eval("[Commercilas and Pricing]") %>' 
                            ValidationGroup="NumericValueOnly" onkeypress="return IsNumeric(event);" ondrop="return false;" onpaste="return false;" />
                            </EditItemTemplate>
                            <ItemTemplate><asp:Label ID="lblValuecom" runat="server" Text='<%#Eval("[Commercilas and Pricing]") %>'/></ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Integration">
                            <EditItemTemplate>
                            <asp:TextBox ID="txtValueint" Width="30px" runat="server" 
                            Text='<%#Eval("[Integration]") %>' 
                            ValidationGroup="NumericValueOnly" onkeypress="return IsNumeric(event);" ondrop="return false;" onpaste="return false;" />
                            </EditItemTemplate>
                            <ItemTemplate><asp:Label ID="lblValueint" runat="server" Text='<%#Eval("[Integration]") %>'/></ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Total">
                            <ItemTemplate><asp:Label ID="lblValuetotal" runat="server" Text='<%#Eval("Total") %>'/></ItemTemplate>
                        </asp:TemplateField>
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
            <td style="color:Black; font-size:small; font-weight:bold;" align="center">Quality Of Response Setting
            </td>        
        </tr>
        <tr>
            <td align="center">
                 <asp:GridView ID="gvQualityOfResponse"  runat="server" DataKeyNames="IpkScaleId"
                                AutoGenerateColumns="False" 
                     onrowcancelingedit="gvQualityOfResponse_RowCancelingEdit" 
                     onrowediting="gvQualityOfResponse_RowEditing" onrowupdating="gvQualityOfResponse_RowUpdating">
                      <HeaderStyle CssClass="skGridInnerHeader"/>
            <RowStyle  CssClass="skGridInnerRow"/>
            <SelectedRowStyle CssClass="skGridInnerSelectedRow" /> 
<AlternatingRowStyle CssClass="skGridInnerAlternatingRow" /> 
<HeaderStyle CssClass="skGridInnerHeader" /> 
<FooterStyle CssClass="skGridInnerFooter" /> 
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
                <asp:Label ID="lblRGYCheckList" runat="server" Text="" ForeColor="Red"></asp:Label>                
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
            var ret = ((keyCode >= 48 && keyCode <= 57) || specialKeys.indexOf(keyCode) != -1);
            return ret;
        }
    </script>

</asp:Content>
