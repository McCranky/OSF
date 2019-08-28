using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OSF {
    public partial class OSFform : Form {
        private bool moveForm = false;
        private Point movePoint;
        private UserControl currentUC;

        public OSFform() {
            InitializeComponent();
            initUC_About();
            ttExit.SetToolTip(btnExit, "Ukončenie aplikácie");
            ttAbout.SetToolTip(btnAbout, "Základne informácie");
            uC_Divizie.zmenaDivizie += zmenaTextuDivizie;
            uC_Projekty.zmenaProjektu += zmenaTextuProjektu;
            uC_Oddelenia.zmenaOddelenia += zmenaTextuOddelenia;
            changeUC(uC_Firma);
        }
        private void zmenaTextuDivizie(string nazov) {
            lbDivizia.Text = "[" + nazov + "]";
        }
        private void zmenaTextuProjektu(string nazov) {
            lbProjekt.Text = "[" + nazov + "]"; ;
        }
        private void zmenaTextuOddelenia(string nazov) {
            lbOddelenie.Text = "[" + nazov + "]"; ;
        }
        private void initUC_About() {
            uC_About.Autor = Constants.AUTOR;
            uC_About.Verzia = Constants.VERZIA;
            uC_About.Rok = Constants.ROK;
        }

        private void OSFform_MouseDown(object sender, MouseEventArgs e) {
            moveForm = true;
            movePoint = e.Location;
            
        }

        private void OSFform_MouseMove(object sender, MouseEventArgs e) {
            if (moveForm) {
                this.Location = new Point((this.Location.X - movePoint.X) + e.X,
                                          (this.Location.Y - movePoint.Y) + e.Y);
                this.Update();
            }
        }

        private void OSFform_MouseUp(object sender, MouseEventArgs e) {
            moveForm = false;
        }

        private void OSFform_KeyUp(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Escape) {
                this.Close();
            }
        }

        private void OSFform_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Escape) {
                this.Close();
            }
        }

        private void btnExit_Click(object sender, EventArgs e) {
            //this.Close();
            Application.Exit();
        }

        private void btnFirma_Click(object sender, EventArgs e) {
            buttonPanel.Height = btnFirma.Height;
            buttonPanel.Top = btnFirma.Top;
            buttonPanel.Left = btnFirma.Left - buttonPanel.Width;
            uC_Firma.update();
            changeUC(uC_Firma);

        }

        private void btnDivizie_Click(object sender, EventArgs e) {
            if (!Preferences.IsFirma) {
                MessageBox.Show("Najprv založte firmu.", "Upozornenie");
                return;
            }
            buttonPanel.Height = btnDivizie.Height;
            buttonPanel.Top = btnDivizie.Top;
            buttonPanel.Left = btnDivizie.Left - buttonPanel.Width;
            uC_Divizie.update();
            changeUC(uC_Divizie);
        }

        private void btnProjekty_Click(object sender, EventArgs e) {
            if (!Preferences.IsDivizia) {
                MessageBox.Show("Najprv založte divíziu.", "Upozornenie");
                return;
            }
            buttonPanel.Height = btnProjekty.Height;
            buttonPanel.Top = btnProjekty.Top;
            buttonPanel.Left = btnProjekty.Left - buttonPanel.Width;
            uC_Projekty.update();
            changeUC(uC_Projekty);
        }

        private void btnOddelenia_Click(object sender, EventArgs e) {
            if (currentUC == uC_Divizie) {
                uC_Projekty.update();
            }
            if (!Preferences.IsProjekt) {
                MessageBox.Show("Najprv založte projekt.", "Upozornenie");
                return;
            }
            buttonPanel.Height = btnOddelenia.Height;
            buttonPanel.Top = btnOddelenia.Top;
            buttonPanel.Left = btnOddelenia.Left - buttonPanel.Width;
            uC_Oddelenia.update();
            changeUC(uC_Oddelenia);
        }

        private void btnAbout_Click(object sender, EventArgs e) {
            buttonPanel.Height = btnAbout.Height;
            buttonPanel.Top = btnAbout.Top;
            buttonPanel.Left = btnAbout.Left - buttonPanel.Width;
            changeUC(uC_About);
        }

        private void btnZamestnanci_Click(object sender, EventArgs e) {
            if (!Preferences.IsFirma) {
                MessageBox.Show("Najprv založte firmu.", "Upozornenie");
                return;
            }
            buttonPanel.Height = btnZamestnanci.Height;
            buttonPanel.Top = btnZamestnanci.Top;
            buttonPanel.Left = btnZamestnanci.Left - buttonPanel.Width;
            uC_Zamestnanci.update();
            changeUC(uC_Zamestnanci);
        }

        private void OSFform_Load(object sender, EventArgs e) {
            buttonPanel.Top = btnFirma.Top;
            buttonPanel.Left = btnFirma.Left - buttonPanel.Width;
        }

        private void changeUC(UserControl uc) {
            if (currentUC != null) {
                if (currentUC == uc) {
                    return;
                }
                currentUC.Visible = false;
            }
            currentUC = uc;
            currentUC.Visible = true;
            currentUC.BringToFront();
        }
    }
}
