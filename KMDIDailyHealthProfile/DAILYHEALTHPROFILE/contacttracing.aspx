<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/DAILYHEALTHPROFILE/DHPmaster.Master" CodeBehind="contacttracing.aspx.cs" Inherits="KMDIDailyHealthProfile.DAILYHEALTHPROFILE.contacttracing" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>Contact tracing</title>
</asp:Content>

<asp:Content ID="content2" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <div class="well">
        <h3><strong>Contact tracing</strong></h3>
        <div class="input-group">
           
               
            <asp:TextBox ID="tboxsearchkey" TextMode="Date" CssClass="form-control" runat="server"></asp:TextBox>
            <div class="input-group-btn">
          
                <asp:LinkButton ID="LinkButton2" CssClass="btn btn-default" runat="server" OnClick="LinkButton2_Click"><span class="glyphicon glyphicon-search"></span></asp:LinkButton>
                       <asp:LinkButton ID="LinkButton1" CssClass="btn btn-default" runat="server" OnClick="LinkButton1_Click">report</asp:LinkButton>
            </div>
        </div>
    </div>
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <asp:Panel ID="Panel1" runat="server">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:ValidationSummary ID="ValidationSummary1" CssClass="alert alert-danger" ValidationGroup="val1" runat="server" />
                <asp:Panel ID="Panel2" runat="server" ScrollBars="Auto">


                    <asp:GridView ID="GridView1" AutoGenerateColumns="false" AllowPaging="true" CssClass="table table-bordered" runat="server" OnPageIndexChanging="GridView1_PageIndexChanging" PageSize="25">
                        <Columns>
                              <asp:TemplateField HeaderText="EMPNO">
                                <ItemTemplate>
                                    <asp:Label ID="lblEMPNO" runat="server" Text='<%# Bind("EMPNO") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="FULLNAME">
                                <ItemTemplate>
                                    <asp:Label ID="lblFULLNAME" runat="server" Text='<%# Bind("FULLNAME") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Person_Interract">
                                <ItemTemplate>
                                    <asp:Label ID="lblPerson_Interract" runat="server" Text='<%# Bind("Person_Interract") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="DEPARTMENT">
                                <ItemTemplate>
                                    <asp:Label ID="lblDEPARTMENT" runat="server" Text='<%# Bind("DEPARTMENT") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="POSCODE">
                                <ItemTemplate>
                                    <asp:Label ID="lblPOSCODE" runat="server" Text='<%# Bind("POSCODE") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                              <asp:TemplateField HeaderText="DATE">
                                <ItemTemplate>
                                    <asp:Label ID="lblDATE" runat="server" Text='<%# Bind("DATE") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <HeaderStyle Wrap="false" />
                        <RowStyle Wrap="false" />
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
                </asp:Panel>
            </ContentTemplate>
        </asp:UpdatePanel>
    </asp:Panel>
</asp:Content>
