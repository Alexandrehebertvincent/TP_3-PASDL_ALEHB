<%@ Page Title="" Language="C#" MasterPageFile="~/Vue/PageDeBase.Master" AutoEventWireup="true" CodeBehind="Inscription.aspx.cs" Inherits="TP_03_VRAI.Vue.Pages.Inscription" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Formulaire d'inscription pour un nouvel utilisateur -->
    <div class="container">
    <div class="row">
    <div class="col-xs-12 col-sm-6">
        <p class="introinscri">Advenit post multos Scudilo Scutariorum tribunus velamento subagrestis ingenii persuasionis opifex callidus. qui eum adulabili sermone seriis admixto solus omnium proficisci pellexit vultu adsimulato saepius replicando quod flagrantibus votis eum videre frater cuperet patruelis, siquid per inprudentiam gestum est remissurus ut mitis et clemens, participemque eum suae maiestatis adscisceret, futurum laborum quoque socium, quos Arctoae provinciae diu fessae poscebant.</p>
    </div>
    <div class="col-xs-12 col-sm-4 col-sm-offset-1">
    <fieldset class="form-group">
    <label for="txtNom">Votre nom</label>
        <asp:TextBox ID="txtNom" placeholder="Entrez votre nom" CssClass="form-control" type="text" runat="server"></asp:TextBox>
    <small class="text-muted">N'oubliez pas que votre nom sera vu par les acheteurs.</small>
    </fieldset>
        <fieldset class="form-group">
    <label for="email">Email</label>
        <asp:TextBox ID="txtEmail" type="email" CssClass="form-control" placeholder="Email" runat="server"></asp:TextBox>
    </fieldset>
    <fieldset class="form-group">
    <label for="txtMdp">Mot de passe</label>
        <asp:TextBox ID="txtMdp" type="password" CssClass="form-control" placeholder="Mot de passe" runat="server"></asp:TextBox>
    </fieldset>
    <fieldset class="form-group">
    <label for="cmbType">Type de membre</label>
    <select class="form-control" id="cmbType" runat="server">
    <option>Admin</option>
    <option>Vendeur</option>
    <option>Acheteur</option>
    </select>
    </fieldset>
    <asp:Button ID="btnGo" CssClass="btn btn-primary" runat="server" Text="S'inscrire!" />
    </div>
    </div>
    </div>

</asp:Content>
