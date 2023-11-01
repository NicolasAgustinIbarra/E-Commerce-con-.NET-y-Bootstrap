<%@ Page Title="" Language="C#" MasterPageFile="~/Mi.Master" AutoEventWireup="true" CodeBehind="FormularioArticulo.aspx.cs" Inherits="TpFinalNivel3_IBARRANicolasAgustin.FormularioArticulo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server" />
    <div class="container">
        <div class="row">
            <div class="col-md-6">
                <div class="mb-3">
                    <label for="txtId" class="form-label">Id:</label>
                    <asp:TextBox ID="txtId" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <label for="txtNombre" class="form-label">Nombre:</label>
                    <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Campo requerido"
                        ControlToValidate="txtNombre" Display="Dynamic" CssClas=""></asp:RequiredFieldValidator>
                </div>
                <div class="mb-3">
                    <label for="txtCodigoArticulo" class="form-label">Código de artículo:</label>
                    <asp:TextBox ID="txtCodigoArticulo" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Campo requerido"
                        ControlToValidate="txtCodigoArticulo" Display="Dynamic" CssClas="text-danger"></asp:RequiredFieldValidator>
                </div>
                <div class="mb-3">
                    <label for="txtPrecio" class="form-label">Precio:</label>
                    <asp:TextBox ID="txtPrecio" runat="server" CssClass="form-control" OnKe></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Campo requerido"
                        ControlToValidate="txtPrecio" Display="Dynamic" CssClas="text-danger"></asp:RequiredFieldValidator>
                    <asp:CustomValidator ID="cvPrecio" runat="server" ControlToValidate="txtPrecio" ErrorMessage="Solo se permiten números" OnServerValidate="cvPrecio_ServerValidate" Display="Dynamic"></asp:CustomValidator>
                </div>

                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <div class="mb-3">
                            <label for="ddlCategoria" class="form-label">Categoria:</label>
                            <asp:DropDownList ID="ddlCategoria" CssClass="form-select" runat="server"></asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Campo requerido"
                                ControlToValidate="ddlCategoria" Display="Dynamic" CssClas="text-danger"></asp:RequiredFieldValidator>
                        </div>
                        <div class="mb-3">
                            <label for="ddlMarca" class="form-label">Marca:</label>
                            <asp:DropDownList ID="ddlMarca" CssClass="form-select" runat="server"></asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Campo requerido"
                                ControlToValidate="ddlMarca" Display="Dynamic" CssClas="text-danger"></asp:RequiredFieldValidator>
                        </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <div class="col-md-6">
                <div class="mb-3">
                    <label for="txtDescripcion" class="form-label">Descripcion:</label>
                    <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Campo requerido"
                        ControlToValidate="txtDescripcion" Display="Dynamic" CssClas="text-danger"></asp:RequiredFieldValidator>
                </div>
                <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                        <div class="mb-3">
                            <label for="txtUrlImagen" class="form-label">Url Imagen:</label>
                            <asp:TextBox ID="txtUrlImagen" runat="server" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtUrlImagen_TextChanged"></asp:TextBox>
                        </div>
                        <div class="mb-3">
                            <asp:Image ID="articuloImagen" ImagenUrl="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTsJ7oEzT6NF02fP_lMNd8LmtKFRGXCnvaInA&usqp=CAU"
                                runat="server" Width="60%" />
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <div class="mb-3">
                    <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" OnClick="btnAceptar_Click" CssClass="btn btn-primary" AutoPostBack="true" />
                    <a href="ListadoDeProductos.aspx">Volver</a>
                </div>
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <div class="mb-3">
                            <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CssClass="btn btn-outline-danger" OnClick="btnEliminar_Click" AutoPostBack="true" />
                            <div class="modal" tabindex="-1" <% if (confirmaEliminacion)
                                { %>
                                style="display: block;" <% } %>>
                                <div class="modal-dialog">
                                    <div class="modal-content">
                                        <div class="modal-header">
                                            <h5 class="modal-title">Confirmar Eliminación</h5>
                                            <asp:Button ID="btnX" runat="server" Text="" CssClass="btn btn-close" data-bs-dismiss="modal" />
                                        </div>
                                        <div class="modal-body">
                                            <p>¿Deseas eliminar este artículo?</p>
                                        </div>
                                        <div class="modal-footer">
                                            <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-primary" data-bs-dismiss="modal" />
                                            <asp:Button ID="btnConfimaEliminar" runat="server" Text="Eliminar" CssClass="btn btn-danger" OnClick="btnConfimaEliminar_Click" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
</asp:Content>
