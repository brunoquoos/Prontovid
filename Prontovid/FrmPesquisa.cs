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
    public partial class FrmPesquisa : Form
    {
        public FrmPesquisa()
        {
            InitializeComponent();
        }

        private void PesquisaTodas()
        {
            IBanco banco = null;

            try
            {
                banco = Utilitarios.ObterConexao();
                var pessoas = Pessoa.ConsultarTodas(banco, false);

                preencheListView(pessoas);
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

        private void FrmPesquisa_Load(object sender, EventArgs e)
        {
            inicializaListView();

            PesquisaTodas();
        }


        private void btnnovo_Click(object sender, EventArgs e)
        {
            var form = new FrmNovo();
            form.Show();
        }

        private void preencheListView(List<Pessoa> pessoas)
        {

            // limpa o ListView
            listView1.Items.Clear();

            // exibe os itens no controle ListView 
            foreach (var p in pessoas)
            {
                // Define os itens da lista                

                ListViewItem lvi = new ListViewItem(p.Codigo.ToString());
                lvi.SubItems.Add(p.Cpf);
                lvi.SubItems.Add(p.Nome);
                lvi.SubItems.Add(p.DataNascimento.ToString("dd/MM/yyy"));
                lvi.SubItems.Add(p.Sexo.ToString());
                lvi.SubItems.Add(p.Endereco);
                lvi.SubItems.Add(p.Telefone);
                lvi.SubItems.Add(p.Email);
                lvi.SubItems.Add(p.DataCadastro.ToString("dd/MM/yyy"));
                lvi.SubItems.Add(p.Ativo ? "Sim" : "Não");

                // Inclui os itens no ListView
                listView1.Items.Add(lvi);
            }


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
            //Cpf, Nome, DataNascimento, Sexo, Endereco, Telefone, Email, DataCadastro, Ativo
            listView1.Columns.Add("Cód", 40, HorizontalAlignment.Left);
            listView1.Columns.Add("CPF", 80, HorizontalAlignment.Left);
            listView1.Columns.Add("Nome", 100, HorizontalAlignment.Left);
            listView1.Columns.Add("Dt. Nasc.", 70, HorizontalAlignment.Left);
            listView1.Columns.Add("Sexo", 40, HorizontalAlignment.Left);
            listView1.Columns.Add("Endereço", 120, HorizontalAlignment.Left);
            listView1.Columns.Add("Telefone", 80, HorizontalAlignment.Left);
            listView1.Columns.Add("Email", 120, HorizontalAlignment.Left);
            listView1.Columns.Add("Dt. Cad.", 70, HorizontalAlignment.Left);
            listView1.Columns.Add("Ativo", 40, HorizontalAlignment.Left);
        }

        private void FrmPesquisa_Activated(object sender, EventArgs e)
        {
            PesquisaTodas();
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
                return;

            if (!string.IsNullOrEmpty(listView1.SelectedItems[0].Text))
            {

                IBanco banco = null;

                try
                {
                    banco = Utilitarios.ObterConexao();
                    var p = Pessoa.ConsultarChave(banco, Convert.ToDouble(listView1.SelectedItems[0].Text));
                    var userLogado = Convert.ToDouble(banco.LerConfiguracao("USER_LOGADO", ""));
                    if (p.Codigo == userLogado || PermissaoPessoa.MaiorPermissao(banco, userLogado) == (double)PermissaoPessoa.ePermissao.Administrador)
                    {

                        var form = new FrmNovo();
                        form._codigo = Convert.ToDouble(listView1.SelectedItems[0].Text);
                        form.ShowDialog();
                    }
                    else
                    {
                        throw new Exception("Sem permissão para acessar este usuário!");
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

        }

        private void FrmPesquisa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                this.SelectNextControl(this.ActiveControl, !e.Shift, true, true, true);
            else if (e.KeyCode == Keys.Escape)
                Close();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
