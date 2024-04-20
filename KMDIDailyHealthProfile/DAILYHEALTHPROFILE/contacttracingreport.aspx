<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/DAILYHEALTHPROFILE/DHPmaster.Master" CodeBehind="contacttracingreport.aspx.cs" Inherits="KMDIDailyHealthProfile.DAILYHEALTHPROFILE.contacttracingreport" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>Contact tracing Report</title>
</asp:Content>
<asp:Content ID="content2" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <div class="well">
        <h3><strong>Contact tracing Report</strong></h3>
        <div class="nav navbar-right">
            <asp:LinkButton ID="LinkButton1" CssClass="btn btn-default" runat="server" PostBackUrl="~/DAILYHEALTHPROFILE/contacttracing.aspx">back</asp:LinkButton>
        </div>
    </div>
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>
    <div style="overflow-x: auto">
        <rsweb:ReportViewer ID="ReportViewer2" runat="server" SizeToReportContent="true">
            <LocalReport ReportPath="DAILYHEALTHPROFILE\report\RPTcontacttracing.rdlc">
                <DataSources>
                    <rsweb:ReportDataSource DataSourceId="SqlDataSource1" Name="DataSet1" />
                </DataSources>
            </LocalReport>
        </rsweb:ReportViewer>
    </div>
</asp:Content>
