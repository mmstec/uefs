using System;

namespace Genius
{
    partial class frmGenius
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGenius));
            this.lblComprimento = new System.Windows.Forms.Label();
            this.lblCds = new System.Windows.Forms.Label();
            this.tmrCores = new System.Windows.Forms.Timer(this.components);
            this.gbNivel = new System.Windows.Forms.GroupBox();
            this.btnJogar = new System.Windows.Forms.Button();
            this.rbExpert = new System.Windows.Forms.RadioButton();
            this.rbDificil = new System.Windows.Forms.RadioButton();
            this.rbMedio = new System.Windows.Forms.RadioButton();
            this.rbFacil = new System.Windows.Forms.RadioButton();
            this.pbVermelho = new System.Windows.Forms.PictureBox();
            this.pbVerde = new System.Windows.Forms.PictureBox();
            this.pbAzul = new System.Windows.Forms.PictureBox();
            this.pbAmarelo = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.iniciarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sobreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.sairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.relatórioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelPontos = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelSegundos = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabeMilliseconds = new System.Windows.Forms.ToolStripStatusLabel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tmrCronometro = new System.Windows.Forms.Timer(this.components);
            this.tmrLabels = new System.Windows.Forms.Timer(this.components);
            this.iniciarUsabilidadeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gbNivel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbVermelho)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbVerde)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAzul)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAmarelo)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblComprimento
            // 
            this.lblComprimento.AutoSize = true;
            this.lblComprimento.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblComprimento.ForeColor = System.Drawing.Color.White;
            this.lblComprimento.Location = new System.Drawing.Point(216, 9);
            this.lblComprimento.Name = "lblComprimento";
            this.lblComprimento.Size = new System.Drawing.Size(16, 16);
            this.lblComprimento.TabIndex = 11;
            this.lblComprimento.Text = "0";
            // 
            // lblCds
            // 
            this.lblCds.AutoSize = true;
            this.lblCds.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCds.ForeColor = System.Drawing.Color.White;
            this.lblCds.Location = new System.Drawing.Point(9, 9);
            this.lblCds.Name = "lblCds";
            this.lblCds.Size = new System.Drawing.Size(201, 16);
            this.lblCds.TabIndex = 10;
            this.lblCds.Text = "Comprimento da sequência:";
            // 
            // tmrCores
            // 
            this.tmrCores.Interval = 1000;
            this.tmrCores.Tick += new System.EventHandler(this.sortearCor);
            // 
            // gbNivel
            // 
            this.gbNivel.BackColor = System.Drawing.Color.Transparent;
            this.gbNivel.Controls.Add(this.btnJogar);
            this.gbNivel.Controls.Add(this.rbExpert);
            this.gbNivel.Controls.Add(this.rbDificil);
            this.gbNivel.Controls.Add(this.rbMedio);
            this.gbNivel.Controls.Add(this.rbFacil);
            this.gbNivel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gbNivel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbNivel.ForeColor = System.Drawing.Color.Black;
            this.gbNivel.Location = new System.Drawing.Point(0, 3);
            this.gbNivel.Name = "gbNivel";
            this.gbNivel.Size = new System.Drawing.Size(366, 51);
            this.gbNivel.TabIndex = 16;
            this.gbNivel.TabStop = false;
            this.gbNivel.Text = "Nível de Habilidade";
            // 
            // btnJogar
            // 
            this.btnJogar.BackColor = System.Drawing.Color.Lime;
            this.btnJogar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnJogar.ForeColor = System.Drawing.Color.Black;
            this.btnJogar.Image = global::Genius.Properties.Resources.bgDireita;
            this.btnJogar.Location = new System.Drawing.Point(266, 12);
            this.btnJogar.Name = "btnJogar";
            this.btnJogar.Size = new System.Drawing.Size(95, 33);
            this.btnJogar.TabIndex = 21;
            this.btnJogar.Text = "J&ogar";
            this.btnJogar.UseVisualStyleBackColor = false;
            this.btnJogar.Click += new System.EventHandler(this.Jogar);
            // 
            // rbExpert
            // 
            this.rbExpert.AutoSize = true;
            this.rbExpert.ForeColor = System.Drawing.Color.Black;
            this.rbExpert.Location = new System.Drawing.Point(186, 19);
            this.rbExpert.Name = "rbExpert";
            this.rbExpert.Size = new System.Drawing.Size(75, 17);
            this.rbExpert.TabIndex = 3;
            this.rbExpert.Text = "Avançado";
            this.rbExpert.UseVisualStyleBackColor = true;
            // 
            // rbDificil
            // 
            this.rbDificil.AutoSize = true;
            this.rbDificil.ForeColor = System.Drawing.Color.Black;
            this.rbDificil.Location = new System.Drawing.Point(124, 19);
            this.rbDificil.Name = "rbDificil";
            this.rbDificil.Size = new System.Drawing.Size(54, 17);
            this.rbDificil.TabIndex = 2;
            this.rbDificil.Text = "Difícil";
            this.rbDificil.UseVisualStyleBackColor = true;
            // 
            // rbMedio
            // 
            this.rbMedio.AutoSize = true;
            this.rbMedio.ForeColor = System.Drawing.Color.Black;
            this.rbMedio.Location = new System.Drawing.Point(60, 19);
            this.rbMedio.Name = "rbMedio";
            this.rbMedio.Size = new System.Drawing.Size(58, 17);
            this.rbMedio.TabIndex = 1;
            this.rbMedio.Text = "Médio";
            this.rbMedio.UseVisualStyleBackColor = true;
            // 
            // rbFacil
            // 
            this.rbFacil.AutoSize = true;
            this.rbFacil.Checked = true;
            this.rbFacil.ForeColor = System.Drawing.Color.Black;
            this.rbFacil.Location = new System.Drawing.Point(6, 19);
            this.rbFacil.Name = "rbFacil";
            this.rbFacil.Size = new System.Drawing.Size(48, 17);
            this.rbFacil.TabIndex = 0;
            this.rbFacil.TabStop = true;
            this.rbFacil.Text = "Fácil";
            this.rbFacil.UseVisualStyleBackColor = true;
            // 
            // pbVermelho
            // 
            this.pbVermelho.Enabled = false;
            this.pbVermelho.Image = global::Genius.Properties.Resources.vermelho;
            this.pbVermelho.Location = new System.Drawing.Point(260, 54);
            this.pbVermelho.Name = "pbVermelho";
            this.pbVermelho.Size = new System.Drawing.Size(260, 169);
            this.pbVermelho.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbVermelho.TabIndex = 15;
            this.pbVermelho.TabStop = false;
            this.pbVermelho.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbVermelho_MouseDown);
            this.pbVermelho.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pbVermelho_MouseUp);
            // 
            // pbVerde
            // 
            this.pbVerde.Enabled = false;
            this.pbVerde.Image = global::Genius.Properties.Resources.verde;
            this.pbVerde.Location = new System.Drawing.Point(0, 54);
            this.pbVerde.Name = "pbVerde";
            this.pbVerde.Size = new System.Drawing.Size(260, 169);
            this.pbVerde.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbVerde.TabIndex = 14;
            this.pbVerde.TabStop = false;
            this.pbVerde.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbVerde_MouseDown);
            this.pbVerde.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pbVerde_MouseUp);
            // 
            // pbAzul
            // 
            this.pbAzul.BackColor = System.Drawing.Color.Transparent;
            this.pbAzul.Enabled = false;
            this.pbAzul.Image = global::Genius.Properties.Resources.azul;
            this.pbAzul.Location = new System.Drawing.Point(260, 222);
            this.pbAzul.Name = "pbAzul";
            this.pbAzul.Size = new System.Drawing.Size(260, 169);
            this.pbAzul.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbAzul.TabIndex = 13;
            this.pbAzul.TabStop = false;
            this.pbAzul.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbAzul_MouseDown);
            this.pbAzul.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pbAzul_MouseUp);
            // 
            // pbAmarelo
            // 
            this.pbAmarelo.Enabled = false;
            this.pbAmarelo.Image = global::Genius.Properties.Resources.amarelo;
            this.pbAmarelo.Location = new System.Drawing.Point(0, 222);
            this.pbAmarelo.Name = "pbAmarelo";
            this.pbAmarelo.Size = new System.Drawing.Size(260, 169);
            this.pbAmarelo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbAmarelo.TabIndex = 12;
            this.pbAmarelo.TabStop = false;
            this.pbAmarelo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbAmarelo_MouseDown);
            this.pbAmarelo.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pbAmarelo_MouseUp);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.relatórioToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(559, 24);
            this.menuStrip1.TabIndex = 30;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.iniciarToolStripMenuItem,
            this.sobreToolStripMenuItem,
            this.toolStripSeparator1,
            this.sairToolStripMenuItem});
            this.toolStripMenuItem1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(51, 20);
            this.toolStripMenuItem1.Text = "&Iniciar";
            // 
            // iniciarToolStripMenuItem
            // 
            this.iniciarToolStripMenuItem.Image = global::Genius.Properties.Resources.button_green;
            this.iniciarToolStripMenuItem.Name = "iniciarToolStripMenuItem";
            this.iniciarToolStripMenuItem.Size = new System.Drawing.Size(104, 22);
            this.iniciarToolStripMenuItem.Text = "Jogar";
            this.iniciarToolStripMenuItem.Click += new System.EventHandler(this.meuMenu);
            // 
            // sobreToolStripMenuItem
            // 
            this.sobreToolStripMenuItem.Image = global::Genius.Properties.Resources.question;
            this.sobreToolStripMenuItem.Name = "sobreToolStripMenuItem";
            this.sobreToolStripMenuItem.Size = new System.Drawing.Size(104, 22);
            this.sobreToolStripMenuItem.Text = "Sobre";
            this.sobreToolStripMenuItem.Click += new System.EventHandler(this.meuMenu);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(101, 6);
            // 
            // sairToolStripMenuItem
            // 
            this.sairToolStripMenuItem.Image = global::Genius.Properties.Resources.alert;
            this.sairToolStripMenuItem.Name = "sairToolStripMenuItem";
            this.sairToolStripMenuItem.Size = new System.Drawing.Size(104, 22);
            this.sairToolStripMenuItem.Text = "Sair";
            this.sairToolStripMenuItem.Click += new System.EventHandler(this.meuMenu);
            // 
            // relatórioToolStripMenuItem
            // 
            this.relatórioToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.iniciarUsabilidadeToolStripMenuItem});
            this.relatórioToolStripMenuItem.Name = "relatórioToolStripMenuItem";
            this.relatórioToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.relatórioToolStripMenuItem.Text = "Extras";
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackgroundImage = global::Genius.Properties.Resources.menu;
            this.statusStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabelPontos,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabelSegundos,
            this.toolStripStatusLabeMilliseconds});
            this.statusStrip1.Location = new System.Drawing.Point(0, 419);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.statusStrip1.Size = new System.Drawing.Size(559, 22);
            this.statusStrip1.Stretch = false;
            this.statusStrip1.TabIndex = 31;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.ForeColor = System.Drawing.Color.DarkCyan;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(47, 17);
            this.toolStripStatusLabel1.Text = "Pontos:";
            this.toolStripStatusLabel1.ToolTipText = "Pontuação";
            // 
            // toolStripStatusLabelPontos
            // 
            this.toolStripStatusLabelPontos.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripStatusLabelPontos.ForeColor = System.Drawing.Color.DarkCyan;
            this.toolStripStatusLabelPontos.Name = "toolStripStatusLabelPontos";
            this.toolStripStatusLabelPontos.Size = new System.Drawing.Size(49, 17);
            this.toolStripStatusLabelPontos.Text = "000000";
            this.toolStripStatusLabelPontos.ToolTipText = "Pontuação";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.ForeColor = System.Drawing.Color.DarkCyan;
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(404, 17);
            this.toolStripStatusLabel2.Spring = true;
            this.toolStripStatusLabel2.Text = "Tempo:";
            this.toolStripStatusLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolStripStatusLabel2.ToolTipText = "Tempo";
            // 
            // toolStripStatusLabelSegundos
            // 
            this.toolStripStatusLabelSegundos.ForeColor = System.Drawing.Color.DarkCyan;
            this.toolStripStatusLabelSegundos.Name = "toolStripStatusLabelSegundos";
            this.toolStripStatusLabelSegundos.Size = new System.Drawing.Size(19, 17);
            this.toolStripStatusLabelSegundos.Text = "00";
            this.toolStripStatusLabelSegundos.ToolTipText = "Segundos";
            // 
            // toolStripStatusLabeMilliseconds
            // 
            this.toolStripStatusLabeMilliseconds.ForeColor = System.Drawing.Color.DarkCyan;
            this.toolStripStatusLabeMilliseconds.Name = "toolStripStatusLabeMilliseconds";
            this.toolStripStatusLabeMilliseconds.Size = new System.Drawing.Size(25, 17);
            this.toolStripStatusLabeMilliseconds.Text = "000";
            this.toolStripStatusLabeMilliseconds.ToolTipText = "Milisegundos";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.panel4, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 24);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(559, 395);
            this.tableLayoutPanel1.TabIndex = 32;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Transparent;
            this.panel4.BackgroundImage = global::Genius.Properties.Resources.bgEsquerda1;
            this.panel4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Margin = new System.Windows.Forms.Padding(0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(20, 395);
            this.panel4.TabIndex = 4;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.BackgroundImage = global::Genius.Properties.Resources.bgDireita1;
            this.panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(539, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(20, 395);
            this.panel3.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackgroundImage = global::Genius.Properties.Resources.bgCentro;
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.gbNivel);
            this.panel2.Controls.Add(this.pbVermelho);
            this.panel2.Controls.Add(this.pbAmarelo);
            this.panel2.Controls.Add(this.pbAzul);
            this.panel2.Controls.Add(this.pbVerde);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(20, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(519, 395);
            this.panel2.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Enabled = false;
            this.pictureBox1.Image = global::Genius.Properties.Resources.icone;
            this.pictureBox1.Location = new System.Drawing.Point(-20, 54);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(540, 337);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 17;
            this.pictureBox1.TabStop = false;
            // 
            // tmrCronometro
            // 
            this.tmrCronometro.Interval = 1;
            this.tmrCronometro.Tick += new System.EventHandler(this.timerCronometro);
            // 
            // tmrLabels
            // 
            this.tmrLabels.Interval = 1;
            this.tmrLabels.Tick += new System.EventHandler(this.timerPlacar);
            // 
            // iniciarUsabilidadeToolStripMenuItem
            // 
            this.iniciarUsabilidadeToolStripMenuItem.Name = "iniciarUsabilidadeToolStripMenuItem";
            this.iniciarUsabilidadeToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.iniciarUsabilidadeToolStripMenuItem.Text = "Iniciar Usabilidade";
            this.iniciarUsabilidadeToolStripMenuItem.Click += new System.EventHandler(this.iniciarUsabilidadeToolStripMenuItem_Click);
            // 
            // frmGenius
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(559, 441);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.lblComprimento);
            this.Controls.Add(this.lblCds);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmGenius";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GENIUS G4H (protótipo)";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmGenius_FormClosed);
            this.Load += new System.EventHandler(this.frmGenius_Load);
            this.gbNivel.ResumeLayout(false);
            this.gbNivel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbVermelho)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbVerde)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAzul)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAmarelo)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            if (rbFacil.Checked == true)
            {
                cores = new int[8];
            }
            else if (rbMedio.Checked == true)
            {
                cores = new int[14];
            }
            else if (rbDificil.Checked == true)
            {
                cores = new int[20];
            }
            else if (rbExpert.Checked == true)
            {
                cores = new int[31];
            }
            gbNivel.Enabled = false;
            //btnIniciar.Enabled = false;
            novoJogo();
        }

        #endregion

        private System.Windows.Forms.PictureBox pbVermelho;
        private System.Windows.Forms.PictureBox pbVerde;
        private System.Windows.Forms.PictureBox pbAzul;
        private System.Windows.Forms.PictureBox pbAmarelo;
        private System.Windows.Forms.Label lblComprimento;
        private System.Windows.Forms.Label lblCds;
        private System.Windows.Forms.Timer tmrCores;
        private System.Windows.Forms.GroupBox gbNivel;
        private System.Windows.Forms.RadioButton rbExpert;
        private System.Windows.Forms.RadioButton rbDificil;
        private System.Windows.Forms.RadioButton rbMedio;
        private System.Windows.Forms.RadioButton rbFacil;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem iniciarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sobreToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sairToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnJogar;
        private System.Windows.Forms.Timer tmrCronometro;
        private System.Windows.Forms.Timer tmrLabels;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelPontos;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelSegundos;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabeMilliseconds;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripMenuItem relatórioToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem iniciarUsabilidadeToolStripMenuItem;
    }
}

