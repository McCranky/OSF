using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace OSF {
    public partial class UC_Divizie : UserControl {
        private SqlConnection connection;
        public event EventZmenyDivizie zmenaDivizie;
        public UC_Divizie() {
            InitializeComponent();
            update();
        }

        private void naplnDivizie() {
            using (connection = new SqlConnection(Preferences.connectionString)) {
                string quarryDivizie = "SELECT nazov, tk.kod AS kd FROM Tab_Divizie td " +
                                         "JOIN Tab_Kody tk ON td.kod = tk.kod";
                using (SqlDataAdapter adapter = new SqlDataAdapter(quarryDivizie, connection)) {
                    DataTable table = new DataTable();
                    adapter.Fill(table);

                    lstDivizie.DataSource = table;
                    lstDivizie.DisplayMember = "nazov";
                    lstDivizie.ValueMember = "kd";
                }
            }
        }

        private void naplnKandidatov() {
            using (connection = new SqlConnection(Preferences.connectionString)) {
                // Ziskanie vhodnych kandidátov na pozíciu vedúceho
                string quarryZamestnanci = "SELECT id, (isnull(titul,'') + ' ' + meno + ' ' + priezvisko + ' ' + mail + ' ' + CONVERT(nchar(10),isnull(telefon,12345))) as INFO FROM Tab_Zamestnanci " +
                                           "WHERE kodPracoviska = @kod";
                using (SqlDataAdapter adapter = new SqlDataAdapter(quarryZamestnanci, connection)) {
                    string meno = (lstDivizie.SelectedValue == null) ? "" : lstDivizie.SelectedValue.ToString();
                    adapter.SelectCommand.Parameters.AddWithValue("@kod", meno);
                    DataTable table = new DataTable();
                    adapter.Fill(table);

                    lstZamestnanci.DataSource = table;
                    lstZamestnanci.DisplayMember = "INFO";
                    lstZamestnanci.ValueMember = "id";
                }
                // vyznačenie aktuálneho vedúceho
                string quarryVeduciDivizie = "SELECT id AS MENO FROM Tab_Zamestnanci tz " +
                                             "JOIN Tab_Divizie td ON tz.kodPracoviska = td.kod " +
                                             "WHERE idVeduci = id " +
                                             "AND kod = @kod";
                using (SqlCommand cmd = new SqlCommand(quarryVeduciDivizie, connection)) {
                    cmd.Parameters.AddWithValue("@kod", Convert.ToInt32(lstDivizie.SelectedValue));
                    connection.Open();
                    Object obj = cmd.ExecuteScalar();
                    connection.Close();
                    lstZamestnanci.SelectedValue = Convert.ToInt32(obj);
                }
            }
        }

        private void naplnNepriradenych() {
            using (connection = new SqlConnection(Preferences.connectionString)) {
                string quarryNepriradeny = "SELECT id, (isnull(titul,'') + ' ' + meno + ' ' + priezvisko + ' ' + mail + ' ' + CONVERT(nchar(10),isnull(telefon,12345))) as INFO FROM Tab_Zamestnanci " +
                                           "WHERE kodPracoviska IS NULL";
                using (SqlDataAdapter adapter = new SqlDataAdapter(quarryNepriradeny, connection)) {
                    DataTable table = new DataTable();
                    adapter.Fill(table);

                    lstNepriradeny.DataSource = table;
                    lstNepriradeny.DisplayMember = "INFO";
                    lstNepriradeny.ValueMember = "id";
                    lstNepriradeny.ClearSelected();
                }
            }
        }

        private void LstDivizie_SelectedIndexChanged(object sender, EventArgs e) {
            if (lstDivizie.SelectedValue == null || lstDivizie.SelectedValue.ToString() == "System.Data.DataRowView") {
                return;
            }
            if (zmenaDivizie != null) {
                zmenaDivizie(lstDivizie.Text);
            }
            Preferences.IsKodDivizia = true;
            Preferences.KodDivizie = Convert.ToInt32(lstDivizie.SelectedValue);
            tbNazov.Text = lstDivizie.Text;
            naplnKandidatov();
        }

        private void LstZamestnanci_SelectedIndexChanged(object sender, EventArgs e) {
            if (lstZamestnanci.SelectedItem == null) {
                return;
            }
            cbVeduci.Text = lstZamestnanci.Text;
            cbVeduci.ValueMember = lstZamestnanci.SelectedValue.ToString();
            lstNepriradeny.ClearSelected();
        }

        private void BtnUlozit_Click(object sender, EventArgs e) {
            if (lstDivizie.FindStringExact(tbNazov.Text) >= 0) {
                if (lstDivizie.Text != tbNazov.Text) {
                    MessageBox.Show("Divízia s takýmto menom už existuje.", "Upozornenie");
                    return;
                }
            }
            if (lstDivizie.Items.Count < 1) {
                MessageBox.Show("Neexistuje divízia na upravu.", "Upozornenie");
                return;
            }

            using (connection = new SqlConnection(Preferences.connectionString)) {
                using (SqlCommand cmd = new SqlCommand("upravDiviziu", connection)) {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@pKod", Convert.ToInt32(lstDivizie.SelectedValue));
                    cmd.Parameters.AddWithValue("@pNazov", tbNazov.Text);
                    cmd.Parameters.AddWithValue("@pIdVeduci", Convert.ToInt32(cbVeduci.ValueMember));
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
            }
            update();
        }

        private void BtnPridat_Click(object sender, EventArgs e) {
            // kontrola
            if (tbNazov.Text == "" || cbVeduci.ValueMember == "" || cbVeduci.ValueMember.ToString() == "System.Data.DataRowView" || cbVeduci.Text == "") {
                MessageBox.Show("Všetky polia musie byť vyplnené.", "Upozornenie");
                return;
            }
            if (lstDivizie.FindStringExact(tbNazov.Text) >= 0) {
                MessageBox.Show("Divízia s takýmto menom už existuje.", "Upozornenie");
                return;
            }

            using (connection = new SqlConnection(Preferences.connectionString)) {
                string quarryKandidatVeduceho = "SELECT COUNT(*) FROM Tab_Divizie " +
                                             "WHERE idVeduci = @id";
                using (SqlCommand cmd = new SqlCommand(quarryKandidatVeduceho, connection)) {
                    cmd.Parameters.AddWithValue("@id", Convert.ToInt32(cbVeduci.ValueMember));
                    connection.Open();
                    int pocet = Convert.ToInt32(cmd.ExecuteScalar());
                    if (pocet > 0) {
                        connection.Close();
                        MessageBox.Show("Zamestnanec už vedie inú divíziu.", "Upozornenie");
                        return;
                    }
                }
                using (SqlCommand cmd = new SqlCommand("pridajDiviziu", connection)) {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@pIdUrovne", Constants.UROVEN_DIVIZIA);
                    cmd.Parameters.AddWithValue("@pKodFirmy", Constants.UROVEN_FIRMA);
                    cmd.Parameters.AddWithValue("@pNazov", tbNazov.Text);
                    cmd.Parameters.AddWithValue("@pVeduci", Convert.ToInt32(cbVeduci.ValueMember));
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
            }
            update();
        }

        private void BtnZrus_Click(object sender, EventArgs e) {
            if (lstDivizie.SelectedItem == null) {
                MessageBox.Show("Najprv vyber divíziu.", "Upozornenie");
                return;
            }
            string msg = "- prepustenie všetkych zamestnancov pracujúcich pod vybranou divíziou\n\n" +
                         "Prajete si zrušiť divíziu a prepustiť jej zamestnancov?";
            DialogResult rst = MessageBox.Show(msg, "Zrušenie firmy", MessageBoxButtons.YesNo);
            if (rst == DialogResult.Yes) {
                using (connection = new SqlConnection(Preferences.connectionString)) {
                    using (SqlCommand cmd = new SqlCommand("zrusDiviziu", connection)) {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@pKod", Convert.ToInt32(lstDivizie.SelectedValue));
                        connection.Open();
                        cmd.ExecuteNonQuery();
                        connection.Close();
                    }
                }
                update();
            }
        }

        private void LstNepriradeny_SelectedIndexChanged(object sender, EventArgs e) {
            if (lstNepriradeny.SelectedItem == null) {
                return;
            }
            cbVeduci.Text = lstNepriradeny.Text;
            cbVeduci.ValueMember = lstNepriradeny.SelectedValue.ToString();
            lstZamestnanci.ClearSelected();
        }

        public void update() {
            cbVeduci.Text = "";
            naplnDivizie();
            
            naplnNepriradenych();
            naplnKandidatov();
            if (lstDivizie.Items.Count > 0) {
                lstDivizie.SelectedIndex = 0;
                Preferences.IsDivizia = true;
                Preferences.IsKodDivizia = true;
                Preferences.KodDivizie = Convert.ToInt32(lstDivizie.SelectedValue);
            } else {
                Preferences.IsDivizia = false;
                Preferences.IsKodDivizia = false;

                Preferences.IsProjekt = false;
                Preferences.IsOddelenie = false;
            }

            if (zmenaDivizie != null) {
                zmenaDivizie(lstDivizie.SelectedItem == null ? "---" : lstDivizie.Text);
            }
            lstNepriradeny.ClearSelected();
        }
    }
}
