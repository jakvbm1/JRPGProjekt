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
        public static bool AddCharacterToDatabase(Characters characters)
        {
            bool check = false;
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command =
                    new MySqlCommand($"{ADD_CHARACTER} ('{characters.CharId}', '{characters.Usermail}', '{characters.ExpLevel}', '{characters.Gold}', '{characters.Class_Name}')", connection);
                connection.Open();
                try { var n = command.ExecuteNonQuery(); }
                catch (MySql.Data.MySqlClient.MySqlException ex)
                {
                    System.Windows.MessageBox.Show(ex.ToString());
                    connection.Close();
                    return false;

                }
                check = true;

                connection.Close();
            }
            return check;
        }    
    
    
    }
}
