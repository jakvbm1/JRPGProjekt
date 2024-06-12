using Fantasia.DAL.Encje;
using JRPG.DAL.Encje;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JRPG.DAL.Repozytoria
{
     class RepoCharacters
    {
        private const string ALL_CHARACTERS = "SELECT * FROM characters";
        private const string ADD_CHARACTER = "INSERT INTO `characters` VALUES ";
       
        public static List<Characters> GetAllCharacters()
        {
            List<Characters> characters = new List<Characters>();

            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand(ALL_CHARACTERS, connection);

                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                    characters.Add(new Characters(reader));
                connection.Close();
            }

            return characters;
        }
        }
}
