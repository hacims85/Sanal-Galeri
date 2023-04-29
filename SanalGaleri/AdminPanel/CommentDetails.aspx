<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CommentDetails.aspx.cs" Inherits="SanalGaleri.AdminPanel.CommentDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Yourm-Cevap Detayı</title>
    <link href="Assets/Css/MainLayout.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:Label ID="lbl_artworkTitle" runat="server" Visible="false"><h2>Yorum Detayı</h2></asp:Label>
        <asp:Label ID="lbl_answerTitle" runat="server" Visible="false"><h2>Cevap Detayı</h2></asp:Label>

        <div class="detailPageContainer">
            <div class="basicKnowledge">
                Yorum No:
                <asp:Literal ID="ltrl_ID" runat="server"></asp:Literal>
                ||
              <asp:Label ID="lbl_commentArtwork" runat="server" Visible="false">Yorum Yapılan Eser No:
                      <asp:Literal ID="ltrl_commentArtwork" runat="server"></asp:Literal>
                  || Yorum Yapan:
              </asp:Label>
                <asp:Label ID="lbl_ansverComment" runat="server" Visible="false">Cevap Verilen Yorum No:
                    <asp:Literal ID="ltrl_answerComment" runat="server"></asp:Literal>
                    || Cevap Veren:
                </asp:Label>
                <asp:Literal ID="ltrl_uploaderUserName" runat="server"></asp:Literal>

                <br />
                <div class="uploaddate">
                    Yüklenme Tarihi: 
                <asp:Literal ID="ltrl_UploadDate" runat="server"></asp:Literal>
                </div>

            </div>
            <div class="detailPageContent">
                <div class="commentInfo">
                    <h5>İçerik:</h5>
                    <asp:Literal ID="ltrl_info" runat="server"></asp:Literal>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
