using System.Configuration;

namespace OSF {
    class Preferences {
        public static bool IsFirma { get; set; }
        public static bool IsDivizia { get; set; }
        public static bool IsProjekt { get; set; }
        public static bool IsOddelenie { get; set; }

        public static bool IsKodFirma { get; set; }
        public static bool IsKodDivizia { get; set; }
        public static bool IsKodProjekt { get; set; }
        public static bool IsKodOddelenie { get; set; }

        public static int KodFirmy { get; set; }
        public static int KodDivizie { get; set; }
        public static int KodProjektu { get; set; }
        public static int KodOddelenia { get; set; }

        public static string connectionString { get { return "Data Source=DESKTOP-AUUG58B\\SQLEXPRESS;Initial Catalog=OSFDatabase;Integrated Security=True"; } }
    }
}
