<%@ Page Title="" Language="C#" MasterPageFile="~/Mi.Master" AutoEventWireup="true" CodeBehind="ListadoDeProductos.aspx.cs" Inherits="TpFinalNivel3_IBARRANicolasAgustin.ListadoDeProductos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server" />
    <div class="d-flex justify-content-center">
        <h1>Lista de Artículos</h1>
    </div>
    <br />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="row justify-content-center">
                <div class="col-5" style="margin: auto">
                    <asp:Label ID="lblFiltro" runat="server" CssClass="form-control"  Text="Filtrar por nombre: "></asp:Label>
                    <asp:TextBox ID="txtFiltro" CssClass="form-control" runat="server" AutoPostBack="true" OnTextChanged="txtFiltro_TextChanged"></asp:TextBox>
                </div>
                <div class="row">
                    <div class=" col-5 justify-content-center" style="margin: auto">
                        <asp:GridView ID="dgvListaArticulos" runat="server" CssClass="table table-bordered" AutoGenerateColumns="false" DataKeyNames="ID"
                            OnSelectedIndexChanged="dgvListaArticulos_SelectedIndexChanged" AllowPaging="true" PageSize="5" OnPageIndexChanging="dgvListaArticulos_PageIndexChanging">
                            <Columns>
                                <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                                <asp:BoundField HeaderText="Categoria" DataField="Categoria.Descripcion" />
                                <asp:BoundField HeaderText="Marca" DataField="Marca.Descripcion" />
                                <asp:BoundField HeaderText="Precio" DataField="Precio" />
                                <asp:CommandField HeaderText="Editar" ShowSelectButton="true" SelectText="👌" />
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
        </ContentTemplate>
    </asp:UpdatePanel>







    
    <div class="d-flex justify-content-center">
        <asp:Button Text="Agregar" ID="btnAgregar" CssClass="btn btn-outline-primary" runat="server" OnClick="Unnamed_Click" />
    </div>
</asp:Content>
