<%@ Page Title="" Language="C#" MasterPageFile="~/Mi.Master" AutoEventWireup="true" CodeBehind="MiPerfil.aspx.cs" Inherits="TpFinalNivel3_IBARRANicolasAgustin.MiPerfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Mi perfil</h1>
    <hr />
    <div class="col-md-4">
        <div class="mb-3">
            <label for="txtNombre" class="form-label">Nombre:</label>
            <asp:TextBox ID="txtNombre2" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="mb-3">
            <label for="txtApellido" class="form-label">Apellido:</label>
            <asp:TextBox ID="txtApellido2" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="mb-3">
            <label for="txtEmail" class="form-label">Email:</label>
            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
    </div>

    <div class="col-md-4">
        <div class="mb-3">
            <label class="form-label">Imagen de Perfil</label>

            <input type="file" id="txtImagen" runat="server" class="form-control" />
        </div>
        <div>
            <asp:Image ID="imgNuevoPerfil" 
                runat="server" CssClass="img-fluid mb-3" />
        </div>
        <div class="col-md-4">
            <div class="mb-3">
                <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn btn-primary" OnClick="btnGuardar_Click" />
                </div>
         </div>
            </div>
</asp:Content>

