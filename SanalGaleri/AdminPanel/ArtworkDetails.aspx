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
            <div class="basicKnowledge">
                Eser No:
                <asp:Literal ID="ltrl_ID" runat="server"></asp:Literal>
                ||
               Eser Kategorisi:
                <asp:Literal ID="ltrl_artworkCategoriesName" runat="server"></asp:Literal>
                || Eseri Yayınlayan:
               <asp:Literal ID="ltrl_uploaderUserName" runat="server"></asp:Literal>
                <br />
                <div class="uploaddate">
                    Yüklenme Tarihi: 
                <asp:Literal ID="ltrl_UploadDate" runat="server"></asp:Literal>
                </div>

            </div>
            <div class="coverImg">
                <asp:Image ID="img_coverIMG" runat="server" />
            </div>
            <div class="detailPageContent">
                <div class="artworkimages">
                    <asp:Repeater ID="rp_awi" runat="server">
                        <ItemTemplate>
                            <img src='../Images/<%# Eval("ImagePath") %>' />
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
                <div class="artwotkInfo">
                    <h4>Eser Hakkında:</h4>
                    <h5>ADI:</h5>
                    <asp:Literal ID="ltrl_name" runat="server"></asp:Literal>
                    <h5>Yaş Aralığı:</h5>
                    <asp:Literal ID="ltrl_ageRange" runat="server"></asp:Literal>
                    <h5>Bilgi:</h5>
                    <asp:Literal ID="ltrl_info" runat="server"></asp:Literal>
                </div>
            </div>
    </form>
</body>
</html>
