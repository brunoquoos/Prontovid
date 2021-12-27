<%@ Page Title="Cadastro de [NomeClasse]" Language="C#" MasterPageFile="~/Forms/MasterLogado.master" AutoEventWireup="true" CodeBehind="Cad[NomeClasse].aspx.cs" Inherits="[NamespaceSemBiblioteca].Forms.Cad[NomeClasse]" %>


<asp:Content ID="Content3" ContentPlaceHolderID="cphCabecalho2" runat="server">
    <%-- OUTROS --%>
    <script src="../Scripts/jsCad[NomeClasse].js"></script>

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphCorpo2" runat="server">

    <h1>Cadastro de [NomeClasse]</h1>
    <div id="divFiltros">
        <input type="text" id="txtPesquisa" class="txtBusca" />
                <input type="button" value="Atualizar" id="btnPesquisar" class="botao principal" />
        &nbsp; &nbsp;
        <input type="button" value="Adicionar" id="btnAdicionar" class="botao auxiliar" />
    </div>

    <div id="divDados">
    </div>

    <div id="divPopupCadastro" title="Detalhes" style="display: none">
        <div id="divCadastro">
            <input type="hidden" id="hid[CampoPK]" value="0" />
            <table style='width: 100%'>
                [CamposCadastro]
                <tr>
                    <td>&nbsp;
                    </td>
                    <td>&nbsp;
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;
                    </td>
                    <td>
                        <input type="button" value="Gravar" id="btnGravar" class="botao principal" />
                    </td>
                </tr>
            </table>
        </div>
    </div>

</asp:Content>
