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
    public partial class FrmExames : Form
    {
        public double _codigo;

        public FrmExames()
        {
            InitializeComponent();
        }



        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void CarregaComboUsuarios(IBanco banco)
        {
            var pessoas = Pessoa.ConsultarTodas(banco, true);
            double userlogado = Convert.ToDouble(banco.LerConfiguracao("USER_LOGADO", ""));
            double maiorPermissao = PermissaoPessoa.MaiorPermissao(banco, userlogado);

            foreach (var item in pessoas)
            {
                cboUsuarios.Adicionar(item.Usuario, item.Codigo);
            }

            double userPaciente = Convert.ToDouble(banco.LerConfiguracao("USER_PACIENTE", "0"));
            if (userPaciente > 0 && maiorPermissao == (double)PermissaoPessoa.ePermissao.Medico)
                cboUsuarios.Posicionar(userPaciente);
            else
                cboUsuarios.SelectedIndex = 1;
        }

        private void CarregaComboTiposExame(IBanco banco)
        {
            var tipos = TipoExame.ConsultarTodos(banco, false);

            foreach (var item in tipos)
            {
                cboTiposExames.Adicionar(item.NomeExame, item.Codigo);
            }

            cboTiposExames.SelectedIndex = 0;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {

            IBanco banco = null;

            try
            {
                if ((int)cboUsuarios.ObterValor() == 0)
                    throw new Exception("Escolha um usuário");

                if ((int)cboTiposExames.ObterValor() == 0)
                    throw new Exception("Escolha um tipo de exame!");

                DateTime dt;
                if (!DateTime.TryParse(txtDataExame.Text, out dt))
                    throw new Exception("Data do exame inválida!");

                if (!DateTime.TryParse(txtDataResultado.Text, out dt))
                    throw new Exception("Data do resultado inválida!");

                if (Convert.ToDateTime(txtDataResultado.Text) < Convert.ToDateTime(txtDataExame.Text))
                    throw new Exception("Data do resultado deve ser igual ou posterior à data do exame!");


                banco = Utilitarios.ObterConexao();

                var exame = new Exame();
                exame.CodPaciente = (int)cboUsuarios.ObterValor();
                exame.DataExame = Convert.ToDateTime(txtDataExame.Text);
                exame.DataProvavelResultado = Convert.ToDateTime(txtDataResultado.Text);
                exame.TipoExame = (int)cboTiposExames.ObterValor();
                exame.Observacoes = txtObs.Text;
                Exame.Gravar(banco, exame);

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

        private void FrmExames_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                this.SelectNextControl(this.ActiveControl, !e.Shift, true, true, true);
            else if (e.KeyCode == Keys.Escape)
                Close();
        }

        private void FrmExames_Load(object sender, EventArgs e)
        {
            IBanco banco = null;

            try
            {
                banco = Utilitarios.ObterConexao();

                CarregaComboUsuarios(banco);
                CarregaComboTiposExame(banco);
                txtDataExame.Text = DateTime.Now.ToString("dd/MM/yyyy");

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
