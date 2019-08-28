using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace OSF {
    public partial class UC_Zamestnanci : UserControl {
        private SqlConnection connection;
        public UC_Zamestnanci() {
            InitializeComponent();
            clear();
            tbTelefon.ShortcutsEnabled = false;
            ttPridel.SetToolTip(btnPridel, "1. stlačenie - otvorí ponuku\n2. stlačenie - pridelí prácu");
        }

        private void clear() {
            tbTitul.Text = "";
            tbMeno.Text = "";
            tbPriezvisko.Text = "";
            tbMail.Text = "";
            tbTelefon.Text = "";
            lstZamestnanci.ClearSelected();
            lstNepriradeny.ClearSelected();
        }

        private void naplnZamestnancov() {
            using (connection = new SqlConnection(Constants.CONNECTIONSTRING)) {
                string quarryZamestnanci = "SELECT id, (isnull(titul,'') + ' ' + meno + ' ' + priezvisko + ' ' + mail + ' ' + CONVERT(nchar(10),isnull(telefon,12345))) as INFO FROM Tab_Zamestnanci " +
                                           "WHERE kodPracoviska IS NOT NULL";
                using (SqlDataAdapter adapter = new SqlDataAdapter(quarryZamestnanci, connection)) {
                    DataTable table = new DataTable();
                    adapter.Fill(table);

                    lstZamestnanci.DataSource = table;
                    lstZamestnanci.DisplayMember = "INFO";
                    lstZamestnanci.ValueMember = "id";
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

        private void LstZamestnanci_SelectedIndexChanged(object sender, EventArgs e) {
            if (lstZamestnanci.SelectedItem == null || lstZamestnanci.ValueMember != "id") {
                return;
            }

            naplnPolia(Convert.ToInt32(lstZamestnanci.SelectedValue));
            lstNepriradeny.ClearSelected();
        }

        private void LstNepriradeny_SelectedIndexChanged(object sender, EventArgs e) {
            if (lstNepriradeny.SelectedItem == null || lstNepriradeny.ValueMember != "id") {
                return;
            }

            naplnPolia(Convert.ToInt32(lstNepriradeny.SelectedValue));
            lstZamestnanci.ClearSelected();
        }

        private void naplnPolia(int id) {
            using (connection = new SqlConnection(Constants.CONNECTIONSTRING)) {
                string quarryOsoba = "SELECT isnull(titul,'') AS TIT, meno, priezvisko, mail, isnull(telefon,'') AS TEL FROM Tab_Zamestnanci " +
                                           "WHERE id = @id";
                using (SqlCommand cmd = new SqlCommand(quarryOsoba, connection)) {
                    cmd.Parameters.AddWithValue("@id", id);
                    connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read()) {
                        tbTitul.Text = reader["TIT"].ToString();
                        tbMeno.Text = reader["meno"].ToString();
                        tbPriezvisko.Text = reader["priezvisko"].ToString();
                        tbMail.Text = reader["mail"].ToString();
                        tbTelefon.Text = reader["TEL"].ToString();
                    } else {
                        clear();
                    }
                    connection.Close();
                }
            }
        }

        public void update() {
            naplnZamestnancov();
            naplnNepriradenych();
            if (lstZamestnanci.Items.Count > 0) {
                lstNepriradeny.ClearSelected();
                lstZamestnanci.SelectedIndex = 0;
                naplnPolia(Convert.ToInt32(lstZamestnanci.SelectedValue));
            } else if (lstNepriradeny.Items.Count > 0) {
                lstZamestnanci.ClearSelected();
                lstNepriradeny.SelectedIndex = 0;
                naplnPolia(Convert.ToInt32(lstNepriradeny.SelectedValue));
            }
            panelPraca.Visible = false;
        }

        private void BtnUloz_Click(object sender, EventArgs e) {
            if (!check()) {
                return;
            }
            if (tbMeno.Text == "" || tbPriezvisko.Text == "" || tbMail.Text == "") {
                MessageBox.Show("Je potrebné vyplniť aspoň meno, priezvisko a mail.", "Upozornenie");
                return;
            }
            using (connection = new SqlConnection(Constants.CONNECTIONSTRING)) {
                string quarryUpravZamestnanca = "UPDATE Tab_Zamestnanci " +
                                                "SET titul = @titul, meno = @meno, priezvisko = @priezvisko, mail = @mail, telefon = @telefon " +
                                                "WHERE id = @id";
                using (SqlCommand cmd = new SqlCommand(quarryUpravZamestnanca, connection)) {
                    cmd.Parameters.AddWithValue("@titul",tbTitul.Text);
                    cmd.Parameters.AddWithValue("@meno", tbMeno.Text);
                    cmd.Parameters.AddWithValue("@priezvisko", tbPriezvisko.Text);
                    cmd.Parameters.AddWithValue("@mail", tbMail.Text);
                    cmd.Parameters.AddWithValue("@telefon", tbTelefon.Text == "" ? -1 : Convert.ToInt32(tbTelefon.Text));
                    cmd.Parameters.AddWithValue("@id", lstNepriradeny.SelectedItem != null ? Convert.ToInt32(lstNepriradeny.SelectedValue) : Convert.ToInt32(lstZamestnanci.SelectedValue));
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
            }
            if (lstNepriradeny.SelectedItem != null) {
                naplnNepriradenych();
            } else {
                naplnZamestnancov();
            }
        }

        private void BtnPridaj_Click(object sender, EventArgs e) {
            if (!check()) {
                return;
            }
            if (tbMeno.Text == "" || tbPriezvisko.Text == "" || tbMail.Text == "") {
                MessageBox.Show("Je potrebné vyplniť aspoň meno, priezvisko a mail.", "Upozornenie");
                return;
            }
            using (connection = new SqlConnection(Constants.CONNECTIONSTRING)) {
                string quarryPridajZamestnanca = "INSERT INTO Tab_Zamestnanci " +
                                                 "(titul, meno, priezvisko, mail, telefon) " +
                                                 "VALUES (@titul, @meno, @priezvisko, @mail, @telefon)";
                using (SqlCommand cmd = new SqlCommand(quarryPridajZamestnanca, connection)) {
                    cmd.Parameters.AddWithValue("@titul", tbTitul.Text);
                    cmd.Parameters.AddWithValue("@meno", tbMeno.Text);
                    cmd.Parameters.AddWithValue("@priezvisko", tbPriezvisko.Text);
                    cmd.Parameters.AddWithValue("@mail", tbMail.Text);
                    cmd.Parameters.AddWithValue("@telefon", tbTelefon.Text == "" ? -1 : Convert.ToInt32(tbTelefon.Text));
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
            }
            naplnNepriradenych();
        }

        private bool check() {
            if (panelPraca.Visible) {
                MessageBox.Show("Najprv dokončite pridávanie práce.", "Upozornenie");
                return false;
            }
            return true;
        }

        private void TbTelefon_KeyPress(object sender, KeyPressEventArgs e) {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) {
                e.Handled = true;
            }
        }

        private void BtnVyhod_Click(object sender, EventArgs e) {
            if (!check()) {
                return;
            }
            try {
                using (connection = new SqlConnection(Constants.CONNECTIONSTRING)) {
                    string quarryPridajZamestnanca = "DELETE FROM Tab_Zamestnanci " +
                                                     "WHERE id = @id";
                    using (SqlCommand cmd = new SqlCommand(quarryPridajZamestnanca, connection)) {
                        if (lstZamestnanci.SelectedItem != null) {
                            cmd.Parameters.AddWithValue("@id", Convert.ToInt32(lstZamestnanci.SelectedValue));
                        } else {
                            cmd.Parameters.AddWithValue("@id", Convert.ToInt32(lstNepriradeny.SelectedValue));
                        }
                        connection.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
                if (lstZamestnanci.SelectedItem != null) {
                    naplnZamestnancov();
                } else {
                    naplnNepriradenych();
                }
            } catch (Exception ex) {
                int index = ex.ToString().IndexOf("Tab_") + 4;
                string text;
                switch (ex.ToString()[index]) {
                    case 'F':
                        text = "Pracovník vedie firmu, nájdite za neho náhradu.";
                        break;
                    case 'D':
                        text = "Pracovník vedie divíziu, nájdite za neho náhradu.";
                        break;
                    case 'P':
                        text = "Pracovník vedie projekt, nájdite za neho náhradu.";
                        break;
                    case 'O':
                        text = "Pracovník vedie oddelenie, nájdite za neho náhradu.";
                        break;
                    default:
                        text = "Nebolo možné prepustiť tohto zamestnanca.";
                        break;
                }
                MessageBox.Show(text, "Upozornenie");
            } finally {
                connection.Close();
            }
        }

        private void BtnPridel_Click(object sender, EventArgs e) {
            if (!panelPraca.Visible) {
                panelPraca.Visible = true;
                rbFirma.Checked = true;
                return;
            }

            // kontrola
            if (lstPracoviska.Items.Count < 1) {
                if (rbFirma.Checked) {
                    MessageBox.Show("Najprv založte firmu.", "Upozornenie");
                } else if (rbDivizia.Checked) {
                    MessageBox.Show("Najprv založte divíziu.", "Upozornenie");
                } else if (rbProjekt.Checked) {
                    MessageBox.Show("Najprv založte projekt.", "Upozornenie");
                } else { // oddelenie
                    MessageBox.Show("Najprv založte oddelenie.", "Upozornenie");
                }
                panelPraca.Visible = false;
                return;
            }

            using (connection = new SqlConnection(Constants.CONNECTIONSTRING)) {
                using (SqlCommand cmd = new SqlCommand("skontrolujZamestnanca", connection)) {
                    cmd.CommandType = CommandType.StoredProcedure;
                    if (lstNepriradeny.SelectedItem != null) {
                        cmd.Parameters.AddWithValue("@id", Convert.ToInt32(lstNepriradeny.SelectedValue));
                    } else {
                        cmd.Parameters.AddWithValue("@id", Convert.ToInt32(lstZamestnanci.SelectedValue));
                    }
                    cmd.Parameters.Add("@pocet", SqlDbType.Int);
                    cmd.Parameters["@pocet"].Direction = ParameterDirection.Output;
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();
                    if (Convert.ToInt32(cmd.Parameters["@pocet"].Value) > 0) {
                        MessageBox.Show("Zamestnanec už vedie daný, alebo iný uzol.\n" +
                                        "Nájdite za neho náhradu.", "Upozornenie");
                        panelPraca.Visible = false;
                        return;
                    }
                }
            }

            using (connection = new SqlConnection(Constants.CONNECTIONSTRING)) {
                string quarryZaradZamestnanca = "UPDATE Tab_Zamestnanci " +
                                                "SET kodPracoviska = @kod " +
                                                "WHERE id = @id";
                using (SqlCommand cmd = new SqlCommand(quarryZaradZamestnanca, connection)) {
                    cmd.Parameters.AddWithValue("@kod", Convert.ToInt32(lstPracoviska.SelectedValue));
                    if (lstNepriradeny.SelectedItem != null) {
                        cmd.Parameters.AddWithValue("@id", Convert.ToInt32(lstNepriradeny.SelectedValue));
                    } else {
                        cmd.Parameters.AddWithValue("@id", Convert.ToInt32(lstZamestnanci.SelectedValue));
                    }
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
            }
            panelPraca.Visible = false;
            if (lstNepriradeny.SelectedItem != null) {
                naplnNepriradenych();
            }
            naplnZamestnancov();
        }

        private void RbFirma_CheckedChanged(object sender, EventArgs e) {
            if (rbFirma.Checked) {
                naplnPracoviska("Tab_Firma");
            }
        }

        private void RbDivizia_CheckedChanged(object sender, EventArgs e) {
            if (rbDivizia.Checked) {
                naplnPracoviska("Tab_Divizie");
            }
        }

        private void RbProjekt_CheckedChanged(object sender, EventArgs e) {
            if (rbProjekt.Checked) {
                naplnPracoviska("Tab_Projekty");
            }
        }

        private void RbOddelenie_CheckedChanged(object sender, EventArgs e) {
            if (rbOddelenie.Checked) {
                naplnPracoviska("Tab_Oddelenie");
            }
        }

        private void naplnPracoviska(string tabulka) {
            using (connection = new SqlConnection(Constants.CONNECTIONSTRING)) {
                string quarryDivizie = "SELECT nazov, tk.kod AS kd FROM " + tabulka + " td " +
                                       "JOIN Tab_Kody tk ON td.kod = tk.kod";
                using (SqlDataAdapter adapter = new SqlDataAdapter(quarryDivizie, connection)) {
                    DataTable table = new DataTable();
                    adapter.Fill(table);

                    lstPracoviska.DataSource = table;
                    lstPracoviska.DisplayMember = "nazov";
                    lstPracoviska.ValueMember = "kd";
                }
            }
        }
    }
}
