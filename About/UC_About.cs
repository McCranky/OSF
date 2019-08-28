using System.Windows.Forms;

namespace OSF {
    public partial class UC_About : UserControl {
        public string Autor {
            get { return labelAutor.Text; }
            set { labelAutor.Text = value; }
        }

        public string Verzia {
            get { return labelVerzia.Text; }
            set { labelVerzia.Text = value; }
        }

        public string Rok {
            get { return labelRok.Text; }
            set { labelRok.Text = value; }
        }
        public UC_About() {
            InitializeComponent();
        }
    }
}
