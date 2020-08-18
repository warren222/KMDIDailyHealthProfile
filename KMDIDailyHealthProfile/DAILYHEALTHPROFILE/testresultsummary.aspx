<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/DAILYHEALTHPROFILE/DHPmaster.Master" CodeBehind="testresultsummary.aspx.cs" Inherits="KMDIDailyHealthProfile.DAILYHEALTHPROFILE.testresultsummary" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>Test Result</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="well">
        <h3><strong>Test results summary</strong></h3>
        <div class="input-group">
            <div class="input-group-addon">
                Search key
            </div>
            <asp:TextBox ID="tboxsearchkey" CssClass="form-control" runat="server"></asp:TextBox>
            <div class="input-group-btn">
                <asp:LinkButton ID="btnsearch" CssClass="btn btn-default" runat="server" OnClick="btnsearch_Click"><span class="glyphicon glyphicon-search"></span></asp:LinkButton>
                <asp:LinkButton ID="LinkButton1" CssClass="btn btn-default" runat="server" OnClick="LinkButton1_Click">report</asp:LinkButton>
            </div>
        </div>
    </div>
    <asp:ValidationSummary ID="ValidationSummary1" ValidationGroup="val1" CssClass="alert alert-danger" runat="server" />
    <asp:Panel ID="Panel1" runat="server" ScrollBars="Horizontal">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>

                <asp:GridView ID="GridView1" GridLines="None" AllowPaging="true" AutoGenerateColumns="false" runat="server" OnPageIndexChanging="GridView1_PageIndexChanging" ShowHeader="False">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <div class="panel panel-primary">
                                    <div class="panel-heading">
                                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("EMPNO") %>'></asp:Label>
                                    </div>
                                    <div class="panel-body">
                                        <asp:Label ID="Label2" runat="server" Font-Size="XX-Large" Text='<%# Bind("FULLNAME") %>'></asp:Label>
                                        <br />
                                        <br />
                                        <asp:GridView ID="GridView2" GridLines="Horizontal" CssClass="table table-striped" DataSource='<%# Bind("testresultsummary") %>' runat="server" AutoGenerateColumns="False">
                                            <Columns>
                                                <asp:TemplateField HeaderText="DATE TEST DONE" HeaderStyle-CssClass="text-muted">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbldatetestdone" runat="server" Text='<%# Bind("DATETESTDONE") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="TIME TEST" HeaderStyle-CssClass="text-muted">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbltimetest" runat="server" Text='<%# Bind("TIMETEST") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="SERIAL#" HeaderStyle-CssClass="text-muted">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblserialno" runat="server" Text='<%# Bind("SERIALNO") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="TEST RESULTS" HeaderStyle-CssClass="text-muted">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbltestresult" runat="server" Text='<%# Bind("TESTRESULT") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="ADMINISTERED BY" HeaderStyle-CssClass="text-muted">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbladministeredby" runat="server" Text='<%# Bind("ADMINISTEREDBY") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <HeaderStyle Wrap="False" />
                                            <RowStyle Wrap="False" />
                                            <EmptyDataTemplate>
                                                <div class="alert alert-info">
                                                    <h3><strong>Empty Table!</strong>
                                                    </h3>
                                                </div>
                                            </EmptyDataTemplate>
                                            <EditRowStyle BorderStyle="None" BorderWidth="0px" />
                                          
                                        </asp:GridView>
                                    </div>
                                    <div class="panel-footer">
                                    </div>
                                </div>



                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <HeaderStyle Wrap="False" />
                    <RowStyle Wrap="False" />
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

            </ContentTemplate>
        </asp:UpdatePanel>
    </asp:Panel>
</asp:Content>
