<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="nologin.aspx.cs" MasterPageFile="~/DAILYHEALTHPROFILE/DHPmaster.Master" Inherits="KMDIDailyHealthProfile.DAILYHEALTHPROFILE.nologin" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>No Login Report</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="well">
        <h2><strong>No Login</strong></h2>
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
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" SelectCommand="no_login_stp" SelectCommandType="StoredProcedure">
  
        <SelectParameters>
              <asp:ControlParameter Name="date" ControlID="tboxDate" DefaultValue="1900-01-01" PropertyName="Text" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
    <rsweb:ReportViewer ID="ReportViewer1" Width="100%" Height="800px" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt">
        <LocalReport ReportPath="DAILYHEALTHPROFILE\report\rptNoLogin.rdlc">
            <DataSources>
                <rsweb:ReportDataSource DataSourceId="SqlDataSource1" Name="DataSet1" />
            </DataSources>
        </LocalReport>

    </rsweb:ReportViewer>
</asp:Content>