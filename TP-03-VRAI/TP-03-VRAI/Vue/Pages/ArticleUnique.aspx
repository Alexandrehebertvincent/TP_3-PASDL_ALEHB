<%@ Page Title="" Language="C#" MasterPageFile="~/Vue/PageDeBase.Master" AutoEventWireup="true" CodeBehind="ArticleUnique.aspx.cs" Inherits="TP_03_VRAI.Vue.Pages.ArticleUnique" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <div class="row" id="affichageItem" runat="server">
            <asp:Label ID="messageErreur" runat="server" CssClass="container"></asp:Label>
        </div>
    </div>

</asp:Content>
