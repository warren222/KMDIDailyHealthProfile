<%@ Page Language="C#" MasterPageFile="~/DAILYHEALTHPROFILE/DHPmaster.Master" AutoEventWireup="true" CodeBehind="dhppage2.aspx.cs" Inherits="webaftersales.DAILYHEALTHPROFILE.dhppage2" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>Dgp PAGE 2</title>
</asp:Content>

<asp:Content ID="content2" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <div class="well">
        <h3><strong>Page 2</strong></h3>
        <div class="navbar-right">
            <asp:LinkButton ID="LinkButton1" CssClass="btn btn-default" PostBackUrl="~/DAILYHEALTHPROFILE/dhphome.aspx" runat="server">back</asp:LinkButton>
        </div>
    </div>
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <h3 class="text-info">EMPLOYEE DAILY HEALTH PROFILE</h3>
    <h4>RECORD DATE:
            <asp:Label ID="lbldate" runat="server" Text="Label"></asp:Label></h4>
    <blockquote>
        <h4>
            <table border="0">
                <tr>
                    <td class="text-muted">NAME
                    </td>
                    <td>
                        <asp:Label ID="lblname" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="text-muted">EMPLOYEE NO.
                    </td>
                    <td>
                        <asp:Label ID="lblempno" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="text-muted">BIRTHDATE
                    </td>
                    <td>
                        <asp:Label ID="lblbirthday" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="text-muted">AGE
                    </td>
                    <td>
                        <asp:Label ID="lblage" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
            </table>
        </h4>
    </blockquote>

    <asp:ValidationSummary ID="ValidationSummary4" CssClass="alert alert-danger" ValidationGroup="mainval" runat="server" />
    <h4>(To be used when a sudden feeling/sensation or symptom is exhibited during working hours – before and during isolation as the case may be)</h4>
    <h3><strong>CONCISE CLINICAL HISTORY</strong></h3>
    <strong>Travel History/Record:</strong>&nbsp;<label class="text-success">(please indicate previous day’s sequence of movement)</label>
    <br />
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <div class=" container">
                <asp:Panel ID="pnl1" runat="server">
                    <div class="input-group">
                        <asp:DropDownList CssClass="form-control" Height="35" ID="dltravelhistory" runat="server">
                            <asp:ListItem Value="home">home</asp:ListItem>
                            <asp:ListItem Value="school">school</asp:ListItem>
                            <asp:ListItem Value="work">work</asp:ListItem>
                            <asp:ListItem Value="drugstore">drugstore</asp:ListItem>
                            <asp:ListItem Value="hospital / clinic">hospital / clinic</asp:ListItem>
                            <asp:ListItem Value="wet market">wet market</asp:ListItem>
                            <asp:ListItem Value="grocery store">grocery store</asp:ListItem>
                            <asp:ListItem Value="gym">gym</asp:ListItem>
                            <asp:ListItem Value="church">church</asp:ListItem>
                        </asp:DropDownList>
                        <div class="input-group-btn">
                            <asp:LinkButton ID="LinkButton4" Height="35" CssClass="btn btn-default" runat="server" OnClick="LinkButton4_Click">add</asp:LinkButton>
                        </div>
                    </div>
                    <br />
                    <div class="input-group">
                        <div class="input-group-addon">Others</div>
                        <asp:TextBox ID="tboxother" CssClass="form-control" runat="server"></asp:TextBox>
                        <div class="input-group-btn">
                            <asp:LinkButton ID="LinkButton5" CssClass="btn btn-default" runat="server" OnClick="LinkButton5_Click">add</asp:LinkButton>
                        </div>
                    </div>
                </asp:Panel>
            </div>

            <br />
            <asp:ValidationSummary ID="ValidationSummary3" ValidationGroup="travelval" CssClass="alert alert-danger" runat="server" />
            <asp:GridView ID="GridView1" AllowPaging="true" CssClass="table" runat="server" AutoGenerateColumns="false" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCommand="GridView1_RowCommand">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton CommandName="myedit" ID="btnedit" runat="server">Edit</asp:LinkButton>
                            <asp:LinkButton CommandName="mydelete" ID="btndelete" OnClientClick="return confirm('delete this record')" runat="server">Delete</asp:LinkButton>
                            <asp:LinkButton CommandName="myupdate" ID="btnupdate" Visible="false" runat="server">Update</asp:LinkButton>
                            <asp:LinkButton CommandName="mycancel" ID="btncancel" Visible="false" runat="server">Cancel</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Sorting">
                        <ItemTemplate>
                            <asp:Label ID="lblid" Visible="false" runat="server" Text='<%# Bind("ID") %>'></asp:Label>
                            <asp:Label ID="lblsorting" runat="server" Text='<%# Bind("SORTING") %>'></asp:Label>
                            <asp:TextBox ID="tboxsorting" Visible="false" Width="70" TextMode="Number" CssClass="form-control" Text='<%# Bind("SORTING") %>' runat="server"></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Travel History">
                        <ItemTemplate>
                            <asp:Label ID="lbltravelhistory" runat="server" Text='<%# Bind("TRAVELHISTORY") %>'></asp:Label>
                            <asp:TextBox ID="tboxtravelhistory" Visible="false" CssClass="form-control" Text='<%# Bind("TRAVELHISTORY") %>' runat="server"></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <EmptyDataTemplate>
                    <div class="alert alert-info">
                        <h3><strong>Travel History is Empty!</strong>
                        </h3>
                    </div>
                </EmptyDataTemplate>
                <EditRowStyle BorderStyle="None" BorderWidth="0px" />
                <PagerSettings PageButtonCount="8" />
                <PagerStyle CssClass="GridPager" HorizontalAlign="Left" />
            </asp:GridView>

            <div class="alert alert-success" style="text-wrap: avoid">
                <h4>
                    <asp:Label ID="lbltravelsummary" runat="server"></asp:Label></h4>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
        <ContentTemplate>
            <h3><strong class="text-info">Mga taong nakasama/nakasalamuha</strong></h3>
            <div class="container">
                <blockquote>
                    Full name:<br />
                    <asp:TextBox ID="tboxfullname" placeholder="Full name" CssClass="form-control" runat="server"></asp:TextBox><br />
                    <asp:Button ID="Button2" CssClass="btn btn-primary" ValidationGroup="g2" runat="server" Text="add" OnClick="Button2_Click" />
                </blockquote>
                <asp:ValidationSummary ID="ValidationSummary5" CssClass="alert alert-danger" ValidationGroup="g2" runat="server" />
            </div>
            <br />
            <asp:GridView ID="GridView2" runat="server" CssClass="table" AllowPaging="True" AutoGenerateColumns="False" OnPageIndexChanging="GridView2_PageIndexChanging" OnRowCommand="GridView2_RowCommand">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="btneditg2" CommandName="myedit" runat="server">Edit</asp:LinkButton>
                            <asp:LinkButton ID="btndeleteg2" CommandName="mydelete" OnClientClick="return confirm('delete this record?')" runat="server">Delete</asp:LinkButton>
                            <asp:LinkButton ID="btnupdateg2" Visible="false" CommandName="myupdate" runat="server">Update</asp:LinkButton>
                            <asp:LinkButton ID="btncancelg2" Visible="false" CommandName="mycancel" runat="server">Cancel</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Full name">
                        <ItemTemplate>
                            <asp:Label ID="lblidg2" runat="server" Text='<%# Bind("ID") %>' Visible="false"></asp:Label>
                            <asp:Label ID="lblfullnameg2" runat="server" Text='<%# Bind("FULLNAME") %>'></asp:Label>
                            <asp:TextBox ID="tboxfullnameg2" Visible="false" CssClass="form-control" Text='<%# Bind("FULLNAME") %>' runat="server"></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <EmptyDataTemplate>
                    <div class="alert alert-info">
                        <h3><strong>Travel History is Empty!</strong>
                        </h3>
                    </div>
                </EmptyDataTemplate>
                <EditRowStyle BorderStyle="None" BorderWidth="0px" />
                <PagerSettings PageButtonCount="8" />
                <PagerStyle CssClass="GridPager" HorizontalAlign="Left" />
            </asp:GridView>
        </ContentTemplate>
    </asp:UpdatePanel>
    <br />
    <strong>Possible Exposure to Virus:</strong>&nbsp;<label class="text-success">(Please record possible incident where the patient/ employee could’ve contracted the virus)</label>
    <asp:TextBox ID="tboxexposuretovirus" CssClass="form-control" TextMode="MultiLine" Rows="10" runat="server"></asp:TextBox>
    <h3>
        <label style="text-decoration: underline">TEST RESULTS (if applicable)</label></h3>
    <div class="row">
        <div class="col-sm-6">
            <asp:Panel ID="pnl2" runat="server">
                <table>
                    <tr>
                        <td>DATE OF TEST DONE
                        </td>
                        <td>
                            <asp:TextBox ID="tboxdatetestdone" TextMode="Date" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>Time of Test
                        </td>
                        <td>
                            <asp:TextBox ID="tboxtimetest" TextMode="Time" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>Test Kit Serial Number
                        </td>
                        <td>
                            <asp:TextBox ID="tboxserialno" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                </table>

                <div class="container">
                    <blockquote>
                        <asp:CheckBoxList ID="cboxTESTRESULT" runat="server">
                            <asp:ListItem Value="IgM Negative">IgM Negative</asp:ListItem>
                            <asp:ListItem Value="IgM POSITIVE">IgM POSITIVE</asp:ListItem>
                            <asp:ListItem Value="IgG Negative">IgG Negative</asp:ListItem>
                            <asp:ListItem Value="IgG POSITIVE">IgG POSITIVE</asp:ListItem>
                        </asp:CheckBoxList>
                    </blockquote>
                </div>
            </asp:Panel>
            Patient Name:<asp:LinkButton ID="LinkButton3" runat="server" OnClick="LinkButton3_Click">Sign here...</asp:LinkButton>
            <asp:TextBox ID="tboxpatientname" CssClass="form-control" placeholder="Patient Name" runat="server"></asp:TextBox><br />
            <asp:Panel ID="Panel1" runat="server"></asp:Panel>
            <br />
        </div>
        <div class="col-sm-6">
            <asp:Panel ID="pnl5" runat="server">
                <label class="btn btn-default">
                    <span><strong>Please attach photo of test result:</strong></span>
                    <asp:FileUpload ID="FileUpload1" runat="server" AllowMultiple="True"></asp:FileUpload>
                </label>

                <asp:ValidationSummary ValidationGroup="g1" CssClass="alert alert-danger" ID="ValidationSummary1" runat="server" />
                <asp:Button ID="Button1" runat="server" Text="Upload Image" ValidationGroup="g1" CssClass="btn btn-default" OnClick="Button1_Click" />
            </asp:Panel>
            <asp:Panel ID="Panel2" runat="server" BackColor="#CCCCCC"></asp:Panel>

            <asp:Panel ID="pnl3" runat="server">
                Confirming Physician:<asp:LinkButton ID="LinkButton6" runat="server" OnClick="LinkButton6_Click">Sign here...</asp:LinkButton><br />
                <asp:Panel ID="pnlphysician" runat="server"></asp:Panel>
                <asp:TextBox CssClass="form-control" ID="tboxphysician" placeholder="Confirming Physician" runat="server"></asp:TextBox><br />
                Test Administered by:<asp:LinkButton ID="LinkButton7" runat="server" OnClick="LinkButton7_Click">Sign here...</asp:LinkButton><br />
                <asp:Panel ID="pnladministered" runat="server"></asp:Panel>
                <asp:TextBox CssClass="form-control" ID="tboxadministeredby" placeholder="Test Administered" runat="server"></asp:TextBox>
            </asp:Panel>
        </div>
    </div>
    <h3><strong>Possible Recommendation(s) after Isolation (if applicable)</strong> </h3>
    <asp:Panel ID="pnl4" runat="server">
        <div class="container">
            <blockquote>
                <asp:CheckBox ID="cboxrecoendo" Text="Endorse to respective LGU : " runat="server" /><asp:TextBox ID="tboxrecoendo" CssClass="form-control" runat="server"></asp:TextBox><br />
                <asp:CheckBox ID="cboxrecocallin" Text="Call in for medical Attention and / or endorsement to hospital specify:" runat="server" /><asp:TextBox ID="tboxrecocallin" CssClass="form-control" runat="server"></asp:TextBox><br />
                <asp:CheckBox ID="cboxrecosendhome" Text="Send home" runat="server" /><br />
                <asp:CheckBox ID="cboxrecoother" Text="Others:" runat="server" /><asp:TextBox ID="tboxrecoother" CssClass="form-control" runat="server"></asp:TextBox><br />
                Patient Name:<asp:LinkButton ID="LinkButton8" runat="server" OnClick="LinkButton8_Click">Sign here...</asp:LinkButton>
                <asp:Panel ID="pnlpatientreco" runat="server"></asp:Panel>
                <asp:TextBox ID="tboxrecopatient" CssClass="form-control" placeholder="Patient Name" runat="server"></asp:TextBox><br />
            </blockquote>
        </div>
    </asp:Panel>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:ValidationSummary ID="ValidationSummary2" ValidationGroup="val2" CssClass="alert alert-success" runat="server" />
            <asp:LinkButton ID="LinkButton2" CssClass="btn btn-primary" runat="server" OnClick="LinkButton2_Click">save page 2</asp:LinkButton>

        </ContentTemplate>
    </asp:UpdatePanel>


</asp:Content>
