<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/DAILYHEALTHPROFILE/DHPmaster.Master" CodeBehind="dhpfullimage.aspx.cs" Inherits="webaftersales.DAILYHEALTHPROFILE.dhpfullimage" %>



<asp:Content ID="content1" runat="server" ContentPlaceHolderID="head">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>image view</title>
</asp:Content>

<asp:Content ID="content2" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <div class="well">
        <h3><strong>Full image view</strong></h3>
        <div class="navbar-right">
            <asp:LinkButton ID="LinkButton1" CssClass="btn btn-default" PostBackUrl="~/DAILYHEALTHPROFILE/dhppage2.aspx" runat="server">back</asp:LinkButton>
        </div>
    </div>
    <asp:Image ID="Image1" runat="server" />
    <br />
    <asp:Button ID="Button1" CssClass="btn btn-default" runat="server" OnClientClick="return confirm('delete this image?');" Text="delete" OnClick="Button1_Click" />
</asp:Content>
