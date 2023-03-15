<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="AddSecurityQestions.aspx.cs" Inherits="SanalGaleri.AdminPanel.AddSecurityQestions" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="addPage">
        <asp:Panel ID="pnl_successful" runat="server" CssClass="successfulpnl" Visible="false">
            Ekleme Başarılı   
        </asp:Panel>
        <asp:Panel ID="pnl_unsuccessful" runat="server" CssClass="unsuccessfulpnl" Visible="false">
            <asp:Label ID="lbl_mesaj" runat="server"></asp:Label>
        </asp:Panel>
        <h3>Güvenlik Sorusu Ekle</h3>
        <div class="textContent">
            <label>Soru:</label>
            <asp:TextBox ID="tb_addSecurityQestion" runat="server" CssClass="addInput"></asp:TextBox>
        </div>
        <div class="singleAddButton">
            <asp:LinkButton ID="lbtn_addSecurityQestion" runat="server" OnClick="lbtn_addSecurityQestion_Click">Ekle</asp:LinkButton>
        </div>
    </div>
</asp:Content>
