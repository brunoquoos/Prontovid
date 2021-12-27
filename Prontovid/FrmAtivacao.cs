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
    public partial class FrmAtivacao : Form
    {
        public FrmAtivacao()
        {
            InitializeComponent();
        }


        private void FrmAtivacao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                this.SelectNextControl(this.ActiveControl, !e.Shift, true, true, true);
            else if (e.KeyCode == Keys.Escape)
                Close();
        }

        private void btnAtivar_Click(object sender, EventArgs e)
        {
            IBanco banco = null;

            try
            {
                banco = Utilitarios.ObterConexao();

                var pessoa = Pessoa.ConsultarChave(banco, (int)cboUsuarios.ObterValor());
                var responsavel = Pessoa.ConsultarChave(banco, (int)cboResponsavel.ObterValor());
                if (pessoa != null)
                {
                    if (Program.CalculaIdade(Convert.ToDateTime(pessoa.DataNascimento)) < 18)
                    {
                        if (responsavel == null)
                            throw new Exception("Para menores de idade é necessário um usuário responsável!");
                        else if (Program.CalculaIdade(Convert.ToDateTime(responsavel.DataNascimento)) < 18)
                            throw new Exception("O responsável deve ser maior de idade!");
                    }
                }

                pessoa.Ativo = true;
                Pessoa.Gravar(banco, pessoa);

                //Responsável pela ativação
                if ((int)cboResponsavelAtivacao.ObterValor() > 0)
                {
                    var resp = new ResponsavelAtivacao();
                    resp.CodPaciente = pessoa.Codigo;
                    resp.CodResponsavelAtivacao = (int)cboResponsavelAtivacao.ObterValor();
                    resp.DataAtivacao = DateTime.Now;
                    ResponsavelAtivacao.Gravar(banco, resp);
                }

                //Responsável pelo menor de idade
                if ((int)cboResponsavel.ObterValor() > 0 && cboResponsavel.Visible)
                {
                    var resp = new ResponsavelPaciente();
                    resp.CodPaciente = pessoa.Codigo;
                    resp.CodResponsavel = (int)cboResponsavel.ObterValor();
                    ResponsavelPaciente.Gravar(banco, resp);
                }

                var maiorPermissao = PermissaoPessoa.MaiorPermissaoObj(banco, pessoa.Codigo);
                if (maiorPermissao == null)
                {
                    var permissao = new PermissaoPessoa();
                    permissao.CodAdmin = (int)cboResponsavelAtivacao.ObterValor();
                    permissao.CodPermissao = 1;
                    permissao.CodPessoa = pessoa.Codigo;
                    PermissaoPessoa.Gravar(banco, permissao);
                }

                Msg.Informar("Cadastro ativo!");
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

        private void CarregaComboResponsavel(IBanco banco)
        {
            cboResponsavel.Items.Clear();
            cboResponsavel.LimparItemData();
            var pessoas = Pessoa.ConsultarTodas(banco, true);
            foreach (var item in pessoas)
            {
                if (Program.CalculaIdade(Convert.ToDateTime(item.DataNascimento)) >= 18)
                    cboResponsavel.Adicionar(item.Usuario, item.Codigo);
            }

            cboResponsavel.SelectedIndex = 0;
        }

        private void CarregaComboResponsavelAtivacao(IBanco banco)
        {

            bool ativar = false;
            var pessoas = Pessoa.ConsultarTodas(banco, false);
            foreach (var item in pessoas)
            {
                if (Convert.ToDouble(banco.LerConfiguracao("USER_LOGADO", "")) == item.Codigo)
                {
                    cboResponsavelAtivacao.Adicionar(item.Usuario, item.Codigo);
                }
            }

            cboResponsavelAtivacao.SelectedIndex = 0;
        }

        private void CarregaComboUsuarios(IBanco banco)
        {

            bool ativar = false;
            var pessoas = Pessoa.ConsultarTodas(banco, false);
            foreach (var item in pessoas)
            {
                if (Convert.ToDouble(banco.LerConfiguracao("USER_LOGADO", "")) != item.Codigo && !item.Ativo)
                {
                    cboUsuarios.Adicionar(item.Usuario, item.Codigo);
                    ativar = true;
                }
            }
            if (ativar)
                cboUsuarios.SelectedIndex = 1;
        }

        private void FrmAtivacao_Load(object sender, EventArgs e)
        {
            IBanco banco = null;

            try
            {
                banco = Utilitarios.ObterConexao();
                CarregaComboUsuarios(banco);
                CarregaComboResponsavelAtivacao(banco);
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

        private void cboUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {

            IBanco banco = null;

            try
            {
                banco = Utilitarios.ObterConexao();
                var pessoa = Pessoa.ConsultarChave(banco, (int)cboUsuarios.ObterValor());
                if (pessoa != null)
                {
                    txtPessoa.Text = pessoa.Nome;
                    if (Program.CalculaIdade(Convert.ToDateTime(pessoa.DataNascimento)) < 18)
                    {
                        CarregaComboResponsavel(banco);
                        cboResponsavel.Visible = true;
                        lblResponsavel.Visible = true;
                        txtResponsavelMenor.Visible = true;
                    }
                    else
                    {
                        cboResponsavel.Visible = false;
                        lblResponsavel.Visible = false;
                        txtResponsavelMenor.Visible = false;
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

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cboResponsavelAtivacao_SelectedIndexChanged(object sender, EventArgs e)
        {
            IBanco banco = null;

            try
            {
                banco = Utilitarios.ObterConexao();
                var pessoa = Pessoa.ConsultarChave(banco, (int)cboResponsavelAtivacao.ObterValor());
                if (pessoa != null)
                    txtResponsavelAtivacao.Text = pessoa.Nome;
                else
                    txtResponsavelAtivacao.Text = "";
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

        private void cboResponsavel_SelectedIndexChanged(object sender, EventArgs e)
        {
            IBanco banco = null;

            try
            {
                banco = Utilitarios.ObterConexao();
                var pessoa = Pessoa.ConsultarChave(banco, (int)cboResponsavel.ObterValor());
                if (pessoa != null)
                    txtResponsavelMenor.Text = pessoa.Nome;
                else
                    txtResponsavelMenor.Text = "";
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
    }
}
