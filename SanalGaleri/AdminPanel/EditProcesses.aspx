<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel/AdminMasterPage.Master" AutoEventWireup="true" CodeBehind="EditProcesses.aspx.cs" Inherits="SanalGaleri.AdminPanel.EditProcesses" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="contentContainer">
        <div class="buttons">
            <div class="buttonArea">
                <asp:LinkButton CssClass="button" ID="lbtn_complaintReasons" runat="server" OnClick="lbtn_complaintReasons_Click">Şikayet Nedenlerini Düzenle</asp:LinkButton>
            </div>
            <div class="buttonArea">
                <asp:LinkButton CssClass="button" ID="lbtn_artworksCategories" runat="server" OnClick="lbtn_artworksCategories_Click">Eser Kategorilerini Düzenle</asp:LinkButton>
            </div>
            <div class="buttonArea">
                <asp:LinkButton CssClass="button" ID="lbtn_SeurityQestions" runat="server" OnClick="lbtn_SeurityQestions_Click">Güvenlik Sorularını Düzenle</asp:LinkButton>
            </div>
            <div class="buttonArea">
                <asp:LinkButton CssClass="button" ID="lbtn_ageRanges" runat="server" OnClick="lbtn_ageRanges_Click">Yaş Aralığını Düzenle</asp:LinkButton>
            </div>
            <div style="clear: both"></div>
        </div>
        <div class="complaintReasons">
            <asp:ListView ID="lv_complaintReasons" runat="server" Visible="false" OnItemCommand="lv_complaintReasons_ItemCommand">
                <LayoutTemplate>
                    <table border="1" class="table" cellpadding="0" cellspacing="0">
                        <thead>
                            <tr>
                                <th>Şikayet Nedeni No</th>
                                <th>Şikayet Nedeni</th>
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
                        <td><%# Eval("Reason") %></td>
                        <td>
                            <asp:LinkButton ID="lbtn_delete" runat="server" CommandArgument='<%# Eval("ID") %>' CommandName="remove">Sil</asp:LinkButton>
                            <a href='EditComplaintReason.aspx?crid=<%# Eval("ID") %>'>Düzenle</a>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>
            <div class="addButton">
                <asp:LinkButton ID="lbtn_addComplaintReason" runat="server" Visible="false" OnClick="lbtn_addComplaintReason_Click">Şikayet Nedeni Ekle</asp:LinkButton>
            </div>
        </div>
        <div class="artCategories">
            <asp:ListView ID="lv_artCategories" runat="server" Visible="true" OnItemCommand="lv_artCategories_ItemCommand">
                <LayoutTemplate>
                    <table border="1" class="table" cellpadding="0" cellspacing="0">
                        <thead>
                            <tr>
                                <th>Eser Kategorisi No</th>
                                <th>Eser Kategorisi Adı</th>
                                <th>Eser Kategorisi Durumu</th>
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
                        <td><%# Eval("ArtCategoriesStatusStr") %></td>
                        <td>
                            <asp:LinkButton ID="lbtn_delete" runat="server" CommandArgument='<%# Eval("ID") %>' CommandName="remove">Sil</asp:LinkButton>
                            <asp:LinkButton ID="lbtn_changestatus" runat="server" CommandArgument='<%# Eval("ID") %>' CommandName="changestatus">Durum Değiştir</asp:LinkButton> 
                            <a href='EditArtworkCategories.aspx?acid=<%# Eval("ID") %>'>Düzenle</a>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>
            <div class="addButton">
                <asp:LinkButton ID="lbtn_addArtCategory" runat="server" Visible="false" OnClick="lbtn_addArtCategory_Click">Eser Kategorisi Ekle</asp:LinkButton>
            </div>
        </div>
        <div class="securityQestions">
            <asp:ListView ID="lv_securityQestions" runat="server" Visible="false" OnItemCommand="lv_securityQestions_ItemCommand">
                <LayoutTemplate>
                    <table border="1" class="table" cellpadding="0" cellspacing="0">
                        <thead>
                            <tr>
                                <th>Güvenlik Sorusu No</th>
                                <th>Güvenlik Sorusu</th>
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
                        <td><%# Eval("Questions") %></td>
                        <td>
                            <asp:LinkButton ID="lbtn_delete" runat="server" CommandArgument='<%# Eval("ID") %>' CommandName="remove">Sil</asp:LinkButton>
                            <a href='EditSecurityQestions.aspx?sqid=<%# Eval("ID") %>'>Düzenle</a>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>
            <div class="addButton">
                <asp:LinkButton ID="lbtn_addsecurityQestions" runat="server" Visible="false" OnClick="lbtn_addsecurityQestions_Click">Güvenlik Sorusu Ekle</asp:LinkButton>
            </div>
        </div>
        <div class="ageRanges">
            <asp:ListView ID="lv_ageRanges" runat="server" Visible="false" OnItemCommand="lv_ageRanges_ItemCommand">
                <LayoutTemplate>
                    <table border="1" class="table" cellpadding="0" cellspacing="0">
                        <thead>
                            <tr>
                                <th>Yaş Aralığı No</th>
                                <th>Yaş Aralığı</th>
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
                        <td><%# Eval("AgeRange") %></td>
                        <td>
                            <asp:LinkButton ID="lbtn_delete" runat="server" CommandArgument='<%# Eval("ID") %>' CommandName="remove">Sil</asp:LinkButton>
                            <a href='EditAgeRange.aspx?arid=<%# Eval("ID") %>'>Düzenle</a>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>
            <div class="addButton">
                <asp:LinkButton ID="lbtn_addageRanges" runat="server" Visible="false" OnClick="lbtn_addageRanges_Click">Yaş Aralığı Ekle</asp:LinkButton>
            </div>
        </div>
    </div>
</asp:Content>
