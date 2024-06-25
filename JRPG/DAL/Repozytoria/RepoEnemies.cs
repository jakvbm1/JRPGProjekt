using JRPG.DAL.Encje;
using MySql.Data.MySqlClient;

namespace JRPG.DAL.Repozytoria
{
    class RepoEnemies
    {
        private const string ALL_ENEMIES = "SELECT * FROM enemies";
        private const string ADD_EQUIPMENT = "INSERT INTO `enemies` VALUES ";

        public static List<Enemies> GetAllEnemies()
        {
            List<Enemies> enemies = new List<Enemies>();

            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand(ALL_ENEMIES, connection);

                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                    enemies.Add(new Enemies(reader));
                connection.Close();
            }

            return enemies;
        }

        public static bool RemoveEnemy(Enemies enemy)
        {
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command =
                    new MySqlCommand($"DELETE FROM enemies WHERE Enemy_Name = \"{enemy.EnemyName}\"", connection);
                connection.Open();
                try
                {
                    var n = command.ExecuteNonQuery();
                    connection.Close();
                    return true;
                }
                catch (MySqlException ex)
                {
                    System.Windows.MessageBox.Show(ex.ToString());
                    connection.Close();
                    return false;
                }
            }
        }
    }
}
