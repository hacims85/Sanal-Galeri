<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="EditAgeRange.aspx.cs" Inherits="SanalGaleri.AdminPanel.EditAgeRange" %>
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
        <h3>Yaş Aralığını Düzenle</h3>
        <div class="textContent">
            <label>Yaş Aralığı :</label>
            <asp:TextBox ID="tb_addAgeRange" runat="server" CssClass="addInput"></asp:TextBox>
        </div>
        <div class="singleAddButton">
            <asp:LinkButton ID="lbtn_editAgeRange" runat="server" OnClick="lbtn_editAgeRange_Click">Düzenle</asp:LinkButton>
        </div>
    </div>
</asp:Content>
