using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OSF {
    public partial class OSFform : Form {
        private bool moveForm = false;
        private Point movePoint;

        public OSFform() {
            InitializeComponent();
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

        private void Button5_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void Button1_Click(object sender, EventArgs e) {
            buttonPanel.Top = button1.Top;
            buttonPanel.Visible = true;
        }

        private void Button2_Click(object sender, EventArgs e) {
            buttonPanel.Top = button2.Top;
            buttonPanel.Visible = true;
        }

        private void Button3_Click(object sender, EventArgs e) {
            buttonPanel.Top = button3.Top;
            buttonPanel.Visible = true;
        }

        private void Button4_Click(object sender, EventArgs e) {
            buttonPanel.Top = button4.Top;
            buttonPanel.Visible = true;
        }
        // About button
        private void Button6_Click(object sender, EventArgs e) {
            buttonPanel.Visible = false;
            uC_About.BringToFront();
        }
    }
}
