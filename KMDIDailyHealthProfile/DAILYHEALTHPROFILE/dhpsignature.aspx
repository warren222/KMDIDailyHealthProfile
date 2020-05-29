<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="dhpsignature.aspx.cs" Inherits="webaftersales.DAILYHEALTHPROFILE.dhpsignature" %>

<meta name="viewport" content="width=device-width, initial-scale=1">
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>DHP Signature</title>
    <script src="../Scripts/bootstrap.js"></script>
    <link href="../Content/bootstrap.css" rel="stylesheet" />
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <script src="../Scripts/bootstrap.min.js"></script>
    <script src="../Scripts/jquery-1.10.2.min.js"></script>
    <script src="scripts/sign.js"></script>
    <script>
        $(document).ready(function () {
            $('#myCanvas').sign({
                resetButton: $('#resetSign'),
                lineWidth: 5
            });
        });
    </script>
    <style>
        #myCanvas {
            border: 4px solid #444;
            border-radius: 1px;
        }

        .tbl td {
            padding-bottom: 10px;
        }
    </style>
    <script>

    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div class="container-fluid">

            <div class="row">
                <div class="col-sm-6">

                    <canvas id="myCanvas"></canvas>
                    <input type='hidden' id='myurl' name='myurl' />
                    <input type='hidden' id='myurl1' name='myurl1' />
                    <br />
                    <asp:Button runat="server" CssClass="btn btn-warning" Text="Reset Sign" ID='resetSign' />
                    <br />
                    <br />
                    <br />


                    <script>
                        function successfulmessage() {
                            alert('Signature captured successfully!');
                        }
                        function storeimage() {
                            var canvas = document.getElementById('myCanvas');
                            var context = canvas.getContext('2d');
                            var dataURL = canvas.toDataURL();
                            var h = document.getElementById('myurl');
                            h.value = dataURL;

                            //document.getElementById('resetSign').click();
                            //document.getElementById('Image1').src = dataURL;
                        }
                    </script>

                </div>
                <div class="col-sm-6">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <div class="container">
                                <div class="page-header">
                                    <h1>
                                        <small>
                                            <asp:Label ID="Label1" runat="server" Text="Signature Form">
                                            </asp:Label></small></h1>
                                    <div class="navbar-right">
                                        <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn btn-default" OnClick="LinkButton1_Click">back</asp:LinkButton>
                                    </div>
                                </div>
                                <asp:Panel ID="Panel1" runat="server">

                                    <asp:Button ID="Button2" CssClass="btn btn-primary" ValidationGroup="g1" OnClientClick="storeimage()" runat="server" Text="capture signature" OnClick="Button2_Click" />

                                </asp:Panel>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
