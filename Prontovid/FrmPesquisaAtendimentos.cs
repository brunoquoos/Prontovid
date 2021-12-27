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

namespace Prontovid
{
    public partial class FrmPesquisaAtendimentos : Form
    {
        public FrmPesquisaAtendimentos()
        {
            InitializeComponent();
        }

        private void preencheListView(IBanco banco, int codUsuario, int codResponsavel, int codDataInsercao)
        {
            List<Pessoa> pessoas = new List<Pessoa>();
            List<SintomaPaciente> atendimentos = new List<SintomaPaciente>();
            if (codUsuario > 0)
            {
                var p = Pessoa.ConsultarChave(banco, codUsuario);
                pessoas.Add(p);
            }
            else
            {
                pessoas = Pessoa.ConsultarTodas(banco, true);
            }

            // limpa o ListView
            lvwAtendimentos.Items.Clear();

            // exibe os itens no controle ListView 
            foreach (var p in pessoas)
            {
                atendimentos = SintomaPaciente.ConsultarAtendimentos(banco, p.Codigo);

                foreach (var a in atendimentos)
                {
                    var atendente = Pessoa.ConsultarChave(banco, a.ResponsavelInsercao);

                    if ((codResponsavel == 0 || codResponsavel == atendente.Codigo) && (codDataInsercao == 0 || codDataInsercao == a.Codigo))
                    {
                        // Define os itens da lista
                        ListViewItem lvi = new ListViewItem(a.Codigo.ToString());
                        lvi.SubItems.Add(p.Nome);
                        lvi.SubItems.Add(a.Temperatura.ToString("0.0"));
                        lvi.SubItems.Add(a.Saturacao.ToString());
                        lvi.SubItems.Add(atendente.Nome);
                        lvi.SubItems.Add(a.CodStatusPessoa == 0 ? "Ok - Verde" : (a.CodStatusPessoa == 2 ? "Alerta - Vermelho" : "Atenção - Amarelo"));
                        lvi.SubItems.Add(a.DataInsercao.ToString("dd/MM/yyyy HH:mm"));

                        // Inclui os itens no ListView
                        lvwAtendimentos.Items.Add(lvi);

                    }

                }
            }


        }

        private void CarregaComboResponsaveis(IBanco banco)
        {
            var pessoas = Pessoa.ConsultarTodas(banco, false);
            cboResponsavelAtendimento.Adicionar("Todos", 0);

            foreach (var item in pessoas)
            {
                if (PermissaoPessoa.MaiorPermissao(banco, item.Codigo) != (double)PermissaoPessoa.ePermissao.Paciente)
                    cboResponsavelAtendimento.Adicionar(item.Usuario, item.Codigo);
            }
            cboResponsavelAtendimento.Posicionar(0);
        }

        private void CarregaComboDataHoraAtendimentos(IBanco banco)
        {
            cboDataHoraAtendimento.Items.Clear();
            cboDataHoraAtendimento.LimparItemData();
            cboDataHoraAtendimento.Adicionar("Todos", 0);
            var sintomas = SintomaPaciente.ConsultarAtendimentos(banco, (double)cboUsuarios.ObterValor());

            if (cboResponsavelAtendimento.ObterValor() > 0)
            {
                sintomas.RemoveAll(l => l.ResponsavelInsercao != cboResponsavelAtendimento.ObterValor());
            }

            foreach (var i in sintomas)
            {
                cboDataHoraAtendimento.Adicionar(i.DataInsercao.ToString("dd/MM/yyyy HH:mm"), i.Codigo);
            }
            cboDataHoraAtendimento.Posicionar(0);
        }

        private void CarregaComboUsuarios(IBanco banco)
        {
            var pessoas = Pessoa.ConsultarTodas(banco, true);
            double userlogado = Convert.ToDouble(banco.LerConfiguracao("USER_LOGADO", ""));
            double maiorPermissao = PermissaoPessoa.MaiorPermissao(banco, userlogado);

            if (PermissaoPessoa.MaiorPermissao(banco, userlogado) != (double)PermissaoPessoa.ePermissao.Paciente)
                cboUsuarios.Adicionar("Todos", 0);

            foreach (var item in pessoas)
            {
                if (PermissaoPessoa.MaiorPermissao(banco, userlogado) == (double)PermissaoPessoa.ePermissao.Paciente && item.Codigo == userlogado) //Paciente logado
                    cboUsuarios.Adicionar(item.Usuario, item.Codigo);
                else if (PermissaoPessoa.MaiorPermissao(banco, userlogado) != (double)PermissaoPessoa.ePermissao.Paciente) //Outros
                    cboUsuarios.Adicionar(item.Usuario, item.Codigo);
            }

            double userPaciente = Convert.ToDouble(banco.LerConfiguracao("USER_PACIENTE", "0"));
            if (userPaciente > 0 && maiorPermissao == (double)PermissaoPessoa.ePermissao.Medico)
                cboUsuarios.Posicionar(userPaciente);
            else
                cboUsuarios.Posicionar(userlogado);
        }

        private void inicializaListView()
        {
            //Apenas cria e inicializa o listView vazio

            // exibe detalhes
            lvwAtendimentos.View = View.Details;
            // permite ao usuário rearranjar as colunas
            lvwAtendimentos.AllowColumnReorder = true;
            // Selecione o item e subitem quando um seleção for feita
            lvwAtendimentos.FullRowSelect = true;
            // Exibe as linhas no ListView
            lvwAtendimentos.GridLines = true;

            // Anexa Subitems no ListView
            lvwAtendimentos.Columns.Add("Código", 50, HorizontalAlignment.Left);
            lvwAtendimentos.Columns.Add("Paciente", 150, HorizontalAlignment.Left);
            lvwAtendimentos.Columns.Add("Temperatura", 80, HorizontalAlignment.Left);
            lvwAtendimentos.Columns.Add("Saturação", 80, HorizontalAlignment.Left);
            lvwAtendimentos.Columns.Add("Atendente", 150, HorizontalAlignment.Left);
            lvwAtendimentos.Columns.Add("Estado Geral", 100, HorizontalAlignment.Left);
            lvwAtendimentos.Columns.Add("Data Atendimento", 120, HorizontalAlignment.Left);
        }


        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lvwAtendimentos.SelectedItems.Count == 0)
                return;

            if (!string.IsNullOrEmpty(lvwAtendimentos.SelectedItems[0].Text))
            {
                var form = new FrmSintomas();
                form._codigo = Convert.ToDouble(lvwAtendimentos.SelectedItems[0].Text);
                form.ShowDialog();
            }
        }



        private void FrmPesquisaExames_Load(object sender, EventArgs e)
        {
            IBanco banco = null;

            try
            {
                banco = Utilitarios.ObterConexao();

                inicializaListView();
                CarregaComboUsuarios(banco);
                CarregaComboResponsaveis(banco);
                CarregaListConformeCombo(banco);
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


        private void FrmPesquisaExames_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                this.SelectNextControl(this.ActiveControl, !e.Shift, true, true, true);
            else if (e.KeyCode == Keys.Escape)
                Close();
        }

        private void FrmPesquisaExames_Activated(object sender, EventArgs e)
        {
            CarregaListConformeCombo(null);
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

                CarregaComboDataHoraAtendimentos(banco);
                CarregaListConformeCombo(banco);
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

        private void cboTiposExames_SelectedIndexChanged(object sender, EventArgs e)
        {
            IBanco banco = null;

            try
            {
                banco = Utilitarios.ObterConexao();
                CarregaComboDataHoraAtendimentos(banco);
                CarregaListConformeCombo(banco);
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

        private void CarregaListConformeCombo(IBanco banco)
        {

            if (banco == null)
            {

                try
                {
                    banco = Utilitarios.ObterConexao();
                    preencheListView(banco, (int)cboUsuarios.ObterValor(), (int)cboResponsavelAtendimento.ObterValor(), (int)cboDataHoraAtendimento.ObterValor());
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
            else
            {
                preencheListView(banco, (int)cboUsuarios.ObterValor(), (int)cboResponsavelAtendimento.ObterValor(), (int)cboDataHoraAtendimento.ObterValor());
            }
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cboDataHoraAtendimento_SelectedIndexChanged(object sender, EventArgs e)
        {
            CarregaListConformeCombo(null);
        }
    }
}
