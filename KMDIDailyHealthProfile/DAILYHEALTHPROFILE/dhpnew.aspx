﻿<%@ Page Language="C#" MasterPageFile="~/DAILYHEALTHPROFILE/DHPmaster.Master" AutoEventWireup="true" CodeBehind="dhpnew.aspx.cs" Inherits="webaftersales.DAILYHEALTHPROFILE.dhpnew" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>DHP page 1</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="well">
        <h3><strong>Page 1</strong></h3>
        <div class="navbar-right">
            <asp:LinkButton ID="LinkButton1" CssClass="btn btn-default" runat="server" OnClick="LinkButton1_Click">back</asp:LinkButton>
        </div>
    </div>
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="panel">
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
        <br />
        <h4><strong>Body Temperature Records for the day:</strong>&nbsp;<span class="text-info">(mga temperatura ng katawan para sa araw)</span> </h4>


        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>

                <blockquote>
                    <table class="table" border="0" style="white-space: nowrap;">
                        <tr>
                            <td>Time of day
                            </td>
                            <td>
                                <asp:DropDownList ID="cboxaddontimeofday" CssClass="form-control" runat="server">
                                    <asp:ListItem Value="Upon arrival at work"></asp:ListItem>
                                    <asp:ListItem Value="While at work"></asp:ListItem>
                                    <asp:ListItem Value="Before leaving work"></asp:ListItem>
                                    <asp:ListItem Value="Outside of work"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>Actual Time Taken
                            </td>
                            <td>
                                <asp:TextBox ID="tboxaddonatt" CssClass="form-control" TextMode="Time" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ControlToValidate="tboxaddonatt" ID="RequiredFieldValidator1" runat="server" ValidationGroup="addonval"
                                    ErrorMessage="Actual Time Taken is required!" ForeColor="Red">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>Temperature Reading (˚C)
                            </td>
                            <td>
                                <asp:TextBox ID="tboxaddontr" CssClass="form-control" Text="0" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="tboxaddontr" runat="server" ForeColor="Red"
                                    ErrorMessage="Temperature Reading (˚C) is required" ValidationGroup="addonval">*</asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ControlToValidate="tboxaddontr" ValidationExpression="^\d+([,\.]\d{1,1})?$" ForeColor="Red"
                                    ID="RegularExpressionValidator5" runat="server" ValidationGroup="addonval" ErrorMessage="temperature must be one decimal place">*</asp:RegularExpressionValidator>
                            </td>
                        </tr>
                        <tr>

                            <td colspan="2">
                                <asp:Button ID="Button1" ValidationGroup="addonval" CssClass="btn btn-primary" runat="server" Text="add" OnClick="Button1_Click" />
                            </td>
                        </tr>

                    </table>
                </blockquote>

                <asp:ValidationSummary ID="ValidationSummary3" CssClass="alert alert-danger" ValidationGroup="addonval" runat="server" />

                <asp:Panel ID="Panel4" runat="server" ScrollBars="Auto">
                    <asp:GridView ID="GridView1" CssClass="table" runat="server" AllowPaging="True" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand" OnPageIndexChanging="GridView1_PageIndexChanging">
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="btnedit" CommandName="myedit" runat="server">Edit</asp:LinkButton>
                                    <asp:LinkButton ID="btndelete" CommandName="mydelete" OnClientClick="return confirm('delete this record')" runat="server">Delete</asp:LinkButton>
                                    <asp:LinkButton ID="btnupdate" ValidationGroup="addoneditval" Visible="false" CommandName="myupdate" runat="server">Update</asp:LinkButton>
                                    <asp:LinkButton ID="btncancel" Visible="false" CommandName="mycancel" runat="server">Cancel</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Time of day">
                                <ItemTemplate>
                                    <asp:Label ID="lblid" Visible="false" runat="server" Text='<%# Bind("ID") %>'></asp:Label>
                                    <asp:Label ID="lbltimeofday" runat="server" Text='<%# Bind("TIMEOFDAY") %>'></asp:Label>
                                    <asp:DropDownList ID="cboxeditaddontimeofday" Width="300" Visible="false" Text='<%# Bind("TIMEOFDAY") %>' CssClass="form-control" runat="server">
                                        <asp:ListItem Value="Upon arrival at work"></asp:ListItem>
                                        <asp:ListItem Value="While at work"></asp:ListItem>
                                        <asp:ListItem Value="Before leaving work"></asp:ListItem>
                                        <asp:ListItem Value="Outside of work"></asp:ListItem>
                                    </asp:DropDownList>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Actual Time Taken">
                                <ItemTemplate>
                                    <asp:Label ID="lblatt" runat="server" Text='<%# Bind("ACTUALTIMETAKEN") %>'></asp:Label>
                                    <asp:TextBox ID="tboxeditaddonatt" Visible="false" Text='<%# Bind("ACTUALTIMETAKEN") %>' CssClass="form-control" TextMode="Time" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator Visible="false" ControlToValidate="tboxeditaddonatt" ID="RequiredFieldValidator143" runat="server" ValidationGroup="addoneditval"
                                        ErrorMessage="Actual Time Taken is required!" ForeColor="Red">*</asp:RequiredFieldValidator>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Temperature Reading (˚C)">
                                <ItemTemplate>
                                    <asp:Label ID="lbltr" runat="server" Text='<%# Bind("TEMPREADING") %>'></asp:Label>
                                    <asp:TextBox ID="tboxeditaddontr" Text='<%# Bind("TEMPREADING") %>' Visible="false" CssClass="form-control" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator442" Visible="false" ControlToValidate="tboxeditaddontr" runat="server" ForeColor="Red"
                                        ErrorMessage="Temperature Reading (˚C) is required" ValidationGroup="addoneditval">*</asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator Visible="false" ControlToValidate="tboxeditaddontr" ValidationExpression="^\d+([,\.]\d{1,1})?$" ForeColor="Red"
                                        ID="RegularExpressionValidator5" runat="server" ValidationGroup="addoneditval" ErrorMessage="temperature must be one decimal place"></asp:RegularExpressionValidator>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <HeaderStyle Wrap="False" />
                        <RowStyle Wrap="False" />
                        <EmptyDataTemplate>
                            <div class="alert alert-warning">
                                <h3><strong>Empty Table!</strong>
                                </h3>
                            </div>
                        </EmptyDataTemplate>
                        <EditRowStyle BorderStyle="None" BorderWidth="0px" />
                        <PagerSettings PageButtonCount="8" />
                        <PagerStyle CssClass="GridPager" HorizontalAlign="Left" />
                    </asp:GridView>

                </asp:Panel>
                <asp:ValidationSummary ID="ValidationSummary4" CssClass="alert alert-danger" ValidationGroup="addoneditval" runat="server" />

            </ContentTemplate>
        </asp:UpdatePanel>


        <%--  <h4>(To be used when a sudden feeling/sensation or symptom is exhibited during working hours – before and during isolation as the case may be)</h4>--%>
        <h3><strong>CONCISE CLINICAL HISTORY</strong></h3>
        <strong>Travel History/Record:</strong>&nbsp;<span class="text-success">(please indicate previous day’s sequence of movement)</span>&nbsp;<span class="text-info">(ihayag ang pagkasunod sunod ng mga pinuntahan noong mga nakaraang araw)</span>
        <br />
        <asp:UpdatePanel ID="UpdatePanel5" runat="server">
            <ContentTemplate>
                <div class=" container">
                    <asp:Panel ID="pnl1" runat="server">
                        <table border="0" style="width: 100%">
                            <tr>
                                <td class="text-info">DATE: 
                                    <asp:TextBox ID="tboxinputdt" TextMode="Date" CssClass="form-control" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ValidationGroup="travelval" ID="RequiredFieldValidator6" ControlToValidate="tboxinputdt" runat="server" ForeColor="red" ErrorMessage="date is required">*</asp:RequiredFieldValidator>
                                </td>
                                <td class="text-info">TIME:
                            <asp:TextBox ID="tboxinputtm" CssClass="form-control" TextMode="Time" runat="server"></asp:TextBox>
                                    <br />
                                </td>
                            </tr>
                        </table>


                        <div class="input-group">
                            <asp:DropDownList CssClass="form-control" Height="35" ID="dltravelhistory" runat="server">
                                <asp:ListItem Value="Home">Home</asp:ListItem>
                                <asp:ListItem Value="School">School</asp:ListItem>
                                <asp:ListItem Value="Work">Work</asp:ListItem>
                                <asp:ListItem Value="Bank">Bank</asp:ListItem>
                                <asp:ListItem Value="Food joint / Restaurant">Food joint / Restaurant</asp:ListItem>
                                <asp:ListItem Value="Drive-thru">Drive-thru</asp:ListItem>
                                <asp:ListItem Value="Drugstore">Drugstore</asp:ListItem>
                                <asp:ListItem Value="Hospital / Clinic">Hospital / Clinic</asp:ListItem>
                                <asp:ListItem Value="Wet market">Wet market</asp:ListItem>
                                <asp:ListItem Value="Grocery store">Grocery store</asp:ListItem>
                                <asp:ListItem Value="Gym">Gym</asp:ListItem>
                                <asp:ListItem Value="Church">Church</asp:ListItem>
                            </asp:DropDownList>
                            <div class="input-group-btn">
                                <asp:LinkButton ID="LinkButton4" ValidationGroup="travelval" Height="35" CssClass="btn btn-default" runat="server" OnClick="LinkButton4_Click">add</asp:LinkButton>
                            </div>
                        </div>
                        <br />
                        <div class="input-group">
                            <div class="input-group-addon">Name of place</div>
                            <asp:TextBox ID="tboxother" CssClass="form-control" runat="server"></asp:TextBox>
                            <div class="input-group-btn">
                                <asp:LinkButton ID="LinkButton5" ValidationGroup="travelval" CssClass="btn btn-default" runat="server" OnClick="LinkButton5_Click">add</asp:LinkButton>
                            </div>
                        </div>
                    </asp:Panel>
                </div>

                <br />
                <asp:ValidationSummary ID="ValidationSummary6" ValidationGroup="travelval" CssClass="alert alert-danger" runat="server" />
                <asp:Panel ID="Panel5" runat="server" ScrollBars="Auto">
                    <asp:GridView ID="GridView3" AllowPaging="true" CssClass="table" runat="server" AutoGenerateColumns="false" OnPageIndexChanging="GridView3_PageIndexChanging" OnRowCommand="GridView3_RowCommand">
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
                            <asp:TemplateField HeaderText="Date">
                                <ItemTemplate>
                                    <asp:Label ID="lbldt" runat="server" Text='<%# Bind("DT") %>'></asp:Label>
                                    <asp:TextBox ID="tboxdt" Visible="false" TextMode="Date" CssClass="form-control" Text='<%# Bind("DT") %>' runat="server"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Time">
                                <ItemTemplate>
                                    <asp:Label ID="lbltm" runat="server" Text='<%# Bind("TM") %>'></asp:Label>
                                    <asp:TextBox ID="tboxtm" Visible="false" TextMode="Time" CssClass="form-control" Text='<%# Bind("TM") %>' runat="server"></asp:TextBox>
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
                            <div class="alert alert-warning">
                                <h3><strong>Travel History is Empty!</strong>
                                </h3>
                            </div>
                        </EmptyDataTemplate>
                        <EditRowStyle BorderStyle="None" BorderWidth="0px" />
                        <PagerSettings PageButtonCount="8" />
                        <PagerStyle CssClass="GridPager" HorizontalAlign="Left" />
                    </asp:GridView>
                </asp:Panel>
                <div class="alert alert-success" style="text-wrap: avoid">
                    <h4>
                        <asp:Label ID="lbltravelsummary" runat="server"></asp:Label></h4>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>


        <asp:UpdatePanel ID="UpdatePanel9" runat="server">
            <ContentTemplate>
                <h3><strong class="text-info">Mga taong nakasama/nakasalamuha</strong></h3>
                <div class="container">
                    <blockquote>
                        Full name:<br />
                        <asp:TextBox ID="tboxfullname" placeholder="Full name" CssClass="form-control" runat="server"></asp:TextBox><br />
                        Date:<br />
                        <asp:TextBox ID="tboxdate" TextMode="Date" CssClass="form-control" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" ControlToValidate="tboxdate"  ValidationGroup="g2"  runat="server" ErrorMessage="date is required" ForeColor="Red">*</asp:RequiredFieldValidator>
                       <br />
                        Remarks:<br />
                        <asp:TextBox ID="tboxremarkstransaction" CssClass="form-control" runat="server"></asp:TextBox><br />
                        <asp:Button ID="Button4" CssClass="btn btn-primary" ValidationGroup="g2" runat="server" Text="add" OnClick="Button4_Click" />
                    </blockquote>
                    <asp:ValidationSummary ID="ValidationSummary7" CssClass="alert alert-danger" ValidationGroup="g2" runat="server" />
                </div>
                <br />
                <asp:GridView ID="GridView6" runat="server" CssClass="table" AllowPaging="True" AutoGenerateColumns="False" OnRowCommand="GridView6_RowCommand" OnPageIndexChanging="GridView6_PageIndexChanging">
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
                        <asp:TemplateField HeaderText="Date">
                            <ItemTemplate>
                                <asp:Label ID="lbldated" runat="server" Text='<%# Bind("DATED") %>'></asp:Label>
                                <asp:TextBox ID="tboxdateedit" TextMode="Date" CssClass="form-control" Text='<%# Bind("DATED") %>' Visible="false" runat="server"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Remarks/Details">
                            <ItemTemplate>
                                <asp:Label ID="lblremarks" runat="server" Text='<%# Bind("REMARKS") %>'></asp:Label>
                                <asp:TextBox ID="tboxremarksedit" Text='<%# Bind("REMARKS") %>' CssClass="form-control" Visible="false" runat="server"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <EmptyDataTemplate>
                        <div class="alert alert-warning">
                            <h3><strong>Contact tracing is Empty!</strong>
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
        <h4>Possible COVID 19 signs/symptoms experienced in the last 24 hours. Indicate date and estimated time only if answer to any of the symptoms is Yes:  
        </h4>
        <div class="text-info">(Mga posibleng senyales o sintomas na naranasan sa nakaraang 24 oras. )</div>
        <br />
        <asp:UpdatePanel ID="UpdatePanel4" runat="server">
            <ContentTemplate>


                <asp:Panel ID="Panel2" runat="server" ScrollBars="Auto">
                    <table border="1" style="white-space: nowrap;" class="table table-striped table-dark text-center">
                        <tr>
                            <td>
                                <strong>SIGN/SYMPTOM</strong>
                                <br />
                                <small class="text-info">(Senyales/Sintomas)</small>
                            </td>
                            <td>
                                <strong>Experienced</strong>
                                <br />
                                <small class="text-info">(Naranasan)</small><br />
                                YES | NO
                            </td>
                            <td>
                                <strong>Date of Onset</strong>
                                <br />
                                <small class="text-info">(mm/dd/yy)</small>
                            </td>
                            <td>
                                <strong>Estimated Time
                            <br />
                                    of Onset</strong>
                                <br />
                                <small class="text-info">(H:M)</small>
                            </td>
                            <td style="width: 350px; min-width: 350px;">
                                <strong>REMARKS</strong>
                                <br />
                                <small class="text-info">(Paglalahad)</small>
                            </td>
                        </tr>
                        <tr>
                            <td><strong>COUGH</strong><br />
                                <small class="text-info">(tuyo o matigas na ubo)</small>
                            </td>
                            <td>
                                <asp:RadioButton CssClass="btn btn-default" GroupName="DCEX" ID="DCEXyes" runat="server" />&nbsp;&nbsp;<asp:RadioButton CssClass="btn btn-default" GroupName="DCEX" ID="DCEXno" runat="server" /></td>
                            <td>
                                <asp:TextBox ID="tboxDCDO" TextMode="Date" CssClass="form-control" runat="server"></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="tboxDCET" TextMode="Time" CssClass="form-control" runat="server"></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="tboxDCRE" CssClass="form-control" runat="server"></asp:TextBox></td>

                        </tr>
                        <tr>
                            <td><strong>FEVER</strong><br />
                                <small class="text-info">(lagnat – 37.5˚ o higit pa ↑)</small>
                            </td>
                            <td>
                                <asp:RadioButton CssClass="btn btn-default" GroupName="FEEX" ID="FEEXyes" runat="server" />&nbsp;&nbsp;<asp:RadioButton CssClass="btn btn-default" GroupName="FEEX" ID="FEEXno" runat="server" />
                            </td>
                            <td>
                                <asp:TextBox ID="tboxFEDO" TextMode="Date" CssClass="form-control" runat="server"></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="tboxFEET" TextMode="Time" CssClass="form-control" runat="server"></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="tboxFERE" CssClass="form-control" runat="server"></asp:TextBox></td>

                        </tr>
                        <tr>
                            <td><strong>MUSCLE PAIN</strong><br />
                                <small class="text-info">(pananakit ng kalamnan)</small>
                            </td>
                            <td>
                                <asp:RadioButton CssClass="btn btn-default" GroupName="MPEX" ID="MPEXyes" runat="server" />&nbsp;&nbsp;<asp:RadioButton CssClass="btn btn-default" GroupName="MPEX" ID="MPEXno" runat="server" /></td>
                            <td>
                                <asp:TextBox ID="tboxMPDO" TextMode="Date" CssClass="form-control" runat="server"></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="tboxMPET" TextMode="Time" CssClass="form-control" runat="server"></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="tboxMPRE" CssClass="form-control" runat="server"></asp:TextBox></td>

                        </tr>
                        <tr>
                            <td><strong>WEAKNESS</strong><br />
                                <small class="text-info">((panghihina))</small>
                            </td>
                            <td>
                                <asp:RadioButton CssClass="btn btn-default" GroupName="WEEX" ID="WEEXyes" runat="server" />&nbsp;&nbsp;<asp:RadioButton CssClass="btn btn-default" GroupName="WEEX" ID="WEEXno" runat="server" /></td>
                            <td>
                                <asp:TextBox ID="tboxWEDO" TextMode="Date" CssClass="form-control" runat="server"></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="tboxWEET" TextMode="Time" CssClass="form-control" runat="server"></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="tboxWERE" CssClass="form-control" runat="server"></asp:TextBox></td>

                        </tr>
                        <tr>
                            <td><strong>DECREASED SENSE<br />
                                OF SMELL</strong><br />
                                <small class="text-info">(kawalan ng pang-amoy)</small>
                            </td>
                            <td>
                                <asp:RadioButton CssClass="btn btn-default" GroupName="DSEX" ID="DSEXyes" runat="server" />&nbsp;&nbsp;<asp:RadioButton CssClass="btn btn-default" GroupName="DSEX" ID="DSEXno" runat="server" />
                            </td>
                            <td>
                                <asp:TextBox ID="tboxDSDO" TextMode="Date" CssClass="form-control" runat="server"></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="tboxDSET" TextMode="Time" CssClass="form-control" runat="server"></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="tboxDSRE" CssClass="form-control" runat="server"></asp:TextBox></td>

                        </tr>
                        <tr>
                            <td><strong>DECREASED SENSE<br />
                                OF TASTE</strong><br />
                                <small class="text-info">(kawalan ng panlasa)</small>
                            </td>
                            <td>
                                <asp:RadioButton CssClass="btn btn-default" GroupName="DTEX" ID="DTEXyes" runat="server" />&nbsp;&nbsp;<asp:RadioButton CssClass="btn btn-default" GroupName="DTEX" ID="DTEXno" runat="server" />
                            </td>
                            <td>
                                <asp:TextBox ID="tboxDTDO" TextMode="Date" CssClass="form-control" runat="server"></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="tboxDTET" TextMode="Time" CssClass="form-control" runat="server"></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="tboxDTRE" CssClass="form-control" runat="server"></asp:TextBox></td>

                        </tr>
                        <tr>
                            <td><strong>DIARRHEA/LBM</strong><br />
                                <small class="text-info">(pagtatae)</small>
                            </td>
                            <td>
                                <asp:RadioButton CssClass="btn btn-default" GroupName="DIEX" ID="DIEXyes" runat="server" AutoPostBack="True" OnCheckedChanged="DIEXyes_CheckedChanged" />&nbsp;&nbsp;<asp:RadioButton CssClass="btn btn-default" GroupName="DIEX" ID="DIEXno" runat="server" AutoPostBack="True" OnCheckedChanged="DIEXyes_CheckedChanged" />
                            </td>
                            <td>
                                <asp:TextBox ID="tboxDIDO" TextMode="Date" CssClass="form-control" runat="server"></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="tboxDIET" TextMode="Time" CssClass="form-control" runat="server"></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="tboxDIRE" CssClass="form-control" runat="server"></asp:TextBox></td>

                        </tr>
                        <tr>
                            <td><strong>DIFFICULTY OF<br />
                                BREATHING</strong><br />
                                <small class="text-info">(hirap na paghinga)</small>
                            </td>
                            <td>
                                <asp:RadioButton CssClass="btn btn-default" GroupName="DBEX" ID="DBEXyes" runat="server" />&nbsp;&nbsp;<asp:RadioButton CssClass="btn btn-default" GroupName="DBEX" ID="DBEXno" runat="server" />
                            </td>
                            <td>
                                <asp:TextBox ID="tboxDBDO" TextMode="Date" CssClass="form-control" runat="server"></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="tboxDBET" TextMode="Time" CssClass="form-control" runat="server"></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="tboxDBRE" CssClass="form-control" runat="server"></asp:TextBox></td>

                        </tr>
                        <tr>
                            <td><strong>VOMITING
                      
                            </strong>
                                <br />
                                <small class="text-info">(pagsusuka)</small>
                            </td>
                            <td>
                                <asp:RadioButton CssClass="btn btn-default" GroupName="VOEX" ID="VOEXyes" runat="server" AutoPostBack="True" OnCheckedChanged="DIEXyes_CheckedChanged" />&nbsp;&nbsp;<asp:RadioButton CssClass="btn btn-default" GroupName="VOEX" ID="VOEXno" runat="server" AutoPostBack="True" OnCheckedChanged="DIEXyes_CheckedChanged" />
                            </td>
                            <td>
                                <asp:TextBox ID="tboxVODO" TextMode="Date" CssClass="form-control" runat="server"></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="tboxVOET" TextMode="Time" CssClass="form-control" runat="server"></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="tboxVORE" CssClass="form-control" runat="server"></asp:TextBox></td>

                        </tr>
                        <tr>
                            <td><strong>COLDS
                      
                            </strong>
                                <br />
                                <small class="text-info">(Sipon)</small>
                            </td>
                            <td>
                                <asp:RadioButton CssClass="btn btn-default" GroupName="COEX" ID="COEXyes" runat="server" />&nbsp;&nbsp;<asp:RadioButton CssClass="btn btn-default" GroupName="COEX" ID="COEXno" runat="server" />
                            </td>
                            <td>
                                <asp:TextBox ID="tboxCODO" TextMode="Date" CssClass="form-control" runat="server"></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="tboxCOET" TextMode="Time" CssClass="form-control" runat="server"></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="tboxCORE" CssClass="form-control" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td><strong>OTHER SYMPTOM(s)</strong><br />
                                <asp:TextBox ID="tboxOS" CssClass="form-control" runat="server"></asp:TextBox>
                                <small class="text-info">(Iba pang kakaibang
                            <br />
                                    karamdaman)</small>
                            </td>
                            <td>
                                <asp:RadioButton CssClass="btn btn-default" GroupName="OSEX" ID="OSEXyes" runat="server" />&nbsp;&nbsp;<asp:RadioButton CssClass="btn btn-default" GroupName="OSEX" ID="OSEXno" runat="server" />
                            </td>
                            <td>
                                <asp:TextBox ID="tboxOSDO" TextMode="Date" CssClass="form-control" runat="server"></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="tboxOSET" TextMode="Time" CssClass="form-control" runat="server"></asp:TextBox></td>
                            <td>
                                <asp:TextBox ID="tboxOSRE" CssClass="form-control" runat="server"></asp:TextBox></td>

                        </tr>
                    </table>
                </asp:Panel>
            </ContentTemplate>
        </asp:UpdatePanel>


        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
            <ContentTemplate>
                <br />
                <asp:Panel ID="DIEPNL" runat="server">
                    <h4><span class="text-danger">Kung may DIARRHEA at VOMITING,</span> <span class="text-info">gamitin ang form na ito upang mai-record ang ibat-ibang oras ng DIARRHEA (pagtatae) at VOMITING (pagsusuka)</span></h4>
                    <div class="container">
                        <blockquote>
                            <strong>SIGN/SYMPTOM</strong><small class="text-danger">(Senyales/Sintomas)</small>
                            <br />
                            <asp:DropDownList ID="ddlsymptom" CssClass="form-control" runat="server">
                                <asp:ListItem Value="DIARRHEA (pagtate)">DIARRHEA (pagtatae)</asp:ListItem>
                                <asp:ListItem Value="VOMITING (pagsusuka)">VOMITING (pagsusuka)</asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ControlToValidate="ddlsymptom" ValidationGroup="symptonval" ID="RequiredFieldValidator3" runat="server"
                                ErrorMessage="SIGN/SYMPTOM is required!" ForeColor="Red">*</asp:RequiredFieldValidator>
                            <br />
                            <strong>Date of Onset</strong><small class="text-danger">(mm/dd/yyyy)</small><br />
                            <asp:TextBox ID="tboxdateofonset" TextMode="Date" CssClass="form-control" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ControlToValidate="tboxdateofonset" ValidationGroup="symptonval" ID="RequiredFieldValidator4" runat="server"
                                ErrorMessage="Date of Onset is required!" ForeColor="Red">*</asp:RequiredFieldValidator>
                            <br />
                            <strong>Estimated Time of Onset</strong>  <small class="text-danger">(H:M)</small>
                            <br />
                            <asp:TextBox ID="tboxtimeonset" TextMode="Time" CssClass="form-control" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ControlToValidate="tboxtimeonset" ValidationGroup="symptonval" ID="RequiredFieldValidator5" runat="server"
                                ErrorMessage="Estimated Time of Onset is required!" ForeColor="Red">*</asp:RequiredFieldValidator>
                            <br />
                            <strong>REMARKS</strong> <small class="text-danger">(Paglalahad)</small><br />
                            <asp:TextBox ID="tboxremarks" CssClass="form-control" runat="server"></asp:TextBox>

                            <br />
                            <asp:Button ID="Button3" CssClass="btn btn-primary" runat="server" Text="add" ValidationGroup="symptonval" OnClick="Button3_Click" />
                        </blockquote>
                    </div>
                    <asp:ValidationSummary ID="ValidationSummary5" CssClass="alert alert-danger" ValidationGroup="symptonval" runat="server" />

                    <asp:Panel ID="Panel1" runat="server" ScrollBars="Auto">
                        <asp:GridView ID="GridView2" CssClass="table" runat="server" AllowPaging="True" AutoGenerateColumns="False" OnPageIndexChanging="GridView2_PageIndexChanging" OnRowCommand="GridView2_RowCommand">
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btnedit2" CommandName="myedit" runat="server">Edit</asp:LinkButton>
                                        <asp:LinkButton ID="btndelete2" CommandName="mydelete" OnClientClick="return confirm('delete this record')" runat="server">Delete</asp:LinkButton>
                                        <asp:LinkButton ID="btnupdate2" ValidationGroup="addoneditval" Visible="false" CommandName="myupdate" runat="server">Update</asp:LinkButton>
                                        <asp:LinkButton ID="btncancel2" Visible="false" CommandName="mycancel" runat="server">Cancel</asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="<strong>SIGN/SYMPTOM</strong><small class='text-danger'>(Senyales/Sintomas)</small>">
                                    <ItemTemplate>
                                        <asp:Label ID="lblid2" runat="server" Visible="false" Text='<%# Bind("ID") %>'></asp:Label>
                                        <asp:Label ID="lblsymptom" runat="server" Text='<%# Bind("SYMPTOM") %>'></asp:Label>
                                        <asp:DropDownList ID="ddleditsymptom" Text='<%# Bind("SYMPTOM") %>' Visible="false" CssClass="form-control" runat="server">
                                            <asp:ListItem Value="DIARRHEA (pagtate)">DIARRHEA (pagtatae)</asp:ListItem>
                                            <asp:ListItem Value="VOMITING (pagsusuka)">VOMITING (pagsusuka)</asp:ListItem>
                                        </asp:DropDownList>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="<strong>Date of Onset</strong><small class='text-danger'>(mm/dd/yyyy)</small>">
                                    <ItemTemplate>
                                        <asp:Label ID="lbldateonset" runat="server" Text='<%# Bind("DATEOFONSET") %>'></asp:Label>
                                        <asp:TextBox ID="tboxeditdateofonset" Text='<%# Bind("DATEOFONSET") %>' Visible="false" TextMode="Date" CssClass="form-control" runat="server"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="<strong>Estimated Time of Onset</strong>  <small class='text-danger'>(H:M)</small>">
                                    <ItemTemplate>
                                        <asp:Label ID="lblestimatedtime" runat="server" Text='<%# Bind("TIMEOFONSET") %>'></asp:Label>
                                        <asp:TextBox ID="tboxedittimeonset" Text='<%# Bind("TIMEOFONSET") %>' Visible="false" TextMode="Time" CssClass="form-control" runat="server"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="<strong>REMARKS</strong> <small class='text-danger'>(Paglalahad)</small>">
                                    <ItemTemplate>
                                        <asp:Label ID="lblremarks" runat="server" Text='<%# Bind("REMARKS") %>'></asp:Label>
                                        <asp:TextBox ID="tboxeditremarks" Text='<%# Bind("REMARKS") %>' Width="300" Visible="false" CssClass="form-control" runat="server"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>

                            </Columns>
                            <HeaderStyle Wrap="False" />
                            <RowStyle Wrap="False" />
                            <EmptyDataTemplate>
                                <div class="alert alert-warning">
                                    <h3><strong>Empty Table!</strong>
                                    </h3>
                                </div>
                            </EmptyDataTemplate>
                            <EditRowStyle BorderStyle="None" BorderWidth="0px" />
                            <PagerSettings PageButtonCount="8" />
                            <PagerStyle CssClass="GridPager" HorizontalAlign="Left" />
                        </asp:GridView>
                    </asp:Panel>
                </asp:Panel>
            </ContentTemplate>
        </asp:UpdatePanel>

        <%--   <div class="text-center">
            <strong>NOTE/OBSERVATIONS</strong>
            <br />
            <small class="text-info">(Nurse’s comments)</small><br />
            <asp:TextBox ID="tboxCOM" runat="server" TextMode="MultiLine" Rows="10" CssClass="form-control"></asp:TextBox>

        </div>
        <br />--%>



        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:ValidationSummary ValidationGroup="val1" CssClass="alert alert-danger" ID="ValidationSummary1" runat="server" />
                <asp:ValidationSummary ID="ValidationSummary2" ValidationGroup="val2" CssClass="alert alert-success" runat="server" />
                <asp:Button ID="Button2" ValidationGroup="val1" CssClass="btn btn-primary" runat="server" Text="save page 1" OnClick="Button2_Click" />
            </ContentTemplate>
        </asp:UpdatePanel>

        <br />

        <div class="panel panel-success">
            <div class="panel-heading">
                <h4 class="panel-title">
                    <asp:HyperLink ID="HyperLink1" runat="server" data-toggle="collapse" href="#collapse1"><span class="glyphicon glyphicon-resize-vertical"></span>&nbsp;Test Results / Quarantine Records</asp:HyperLink>
                </h4>
            </div>
            <div id="collapse1" class="panel-collapse collapse">
                <div class="panel-body">
                    <h3 class="text-info">My Test Results</h3>
                    <asp:Panel ID="Panel3" runat="server" ScrollBars="Auto">
                        <asp:GridView ID="GridView4" runat="server" CssClass="table table-bordered" AllowPaging="True" AutoGenerateColumns="False" OnPageIndexChanging="GridView4_PageIndexChanging">
                            <Columns>
                                <asp:TemplateField HeaderText="TEST">
                                    <ItemTemplate>
                                        <asp:Label ID="lbltest" runat="server" Text='<%# Bind("TEST") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="DATE TEST DONE">
                                    <ItemTemplate>
                                        <asp:Label ID="lbldatetestdone" runat="server" Text='<%# Bind("DATETESTDONE") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="TIME TEST">
                                    <ItemTemplate>
                                        <asp:Label ID="lbltimetest" runat="server" Text='<%# Bind("TIMETEST") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="SERIAL#">
                                    <ItemTemplate>
                                        <asp:Label ID="lblserialno" runat="server" Text='<%# Bind("SERIALNO") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="TEST RESULTS">
                                    <ItemTemplate>
                                        <asp:Label ID="lbltestresult" runat="server" Text='<%# Bind("TESTRESULT") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ADMINISTERED BY">
                                    <ItemTemplate>
                                        <asp:Label ID="lbladministeredby" runat="server" Text='<%# Bind("ADMINISTEREDBY") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <HeaderStyle Wrap="False" />
                            <RowStyle Wrap="False" />
                            <EmptyDataTemplate>
                                <div class="alert alert-warning">
                                    <h3><strong>Empty Table!</strong>
                                    </h3>
                                </div>
                            </EmptyDataTemplate>
                            <EditRowStyle BorderStyle="None" BorderWidth="0px" />
                            <PagerSettings PageButtonCount="8" />
                            <PagerStyle CssClass="GridPager" HorizontalAlign="Left" />
                        </asp:GridView>
                    </asp:Panel>
                    <br />
                    <h3 class="text-info">My Quarantine records</h3>
                    <asp:Panel ID="Panel6" runat="server" ScrollBars="Auto">
                        <asp:GridView ID="GridView5" runat="server" CssClass="table table-bordered" AllowPaging="True" AutoGenerateColumns="False" OnPageIndexChanging="GridView4_PageIndexChanging">
                            <Columns>
                                <asp:TemplateField HeaderText="Started">
                                    <ItemTemplate>
                                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("SDATE") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Finished">
                                    <ItemTemplate>
                                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("EDATE") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Day(s)">
                                    <ItemTemplate>
                                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("DAYS") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <HeaderStyle Wrap="False" />
                            <RowStyle Wrap="False" />
                            <EmptyDataTemplate>
                                <div class="alert alert-warning">
                                    <h3><strong>Empty Table!</strong>
                                    </h3>
                                </div>
                            </EmptyDataTemplate>
                            <EditRowStyle BorderStyle="None" BorderWidth="0px" />
                            <PagerSettings PageButtonCount="8" />
                            <PagerStyle CssClass="GridPager" HorizontalAlign="Left" />
                        </asp:GridView>
                    </asp:Panel>
                </div>

                <div class="panel-footer">
                </div>
            </div>
        </div>
    </div>

</asp:Content>
