<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="MemberProcesses.aspx.cs" Inherits="SanalGaleri.AdminPanel.MemberProcesses" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Üye Listesi</h2>
    <div class="members">
        <asp:ListView ID="lv_members" runat="server">
            <LayoutTemplate>
                <table border="1" class="table" cellpadding="0" cellspacing="0">
                    <thead>
                        <tr>
                            <th>Üye No</th>
                            <th>Üye Adı</th>
                            <th>Nicki</th>
                            <th>Üyelik Statüsü</th>
                            <th>Üyelik Durumu</th>
                            <th>Seçenekler</th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:PlaceHolder ID="ItemPlaceHolder" runat="server"></asp:PlaceHolder>
                    </tbody>
                </table>
            </LayoutTemplate>
            <ItemTemplate>
                <tr>
                    <td><%# Eval("ID") %></td>
                    <td><%# Eval("Name") %></td>
                    <td><%# Eval("UserName") %></td>
                    <td><%# Eval("MembershipStatusName") %></td>
                    <td><%# Eval("UserStatusStr") %></td>
                    <td>
                        <a href="#">Banla</a>
                        <a href="#">Reddet</a>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:ListView>
    </div>
</asp:Content>
