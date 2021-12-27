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
    public partial class FrmPesquisaExames : Form
    {
        public FrmPesquisaExames()
        {
            InitializeComponent();
        }




        private void preencheListView(IBanco banco, int codUsuario, int tipoExame)
        {
            List<Pessoa> pessoas = new List<Pessoa>();
            List<Exame> exames = new List<Exame>();
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
            listView1.Items.Clear();

            // exibe os itens no controle ListView 
            foreach (var p in pessoas)
            {
                exames = Exame.ConsultarTodos(banco, p.Codigo);

                foreach (var e in exames)
                {
                    if (tipoExame == 0 || tipoExame == e.TipoExame)
                    {

                        var tipo = TipoExame.ConsultarChave(banco, e.TipoExame);
                        var resExame = ResultadoExame.ConsultarResultadoExame(banco, e.Codigo);

                        // Define os itens da lista
                        ListViewItem lvi = new ListViewItem(e.Codigo.ToString());
                        lvi.SubItems.Add(p.Nome);
                        lvi.SubItems.Add(tipo.NomeExame);
                        lvi.SubItems.Add(e.DataExame.ToString("dd/MM/yyyy"));
                        lvi.SubItems.Add(e.DataProvavelResultado.ToString("dd/MM/yyy"));
                        if (resExame != null)
                            lvi.SubItems.Add(resExame.DataResultado.ToString("dd/MM/yyy"));
                        else
                            lvi.SubItems.Add("");

                        // Inclui os itens no ListView
                        listView1.Items.Add(lvi);
                    }
                }
            }


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
            listView1.View = View.Details;
            // permite ao usuário rearranjar as colunas
            listView1.AllowColumnReorder = true;
            // Selecione o item e subitem quando um seleção for feita
            listView1.FullRowSelect = true;
            // Exibe as linhas no ListView
            listView1.GridLines = true;

            // Anexa Subitems no ListView
            listView1.Columns.Add("Cód", 40, HorizontalAlignment.Left);
            listView1.Columns.Add("Paciente", 120, HorizontalAlignment.Left);
            listView1.Columns.Add("Tipo Exame", 250, HorizontalAlignment.Left);
            listView1.Columns.Add("Dt Exame", 80, HorizontalAlignment.Left);
            listView1.Columns.Add("Dt Prov Res", 80, HorizontalAlignment.Left);
            listView1.Columns.Add("Dt Resultado", 80, HorizontalAlignment.Left);
        }


        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
                return;

            if (!string.IsNullOrEmpty(listView1.SelectedItems[0].Text))
            {
                var form = new FrmInclusaoResultadoExames();
                form._codigo = Convert.ToDouble(listView1.SelectedItems[0].Text);
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
                CarregaComboTiposExame(banco);
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

        private void CarregaComboTiposExame(IBanco banco)
        {
            var tipos = TipoExame.ConsultarTodos(banco, false);
            cboTiposExames.Adicionar("Todos", 0);

            foreach (var item in tipos)
            {
                cboTiposExames.Adicionar(item.NomeExame, item.Codigo);
            }

            cboTiposExames.SelectedIndex = 0;
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
            CarregaListConformeCombo(null);
        }

        private void CarregaListConformeCombo(IBanco banco)
        {

            if (banco == null)
            {

                try
                {
                    banco = Utilitarios.ObterConexao();
                    preencheListView(banco, (int)cboUsuarios.ObterValor(), (int)cboTiposExames.ObterValor());
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
                preencheListView(banco, (int)cboUsuarios.ObterValor(), (int)cboTiposExames.ObterValor());
            }
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
