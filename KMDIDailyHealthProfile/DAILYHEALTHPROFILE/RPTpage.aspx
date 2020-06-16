<%@ Page Language="C#" MasterPageFile="~/DAILYHEALTHPROFILE/DHPmaster.Master" AutoEventWireup="true" CodeBehind="RPTpage.aspx.cs" Inherits="KMDIDailyHealthProfile.DAILYHEALTHPROFILE.RPTpage" %>


<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>Daily Health Profile Report</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="well">
        <h3><strong>Report viewer</strong></h3>
        <div class="navbar-right">
            <asp:LinkButton ID="LinkButton1" CssClass="btn btn-default" PostBackUrl="~/DAILYHEALTHPROFILE/dhphome.aspx" runat="server">back</asp:LinkButton>
        </div>
    </div>
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:sqlcon %>" SelectCommand="SELECT * FROM [ASNWERSHEETtbl] WHERE (([DHPID] = @DHPID) AND ([EMPNO] = @EMPNO))">
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
     (SELECT [DATETESTDONE] FROM DHPPAGE2 WHERE [EMPNO] = @EMPNO AND [DHPID]=@DHPID ) AS DATETESTDONE,
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
</asp:Content>
