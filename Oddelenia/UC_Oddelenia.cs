using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace OSF {
    public partial class UC_Oddelenia : UserControl {
        private SqlConnection connection;
        public event EventZmenyDivizie zmenaOddelenia;
        public UC_Oddelenia() {
            InitializeComponent();
            update();
        }

        private void naplnOddelenia() {
            using (connection = new SqlConnection(Constants.CONNECTIONSTRING)) {
                string quarryDivizie = "SELECT nazov, tk.kod AS kd FROM Tab_Oddelenie td " +
                                         "JOIN Tab_Kody tk ON td.kod = tk.kod";
                using (SqlDataAdapter adapter = new SqlDataAdapter(quarryDivizie, connection)) {
                    DataTable table = new DataTable();
                    adapter.Fill(table);

                    lstOddelenia.DataSource = table;
                    lstOddelenia.DisplayMember = "nazov";
                    lstOddelenia.ValueMember = "kd";
                }
            }
        }

        private void naplnNepriradenych() {
            using (connection = new SqlConnection(Constants.CONNECTIONSTRING)) {
                string quarryNepriradeny = "SELECT id, (isnull(titul,'') + ' ' + meno + ' ' + priezvisko + ' ' + mail + ' ' + CONVERT(nchar(10),isnull(telefon,12345))) as INFO FROM Tab_Zamestnanci " +
                                           "WHERE kodPracoviska IS NULL";
                using (SqlDataAdapter adapter = new SqlDataAdapter(quarryNepriradeny, connection)) {
                    DataTable table = new DataTable();
                    adapter.Fill(table);

                    lstNepriradeny.DataSource = table;
                    lstNepriradeny.DisplayMember = "INFO";
                    lstNepriradeny.ValueMember = "id";
                }
            }
        }

        private void naplnKandidatov() {
            using (connection = new SqlConnection(Constants.CONNECTIONSTRING)) {
                // Ziskanie vhodnych kandidátov na pozíciu vedúceho
                string quarryZamestnanci = "SELECT id, (isnull(titul,'') + ' ' + meno + ' ' + priezvisko + ' ' + mail + ' ' + CONVERT(nchar(10),isnull(telefon,12345))) as INFO FROM Tab_Zamestnanci " +
                                           "WHERE kodPracoviska  = @kod";
                using (SqlDataAdapter adapter = new SqlDataAdapter(quarryZamestnanci, connection)) {
                    int kod = (lstOddelenia.SelectedValue == null) ? -1 : Convert.ToInt32(lstOddelenia.SelectedValue);
                    adapter.SelectCommand.Parameters.AddWithValue("@kod", kod);
                    DataTable table = new DataTable();
                    adapter.Fill(table);

                    lstZamestnanci.DataSource = table;
                    lstZamestnanci.DisplayMember = "INFO";
                    lstZamestnanci.ValueMember = "id";
                }

                string quarryVeduciOddelenia = "SELECT id AS MENO FROM Tab_Zamestnanci tz " +
                                             "JOIN Tab_Oddelenie tabo ON tz.kodPracoviska = tabo.kod " +
                                             "WHERE idVeduci = id " +
                                             "AND kod = @kod";
                using (SqlCommand cmd = new SqlCommand(quarryVeduciOddelenia, connection)) {
                    cmd.Parameters.AddWithValue("@kod", Convert.ToInt32(lstOddelenia.SelectedValue));
                    connection.Open();
                    Object obj = cmd.ExecuteScalar();
                    connection.Close();
                    lstZamestnanci.SelectedValue = Convert.ToInt32(obj);
                }
            }
        }

        private void LstOddelenia_SelectedIndexChanged(object sender, EventArgs e) {
            if (lstOddelenia.SelectedValue == null || lstOddelenia.SelectedValue.ToString() == "System.Data.DataRowView") {
                return;
            }
            if (zmenaOddelenia != null) {
                zmenaOddelenia(lstOddelenia.Text);
            }
            Preferences.KodOddelenia = Convert.ToInt32(lstOddelenia.SelectedValue);
            tbNazov.Text = lstOddelenia.Text;
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

        private void LstNepriradeny_SelectedIndexChanged(object sender, EventArgs e) {
            if (lstNepriradeny.SelectedItem == null) {
                return;
            }
            cbVeduci.Text = lstNepriradeny.Text;
            cbVeduci.ValueMember = lstNepriradeny.SelectedValue.ToString();
            lstZamestnanci.ClearSelected();
        }

        private void BtnPridaj_Click(object sender, EventArgs e) {
            // kontrola
            if (!Preferences.IsKodProjekt) {
                MessageBox.Show("V záložke 'Projekty' vyber projekt.", "Upozornenie");
                return;
            }
            if (tbNazov.Text == "" || cbVeduci.ValueMember == "" || cbVeduci.Text == "") {
                MessageBox.Show("Všetky polia musie byť vyplnené.", "Upozornenie");
                return;
            }
            if (lstOddelenia.FindStringExact(tbNazov.Text) >= 0) {
                MessageBox.Show("Oddelenie s takýmto menom už existuje.", "Upozornenie");
                return;
            }

            using (connection = new SqlConnection(Constants.CONNECTIONSTRING)) {
                string quarryKandidatVeduceho = "SELECT COUNT(*) FROM Tab_Oddelenie " +
                                                "WHERE idVeduci = @id";
                using (SqlCommand cmd = new SqlCommand(quarryKandidatVeduceho, connection)) {
                    cmd.Parameters.AddWithValue("@id", Convert.ToInt32(cbVeduci.ValueMember));
                    connection.Open();
                    int pocet = Convert.ToInt32(cmd.ExecuteScalar());
                    if (pocet > 0) {
                        connection.Close();
                        MessageBox.Show("Zamestnanec už vedie iné oddelenie.", "Upozornenie");
                        return;
                    }
                }
                using (SqlCommand cmd = new SqlCommand("pridajOddelenie", connection)) {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@pIdUrovne", Constants.UROVEN_ODDELENIE);
                    cmd.Parameters.AddWithValue("@pKodProjektu", Preferences.KodProjektu);
                    cmd.Parameters.AddWithValue("@pNazov", tbNazov.Text);
                    cmd.Parameters.AddWithValue("@pVeduci", Convert.ToInt32(cbVeduci.ValueMember));
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
            }
            update();
        }

        private void BtnUloz_Click(object sender, EventArgs e) {
            if (lstOddelenia.Items.Count <= 0) {
                MessageBox.Show("Neexistuje oddelenie na upravu.", "Upozornenie");
                return;
            }

            if (lstOddelenia.FindStringExact(tbNazov.Text) >= 0) {
                if (lstOddelenia.Text != tbNazov.Text) {
                    MessageBox.Show("Oddelenie s takýmto menom už existuje.", "Upozornenie");
                    return;
                }
            }

            using (connection = new SqlConnection(Constants.CONNECTIONSTRING)) {
                using (SqlCommand cmd = new SqlCommand("upravOddelenie", connection)) {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@pKod", Convert.ToInt32(lstOddelenia.SelectedValue));
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
            if (lstOddelenia.SelectedItem == null) {
                MessageBox.Show("Najprv vyber projekt.", "Upozornenie");
                return;
            }
            string msg = "- prepustenie všetkych zamestnancov pracujúcich pod vybraným projektom\n\n" +
                         "Prajete si zrušiť projekt a prepustiť zamestnancov?";
            DialogResult rst = MessageBox.Show(msg, "Zrušenie projektu", MessageBoxButtons.YesNo);
            if (rst == DialogResult.Yes) {
                using (connection = new SqlConnection(Constants.CONNECTIONSTRING)) {
                    using (SqlCommand cmd = new SqlCommand("zrusOddelenie", connection)) {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@pKod", Convert.ToInt32(lstOddelenia.SelectedValue));
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
            naplnOddelenia();
            naplnNepriradenych();
            naplnKandidatov();
            if (lstOddelenia.Items.Count > 0) {
                lstOddelenia.SelectedIndex = 0;
                Preferences.IsOddelenie = true;
                Preferences.IsKodOddelenie = true;
                Preferences.KodOddelenia = Convert.ToInt32(lstOddelenia.SelectedValue);
            } else {
                Preferences.IsOddelenie = false;
                Preferences.IsKodOddelenie = false;
            }

            if (zmenaOddelenia != null) {
                zmenaOddelenia(lstOddelenia.SelectedItem == null ? "---" : lstOddelenia.Text);
            }
        }
    }
}
