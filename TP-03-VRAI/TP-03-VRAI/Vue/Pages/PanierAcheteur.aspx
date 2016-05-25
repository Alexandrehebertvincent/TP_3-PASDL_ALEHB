<%@ Page Title="" Language="C#" MasterPageFile="~/Vue/PageDeBase.Master" AutoEventWireup="true" CodeBehind="PanierAcheteur.aspx.cs" Inherits="TP_03_VRAI.Vue.Pages.PanierAcheteur" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="divConnErreur" class="erreur-top" runat="server"></div>
    
    <div>
    <div class="container">
        <div class="row">
            <div class="col-xs-12">
                <h1>Mon panier</h1>
            </div>
        </div>
        
        <div class="row" id="affichageItem" runat="server">

        </div>
    </div>
</asp:Content>
