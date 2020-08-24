<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/DAILYHEALTHPROFILE/DHPmaster.Master" CodeBehind="dhpreport.aspx.cs" Inherits="KMDIDailyHealthProfile.DAILYHEALTHPROFILE.dhpreport" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>Daily Health Profile Report</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="well">
        <h3><strong>DHP Submitted Report</strong></h3>
        <div class="navbar-right">
            <asp:LinkButton ID="LinkButton1" CssClass="btn btn-default" PostBackUrl="~/DAILYHEALTHPROFILE/dhphome.aspx" runat="server">back</asp:LinkButton>
        </div>
    </div>
    <asp:ValidationSummary ID="ValidationSummary1" CssClass="alert alert-danger" ValidationGroup="val1" runat="server" />
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        SelectCommand="

select * into #tbl from (select empno,rdate,id from dhrtbl where rdate = case when ISDATE(@RDATE)=1 THEN CAST(@RDATE AS DATE) ELSE @RDATE END) as tbl
select 
SURNAME+', '+FIRSTNAME+' '+MI AS FULLNAME,
CASE WHEN RDATE IS NOT NULL THEN 'Submitted' else '' end as REPORT,
case when ISDATE(@RDATE)=1 THEN FORMAT(CAST(@RDATE AS DATE),'MMM-dd-yyyy') ELSE @RDATE END as [DATE],
A.EMPNO,
BIRTHDAY,
CAST(DATEDIFF(DD,CAST(BIRTHDAY AS DATE),GETDATE())/365.25 AS INT) AS AGE,
DEPARTMENT,  
stuff((select ', '+format(cast([ACTUALTIMETAKEN] as datetime),'hh:mm tt')+' / '+cast([TEMPREADING] as varchar(20)) from [DHP_bodytemp] where empno = a.empno and DHPID=b.ID and [TIMEOFDAY]='Upon arrival at work' for xml path('')),1,2,('')) as [Upon],
stuff((select ', '+format(cast([ACTUALTIMETAKEN] as datetime),'hh:mm tt')+' / '+cast([TEMPREADING] as varchar(20)) from [DHP_bodytemp] where empno = a.empno and DHPID=b.ID and [TIMEOFDAY]='While at work' for xml path('')),1,2,('')) as [While],
stuff((select ', '+format(cast([ACTUALTIMETAKEN] as datetime),'hh:mm tt')+' / '+cast([TEMPREADING] as varchar(20)) from [DHP_bodytemp] where empno = a.empno and DHPID=b.ID and [TIMEOFDAY]='Before leaving work' for xml path('')),1,2,('')) as [Before],
stuff((select ', '+format(cast([ACTUALTIMETAKEN] as datetime),'hh:mm tt')+' / '+cast([TEMPREADING] as varchar(20)) from [DHP_bodytemp] where empno = a.empno and DHPID=b.ID and [TIMEOFDAY]='Outside of work' for xml path('')),1,2,('')) as [Outside]
 from emptbl as a
left join 
#tbl as b
on a.empno = b.empno

where 
userstatus = 'Active'
ORDER BY SURNAME ASC">
        <SelectParameters>
            <asp:SessionParameter Name="RDATE" SessionField="dhpdatekey" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
    <rsweb:ReportViewer ID="ReportViewer1" Width="100%" Height="800px" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt">
        <LocalReport ReportPath="DAILYHEALTHPROFILE\report\RPTdhpreport.rdlc">
            <DataSources>
                <rsweb:ReportDataSource DataSourceId="SqlDataSource1" Name="DataSet1" />
            </DataSources>
        </LocalReport>
    </rsweb:ReportViewer>

</asp:Content>
