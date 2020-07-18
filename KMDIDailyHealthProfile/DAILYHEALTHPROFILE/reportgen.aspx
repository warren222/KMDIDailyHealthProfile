<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/DAILYHEALTHPROFILE/DHPmaster.Master" CodeBehind="reportgen.aspx.cs" Inherits="KMDIDailyHealthProfile.DAILYHEALTHPROFILE.reportgen" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>Daily Health Profile Report</title>
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="well">
        <h3><strong>PROJECT ARK PATIENT DATA&nbsp;<span class="text-info">collection</span> </strong></h3>

    </div>
    <asp:ValidationSummary ValidationGroup="val1" CssClass="alert alert-danger" ID="ValidationSummary1" runat="server" />
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <div class="row">

        <div class="col-sm-4">
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>


                    <div class="input-group">
                        <div class="input-group-addon">DATE</div>
                        <asp:TextBox ID="tboxdate" TextMode="Date" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                    <br />
                    <div class="input-group">
                        <div class="input-group-addon">
                            <asp:CheckBox ID="cboxstatus" runat="server" />
                            with symptom
                        </div>
                        <asp:TextBox ID="tboxsearchkey" CssClass="form-control" runat="server"></asp:TextBox>
                        <div class="input-group-btn">
                            <asp:LinkButton ID="LinkButton3" runat="server" CssClass="btn btn-default" OnClick="LinkButton3_Click"><span class="glyphicon glyphicon-search"></span></asp:LinkButton>

                        </div>
                    </div>
                    <asp:Panel ID="Panel1" Height="800" runat="server" ScrollBars="Auto">

                        <asp:GridView ID="GridView1" CssClass="table" runat="server" AutoGenerateColumns="False" AllowPaging="True" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCommand="GridView1_RowCommand" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" PageSize="12">
                            <Columns>
                                <asp:TemplateField HeaderText="Employee">
                                    <ItemTemplate>
                                        <asp:Label ID="lblid" Visible="false" runat="server" Text='<%# Bind("ID") %>'></asp:Label>
                                        <asp:Label ID="lbldate" Visible="false" runat="server" Text='<%# Bind("RDATE") %>'></asp:Label>
                                        <asp:Label ID="lblname" runat="server" Text='<%# Bind("FULLNAME") %>'></asp:Label>
                                        <asp:Label ID="lblage" Visible="false" runat="server" Text='<%# Bind("AGE") %>'></asp:Label>
                                        <asp:Label ID="lblempno" Visible="false" runat="server" Text='<%# Bind("EMPNO") %>'></asp:Label>
                                        <asp:Label ID="lblbirthday" Visible="false" runat="server" Text='<%# Bind("BIRTHDAY") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LinkButton1" CommandName="myselect" CssClass="btn btn-default" Width="100%" runat="server">SELECT</asp:LinkButton><br />
                                        <small>
                                            <asp:LinkButton ID="LinkButton2" CommandName="page1" runat="server">Page1</asp:LinkButton>
                                            <asp:LinkButton ID="LinkButton4" CommandName="page2" runat="server">Page2</asp:LinkButton>
                                            <asp:LinkButton ID="LinkButton5" CommandName="page3" runat="server">Page3</asp:LinkButton>
                                        </small>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <EmptyDataTemplate>
                                <div class="alert alert-info">
                                    <h3><strong>Empty Table!</strong>
                                    </h3>
                                </div>
                            </EmptyDataTemplate>
                            <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                            <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                            <PagerSettings PageButtonCount="5" />
                            <PagerStyle CssClass="GridPager" HorizontalAlign="Left" BackColor="White" ForeColor="Black" />
                            <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                            <SortedAscendingCellStyle BackColor="#F7F7F7" />
                            <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                            <SortedDescendingCellStyle BackColor="#E5E5E5" />
                            <SortedDescendingHeaderStyle BackColor="#242121" />
                        </asp:GridView>
                    </asp:Panel>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <div class="col-sm-8">
            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                <ContentTemplate>


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
      ,[RECOFITTOWORK]
  FROM [DHPPAGE2] where empno = @EMPNO and DHPID=@DHPID">

                        <SelectParameters>
                            <asp:SessionParameter Name="DHPID" SessionField="dhp_id" Type="String" />
                            <asp:SessionParameter Name="EMPNO" SessionField="dhpempno" Type="String" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                    <asp:Panel ID="Panel2" runat="server" ScrollBars="Auto">
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
                    </asp:Panel>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>

    </div>

</asp:Content>
