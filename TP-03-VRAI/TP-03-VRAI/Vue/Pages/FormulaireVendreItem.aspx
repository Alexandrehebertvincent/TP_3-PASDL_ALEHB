<%@ Page Title="" Language="C#" MasterPageFile="~/Vue/PageDeBase.Master" AutoEventWireup="true" CodeBehind="FormulaireVendreItem.aspx.cs" Inherits="TP_03_VRAI.Vue.Pages.FormulaireVendreItem" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!--<div id="formAjoutItem" class="container" runat="server"></div>-->
    <div class="container"><div class="row">
	<div class="col-xs-12 col-sm-6">
		<div class="form-group">
			<span>Titre de l'item</span><asp:TextBox ID="txtTitre" placeholder="Titre" type="text" CssClass="form-control" style="width:300px;" runat="server"></asp:TextBox>
		</div>
        <div class="form-group">
			<span>Catégorie</span><asp:TextBox ID="txtCat" type="text" placeholder="Catégorie" CssClass="form-control" style="width:300px;" runat="server"></asp:TextBox>
		</div>
        <div class="form-group">
			<span>Description</span><textarea id="txtDescription" class="form-control" style="height:200px;width:600px;" runat="server"></textarea>
		</div><div class="form-group">
			<span>Prix plancher:</span><asp:TextBox ID="txtPrix" type="number" CssClass="form-control" style="width:80px;" runat="server"></asp:TextBox>
		</div><div class="form-group">
			<span>Ajouter une image</span><asp:FileUpload ID="fileImage" runat="server" />
		</div>
        <div class="form-group">
            <asp:Button ID="btnEnregistrer" CssClass="btn btn-primary" runat="server" Text="Enregistrer" />
        </div>
	</div>
</div></div>
</asp:Content>
