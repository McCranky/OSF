using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace OSF {
    public partial class UC_Projekty : UserControl {
        private SqlConnection connection;
        public event EventZmenyDivizie zmenaProjektu;
        public UC_Projekty() {
            InitializeComponent();
            update();
        }

        private void naplnProjekty() {
            using (connection = new SqlConnection(Preferences.connectionString)) {
                string quarryDivizie = "SELECT nazov, tk.kod AS kd FROM Tab_Projekty td " +
                                       "JOIN Tab_Kody tk ON td.kod = tk.kod " +
                                       "WHERE kDivizie = @kod";
                using (SqlDataAdapter adapter = new SqlDataAdapter(quarryDivizie, connection)) {
                    adapter.SelectCommand.Parameters.AddWithValue("@kod", Preferences.KodDivizie);
                    DataTable table = new DataTable();
                    adapter.Fill(table);

                    lstProjekty.DataSource = table;
                    lstProjekty.DisplayMember = "nazov";
                    lstProjekty.ValueMember = "kd";
                }
            }
        }

        private void naplnKandidatov() {
            using (connection = new SqlConnection(Preferences.connectionString)) {
                // Ziskanie vhodnych kandidátov na pozíciu vedúceho
                string quarryZamestnanci = "SELECT id, (isnull(titul,'') + ' ' + meno + ' ' + priezvisko + ' ' + mail + ' ' + CONVERT(nchar(10),isnull(telefon,12345))) as INFO FROM Tab_Zamestnanci " +
                                           "WHERE kodPracoviska = @kod";
                using (SqlDataAdapter adapter = new SqlDataAdapter(quarryZamestnanci, connection)) {
                    int kod = (lstProjekty.SelectedValue == null) ? -1 : Convert.ToInt32(lstProjekty.SelectedValue);
                    adapter.SelectCommand.Parameters.AddWithValue("@kod", kod);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    
                    lstZamestnanci.DataSource = table;
                    lstZamestnanci.DisplayMember = "INFO";
                    lstZamestnanci.ValueMember = "id";
                }
                // vyznačenie veduceho
                string quarryVeduciProjektu = "SELECT id AS MENO FROM Tab_Zamestnanci tz " +
                                              "JOIN Tab_Projekty tp ON tz.kodPracoviska = tp.kod " +
                                              "WHERE idVeduci = id " +
                                              "AND kod = @kod";
                using (SqlCommand cmd = new SqlCommand(quarryVeduciProjektu, connection)) {
                    cmd.Parameters.AddWithValue("@kod", Convert.ToInt32(lstProjekty.SelectedValue));
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

        private void LstProjekty_SelectedIndexChanged(object sender, EventArgs e) {
            if (lstProjekty.SelectedValue == null || lstProjekty.SelectedValue.ToString() == "System.Data.DataRowView") {
                return;
            }
            if (zmenaProjektu != null) {
                zmenaProjektu(lstProjekty.Text);
            }
            Preferences.KodProjektu = Convert.ToInt32(lstProjekty.SelectedValue);
            tbNazov.Text = lstProjekty.Text;
            naplnKandidatov();
        }

        private void LstZamestnanci_SelectedIndexChanged(object sender, EventArgs e) {
            if (lstZamestnanci.SelectedItem == null) {
                return;
            }
            cbVeduci.Text = lstZamestnanci.Text;
            cbVeduci.ValueMember = lstZamestnanci.SelectedValue.ToString();
            lstNepriradeny.ClearSelected();     // aby bol vždy vybrany iba jeden človek
        }

        private void LstNepriradeny_SelectedIndexChanged(object sender, EventArgs e) {
            if (lstNepriradeny.SelectedItem == null) {
                return;
            }
            cbVeduci.Text = lstNepriradeny.Text;
            cbVeduci.ValueMember = lstNepriradeny.SelectedValue.ToString();
            lstZamestnanci.ClearSelected();     // aby bol vždy vybrany iba jeden človek
        }

        private void BtnPridaj_Click(object sender, EventArgs e) {
            // kontrola
            if (!Preferences.IsKodDivizia) {
                MessageBox.Show("V záložke 'Divízie' vyber divíziu.", "Upozornenie");
                return;
            }
            if (tbNazov.Text == "" || cbVeduci.ValueMember == "" || cbVeduci.ValueMember == "System.Data.DataRowView" || cbVeduci.Text == "") {
                MessageBox.Show("Všetky polia musie byť vyplnené.", "Upozornenie");
                return;
            }
            if (lstProjekty.FindStringExact(tbNazov.Text) >= 0) {
                MessageBox.Show("Projekt s takýmto menom už existuje.", "Upozornenie");
                return;
            }

            using (connection = new SqlConnection(Preferences.connectionString)) {
                string quarryKandidatVeduceho = "SELECT COUNT(*) FROM Tab_Projekty " +
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
                using (SqlCommand cmd = new SqlCommand("pridajProjekt", connection)) {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@pIdUrovne", Constants.UROVEN_PROJEKT);
                    cmd.Parameters.AddWithValue("@pKodDivizie", Preferences.KodDivizie);
                    cmd.Parameters.AddWithValue("@pNazov", tbNazov.Text);
                    cmd.Parameters.AddWithValue("@pVeduci", Convert.ToInt32(cbVeduci.ValueMember));
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
            }
            update();
        }

        private void BtnUloz_Click(object sender, EventArgs e) {
            if (lstProjekty.Items.Count <= 0) {
                MessageBox.Show("Neexistuje projekt na upravu.", "Upozornenie");
                return;
            }

            if (lstProjekty.FindStringExact(tbNazov.Text) >= 0) {
                if (lstProjekty.Text != tbNazov.Text) {
                    MessageBox.Show("Projekt s takýmto menom už existuje.", "Upozornenie");
                    return;
                }
            }

            using (connection = new SqlConnection(Preferences.connectionString)) {
                using (SqlCommand cmd = new SqlCommand("upravProjekt", connection)) {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@pKod", Convert.ToInt32(lstProjekty.SelectedValue));
                    cmd.Parameters.AddWithValue("@pNazov", tbNazov.Text);
                    cmd.Parameters.AddWithValue("@pIdVeduci", Convert.ToInt32(cbVeduci.ValueMember));
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
            }
            update();
        }

        private void BtnZrus_Click(object sender, EventArgs e) {
            if (lstProjekty.SelectedItem == null) {
                MessageBox.Show("Najprv vyber projekt.", "Upozornenie");
                return;
            }
            string msg = "- prepustenie všetkych zamestnancov pracujúcich pod vybraným projektom\n\n" +
                         "Prajete si zrušiť projekt a prepustiť zamestnancov?";
            DialogResult rst = MessageBox.Show(msg, "Zrušenie projektu", MessageBoxButtons.YesNo);
            if (rst == DialogResult.Yes) {
                using (connection = new SqlConnection(Preferences.connectionString)) {
                    using (SqlCommand cmd = new SqlCommand("zrusProjekt", connection)) {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@pKod", Convert.ToInt32(lstProjekty.SelectedValue));
                        connection.Open();
                        cmd.ExecuteNonQuery();
                        connection.Close();
                    }
                }
                update();
            }
        }

        public void update() {
            cbVeduci.Text = "";
            naplnProjekty();
            naplnNepriradenych();
            naplnKandidatov();
            if (lstProjekty.Items.Count > 0) {
                lstProjekty.SelectedIndex = 0;
                Preferences.IsProjekt = true;
                Preferences.IsKodProjekt = true;
                Preferences.KodProjektu = Convert.ToInt32(lstProjekty.SelectedValue);
            } else {
                Preferences.IsProjekt = false;
                Preferences.IsKodProjekt = false;

                Preferences.IsOddelenie = false;
            }

            if (zmenaProjektu != null) {
                zmenaProjektu(lstProjekty.SelectedItem == null ? "---" : lstProjekty.Text);
            }
        }
    }
}
