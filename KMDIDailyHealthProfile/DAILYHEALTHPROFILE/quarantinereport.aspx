<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/DAILYHEALTHPROFILE/DHPmaster.Master" CodeBehind="quarantinereport.aspx.cs" Inherits="KMDIDailyHealthProfile.DAILYHEALTHPROFILE.quarantinereport" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>


<asp:Content ID="content1" runat="server" ContentPlaceHolderID="head">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>Quarantine report</title>
</asp:Content>

<asp:Content ID="content2" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="well">
        <h3><strong>Quarantine reports</strong></h3>
    </div>

    <asp:SqlDataSource ID="SqlDataSource1" ConnectionString="<%$ ConnectionStrings:sqlcon %>" SelectCommand="QUARANTINERPTstp" SelectCommandType="StoredProcedure" runat="server"></asp:SqlDataSource>

    <rsweb:ReportViewer ID="ReportViewer1" Width="100%" Height="800px" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt">
        <LocalReport ReportPath="DAILYHEALTHPROFILE\report\RPTquarantine.rdlc">
            <DataSources>
                <rsweb:ReportDataSource DataSourceId="SqlDataSource1" Name="DataSet1" />
            </DataSources>
        </LocalReport>
    </rsweb:ReportViewer>
</asp:Content>
