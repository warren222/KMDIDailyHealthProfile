<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/DAILYHEALTHPROFILE/DHPmaster.Master" CodeBehind="EmployeesTable.aspx.cs" Inherits="KMDIDailyHealthProfile.DAILYHEALTHPROFILE.EmployeesTable" %>

<asp:Content ID="content1" ContentPlaceHolderID="head" runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>Employee Table</title>
</asp:Content>

<asp:Content ID="cpntent2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="well text-center">
        <h2>Employee table</h2>
    </div>
    <br />

    <div class="well">
        <span style="font-size:larger;font-weight:bold;">New employee form</span>
        <div class="row">
            <div class="col-sm-3">
                <span>Surname:</span>
                <asp:TextBox ID="tboxsurname" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="col-sm-3">
                <span>First name:</span>
                <asp:TextBox ID="tboxfirstname" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="col-sm-3">
                <span>Middle name:</span>
                <asp:TextBox ID="tboxmi" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="col-sm-3">
                <span>Empno:</span>
                <asp:TextBox ID="tboxempno" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="row">
            <div class="col-sm-3">
                <span>Birth day:</span>
                <asp:TextBox ID="tboxbirthday" TextMode="Date" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="col-sm-3">
                <span>Gender:</span>
                <asp:DropDownList ID="ddlgender" runat="server" CssClass="form-control">
                    <asp:ListItem Text="M" Value="M"></asp:ListItem>
                    <asp:ListItem Text="F" Value="F"></asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="col-sm-6">
                <span>Address:</span>
                <asp:TextBox ID="tboxaddress" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
        </div>
        <hr />
        <div class="row">
            <div class="col-sm-4">
                <span>Department:</span>
                <asp:TextBox ID="tboxdepartment" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="col-sm-4">
                <span>Department id:</span>
                <asp:TextBox ID="tboxdepartmentid" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="col-sm-4">
                <span>Poscode:</span>
                <asp:TextBox ID="tboxposcode" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
        </div>

        <hr />
        <div class="row">
            <div class="col-sm-4">
                <span>Employee status:</span>
                <asp:TextBox ID="tboxempstatus" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="col-sm-4">
                <span>User status:</span>
                <asp:TextBox ID="tboxuserstatus" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="col-sm-4">
                <span>User account:</span>
                <asp:TextBox ID="tboxuseracct" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-sm-4">
                <span>Atigen test validity:</span>
                <asp:TextBox ID="tboxvalidity" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
        </div>
        <br />
        <asp:LinkButton ID="btnadd" CssClass="btn btn-primary" runat="server" OnClick="btnadd_Click">add</asp:LinkButton>

    </div>
    <br />
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:ValidationSummary ID="ValidationSummary3" CssClass="alert alert-danger" ValidationGroup="val1" runat="server" />
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:Panel ID="Panel1" ScrollBars="Auto" runat="server">
                    <asp:GridView ID="GridView1" AutoGenerateColumns="false" runat="server" AllowPaging="True" OnPageIndexChanging="GridView1_PageIndexChanging" BackColor="White" BorderColor="White" BorderStyle="None" BorderWidth="2px" CellPadding="3" CellSpacing="1" GridLines="Both" PageSize="100" OnRowCommand="GridView1_RowCommand">
                        <Columns>
                            <asp:TemplateField ItemStyle-Wrap="false">
                                <ItemTemplate>
                                    <asp:LinkButton ID="btnEdit" CommandName="myEdit" runat="server">Edit</asp:LinkButton>
                                    <asp:LinkButton ID="btnSave" CommandName="mySave" Visible="false" runat="server">Save</asp:LinkButton>&nbsp;
                                    <asp:LinkButton ID="btnCancel" CommandName="myCancel" Visible="false" runat="server">Cancel</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="EMPLOYEE_NO" ItemStyle-Wrap="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblempno" runat="server" Text='<%# Bind("empno") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="SURNAME" ItemStyle-Wrap="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblsurname" runat="server" Text='<%# Bind("surname") %>'></asp:Label>
                                    <asp:TextBox ID="tboxsurnameedit" Visible="false" CssClass="form-control" Text='<%# Bind("surname") %>' runat="server"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="FIRST NAME" ItemStyle-Wrap="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblfirstname" runat="server" Text='<%# Bind("firstname") %>'></asp:Label>
                                    <asp:TextBox ID="tboxfirstnameedit" Visible="false" CssClass="form-control" Text='<%# Bind("firstname") %>' runat="server"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="MI" ItemStyle-Wrap="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblmi" runat="server" Text='<%# Bind("mi") %>'></asp:Label>
                                    <asp:TextBox ID="tboxmiedit" Visible="false" CssClass="form-control" Text='<%# Bind("mi") %>' runat="server"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="BIRTHDAY" ItemStyle-Wrap="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblbirthday" runat="server" Text='<%# Bind("birthday") %>'></asp:Label>
                                    <asp:TextBox ID="tboxbirthdayedit" Visible="false" TextMode="Date" CssClass="form-control" Text='<%# Bind("birthday") %>' runat="server"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="GENDER" ItemStyle-Wrap="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblgender" runat="server" Text='<%# Bind("gender") %>'></asp:Label>
                                    <asp:TextBox ID="tboxgenderedit" Visible="false" CssClass="form-control" Text='<%# Bind("gender") %>' runat="server"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ADDRESS" ItemStyle-Wrap="false">
                                <ItemTemplate>
                                    <asp:Label ID="lbladdress" runat="server" Text='<%# Bind("address") %>'></asp:Label>
                                    <asp:TextBox ID="tboxaddressedit" Visible="false" CssClass="form-control" Text='<%# Bind("address") %>' runat="server"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="DEPARTMENT" ItemStyle-Wrap="false">
                                <ItemTemplate>
                                    <asp:Label ID="lbldepartment" runat="server" Text='<%# Bind("department") %>'></asp:Label>
                                    <asp:TextBox ID="tboxdepartmentedit" Visible="false" CssClass="form-control" Text='<%# Bind("department") %>' runat="server"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="DEPARTMENT ID" ItemStyle-Wrap="false">
                                <ItemTemplate>
                                    <asp:Label ID="lbldepartmentid" runat="server" Text='<%# Bind("deptid") %>'></asp:Label>
                                    <asp:TextBox ID="tboxdepartmentidedit" Visible="false" CssClass="form-control" Text='<%# Bind("deptid") %>' runat="server"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="POSCODE" ItemStyle-Wrap="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblposcode" runat="server" Text='<%# Bind("poscode") %>'></asp:Label>
                                    <asp:TextBox ID="tboxposcodeedit" Visible="false" CssClass="form-control" Text='<%# Bind("poscode") %>' runat="server"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="EMPLOYEE_STATUS" ItemStyle-Wrap="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblempstatus" runat="server" Text='<%# Bind("empstatus") %>'></asp:Label>
                                    <asp:TextBox ID="tboxempstatusedit" Visible="false" CssClass="form-control" Text='<%# Bind("empstatus") %>' runat="server"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="USER_ACCT" ItemStyle-Wrap="false">
                                <ItemTemplate>
                                    <asp:Label ID="lbluseracct" runat="server" Text='<%# Bind("useracct") %>'></asp:Label>
                                    <asp:TextBox ID="tboxuseracctedit" Visible="false" CssClass="form-control" Text='<%# Bind("useracct") %>' runat="server"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="USER_STATUS" ItemStyle-Wrap="false">
                                <ItemTemplate>
                                    <asp:Label ID="lbluserstatus" runat="server" Text='<%# Bind("userstatus") %>'></asp:Label>
                                    <asp:TextBox ID="tboxuserstatusedit" Visible="false" CssClass="form-control" Text='<%# Bind("userstatus") %>' runat="server"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ANTIGEN_TEST_VALIDITY" ItemStyle-Wrap="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblantigentestvalidity" runat="server" Text='<%# Bind("antigen_test_validity") %>'></asp:Label>
                                    <asp:TextBox ID="tboxvalidityedit" Visible="false" CssClass="form-control" Text='<%# Bind("antigen_test_validity") %>' runat="server"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                        <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" />
                        <PagerSettings PageButtonCount="10" Position="TopAndBottom" />
                        <EditRowStyle BorderStyle="None" BorderWidth="0px" />
                        <PagerStyle CssClass="GridPager" HorizontalAlign="Left" />
                        <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
                        <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                        <SortedAscendingHeaderStyle BackColor="#594B9C" />
                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                        <SortedDescendingHeaderStyle BackColor="#33276A" />

                    </asp:GridView>
                </asp:Panel>
            </ContentTemplate>
        </asp:UpdatePanel>


    </div>
</asp:Content>
