namespace OSF {
    partial class UC_Divizie {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_Divizie));
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnZrus = new System.Windows.Forms.Button();
            this.tbNazov = new System.Windows.Forms.TextBox();
            this.cbVeduci = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnUloz = new System.Windows.Forms.Button();
            this.btnPridaj = new System.Windows.Forms.Button();
            this.lstDivizie = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lstZamestnanci = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lstNepriradeny = new System.Windows.Forms.ListBox();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(123)))), ((int)(((byte)(136)))));
            this.panel2.Controls.Add(this.btnZrus);
            this.panel2.Controls.Add(this.tbNazov);
            this.panel2.Controls.Add(this.cbVeduci);
            this.panel2.Controls.Add(this.label14);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.btnUloz);
            this.panel2.Controls.Add(this.btnPridaj);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(785, 59);
            this.panel2.TabIndex = 16;
            // 
            // btnZrus
            // 
            this.btnZrus.FlatAppearance.BorderSize = 0;
            this.btnZrus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnZrus.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnZrus.ForeColor = System.Drawing.Color.White;
            this.btnZrus.Image = ((System.Drawing.Image)(resources.GetObject("btnZrus.Image")));
            this.btnZrus.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnZrus.Location = new System.Drawing.Point(673, 5);
            this.btnZrus.Name = "btnZrus";
            this.btnZrus.Size = new System.Drawing.Size(107, 48);
            this.btnZrus.TabIndex = 2;
            this.btnZrus.Text = "     Zruš";
            this.btnZrus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnZrus.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnZrus.UseVisualStyleBackColor = true;
            this.btnZrus.Click += new System.EventHandler(this.BtnZrus_Click);
            // 
            // tbNazov
            // 
            this.tbNazov.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbNazov.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbNazov.Location = new System.Drawing.Point(79, 19);
            this.tbNazov.MaxLength = 16;
            this.tbNazov.Name = "tbNazov";
            this.tbNazov.Size = new System.Drawing.Size(100, 23);
            this.tbNazov.TabIndex = 31;
            // 
            // cbVeduci
            // 
            this.cbVeduci.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.cbVeduci.DropDownWidth = 500;
            this.cbVeduci.Enabled = false;
            this.cbVeduci.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cbVeduci.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cbVeduci.Location = new System.Drawing.Point(251, 18);
            this.cbVeduci.Name = "cbVeduci";
            this.cbVeduci.Size = new System.Drawing.Size(121, 25);
            this.cbVeduci.TabIndex = 39;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(19, 17);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(60, 21);
            this.label14.TabIndex = 28;
            this.label14.Text = "Názov";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(185, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 21);
            this.label2.TabIndex = 35;
            this.label2.Text = "Vedúci";
            // 
            // btnUloz
            // 
            this.btnUloz.FlatAppearance.BorderSize = 0;
            this.btnUloz.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUloz.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnUloz.ForeColor = System.Drawing.Color.White;
            this.btnUloz.Image = ((System.Drawing.Image)(resources.GetObject("btnUloz.Image")));
            this.btnUloz.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUloz.Location = new System.Drawing.Point(553, 5);
            this.btnUloz.Name = "btnUloz";
            this.btnUloz.Size = new System.Drawing.Size(107, 48);
            this.btnUloz.TabIndex = 32;
            this.btnUloz.Text = "     Ulož";
            this.btnUloz.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUloz.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnUloz.UseVisualStyleBackColor = true;
            this.btnUloz.Click += new System.EventHandler(this.BtnUlozit_Click);
            // 
            // btnPridaj
            // 
            this.btnPridaj.FlatAppearance.BorderSize = 0;
            this.btnPridaj.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPridaj.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnPridaj.ForeColor = System.Drawing.Color.White;
            this.btnPridaj.Image = ((System.Drawing.Image)(resources.GetObject("btnPridaj.Image")));
            this.btnPridaj.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPridaj.Location = new System.Drawing.Point(433, 5);
            this.btnPridaj.Name = "btnPridaj";
            this.btnPridaj.Size = new System.Drawing.Size(107, 48);
            this.btnPridaj.TabIndex = 33;
            this.btnPridaj.Text = "     Pridaj";
            this.btnPridaj.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPridaj.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPridaj.UseVisualStyleBackColor = true;
            this.btnPridaj.Click += new System.EventHandler(this.BtnPridat_Click);
            // 
            // lstDivizie
            // 
            this.lstDivizie.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lstDivizie.FormattingEnabled = true;
            this.lstDivizie.HorizontalScrollbar = true;
            this.lstDivizie.ItemHeight = 17;
            this.lstDivizie.Location = new System.Drawing.Point(79, 196);
            this.lstDivizie.Name = "lstDivizie";
            this.lstDivizie.Size = new System.Drawing.Size(145, 208);
            this.lstDivizie.TabIndex = 30;
            this.lstDivizie.SelectedIndexChanged += new System.EventHandler(this.LstDivizie_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(75, 172);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 21);
            this.label1.TabIndex = 34;
            this.label1.Text = "Divízie";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(252, 172);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 21);
            this.label3.TabIndex = 37;
            this.label3.Text = "Zamestnanci";
            // 
            // lstZamestnanci
            // 
            this.lstZamestnanci.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lstZamestnanci.FormattingEnabled = true;
            this.lstZamestnanci.HorizontalScrollbar = true;
            this.lstZamestnanci.ItemHeight = 17;
            this.lstZamestnanci.Location = new System.Drawing.Point(256, 196);
            this.lstZamestnanci.Name = "lstZamestnanci";
            this.lstZamestnanci.Size = new System.Drawing.Size(204, 208);
            this.lstZamestnanci.TabIndex = 38;
            this.lstZamestnanci.SelectedIndexChanged += new System.EventHandler(this.LstZamestnanci_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.Location = new System.Drawing.Point(494, 172);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 21);
            this.label5.TabIndex = 43;
            this.label5.Text = "Nepriradený";
            // 
            // lstNepriradeny
            // 
            this.lstNepriradeny.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lstNepriradeny.FormattingEnabled = true;
            this.lstNepriradeny.HorizontalScrollbar = true;
            this.lstNepriradeny.ItemHeight = 17;
            this.lstNepriradeny.Location = new System.Drawing.Point(498, 196);
            this.lstNepriradeny.Name = "lstNepriradeny";
            this.lstNepriradeny.Size = new System.Drawing.Size(204, 208);
            this.lstNepriradeny.TabIndex = 44;
            this.lstNepriradeny.SelectedIndexChanged += new System.EventHandler(this.LstNepriradeny_SelectedIndexChanged);
            // 
            // UC_Divizie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lstNepriradeny);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lstZamestnanci);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lstDivizie);
            this.Controls.Add(this.panel2);
            this.Name = "UC_Divizie";
            this.Size = new System.Drawing.Size(785, 552);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnZrus;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ListBox lstDivizie;
        private System.Windows.Forms.TextBox tbNazov;
        private System.Windows.Forms.Button btnPridaj;
        private System.Windows.Forms.Button btnUloz;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox lstZamestnanci;
        private System.Windows.Forms.ComboBox cbVeduci;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox lstNepriradeny;
    }
}
