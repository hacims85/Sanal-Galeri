<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ArtworkComplaintDetails.aspx.cs" Inherits="SanalGaleri.AdminPanel.ArtworkComplaintDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sanat Eseri Şikayeti</title>
    <link href="Assets/Css/MainLayout.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <h2>Sanat Eseri Şikayeti</h2>
        <div class="detailPageContainer">
            <div class="basicKnowledge">
                Şikayet No:
                <asp:Literal ID="ltrl_ID" runat="server"></asp:Literal>
                || Şikayet Edilen Sanat Eseri No:
                <asp:Literal ID="ltrl_artworkID" runat="server"></asp:Literal>
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
