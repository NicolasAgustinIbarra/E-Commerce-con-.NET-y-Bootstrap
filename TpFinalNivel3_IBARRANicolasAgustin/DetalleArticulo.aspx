<%@ Page Title="" Language="C#" MasterPageFile="~/Mi.Master" AutoEventWireup="true" CodeBehind="DetalleArticulo.aspx.cs" Inherits="TpFinalNivel3_IBARRANicolasAgustin.DetalleArticulo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Detalles de Articulo</h1>
    <br />
    <div class="row">
        <div class="col-md-6">
            <asp:Image CssClass="img-fluid mb-3" ID="imgVerDetalle" runat="server" ImageUrl="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcT1qWAIpqePEAH-UPypnABjdT_eNu7hlLi54Q&usqp=CAU" />
        </div>
        <div class="col-md-6 d-flex align-items-center">
            <div>
                <h2>
                    <asp:Label ID="lblNombreDetalle" class="form-label" runat="server"></asp:Label>
                </h2>
                <h4>
                    <asp:Label Text="Descripción:" class="form-label" runat="server" />
                </h4>
                <asp:Label ID="lblDescripcionDetalle" class="form-label" runat="server"></asp:Label>
                <div class="md-3">
                    <h4>
                        <asp:Label Text="Precio:" ID="lblPrecioDetalle" class="form-label" runat="server" />
                    </h4>
                    <asp:Label ID="lblPrecio" class="form-label" runat="server" />
                </div>
                <div class="md-3">
                    <h5>
                        <asp:Label Text="Categoria:" class="form-label" runat="server" />

                    </h5>
                    <asp:Label ID="lblCategoriaDetalle" class="form-label" runat="server" />
                    <div class="md-3">

                        <h5>
                            <asp:Label Text="Marca:" class="form-label" runat="server" />
                        </h5>
                        <asp:Label runat="server" class="form-label" ID="lblMarcaDetalle" />
                    </div>
                </div>
                <div class="md-3">
                    <h6>
                        <asp:Label Text="Codigo de artículo:" class="form-label" runat="server" />

                    </h6>
                    <asp:Label Text="codigo" ID="lblCodigoDetalle" class="form-label" runat="server" />
                </div>
            </div>
        </div>
    </div>

</asp:Content>
