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
    public partial class FrmNovo : Form
    {
        public double _codigo;

        public FrmNovo()
        {
            InitializeComponent();
        }


        private void FrmNovo_Load(object sender, EventArgs e)
        {
            IBanco banco = null;
            try
            {
                banco = Utilitarios.ObterConexao();
                CarregaComboNiveis(banco);

                double codUser = 0;
                string userlogado = banco.LerConfiguracao("USER_LOGADO", "");

                if (Texto.TestarNumerico(userlogado))
                {
                    var maiorPermissao = PermissaoPessoa.MaiorPermissao(banco, Convert.ToDouble(userlogado));
                    cboNiveis.Enabled = (maiorPermissao == (double)PermissaoPessoa.ePermissao.Administrador);
                    chkAtivo.Enabled = (maiorPermissao != (double)PermissaoPessoa.ePermissao.Paciente);
                    cboResponsavel.Enabled = (maiorPermissao != (double)PermissaoPessoa.ePermissao.Paciente);
                    grbDadosClinicos.Enabled = (maiorPermissao != (double)PermissaoPessoa.ePermissao.Paciente);
                }
                else
                {
                    cboNiveis.Posicionar(1);
                    cboNiveis.Enabled = false;
                    chkAtivo.Enabled = false;
                    cboResponsavel.Enabled = false;
                }

                if (_codigo > 0) //Alteração
                {
                    CarregarPessoa(banco);
                }
                else //Inserção
                {
                    if (Texto.TestarNumerico(userlogado))
                    {
                        var maiorPermissao = PermissaoPessoa.MaiorPermissao(banco, Convert.ToDouble(userlogado));
                        if (maiorPermissao != (double)PermissaoPessoa.ePermissao.Paciente)
                            chkAtivo.Checked = true;
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

        private void CarregarPessoa(IBanco banco)
        {
            var p = Pessoa.ConsultarChave(banco, _codigo);

            if (p != null)
            {
                txtCodigo.Visible = true;
                txtCodigo.Text = p.Codigo.ToString();
                txtNome.Text = p.Nome;
                txtDataNascimento.Text = p.DataNascimento.ToString("dd/MM/yyyy");
                txtCpf.Text = p.Cpf;
                txtTelefone.Text = p.Telefone;
                txtEndereco.Text = p.Endereco;
                txtEmail.Text = p.Email;
                txtUsuario.Text = p.Usuario;
                radMasc.Checked = p.Sexo.Equals("M");
                radFem.Checked = !p.Sexo.Equals("M");
                cboNiveis.Posicionar(PermissaoPessoa.MaiorPermissao(banco, p.Codigo));
                chkAtivo.Checked = p.Ativo;

                if (!radFem.Checked)
                {
                    chkGestanteAltoRisco.Enabled = false;
                    chkGestanteAltoRisco.Checked = false;
                }
                else
                {
                    chkGestanteAltoRisco.Enabled = true;
                }

                var resp = ResponsavelAtivacao.ConsultarChave(banco, p.Codigo);
                if (resp != null)
                {
                    CarregaComboResponsavel(banco);
                }

                CarregaDadosClinicos(banco, _codigo);
            }
        }

        private void CarregaDadosClinicos(IBanco banco, double codPaciente)
        {
            var dadosClinicos = DadoClinicoPaciente.ConsultarPeloPaciente(banco, codPaciente);
            if (dadosClinicos != null)
            {
                chkInsuficienciaCardiaca.Checked = dadosClinicos.InsuficienciaCardiaca;
                chkHipertensao.Checked = dadosClinicos.Hipertensao;
                chkPneumopatiasGraves.Checked = dadosClinicos.PneumopatiasGraves;
                chkTabagismo.Checked = dadosClinicos.Tabagismo;
                chkImunoDepressao.Checked = dadosClinicos.ImunoDepressao;
                chkDoencaRenalApartirGrau3.Checked = dadosClinicos.DoencaRenalApartirGrau3;
                chkDiabetes.Checked = dadosClinicos.Diabetes;
                chkDoencaCromossomica.Checked = dadosClinicos.DoencaCromossomica;
                chkNeoplasiaMaligna.Checked = dadosClinicos.NeoplasiaMaligna;
                chkGestanteAltoRisco.Checked = dadosClinicos.GestanteAltoRisco;
                txtPeso.Text = dadosClinicos.Peso.ToString("0.000");
                txtAltura.Text = dadosClinicos.Altura.ToString("0.00");
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

            if (Texto.TestarNumerico(txtCodigo.Text))
            {
                var resp = ResponsavelPaciente.ConsultarChave(banco, Convert.ToDouble(txtCodigo.Text));
                if (resp != null)
                    cboResponsavel.Posicionar(resp.CodResponsavel);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void CarregaComboNiveis(IBanco banco)
        {
            var niveis = NivelPermissao.ConsultarTodos(banco);
            foreach (var item in niveis)
            {
                cboNiveis.Adicionar(item.DescricaoNivel, item.CodNivel);
            }

            cboNiveis.Posicionar(1);
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {

            IBanco banco = null;

            try
            {
                banco = Utilitarios.ObterConexao();

                if (!txtSenha.Text.Equals(txtConfirmarSenha.Text))
                    throw new Exception("As senhas não conferem!");
                if (lbl.Text.Length == 0)
                    throw new Exception("Deve ser utilizado um nome de usuário!");
                if (txtSenha.Text.Length < 4)
                    throw new Exception("Deve ser utilizada uma senha de no mínimo 4 caracteres!");
                if (Pessoa.ExisteUser(banco, txtUsuario.Text) && Convert.ToInt32(txtCodigo.Text) == 0)
                    throw new Exception("Nome de usuário já existente!");
                DateTime dt;
                if (!DateTime.TryParse(txtDataNascimento.Text, out dt))
                    throw new Exception("Data de Nascimento inválida!");
                if (string.IsNullOrEmpty(txtUsuario.Text))
                    throw new Exception("Deve ser preenchido um código de usuário.");

                if (Program.CalculaIdade(Convert.ToDateTime(txtDataNascimento.Text)) < 18 && !chkAtivo.Checked)
                    Msg.Informar("Para ativar o cadastro de usuário menor de idade, será necessário designar um responsável.");

                var pessoa = new Pessoa();
                var p = Pessoa.ConsultarChave(banco, _codigo);
                if (!string.IsNullOrEmpty(txtCodigo.Text) && txtCodigo.Visible == true && p != null)
                {
                    pessoa = p;

                    if (Pessoa.ExisteUser(banco, txtUsuario.Text) && !txtUsuario.Text.Equals(p.Usuario))
                        throw new Exception("Nome de usuário já existente!");
                }
                else
                {
                    if (!chkAtivo.Checked)
                        Msg.Informar("Para logar no sistema, é necessário a ativação do cadastro por um Profissional de saúde ou Administrador!");
                }

                pessoa.Cpf = txtCpf.Text;
                pessoa.Nome = txtNome.Text;
                pessoa.DataNascimento = Convert.ToDateTime(txtDataNascimento.Text);
                pessoa.Sexo = radMasc.Checked ? "M" : "F";
                pessoa.Endereco = txtEndereco.Text;
                pessoa.Telefone = txtTelefone.Text;
                pessoa.Email = txtEmail.Text;
                pessoa.DataCadastro = DateTime.Now;
                pessoa.Ativo = chkAtivo.Checked;
                pessoa.Usuario = txtUsuario.Text;
                pessoa.Senha = Texto.CriptografarTexto(txtSenha.Text);
                Pessoa.Gravar(banco, pessoa);
                pessoa = Pessoa.ConsultarPorUser(banco, txtUsuario.Text);

                var pessoaPermissao = PermissaoPessoa.ConsultarChave(banco, (int)cboNiveis.ObterValor(), pessoa.Codigo);
                if (pessoaPermissao != null)
                    PermissaoPessoa.Excluir(banco, pessoaPermissao);
                pessoaPermissao = new PermissaoPessoa();
                pessoaPermissao.CodPessoa = pessoa.Codigo;
                pessoaPermissao.CodPermissao = (int)cboNiveis.ObterValor();

                string log = banco.LerConfiguracao("USER_LOGADO", "");
                if (Texto.TestarNumerico(log))
                {
                    var logado = Convert.ToDouble(log);
                    if (logado != pessoa.Codigo)
                        pessoaPermissao.CodAdmin = logado;
                }

                PermissaoPessoa.Gravar(banco, pessoaPermissao);

                if (cboResponsavel.Visible && Texto.TestarNumerico(txtCodigo.Text))
                {
                    var resp = new ResponsavelPaciente();
                    resp.CodPaciente = Convert.ToInt32(txtCodigo.Text);
                    resp.CodResponsavel = (int)cboResponsavel.ObterValor();
                    ResponsavelPaciente.Gravar(banco, resp);
                }

                var dadosClinicos = DadoClinicoPaciente.ConsultarPeloPaciente(banco, pessoa.Codigo);
                if (dadosClinicos == null)
                {
                    dadosClinicos = new DadoClinicoPaciente();
                }
                dadosClinicos.CodPaciente = pessoa.Codigo;
                dadosClinicos.InsuficienciaCardiaca = chkInsuficienciaCardiaca.Checked;
                dadosClinicos.Hipertensao = chkHipertensao.Checked;
                dadosClinicos.PneumopatiasGraves = chkPneumopatiasGraves.Checked;
                dadosClinicos.Tabagismo = chkTabagismo.Checked;
                dadosClinicos.ImunoDepressao = chkImunoDepressao.Checked;
                dadosClinicos.DoencaRenalApartirGrau3 = chkDoencaRenalApartirGrau3.Checked;
                dadosClinicos.Diabetes = chkDiabetes.Checked;
                dadosClinicos.DoencaCromossomica = chkDoencaCromossomica.Checked;
                dadosClinicos.NeoplasiaMaligna = chkNeoplasiaMaligna.Checked;
                dadosClinicos.GestanteAltoRisco = chkGestanteAltoRisco.Checked;
                dadosClinicos.Peso = Convert.ToDecimal(txtPeso.Text);
                dadosClinicos.Altura = Convert.ToDecimal(txtAltura.Text);
                DadoClinicoPaciente.Gravar(banco, dadosClinicos);


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

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {
            txtUsuario.Text = txtUsuario.Text.ToString().Replace(" ", "");
            txtUsuario.Select(txtUsuario.Text.Length, 0);

        }

        private void FrmNovo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                this.SelectNextControl(this.ActiveControl, !e.Shift, true, true, true);
            else if (e.KeyCode == Keys.Escape)
                Close();
        }

        private void txtDataNascimento_TextChanged(object sender, EventArgs e)
        {
            DateTime dt;
            if (DateTime.TryParse(txtDataNascimento.Text, out dt))
            {
                if (Program.CalculaIdade(Convert.ToDateTime(txtDataNascimento.Text)) < 18)
                {
                    lblResponsavel.Visible = true;
                    cboResponsavel.Visible = true;
                    txtResponsavel.Visible = true;
                }
                else
                {
                    lblResponsavel.Visible = false;
                    cboResponsavel.Visible = false;
                    txtResponsavel.Visible = false;
                }

            }
        }

        private void cboResponsavel_SelectedIndexChanged(object sender, EventArgs e)
        {
            IBanco banco = null;
            try
            {
                banco = Utilitarios.ObterConexao();

                txtResponsavel.Text = "";

                var pessoa = Pessoa.ConsultarChave(banco, (int)cboResponsavel.ObterValor());
                if (pessoa != null)
                    txtResponsavel.Text = pessoa.Nome;


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

        private void radFem_CheckedChanged(object sender, EventArgs e)
        {
            if (!radFem.Checked)
            {
                chkGestanteAltoRisco.Enabled = false;
                chkGestanteAltoRisco.Checked = false;
            }
            else
            {
                chkGestanteAltoRisco.Enabled = true;
            }
        }
    }
}
