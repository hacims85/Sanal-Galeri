<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CommentComplaintDetails.aspx.cs" Inherits="SanalGaleri.AdminPanel.CommentComplaintDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Yorum-Cevap Şikayeti Detayı</title>
    <link href="Assets/Css/MainLayout.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:Label ID="lbl_commentTitle" runat="server" Visible="false"><h2>Yorum Şikayeti</h2></asp:Label>
        <asp:Label ID="lbl_answerTitle" runat="server" Visible="false"><h2>Cevap Şikayeti</h2></asp:Label>

        <div class="detailPageContainer">
            <div class="basicKnowledge">
                Şikayet No:
                <asp:Literal ID="ltrl_ID" runat="server"></asp:Literal>
                ||
               <asp:Label ID="lbl_commentComplaint" runat="server" Visible="false">Şikayet Edilen Yorum No:
               </asp:Label>
                <asp:Label ID="lbl_ansverComplaint" runat="server" Visible="false">Şikayet Edilen Cevap No:
                </asp:Label>
                <asp:Literal ID="ltrl_commentID" runat="server"></asp:Literal>
                || Şikayet Eden:
                <asp:Literal ID="ltrl_conplainantUserName" runat="server"></asp:Literal>
                <br />
                <div class="uploaddate">
                    Yüklenme Tarihi: 
                <asp:Literal ID="ltrl_conplainantDate" runat="server"></asp:Literal>
                </div>

            </div>
            <div class="detailPageContent">
                <div class="complaintInfo">
                    <h5>Şikayet Nedeni:</h5>
                    <asp:Literal ID="ltrl_complaintReason" runat="server"></asp:Literal>
                    <h5>Şikayet Açıklaması:</h5>
                    <asp:Literal ID="ltrl_explanation" runat="server"></asp:Literal>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
