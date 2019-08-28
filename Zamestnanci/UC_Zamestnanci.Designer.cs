namespace OSF.Zamestnanci {
    partial class UC_Zamestnanci {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_Zamestnanci));
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnPridel = new System.Windows.Forms.Button();
            this.btnVyhod = new System.Windows.Forms.Button();
            this.btnUloz = new System.Windows.Forms.Button();
            this.btnPridaj = new System.Windows.Forms.Button();
            this.lstNepriradeny = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lstZamestnanci = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbTelefon = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbMail = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbPriezvisko = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbMeno = new System.Windows.Forms.TextBox();
            this.lbTitul = new System.Windows.Forms.Label();
            this.tbTitul = new System.Windows.Forms.TextBox();
            this.panelPraca = new System.Windows.Forms.Panel();
            this.lstPracoviska = new System.Windows.Forms.ListBox();
            this.rbOddelenie = new System.Windows.Forms.RadioButton();
            this.rbProjekt = new System.Windows.Forms.RadioButton();
            this.rbDivizia = new System.Windows.Forms.RadioButton();
            this.rbFirma = new System.Windows.Forms.RadioButton();
            this.ttPridel = new System.Windows.Forms.ToolTip(this.components);
            this.panel2.SuspendLayout();
            this.panelPraca.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(123)))), ((int)(((byte)(136)))));
            this.panel2.Controls.Add(this.btnPridel);
            this.panel2.Controls.Add(this.btnVyhod);
            this.panel2.Controls.Add(this.btnUloz);
            this.panel2.Controls.Add(this.btnPridaj);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(785, 59);
            this.panel2.TabIndex = 16;
            // 
            // btnPridel
            // 
            this.btnPridel.FlatAppearance.BorderSize = 0;
            this.btnPridel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPridel.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnPridel.ForeColor = System.Drawing.Color.White;
            this.btnPridel.Image = ((System.Drawing.Image)(resources.GetObject("btnPridel.Image")));
            this.btnPridel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPridel.Location = new System.Drawing.Point(165, 3);
            this.btnPridel.Name = "btnPridel";
            this.btnPridel.Size = new System.Drawing.Size(107, 48);
            this.btnPridel.TabIndex = 48;
            this.btnPridel.Text = "     Pridel";
            this.btnPridel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPridel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPridel.UseVisualStyleBackColor = true;
            this.btnPridel.Click += new System.EventHandler(this.BtnPridel_Click);
            // 
            // btnVyhod
            // 
            this.btnVyhod.FlatAppearance.BorderSize = 0;
            this.btnVyhod.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVyhod.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnVyhod.ForeColor = System.Drawing.Color.White;
            this.btnVyhod.Image = ((System.Drawing.Image)(resources.GetObject("btnVyhod.Image")));
            this.btnVyhod.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVyhod.Location = new System.Drawing.Point(516, 3);
            this.btnVyhod.Name = "btnVyhod";
            this.btnVyhod.Size = new System.Drawing.Size(114, 48);
            this.btnVyhod.TabIndex = 45;
            this.btnVyhod.Text = "     Vyhoď";
            this.btnVyhod.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVyhod.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnVyhod.UseVisualStyleBackColor = true;
            this.btnVyhod.Click += new System.EventHandler(this.BtnVyhod_Click);
            // 
            // btnUloz
            // 
            this.btnUloz.FlatAppearance.BorderSize = 0;
            this.btnUloz.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUloz.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnUloz.ForeColor = System.Drawing.Color.White;
            this.btnUloz.Image = ((System.Drawing.Image)(resources.GetObject("btnUloz.Image")));
            this.btnUloz.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUloz.Location = new System.Drawing.Point(399, 3);
            this.btnUloz.Name = "btnUloz";
            this.btnUloz.Size = new System.Drawing.Size(107, 48);
            this.btnUloz.TabIndex = 46;
            this.btnUloz.Text = "     Ulož";
            this.btnUloz.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUloz.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnUloz.UseVisualStyleBackColor = true;
            this.btnUloz.Click += new System.EventHandler(this.BtnUloz_Click);
            // 
            // btnPridaj
            // 
            this.btnPridaj.FlatAppearance.BorderSize = 0;
            this.btnPridaj.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPridaj.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnPridaj.ForeColor = System.Drawing.Color.White;
            this.btnPridaj.Image = ((System.Drawing.Image)(resources.GetObject("btnPridaj.Image")));
            this.btnPridaj.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPridaj.Location = new System.Drawing.Point(282, 3);
            this.btnPridaj.Name = "btnPridaj";
            this.btnPridaj.Size = new System.Drawing.Size(107, 48);
            this.btnPridaj.TabIndex = 47;
            this.btnPridaj.Text = "     Pridaj";
            this.btnPridaj.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPridaj.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPridaj.UseVisualStyleBackColor = true;
            this.btnPridaj.Click += new System.EventHandler(this.BtnPridaj_Click);
            // 
            // lstNepriradeny
            // 
            this.lstNepriradeny.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lstNepriradeny.FormattingEnabled = true;
            this.lstNepriradeny.HorizontalScrollbar = true;
            this.lstNepriradeny.ItemHeight = 17;
            this.lstNepriradeny.Location = new System.Drawing.Point(543, 190);
            this.lstNepriradeny.Name = "lstNepriradeny";
            this.lstNepriradeny.Size = new System.Drawing.Size(204, 208);
            this.lstNepriradeny.TabIndex = 56;
            this.lstNepriradeny.SelectedIndexChanged += new System.EventHandler(this.LstNepriradeny_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.Location = new System.Drawing.Point(539, 166);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 21);
            this.label5.TabIndex = 55;
            this.label5.Text = "Nepriradený";
            // 
            // lstZamestnanci
            // 
            this.lstZamestnanci.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lstZamestnanci.FormattingEnabled = true;
            this.lstZamestnanci.HorizontalScrollbar = true;
            this.lstZamestnanci.ItemHeight = 17;
            this.lstZamestnanci.Location = new System.Drawing.Point(38, 190);
            this.lstZamestnanci.Name = "lstZamestnanci";
            this.lstZamestnanci.Size = new System.Drawing.Size(204, 208);
            this.lstZamestnanci.TabIndex = 54;
            this.lstZamestnanci.SelectedIndexChanged += new System.EventHandler(this.LstZamestnanci_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(34, 166);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 21);
            this.label3.TabIndex = 53;
            this.label3.Text = "Zamestnanci";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(297, 322);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 21);
            this.label4.TabIndex = 66;
            this.label4.Text = "Telefon";
            // 
            // tbTelefon
            // 
            this.tbTelefon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbTelefon.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbTelefon.Location = new System.Drawing.Point(395, 324);
            this.tbTelefon.MaxLength = 10;
            this.tbTelefon.Name = "tbTelefon";
            this.tbTelefon.Size = new System.Drawing.Size(100, 23);
            this.tbTelefon.TabIndex = 65;
            this.tbTelefon.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TbTelefon_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(309, 293);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 21);
            this.label1.TabIndex = 64;
            this.label1.Text = "Mail";
            // 
            // tbMail
            // 
            this.tbMail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbMail.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbMail.Location = new System.Drawing.Point(395, 295);
            this.tbMail.MaxLength = 30;
            this.tbMail.Name = "tbMail";
            this.tbMail.Size = new System.Drawing.Size(100, 23);
            this.tbMail.TabIndex = 63;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(290, 264);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 21);
            this.label2.TabIndex = 62;
            this.label2.Text = "Priezvisko";
            // 
            // tbPriezvisko
            // 
            this.tbPriezvisko.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbPriezvisko.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbPriezvisko.Location = new System.Drawing.Point(395, 266);
            this.tbPriezvisko.MaxLength = 20;
            this.tbPriezvisko.Name = "tbPriezvisko";
            this.tbPriezvisko.Size = new System.Drawing.Size(100, 23);
            this.tbPriezvisko.TabIndex = 61;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label6.Location = new System.Drawing.Point(303, 235);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 21);
            this.label6.TabIndex = 60;
            this.label6.Text = "Meno";
            // 
            // tbMeno
            // 
            this.tbMeno.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbMeno.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbMeno.Location = new System.Drawing.Point(395, 237);
            this.tbMeno.MaxLength = 20;
            this.tbMeno.Name = "tbMeno";
            this.tbMeno.Size = new System.Drawing.Size(100, 23);
            this.tbMeno.TabIndex = 59;
            // 
            // lbTitul
            // 
            this.lbTitul.AutoSize = true;
            this.lbTitul.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbTitul.Location = new System.Drawing.Point(310, 206);
            this.lbTitul.Name = "lbTitul";
            this.lbTitul.Size = new System.Drawing.Size(41, 21);
            this.lbTitul.TabIndex = 58;
            this.lbTitul.Text = "Titul";
            // 
            // tbTitul
            // 
            this.tbTitul.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbTitul.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbTitul.Location = new System.Drawing.Point(395, 208);
            this.tbTitul.MaxLength = 10;
            this.tbTitul.Name = "tbTitul";
            this.tbTitul.Size = new System.Drawing.Size(100, 23);
            this.tbTitul.TabIndex = 57;
            // 
            // panelPraca
            // 
            this.panelPraca.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(123)))), ((int)(((byte)(136)))));
            this.panelPraca.Controls.Add(this.lstPracoviska);
            this.panelPraca.Controls.Add(this.rbOddelenie);
            this.panelPraca.Controls.Add(this.rbProjekt);
            this.panelPraca.Controls.Add(this.rbDivizia);
            this.panelPraca.Controls.Add(this.rbFirma);
            this.panelPraca.Location = new System.Drawing.Point(248, 181);
            this.panelPraca.Name = "panelPraca";
            this.panelPraca.Size = new System.Drawing.Size(289, 222);
            this.panelPraca.TabIndex = 68;
            this.panelPraca.Visible = false;
            // 
            // lstPracoviska
            // 
            this.lstPracoviska.FormattingEnabled = true;
            this.lstPracoviska.Location = new System.Drawing.Point(147, 23);
            this.lstPracoviska.Name = "lstPracoviska";
            this.lstPracoviska.Size = new System.Drawing.Size(128, 173);
            this.lstPracoviska.TabIndex = 4;
            // 
            // rbOddelenie
            // 
            this.rbOddelenie.AutoSize = true;
            this.rbOddelenie.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.rbOddelenie.ForeColor = System.Drawing.Color.White;
            this.rbOddelenie.Location = new System.Drawing.Point(10, 178);
            this.rbOddelenie.Name = "rbOddelenie";
            this.rbOddelenie.Size = new System.Drawing.Size(93, 21);
            this.rbOddelenie.TabIndex = 3;
            this.rbOddelenie.TabStop = true;
            this.rbOddelenie.Text = "Oddelenie";
            this.rbOddelenie.UseVisualStyleBackColor = true;
            this.rbOddelenie.CheckedChanged += new System.EventHandler(this.RbOddelenie_CheckedChanged);
            // 
            // rbProjekt
            // 
            this.rbProjekt.AutoSize = true;
            this.rbProjekt.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.rbProjekt.ForeColor = System.Drawing.Color.White;
            this.rbProjekt.Location = new System.Drawing.Point(10, 126);
            this.rbProjekt.Name = "rbProjekt";
            this.rbProjekt.Size = new System.Drawing.Size(70, 21);
            this.rbProjekt.TabIndex = 2;
            this.rbProjekt.TabStop = true;
            this.rbProjekt.Text = "Projekt";
            this.rbProjekt.UseVisualStyleBackColor = true;
            this.rbProjekt.CheckedChanged += new System.EventHandler(this.RbProjekt_CheckedChanged);
            // 
            // rbDivizia
            // 
            this.rbDivizia.AutoSize = true;
            this.rbDivizia.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.rbDivizia.ForeColor = System.Drawing.Color.White;
            this.rbDivizia.Location = new System.Drawing.Point(10, 74);
            this.rbDivizia.Name = "rbDivizia";
            this.rbDivizia.Size = new System.Drawing.Size(68, 21);
            this.rbDivizia.TabIndex = 1;
            this.rbDivizia.TabStop = true;
            this.rbDivizia.Text = "Divízia";
            this.rbDivizia.UseVisualStyleBackColor = true;
            this.rbDivizia.CheckedChanged += new System.EventHandler(this.RbDivizia_CheckedChanged);
            // 
            // rbFirma
            // 
            this.rbFirma.AutoSize = true;
            this.rbFirma.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.rbFirma.ForeColor = System.Drawing.Color.White;
            this.rbFirma.Location = new System.Drawing.Point(10, 22);
            this.rbFirma.Name = "rbFirma";
            this.rbFirma.Size = new System.Drawing.Size(61, 21);
            this.rbFirma.TabIndex = 0;
            this.rbFirma.TabStop = true;
            this.rbFirma.Text = "Firma";
            this.rbFirma.UseVisualStyleBackColor = true;
            this.rbFirma.CheckedChanged += new System.EventHandler(this.RbFirma_CheckedChanged);
            // 
            // UC_Zamestnanci
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelPraca);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbTelefon);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbMail);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbPriezvisko);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tbMeno);
            this.Controls.Add(this.lbTitul);
            this.Controls.Add(this.tbTitul);
            this.Controls.Add(this.lstNepriradeny);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lstZamestnanci);
            this.Controls.Add(this.label3);
            this.Name = "UC_Zamestnanci";
            this.Size = new System.Drawing.Size(785, 552);
            this.panel2.ResumeLayout(false);
            this.panelPraca.ResumeLayout(false);
            this.panelPraca.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ListBox lstNepriradeny;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox lstZamestnanci;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnVyhod;
        private System.Windows.Forms.Button btnUloz;
        private System.Windows.Forms.Button btnPridaj;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbTelefon;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbMail;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbPriezvisko;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbMeno;
        private System.Windows.Forms.Label lbTitul;
        private System.Windows.Forms.TextBox tbTitul;
        private System.Windows.Forms.Button btnPridel;
        private System.Windows.Forms.Panel panelPraca;
        private System.Windows.Forms.RadioButton rbFirma;
        private System.Windows.Forms.ListBox lstPracoviska;
        private System.Windows.Forms.RadioButton rbOddelenie;
        private System.Windows.Forms.RadioButton rbProjekt;
        private System.Windows.Forms.RadioButton rbDivizia;
        private System.Windows.Forms.ToolTip ttPridel;
    }
}
