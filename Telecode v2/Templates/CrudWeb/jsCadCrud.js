var carregou = false;

$(document).ready(function () {
    if (carregou)
        return;

    carregou = true;

    DefinirMascaraMoeda('.txtMoeda');

    $('#btnPesquisar').off().click(Pesquisar);
    $('#btnGravar').off().click(Gravar);
    $('#btnAdicionar').off().click(AbrirNovo);

    $('#txtPesquisa').focus();

    DefinirBotaoPadrao();

    PadronizarTxtDatas();

    Pesquisar();

});

function DefinirBotaoPadrao() {
    $('#divFiltros input').keypress(function (e) {
        if (e.keyCode == 13)
            $('#btnPesquisar').click();
    });
};

function Pesquisar() {

    exibirFeedback();

    $.ajax({
        type: "POST",
        url: "../WebServices/Ws[NomeClasse].asmx/Consultar",
        data: "{ 'pesquisa': '" + $('#txtPesquisa').val() + "'}",

        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {

            var resultado = (typeof response.d) == 'string' ? eval('(' + response.d + ')') : response.d;

            $('#divDados').empty();

            if (resultado.Sucesso) {

                if (resultado.Dado.length > 0) {

                    var html = '<table class="grid" id="tblCabecalho">';
                    html += "<tr>";
                    html += "<th></th>";
                    html += "<th>Código</th>";
                    [ColunasTh]
                    html += "</tr>";
                    html += "</table>";
                    html += "<div style='clear: both'></div>";
                    html += "<div style='height: 400px; overflow: auto'>";
                    html += "<table id='tblDados' class='grid'>";

                    for (var i = 0; i < resultado.Dado.length; i++) {

                        html += "<tr>";

                        html += "<td><a class='lnkExcluir' href='#' id='lnkExcluir_" + resultado.Dado[i].[CampoPK] + "'>Excluir</a></td>";
                        html += "<td><a href='#' id='lnkAlterar_" + resultado.Dado[i].[CampoPK] + "'>" + resultado.Dado[i].[CampoPK] + "</a></td>";
                        [ColunasTd]

                        html += "</tr>";

                    }

                    html += "</div>";
                    html += "</table>";

                    $('#divDados').append(html);

                    $('a[id^="lnkAlterar_"]').click(function() {
                        AbrirAlteracao(this.id);
                    });

                    $('a[id^="lnkExcluir_"]').click(function () {

                        var vetor = this.id.split('_');
                        var codigo = vetor[1];

                        $("#divMsg").dialog({
                            resizable: false,
                            height: 220,
                            width: 400,
                            modal: true,
                            buttons: {
                                "Sim": function () {
                                    $(this).dialog("close");
                                    Excluir(codigo);
                                },
                                "Não": function () {
                                    $(this).dialog("close");
                                }
                            }
                        });

                        $("#divMsg").find("p").html("Confirma excluir este registro?");

                    });

                    DefinirLarguraColuna('#tblCabecalho', '#tblDados', 1, '100px');
                    DefinirLarguraColuna('#tblCabecalho', '#tblDados', 2, '100px');
                    [DefinirLarguraColunas]

                    $(".grid tr:odd").addClass("linhaColorida");

                } else {
                    $('#divDados').append('<strong>Nenhum registro foi encontrado.</strong>');
                }

                ocultarFeedback();

            } else {
                ocultarFeedback();
                ExibirMessageBox(resultado.Mensagem);
            }

        },

        failure: function (msg) {
            ocultarFeedback();
            ExibirMessageBox('Ocorreu um erro interno. ' + msg);

        }

    });
}

function AbrirAlteracao(id) {
    exibirFeedback();

    var vetor = id.split('_');
    var codigo = vetor[1];

    $.ajax({
        type: "POST",
        url: "../WebServices/Ws[NomeClasse].asmx/ConsultarChave",
        data: "{ 'codigo': '" + codigo + "'}",

        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {

            var resultado = (typeof response.d) == 'string' ? eval('(' + response.d + ')') : response.d;

            if (resultado.Sucesso) {

                [AtualizaTela]
                ocultarFeedback();

                $("#divPopupCadastro").dialog({
                    resizable: false,
                    height: [AlturaPopup],
                    width: 600,
                    modal: true,
                    buttons: {}
                });

                $('#[CampoFoco]').focus();

            } else {
                ocultarFeedback();
                ExibirMessageBox(resultado.Mensagem);
            }

        },

        failure: function (msg) {
            ocultarFeedback();
            ExibirMessageBox('Ocorreu um erro interno. ' + msg);

        }

    });
}

function Excluir(codigo) {

    exibirFeedback();

    $.ajax({
        type: "POST",
        url: "../WebServices/Ws[NomeClasse].asmx/Excluir",
        data: "{ 'codigo': '" + codigo + "'}",

        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {

            var resultado = (typeof response.d) == 'string' ? eval('(' + response.d + ')') : response.d;

            if (resultado.Sucesso) {
                Pesquisar();

            } else {
                ocultarFeedback();
                ExibirMessageBox(resultado.Mensagem);
            }

        },

        failure: function (msg) {
            ocultarFeedback();
            ExibirMessageBox('Ocorreu um erro interno. ' + msg);

        }

    });
}

function AbrirNovo() {
    
    [LimparTela]
    
    $("#divPopupCadastro").dialog({
        resizable: false,
        height: [AlturaPopup],
        width: 600,
        modal: true,
        buttons: {}
    });

    $('#[CampoFoco]').focus();
}

function Gravar() {

    exibirFeedback();

    $.ajax({
        type: "POST",
        url: "../WebServices/Ws[NomeClasse].asmx/Gravar",
        data: "{ [ParametrosGravar] }",

        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {

            var resultado = (typeof response.d) == 'string' ? eval('(' + response.d + ')') : response.d;

            if (resultado.Sucesso) {

                $("#divPopupCadastro").dialog("close");

                Pesquisar();


            } else {
                ocultarFeedback();
                ExibirMessageBox(resultado.Mensagem);
            }

        },

        failure: function (msg) {
            ocultarFeedback();
            ExibirMessageBox('Ocorreu um erro interno. ' + msg);

        }

    });
}