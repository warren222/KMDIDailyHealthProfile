<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/DAILYHEALTHPROFILE/DHPmaster.Master" CodeBehind="testresultsummaryreport.aspx.cs" Inherits="KMDIDailyHealthProfile.DAILYHEALTHPROFILE.testresultsummaryreport" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>Test Result Report</title>
</asp:Content>

<asp:Content ID="content2" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <div class="well">
        <h3><strong>Test Result Report</strong></h3>
        <div class="nav navbar-right">
            <asp:LinkButton ID="LinkButton1" CssClass="btn btn-default" PostBackUrl="~/DAILYHEALTHPROFILE/testresultsummary.aspx" runat="server">back</asp:LinkButton>
        </div>
    </div>
    <asp:ValidationSummary ID="ValidationSummary1" ValidationGroup="val1" CssClass="alert alert-danger" runat="server" />
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server"  
        SelectCommand="
     SELECT TEST,ID,EMPNO,DHPID,CASE WHEN ISDATE(DATETESTDONE)=1 THEN FORMAT(CAST(DATETESTDONE AS DATE),'MMMM-dd-yyyy') ELSE DATETESTDONE END AS DATETESTDONE
,CASE WHEN ISDATE(TIMETEST)=1 THEN FORMAT(CAST(TIMETEST AS datetime),'hh:mm tt') ELSE TIMETEST END AS TIMETEST
,SERIALNO,TESTRESULT,ADMINISTEREDBY,[PHYSICIAN],[LICENSENO],FULLNAME
 FROM ( SELECT 'RAPID TEST' AS TEST,[ID]
      ,a.[EMPNO]
      ,[DHPID]
      ,[DATETESTDONE]
      ,[TIMETEST]
      ,[SERIALNO]
      ,[TESTRESULT]
      ,[ADMINISTEREDBY]
      ,[PHYSICIAN]
      ,[LICENSENO]
	  ,b.SURNAME+', '+b.FIRSTNAME+' '+MI AS FULLNAME
       FROM [DHPPAGE2] as a left join emptbl as b
       on a.empno = b.empno
        WHERE datetestdone <> '' AND (SURNAME LIKE '%'+@PATIENTNAME+'%' or firstname like '%'+@PATIENTNAME+'%')
		UNION ALL
	   SELECT 'ANTIGEN TEST',[ID]
      ,a.[EMPNO]
      ,[DHPID]
      ,ANTIGENDATE
      ,ANTIGENTIME
      ,ANTIGENSERIAL
      ,ANTIGENRESULT
      ,[ADMINISTEREDBY]
      ,[PHYSICIAN]
      ,[LICENSENO]
	  ,b.SURNAME+', '+b.FIRSTNAME+' '+MI AS FULLNAME
       FROM [DHPPAGE2] as a left join emptbl as b
       on a.empno = b.empno
        WHERE ANTIGENDATE <> '' AND (SURNAME LIKE '%'+@PATIENTNAME+'%' or firstname like '%'+@PATIENTNAME+'%')
		) AS TB 
		order by case when isdate(datetestdone)=1 then cast([DATETESTDONE] as date) else datetestdone end desc, 
        CASE WHEN ISDATE(TIMETEST)=1 THEN cast(TIMETEST AS datetime) ELSE TIMETEST END desc ">
        <SelectParameters>
            <asp:SessionParameter Name="PATIENTNAME" SessionField="testresultsearchkey" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="100%" Height="800px" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt">
        <LocalReport ReportPath="DAILYHEALTHPROFILE\report\testresultRDLC.rdlc">
            <DataSources>
                <rsweb:ReportDataSource DataSourceId="SqlDataSource1" Name="DataSet1" />
            </DataSources>
        </LocalReport>
    </rsweb:ReportViewer>
</asp:Content>