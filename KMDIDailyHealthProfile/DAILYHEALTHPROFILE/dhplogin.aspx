<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="dhplogin.aspx.cs" Inherits="webaftersales.DAILYHEALTHPROFILE.dhplogin" %>

<!DOCTYPE html>
  <meta name="viewport" content="width=device-width, initial-scale=1">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     
    <title>Log in</title>
  
    <script src="../Scripts/bootstrap.js"></script>
    <link href="../Content/bootstrap.css" rel="stylesheet" />
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <script src="../Scripts/jquery-1.10.2.min.js"></script>
    <script src="../Scripts/bootstrap.min.js"></script>
    <link href="css/gridcss.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">

        <div class="jumbotron">
            <h1><strong>Kenneth and Mock</strong> <small>WINDOWS AND DOORS</small></h1>
        </div>
        <div class="container">

            <div class="row">
                <div class="col-sm-12">
                    <h3><strong class="text-info text-center">DAILY HEALTH PROFILE</strong> </h3>
                 
                    <div class="alert alert-warning"><strong class="text-info">Note!</strong> Change Username/Password is an option. <span class="text-danger">(Pweding mag palit ng Username at Password)</span>
                    </div>
                    <blockquote>
                       <span class="text-muted">Username =</span><span class="text-info"> <strong>First name</strong><span class="text-danger">&nbsp;(example: Juan)</span> </span><br />
                        <asp:TextBox ID="tboxempno" Height="40" placeholder="username" CssClass="form-control" runat="server"></asp:TextBox>
                        <br />
                     <span class="text-muted">Password =</span><span class="text-info"> <strong>Surname</strong><span class="text-danger">&nbsp;(example: Dela Cruz)</span> </span><br />
                        <asp:TextBox ID="tboxpassword" Height="40" placeholder="password" CssClass="form-control" TextMode="Password" runat="server" OnTextChanged="tboxpassword_TextChanged"></asp:TextBox><br />
                        <div class="checkbox">
                            <asp:CheckBox ID="CheckBox1" runat="server" Text="Remember me" Checked="True" />
                        </div>
                        <asp:Button ID="Button1" runat="server" CssClass="btn btn-primary" Text="Login" OnClick="Button1_Click" />
                        <asp:ValidationSummary CssClass="alert alert-danger" ValidationGroup="val1" ID="ValidationSummary1" runat="server" />
                    </blockquote>
                </div>
            
            </div>
        </div>
        <footer class="container-fluid text-center" style="background-color: white; margin-top: 0px;">
            <br />
            <br />
            <br />
            <p>Copyright 2020. Kenneth and Mock windows and doors. All rights Reserved.</p>
        </footer>
    </form>
</body>
</html>
