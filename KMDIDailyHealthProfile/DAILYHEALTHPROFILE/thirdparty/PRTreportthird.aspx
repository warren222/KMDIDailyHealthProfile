﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PRTreportthird.aspx.cs" Inherits="KMDIDailyHealthProfile.DAILYHEALTHPROFILE.thirdparty.PRTreportthird" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>
<meta name="viewport" content="width=device-width, initial-scale=1">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script src="../../Scripts/bootstrap.js"></script>
    <link href="../../Content/bootstrap.css" rel="stylesheet" />
    <link href="../../Content/bootstrap.min.css" rel="stylesheet" />
    <script src="../../Scripts/jquery-1.10.2.min.js"></script>
    <script src="../../Scripts/bootstrap.min.js"></script>
    <link href="../css/gridcss.css" rel="stylesheet" />
    <title>Daily Health Profile Report</title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="well">
            <h2>DHP For sign</h2>
        </div>
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:sqlcon %>" SelectCommand="
        SELECT 
        [ID]
      ,[EMPNO]
      ,[DHPID]
      ,[DCEX]
      ,[DCEXno]
      ,CASE WHEN ISDATE ([DCDO]) = 1 THEN FORMAT(CAST([DCDO] AS DATE),'MMMM dd, yyyy') ELSE [DCDO] END AS [DCDO]
      ,[DCET]
      ,[DCRE]
      ,[FEEX]
      ,[FEEXno]
      ,CASE WHEN ISDATE ([FEDO]) = 1 THEN FORMAT(CAST([FEDO] AS DATE),'MMMM dd, yyyy') ELSE [FEDO] END AS [FEDO]
      ,[FEET]
      ,[FERE]
      ,[MPEX]
      ,[MPEXno]
      ,CASE WHEN ISDATE ([MPDO]) = 1 THEN FORMAT(CAST([MPDO] AS DATE),'MMMM dd, yyyy') ELSE [MPDO] END AS [MPDO]
      ,[MPET]
      ,[MPRE]
      ,[WEEX]
      ,[WEEXno]
      ,CASE WHEN ISDATE ([WEDO]) = 1 THEN FORMAT(CAST([WEDO] AS DATE),'MMMM dd, yyyy') ELSE [WEDO] END AS [WEDO]
      ,[WEET]
      ,[WERE]
      ,[DSEX]
      ,[DSEXno]
      ,CASE WHEN ISDATE ([DSDO]) = 1 THEN FORMAT(CAST([DSDO] AS DATE),'MMMM dd, yyyy') ELSE [DSDO] END AS [DSDO]
      ,[DSET]
      ,[DSRE]
      ,[DTEX]
      ,[DTEXno]
      ,CASE WHEN ISDATE ([DTDO]) = 1 THEN FORMAT(CAST([DTDO] AS DATE),'MMMM dd, yyyy') ELSE [DTDO] END AS [DTDO]
      ,[DTET]
      ,[DTRE]
      ,[DIEX]
      ,[DIEXno]
      ,CASE WHEN ISDATE ([DIDO]) = 1 THEN FORMAT(CAST([DIDO] AS DATE),'MMMM dd, yyyy') ELSE [DIDO] END AS [DIDO]
      ,[DIET]
      ,[DIRE]
      ,[DBEX]
      ,[DBEXno]
      ,CASE WHEN ISDATE ([DBDO]) = 1 THEN FORMAT(CAST([DBDO] AS DATE),'MMMM dd, yyyy') ELSE [DBDO] END AS [DBDO]
      ,[DBET]
      ,[DBRE]
      ,[LBEX]
      ,[LBEXno]
      ,CASE WHEN ISDATE ([LBDO]) = 1 THEN FORMAT(CAST([LBDO] AS DATE),'MMMM dd, yyyy') ELSE [LBDO] END AS [LBDO]
      ,[LBET]
      ,[LBRE]
      ,[VOEX]
      ,[VOEXno]
      ,CASE WHEN ISDATE ([VODO]) = 1 THEN FORMAT(CAST([VODO] AS DATE),'MMMM dd, yyyy') ELSE [VODO] END AS [VODO]
      ,[VOET]
      ,[VORE]
      ,[COEX]
      ,[COEXno]
      ,CASE WHEN ISDATE ([CODO]) = 1 THEN FORMAT(CAST([CODO] AS DATE),'MMMM dd, yyyy') ELSE [CODO] END AS [CODO]
      ,[COET]
      ,[CORE]
      ,[OSEX]
      ,[OSEXno]
      ,CASE WHEN ISDATE ([OSDO]) = 1 THEN FORMAT(CAST([OSDO] AS DATE),'MMMM dd, yyyy') ELSE [OSDO] END AS [OSDO]
      ,[OSET]
      ,[OSRE]
      ,[OS]
      ,[COMMENT]
         FROM [ASNWERSHEETtbl] WHERE (([DHPID] = @DHPID) AND ([EMPNO] = @EMPNO))">
            <SelectParameters>
                <asp:SessionParameter Name="DHPID" SessionField="dhp_id" Type="String" />
                <asp:SessionParameter Name="EMPNO" SessionField="dhpempno" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:sqlcon %>"
            SelectCommand="SELECT SURNAME,
FIRSTNAME,
MI,
DEPARTMENT,
POSCODE,
EMPNO,
BIRTHDAY,
GENDER,
ADDRESS,
surname+', '+firstname+' '+mi as FULLNAME,
CAST(DATEDIFF(DD,CAST(BIRTHDAY AS DATE),GETDATE())/365.25 AS INT) AS AGE FROM [EMPTBL] as a WHERE ([EMPNO] = @EMPNO)">
            <SelectParameters>
                <asp:SessionParameter Name="EMPNO" SessionField="dhpempno" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>

        <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:sqlcon %>"
            SelectCommand="

 SELECT 
STUFF((SELECT ', '+[TRAVELHISTORY]
  FROM [DHPtravelhistory] WHERE [EMPNO] = @EMPNO AND [DHPID]=@DHPID FOR XML PATH('')),1,2,'') AS TRAVELHISTORY,
  STUFF((SELECT ', '+FULLNAME
      
  FROM PERSONSINTERACT WHERE [EMPNO] = @EMPNO AND [DHPID]=@DHPID FOR XML PATH('')),1,2,'') AS PERSONINTERACT,
     (SELECT CASE WHEN ISDATE([DATETESTDONE])=1 THEN FORMAT(CAST(DATETESTDONE AS DATE),'MMMM dd, yyyy') ELSE DATETESTDONE END FROM DHPPAGE2 WHERE [EMPNO] = @EMPNO AND [DHPID]=@DHPID ) AS DATETESTDONE,
          (SELECT [SERIALNO] FROM DHPPAGE2 WHERE [EMPNO] = @EMPNO AND [DHPID]=@DHPID ) AS [SERIALNO]
  FROM [emptbl] where empno = @EMPNO">

            <SelectParameters>
                <asp:SessionParameter Name="DHPID" SessionField="dhp_id" Type="String" />
                <asp:SessionParameter Name="EMPNO" SessionField="dhpempno" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSource4" runat="server"
            ConnectionString="<%$ ConnectionStrings:sqlcon %>"
            SelectCommand="

 SELECT 
       [ID]
      ,[EMPNO]
      ,[DHPID]
      ,[EXPOSURETOVIRUS]
      ,[DATETESTDONE]
      ,[TIMETEST]
      ,[SERIALNO]
      ,[TESTRESULT]
      ,[PATIENTNAME]
      ,[ADMINISTEREDBY]
      ,[PHYSICIAN]
      ,[LICENSENO]
      ,[RECOENDO]
      ,[RECOCALLIN]
      ,[RECOSENDHOME]
      ,[RECOOTHER]
      ,[RECOPATIENT]
  FROM [DHPPAGE2] where empno = @EMPNO and DHPID=@DHPID">

            <SelectParameters>
                <asp:SessionParameter Name="DHPID" SessionField="dhp_id" Type="String" />
                <asp:SessionParameter Name="EMPNO" SessionField="dhpempno" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
        <rsweb:ReportViewer ID="ReportViewer1" Width="100%" Height="800px" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt">
            <LocalReport ReportPath="DAILYHEALTHPROFILE\report\RPT.rdlc">
                <DataSources>
                    <rsweb:ReportDataSource DataSourceId="SqlDataSource1" Name="DataSet1" />
                    <rsweb:ReportDataSource DataSourceId="SqlDataSource2" Name="DataSet2" />
                    <rsweb:ReportDataSource DataSourceId="SqlDataSource3" Name="DataSet3" />
                    <rsweb:ReportDataSource DataSourceId="SqlDataSource4" Name="DataSet4" />
                </DataSources>
            </LocalReport>

        </rsweb:ReportViewer>
    </form>
</body>
</html>
