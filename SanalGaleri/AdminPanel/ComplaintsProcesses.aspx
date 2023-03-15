<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="ComplaintsProcesses.aspx.cs" Inherits="SanalGaleri.AdminPanel.ComplaintsProcesses" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="contentContainer">
        <div class="buttons">
            <div class="buttonArea">
                <asp:LinkButton CssClass="button" ID="lbtn_comments" runat="server" OnClick="lbtn_comments_Click">Yorum Şikayetleri</asp:LinkButton>
            </div>
            <div class="buttonArea">
                <asp:LinkButton CssClass="button" ID="lbtn_artworks" runat="server" OnClick="lbtn_artworks_Click">Sanat Eseri Şikayetleri</asp:LinkButton>
            </div>
            <div class="buttonArea">
                <asp:LinkButton CssClass="button" ID="lbtn_members" runat="server" OnClick="lbtn_members_Click">Üye Şikayetleri</asp:LinkButton>
            </div>
            <div style="clear: both"></div>
        </div>
        <div class="comments">
            <asp:ListView ID="lv_comments" runat="server" Visible="false">
                <LayoutTemplate>
                    <table border="1" class="table" cellpadding="0" cellspacing="0">
                        <thead>
                            <tr>
                                <th>Şikayet No</th>
                                <th>Şikayet Nedeni</th>
                                <th>Şikayet Ettiği Yorum No</th>
                                <th>Şikayet Eden Üye</th>
                                <th>Şikayet Tarihi</th>
                                <th>Şikayet Saati</th>
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
                        <td><%# Eval("ComplaintReason") %></td>
                        <td><%# Eval("CommentID") %></td>
                        <td><%# Eval("ComplainantUserName") %></td>
                        <td><%# Eval("ComplainantDateStr") %></td>
                        <td><%# Eval("ComplainantTimeStr") %></td>
                        <td>
                            <a href="#">Onayla</a>
                            <a href="#">Reddet</a>
                            <a href="#">Detaylar</a>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>
        </div>
        <div class="artWorks">
            <asp:ListView ID="lv_artworks" runat="server" Visible="false">
                <LayoutTemplate>
                    <table border="1" class="table" cellpadding="0" cellspacing="0">
                        <thead>
                            <tr>
                                <th>Şikayet No</th>
                                <th>Şikayet Nedeni</th>
                                <th>Şikayet Ettiği Eser No</th>
                                <th>Şikayet Eden Üye</th>
                                <th>Şikayet Tarihi</th>
                                <th>Şikayet Saati</th>
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
                        <td><%# Eval("ComplaintReason") %></td>
                        <td><%# Eval("ArtworkID") %></td>
                        <td><%# Eval("ComplainantUserName") %></td>
                        <td><%# Eval("ComplainantDateStr") %></td>
                        <td><%# Eval("ComplainantTimeStr") %></td>
                        <td>
                            <a href="#">Onayla</a>
                            <a href="#">Reddet</a>
                            <a href="#">Detaylar</a>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>
        </div>
        <div class="members">
            <asp:ListView ID="lv_members" runat="server" Visible="false">
                <LayoutTemplate>
                    <table border="1" class="table" cellpadding="0" cellspacing="0">
                        <thead>
                            <tr>
                                <th>Şikayet No</th>
                                <th>Şikayet Nedeni</th>
                                <th>Şikayet Ettiği Üye No</th>
                                <th>Şikayet Eden Üye</th>
                                <th>Şikayet Tarihi</th>
                                <th>Şikayet Saati</th>
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
                        <td><%# Eval("ComplaintReason") %></td>
                        <td><%# Eval("MemberID") %></td>
                        <td><%# Eval("ComplainantUserName") %></td>
                        <td><%# Eval("ComplainantDateStr") %></td>
                        <td><%# Eval("ComplainantTimeStr") %></td>
                        <td>
                            <a href="#">Onayla</a>
                            <a href="#">Reddet</a>
                            <a href="#">Detaylar</a>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>
        </div>
    </div>
</asp:Content>
