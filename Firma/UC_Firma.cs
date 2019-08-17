using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace OSF {
    public partial class UC_Firma : UserControl {
        //private string connectionString;
        private SqlConnection connection;
        //private int pocProjektov, pocDivizii, pocOddeleni;
        public UC_Firma() {
            InitializeComponent();
            
        }

        private void btnUpravit_Click(object sender, EventArgs e) {
            if (!panelEdit.Visible) {
                panelEdit.Visible = true;
                naplnListKandidatov();
            } else {
                MessageBox.Show("Úprava je otvorená.");
            }
        }

        private void BtnZrusit_Click(object sender, EventArgs e) {

        }

        private void BtnUkoncit_Click(object sender, EventArgs e) {
            tbNazov.Text = "";
            tbKod.Text = "";
            panelEdit.Visible = false;
        }

        private void naplnListKandidatov() {
            using (connection = new SqlConnection(Constants.CONNECTIONSTRING))
            using (SqlDataAdapter adapter = new SqlDataAdapter("SELECT id, (isnull(titul,'') + meno + priezvisko + mail + CONVERT(nchar(10),isnull(telefon,00000))) as INFO FROM Tab_Zamestnanci", connection)) {
                DataTable table = new DataTable();
                adapter.Fill(table);
                
                lstKandidati.DataSource = table;
                lstKandidati.DisplayMember = "INFO";
                lstKandidati.ValueMember = "id";

            }
        }

        private void ziskajUdaje() {
            using (connection = new SqlConnection(Constants.CONNECTIONSTRING))
            using (SqlCommand cmd = new SqlCommand("pocetnost", connection)) {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@pDivizie", SqlDbType.Int);
                cmd.Parameters.Add("@pProjekty", SqlDbType.Int);
                cmd.Parameters.Add("@pOddelenia", SqlDbType.Int);
                cmd.Parameters.Add("@pZamestnanci", SqlDbType.Int);
                cmd.Parameters["@pDivizie"].Direction = ParameterDirection.Output;
                cmd.Parameters["@pProjekty"].Direction = ParameterDirection.Output;
                cmd.Parameters["@pOddelenia"].Direction = ParameterDirection.Output;
                cmd.Parameters["@pZamestnanci"].Direction = ParameterDirection.Output;
                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
                labelDivizie.Text = cmd.Parameters["@pDivizie"].Value.ToString();
                labelProjekty.Text = cmd.Parameters["@pProjekty"].Value.ToString();
                labelOddelenia.Text = cmd.Parameters["@pOddelenia"].Value.ToString();
                labelZamestnanci.Text = cmd.Parameters["@pZamestnanci"].Value.ToString();

            }
        }

        private void UC_Firma_Load(object sender, EventArgs e) {
            ziskajUdaje();
        }
    }
}
