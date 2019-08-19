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
using System.Configuration;

namespace OSF {
    public partial class UC_FormularZamestnanec : UserControl {
        string connectionString;
        public bool AllowClose { get; set; }

        public UC_FormularZamestnanec() {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["OSF.Properties.Settings.OSF_DatabaseConnectionString"].ConnectionString;
        }

        private void BtnUkoncit_Click(object sender, EventArgs e) {
            if (AllowClose) {
                close();
            } else {
                MessageBox.Show("Je potrebné vyplniť požadované polia.", "Varovanie");
            }
        }

        private void clear() {
            tbTitul.Text = "";
            tbMeno.Text = "";
            tbPriezvisko.Text = "";
            tbMail.Text = "";
            tbTelefon.Text = "";
        }

        private void close() {
            clear();
            this.Visible = false;
            
        }

        private void BtnUlozit_Click(object sender, EventArgs e) {
            if (tbMeno.Text =="" || tbPriezvisko.Text == "" || tbMail.Text == "") {
                MessageBox.Show("Polia s '*' musia byť vyplnené.", "Upozornenie");
                return;
            }
            using (SqlConnection connection = new SqlConnection(connectionString)) {
                string quarryPridajZamestnanca = "INSERT INTO Tab_Zamestnanec (kodPracoviska, titul, meno, priezvisko, mail, telefon) " +
                                                 "VALUES (@kodPracoviska, @titul, @meno, @priezvisko, @mail, @telefon)";
                using (SqlCommand cmd = new SqlCommand(quarryPridajZamestnanca, connection)) {
                    cmd.Parameters.AddWithValue("@kodPracoviska", Constants.UROVEN_FIRMA);
                    cmd.Parameters.AddWithValue("@titul", tbTitul.Text);
                    cmd.Parameters.AddWithValue("@meno", tbMeno.Text);
                    cmd.Parameters.AddWithValue("@priezvisko", tbPriezvisko.Text);
                    cmd.Parameters.AddWithValue("@mail", tbMail.Text);
                    cmd.Parameters.AddWithValue("@telefon", tbTelefon.Text);
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
            }
            close();
        }
    }
}
