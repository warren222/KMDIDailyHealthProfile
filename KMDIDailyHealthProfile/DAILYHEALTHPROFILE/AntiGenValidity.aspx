<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/DAILYHEALTHPROFILE/DHPmaster.Master" CodeBehind="AntiGenValidity.aspx.cs" Inherits="KMDIDailyHealthProfile.DAILYHEALTHPROFILE.AntiGenValidity" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>Antigen Test Clearance</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="well text-center">
        <h3><strong>Antigen Test Clearance</strong></h3>

    </div>
    <asp:ValidationSummary ID="ValidationSummary1" CssClass="alert alert-danger" ValidationGroup="val1" runat="server" />
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div>
        <div class="row">
            <div class="col-sm-4">
            </div>
            <div class="col-sm-4">
                <span>Employee number</span>
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

                            <div class="row" style="width: 99%;">
                                <div class="col-sm-3">
                                    <asp:Image ID="Image1" Visible="false" Width="100" Height="100" runat="server" ImageUrl="~/images/Accept-icon.png" />
                                    <asp:Image ID="Image2" Visible="false" Width="100" Height="100" runat="server" ImageUrl="~/images/Actions-window-close-icon.png" />
                                    <asp:Image ID="Image3" Visible="true" Width="100" Height="100" runat="server" ImageUrl="~/images/Question-icon.png" />
                                </div>
                                <div class="col-sm-9">

                                    <asp:Label ID="lblFullname" Font-Size="X-Large" runat="server" Text="Name"></asp:Label><br />
                                    <br />
                                    <asp:Label ID="lblClearance" Font-Size="XX-Large" Font-Bold="true" runat="server" Text="Status"></asp:Label><br />
                                    <asp:Label ID="lblDate" Font-Size="Large" CssClass="text-center" runat="server" Text="Date"></asp:Label>
                                </div>
                            </div>

                        </asp:Panel>
                        <br />
                        <asp:Label ID="lblRemarks" Font-Size="Large" runat="server" CssClass="label label-info" Text=""></asp:Label><br />
                        <br />
                        <asp:Panel ID="Panel2" ScrollBars="Auto" runat="server">
                            <table style="width: 100%" border="1">
                                <tr>
                                    <th colspan="2"><span>Latest antigen test record</span></th>
                                </tr>
                                <tr>
                                    <td>Result</td>
                                    <td>
                                        <asp:Label ID="lblantigenresult" Font-Size="Medium" Font-Bold="true" runat="server" Text="Test result"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td><span class="">Date Tested</span></td>
                                    <td>
                                        <asp:Label ID="lblantigendate" runat="server" Font-Size="Small" Text=""></asp:Label></td>
                                </tr>
                                <tr>
                                    <td><span class="">Expiration Date</span></td>
                                    <td>
                                        <asp:Label ID="lbltestvaliditydate" Font-Size="Small" runat="server" Text=""></asp:Label></td>
                                </tr>
                            </table>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="Panel3" ScrollBars="Auto" runat="server">
                            <table style="width: 100%" border="1">
                                <tr>
                                    <th colspan="2"><span>Last 2 DHP reports</span></th>
                                </tr>
                                <tr>
                                    <td>Date</td>
                                    <td>May Sintomas</td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblDHP_Report_1_Date" Font-Size="Small" runat="server" Text=""></asp:Label></td>
                                    <td>
                                        <asp:Label ID="lblDHP_Report_1" Font-Size="Small" runat="server" Text=""></asp:Label></td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblDHP_Report_2_Date" Font-Size="Small" runat="server" Text=""></asp:Label></td>
                                    <td>
                                        <asp:Label ID="lblDHP_Report_2" Font-Size="Small" runat="server" Text=""></asp:Label></td>
                                </tr>
                            </table>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="Panel4" ScrollBars="Auto" runat="server">
                            <table style="width: 100%" border="1">
                                <tr>
                                    <th colspan="2"><span>Latest quarantine record</span></th>
                                </tr>
                                <tr>
                                    <td>Date quarantined</td>
                                    <td>
                                        <asp:Label ID="lblQuarantine_Date" Font-Size="Small" runat="server" Text=""></asp:Label></td>
                                </tr>
                                <tr>
                                    <td>Expected date finish</td>
                                    <td>
                                        <asp:Label ID="lblEnd_Quarantine_Date" Font-Size="Small" runat="server" Text=""></asp:Label></td>
                                </tr>
                                <tr>
                                    <td>Date ended</td>
                                    <td>
                                        <asp:Label ID="lblEnded_Quarantine_Date" Font-Size="Small" runat="server" Text=""></asp:Label></td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </div>
                </div>
                <div class="col-sm-3">
                </div>
            </div>
        </div>
    </div>
</asp:Content>
