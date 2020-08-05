<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/DAILYHEALTHPROFILE/DHPmaster.Master" CodeBehind="dhphome.aspx.cs" Inherits="webaftersales.DAILYHEALTHPROFILE.dhphome" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>Daily Health Profile</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">


        <div class="well">
            <h3><strong>Daily Health Profile </strong></h3>

            <br />
            <div class="row">
                <div class="col-sm-6">
                    <asp:LinkButton ID="LinkButton1" Width="100%" CssClass="btn btn-default" Font-Size="XX-Large" runat="server" OnClick="LinkButton1_Click"><h1>Add New Record</h1></asp:LinkButton>
                    <br />
                </div>
                <div class="col-sm-6">
                    <div class="input-group">
                        <div class="input-group-addon">DATE</div>
                        <asp:TextBox ID="tboxdate" TextMode="Date" CssClass="form-control" runat="server"></asp:TextBox>
                        <div class="input-group-btn">
                            <asp:LinkButton ID="LinkButton2" CssClass="btn btn-default" runat="server" OnClick="LinkButton2_Click"><span class="glyphicon glyphicon-print"></span></asp:LinkButton>
                        </div>
                    </div>
                    <br />
                    <div class="input-group">
                        <div class="input-group-addon">
                            <asp:CheckBox ID="cboxstatus" runat="server" />
                            with symptom
                        </div>
                        <asp:TextBox ID="tboxsearchkey" CssClass="form-control" runat="server"></asp:TextBox>
                        <div class="input-group-btn">
                            <asp:LinkButton ID="LinkButton3" runat="server" CssClass="btn btn-default" OnClick="LinkButton3_Click"><span class="glyphicon glyphicon-search"></span></asp:LinkButton>

                        </div>
                    </div>
                </div>

            </div>
        </div>
        <asp:ValidationSummary ValidationGroup="val1" CssClass="alert alert-danger" ID="ValidationSummary1" runat="server" />
        <asp:Panel ID="Panel1" runat="server">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    Backtrack form
                </div>
                <div class="panel-body">
                    <div class="row">
                        <div class="col-sm-6">
                            <div class="input-group">
                                <div class="input-group-addon">
                                    DATE
                                </div>
                                <asp:TextBox ID="TBOXinputdate" TextMode="Date" CssClass="form-control" runat="server"></asp:TextBox>

                            </div>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TBOXinputdate" ErrorMessage="date is required" ValidationGroup="val2" ForeColor="Red">*</asp:RequiredFieldValidator>
                        </div>
                        <div class="col-sm-6">
                            <div class="input-group">
                                <div class="input-group-addon">
                                    Name
                                </div>
                                <asp:DropDownList ID="DDLemployee" CssClass="form-control" runat="server"></asp:DropDownList>
                            </div>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="DDLemployee" ErrorMessage="name of employee is required" ValidationGroup="val2" ForeColor="Red">*</asp:RequiredFieldValidator>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-sm-1">
                            <asp:LinkButton ID="LinkButton8" CssClass="btn btn-primary" runat="server" ValidationGroup="val2" OnClick="LinkButton8_Click">add</asp:LinkButton>
                        </div>
                        <div class="col-sm-11">
                            <asp:ValidationSummary ID="ValidationSummary2" ValidationGroup="val2" CssClass="alert alert-danger" runat="server" />
                        </div>
                    </div>


                </div>
                <div class="panel-footer">
                </div>
            </div>
        </asp:Panel>
        <asp:GridView ID="GridView1" AutoGenerateColumns="false" GridLines="None" runat="server" OnRowCommand="GridView1_RowCommand" AllowPaging="True" OnPageIndexChanging="GridView1_PageIndexChanging" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <div class='<%# Eval("status").ToString() ==  "yes" ? "panel panel-danger" : "panel panel-success" %>'>
                            <div class="panel-heading">
                            </div>
                            <div class="panel-body">
                                <asp:Label ID="Label1" Font-Size="XX-Large" runat="server" CssClass='<%# Eval("status").ToString() ==  "yes" ? "text-danger" : "text-info" %>' Text='<%# Bind("DATE") %>'></asp:Label>&nbsp;  
                            <asp:Label ID="Label3" CssClass="text-muted" runat="server" Text='<%# Bind("TIME") %>'></asp:Label>
                                <h5>KMDI EMPLOYEE DAILY HEALTH PROFILE</h5>
                                <blockquote>
                                    <table border="0">

                                        <tr>
                                            <td></td>
                                        </tr>
                                        <tr>
                                            <td class="text-muted">NAME
                                            </td>
                                            <td>
                                                <asp:Label ID="lblname" CssClass='<%# Eval("status").ToString() ==  "yes" ? "text-danger" : "text-info" %>' Font-Size="Large" runat="server" Text='<%# Bind("FULLNAME") %>'></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="text-muted">EMPLOYEE NO.
                                            </td>
                                            <td>
                                                <asp:Label ID="lblempno" runat="server" Text='<%# Bind("EMPNO") %>'></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="text-muted">BIRTHDATE
                                            </td>
                                            <td>
                                                <asp:Label ID="lblbirthday" runat="server" Text='<%# Bind("BIRTHDAY") %>'></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="text-muted">AGE
                                            </td>
                                            <td>
                                                <asp:Label ID="lblage" runat="server" Text='<%# Bind("AGE") %>'></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </blockquote>
                                <table border="0" class="table">
                                    <tr>
                                        <td>
                                            <strong>SIGN/SYMPTOM</strong>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <blockquote>
                                                <asp:Label ID="Label4" runat="server" Text='<%# Bind("SYMPTOM") %>'></asp:Label>
                                            </blockquote>
                                        </td>
                                    </tr>
                                </table>

                                <asp:LinkButton ID="LinkButton4" CommandName="page1" CssClass='<%# Eval("page1").ToString() ==  Eval("empno").ToString() ? "btn btn-primary" : "btn btn-default" %>' runat="server">Page 1</asp:LinkButton>
                                <asp:LinkButton ID="LinkButton5" CommandName="page2"
                                    Visible='<%# Eval("CURRENTUSER").ToString() == "Admin" ? true : false %>'
                                    CssClass='<%# Eval("page2").ToString() ==  Eval("empno").ToString() ? "btn btn-primary" : "btn btn-default" %>' runat="server">Page 2</asp:LinkButton>
                                <asp:LinkButton ID="LinkButton6" CommandName="page3"
                                    Visible='<%# Eval("CURRENTUSER").ToString() == "Admin" ? true : false %>'
                                    CssClass='<%# Eval("page3").ToString() ==  Eval("empno").ToString() ? "btn btn-primary" : "btn btn-default" %>' runat="server">Page 3</asp:LinkButton>
                                <asp:LinkButton ID="LinkButton7" CommandName="myreport"
                                    Visible='<%# Eval("CURRENTUSER").ToString() == "Admin" ? true : false %>'
                                    CssClass="btn btn-success"
                                    runat="server">Report</asp:LinkButton>
                                <br />


                            </div>



                            <div class="panel-footer">
                                <strong>NOTE/OBSERVATIONS</strong>
                                <br />
                                <small class="text-info">(Nurse’s comments)</small><br />
                                <blockquote>
                                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("COMMENTP2") %>'></asp:Label>
                                </blockquote>
                            </div>
                        </div>
                        <asp:Label ID="lblid" Visible="false" runat="server" Text='<%# Bind("ID") %>'></asp:Label>
                        <asp:Label ID="lbldate" Visible="false" runat="server" Text='<%# Bind("DATE") %>'></asp:Label>

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
        <br />
        <strong>
            <asp:Label CssClass="text-muted" ID="lblcountrow" runat="server" Text="Label"></asp:Label></strong>
    </div>
</asp:Content>
