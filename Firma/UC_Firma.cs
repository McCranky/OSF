using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace OSF {
    public partial class UC_Firma : UserControl {
        private SqlConnection connection;
        public UC_Firma() {
            InitializeComponent();
        }

        private void btnUpravit_Click(object sender, EventArgs e) {
            if (!Preferences.IsFirma) {
                MessageBox.Show("Najskôr vyplnte formulár.", "Upozornenie");
                return;
            }
            if (!panelEdit.Visible) {
                panelEdit.Visible = true;
            } else {
                MessageBox.Show("Okno je už otvorené.", "Edit");
            }
        }

        private void BtnZrusit_Click(object sender, EventArgs e) {
            if (!Preferences.IsFirma) {
                MessageBox.Show("Najskôr vyplnte formulár.", "Upozornenie");
                return;
            }
            string msg = "- prepustenie všetkých zamestnancov\n" +
                         "- zrušenie celej firemnej štruktúry\n" +
                         "+ nová firma\n" +
                         "+ nový riaditeľ\n\n" +
                         "Prajete si firmu zrušiť?";
            DialogResult rst = MessageBox.Show(msg, "Zrušenie firmy", MessageBoxButtons.YesNo);
            if (rst == DialogResult.Yes) {
                using (connection = new SqlConnection(Constants.CONNECTIONSTRING)) {
                    using (SqlCommand cmd = new SqlCommand("panicButton", connection)) {
                        connection.Open();
                        cmd.ExecuteNonQuery();
                        connection.Close();
                    }
                }
                formularFirmy.Visible = true;
                Preferences.IsFirma = false;
            }
        }

        private void BtnUkoncit_Click(object sender, EventArgs e) {
            hideEditPanel();
        }

        private void ziskajAktualneUdaje() {
            using (connection = new SqlConnection(Constants.CONNECTIONSTRING)) {
                connection.Open(); // Otvorenie spojenia
                // Ziskanie početnosti uzlov
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
                    cmd.ExecuteNonQuery();
                    
                    labelDivizie.Text = cmd.Parameters["@pDivizie"].Value.ToString();
                    labelProjekty.Text = cmd.Parameters["@pProjekty"].Value.ToString();
                    labelOddelenia.Text = cmd.Parameters["@pOddelenia"].Value.ToString();
                    labelZamestnanci.Text = cmd.Parameters["@pZamestnanci"].Value.ToString();
                }
                // Ziskanie mena riaditeľa
                string quarryRiaditel = "SELECT (meno + ' ' + priezvisko) AS MENO FROM Tab_Firma tf" +
                                        " JOIN Tab_Zamestnanci tz ON tf.idRiaditel = tz.id";
                using (SqlCommand cmd = new SqlCommand(quarryRiaditel, connection)) {
                    Object obj = cmd.ExecuteScalar();
                    labelRiaditel.Text = (obj == null ? "---" : obj.ToString()) ;
                }
                // Ziskanie názvu a kódu firmy
                string quarryFirma = "SELECT nazov, Tab_Kody.kod FROM Tab_Kody" +
                                    " JOIN Tab_Firma ON Tab_Kody.kod = Tab_Firma.kod";
                using (SqlCommand cmd = new SqlCommand(quarryFirma, connection)) {
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read()) {
                        labelNazov.Text = reader["nazov"].ToString();
                        labelKod.Text = reader["kod"].ToString();
                    } else {
                        labelNazov.Text = "---";
                        labelKod.Text = "---";
                    }
                    
                }
                connection.Close(); // Zatvorenie spojenia
            }
        }

        private void UC_Firma_Load(object sender, EventArgs e) {
            ziskajAktualneUdaje();
            naplnListKAndidatov();
            if (labelRiaditel.Text == "---") {
                formularFirmy.Visible = true;
                Preferences.IsFirma = false;
            } else {
                Preferences.IsFirma = true;
            }
        }

        private void BtnUlozit_Click(object sender, EventArgs e) {
            if (tbNazov.Text == "") {
                MessageBox.Show("Všetky polia musia byť vyplnené.");
                return;
            }
            using (connection = new SqlConnection(Constants.CONNECTIONSTRING)) {
                // Aktualizovanie Nazvu
                string quarryNazovFirmy = "UPDATE Tab_Kody " +
                                          "SET nazov = @pNazov " +
                                          "WHERE kod = @pKod";
                using (SqlCommand cmd = new SqlCommand(quarryNazovFirmy, connection)) {
                    cmd.Parameters.AddWithValue("@pNazov", tbNazov.Text);
                    cmd.Parameters.AddWithValue("@pKod", Constants.UROVEN_FIRMA);
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }

                // Aktualizovanie riaditeľa
                string quarryRiaditel = "UPDATE Tab_Firma " +
                                        "SET idRiaditel = @pIdRiaditel";
                using (SqlCommand cmd = new SqlCommand(quarryRiaditel, connection)) {
                    cmd.Parameters.AddWithValue("@pIdRiaditel", lstKandidati.SelectedValue);
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
            }
            hideEditPanel();
            ziskajAktualneUdaje();
        }

        private void hideEditPanel() {
            tbNazov.Text = "";
            panelEdit.Visible = false;
        }

        private void naplnListKAndidatov() {
            using (connection = new SqlConnection(Constants.CONNECTIONSTRING)) {
                // Ziskanie vhodnych kandidátov na pozíciu riaditeľa (pracovnícy na úrovni firmy)
                string quarryKandidati = "SELECT id, (isnull(titul,'') + meno + priezvisko + mail + CONVERT(nchar(10),isnull(telefon,12345))) as INFO FROM Tab_Zamestnanci " +
                                     "WHERE kodPracoviska IN(" +
                                       "SELECT kod FROM Tab_Kody tk " +
                                       "JOIN Tab_UrovenFirmy tu ON tk.idUrovne = tu.id " +
                                       "WHERE popis LIKE '%Firma%')";
                using (SqlDataAdapter adapter = new SqlDataAdapter(quarryKandidati, connection)) {
                    DataTable table = new DataTable();
                    adapter.Fill(table);

                    lstKandidati.DataSource = table;
                    lstKandidati.DisplayMember = "INFO";
                    lstKandidati.ValueMember = "id";
                }
            }
        }

        private void BtnFulozit_Click(object sender, EventArgs e) {
            if (tbFmeno.Text == "" || tbFpriezvisko.Text == "" || tbFmail.Text == "" || tbFnazov.Text == "") {
                MessageBox.Show("Polia s '*' musia byť vyplnené.", "Upozornenie");
                return;
            }
            using (SqlConnection connection = new SqlConnection(Constants.CONNECTIONSTRING)) {
                string quarryPridajKodFirmy = "INSERT INTO Tab_Kody (idUrovne, nazov) " +
                                           "VALUES (@uroven, @nazov)";
                using (SqlCommand cmd = new SqlCommand(quarryPridajKodFirmy, connection)) {
                    cmd.Parameters.AddWithValue("@uroven", Constants.UROVEN_FIRMA);
                    cmd.Parameters.AddWithValue("@nazov", tbFnazov.Text);
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }

                string quarryPridajZamestnanca = "INSERT INTO Tab_Zamestnanci (kodPracoviska, titul, meno, priezvisko, mail, telefon) " +
                                                 "VALUES (@kodPracoviska, @titul, @meno, @priezvisko, @mail, @telefon)";
                using (SqlCommand cmd = new SqlCommand(quarryPridajZamestnanca, connection)) {
                    cmd.Parameters.AddWithValue("@kodPracoviska", Constants.UROVEN_FIRMA);
                    cmd.Parameters.AddWithValue("@titul", tbFtitul.Text);
                    cmd.Parameters.AddWithValue("@meno", tbFmeno.Text);
                    cmd.Parameters.AddWithValue("@priezvisko", tbFpriezvisko.Text);
                    cmd.Parameters.AddWithValue("@mail", tbFmail.Text);
                    cmd.Parameters.AddWithValue("@telefon", tbFtelefon.Text);
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
                
                string quarryPridajFirmu = "INSERT INTO Tab_Firma VALUES(1, 1)";
                using (SqlCommand cmd = new SqlCommand(quarryPridajFirmu, connection)) {
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
            }
            formularFirmy.Visible = false;
            ziskajAktualneUdaje();
            naplnListKAndidatov();
            Preferences.IsFirma = true;
        }

        public void update() {
            ziskajAktualneUdaje();
            naplnListKAndidatov();
            hideEditPanel();
        }
    }
}
