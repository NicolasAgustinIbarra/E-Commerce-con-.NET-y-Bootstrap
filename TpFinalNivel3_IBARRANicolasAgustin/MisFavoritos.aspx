<%@ Page Title="" Language="C#" MasterPageFile="~/Mi.Master" AutoEventWireup="true" CodeBehind="MisFavoritos.aspx.cs" Inherits="TpFinalNivel3_IBARRANicolasAgustin.MisFavoritos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="d-flex justify-content-center"">
         <h1>Bienvenido a tus articulos favoritos</h1>
    </div>
           <br />
    <div class="row row-cols-1 row-cols-md-3 g-4">
        <asp:Repeater runat="server" ID="repFavorito">
            <ItemTemplate>
                <div class="d-flex justify-content-center">
                    <div class="card" style="width: 18rem;">
                        <img src="<%#Eval("ImagenUrl") %>" class="card-img-top" alt="...">
                        <div class="card-body">
                            <h5 class="card-title"><%#Eval("Nombre") %></h5>
                            <p class="card-text"><%#Eval("Descripcion") %></p>
                            <div class="row-cols-md-3">
                                <a href="DetalleArticulo.aspx?id=<%#Eval("Id") %>" class="btn btn-primary">Ver Detalles</a>
                                <asp:Button Text="Eliminar" CssClass="btn btn-outline-danger" CommandArgument='<%#Eval("Id") %>' ID="btnEliminarFavorito" OnClick="btnEliminarFavorito_Click" 
                                    CommandName="IdElmininarFavorito" runat="server" />
                            </div>

                        </div>
                    </div>
                </div>

            </ItemTemplate>
        </asp:Repeater>
    </div>

</asp:Content>
