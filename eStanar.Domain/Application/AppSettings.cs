using System;
using System.Data;

namespace eStanar.Domain.Application
{
    public static class AppSettings
    {
        #region Constructor
        static AppSettings()
        {
            GetSettingsFromXml(String.Format("{0}\\App_Data\\Settings.xml", AppDomain.CurrentDomain.BaseDirectory));
        }
        #endregion

        #region Properties
        public static string GoogleClientId { get; set; }

        public static string GoogleClientSecret { get; set; }

        public static string TwitterConsumerKey { get; set; }

        public static string TwitterConsumerSecret { get; set; }

        public static string GitHubClientId { get; set; }

        public static string GitHubClientSecret { get; set; }
        #endregion

        #region Methods
        private static void GetSettingsFromXml(string putanja)
        {
            try
            {
                DataSet dsSettings = new DataSet();
                dsSettings.ReadXml(putanja);

                if (dsSettings.Tables.Count > 0)
                {
                    foreach (DataRow dRow in dsSettings.Tables[0].Rows)
                    {
                        if (dRow.Table.Columns["GoogleClientId"] != null)
                            GoogleClientId = Encrypter.DecryptString(dRow["GoogleClientId"].ToString());

                        if (dRow.Table.Columns["GoogleClientSecret"] != null)
                            GoogleClientSecret = Encrypter.DecryptString(dRow["GoogleClientSecret"].ToString());

                        if (dRow.Table.Columns["TwitterConsumerKey"] != null)
                            TwitterConsumerKey = Encrypter.DecryptString(dRow["TwitterConsumerKey"].ToString());

                        if (dRow.Table.Columns["TwitterConsumerSecret"] != null)
                            TwitterConsumerSecret = Encrypter.DecryptString(dRow["TwitterConsumerSecret"].ToString());

                        if (dRow.Table.Columns["GitHubClientId"] != null)
                            GitHubClientId = Encrypter.DecryptString(dRow["GitHubClientId"].ToString());

                        if (dRow.Table.Columns["GitHubClientSecret"] != null)
                            GitHubClientSecret = Encrypter.DecryptString(dRow["GitHubClientSecret"].ToString());
                    }
                }
            }
            finally { }
        }
        #endregion
    }
}
