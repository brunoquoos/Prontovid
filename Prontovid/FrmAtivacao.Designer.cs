namespace Prontovid
{
    partial class FrmAtivacao
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAtivacao));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cboResponsavelAtivacao = new Telecon.Genericos.Controles.ComboBoxItemData();
            this.lblResponsavel = new System.Windows.Forms.Label();
            this.cboResponsavel = new Telecon.Genericos.Controles.ComboBoxItemData();
            this.label9 = new System.Windows.Forms.Label();
            this.cboUsuarios = new Telecon.Genericos.Controles.ComboBoxItemData();
            this.btnVoltar = new System.Windows.Forms.Button();
            this.btnAtivar = new System.Windows.Forms.Button();
            this.txtResponsavelAtivacao = new Telecon.Genericos.Controles.CaixaTexto();
            this.txtPessoa = new Telecon.Genericos.Controles.CaixaTexto();
            this.txtResponsavelMenor = new Telecon.Genericos.Controles.CaixaTexto();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtResponsavelMenor);
            this.groupBox1.Controls.Add(this.txtPessoa);
            this.groupBox1.Controls.Add(this.txtResponsavelAtivacao);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.cboResponsavelAtivacao);
            this.groupBox1.Controls.Add(this.lblResponsavel);
            this.groupBox1.Controls.Add(this.cboResponsavel);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.cboUsuarios);
            this.groupBox1.Location = new System.Drawing.Point(38, 23);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(722, 480);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ativação de Usuário";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(16, 173);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(136, 13);
            this.label10.TabIndex = 17;
            this.label10.Text = "Responsável pela ativação";
            // 
            // cboResponsavelAtivacao
            // 
            this.cboResponsavelAtivacao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboResponsavelAtivacao.Enabled = false;
            this.cboResponsavelAtivacao.FormattingEnabled = true;
            this.cboResponsavelAtivacao.Location = new System.Drawing.Point(19, 189);
            this.cboResponsavelAtivacao.Name = "cboResponsavelAtivacao";
            this.cboResponsavelAtivacao.Size = new System.Drawing.Size(174, 21);
            this.cboResponsavelAtivacao.TabIndex = 16;
            this.cboResponsavelAtivacao.SelectedIndexChanged += new System.EventHandler(this.cboResponsavelAtivacao_SelectedIndexChanged);
            // 
            // lblResponsavel
            // 
            this.lblResponsavel.AutoSize = true;
            this.lblResponsavel.Location = new System.Drawing.Point(16, 271);
            this.lblResponsavel.Name = "lblResponsavel";
            this.lblResponsavel.Size = new System.Drawing.Size(124, 13);
            this.lblResponsavel.TabIndex = 15;
            this.lblResponsavel.Text = "Responsável pelo menor";
            this.lblResponsavel.Visible = false;
            // 
            // cboResponsavel
            // 
            this.cboResponsavel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboResponsavel.FormattingEnabled = true;
            this.cboResponsavel.Location = new System.Drawing.Point(19, 287);
            this.cboResponsavel.Name = "cboResponsavel";
            this.cboResponsavel.Size = new System.Drawing.Size(174, 21);
            this.cboResponsavel.TabIndex = 14;
            this.cboResponsavel.Visible = false;
            this.cboResponsavel.SelectedIndexChanged += new System.EventHandler(this.cboResponsavel_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(16, 223);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(33, 13);
            this.label9.TabIndex = 12;
            this.label9.Text = "Login";
            // 
            // cboUsuarios
            // 
            this.cboUsuarios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboUsuarios.FormattingEnabled = true;
            this.cboUsuarios.Location = new System.Drawing.Point(19, 239);
            this.cboUsuarios.Name = "cboUsuarios";
            this.cboUsuarios.Size = new System.Drawing.Size(174, 21);
            this.cboUsuarios.TabIndex = 11;
            this.cboUsuarios.SelectedIndexChanged += new System.EventHandler(this.cboUsuarios_SelectedIndexChanged);
            // 
            // btnVoltar
            // 
            this.btnVoltar.Location = new System.Drawing.Point(616, 526);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(75, 23);
            this.btnVoltar.TabIndex = 20;
            this.btnVoltar.Text = "Voltar";
            this.btnVoltar.UseVisualStyleBackColor = true;
            this.btnVoltar.Click += new System.EventHandler(this.btnVoltar_Click);
            // 
            // btnAtivar
            // 
            this.btnAtivar.Location = new System.Drawing.Point(697, 526);
            this.btnAtivar.Name = "btnAtivar";
            this.btnAtivar.Size = new System.Drawing.Size(75, 23);
            this.btnAtivar.TabIndex = 19;
            this.btnAtivar.Text = "Ativar";
            this.btnAtivar.UseVisualStyleBackColor = true;
            this.btnAtivar.Click += new System.EventHandler(this.btnAtivar_Click);
            // 
            // txtResponsavelAtivacao
            // 
            this.txtResponsavelAtivacao.Decimais = 0;
            this.txtResponsavelAtivacao.Enabled = false;
            this.txtResponsavelAtivacao.Formato = Telecon.Genericos.Controles.CaixaTexto.TipoFormato.Livre;
            this.txtResponsavelAtivacao.Location = new System.Drawing.Point(199, 190);
            this.txtResponsavelAtivacao.MaxLength = 32;
            this.txtResponsavelAtivacao.Name = "txtResponsavelAtivacao";
            this.txtResponsavelAtivacao.PermiteValorNegativo = false;
            this.txtResponsavelAtivacao.Senha = "";
            this.txtResponsavelAtivacao.SenhaCrypt = "";
            this.txtResponsavelAtivacao.Size = new System.Drawing.Size(517, 20);
            this.txtResponsavelAtivacao.TabIndex = 96;
            // 
            // txtPessoa
            // 
            this.txtPessoa.Decimais = 0;
            this.txtPessoa.Enabled = false;
            this.txtPessoa.Formato = Telecon.Genericos.Controles.CaixaTexto.TipoFormato.Livre;
            this.txtPessoa.Location = new System.Drawing.Point(199, 239);
            this.txtPessoa.MaxLength = 32;
            this.txtPessoa.Name = "txtPessoa";
            this.txtPessoa.PermiteValorNegativo = false;
            this.txtPessoa.Senha = "";
            this.txtPessoa.SenhaCrypt = "";
            this.txtPessoa.Size = new System.Drawing.Size(517, 20);
            this.txtPessoa.TabIndex = 98;
            // 
            // txtResponsavelMenor
            // 
            this.txtResponsavelMenor.Decimais = 0;
            this.txtResponsavelMenor.Enabled = false;
            this.txtResponsavelMenor.Formato = Telecon.Genericos.Controles.CaixaTexto.TipoFormato.Livre;
            this.txtResponsavelMenor.Location = new System.Drawing.Point(199, 288);
            this.txtResponsavelMenor.MaxLength = 32;
            this.txtResponsavelMenor.Name = "txtResponsavelMenor";
            this.txtResponsavelMenor.PermiteValorNegativo = false;
            this.txtResponsavelMenor.Senha = "";
            this.txtResponsavelMenor.SenhaCrypt = "";
            this.txtResponsavelMenor.Size = new System.Drawing.Size(517, 20);
            this.txtResponsavelMenor.TabIndex = 100;
            this.txtResponsavelMenor.Visible = false;
            // 
            // FrmAtivacao
            // 
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.btnVoltar);
            this.Controls.Add(this.btnAtivar);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "FrmAtivacao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Prontovid EHR";
            this.Load += new System.EventHandler(this.FrmAtivacao_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmAtivacao_KeyDown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtEndereco;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton radMasc;
        private System.Windows.Forms.RadioButton radFem;
        private System.Windows.Forms.CheckBox chkAtivo;
        private System.Windows.Forms.Label label6;
        private Telecon.Genericos.Controles.CaixaTextoData txtDataNascimento;
        private Telecon.Genericos.Controles.CaixaTexto txtCpf;
        private Telecon.Genericos.Controles.CaixaTexto txtTelefone;
        private System.Windows.Forms.TextBox txtSenha;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnCadastro;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private Telecon.Genericos.Controles.ComboBoxItemData cboUsuario;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label10;
        private Telecon.Genericos.Controles.ComboBoxItemData cboResponsavelAtivacao;
        private System.Windows.Forms.Label lblResponsavel;
        private Telecon.Genericos.Controles.ComboBoxItemData cboResponsavel;
        private System.Windows.Forms.Label label9;
        private Telecon.Genericos.Controles.ComboBoxItemData cboUsuarios;
        private System.Windows.Forms.Button btnVoltar;
        private System.Windows.Forms.Button btnAtivar;
        private Telecon.Genericos.Controles.CaixaTexto txtResponsavelMenor;
        private Telecon.Genericos.Controles.CaixaTexto txtPessoa;
        private Telecon.Genericos.Controles.CaixaTexto txtResponsavelAtivacao;
    }
}

