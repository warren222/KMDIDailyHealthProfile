<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/DAILYHEALTHPROFILE/DHPmaster.Master" CodeBehind="dhpchangepass.aspx.cs" Inherits="webaftersales.DAILYHEALTHPROFILE.dhpchangepass" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
       <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>change username and password</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="well">
        <h3><strong>Change user account security</strong></h3>
    </div>
    <asp:ValidationSummary ValidationGroup="val1" CssClass="alert alert-danger" ID="ValidationSummary1" runat="server" />

    <div>
        New username<asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="tboxusername" ForeColor="Red" runat="server" ValidationGroup="val1" ErrorMessage="new username is required">*</asp:RequiredFieldValidator><br />
        <asp:TextBox ID="tboxusername" CssClass="form-control" runat="server"></asp:TextBox><br />
        New Password<asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="tboxpassword" ForeColor="Red" runat="server" ValidationGroup="val1" ErrorMessage="new password is required">*</asp:RequiredFieldValidator><br />
        <asp:TextBox ID="tboxpassword" CssClass="form-control" TextMode="Password" runat="server"></asp:TextBox><br />
        Password<asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="tboxoldpassord" ForeColor="Red" runat="server" ValidationGroup="val1" ErrorMessage="password is required">*</asp:RequiredFieldValidator><br />
        <asp:TextBox ID="tboxoldpassord" CssClass="form-control" TextMode="Password" runat="server"></asp:TextBox><br />
        <asp:Button ID="Button1" runat="server" Text="save changes" ValidationGroup="val1" CssClass="btn btn-primary" OnClick="Button1_Click" />
    </div>
</asp:Content>
