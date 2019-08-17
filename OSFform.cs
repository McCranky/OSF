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
        private string connectionString;
        private SqlConnection connection;
        private bool moveForm = false;
        private Point movePoint;
        private UserControl currentUC;

        public OSFform() {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["OSF.Properties.Settings.OSF_DatabaseConnectionString"].ConnectionString;
            initUC_About();

            changeUC(uC_About);
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
            buttonPanel.Top = btnFirma.Top;
            buttonPanel.Left = btnFirma.Left - buttonPanel.Width;
            changeUC(uC_Firma);

        }

        private void btnDivizie_Click(object sender, EventArgs e) {
            buttonPanel.Top = btnDivizie.Top;
            buttonPanel.Left = btnDivizie.Left - buttonPanel.Width;
        }

        private void btnProjekty_Click(object sender, EventArgs e) {
            buttonPanel.Top = btnProjekty.Top;
            buttonPanel.Left = btnProjekty.Left - buttonPanel.Width;
        }

        private void btnOddelenia_Click(object sender, EventArgs e) {
            buttonPanel.Top = btnOddelenia.Top;
            buttonPanel.Left = btnOddelenia.Left - buttonPanel.Width;
        }

        private void btnAbout_Click(object sender, EventArgs e) {
            buttonPanel.Top = btnAbout.Top;
            buttonPanel.Left = btnAbout.Left - buttonPanel.Width;
            changeUC(uC_About);
        }

        private void btnZamestnanci_Click(object sender, EventArgs e) {
            buttonPanel.Top = btnZamestnanci.Top;
            buttonPanel.Left = btnZamestnanci.Left - buttonPanel.Width;
        }

        private void OSFform_Load(object sender, EventArgs e) {
            buttonPanel.Top = btnFirma.Top;
            buttonPanel.Left = btnFirma.Left - buttonPanel.Width;

            naplnList();
        }

        private void naplnList() {
            using (connection = new SqlConnection(Constants.CONNECTIONSTRING))
            using (SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Tab_UrovenFirmy", connection)) {
                DataTable table = new DataTable();
                adapter.Fill(table);

                
                listUrovni.DataSource = table;
                listUrovni.DisplayMember = "popis";
                listUrovni.ValueMember = "id";
                
            }
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
