namespace Prontovid
{
    partial class FrmPesquisaExames
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPesquisaExames));
            this.listView1 = new System.Windows.Forms.ListView();
            this.cboUsuarios = new Telecon.Genericos.Controles.ComboBoxItemData();
            this.label9 = new System.Windows.Forms.Label();
            this.cboTiposExames = new Telecon.Genericos.Controles.ComboBoxItemData();
            this.label1 = new System.Windows.Forms.Label();
            this.btnVoltar = new System.Windows.Forms.Button();
            this.lbl = new System.Windows.Forms.Label();
            this.txtPaciente = new Telecon.Genericos.Controles.CaixaTexto();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(12, 91);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(760, 429);
            this.listView1.TabIndex = 2;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseDoubleClick);
            // 
            // cboUsuarios
            // 
            this.cboUsuarios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboUsuarios.FormattingEnabled = true;
            this.cboUsuarios.Location = new System.Drawing.Point(12, 24);
            this.cboUsuarios.Name = "cboUsuarios";
            this.cboUsuarios.Size = new System.Drawing.Size(141, 21);
            this.cboUsuarios.TabIndex = 0;
            this.cboUsuarios.SelectedIndexChanged += new System.EventHandler(this.cboUsuarios_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(9, 9);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(74, 13);
            this.label9.TabIndex = 18;
            this.label9.Text = "User Paciente";
            // 
            // cboTiposExames
            // 
            this.cboTiposExames.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTiposExames.FormattingEnabled = true;
            this.cboTiposExames.Location = new System.Drawing.Point(12, 64);
            this.cboTiposExames.Name = "cboTiposExames";
            this.cboTiposExames.Size = new System.Drawing.Size(760, 21);
            this.cboTiposExames.TabIndex = 1;
            this.cboTiposExames.SelectedIndexChanged += new System.EventHandler(this.cboTiposExames_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "Exame";
            // 
            // btnVoltar
            // 
            this.btnVoltar.Location = new System.Drawing.Point(696, 526);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(76, 23);
            this.btnVoltar.TabIndex = 3;
            this.btnVoltar.Text = "Voltar";
            this.btnVoltar.UseVisualStyleBackColor = true;
            this.btnVoltar.Click += new System.EventHandler(this.btnVoltar_Click);
            // 
            // lbl
            // 
            this.lbl.AutoSize = true;
            this.lbl.Location = new System.Drawing.Point(156, 9);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(49, 13);
            this.lbl.TabIndex = 50;
            this.lbl.Text = "Paciente";
            // 
            // txtPaciente
            // 
            this.txtPaciente.Decimais = 0;
            this.txtPaciente.Enabled = false;
            this.txtPaciente.Formato = Telecon.Genericos.Controles.CaixaTexto.TipoFormato.Livre;
            this.txtPaciente.Location = new System.Drawing.Point(159, 25);
            this.txtPaciente.MaxLength = 32;
            this.txtPaciente.Name = "txtPaciente";
            this.txtPaciente.PermiteValorNegativo = false;
            this.txtPaciente.Senha = "";
            this.txtPaciente.SenhaCrypt = "";
            this.txtPaciente.Size = new System.Drawing.Size(613, 20);
            this.txtPaciente.TabIndex = 49;
            // 
            // FrmPesquisaExames
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.lbl);
            this.Controls.Add(this.txtPaciente);
            this.Controls.Add(this.btnVoltar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboTiposExames);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cboUsuarios);
            this.Controls.Add(this.listView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "FrmPesquisaExames";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ProntoVid EHR";
            this.Activated += new System.EventHandler(this.FrmPesquisaExames_Activated);
            this.Load += new System.EventHandler(this.FrmPesquisaExames_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmPesquisaExames_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListView listView1;
        private Telecon.Genericos.Controles.ComboBoxItemData cboUsuarios;
        private System.Windows.Forms.Label label9;
        private Telecon.Genericos.Controles.ComboBoxItemData cboTiposExames;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnVoltar;
        private System.Windows.Forms.Label lbl;
        private Telecon.Genericos.Controles.CaixaTexto txtPaciente;
    }
}