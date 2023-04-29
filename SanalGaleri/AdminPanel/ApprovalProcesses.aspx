<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="ApprovalProcesses.aspx.cs" Inherits="SanalGaleri.ApprovalProcesses" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="contentContainer">
        <div class="buttons" style="padding-left: 300px">
            <div class="buttonArea">
                <asp:LinkButton CssClass="button" ID="lbtn_comments" runat="server" OnClick="lbtn_comments_Click">Yorum Onayı</asp:LinkButton>
            </div>
            <div class="buttonArea">
                <asp:LinkButton CssClass="button" ID="lbtn_artworks" runat="server" OnClick="lbtn_artworks_Click">Sanat Eseri Onayı</asp:LinkButton>
            </div>
            <div style="clear: both"></div>
        </div>
        <div class="comments">
            <asp:ListView ID="lv_comments" runat="server" Visible="false" OnItemCommand="lv_comments_ItemCommand">
                <LayoutTemplate>
                    <table border="1" class="table" cellpadding="0" cellspacing="0">
                        <thead>
                            <tr>
                                <th>Yorum No</th>
                                <th>Yorumu Yazan</th>
                                <th>Yorum Tarihi</th>
                                <th>Yorum Saati</th>
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
                        <td><%# Eval("WriterUserName") %></td>
                        <td><%# Eval("UploadDateStr") %></td>
                        <td><%# Eval("UploadTimeStr") %></td>
                        <td>
                            <asp:LinkButton ID="lbtn_approve" runat="server" CommandArgument='<%# Eval("ID") %>' CommandName="approve">Onayla</asp:LinkButton>
                            <asp:LinkButton ID="lbtn_reject" runat="server" CommandArgument='<%# Eval("ID") %>' CommandName="reject">Reddet</asp:LinkButton>
                            <a href='CommentDetails.aspx?cid=<%# Eval("ID") %>' target="_blank">Detaylar</a>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>
        </div>
        <div class="artWorks">
            <asp:ListView ID="lv_artworks" runat="server" Visible="false" OnItemCommand="lv_artworks_ItemCommand">
                <LayoutTemplate>
                    <table border="1" class="table" cellpadding="0" cellspacing="0">
                        <thead>
                            <tr>
                                <th>Sanat Eseri No</th>
                                <th>Kategori Adı</th>
                                <th>Yükleyen Kullanıcı</th>
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
                        <td><%# Eval("ArtCategoryName") %></td>
                        <td><%# Eval("UploaderUserName") %></td>
                        <td>
                            <asp:LinkButton ID="lbtn_approve" runat="server" CommandArgument='<%# Eval("ID") %>' CommandName="approve">Onayla</asp:LinkButton>
                            <asp:LinkButton ID="lbtn_reject" runat="server" CommandArgument='<%# Eval("ID") %>' CommandName="reject">Reddet</asp:LinkButton>
                            <a href='ArtworkDetails.aspx?awid=<%# Eval("ID") %>' target="_blank">Detaylar</a>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>
        </div>
    </div>
</asp:Content>
