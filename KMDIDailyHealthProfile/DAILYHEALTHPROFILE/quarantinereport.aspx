<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/DAILYHEALTHPROFILE/DHPmaster.Master" CodeBehind="quarantinereport.aspx.cs" Inherits="KMDIDailyHealthProfile.DAILYHEALTHPROFILE.quarantinereport" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>


<asp:Content ID="content1" runat="server" ContentPlaceHolderID="head">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>Quarantine report</title>
</asp:Content>

<asp:Content ID="content2" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="well">
        <h3><strong>Quarantine report</strong></h3>
    </div>
    <asp:ValidationSummary ID="ValidationSummary1" ValidationGroup="val1" CssClass="alert alert-danger" runat="server" />

    <asp:CheckBox ID="cboxuq" Checked="true" Text="Under quarantine" runat="server" />
    <div class="input-group">
        <div class="input-group-addon">Department</div>
        <asp:DropDownList ID="dpdepartment" CssClass="form-control" runat="server">
            <asp:ListItem Value="Accounting" Selected="True">Accounting</asp:ListItem>
            <asp:ListItem Value="Admin">Admin</asp:ListItem>
            <asp:ListItem Value="Delivery & Installation">Delivery & Installation</asp:ListItem>
            <asp:ListItem Value="Human Resource">Human Resource</asp:ListItem>
            <asp:ListItem Value="Management">Management</asp:ListItem>
            <asp:ListItem Value="Marketing">Marketing</asp:ListItem>
            <asp:ListItem Value="POSE">POSE</asp:ListItem>
            <asp:ListItem Value="Production">Production</asp:ListItem>
            <asp:ListItem Value="Sales">Sales</asp:ListItem>
        </asp:DropDownList>

        <div class="input-group-btn">
            <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn btn-primary" OnClick="LinkButton1_Click">go</asp:LinkButton>
        </div>
    </div>

    <asp:SqlDataSource ID="SqlDataSource1" 
        SelectCommand="
        select * into #my_tb from( 
select 
a.EMPNO,
a.FULLNAME,
case when isdate(b.BIRTHDAY)=1 then format(cast(b.BIRTHDAY as date),'MMM dd, yyyy') else b.BIRTHDAY end as BIRTHDAY,
CAST(DATEDIFF(DD,CAST(b.BIRTHDAY AS DATE),GETDATE())/365.25 AS INT) AS AGE,
b.DEPARTMENT,
b.DEPTID,
case when isdate(a.SDATE)=1 then format(cast(a.SDATE as date),'MMM dd, yyyy') else a.SDATE end as SDATE,
case when isdate(a.EDATE)=1 then format(cast(a.EDATE as date),'MMM dd, yyyy') else a.EDATE end as EDATE,
DATEDIFF(day,sdate,case when edate='' then getdate() else edate end)+1 AS [DAYS]
from 
quarantinetbl as a
left join
EMPTBL as b
on a.empno = b.empno) as tb

select * from #my_tb where DEPTID = @department and edate = case when @rb = '1' then '' else edate end"
        runat="server">
        <SelectParameters>
            <asp:SessionParameter Name="department" SessionField="mydepartment" DefaultValue="delivery" Type="String" />
            <asp:SessionParameter Name="rb" SessionField="rb" DefaultValue="1" Type="String" />
        </SelectParameters>

    </asp:SqlDataSource>
    <rsweb:ReportViewer ID="ReportViewer1" Width="100%" Height="800px" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt">
        <LocalReport ReportPath="DAILYHEALTHPROFILE\report\RPTquarantine.rdlc">
            <DataSources>
                <rsweb:ReportDataSource DataSourceId="SqlDataSource1" Name="DataSet1" />
            </DataSources>
        </LocalReport>
    </rsweb:ReportViewer>
</asp:Content>
