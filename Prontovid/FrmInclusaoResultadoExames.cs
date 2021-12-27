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
    public partial class FrmInclusaoResultadoExames : Form
    {
        public double _codigo;

        public FrmInclusaoResultadoExames()
        {
            InitializeComponent();
        }



        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void CarregaComboStatusPessoa(IBanco banco)
        {
            cboStatusPessoa.Adicionar("Ok - Verde", 0);
            cboStatusPessoa.Adicionar("Atenção - Amarelo", 1);
            cboStatusPessoa.Adicionar("Alerta - Vermelho", 2);
            cboStatusPessoa.Posicionar(0);
        }

        private void CarregaComboUsuarios(IBanco banco)
        {
            var pessoas = Pessoa.ConsultarTodas(banco, true);
            double userlogado = Convert.ToDouble(banco.LerConfiguracao("USER_LOGADO", ""));
            double maiorPermissao = PermissaoPessoa.MaiorPermissao(banco, userlogado);

            foreach (var item in pessoas)
            {
                if ((_codigo > 0 && userlogado == item.Codigo) || (userlogado != item.Codigo || maiorPermissao == (double)PermissaoPessoa.ePermissao.Administrador))
                    cboUsuarios.Adicionar(item.Usuario, item.Codigo);
            }

            double userPaciente = Convert.ToDouble(banco.LerConfiguracao("USER_PACIENTE", "0"));
            if (userPaciente > 0 && maiorPermissao == (double)PermissaoPessoa.ePermissao.Medico)
                cboUsuarios.Posicionar(userPaciente);
            else
                cboUsuarios.SelectedIndex = 1;
        }

        private void CarregaComboExame(IBanco banco, double codPessoa)
        {
            cboExame.Items.Clear();
            cboExame.LimparItemData();
            var examesPessoa = Exame.ConsultarTodos(banco, codPessoa);
            bool existeExame = false;

            foreach (var item in examesPessoa)
            {
                var tipoExame = TipoExame.ConsultarChave(banco, item.TipoExame);
                var resExame = ResultadoExame.ConsultarResultadoExame(banco, item.Codigo);

                if (_codigo > 0 || (_codigo == 0 && resExame == null))
                {
                    cboExame.Adicionar(item.Codigo.ToString() + " - " + tipoExame.NomeExame, item.Codigo);
                    existeExame = true;
                }
            }
            if (existeExame)
            {
                cboExame.SelectedIndex = 0;
            }
            else if (_codigo == 0)
            {
                LimparDadosExame();
            }

        }


        private void btnSalvar_Click(object sender, EventArgs e)
        {

            IBanco banco = null;

            try
            {
                if ((int)cboUsuarios.ObterValor() == 0)
                    throw new Exception("Escolha um usuário!");

                if ((int)cboExame.ObterValor() == 0)
                    throw new Exception("Escolha um exame!");

                DateTime dt;
                if (!DateTime.TryParse(txtDataResultado.Text, out dt))
                    throw new Exception("Data de resultado do exame inválida!");

                if (Convert.ToDateTime(txtDataResultado.Text) < Convert.ToDateTime(txtDataExame.Text))
                    throw new Exception("Data do resultado deve ser igual ou posterior à data do exame!");


                banco = Utilitarios.ObterConexao();
                double userlogado = Convert.ToDouble(banco.LerConfiguracao("USER_LOGADO", ""));
                var resultadoExame = new ResultadoExame();
                resultadoExame.CodExame = (int)cboExame.ObterValor();
                resultadoExame.DataResultado = Convert.ToDateTime(txtDataResultado.Text);
                resultadoExame.Resultado = txtResultado.Text;
                resultadoExame.Observacoes = txtObsResultado.Text;
                resultadoExame.ResponsavelResultado = userlogado;
                ResultadoExame.Gravar(banco, resultadoExame);

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




        private void cboUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            IBanco banco = null;

            try
            {
                banco = Utilitarios.ObterConexao();

                var p = Pessoa.ConsultarChave(banco, (int)cboUsuarios.ObterValor());
                if (p != null)
                {
                    txtPaciente.Text = p.Nome;
                    CarregaComboExame(banco, p.Codigo);
                }
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

        private void cboExame_SelectedIndexChanged(object sender, EventArgs e)
        {
            IBanco banco = null;

            try
            {
                banco = Utilitarios.ObterConexao();

                var exame = Exame.ConsultarChave(banco, (double)cboExame.ObterValor());
                if (exame != null)
                {
                    txtDataExame.Text = exame.DataExame.ToString("dd/MM/yyyy");
                    txtDataResultadoProvavel.Text = exame.DataProvavelResultado.ToString("dd/MM/yyyy");
                    txtObs.Text = exame.Observacoes;
                    txtDataResultado.Text = DateTime.Now.ToString("dd/MM/yyyy");
                }
                else
                {
                    LimparDadosExame();
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

        private void LimparDadosExame()
        {
            txtDataExame.Text = "";
            txtDataResultadoProvavel.Text = "";
            txtDataResultado.Text = "";
            txtObs.Text = "";
            txtObsResultado.Text = "";
        }

        private void FrmInclusaoResultadoExames_Load(object sender, EventArgs e)
        {
            IBanco banco = null;

            try
            {
                banco = Utilitarios.ObterConexao();

                CarregaComboUsuarios(banco);
                CarregaComboStatusPessoa(banco);

                if (_codigo != 0)
                    CarregaResultadoExame(banco);


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

        private void CarregaResultadoExame(IBanco banco)
        {
            txtDataResultado.Enabled = false;
            cboExame.Enabled = false;
            cboUsuarios.Enabled = false;
            txtResultado.Enabled = false;
            txtObs.Enabled = false;
            txtObsResultado.Enabled = false;

            btnCancelar.Text = "Voltar";
            btnCancelar.Left = btnSalvar.Left;
            btnSalvar.Visible = false;
            cboStatusPessoa.Visible = false;
            lblStatusPessoa.Visible = false;

            var exame = Exame.ConsultarChave(banco, _codigo);
            var resExame = ResultadoExame.ConsultarResultadoExame(banco, _codigo);

            cboUsuarios.Posicionar(exame.CodPaciente);
            cboExame.Posicionar(exame.Codigo);

            if (resExame != null)
            {
                txtDataResultado.Text = resExame.DataResultado.ToString("dd/MM/yyyy");
                txtResultado.Text = resExame.Resultado;
                txtObsResultado.Text = resExame.Observacoes;
            }
        }

        private void FrmInclusaoResultadoExames_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                this.SelectNextControl(this.ActiveControl, !e.Shift, true, true, true);
            else if (e.KeyCode == Keys.Escape)
                Close();
        }
    }
}
