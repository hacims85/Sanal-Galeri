<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="Requests.aspx.cs" Inherits="SanalGaleri.AdminPanel.Requests" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2 class="requesTtitle">Talepler</h2>
    <div class="requests">
        <asp:ListView ID="lv_request" runat="server">
            <layouttemplate>
                <table border="1" class="table" cellpadding="0" cellspacing="0">
                    <thead>
                        <tr>
                            <th>Talep No</th>
                            <th>Talep Özeti</th>
                            <th>Talep Eden Üye</th>
                            <th>Talep Tarihi</th>
                            <th>Talep Saati</th>
                            <th>Seçenekler</th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:PlaceHolder ID="ItemPlaceHolder" runat="server"></asp:PlaceHolder>
                    </tbody>
                </table>
            </layouttemplate>
            <itemtemplate>
                <tr>
                    <td><%# Eval("ID") %></td>
                    <td><%# Eval("Summary") %></td>
                    <td><%# Eval("MemberUserName") %></td>
                    <td><%# Eval("RequestDateStr") %></td>
                    <td><%# Eval("RequestTimeStr") %></td>
                    <td>
                        <a href="#">Detay</a>
                        <a href="#">Okundu</a>
                    </td>
                </tr>
            </itemtemplate>
        </asp:ListView>
    </div>
</asp:Content>
