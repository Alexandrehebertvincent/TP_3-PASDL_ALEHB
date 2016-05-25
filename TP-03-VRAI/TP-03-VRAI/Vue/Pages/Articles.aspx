<%@ Page Title="" Language="C#" MasterPageFile="~/Vue/PageDeBase.Master" AutoEventWireup="true" CodeBehind="Articles.aspx.cs" Inherits="TP_03_VRAI.Vue.Pages.Articles" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="divConnErreur" class="erreur-top" runat="server"></div>
    
    <div>
    <div class="container">
        <div class="row" id="affichageItem" runat="server">

        </div>
    </div>
</asp:Content>
