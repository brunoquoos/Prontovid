using Prontovid.Biblioteca;
using Prontovid.Biblioteca.Biblioteca.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telecon.Genericos.Classes.BancoDeDados;
using Telecon.Genericos.Classes.Outros;
using Telecon.Genericos.Classes.TiposDados;

namespace Prontovid
{
    public partial class FrmSintomas : Form
    {
        public double _codigo;
        private bool _salvouDadosSintoma;
        private List<string> _listPartesCorpo = new List<string>();

        public FrmSintomas()
        {
            InitializeComponent();
        }

        private void Cancelar()
        {
            IBanco banco = null;

            if (_salvouDadosSintoma && _codigo == 0)
            {
                if (Msg.PerguntarPadraoNao("Você vai perder todos os dados de sintomas inseridos nesta tela! Tem certeza que deseja cancelar?") == DialogResult.Yes)
                {

                    try
                    {
                        banco = Utilitarios.ObterConexao();
                        if (Convert.ToDouble(txtCodSintomaPaciente.Text) > 0)
                        {
                            var sintomaPaciente = SintomaPaciente.ConsultarChave(banco, Convert.ToDouble(txtCodSintomaPaciente.Text));
                            var dadosSintoma = DadoSintoma.ConsultarPeloSintomasPaciente(banco, sintomaPaciente.Codigo);
                            foreach (var item in dadosSintoma)
                            {
                                DadoSintoma.Excluir(banco, item);
                            }
                            SintomaPaciente.Excluir(banco, sintomaPaciente);
                        }

                    }
                    catch (Exception erro)
                    {
                        Msg.Criticar(erro.Message);
                    }
                    finally
                    {
                        if (banco != null)
                            banco.FecharConexao();

                        Close();
                    }
                }
            }
            else
                Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Cancelar();
        }

        private void CarregaComboUsuarios(IBanco banco)
        {
            var pessoas = Pessoa.ConsultarTodas(banco, true);
            double userlogado = Convert.ToDouble(banco.LerConfiguracao("USER_LOGADO", ""));
            double maiorPermissao = PermissaoPessoa.MaiorPermissao(banco, userlogado);

            foreach (var item in pessoas)
            {
                if (userlogado != item.Codigo || maiorPermissao == (double)PermissaoPessoa.ePermissao.Administrador)
                    cboUsuarios.Adicionar(item.Usuario, item.Codigo);
            }

            double userPaciente = Convert.ToDouble(banco.LerConfiguracao("USER_PACIENTE", "0"));
            if (userPaciente > 0 && maiorPermissao == (double)PermissaoPessoa.ePermissao.Medico)
                cboUsuarios.Posicionar(userPaciente);
            else
                cboUsuarios.SelectedIndex = 1;
        }

        private void CarregaComboTiposSintomasPaciente(IBanco banco)
        {
            if (_codigo == 0)
                cboTiposSintomasPaciente.Adicionar("Novo tipo", 0);

            var tiposSintomas = new List<TipoSintomaPaciente>();

            if (_codigo > 0)
            {
                var dadosSintoma = DadoSintoma.ConsultarPeloSintomasPaciente(banco, _codigo);
                foreach (var d in dadosSintoma)
                    tiposSintomas.Add(TipoSintomaPaciente.ConsultarChave(banco, d.CodigoTipoSintoma));
            }
            else
            {
                tiposSintomas = TipoSintomaPaciente.ConsultarTodos(banco);
            }

            foreach (var item in tiposSintomas)
            {
                cboTiposSintomasPaciente.Adicionar(item.NomeTipo, item.CodigoTipo);
            }

            cboTiposSintomasPaciente.SelectedIndex = 0;
        }

        private void CarregaComboCategoriaGravidade(IBanco banco)
        {
            cboCategoriaGravidade.Adicionar("Leve", (int)DadoSintoma.eCategoriaGravidade.Leve);
            cboCategoriaGravidade.Adicionar("Moderada", (int)DadoSintoma.eCategoriaGravidade.Moderada);
            cboCategoriaGravidade.Adicionar("Grave", (int)DadoSintoma.eCategoriaGravidade.Grave);
            cboCategoriaGravidade.Posicionar(0);
        }

        private void CarregaComboProgressao(IBanco banco)
        {
            cboProgressao.Adicionar("Piorando", (int)DadoSintoma.eProgressao.Piorando);
            cboProgressao.Adicionar("Imutavel", (int)DadoSintoma.eProgressao.Imutavel);
            cboProgressao.Adicionar("Melhorando", (int)DadoSintoma.eProgressao.Melhorando);
            cboProgressao.Adicionar("Resolvido", (int)DadoSintoma.eProgressao.Resolvido);

            cboProgressao.Posicionar(0);
        }

        private void CarregaCombocboEfeitoFatorModificador(IBanco banco)
        {
            cboEfeitoFatorModificador.Adicionar("Alivia", 0);
            cboEfeitoFatorModificador.Adicionar("Sem efeito", 1);
            cboEfeitoFatorModificador.Adicionar("Piora", 2);

            cboEfeitoFatorModificador.Posicionar(0);
        }

        private void CarregaComboTipoInicio(IBanco banco)
        {
            cboTipoInicio.Adicionar("Novo", (int)DadoSintoma.eTipoInicio.Gradual);
            cboTipoInicio.Adicionar("Em Curso", (int)DadoSintoma.eTipoInicio.Subito);
            cboTipoInicio.Posicionar(0);
        }

        private void CarregaComboEpisodicidade(IBanco banco)
        {
            cboEpisodicidade.Adicionar("Novo", (int)DadoSintoma.eEpisodicidade.Novo);
            cboEpisodicidade.Adicionar("Em Curso", (int)DadoSintoma.eEpisodicidade.EmCurso);
            cboEpisodicidade.Adicionar("Indeterminado", (int)DadoSintoma.eEpisodicidade.Indeterminado);
            cboEpisodicidade.Posicionar(0);
        }

        private void CarregaComboStatusPessoa(IBanco banco)
        {
            cboStatusPessoa.Adicionar("Ok - Verde", 0);
            cboStatusPessoa.Adicionar("Atenção - Amarelo", 1);
            cboStatusPessoa.Adicionar("Alerta - Vermelho", 2);
            controlaStatusPessoa();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {

            IBanco banco = null;

            try
            {
                if (Convert.ToInt32(txtSaturacao.Text) < 0 || Convert.ToInt32(txtSaturacao.Text) > 100)
                {
                    Msg.Criticar("Saturação deve ser entre 0 e 100%");
                    txtSaturacao.Focus();
                    return;
                }
                if (Convert.ToDouble(txtTemperatura.Text) < 30 || Convert.ToDouble(txtTemperatura.Text) > 45)
                {
                    Msg.Criticar("Temperatura inválida!");
                    txtTemperatura.Focus();
                    return;
                }
                if (!Texto.TestarInteiro(txtCodSintomaPaciente.Text))
                {
                    Msg.Criticar("Necessário adicionar ao menos um sintoma!");
                    cboTiposSintomasPaciente.Focus();
                    return;
                }

                banco = Utilitarios.ObterConexao();
                double userlogado = Convert.ToDouble(banco.LerConfiguracao("USER_LOGADO", ""));

                var sintomasPaciente = new SintomaPaciente();
                if (Convert.ToInt32(txtCodSintomaPaciente.Text) != 0)
                {
                    sintomasPaciente = SintomaPaciente.ConsultarChave(banco, Convert.ToDouble(txtCodSintomaPaciente.Text));
                }

                sintomasPaciente.CodPaciente = (int)cboUsuarios.ObterValor();
                sintomasPaciente.DataInsercao = DateTime.Now;
                sintomasPaciente.ResponsavelInsercao = userlogado;
                sintomasPaciente.Saturacao = Convert.ToInt32(txtSaturacao.Text);
                sintomasPaciente.Temperatura = Convert.ToDecimal(txtTemperatura.Text);
                sintomasPaciente.EstadoGeral = trkEstadoGeral.Value;
                sintomasPaciente.CodStatusPessoa = cboStatusPessoa.ObterValor();
                SintomaPaciente.Gravar(banco, sintomasPaciente);

                var statusPessoa = new StatusPessoa();
                statusPessoa.CodPaciente = (int)cboUsuarios.ObterValor();
                statusPessoa.CodResponsavel = userlogado;
                statusPessoa.CodStatus = (int)cboStatusPessoa.ObterValor();
                statusPessoa.DataStatus = DateTime.Now;
                StatusPessoa.Gravar(banco, statusPessoa);

                Close();
            }
            catch (Exception erro)
            {
                Msg.Criticar(erro.Message);
            }
            finally
            {
                if (banco != null)
                    banco.FecharConexao();
            }
        }

        private void FrmSintomas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                this.SelectNextControl(this.ActiveControl, !e.Shift, true, true, true);
            else if (e.KeyCode == Keys.Escape)
                Cancelar();
        }

        private void FrmSintomas_Load(object sender, EventArgs e)
        {
            IBanco banco = null;

            try
            {
                banco = Utilitarios.ObterConexao();

                CarregaComboUsuarios(banco);
                CarregaComboTiposSintomasPaciente(banco);
                CarregaComboStatusPessoa(banco);
                CarregaComboEpisodicidade(banco);
                CarregaComboCategoriaGravidade(banco);
                CarregaComboProgressao(banco);
                CarregaCombocboEfeitoFatorModificador(banco);
                CarregaComboTipoInicio(banco);
                inicializaLvwParteDoCorpoSintomas();

                if (_codigo > 0)
                {
                    CarregarAtendimento(banco);
                }
            }
            catch (Exception erro)
            {
                Msg.Criticar(erro.Message);
            }
            finally
            {
                if (banco != null)
                    banco.FecharConexao();
            }
        }

        private void CarregarAtendimento(IBanco banco)
        {
            grbDadosSintoma.Enabled = false;
            cboStatusPessoa.Enabled = false;
            cboUsuarios.Enabled = false;
            txtTemperatura.Enabled = false;
            txtSaturacao.Enabled = false;
            trkEstadoGeral.Enabled = false;
            btnAddSintoma.Enabled = false;
            btnSalvar.Visible = false;
            btnCancelar.Left = btnSalvar.Left;
        }

        private void cboUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            IBanco banco = null;

            try
            {
                banco = Utilitarios.ObterConexao();

                var p = Pessoa.ConsultarChave(banco, (int)cboUsuarios.ObterValor());
                if (p != null)
                    txtPaciente.Text = p.Nome;
                else
                    txtPaciente.Text = "";
            }
            catch (Exception erro)
            {
                Msg.Criticar(erro.Message);
            }
            finally
            {
                if (banco != null)
                    banco.FecharConexao();
            }
        }



        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void caixaTexto3_TextChanged(object sender, EventArgs e)
        {

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {

        }

        private void btnAddSintoma_Click(object sender, EventArgs e)
        {
            IBanco banco = null;

            try
            {
                banco = Utilitarios.ObterConexao();

                if (Convert.ToInt32(txtSaturacao.Text) < 0 || Convert.ToInt32(txtSaturacao.Text) > 100)
                {
                    Msg.Criticar("Saturação deve ser entre 0 e 100%");
                    txtSaturacao.Focus();
                    return;
                }
                if (Convert.ToDouble(txtTemperatura.Text) < 30 || Convert.ToDouble(txtTemperatura.Text) > 45)
                {
                    Msg.Criticar("Temperatura inválida!");
                    txtTemperatura.Focus();
                    return;
                }

                trkClassificacaoGravidade.Value = 5;
                txtInicioEpisodio.Text = DateTime.Now.ToString("dd/MM/yyyy");

                if ((int)cboTiposSintomasPaciente.ObterValor() > 0)
                {
                    var tipo = TipoSintomaPaciente.ConsultarChave(banco, (int)cboTiposSintomasPaciente.ObterValor());
                    txtNomeDadoSintoma.Text = tipo.NomeTipo;
                    txtDescricaoDadoSintoma.Text = tipo.DescricaoTipo;
                }
                else
                {
                    txtNomeDadoSintoma.Text = "";
                    txtDescricaoDadoSintoma.Text = "";
                }

            }
            catch (Exception erro)
            {
                Msg.Criticar(erro.Message);
            }
            finally
            {
                if (banco != null)
                    banco.FecharConexao();
            }

            AlteraTela(true);

            if (!string.IsNullOrEmpty(txtNomeDadoSintoma.Text))
                chkNaoSignificante.Focus();
        }

        private void btnSalvarDadosSintoma_Click(object sender, EventArgs e)
        {
            IBanco banco = null;

            try
            {
                banco = Utilitarios.ObterConexao();

                DateTime dt;
                if (!DateTime.TryParse(txtInicioEpisodio.Text, out dt))
                {
                    throw new Exception("Data de inicio do episódio inválida!");
                }

                _salvouDadosSintoma = true;

                var tipo = TipoSintomaPaciente.ConsultarPeloNome(banco, txtNomeDadoSintoma.Text);
                if (tipo == null)
                {
                    tipo = new TipoSintomaPaciente();
                    tipo.NomeTipo = txtNomeDadoSintoma.Text;
                    tipo.DescricaoTipo = txtDescricaoDadoSintoma.Text;
                    TipoSintomaPaciente.Gravar(banco, tipo);
                }

                double userlogado = Convert.ToDouble(banco.LerConfiguracao("USER_LOGADO", ""));
                var sintomasPaciente = new SintomaPaciente();
                if (Convert.ToDouble(txtCodSintomaPaciente.Text) > 0)
                    sintomasPaciente = SintomaPaciente.ConsultarChave(banco, Convert.ToDouble(txtCodSintomaPaciente.Text));

                sintomasPaciente.CodPaciente = (int)cboUsuarios.ObterValor();
                sintomasPaciente.DataInsercao = DateTime.Now;
                sintomasPaciente.ResponsavelInsercao = userlogado;
                sintomasPaciente.Saturacao = Convert.ToInt32(txtSaturacao.Text);
                sintomasPaciente.Temperatura = Convert.ToDecimal(txtTemperatura.Text);
                sintomasPaciente.EstadoGeral = trkEstadoGeral.Value;
                sintomasPaciente.CodStatusPessoa = cboStatusPessoa.ObterValor();
                SintomaPaciente.Gravar(banco, sintomasPaciente);

                txtCodSintomaPaciente.Text = sintomasPaciente.Codigo.ToString();

                var dadosSintoma = new DadoSintoma();
                dadosSintoma.CodSintomasPaciente = sintomasPaciente.Codigo;
                dadosSintoma.NomeSintoma = txtNomeDadoSintoma.Text;
                dadosSintoma.DescricaoSintoma = txtDescricaoDadoSintoma.Text;
                dadosSintoma.Duracao = txtDuracao.Text;
                dadosSintoma.InicioEpisodio = Convert.ToDateTime(txtInicioEpisodio.Text);
                dadosSintoma.Padrao = txtPadrao.Text;
                dadosSintoma.NaoSignificante = chkNaoSignificante.Checked;
                dadosSintoma.PrimeiraVez = chkPrimeiraVez.Checked;
                dadosSintoma.Progressao = (int)cboProgressao.ObterValor();
                dadosSintoma.TipoDeInicio = (int)cboTipoInicio.ObterValor();
                dadosSintoma.Episodicidade = (int)cboEpisodicidade.ObterValor();
                dadosSintoma.CategoriaGravidade = (int)cboCategoriaGravidade.ObterValor();
                dadosSintoma.ClassificacaoGravidade = trkClassificacaoGravidade.Value;
                dadosSintoma.DescricaoEpisodio = txtDescricaoDoEpisodio.Text;
                dadosSintoma.Impacto = txtImpacto.Text;
                dadosSintoma.DescricaoEpisodiosPrevios = txtDescricaoEpisodiosPrevios.Text;
                if (tipo == null)
                    dadosSintoma.CodigoTipoSintoma = cboTiposSintomasPaciente.ObterValor();
                else
                    dadosSintoma.CodigoTipoSintoma = tipo.CodigoTipo;

                if (string.IsNullOrEmpty(txtFimEpisodio.Text))
                    dadosSintoma.FimEpisodio = null;
                else
                    dadosSintoma.FimEpisodio = Convert.ToDateTime(txtFimEpisodio.Text);

                DadoSintoma.Gravar(banco, dadosSintoma);

                if (lvwParteDoCorpoSintoma.Items.Count > 0)
                {
                    foreach (ListViewItem itemRow in lvwParteDoCorpoSintoma.Items)
                    {
                        var parte = new PartedoCorpoSintoma();
                        parte.CodSintoma = dadosSintoma.CodSintoma;
                        parte.Descricao = itemRow.SubItems[0].Text;
                        PartedoCorpoSintoma.Gravar(banco, parte);
                    }
                }

                AlteraTela(false);

            }
            catch (Exception erro)
            {
                Msg.Criticar(erro.Message);
                txtInicioEpisodio.Focus();
            }
            finally
            {
                if (banco != null)
                    banco.FecharConexao();

            }
        }

        private void btnCancelarDadosSintoma_Click(object sender, EventArgs e)
        {
            AlteraTela(false);
        }

        private void AlteraTela(bool inserindoSintoma)
        {
            grbDadosSintoma.Visible = inserindoSintoma;
            btnSalvar.Enabled = !inserindoSintoma;
            btnCancelar.Enabled = !inserindoSintoma;
            grbPaciente.Enabled = !inserindoSintoma;
            _listPartesCorpo.Clear();
        }

        private void txtPaciente_TextChanged(object sender, EventArgs e)
        {

        }

        private void cboStatusPessoa_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cboTiposSintomasPaciente_SelectedIndexChanged(object sender, EventArgs e)
        {
            IBanco banco = null;

            try
            {
                banco = Utilitarios.ObterConexao();

                if (_codigo > 0)
                {
                    grbDadosSintoma.Visible = true;

                    var sintomasPaciente = SintomaPaciente.ConsultarChave(banco, _codigo);
                    if (sintomasPaciente != null)
                    {
                        cboUsuarios.Posicionar(sintomasPaciente.CodPaciente);                        
                        txtTemperatura.Text = sintomasPaciente.Temperatura.ToString("0.0");
                        txtSaturacao.Text = sintomasPaciente.Saturacao.ToString();
                        trkEstadoGeral.Value = sintomasPaciente.EstadoGeral;
                        cboStatusPessoa.Posicionar(sintomasPaciente.CodStatusPessoa);
                        controlaStatusPessoa();
                    }

                    var dadosSintoma = DadoSintoma.ConsultarChave(banco, cboTiposSintomasPaciente.ObterValor(), _codigo);
                    if (dadosSintoma != null)
                    {
                        cboCategoriaGravidade.Posicionar(dadosSintoma.CategoriaGravidade);
                        cboEpisodicidade.Posicionar(dadosSintoma.Episodicidade);
                        cboProgressao.Posicionar(dadosSintoma.Progressao);
                        cboTipoInicio.Posicionar(dadosSintoma.TipoDeInicio);
                        txtDescricaoDadoSintoma.Text = dadosSintoma.DescricaoSintoma;
                        txtDescricaoDoEpisodio.Text = dadosSintoma.DescricaoEpisodio;
                        txtDescricaoEpisodiosPrevios.Text = dadosSintoma.DescricaoEpisodiosPrevios;
                        txtDuracao.Text = dadosSintoma.Duracao;
                        txtImpacto.Text = dadosSintoma.Impacto;
                        txtInicioEpisodio.Text = dadosSintoma.InicioEpisodio.ToString("dd/MM/yyyy");
                        txtNomeDadoSintoma.Text = dadosSintoma.NomeSintoma;
                        txtPadrao.Text = dadosSintoma.Padrao;
                        trkClassificacaoGravidade.Value = dadosSintoma.ClassificacaoGravidade;
                        chkNaoSignificante.Checked = dadosSintoma.NaoSignificante;
                        chkPrimeiraVez.Checked = dadosSintoma.PrimeiraVez;
                        if (!string.IsNullOrEmpty(dadosSintoma.FimEpisodio.ToString()))
                            txtFimEpisodio.Text = Convert.ToDateTime(dadosSintoma.FimEpisodio).ToString("dd/MM/yyyy");

                        var partesCorpo = PartedoCorpoSintoma.ConsultarPeloCodSintoma(banco, dadosSintoma.CodSintoma);
                        _listPartesCorpo.Clear();
                        foreach (var i in partesCorpo)
                        {
                            _listPartesCorpo.Add(i.Descricao);
                        }

                        lvwParteDoCorpoSintoma.Visible = false;
                        lvwParteDoCorpoSintoma.Items.Clear();
                        foreach (var i in _listPartesCorpo)
                        {
                            ListViewItem lvi = new ListViewItem(i);
                            lvwParteDoCorpoSintoma.Items.Add(lvi);
                        }
                        lvwParteDoCorpoSintoma.Visible = true;                        
                    }
                }

            }
            catch (Exception erro)
            {
                Msg.Criticar(erro.Message);
            }
            finally
            {
                if (banco != null)
                    banco.FecharConexao();
            }
        }

        private void lnkDias_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            txtDuracao.Text = txtDuracao.Text.Replace(" dias", "");
            txtDuracao.Text = txtDuracao.Text.Replace(" dia", "");
            txtDuracao.Text = txtDuracao.Text.Replace(" meses", "");
            txtDuracao.Text = txtDuracao.Text.Replace(" mês", "");
            txtDuracao.Text = txtDuracao.Text.Replace(" anos", "");
            txtDuracao.Text = txtDuracao.Text.Replace(" ano", "");

            if (Texto.TestarNumerico(txtDuracao.Text))
                if (Convert.ToInt32(txtDuracao.Text) == 1)
                    txtDuracao.Text = txtDuracao.Text + " dia";
                else
                    txtDuracao.Text = txtDuracao.Text + " dias";
        }

        private void lnkMeses_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            txtDuracao.Text = txtDuracao.Text.Replace(" dias", "");
            txtDuracao.Text = txtDuracao.Text.Replace(" dia", "");
            txtDuracao.Text = txtDuracao.Text.Replace(" meses", "");
            txtDuracao.Text = txtDuracao.Text.Replace(" mês", "");
            txtDuracao.Text = txtDuracao.Text.Replace(" anos", "");
            txtDuracao.Text = txtDuracao.Text.Replace(" ano", "");

            if (Texto.TestarNumerico(txtDuracao.Text))
                if (Convert.ToInt32(txtDuracao.Text) == 1)
                    txtDuracao.Text = txtDuracao.Text + " mês";
                else
                    txtDuracao.Text = txtDuracao.Text + " meses";
        }

        private void lnkAnos_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            txtDuracao.Text = txtDuracao.Text.Replace(" dias", "");
            txtDuracao.Text = txtDuracao.Text.Replace(" dia", "");
            txtDuracao.Text = txtDuracao.Text.Replace(" meses", "");
            txtDuracao.Text = txtDuracao.Text.Replace(" mês", "");
            txtDuracao.Text = txtDuracao.Text.Replace(" anos", "");
            txtDuracao.Text = txtDuracao.Text.Replace(" ano", "");


            if (Texto.TestarNumerico(txtDuracao.Text))
                if (Convert.ToInt32(txtDuracao.Text) == 1)
                    txtDuracao.Text = txtDuracao.Text + " ano";
                else
                    txtDuracao.Text = txtDuracao.Text + " anos";
        }


        private void btnAddParteCorpo_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtParteCorpo.Text))
                return;


            if (_listPartesCorpo.Count == 0)
                _listPartesCorpo.Add(txtParteCorpo.Text);
            else
            {
                if (_listPartesCorpo.Exists(l => l.Equals(txtParteCorpo.Text)))
                    Msg.Criticar("Parte do corpo já adicionada");
                else
                    _listPartesCorpo.Add(txtParteCorpo.Text);
            }

            lvwParteDoCorpoSintoma.Visible = false;
            lvwParteDoCorpoSintoma.Items.Clear();
            foreach (var i in _listPartesCorpo)
            {
                ListViewItem lvi = new ListViewItem(i);
                lvwParteDoCorpoSintoma.Items.Add(lvi);
            }

            lvwParteDoCorpoSintoma.Visible = true;
            txtParteCorpo.Text = "";
            txtParteCorpo.Focus();
        }

        private void inicializaLvwParteDoCorpoSintomas()
        {
            //Apenas cria e inicializa o listView vazio

            // exibe detalhes
            lvwParteDoCorpoSintoma.View = View.Details;
            // permite ao usuário rearranjar as colunas
            lvwParteDoCorpoSintoma.AllowColumnReorder = true;
            // Selecione o item e subitem quando um seleção for feita
            lvwParteDoCorpoSintoma.FullRowSelect = true;
            // Exibe as linhas no ListView
            lvwParteDoCorpoSintoma.GridLines = true;

            // Anexa Subitems no ListView
            lvwParteDoCorpoSintoma.Columns.Add("Descrição", 180, HorizontalAlignment.Left);
        }

        private void trkEstadoGeral_ValueChanged(object sender, EventArgs e)
        {
            controlaStatusPessoa();
        }

        private void controlaStatusPessoa()
        {
            if (!Texto.TestarNumerico(txtSaturacao.Text) || !Texto.TestarNumerico(txtTemperatura.Text))
                return;

            if (Convert.ToDouble(txtSaturacao.Text) < 90)
                cboStatusPessoa.Posicionar(2); //Vermelho
            else
            {
                if (Convert.ToDouble(txtTemperatura.Text) > 37.5 || Convert.ToDouble(txtSaturacao.Text) <= 95)
                    cboStatusPessoa.Posicionar(1); //Amarelo
                else
                {
                    if (trkEstadoGeral.Value < 4)
                        cboStatusPessoa.Posicionar(0); //Verde
                    else if (trkEstadoGeral.Value >= 4 && trkEstadoGeral.Value <= 6)
                        cboStatusPessoa.Posicionar(1); //Amarelo
                    else
                        cboStatusPessoa.Posicionar(2); //Vermelho
                }
            }
        }

        private void txtTemperatura_TextChanged(object sender, EventArgs e)
        {
            controlaStatusPessoa();
        }

        private void txtSaturacao_TextChanged(object sender, EventArgs e)
        {
            controlaStatusPessoa();
        }
    }
}
