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
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            IBanco banco = null;

            try
            {
                banco = Utilitarios.ObterConexao();
                
                var pessoa = Pessoa.ConsultarChave(banco, (int)cboUsuario.ObterValor());
                if (pessoa != null)
                {
                    if (pessoa.Senha.Equals(Texto.CriptografarTexto(txtSenha.Text)))
                    {
                        banco.GravarConfiguracao("USER_LOGADO", pessoa.Codigo.ToString()); 
                        this.Hide();
                        var form = new FrmInicio();
                        form.Closed += (s, args) => this.Close();
                        form.Show();
                    }
                    else
                    {
                        throw new Exception("Senha inválida");
                    }
                }
                else
                {
                    throw new Exception("Usuário não encontrado");
                }

            }
            catch (Exception erro)
            {
                Msg.Criticar(erro.Message);
                txtSenha.Text = "";
                txtSenha.Focus();
            }
            finally
            {
                if (banco != null)
                    banco.FecharConexao();
            }

        }

        private void btnCadastro_Click(object sender, EventArgs e)
        {
            var form = new FrmNovo();
            form.ShowDialog();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            IBanco banco = null;

            try
            {
                banco = Utilitarios.ObterConexao();
                banco.GravarConfiguracao("USER_LOGADO","");
                CarregaComboUsuarios(banco);
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

        private void CarregaComboUsuarios(IBanco banco)
        {
            var pessoas = Pessoa.ConsultarTodas(banco, true);
            foreach (var item in pessoas)
            {
                cboUsuario.Adicionar(item.Usuario, item.Codigo);
            }

            cboUsuario.SelectedIndex = 1;
        }

        private void FrmLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                this.SelectNextControl(this.ActiveControl, !e.Shift, true, true, true);
            else if (e.KeyCode == Keys.Escape)
                Close();
        }
    }
}
