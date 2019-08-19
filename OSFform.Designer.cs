namespace OSF
{
    partial class OSFform
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OSFform));
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonPanel = new System.Windows.Forms.Panel();
            this.btnZamestnanci = new System.Windows.Forms.Button();
            this.btnAbout = new System.Windows.Forms.Button();
            this.btnOddelenia = new System.Windows.Forms.Button();
            this.btnProjekty = new System.Windows.Forms.Button();
            this.btnDivizie = new System.Windows.Forms.Button();
            this.btnFirma = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelAbout = new System.Windows.Forms.Panel();
            this.labRok = new System.Windows.Forms.Label();
            this.labVerzia = new System.Windows.Forms.Label();
            this.labAutor = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.listUrovni = new System.Windows.Forms.ComboBox();
            this.uC_About = new OSF.UC_About();
            this.uC_Firma = new OSF.UC_Firma();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelAbout.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(61)))), ((int)(((byte)(68)))));
            this.panel1.Controls.Add(this.buttonPanel);
            this.panel1.Controls.Add(this.btnZamestnanci);
            this.panel1.Controls.Add(this.btnAbout);
            this.panel1.Controls.Add(this.btnOddelenia);
            this.panel1.Controls.Add(this.btnProjekty);
            this.panel1.Controls.Add(this.btnDivizie);
            this.panel1.Controls.Add(this.btnFirma);
            this.panel1.Controls.Add(this.btnExit);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(226, 552);
            this.panel1.TabIndex = 0;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OSFform_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.OSFform_MouseMove);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OSFform_MouseUp);
            // 
            // buttonPanel
            // 
            this.buttonPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(231)))), ((int)(((byte)(238)))));
            this.buttonPanel.Location = new System.Drawing.Point(25, 116);
            this.buttonPanel.Name = "buttonPanel";
            this.buttonPanel.Size = new System.Drawing.Size(12, 48);
            this.buttonPanel.TabIndex = 7;
            // 
            // btnZamestnanci
            // 
            this.btnZamestnanci.FlatAppearance.BorderSize = 0;
            this.btnZamestnanci.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnZamestnanci.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnZamestnanci.ForeColor = System.Drawing.Color.White;
            this.btnZamestnanci.Image = ((System.Drawing.Image)(resources.GetObject("btnZamestnanci.Image")));
            this.btnZamestnanci.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnZamestnanci.Location = new System.Drawing.Point(53, 368);
            this.btnZamestnanci.Name = "btnZamestnanci";
            this.btnZamestnanci.Size = new System.Drawing.Size(161, 48);
            this.btnZamestnanci.TabIndex = 7;
            this.btnZamestnanci.Text = "     Zamestnanci";
            this.btnZamestnanci.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnZamestnanci.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnZamestnanci.UseVisualStyleBackColor = true;
            this.btnZamestnanci.Click += new System.EventHandler(this.btnZamestnanci_Click);
            // 
            // btnAbout
            // 
            this.btnAbout.FlatAppearance.BorderSize = 0;
            this.btnAbout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAbout.Image = ((System.Drawing.Image)(resources.GetObject("btnAbout.Image")));
            this.btnAbout.Location = new System.Drawing.Point(189, 515);
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Size = new System.Drawing.Size(25, 25);
            this.btnAbout.TabIndex = 6;
            this.btnAbout.UseVisualStyleBackColor = true;
            this.btnAbout.Click += new System.EventHandler(this.btnAbout_Click);
            // 
            // btnOddelenia
            // 
            this.btnOddelenia.FlatAppearance.BorderSize = 0;
            this.btnOddelenia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOddelenia.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnOddelenia.ForeColor = System.Drawing.Color.White;
            this.btnOddelenia.Image = ((System.Drawing.Image)(resources.GetObject("btnOddelenia.Image")));
            this.btnOddelenia.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOddelenia.Location = new System.Drawing.Point(55, 305);
            this.btnOddelenia.Name = "btnOddelenia";
            this.btnOddelenia.Size = new System.Drawing.Size(151, 48);
            this.btnOddelenia.TabIndex = 4;
            this.btnOddelenia.Text = "     Oddelenia";
            this.btnOddelenia.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOddelenia.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnOddelenia.UseVisualStyleBackColor = true;
            this.btnOddelenia.Click += new System.EventHandler(this.btnOddelenia_Click);
            // 
            // btnProjekty
            // 
            this.btnProjekty.FlatAppearance.BorderSize = 0;
            this.btnProjekty.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProjekty.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnProjekty.ForeColor = System.Drawing.Color.White;
            this.btnProjekty.Image = ((System.Drawing.Image)(resources.GetObject("btnProjekty.Image")));
            this.btnProjekty.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProjekty.Location = new System.Drawing.Point(55, 242);
            this.btnProjekty.Name = "btnProjekty";
            this.btnProjekty.Size = new System.Drawing.Size(151, 48);
            this.btnProjekty.TabIndex = 3;
            this.btnProjekty.Text = "     Projekty";
            this.btnProjekty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProjekty.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnProjekty.UseVisualStyleBackColor = true;
            this.btnProjekty.Click += new System.EventHandler(this.btnProjekty_Click);
            // 
            // btnDivizie
            // 
            this.btnDivizie.FlatAppearance.BorderSize = 0;
            this.btnDivizie.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDivizie.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnDivizie.ForeColor = System.Drawing.Color.White;
            this.btnDivizie.Image = ((System.Drawing.Image)(resources.GetObject("btnDivizie.Image")));
            this.btnDivizie.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDivizie.Location = new System.Drawing.Point(55, 179);
            this.btnDivizie.Name = "btnDivizie";
            this.btnDivizie.Size = new System.Drawing.Size(151, 48);
            this.btnDivizie.TabIndex = 2;
            this.btnDivizie.Text = "     Divízie";
            this.btnDivizie.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDivizie.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDivizie.UseVisualStyleBackColor = true;
            this.btnDivizie.Click += new System.EventHandler(this.btnDivizie_Click);
            // 
            // btnFirma
            // 
            this.btnFirma.FlatAppearance.BorderSize = 0;
            this.btnFirma.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFirma.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnFirma.ForeColor = System.Drawing.Color.White;
            this.btnFirma.Image = ((System.Drawing.Image)(resources.GetObject("btnFirma.Image")));
            this.btnFirma.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFirma.Location = new System.Drawing.Point(55, 116);
            this.btnFirma.Name = "btnFirma";
            this.btnFirma.Size = new System.Drawing.Size(151, 48);
            this.btnFirma.TabIndex = 1;
            this.btnFirma.Text = "     Firma";
            this.btnFirma.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFirma.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFirma.UseVisualStyleBackColor = true;
            this.btnFirma.Click += new System.EventHandler(this.btnFirma_Click);
            // 
            // btnExit
            // 
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.Location = new System.Drawing.Point(12, 515);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(25, 25);
            this.btnExit.TabIndex = 5;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(21, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(183, 65);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panelAbout
            // 
            this.panelAbout.Controls.Add(this.labRok);
            this.panelAbout.Controls.Add(this.labVerzia);
            this.panelAbout.Controls.Add(this.labAutor);
            this.panelAbout.Controls.Add(this.label18);
            this.panelAbout.Controls.Add(this.label19);
            this.panelAbout.Controls.Add(this.label20);
            this.panelAbout.Controls.Add(this.label21);
            this.panelAbout.Location = new System.Drawing.Point(226, 59);
            this.panelAbout.Name = "panelAbout";
            this.panelAbout.Size = new System.Drawing.Size(785, 481);
            this.panelAbout.TabIndex = 30;
            this.panelAbout.Visible = false;
            // 
            // labRok
            // 
            this.labRok.AutoSize = true;
            this.labRok.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labRok.Location = new System.Drawing.Point(352, 280);
            this.labRok.Name = "labRok";
            this.labRok.Size = new System.Drawing.Size(36, 17);
            this.labRok.TabIndex = 13;
            this.labRok.Text = "2019";
            // 
            // labVerzia
            // 
            this.labVerzia.AutoSize = true;
            this.labVerzia.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labVerzia.Location = new System.Drawing.Point(352, 259);
            this.labVerzia.Name = "labVerzia";
            this.labVerzia.Size = new System.Drawing.Size(26, 17);
            this.labVerzia.TabIndex = 12;
            this.labVerzia.Text = "1.0";
            // 
            // labAutor
            // 
            this.labAutor.AutoSize = true;
            this.labAutor.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labAutor.Location = new System.Drawing.Point(352, 238);
            this.labAutor.Name = "labAutor";
            this.labAutor.Size = new System.Drawing.Size(110, 17);
            this.labAutor.TabIndex = 11;
            this.labAutor.Text = "Marek Smatana";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label18.Location = new System.Drawing.Point(304, 276);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(42, 21);
            this.label18.TabIndex = 10;
            this.label18.Text = "Rok:";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label19.Location = new System.Drawing.Point(285, 255);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(61, 21);
            this.label19.TabIndex = 9;
            this.label19.Text = "Verzia:";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label20.Location = new System.Drawing.Point(287, 234);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(59, 21);
            this.label20.TabIndex = 8;
            this.label20.Text = "Autor:";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(244, 184);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(296, 25);
            this.label21.TabIndex = 7;
            this.label21.Text = "Organizačná štruktúra firmy";
            // 
            // listUrovni
            // 
            this.listUrovni.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.listUrovni.FormattingEnabled = true;
            this.listUrovni.Location = new System.Drawing.Point(53, 453);
            this.listUrovni.Name = "listUrovni";
            this.listUrovni.Size = new System.Drawing.Size(121, 21);
            this.listUrovni.TabIndex = 2;
            // 
            // uC_About
            // 
            this.uC_About.Autor = "Marek Smatana";
            this.uC_About.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uC_About.Location = new System.Drawing.Point(226, 0);
            this.uC_About.Name = "uC_About";
            this.uC_About.Rok = "2019";
            this.uC_About.Size = new System.Drawing.Size(785, 552);
            this.uC_About.TabIndex = 1;
            this.uC_About.Verzia = "1.0";
            this.uC_About.Visible = false;
            // 
            // uC_Firma
            // 
            this.uC_Firma.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uC_Firma.Location = new System.Drawing.Point(226, 0);
            this.uC_Firma.Name = "uC_Firma";
            this.uC_Firma.Size = new System.Drawing.Size(785, 552);
            this.uC_Firma.TabIndex = 3;
            this.uC_Firma.Visible = false;
            // 
            // OSFform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1011, 552);
            this.ControlBox = false;
            this.Controls.Add(this.uC_Firma);
            this.Controls.Add(this.listUrovni);
            this.Controls.Add(this.uC_About);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "OSFform";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OSF";
            this.Load += new System.EventHandler(this.OSFform_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OSFform_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.OSFform_KeyUp);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OSFform_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.OSFform_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OSFform_MouseUp);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelAbout.ResumeLayout(false);
            this.panelAbout.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnOddelenia;
        private System.Windows.Forms.Button btnProjekty;
        private System.Windows.Forms.Button btnDivizie;
        private System.Windows.Forms.Button btnFirma;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Panel buttonPanel;
        private System.Windows.Forms.Button btnAbout;
        private System.Windows.Forms.Panel panelAbout;
        private System.Windows.Forms.Label labRok;
        private System.Windows.Forms.Label labVerzia;
        private System.Windows.Forms.Label labAutor;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Button btnZamestnanci;
        private UC_About uC_About;
        private System.Windows.Forms.ComboBox listUrovni;
        private UC_Firma uC_Firma;
    }
}

