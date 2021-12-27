namespace Prontovid
{
    partial class FrmNovo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmNovo));
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtEndereco = new System.Windows.Forms.TextBox();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.radMasc = new System.Windows.Forms.RadioButton();
            this.radFem = new System.Windows.Forms.RadioButton();
            this.chkAtivo = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDataNascimento = new Telecon.Genericos.Controles.CaixaTextoData();
            this.txtCpf = new Telecon.Genericos.Controles.CaixaTexto();
            this.txtTelefone = new Telecon.Genericos.Controles.CaixaTexto();
            this.txtUsuario = new Telecon.Genericos.Controles.CaixaTexto();
            this.txtSenha = new Telecon.Genericos.Controles.CaixaTexto();
            this.lbl = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtConfirmarSenha = new Telecon.Genericos.Controles.CaixaTexto();
            this.label9 = new System.Windows.Forms.Label();
            this.cboNiveis = new Telecon.Genericos.Controles.ComboBoxItemData();
            this.txtCodigo = new Telecon.Genericos.Controles.CaixaTexto();
            this.cboResponsavel = new Telecon.Genericos.Controles.ComboBoxItemData();
            this.lblResponsavel = new System.Windows.Forms.Label();
            this.txtResponsavel = new System.Windows.Forms.TextBox();
            this.grbDadosClinicos = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.chkGestanteAltoRisco = new System.Windows.Forms.CheckBox();
            this.chkNeoplasiaMaligna = new System.Windows.Forms.CheckBox();
            this.chkDoencaCromossomica = new System.Windows.Forms.CheckBox();
            this.chkDiabetes = new System.Windows.Forms.CheckBox();
            this.chkDoencaRenalApartirGrau3 = new System.Windows.Forms.CheckBox();
            this.chkImunoDepressao = new System.Windows.Forms.CheckBox();
            this.chkTabagismo = new System.Windows.Forms.CheckBox();
            this.chkPneumopatiasGraves = new System.Windows.Forms.CheckBox();
            this.chkHipertensao = new System.Windows.Forms.CheckBox();
            this.chkInsuficienciaCardiaca = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtAltura = new Telecon.Genericos.Controles.CaixaTexto();
            this.label10 = new System.Windows.Forms.Label();
            this.txtPeso = new Telecon.Genericos.Controles.CaixaTexto();
            this.txtEmail = new Telecon.Genericos.Controles.CaixaTexto();
            this.grbDadosClinicos.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(615, 526);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(76, 23);
            this.btnCancelar.TabIndex = 17;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(697, 526);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(75, 23);
            this.btnSalvar.TabIndex = 16;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 219);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 13);
            this.label5.TabIndex = 30;
            this.label5.Text = "Email";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(404, 133);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 38;
            this.label4.Text = "Telefone";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 176);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 36;
            this.label3.Text = "Endereço";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 34;
            this.label1.Text = "Nome";
            // 
            // txtEndereco
            // 
            this.txtEndereco.Location = new System.Drawing.Point(15, 192);
            this.txtEndereco.MaxLength = 80;
            this.txtEndereco.Name = "txtEndereco";
            this.txtEndereco.Size = new System.Drawing.Size(701, 20);
            this.txtEndereco.TabIndex = 9;
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(15, 103);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(701, 20);
            this.txtNome.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(208, 133);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 40;
            this.label2.Text = "CPF";
            // 
            // radMasc
            // 
            this.radMasc.AutoSize = true;
            this.radMasc.Checked = true;
            this.radMasc.Location = new System.Drawing.Point(645, 151);
            this.radMasc.Name = "radMasc";
            this.radMasc.Size = new System.Drawing.Size(34, 17);
            this.radMasc.TabIndex = 7;
            this.radMasc.TabStop = true;
            this.radMasc.Text = "M";
            this.radMasc.UseVisualStyleBackColor = true;
            // 
            // radFem
            // 
            this.radFem.AutoSize = true;
            this.radFem.Location = new System.Drawing.Point(685, 151);
            this.radFem.Name = "radFem";
            this.radFem.Size = new System.Drawing.Size(31, 17);
            this.radFem.TabIndex = 8;
            this.radFem.Text = "F";
            this.radFem.UseVisualStyleBackColor = true;
            this.radFem.CheckedChanged += new System.EventHandler(this.radFem_CheckedChanged);
            // 
            // chkAtivo
            // 
            this.chkAtivo.AutoSize = true;
            this.chkAtivo.Location = new System.Drawing.Point(722, 105);
            this.chkAtivo.Name = "chkAtivo";
            this.chkAtivo.Size = new System.Drawing.Size(50, 17);
            this.chkAtivo.TabIndex = 3;
            this.chkAtivo.Text = "Ativo";
            this.chkAtivo.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 133);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(104, 13);
            this.label6.TabIndex = 45;
            this.label6.Text = "Data de Nascimento";
            // 
            // txtDataNascimento
            // 
            this.txtDataNascimento.Location = new System.Drawing.Point(15, 148);
            this.txtDataNascimento.Name = "txtDataNascimento";
            this.txtDataNascimento.Size = new System.Drawing.Size(155, 20);
            this.txtDataNascimento.TabIndex = 4;
            this.txtDataNascimento.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtDataNascimento.TextChanged += new System.EventHandler(this.txtDataNascimento_TextChanged);
            // 
            // txtCpf
            // 
            this.txtCpf.Decimais = 0;
            this.txtCpf.Formato = Telecon.Genericos.Controles.CaixaTexto.TipoFormato.Livre;
            this.txtCpf.Location = new System.Drawing.Point(211, 148);
            this.txtCpf.Name = "txtCpf";
            this.txtCpf.PermiteValorNegativo = false;
            this.txtCpf.Senha = "";
            this.txtCpf.SenhaCrypt = "";
            this.txtCpf.Size = new System.Drawing.Size(155, 20);
            this.txtCpf.TabIndex = 5;
            // 
            // txtTelefone
            // 
            this.txtTelefone.Decimais = 0;
            this.txtTelefone.Formato = Telecon.Genericos.Controles.CaixaTexto.TipoFormato.Livre;
            this.txtTelefone.Location = new System.Drawing.Point(407, 148);
            this.txtTelefone.Name = "txtTelefone";
            this.txtTelefone.PermiteValorNegativo = false;
            this.txtTelefone.Senha = "";
            this.txtTelefone.SenhaCrypt = "";
            this.txtTelefone.Size = new System.Drawing.Size(155, 20);
            this.txtTelefone.TabIndex = 6;
            // 
            // txtUsuario
            // 
            this.txtUsuario.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.txtUsuario.Decimais = 0;
            this.txtUsuario.Formato = Telecon.Genericos.Controles.CaixaTexto.TipoFormato.Minusculo;
            this.txtUsuario.Location = new System.Drawing.Point(15, 279);
            this.txtUsuario.MaxLength = 32;
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.PermiteValorNegativo = false;
            this.txtUsuario.Senha = "";
            this.txtUsuario.SenhaCrypt = "";
            this.txtUsuario.Size = new System.Drawing.Size(155, 20);
            this.txtUsuario.TabIndex = 11;
            this.txtUsuario.TextChanged += new System.EventHandler(this.txtUsuario_TextChanged);
            // 
            // txtSenha
            // 
            this.txtSenha.Decimais = 0;
            this.txtSenha.Formato = Telecon.Genericos.Controles.CaixaTexto.TipoFormato.Livre;
            this.txtSenha.Location = new System.Drawing.Point(211, 279);
            this.txtSenha.Name = "txtSenha";
            this.txtSenha.PasswordChar = '*';
            this.txtSenha.PermiteValorNegativo = false;
            this.txtSenha.Senha = "";
            this.txtSenha.SenhaCrypt = "";
            this.txtSenha.Size = new System.Drawing.Size(155, 20);
            this.txtSenha.TabIndex = 12;
            // 
            // lbl
            // 
            this.lbl.AutoSize = true;
            this.lbl.Location = new System.Drawing.Point(12, 263);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(29, 13);
            this.lbl.TabIndex = 48;
            this.lbl.Text = "User";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(208, 263);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(38, 13);
            this.label8.TabIndex = 49;
            this.label8.Text = "Senha";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(404, 263);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 13);
            this.label7.TabIndex = 51;
            this.label7.Text = "Confirmar Senha";
            // 
            // txtConfirmarSenha
            // 
            this.txtConfirmarSenha.Decimais = 0;
            this.txtConfirmarSenha.Formato = Telecon.Genericos.Controles.CaixaTexto.TipoFormato.Livre;
            this.txtConfirmarSenha.Location = new System.Drawing.Point(407, 279);
            this.txtConfirmarSenha.Name = "txtConfirmarSenha";
            this.txtConfirmarSenha.PasswordChar = '*';
            this.txtConfirmarSenha.PermiteValorNegativo = false;
            this.txtConfirmarSenha.Senha = "";
            this.txtConfirmarSenha.SenhaCrypt = "";
            this.txtConfirmarSenha.Size = new System.Drawing.Size(155, 20);
            this.txtConfirmarSenha.TabIndex = 13;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(585, 263);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(33, 13);
            this.label9.TabIndex = 53;
            this.label9.Text = "Nível";
            // 
            // cboNiveis
            // 
            this.cboNiveis.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNiveis.FormattingEnabled = true;
            this.cboNiveis.Location = new System.Drawing.Point(587, 279);
            this.cboNiveis.Name = "cboNiveis";
            this.cboNiveis.Size = new System.Drawing.Size(129, 21);
            this.cboNiveis.TabIndex = 14;
            // 
            // txtCodigo
            // 
            this.txtCodigo.Decimais = 0;
            this.txtCodigo.Enabled = false;
            this.txtCodigo.Formato = Telecon.Genericos.Controles.CaixaTexto.TipoFormato.Livre;
            this.txtCodigo.Location = new System.Drawing.Point(15, 11);
            this.txtCodigo.MaxLength = 32;
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.PermiteValorNegativo = false;
            this.txtCodigo.Senha = "";
            this.txtCodigo.SenhaCrypt = "";
            this.txtCodigo.Size = new System.Drawing.Size(101, 20);
            this.txtCodigo.TabIndex = 17;
            this.txtCodigo.Visible = false;
            // 
            // cboResponsavel
            // 
            this.cboResponsavel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboResponsavel.FormattingEnabled = true;
            this.cboResponsavel.Location = new System.Drawing.Point(15, 57);
            this.cboResponsavel.Name = "cboResponsavel";
            this.cboResponsavel.Size = new System.Drawing.Size(155, 21);
            this.cboResponsavel.TabIndex = 0;
            this.cboResponsavel.SelectedIndexChanged += new System.EventHandler(this.cboResponsavel_SelectedIndexChanged);
            // 
            // lblResponsavel
            // 
            this.lblResponsavel.AutoSize = true;
            this.lblResponsavel.Location = new System.Drawing.Point(12, 41);
            this.lblResponsavel.Name = "lblResponsavel";
            this.lblResponsavel.Size = new System.Drawing.Size(136, 13);
            this.lblResponsavel.TabIndex = 55;
            this.lblResponsavel.Text = "Responsável pelo paciente";
            // 
            // txtResponsavel
            // 
            this.txtResponsavel.Enabled = false;
            this.txtResponsavel.Location = new System.Drawing.Point(176, 58);
            this.txtResponsavel.Name = "txtResponsavel";
            this.txtResponsavel.Size = new System.Drawing.Size(540, 20);
            this.txtResponsavel.TabIndex = 1;
            // 
            // grbDadosClinicos
            // 
            this.grbDadosClinicos.Controls.Add(this.label13);
            this.grbDadosClinicos.Controls.Add(this.label12);
            this.grbDadosClinicos.Controls.Add(this.chkGestanteAltoRisco);
            this.grbDadosClinicos.Controls.Add(this.chkNeoplasiaMaligna);
            this.grbDadosClinicos.Controls.Add(this.chkDoencaCromossomica);
            this.grbDadosClinicos.Controls.Add(this.chkDiabetes);
            this.grbDadosClinicos.Controls.Add(this.chkDoencaRenalApartirGrau3);
            this.grbDadosClinicos.Controls.Add(this.chkImunoDepressao);
            this.grbDadosClinicos.Controls.Add(this.chkTabagismo);
            this.grbDadosClinicos.Controls.Add(this.chkPneumopatiasGraves);
            this.grbDadosClinicos.Controls.Add(this.chkHipertensao);
            this.grbDadosClinicos.Controls.Add(this.chkInsuficienciaCardiaca);
            this.grbDadosClinicos.Controls.Add(this.label11);
            this.grbDadosClinicos.Controls.Add(this.txtAltura);
            this.grbDadosClinicos.Controls.Add(this.label10);
            this.grbDadosClinicos.Controls.Add(this.txtPeso);
            this.grbDadosClinicos.Enabled = false;
            this.grbDadosClinicos.Location = new System.Drawing.Point(15, 328);
            this.grbDadosClinicos.Name = "grbDadosClinicos";
            this.grbDadosClinicos.Size = new System.Drawing.Size(757, 192);
            this.grbDadosClinicos.TabIndex = 15;
            this.grbDadosClinicos.TabStop = false;
            this.grbDadosClinicos.Text = "Dados Clínicos";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(177, 97);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(15, 13);
            this.label13.TabIndex = 68;
            this.label13.Text = "m";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label12.Location = new System.Drawing.Point(177, 46);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(19, 13);
            this.label12.TabIndex = 67;
            this.label12.Text = "kg";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkGestanteAltoRisco
            // 
            this.chkGestanteAltoRisco.AutoSize = true;
            this.chkGestanteAltoRisco.Location = new System.Drawing.Point(242, 20);
            this.chkGestanteAltoRisco.Name = "chkGestanteAltoRisco";
            this.chkGestanteAltoRisco.Size = new System.Drawing.Size(129, 17);
            this.chkGestanteAltoRisco.TabIndex = 2;
            this.chkGestanteAltoRisco.Text = "Gestante de alto risco";
            this.chkGestanteAltoRisco.UseVisualStyleBackColor = true;
            // 
            // chkNeoplasiaMaligna
            // 
            this.chkNeoplasiaMaligna.AutoSize = true;
            this.chkNeoplasiaMaligna.Location = new System.Drawing.Point(459, 122);
            this.chkNeoplasiaMaligna.Name = "chkNeoplasiaMaligna";
            this.chkNeoplasiaMaligna.Size = new System.Drawing.Size(112, 17);
            this.chkNeoplasiaMaligna.TabIndex = 9;
            this.chkNeoplasiaMaligna.Text = "Neoplasia maligna";
            this.chkNeoplasiaMaligna.UseVisualStyleBackColor = true;
            // 
            // chkDoencaCromossomica
            // 
            this.chkDoencaCromossomica.AutoSize = true;
            this.chkDoencaCromossomica.Location = new System.Drawing.Point(459, 88);
            this.chkDoencaCromossomica.Name = "chkDoencaCromossomica";
            this.chkDoencaCromossomica.Size = new System.Drawing.Size(134, 17);
            this.chkDoencaCromossomica.TabIndex = 7;
            this.chkDoencaCromossomica.Text = "Doença cromossômica";
            this.chkDoencaCromossomica.UseVisualStyleBackColor = true;
            // 
            // chkDiabetes
            // 
            this.chkDiabetes.AutoSize = true;
            this.chkDiabetes.Location = new System.Drawing.Point(459, 54);
            this.chkDiabetes.Name = "chkDiabetes";
            this.chkDiabetes.Size = new System.Drawing.Size(68, 17);
            this.chkDiabetes.TabIndex = 5;
            this.chkDiabetes.Text = "Diabetes";
            this.chkDiabetes.UseVisualStyleBackColor = true;
            // 
            // chkDoencaRenalApartirGrau3
            // 
            this.chkDoencaRenalApartirGrau3.AutoSize = true;
            this.chkDoencaRenalApartirGrau3.Location = new System.Drawing.Point(459, 20);
            this.chkDoencaRenalApartirGrau3.Name = "chkDoencaRenalApartirGrau3";
            this.chkDoencaRenalApartirGrau3.Size = new System.Drawing.Size(173, 17);
            this.chkDoencaRenalApartirGrau3.TabIndex = 3;
            this.chkDoencaRenalApartirGrau3.Text = "Doença renal à partir do grau 3";
            this.chkDoencaRenalApartirGrau3.UseVisualStyleBackColor = true;
            // 
            // chkImunoDepressao
            // 
            this.chkImunoDepressao.AutoSize = true;
            this.chkImunoDepressao.Location = new System.Drawing.Point(242, 156);
            this.chkImunoDepressao.Name = "chkImunoDepressao";
            this.chkImunoDepressao.Size = new System.Drawing.Size(104, 17);
            this.chkImunoDepressao.TabIndex = 10;
            this.chkImunoDepressao.Text = "Imunodepressão";
            this.chkImunoDepressao.UseVisualStyleBackColor = true;
            // 
            // chkTabagismo
            // 
            this.chkTabagismo.AutoSize = true;
            this.chkTabagismo.Location = new System.Drawing.Point(242, 122);
            this.chkTabagismo.Name = "chkTabagismo";
            this.chkTabagismo.Size = new System.Drawing.Size(78, 17);
            this.chkTabagismo.TabIndex = 8;
            this.chkTabagismo.Text = "Tabagismo";
            this.chkTabagismo.UseVisualStyleBackColor = true;
            // 
            // chkPneumopatiasGraves
            // 
            this.chkPneumopatiasGraves.AutoSize = true;
            this.chkPneumopatiasGraves.Location = new System.Drawing.Point(242, 88);
            this.chkPneumopatiasGraves.Name = "chkPneumopatiasGraves";
            this.chkPneumopatiasGraves.Size = new System.Drawing.Size(128, 17);
            this.chkPneumopatiasGraves.TabIndex = 6;
            this.chkPneumopatiasGraves.Text = "Pneumopatias graves";
            this.chkPneumopatiasGraves.UseVisualStyleBackColor = true;
            // 
            // chkHipertensao
            // 
            this.chkHipertensao.AutoSize = true;
            this.chkHipertensao.Location = new System.Drawing.Point(242, 54);
            this.chkHipertensao.Name = "chkHipertensao";
            this.chkHipertensao.Size = new System.Drawing.Size(83, 17);
            this.chkHipertensao.TabIndex = 4;
            this.chkHipertensao.Text = "Hipertensão";
            this.chkHipertensao.UseVisualStyleBackColor = true;
            // 
            // chkInsuficienciaCardiaca
            // 
            this.chkInsuficienciaCardiaca.AutoSize = true;
            this.chkInsuficienciaCardiaca.Location = new System.Drawing.Point(459, 156);
            this.chkInsuficienciaCardiaca.Name = "chkInsuficienciaCardiaca";
            this.chkInsuficienciaCardiaca.Size = new System.Drawing.Size(131, 17);
            this.chkInsuficienciaCardiaca.TabIndex = 11;
            this.chkInsuficienciaCardiaca.Text = "Insuficiência cardíaca";
            this.chkInsuficienciaCardiaca.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(18, 78);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(34, 13);
            this.label11.TabIndex = 51;
            this.label11.Text = "Altura";
            // 
            // txtAltura
            // 
            this.txtAltura.Decimais = 2;
            this.txtAltura.Formato = Telecon.Genericos.Controles.CaixaTexto.TipoFormato.Moeda;
            this.txtAltura.Location = new System.Drawing.Point(21, 94);
            this.txtAltura.MaxLength = 32;
            this.txtAltura.Name = "txtAltura";
            this.txtAltura.PermiteValorNegativo = false;
            this.txtAltura.Senha = "0,00";
            this.txtAltura.SenhaCrypt = "°¬°°";
            this.txtAltura.Size = new System.Drawing.Size(155, 20);
            this.txtAltura.TabIndex = 1;
            this.txtAltura.Text = "0,00";
            this.txtAltura.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(18, 27);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(31, 13);
            this.label10.TabIndex = 49;
            this.label10.Text = "Peso";
            // 
            // txtPeso
            // 
            this.txtPeso.Decimais = 2;
            this.txtPeso.Formato = Telecon.Genericos.Controles.CaixaTexto.TipoFormato.Moeda;
            this.txtPeso.Location = new System.Drawing.Point(21, 43);
            this.txtPeso.MaxLength = 32;
            this.txtPeso.Name = "txtPeso";
            this.txtPeso.PermiteValorNegativo = false;
            this.txtPeso.Senha = "0,00";
            this.txtPeso.SenhaCrypt = "°¬°°";
            this.txtPeso.Size = new System.Drawing.Size(155, 20);
            this.txtPeso.TabIndex = 0;
            this.txtPeso.Text = "0,00";
            this.txtPeso.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtEmail
            // 
            this.txtEmail.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.txtEmail.Decimais = 2;
            this.txtEmail.Formato = Telecon.Genericos.Controles.CaixaTexto.TipoFormato.Minusculo;
            this.txtEmail.Location = new System.Drawing.Point(15, 235);
            this.txtEmail.MaxLength = 32;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.PermiteValorNegativo = false;
            this.txtEmail.Senha = "";
            this.txtEmail.SenhaCrypt = "";
            this.txtEmail.Size = new System.Drawing.Size(701, 20);
            this.txtEmail.TabIndex = 10;
            // 
            // FrmNovo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.grbDadosClinicos);
            this.Controls.Add(this.txtResponsavel);
            this.Controls.Add(this.lblResponsavel);
            this.Controls.Add(this.cboResponsavel);
            this.Controls.Add(this.txtCodigo);
            this.Controls.Add(this.cboNiveis);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtConfirmarSenha);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lbl);
            this.Controls.Add(this.txtSenha);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.txtTelefone);
            this.Controls.Add(this.txtCpf);
            this.Controls.Add(this.txtDataNascimento);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.chkAtivo);
            this.Controls.Add(this.radFem);
            this.Controls.Add(this.radMasc);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtEndereco);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.btnCancelar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "FrmNovo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ProntoVid EHR";
            this.Load += new System.EventHandler(this.FrmNovo_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmNovo_KeyDown);
            this.grbDadosClinicos.ResumeLayout(false);
            this.grbDadosClinicos.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnSalvar;
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
        private Telecon.Genericos.Controles.CaixaTexto txtUsuario;
        private Telecon.Genericos.Controles.CaixaTexto txtSenha;
        private System.Windows.Forms.Label lbl;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private Telecon.Genericos.Controles.CaixaTexto txtConfirmarSenha;
        private System.Windows.Forms.Label label9;
        private Telecon.Genericos.Controles.ComboBoxItemData cboNiveis;
        private Telecon.Genericos.Controles.CaixaTexto txtCodigo;
        private Telecon.Genericos.Controles.ComboBoxItemData cboResponsavel;
        private System.Windows.Forms.Label lblResponsavel;
        private System.Windows.Forms.TextBox txtResponsavel;
        private System.Windows.Forms.GroupBox grbDadosClinicos;
        private System.Windows.Forms.Label label10;
        private Telecon.Genericos.Controles.CaixaTexto txtPeso;
        private Telecon.Genericos.Controles.CaixaTexto txtEmail;
        private System.Windows.Forms.CheckBox chkGestanteAltoRisco;
        private System.Windows.Forms.CheckBox chkNeoplasiaMaligna;
        private System.Windows.Forms.CheckBox chkDoencaCromossomica;
        private System.Windows.Forms.CheckBox chkDiabetes;
        private System.Windows.Forms.CheckBox chkDoencaRenalApartirGrau3;
        private System.Windows.Forms.CheckBox chkImunoDepressao;
        private System.Windows.Forms.CheckBox chkTabagismo;
        private System.Windows.Forms.CheckBox chkPneumopatiasGraves;
        private System.Windows.Forms.CheckBox chkHipertensao;
        private System.Windows.Forms.CheckBox chkInsuficienciaCardiaca;
        private System.Windows.Forms.Label label11;
        private Telecon.Genericos.Controles.CaixaTexto txtAltura;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
    }
}

