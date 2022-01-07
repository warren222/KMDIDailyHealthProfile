<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/DAILYHEALTHPROFILE/DHPmaster.Master" CodeBehind="AntiGenValidity.aspx.cs" Inherits="KMDIDailyHealthProfile.DAILYHEALTHPROFILE.AntiGenValidity" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>Daily Health Profile Report</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="well text-center">
        <h3><strong>Antigen Test Validation</strong></h3>

    </div>
    <asp:ValidationSummary ID="ValidationSummary1" CssClass="alert alert-danger" ValidationGroup="val1" runat="server" />
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div>
        <div class="row">
            <div class="col-sm-4">
            </div>
            <div class="col-sm-4">
                <span></span>
                <div class="input-group">
                    <asp:TextBox ID="tboxempno" CssClass="form-control" runat="server"></asp:TextBox>
                    <div class="input-group-btn">
                        <asp:LinkButton ID="LinkButton1" CssClass="btn btn-primary" runat="server" OnClick="LinkButton1_Click">check</asp:LinkButton>
                    </div>
                </div>
            </div>
            <div class="col-sm-4">
            </div>
        </div>
        <br />
        <div>
            <div class="row">
                <div class="col-sm-3">
                </div>
                <div class="col-sm-6">
                    <div class="well text-center">
                        <asp:Panel ID="Panel1" ScrollBars="Auto" runat="server">
                            <table style="width: 100%">
                                <tr>
                                    <td>
                                        <asp:Image ID="Image1" Visible="false" runat="server" ImageUrl="~/images/Accept-icon.png" />
                                        <asp:Image ID="Image2" Visible="false" runat="server" ImageUrl="~/images/Actions-window-close-icon.png" />
                                        <asp:Image ID="Image3" Visible="true" runat="server" ImageUrl="~/images/Question-icon.png" />

                                    </td>
                                    <td>
                                        <asp:Label ID="lblFullname" Font-Size="XX-Large" runat="server" Text="Name"></asp:Label><br />
                                        <asp:Label ID="lbliscleared" Font-Size="X-Large" runat="server" Text="Status"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="Panel2" ScrollBars="Auto" runat="server">
                            <asp:Label ID="lblEmpno" Visible="false" runat="server" Text="Label"></asp:Label>
                            <asp:Label ID="lbltestvalidity" Visible="false" runat="server" Text="Label"></asp:Label>
                            <asp:Label ID="lblantigenserial" Visible="false" runat="server" Text="Label"></asp:Label>
                            <asp:Label ID="lblantigenresult" Font-Size="Larger" Font-Bold="true" runat="server" Text="Test result"></asp:Label>
                            <br />
                            <br />
                            <asp:Label ID="lbldate" runat="server" Font-Size="Large" Text=""></asp:Label><br />
                            <span class="text-muted">(Date Tested)</span>
                            <br />
                            <br />
                            <asp:Label ID="lbltextvaliditydate" Font-Size="Large" runat="server" Text=""></asp:Label><br />
                            <span class="text-muted">(Valid until)</span>
                        </asp:Panel>
                    </div>
                </div>
                <div class="col-sm-3">
                </div>
            </div>
        </div>
    </div>
</asp:Content>
