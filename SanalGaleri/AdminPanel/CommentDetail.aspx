<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CommentDetail.aspx.cs" Inherits="SanalGaleri.AdminPanel.CommentDetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Yorum Detayı</title>
    <link href="Assets/Css/MainLayout.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <h2>Yorum Detayı</h2>
        <div class="detailPageContainer">
            <div class="commentNumbers">
                Yorum No:
                <asp:Literal ID="ltrl_ID" runat="server"></asp:Literal>
                ||
               <asp:Label ID="lbl_artworkID" runat="server" Visible="false">Yorum Yapılan  Eser NO:
                <asp:Literal ID="ltrl_artworkID" runat="server"></asp:Literal>
                   ||</asp:Label>
                <asp:Label ID="lbl_commentID" runat="server" Visible="false">Cevap Verilen Yorum No:
                    <asp:Literal ID="ltrl_commentID" runat="server"></asp:Literal>
                    ||
                </asp:Label>
                Yazanın Kullanıcıadı:
                <asp:Literal ID="ltrl_writerUserName" runat="server"></asp:Literal>
            </div>
            <div class="detailPageContent">
                <h4>İçerik :</h4>
                <asp:Literal ID="ltrl_content" runat="server"></asp:Literal>
            </div>

        </div>
    </form>
</body>
</html>
