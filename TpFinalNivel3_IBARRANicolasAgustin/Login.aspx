<%@ Page Title="" Language="C#" MasterPageFile="~/Mi.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TpFinalNivel3_IBARRANicolasAgustin.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%if (!IsPostBack)
        {%>
    <div class="d-flex justify-content-center">
        <h1>Incio de Sesión</h1>
    </div>
    <br />

    <div class="d-flex justify-content-center">

        <div class="d-flex flex-column">
            <div class="mb-3">
                <label for="exampleInputEmail1" class="form-label">Email:</label>
                <asp:TextBox ID="txtEmail" TextMode="Email" Placeholder="Correo" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="exampleInputPassword1" class="form-label">Contraseña:</label>
                <asp:TextBox ID="txtPass" TextMode="Password" Placeholder="*********" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="d-flex justify-content-center">
                <asp:Button Text="Ingresar" ID="btnIngresar" CssClass="btn btn-primary me-2" OnClick="btnIngresar_Click" runat="server" />
                <asp:Button Text="Registrarse" ID="btnRegistrarse" CssClass="btn btn-primary me-2" OnClick="btnRegistrarse_Click" runat="server" />
            </div>
        </div>

    </div>




    <%} %>
    <%else
        {%>
        
         <div class="d-flex justify-content-center">
        <h1>Registro de usuario</h1>
    </div>
    <br />

    <div class="d-flex justify-content-center">

        <div class="d-flex flex-column">
            <div class="mb-3">
                <label for="exampleInputEmail1" class="form-label">Email:</label>
                <asp:TextBox ID="txtEmailRegister" TextMode="Email" Placeholder="Correo" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="exampleInputPassword1" class="form-label">Contraseña:</label>
                <asp:TextBox ID="txtPassRegister" TextMode="Password" Placeholder="*********" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="d-flex justify-content-center">
                <asp:Button Text="Aceptar" ID="btnAceptar" CssClass="btn btn-primary me-2" OnClick="btnAceptar_Click" runat="server" />
                <asp:Button Text="Volver" ID="btnVolver" CssClass="btn btn-primary me-2" OnClick="btnVolver_Click" runat="server" />
            </div>
        </div>

    </div>
        

        <%} %>
</asp:Content>
