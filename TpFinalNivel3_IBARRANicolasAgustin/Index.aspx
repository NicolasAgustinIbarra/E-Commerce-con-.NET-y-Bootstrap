<%@ Page Title="" Language="C#" MasterPageFile="~/Mi.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="TpFinalNivel3_IBARRANicolasAgustin.Productos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="card d-flex justify-content-center">
        <div class="card-header">
            <div class="d-flex justify-content-center">
                <h1>Bienvenido a nuestra tienda virtual</h1>
            </div>
        </div>
        <div class="card-body d-flex justify-content-center align-items-center">
            <asp:TextBox ID="txtFiltro" runat="server" CssClass="form-control" Width="70%" PlaceHolder="Buscar" />
            <asp:Button Text="Buscar" ID="btnFiltro" runat="server" CssClass="btn btn-primary" Style="margin-left: 20px;" OnClick="btnFiltro_Click" />
        </div>
    </div>
    <hr />
    <div class="row row-cols-1 row-cols-md-3 g-4">
        <asp:Repeater runat="server" ID="repRepetidor">
            <ItemTemplate>
                <div class="d-flex justify-content-center">
                    <div class="card tarjeta-con-fondo" style="width: 20rem;">
                        <img src="<%#Eval("ImagenUrl") %>" class="card-img-top" alt="...">
                        <div class="card-body">
                            <h5 class="card-title"><%#Eval("Nombre") %></h5>
                            <p class="card-text"><%#Eval("Descripcion") %></p>
                        </div>
                        <div class="card-footer d-flex flex-column align-items-center">
                            <a href="DetalleArticulo.aspx?id=<%#Eval("Id") %>" class="btn btn-primary" style="width: 100%">Ver Detalles</a>
                            <asp:Button Text="☆" runat="server" ID="btnFavoritos" OnClick="btnFavoritos_Click" CssClass="btn btn-warning mt-1" Style="width: 100%" CommandArgument='<%#Eval("Id") %>' CommandName="IdFavoritos" />
                        </div>
                    </div>
                </div>

            </ItemTemplate>
        </asp:Repeater>
    </div>

</asp:Content>
