<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminLoginPage.aspx.cs" Inherits="SanalGaleri.AdminPanel.AdminLoginPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admin Login</title>
    <link href="Assets/Css/AdminLoginCss.css" rel="stylesheet" />
    <link href="Assets/Fontawesome/css/all.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="adminPanelLogin">
            <div class="container">
                <div class="title">
                    <h1>Admin Login</h1>
                    <div style="border-top: 1px solid white; margin-bottom: 3px;"></div>
                    <div style="border-top: 3px solid white"></div>
                </div>
                <div class="row" style="margin-top: 40px;">
                    <asp:TextBox CssClass="inputbox" ID="tb_mail" runat="server"></asp:TextBox><span><i class="fa-solid fa-user"></i></span>
                </div>
                <div class="row">

                    <asp:TextBox CssClass="inputbox" ID="tb_password" TextMode="Password" runat="server"></asp:TextBox><span><i class="fa-solid fa-lock"></i></span>
                    <div class="forgetPassword">
                        <a href="#">Şifremi Unuttum</a>
                    </div>
                    <asp:LinkButton ID="lbtn_loginBtn" CssClass="loginBtn" runat="server">Giriş yap</asp:LinkButton>

                </div>

                <br />
                <div class="row" style="margin-left:20px;">
                    <div style="border-top: 3px solid white; margin-bottom: 3px; width: 470px"></div>
                    <div style="border-top: 1px solid white; width: 470px"></div>
                </div>

            </div>
        </div>
    </form>
</body>
</html>
