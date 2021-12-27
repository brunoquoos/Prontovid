using MessagingToolkit.QRCode.Codec;
using Prontovid.Biblioteca;
using Prontovid.Biblioteca.Biblioteca.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telecon.Genericos.Classes.BancoDeDados;
using Telecon.Genericos.Classes.Outros;
using Hl7.Fhir.Model;
using Hl7.Fhir.Rest;
using Hl7.Fhir.Serialization;
using System.Runtime.Serialization.Json;
using System.IO;
using Newtonsoft.Json;

namespace Prontovid
{

    public partial class FrmInicio : Form
    {
        private const string _fhirServer = "http://test.fhir.org/r4";
        FhirClient fhirClient = new FhirClient(_fhirServer)
        {
            PreferredFormat = ResourceFormat.Json,
            PreferredReturn = Prefer.ReturnRepresentation
        };

        public FrmInicio()
        {
            InitializeComponent();
        }

        private void btnNovoUsuario_Click(object sender, EventArgs e)
        {
            var form = new FrmNovo();
            form.ShowDialog();
        }

        private void btnPesquisaUsuario_Click(object sender, EventArgs e)
        {
            var form = new FrmPesquisa();
            form.ShowDialog();
        }

        private void Deslogar()
        {
            IBanco banco = null;

            try
            {
                banco = Utilitarios.ObterConexao();

                banco.GravarConfiguracao("USER_LOGADO", "");
                this.Hide();
                var form = new FrmLogin();
                form.Closed += (s, args) => this.Close();
                form.Show();
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

        private void btnLogoff_Click(object sender, EventArgs e)
        {
            if (Msg.Perguntar("Deseja deslogar?") == DialogResult.Yes)
                Deslogar();
        }

        private void ResetarStatusForaPrazo(IBanco banco)
        {
            //Volta o status para verde de quem está amarelo ou vermelho há mais de 15 dias
            var sql = " Update S Set S.CodStatus = 0 ";
            sql += " from StatusPessoa S ";
            sql += " Inner Join ( ";
            sql += " select CodPaciente, Max(DataStatus) as Data ";
            sql += " from StatusPessoa  ";
            sql += " where CodStatus <> 0 ";
            sql += " group by CodPaciente ";
            sql += " HAVING DATEDIFF(DD, max(datastatus), GETDATE()) > 15 ";
            sql += " ) as M on (S.CodPaciente = M.CodPaciente and S.DataStatus = M.Data) ";
            banco.ExecutarComando(sql);
        }

        private void FrmInicio_Load(object sender, EventArgs e)
        {
            IBanco banco = null;

            try
            {
                banco = Utilitarios.ObterConexao();

                ResetarStatusForaPrazo(banco);

                double userLogado = Convert.ToDouble(banco.LerConfiguracao("USER_LOGADO", ""));
                var user = Pessoa.ConsultarChave(banco, userLogado);
                var responsavel = ResponsavelPaciente.ConsultarChave(banco, user.Codigo);

                lblUsuario.Text = "Usuário Logado: " + user.Usuario + " (" + user.Nome + ")";
                if (responsavel != null)
                {
                    var userResp = Pessoa.ConsultarChave(banco, responsavel.CodResponsavel);
                    lblUsuario.Text = lblUsuario.Text + "                Usuário Responsável: " + userResp.Usuario + " (" + userResp.Nome + ")";
                }

                double maiorPermissao = PermissaoPessoa.MaiorPermissao(banco, userLogado);
                btnPesquisaUsuario.Enabled = (maiorPermissao != (double)PermissaoPessoa.ePermissao.Paciente);
                btnAtivacaoUsuario.Enabled = (maiorPermissao != (double)PermissaoPessoa.ePermissao.Paciente);
                btnInclusaoExames.Enabled = (maiorPermissao != (double)PermissaoPessoa.ePermissao.Paciente);
                btnInclusaoResultados.Enabled = (maiorPermissao != (double)PermissaoPessoa.ePermissao.Paciente);
                btnInclusaoSintomas.Enabled = (maiorPermissao != (double)PermissaoPessoa.ePermissao.Paciente);
                btnNovoUsuario.Enabled = (maiorPermissao != (double)PermissaoPessoa.ePermissao.Paciente);

                if (maiorPermissao == (double)PermissaoPessoa.ePermissao.Medico)
                {
                    grbMeuPaciente.Visible = true;
                    CarregaComboPacientes(banco);
                }


                AtualizaQr(banco, userLogado);
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

        private void CarregaComboPacientes(IBanco banco)
        {
            var pessoas = Pessoa.ConsultarTodas(banco, true);
            double userlogado = Convert.ToDouble(banco.LerConfiguracao("USER_LOGADO", ""));
            double maiorPermissao = PermissaoPessoa.MaiorPermissao(banco, userlogado);

            foreach (var item in pessoas)
            {
                if (userlogado != item.Codigo)
                    cboPaciente.Adicionar(item.Usuario, item.Codigo);
            }

            cboPaciente.SelectedIndex = 1;
        }

        private void btnMeuCadastro_Click(object sender, EventArgs e)
        {
            IBanco banco = null;

            try
            {
                banco = Utilitarios.ObterConexao();

                double userLogado = Convert.ToDouble(banco.LerConfiguracao("USER_LOGADO", ""));
                double maiorPermissao = PermissaoPessoa.MaiorPermissao(banco, userLogado);
                var form = new FrmNovo();



                if (maiorPermissao == (double)PermissaoPessoa.ePermissao.Medico && grbMeuPaciente.Visible)
                {
                    if (Msg.PerguntarPadraoNao("Deseja abrir o seu cadastro ou o do paciente?\nClique em SIM para o seu e em NÃO para o do paciente.") == DialogResult.Yes)
                        form._codigo = userLogado;
                    else
                        form._codigo = cboPaciente.ObterValor();
                }
                else
                    form._codigo = userLogado;

                form.ShowDialog();
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

        private void btnAtivacaoUsuario_Click(object sender, EventArgs e)
        {
            var form = new FrmAtivacao();
            form.ShowDialog();
        }

        private void btnInclusaoSintomas_Click(object sender, EventArgs e)
        {
            var form = new FrmSintomas();
            form.ShowDialog();
        }

        private void FrmInicio_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                btnLogoff_Click(null, null);
        }

        private void btnInclusaoExames_Click(object sender, EventArgs e)
        {
            var form = new FrmExames();
            form.ShowDialog();
        }

        private void btnResultadoExames_Click(object sender, EventArgs e)
        {
            var form = new FrmPesquisaExames();
            form.ShowDialog();
        }

        private void btnInclusaoResultados_Click(object sender, EventArgs e)
        {
            var form = new FrmInclusaoResultadoExames();
            form.ShowDialog();
        }

        private void AtualizaQr(IBanco banco, double userLogado)
        {
            var p = Pessoa.ConsultarChave(banco, userLogado);
            var s = StatusPessoa.UltimoStatus(banco, p.Codigo);
            if (s == null)
            {
                s = new StatusPessoa();
                s.CodPaciente = p.Codigo;
                s.CodResponsavel = p.Codigo;
                s.CodStatus = (int)StatusPessoa.eColor.Verde;
                s.DataStatus = DateTime.Now;
                StatusPessoa.Gravar(banco, s);
            }

            var textoQr = "USER=" + p.Codigo + ";STATUS=" + s.CodStatus + ";DATA=" + s.DataStatus.ToString("dd/MM/yyyy HH:mm:ss") + ";RESPONSAVEL=" + s.CodResponsavel;

            Color cor = Color.Green;
            if (s.CodStatus == (int)StatusPessoa.eColor.Amarelo)
                cor = Color.Gold;
            else if (s.CodStatus == (int)StatusPessoa.eColor.Vermelho)
                cor = Color.Red;

            picQr.Image = GerarQRCode(4, textoQr, cor);

        }


        private Image GerarQRCode(int escala, string text, Color cor)
        {
            try
            {
                QRCodeEncoder qrCodecEncoder = new QRCodeEncoder();
                qrCodecEncoder.QRCodeBackgroundColor = Color.White;
                qrCodecEncoder.QRCodeForegroundColor = cor;
                qrCodecEncoder.CharacterSet = "UTF-8";
                qrCodecEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;
                qrCodecEncoder.QRCodeScale = escala;
                qrCodecEncoder.QRCodeVersion = 0;
                qrCodecEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.Q;
                Image imageQRCode;
                String dados = text;
                imageQRCode = qrCodecEncoder.Encode(dados);
                return imageQRCode;
            }
            catch
            {
                throw;
            }
        }

        private void FrmInicio_Activated(object sender, EventArgs e)
        {
            IBanco banco = null;

            try
            {
                banco = Utilitarios.ObterConexao();

                double userLogado = Convert.ToDouble(banco.LerConfiguracao("USER_LOGADO", ""));
                AtualizaQr(banco, userLogado);
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

        private void btnMeusAtendimentos_Click(object sender, EventArgs e)
        {
            var form = new FrmPesquisaAtendimentos();
            form.ShowDialog();
        }

        private void cboPaciente_SelectedIndexChanged(object sender, EventArgs e)
        {
            IBanco banco = null;

            try
            {
                banco = Utilitarios.ObterConexao();

                var p = Pessoa.ConsultarChave(banco, (int)cboPaciente.ObterValor());
                if (p != null)
                    txtPaciente.Text = p.Nome;
                else
                    txtPaciente.Text = "";

                banco.GravarConfiguracao("USER_PACIENTE", cboPaciente.ObterValor().ToString());
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

        private void btnFhir_Click(object sender, EventArgs e)
        {
            var pacientes = encontrarPacientes();

            foreach (var paciente in pacientes)
            {
                string texto = "Id:" + paciente.Id + "\n";
                if (paciente.Name.Count > 0)
                {
                    string familia = "";
                    if (paciente.Name[0].Family != null)
                        familia = paciente.Name[0].Family;

                    texto += "Nome: \"" + paciente.Name[0].ToString() + "\"\n";

                    if (paciente.Gender != null)
                        texto += "Sexo: " + (paciente.Gender.Value.ToString().Equals("Male") ? "Masculino" : "Feminino") + "\n";

                    if (paciente.BirthDate != null)
                        texto += "Data de Nascimento: " + Convert.ToDateTime(paciente.BirthDate.ToString()).ToString("dd/MM/yyyy") + "\n";

                    if (paciente.Address != null)
                    {
                        if (paciente.Address.Count > 0)
                        {
                            if (paciente.Address[0].PostalCode != null)
                                texto += "Endereço: " + paciente.Address[0].PostalCode.ToString() + "\n";
                        }
                    }

                    if (paciente.Telecom != null)
                    {
                        foreach (var t in paciente.Telecom)
                        {
                            if (t.System == ContactPoint.ContactPointSystem.Phone)
                            {
                                if (!string.IsNullOrEmpty(t.Value))
                                    texto += "Telefone: " + t.Value + "\n";
                            }
                            else if (t.System == ContactPoint.ContactPointSystem.Email)
                            {
                                if (!string.IsNullOrEmpty(t.Value))
                                    texto += "Email: " + t.Value + "\n";
                            }
                        }
                    }

                    Msg.Informar("Paciente encontrado.\n\n" + texto);
                }
            }

            if (pacientes.Count == 0)
                Msg.Criticar("Paciente não encontrado na base do FHIR!");
        }


        private void btnAddFhir_Click(object sender, EventArgs e)
        {
            if (encontrarPacientes().Count > 0)
            {
                Msg.Criticar("Paciente já existente na base do FHIR!");
                return;
            }

            var pacienteCriado = criarPaciente();
            if (pacienteCriado != null)
                Msg.Informar("Criado paciente id=" + pacienteCriado.Id);
        }

        private List<Patient> encontrarPacientes()
        {
            IBanco banco = null;
            var retorno = new List<Patient>();

            try
            {
                banco = Utilitarios.ObterConexao();

                var p = Pessoa.ConsultarChave(banco, (int)cboPaciente.ObterValor());
                if (p != null)
                {
                    var nomeSplit = p.Nome.Split(' ');
                    string nome = "";
                    string sobrenome = "";
                    var count = 0;
                    foreach (var s in nomeSplit)
                    {
                        if (count == 0)
                            nome = s;
                        else if (count == 1)
                            sobrenome = s;
                        else
                            sobrenome = sobrenome + " " + s;
                        count++;
                    }

                    var pesquisa = new string[1];
                    pesquisa[0] = "name=" + nome;

                    Bundle pacientesPacote = fhirClient.Search<Patient>(pesquisa);

                    foreach (Bundle.EntryComponent entry in pacientesPacote.Entry)
                    {
                        if (entry.Resource != null)
                        {
                            Patient paciente = (Patient)entry.Resource;
                            string texto = "Id:" + paciente.Id + "\n";
                            if (paciente.Name.Count > 0)
                            {
                                string familia = "";
                                if (paciente.Name[0].Family != null)
                                    familia = paciente.Name[0].Family;

                                if (familia.Equals(sobrenome))
                                {
                                    retorno.Add(paciente);
                                }
                            }
                        }
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

            return retorno;
        }

        private void btnExcluirFhir_Click(object sender, EventArgs e)
        {
            var pacientes = excluirPacientes();

            foreach (var paciente in pacientes)
            {
                Msg.Informar(paciente.Id + " excluído.");
            }
        }

        private List<Patient> excluirPacientes()
        {
            var pacientes = encontrarPacientes();

            foreach (var paciente in pacientes)
            {
                fhirClient.Delete(paciente);
            }

            return pacientes;
        }

        private Patient criarPaciente()
        {
            IBanco banco = null;
            Patient pacienteCriado = null;

            try
            {
                banco = Utilitarios.ObterConexao();

                var p = Pessoa.ConsultarChave(banco, (int)cboPaciente.ObterValor());
                if (p != null)
                {
                    var endereco = new List<Address>();
                    var end = new Address();
                    end.Country = "Brasil";
                    end.PostalCode = p.Endereco;

                    var telecom = new List<ContactPoint>();

                    var tel = new ContactPoint();
                    tel.System = ContactPoint.ContactPointSystem.Phone;
                    tel.Value = p.Telefone;
                    tel.Use = ContactPoint.ContactPointUse.Home;

                    var email = new ContactPoint();
                    email.System = ContactPoint.ContactPointSystem.Email;
                    email.Value = p.Email;
                    email.Use = ContactPoint.ContactPointUse.Home;

                    telecom.Add(tel);
                    telecom.Add(email);

                    var nomeSplit = p.Nome.Split(' ');
                    string nome = "";
                    string sobrenome = "";
                    var count = 0;
                    foreach (var s in nomeSplit)
                    {
                        if (count == 0)
                            nome = s;
                        else if (count == 1)
                            sobrenome = " " + s;
                        else
                            sobrenome = sobrenome + " " + s;
                        count++;
                    }

                    Patient paciente = new Patient()
                    {
                        Name = new List<HumanName>()
                        {
                            new HumanName()
                            {
                                Family = sobrenome,
                                Given = new List<string>()
                                {
                                    nome,
                                },
                            }
                        },
                        BirthDateElement = new Date(p.DataNascimento.Year, p.DataNascimento.Month, p.DataNascimento.Day),
                        Gender = p.Sexo.Equals("M") ? AdministrativeGender.Male : AdministrativeGender.Female,
                        Address = new List<Address>() { end },
                        Telecom = telecom
                    };


                    pacienteCriado = fhirClient.Create<Patient>((Patient)paciente);
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
            return pacienteCriado;
        }

        private void btnAtualizarFhir_Click(object sender, EventArgs e)
        {
            var pacientes = encontrarPacientes();

            if (pacientes.Count > 0)
            {
                excluirPacientes();
                var pacienteCriado = criarPaciente();
                if (pacienteCriado != null)
                    Msg.Informar("Paciente " + pacienteCriado.Name[0].ToString() + " atualizado na base do FHIR.");
            }
            else
            {
                Msg.Criticar("Paciente ainda não existe na base do FHIR!");
            }
        }
    }
}

