using JRPG.DAL.Encje;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    }
}
