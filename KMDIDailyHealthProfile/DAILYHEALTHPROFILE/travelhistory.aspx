<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="travelhistory.aspx.cs" MasterPageFile="~/DAILYHEALTHPROFILE/DHPmaster.Master" Inherits="KMDIDailyHealthProfile.DAILYHEALTHPROFILE.travelhistory" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>Travel History Report</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="well">
        <h2><strong>Travel History</strong></h2>
        <div class="input-group">
            <div class="input-group-addon">
                Date
            </div>
            <asp:TextBox ID="tboxDate" CssClass="form-control" TextMode="Date" runat="server"></asp:TextBox>
            <div class="input-group-btn">
                <asp:LinkButton ID="btnSearch" CssClass="btn btn-primary" runat="server" OnClick="btnSearch_Click">Find</asp:LinkButton>
            </div>
        </div>
    </div>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" SelectCommand="travel_history_stp" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:ControlParameter Name="date" ControlID="tboxDate" DefaultValue="1900-01-01" PropertyName="Text" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
    <div style="overflow-x: auto">
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" SizeToReportContent="true">
            <LocalReport ReportPath="DAILYHEALTHPROFILE\report\rptTravelHistoryReport.rdlc">
                <DataSources>
                    <rsweb:ReportDataSource DataSourceId="SqlDataSource1" Name="DataSet1" />
                </DataSources>
            </LocalReport>
        </rsweb:ReportViewer>
    </div>
</asp:Content>
