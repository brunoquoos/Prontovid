namespace Prontovid
{
    partial class FrmInclusaoResultadoExames
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmInclusaoResultadoExames));
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.txtPaciente = new Telecon.Genericos.Controles.CaixaTexto();
            this.lbl = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cboUsuarios = new Telecon.Genericos.Controles.ComboBoxItemData();
            this.txtDataExame = new Telecon.Genericos.Controles.CaixaTextoData();
            this.txtDataResultadoProvavel = new Telecon.Genericos.Controles.CaixaTextoData();
            this.lbl1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtObs = new Telecon.Genericos.Controles.CaixaTexto();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cboExame = new Telecon.Genericos.Controles.ComboBoxItemData();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDataResultado = new Telecon.Genericos.Controles.CaixaTextoData();
            this.label6 = new System.Windows.Forms.Label();
            this.txtResultado = new Telecon.Genericos.Controles.CaixaTexto();
            this.label1 = new System.Windows.Forms.Label();
            this.txtObsResultado = new Telecon.Genericos.Controles.CaixaTexto();
            this.lblStatusPessoa = new System.Windows.Forms.Label();
            this.cboStatusPessoa = new Telecon.Genericos.Controles.ComboBoxItemData();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(615, 526);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(76, 23);
            this.btnCancelar.TabIndex = 10;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(697, 526);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(75, 23);
            this.btnSalvar.TabIndex = 9;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // txtPaciente
            // 
            this.txtPaciente.Decimais = 0;
            this.txtPaciente.Enabled = false;
            this.txtPaciente.Formato = Telecon.Genericos.Controles.CaixaTexto.TipoFormato.Livre;
            this.txtPaciente.Location = new System.Drawing.Point(159, 34);
            this.txtPaciente.MaxLength = 32;
            this.txtPaciente.Name = "txtPaciente";
            this.txtPaciente.PermiteValorNegativo = false;
            this.txtPaciente.Senha = "";
            this.txtPaciente.SenhaCrypt = "";
            this.txtPaciente.Size = new System.Drawing.Size(613, 20);
            this.txtPaciente.TabIndex = 1;
            // 
            // lbl
            // 
            this.lbl.AutoSize = true;
            this.lbl.Location = new System.Drawing.Point(156, 18);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(49, 13);
            this.lbl.TabIndex = 48;
            this.lbl.Text = "Paciente";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(9, 18);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(74, 13);
            this.label9.TabIndex = 53;
            this.label9.Text = "User Paciente";
            // 
            // cboUsuarios
            // 
            this.cboUsuarios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboUsuarios.FormattingEnabled = true;
            this.cboUsuarios.Location = new System.Drawing.Point(12, 34);
            this.cboUsuarios.Name = "cboUsuarios";
            this.cboUsuarios.Size = new System.Drawing.Size(138, 21);
            this.cboUsuarios.TabIndex = 0;
            this.cboUsuarios.SelectedIndexChanged += new System.EventHandler(this.cboUsuarios_SelectedIndexChanged);
            // 
            // txtDataExame
            // 
            this.txtDataExame.Enabled = false;
            this.txtDataExame.Location = new System.Drawing.Point(12, 123);
            this.txtDataExame.Name = "txtDataExame";
            this.txtDataExame.Size = new System.Drawing.Size(184, 20);
            this.txtDataExame.TabIndex = 3;
            this.txtDataExame.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtDataResultadoProvavel
            // 
            this.txtDataResultadoProvavel.Enabled = false;
            this.txtDataResultadoProvavel.Location = new System.Drawing.Point(205, 123);
            this.txtDataResultadoProvavel.Name = "txtDataResultadoProvavel";
            this.txtDataResultadoProvavel.Size = new System.Drawing.Size(184, 20);
            this.txtDataResultadoProvavel.TabIndex = 4;
            this.txtDataResultadoProvavel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.Location = new System.Drawing.Point(9, 107);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(80, 13);
            this.lbl1.TabIndex = 58;
            this.lbl1.Text = "Data do Exame";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(202, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(147, 13);
            this.label3.TabIndex = 59;
            this.label3.Text = "Data de Resultado (Provável)";
            // 
            // txtObs
            // 
            this.txtObs.Decimais = 0;
            this.txtObs.Enabled = false;
            this.txtObs.Formato = Telecon.Genericos.Controles.CaixaTexto.TipoFormato.Livre;
            this.txtObs.Location = new System.Drawing.Point(12, 169);
            this.txtObs.MaxLength = 1024;
            this.txtObs.Multiline = true;
            this.txtObs.Name = "txtObs";
            this.txtObs.PermiteValorNegativo = false;
            this.txtObs.Senha = "";
            this.txtObs.SenhaCrypt = "";
            this.txtObs.Size = new System.Drawing.Size(760, 97);
            this.txtObs.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 153);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 13);
            this.label4.TabIndex = 61;
            this.label4.Text = "Observações Exame";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 63;
            this.label2.Text = "Exame";
            // 
            // cboExame
            // 
            this.cboExame.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboExame.FormattingEnabled = true;
            this.cboExame.Location = new System.Drawing.Point(12, 78);
            this.cboExame.Name = "cboExame";
            this.cboExame.Size = new System.Drawing.Size(760, 21);
            this.cboExame.TabIndex = 2;
            this.cboExame.SelectedIndexChanged += new System.EventHandler(this.cboExame_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(392, 107);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 13);
            this.label5.TabIndex = 65;
            this.label5.Text = "Data de Resultado";
            // 
            // txtDataResultado
            // 
            this.txtDataResultado.Location = new System.Drawing.Point(395, 123);
            this.txtDataResultado.Name = "txtDataResultado";
            this.txtDataResultado.Size = new System.Drawing.Size(184, 20);
            this.txtDataResultado.TabIndex = 5;
            this.txtDataResultado.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 273);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 13);
            this.label6.TabIndex = 67;
            this.label6.Text = "Resultado";
            // 
            // txtResultado
            // 
            this.txtResultado.Decimais = 0;
            this.txtResultado.Formato = Telecon.Genericos.Controles.CaixaTexto.TipoFormato.Livre;
            this.txtResultado.Location = new System.Drawing.Point(12, 289);
            this.txtResultado.MaxLength = 1024;
            this.txtResultado.Multiline = true;
            this.txtResultado.Name = "txtResultado";
            this.txtResultado.PermiteValorNegativo = false;
            this.txtResultado.Senha = "";
            this.txtResultado.SenhaCrypt = "";
            this.txtResultado.Size = new System.Drawing.Size(760, 35);
            this.txtResultado.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 333);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 13);
            this.label1.TabIndex = 69;
            this.label1.Text = "Observações Resultado";
            // 
            // txtObsResultado
            // 
            this.txtObsResultado.Decimais = 0;
            this.txtObsResultado.Formato = Telecon.Genericos.Controles.CaixaTexto.TipoFormato.Livre;
            this.txtObsResultado.Location = new System.Drawing.Point(12, 349);
            this.txtObsResultado.MaxLength = 1024;
            this.txtObsResultado.Multiline = true;
            this.txtObsResultado.Name = "txtObsResultado";
            this.txtObsResultado.PermiteValorNegativo = false;
            this.txtObsResultado.Senha = "";
            this.txtObsResultado.SenhaCrypt = "";
            this.txtObsResultado.Size = new System.Drawing.Size(760, 97);
            this.txtObsResultado.TabIndex = 8;
            // 
            // lblStatusPessoa
            // 
            this.lblStatusPessoa.AutoSize = true;
            this.lblStatusPessoa.Location = new System.Drawing.Point(582, 106);
            this.lblStatusPessoa.Name = "lblStatusPessoa";
            this.lblStatusPessoa.Size = new System.Drawing.Size(82, 13);
            this.lblStatusPessoa.TabIndex = 106;
            this.lblStatusPessoa.Text = "Status Paciente";
            // 
            // cboStatusPessoa
            // 
            this.cboStatusPessoa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStatusPessoa.FormattingEnabled = true;
            this.cboStatusPessoa.Location = new System.Drawing.Point(585, 123);
            this.cboStatusPessoa.Name = "cboStatusPessoa";
            this.cboStatusPessoa.Size = new System.Drawing.Size(187, 21);
            this.cboStatusPessoa.TabIndex = 105;
            // 
            // FrmInclusaoResultadoExames
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.lblStatusPessoa);
            this.Controls.Add(this.cboStatusPessoa);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtObsResultado);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtResultado);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtDataResultado);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboExame);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtObs);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbl1);
            this.Controls.Add(this.txtDataResultadoProvavel);
            this.Controls.Add(this.txtDataExame);
            this.Controls.Add(this.cboUsuarios);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lbl);
            this.Controls.Add(this.txtPaciente);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.btnCancelar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "FrmInclusaoResultadoExames";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ProntoVid EHR";
            this.Load += new System.EventHandler(this.FrmInclusaoResultadoExames_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmInclusaoResultadoExames_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnSalvar;
        private Telecon.Genericos.Controles.CaixaTexto txtPaciente;
        private System.Windows.Forms.Label lbl;
        private System.Windows.Forms.Label label9;
        private Telecon.Genericos.Controles.ComboBoxItemData cboUsuarios;
        private Telecon.Genericos.Controles.CaixaTextoData txtDataExame;
        private Telecon.Genericos.Controles.CaixaTextoData txtDataResultadoProvavel;
        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.Label label3;
        private Telecon.Genericos.Controles.CaixaTexto txtObs;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private Telecon.Genericos.Controles.ComboBoxItemData cboExame;
        private System.Windows.Forms.Label label5;
        private Telecon.Genericos.Controles.CaixaTextoData txtDataResultado;
        private System.Windows.Forms.Label label6;
        private Telecon.Genericos.Controles.CaixaTexto txtResultado;
        private System.Windows.Forms.Label label1;
        private Telecon.Genericos.Controles.CaixaTexto txtObsResultado;
        private System.Windows.Forms.Label lblStatusPessoa;
        private Telecon.Genericos.Controles.ComboBoxItemData cboStatusPessoa;
    }
}

