using MySql.Data.MySqlClient;

namespace JRPG.DAL
{
    class DBConnection
    {
        private MySqlConnectionStringBuilder stringBuilder =
             new MySqlConnectionStringBuilder();

        private static DBConnection instance = null;
        public static DBConnection Instance
        {
            get
            {
                instance = new DBConnection();
                return instance;
            }
            }
        private MySqlConnection connection;
        public MySqlConnection Connection => connection;
        private DBConnection()
        {

            
            stringBuilder.UserID = Properties.Settings.Default.userID;
            stringBuilder.Server = Properties.Settings.Default.server;
            stringBuilder.Database = Properties.Settings.Default.database;
            stringBuilder.Port = Properties.Settings.Default.port;
            stringBuilder.Password = Properties.Settings.Default.paswd;

            connection = new MySqlConnection(stringBuilder.ToString());
        }
    }
}
