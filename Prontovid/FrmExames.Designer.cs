namespace Prontovid
{
    partial class FrmExames
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmExames));
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.txtPaciente = new Telecon.Genericos.Controles.CaixaTexto();
            this.lbl = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cboUsuarios = new Telecon.Genericos.Controles.ComboBoxItemData();
            this.cboTiposExames = new Telecon.Genericos.Controles.ComboBoxItemData();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDataExame = new Telecon.Genericos.Controles.CaixaTextoData();
            this.txtDataResultado = new Telecon.Genericos.Controles.CaixaTextoData();
            this.lbl1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtObs = new Telecon.Genericos.Controles.CaixaTexto();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(615, 526);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(76, 23);
            this.btnCancelar.TabIndex = 27;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(697, 526);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(75, 23);
            this.btnSalvar.TabIndex = 28;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // txtPaciente
            // 
            this.txtPaciente.Decimais = 0;
            this.txtPaciente.Enabled = false;
            this.txtPaciente.Formato = Telecon.Genericos.Controles.CaixaTexto.TipoFormato.Livre;
            this.txtPaciente.Location = new System.Drawing.Point(258, 34);
            this.txtPaciente.MaxLength = 32;
            this.txtPaciente.Name = "txtPaciente";
            this.txtPaciente.PermiteValorNegativo = false;
            this.txtPaciente.Senha = "";
            this.txtPaciente.SenhaCrypt = "";
            this.txtPaciente.Size = new System.Drawing.Size(514, 20);
            this.txtPaciente.TabIndex = 10;
            // 
            // lbl
            // 
            this.lbl.AutoSize = true;
            this.lbl.Location = new System.Drawing.Point(255, 17);
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
            this.cboUsuarios.Size = new System.Drawing.Size(240, 21);
            this.cboUsuarios.TabIndex = 0;
            this.cboUsuarios.SelectedIndexChanged += new System.EventHandler(this.cboUsuarios_SelectedIndexChanged);
            // 
            // cboTiposExames
            // 
            this.cboTiposExames.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTiposExames.FormattingEnabled = true;
            this.cboTiposExames.Location = new System.Drawing.Point(12, 85);
            this.cboTiposExames.Name = "cboTiposExames";
            this.cboTiposExames.Size = new System.Drawing.Size(760, 21);
            this.cboTiposExames.TabIndex = 54;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 55;
            this.label1.Text = "Tipo de Exame";
            // 
            // txtDataExame
            // 
            this.txtDataExame.Location = new System.Drawing.Point(12, 132);
            this.txtDataExame.Name = "txtDataExame";
            this.txtDataExame.Size = new System.Drawing.Size(240, 20);
            this.txtDataExame.TabIndex = 56;
            this.txtDataExame.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtDataResultado
            // 
            this.txtDataResultado.Location = new System.Drawing.Point(12, 177);
            this.txtDataResultado.Name = "txtDataResultado";
            this.txtDataResultado.Size = new System.Drawing.Size(240, 20);
            this.txtDataResultado.TabIndex = 57;
            this.txtDataResultado.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.Location = new System.Drawing.Point(9, 116);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(80, 13);
            this.lbl1.TabIndex = 58;
            this.lbl1.Text = "Data do Exame";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 161);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(147, 13);
            this.label3.TabIndex = 59;
            this.label3.Text = "Data de Resultado (Provável)";
            // 
            // txtObs
            // 
            this.txtObs.Decimais = 0;
            this.txtObs.Formato = Telecon.Genericos.Controles.CaixaTexto.TipoFormato.Livre;
            this.txtObs.Location = new System.Drawing.Point(12, 223);
            this.txtObs.MaxLength = 1024;
            this.txtObs.Multiline = true;
            this.txtObs.Name = "txtObs";
            this.txtObs.PermiteValorNegativo = false;
            this.txtObs.Senha = "";
            this.txtObs.SenhaCrypt = "";
            this.txtObs.Size = new System.Drawing.Size(760, 97);
            this.txtObs.TabIndex = 60;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 207);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 13);
            this.label4.TabIndex = 61;
            this.label4.Text = "Observações";
            // 
            // FrmExames
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtObs);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbl1);
            this.Controls.Add(this.txtDataResultado);
            this.Controls.Add(this.txtDataExame);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboTiposExames);
            this.Controls.Add(this.cboUsuarios);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lbl);
            this.Controls.Add(this.txtPaciente);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.btnCancelar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "FrmExames";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ProntoVid EHR";
            this.Load += new System.EventHandler(this.FrmExames_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmExames_KeyDown);
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
        private Telecon.Genericos.Controles.ComboBoxItemData cboTiposExames;
        private System.Windows.Forms.Label label1;
        private Telecon.Genericos.Controles.CaixaTextoData txtDataExame;
        private Telecon.Genericos.Controles.CaixaTextoData txtDataResultado;
        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.Label label3;
        private Telecon.Genericos.Controles.CaixaTexto txtObs;
        private System.Windows.Forms.Label label4;
    }
}

