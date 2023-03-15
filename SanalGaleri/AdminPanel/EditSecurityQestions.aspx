<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="EditSecurityQestions.aspx.cs" Inherits="SanalGaleri.AdminPanel.EditSecurityQestions" %>

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
        <h3>Güvenlik Sorusunu Düzenle</h3>
        <div class="textContent">
            <label>Soru:</label>
            <asp:TextBox ID="tb_addSecurityQestion" runat="server" CssClass="addInput"></asp:TextBox>
        </div>
        <div class="singleAddButton">
            <asp:LinkButton ID="lbtn_editSecurityQestion" runat="server" OnClick="lbtn_editSecurityQestion_Click">Düzenle</asp:LinkButton>
        </div>
    </div>
</asp:Content>
