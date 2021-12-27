namespace Prontovid
{
    partial class FrmInicio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmInicio));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.picQr = new System.Windows.Forms.PictureBox();
            this.btnMeusAtendimentos = new System.Windows.Forms.Button();
            this.btnInclusaoResultados = new System.Windows.Forms.Button();
            this.btnMeuCadastro = new System.Windows.Forms.Button();
            this.btnLogoff = new System.Windows.Forms.Button();
            this.btnResultadoExames = new System.Windows.Forms.Button();
            this.btnAtivacaoUsuario = new System.Windows.Forms.Button();
            this.btnInclusaoExames = new System.Windows.Forms.Button();
            this.btnInclusaoSintomas = new System.Windows.Forms.Button();
            this.btnPesquisaUsuario = new System.Windows.Forms.Button();
            this.btnNovoUsuario = new System.Windows.Forms.Button();
            this.grbMeuPaciente = new System.Windows.Forms.GroupBox();
            this.btnExcluirFhir = new System.Windows.Forms.Button();
            this.btnAtualizarFhir = new System.Windows.Forms.Button();
            this.btnAddFhir = new System.Windows.Forms.Button();
            this.btnFhir = new System.Windows.Forms.Button();
            this.txtPaciente = new Telecon.Genericos.Controles.CaixaTexto();
            this.cboPaciente = new Telecon.Genericos.Controles.ComboBoxItemData();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picQr)).BeginInit();
            this.grbMeuPaciente.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblUsuario);
            this.groupBox1.Location = new System.Drawing.Point(12, 511);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(760, 38);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuario.Location = new System.Drawing.Point(6, 13);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(58, 13);
            this.lblUsuario.TabIndex = 11;
            this.lblUsuario.Text = "Usuário: ";
            this.lblUsuario.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // groupBox2
            // 
            this.groupBox2.AutoSize = true;
            this.groupBox2.BackColor = System.Drawing.Color.White;
            this.groupBox2.Controls.Add(this.picQr);
            this.groupBox2.Location = new System.Drawing.Point(417, 320);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(160, 185);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Meu QR";
            // 
            // picQr
            // 
            this.picQr.Location = new System.Drawing.Point(6, 19);
            this.picQr.Name = "picQr";
            this.picQr.Size = new System.Drawing.Size(143, 147);
            this.picQr.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picQr.TabIndex = 13;
            this.picQr.TabStop = false;
            // 
            // btnMeusAtendimentos
            // 
            this.btnMeusAtendimentos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMeusAtendimentos.Image = global::Prontovid.Properties.Resources.Remédio1;
            this.btnMeusAtendimentos.Location = new System.Drawing.Point(428, 12);
            this.btnMeusAtendimentos.Name = "btnMeusAtendimentos";
            this.btnMeusAtendimentos.Size = new System.Drawing.Size(134, 139);
            this.btnMeusAtendimentos.TabIndex = 2;
            this.btnMeusAtendimentos.Text = "Meus Atendimentos";
            this.btnMeusAtendimentos.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMeusAtendimentos.UseVisualStyleBackColor = true;
            this.btnMeusAtendimentos.Click += new System.EventHandler(this.btnMeusAtendimentos_Click);
            // 
            // btnInclusaoResultados
            // 
            this.btnInclusaoResultados.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInclusaoResultados.Image = global::Prontovid.Properties.Resources.Enferemeira1;
            this.btnInclusaoResultados.Location = new System.Drawing.Point(220, 366);
            this.btnInclusaoResultados.Name = "btnInclusaoResultados";
            this.btnInclusaoResultados.Size = new System.Drawing.Size(134, 139);
            this.btnInclusaoResultados.TabIndex = 8;
            this.btnInclusaoResultados.Text = "Inclusão Resultados";
            this.btnInclusaoResultados.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnInclusaoResultados.UseVisualStyleBackColor = true;
            this.btnInclusaoResultados.Click += new System.EventHandler(this.btnInclusaoResultados_Click);
            // 
            // btnMeuCadastro
            // 
            this.btnMeuCadastro.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMeuCadastro.Image = global::Prontovid.Properties.Resources.Paciente;
            this.btnMeuCadastro.Location = new System.Drawing.Point(12, 12);
            this.btnMeuCadastro.Name = "btnMeuCadastro";
            this.btnMeuCadastro.Size = new System.Drawing.Size(134, 139);
            this.btnMeuCadastro.TabIndex = 0;
            this.btnMeuCadastro.Text = "Meu Cadastro";
            this.btnMeuCadastro.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMeuCadastro.UseVisualStyleBackColor = true;
            this.btnMeuCadastro.Click += new System.EventHandler(this.btnMeuCadastro_Click);
            // 
            // btnLogoff
            // 
            this.btnLogoff.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogoff.Image = global::Prontovid.Properties.Resources.Sair;
            this.btnLogoff.Location = new System.Drawing.Point(638, 366);
            this.btnLogoff.Name = "btnLogoff";
            this.btnLogoff.Size = new System.Drawing.Size(134, 139);
            this.btnLogoff.TabIndex = 10;
            this.btnLogoff.Text = "Sair";
            this.btnLogoff.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnLogoff.UseVisualStyleBackColor = true;
            this.btnLogoff.Click += new System.EventHandler(this.btnLogoff_Click);
            // 
            // btnResultadoExames
            // 
            this.btnResultadoExames.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResultadoExames.Image = global::Prontovid.Properties.Resources.Resultados1;
            this.btnResultadoExames.Location = new System.Drawing.Point(220, 12);
            this.btnResultadoExames.Name = "btnResultadoExames";
            this.btnResultadoExames.Size = new System.Drawing.Size(134, 139);
            this.btnResultadoExames.TabIndex = 1;
            this.btnResultadoExames.Text = "Resultados Exames";
            this.btnResultadoExames.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnResultadoExames.UseVisualStyleBackColor = true;
            this.btnResultadoExames.Click += new System.EventHandler(this.btnResultadoExames_Click);
            // 
            // btnAtivacaoUsuario
            // 
            this.btnAtivacaoUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAtivacaoUsuario.Image = global::Prontovid.Properties.Resources.Doutor1;
            this.btnAtivacaoUsuario.Location = new System.Drawing.Point(12, 366);
            this.btnAtivacaoUsuario.Name = "btnAtivacaoUsuario";
            this.btnAtivacaoUsuario.Size = new System.Drawing.Size(134, 139);
            this.btnAtivacaoUsuario.TabIndex = 7;
            this.btnAtivacaoUsuario.Text = "Ativação de Usuário";
            this.btnAtivacaoUsuario.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAtivacaoUsuario.UseVisualStyleBackColor = true;
            this.btnAtivacaoUsuario.Click += new System.EventHandler(this.btnAtivacaoUsuario_Click);
            // 
            // btnInclusaoExames
            // 
            this.btnInclusaoExames.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInclusaoExames.Image = global::Prontovid.Properties.Resources.Sangue;
            this.btnInclusaoExames.Location = new System.Drawing.Point(220, 189);
            this.btnInclusaoExames.Name = "btnInclusaoExames";
            this.btnInclusaoExames.Size = new System.Drawing.Size(134, 139);
            this.btnInclusaoExames.TabIndex = 5;
            this.btnInclusaoExames.Text = "Pedido de Exames";
            this.btnInclusaoExames.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnInclusaoExames.UseVisualStyleBackColor = true;
            this.btnInclusaoExames.Click += new System.EventHandler(this.btnInclusaoExames_Click);
            // 
            // btnInclusaoSintomas
            // 
            this.btnInclusaoSintomas.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInclusaoSintomas.Image = global::Prontovid.Properties.Resources.Ambulancia2;
            this.btnInclusaoSintomas.Location = new System.Drawing.Point(12, 189);
            this.btnInclusaoSintomas.Name = "btnInclusaoSintomas";
            this.btnInclusaoSintomas.Size = new System.Drawing.Size(134, 139);
            this.btnInclusaoSintomas.TabIndex = 4;
            this.btnInclusaoSintomas.Text = "Atendimento";
            this.btnInclusaoSintomas.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnInclusaoSintomas.UseVisualStyleBackColor = true;
            this.btnInclusaoSintomas.Click += new System.EventHandler(this.btnInclusaoSintomas_Click);
            // 
            // btnPesquisaUsuario
            // 
            this.btnPesquisaUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPesquisaUsuario.Image = global::Prontovid.Properties.Resources.Maleta;
            this.btnPesquisaUsuario.Location = new System.Drawing.Point(638, 189);
            this.btnPesquisaUsuario.Name = "btnPesquisaUsuario";
            this.btnPesquisaUsuario.Size = new System.Drawing.Size(134, 139);
            this.btnPesquisaUsuario.TabIndex = 6;
            this.btnPesquisaUsuario.Text = "Pesquisa/Editar Usuários";
            this.btnPesquisaUsuario.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnPesquisaUsuario.UseVisualStyleBackColor = true;
            this.btnPesquisaUsuario.Click += new System.EventHandler(this.btnPesquisaUsuario_Click);
            // 
            // btnNovoUsuario
            // 
            this.btnNovoUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNovoUsuario.Image = global::Prontovid.Properties.Resources.NovoPaciente1;
            this.btnNovoUsuario.Location = new System.Drawing.Point(638, 12);
            this.btnNovoUsuario.Name = "btnNovoUsuario";
            this.btnNovoUsuario.Size = new System.Drawing.Size(134, 139);
            this.btnNovoUsuario.TabIndex = 3;
            this.btnNovoUsuario.Text = "Novo Usuário";
            this.btnNovoUsuario.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNovoUsuario.UseVisualStyleBackColor = true;
            this.btnNovoUsuario.Click += new System.EventHandler(this.btnNovoUsuario_Click);
            // 
            // grbMeuPaciente
            // 
            this.grbMeuPaciente.Controls.Add(this.btnExcluirFhir);
            this.grbMeuPaciente.Controls.Add(this.btnAtualizarFhir);
            this.grbMeuPaciente.Controls.Add(this.btnAddFhir);
            this.grbMeuPaciente.Controls.Add(this.btnFhir);
            this.grbMeuPaciente.Controls.Add(this.txtPaciente);
            this.grbMeuPaciente.Controls.Add(this.cboPaciente);
            this.grbMeuPaciente.Location = new System.Drawing.Point(397, 157);
            this.grbMeuPaciente.Name = "grbMeuPaciente";
            this.grbMeuPaciente.Size = new System.Drawing.Size(200, 157);
            this.grbMeuPaciente.TabIndex = 57;
            this.grbMeuPaciente.TabStop = false;
            this.grbMeuPaciente.Text = "Meu Paciente";
            this.grbMeuPaciente.Visible = false;
            // 
            // btnExcluirFhir
            // 
            this.btnExcluirFhir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExcluirFhir.Location = new System.Drawing.Point(103, 114);
            this.btnExcluirFhir.Name = "btnExcluirFhir";
            this.btnExcluirFhir.Size = new System.Drawing.Size(77, 37);
            this.btnExcluirFhir.TabIndex = 62;
            this.btnExcluirFhir.Text = "Excluir no FHIR";
            this.btnExcluirFhir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnExcluirFhir.UseVisualStyleBackColor = true;
            this.btnExcluirFhir.Click += new System.EventHandler(this.btnExcluirFhir_Click);
            // 
            // btnAtualizarFhir
            // 
            this.btnAtualizarFhir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAtualizarFhir.Location = new System.Drawing.Point(20, 114);
            this.btnAtualizarFhir.Name = "btnAtualizarFhir";
            this.btnAtualizarFhir.Size = new System.Drawing.Size(77, 37);
            this.btnAtualizarFhir.TabIndex = 61;
            this.btnAtualizarFhir.Text = "Atualizar no FHIR";
            this.btnAtualizarFhir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAtualizarFhir.UseVisualStyleBackColor = true;
            this.btnAtualizarFhir.Click += new System.EventHandler(this.btnAtualizarFhir_Click);
            // 
            // btnAddFhir
            // 
            this.btnAddFhir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddFhir.Location = new System.Drawing.Point(20, 77);
            this.btnAddFhir.Name = "btnAddFhir";
            this.btnAddFhir.Size = new System.Drawing.Size(77, 37);
            this.btnAddFhir.TabIndex = 59;
            this.btnAddFhir.Text = "Adicionar ao FHIR";
            this.btnAddFhir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAddFhir.UseVisualStyleBackColor = true;
            this.btnAddFhir.Click += new System.EventHandler(this.btnAddFhir_Click);
            // 
            // btnFhir
            // 
            this.btnFhir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFhir.Location = new System.Drawing.Point(103, 77);
            this.btnFhir.Name = "btnFhir";
            this.btnFhir.Size = new System.Drawing.Size(77, 37);
            this.btnFhir.TabIndex = 60;
            this.btnFhir.Text = "Consultar FHIR";
            this.btnFhir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnFhir.UseVisualStyleBackColor = true;
            this.btnFhir.Click += new System.EventHandler(this.btnFhir_Click);
            // 
            // txtPaciente
            // 
            this.txtPaciente.Decimais = 0;
            this.txtPaciente.Enabled = false;
            this.txtPaciente.Formato = Telecon.Genericos.Controles.CaixaTexto.TipoFormato.Livre;
            this.txtPaciente.Location = new System.Drawing.Point(8, 46);
            this.txtPaciente.MaxLength = 32;
            this.txtPaciente.Name = "txtPaciente";
            this.txtPaciente.PermiteValorNegativo = false;
            this.txtPaciente.Senha = "";
            this.txtPaciente.SenhaCrypt = "";
            this.txtPaciente.Size = new System.Drawing.Size(185, 20);
            this.txtPaciente.TabIndex = 58;
            // 
            // cboPaciente
            // 
            this.cboPaciente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPaciente.FormattingEnabled = true;
            this.cboPaciente.Location = new System.Drawing.Point(8, 19);
            this.cboPaciente.Name = "cboPaciente";
            this.cboPaciente.Size = new System.Drawing.Size(185, 21);
            this.cboPaciente.TabIndex = 57;
            this.cboPaciente.SelectedIndexChanged += new System.EventHandler(this.cboPaciente_SelectedIndexChanged);
            // 
            // FrmInicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CadetBlue;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.grbMeuPaciente);
            this.Controls.Add(this.btnMeusAtendimentos);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnInclusaoResultados);
            this.Controls.Add(this.btnMeuCadastro);
            this.Controls.Add(this.btnLogoff);
            this.Controls.Add(this.btnResultadoExames);
            this.Controls.Add(this.btnAtivacaoUsuario);
            this.Controls.Add(this.btnInclusaoExames);
            this.Controls.Add(this.btnInclusaoSintomas);
            this.Controls.Add(this.btnPesquisaUsuario);
            this.Controls.Add(this.btnNovoUsuario);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "FrmInicio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ProntoVid EHR";
            this.Activated += new System.EventHandler(this.FrmInicio_Activated);
            this.Load += new System.EventHandler(this.FrmInicio_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmInicio_KeyDown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picQr)).EndInit();
            this.grbMeuPaciente.ResumeLayout(false);
            this.grbMeuPaciente.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnNovoUsuario;
        private System.Windows.Forms.Button btnPesquisaUsuario;
        private System.Windows.Forms.Button btnInclusaoSintomas;
        private System.Windows.Forms.Button btnInclusaoExames;
        private System.Windows.Forms.Button btnAtivacaoUsuario;
        private System.Windows.Forms.Button btnResultadoExames;
        private System.Windows.Forms.Button btnLogoff;
        private System.Windows.Forms.Button btnMeuCadastro;
        private System.Windows.Forms.Button btnInclusaoResultados;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.PictureBox picQr;
        private System.Windows.Forms.Button btnMeusAtendimentos;
        private System.Windows.Forms.GroupBox grbMeuPaciente;
        private Telecon.Genericos.Controles.CaixaTexto txtPaciente;
        private Telecon.Genericos.Controles.ComboBoxItemData cboPaciente;
        private System.Windows.Forms.Button btnAddFhir;
        private System.Windows.Forms.Button btnFhir;
        private System.Windows.Forms.Button btnExcluirFhir;
        private System.Windows.Forms.Button btnAtualizarFhir;
    }
}