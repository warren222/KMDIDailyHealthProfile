<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/DAILYHEALTHPROFILE/DHPmaster.Master" CodeBehind="backtrackaccess.aspx.cs" Inherits="KMDIDailyHealthProfile.DAILYHEALTHPROFILE.backtrackaccess" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>change username and password</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="well">
        <h3><strong>Backtrack access</strong></h3>
    </div>
    <asp:ValidationSummary ValidationGroup="val1" CssClass="alert alert-danger" ID="ValidationSummary1" runat="server" />
    <div class="input-group">
        <div class="input-group-addon">
            Account
        </div>
        <asp:DropDownList ID="DropDownList1" CssClass="form-control" runat="server">
        </asp:DropDownList>
        <div class="input-group-btn">
            <asp:LinkButton ID="LinkButton1" CssClass="btn btn-default" runat="server" OnClick="LinkButton1_Click">add</asp:LinkButton>
        </div>
    </div>


    <br />
    <asp:GridView ID="GridView1" CssClass="table table-bordered" runat="server" AllowPaging="True" AutoGenerateColumns="False" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCommand="GridView1_RowCommand">
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton2" runat="server" CssClass="btn btn-danger" CommandName="mydelete" OnClientClick="return confirm('delete this record?')">DELETE</asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="EMPNO">
                <ItemTemplate>
                    <asp:Label ID="lblempno" runat="server" Text='<%# Bind("EMPNO") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="NAME">
                <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("FULLNAME") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <EmptyDataTemplate>
            <div class="alert alert-info">
                <h3><strong>Empty Table!</strong>
                </h3>
            </div>
        </EmptyDataTemplate>
        <EditRowStyle BorderStyle="None" BorderWidth="0px" />
        <PagerSettings PageButtonCount="8" />
        <PagerStyle CssClass="GridPager" HorizontalAlign="Left" />
    </asp:GridView>

</asp:Content>
