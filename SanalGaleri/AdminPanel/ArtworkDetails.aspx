<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ArtworkDetails.aspx.cs" Inherits="SanalGaleri.AdminPanel.ArtworkDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Eser Detayı</title>
    <link href="Assets/Css/MainLayout.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <h2>Eser Detayı</h2>
        <div class="detailPageContainer">
            <div class="commentNumbers">
                Eser No:
                <asp:Literal ID="ltrl_ID" runat="server"></asp:Literal>
                ||
               Eser Kategorisi:
                <asp:Literal ID="ltrl_artworkCategoriesName" runat="server"></asp:Literal>
                || Eseri Yayınlayan:
               <asp:Literal ID="ltrl_uploaderUserName" runat="server"></asp:Literal>

            </div>
            <div class="coverImg">
                <asp:Image ID="img_coverIMG" runat="server" />
            </div>
            <div class="detailPageContent">
                
            </div>

        </div>
    </form>
</body>
</html>
