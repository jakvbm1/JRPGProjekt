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
        private const string UPDATE_TABLE = "UPDATE characters";
       
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
         
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command =
                    new MySqlCommand($"{ADD_CHARACTER} ('{characters.CharId}', '{characters.Usermail}', '{characters.ExpLevel}', '{characters.Gold}', '{characters.Class_Name}')", connection);
                connection.Open();
                try { var n = command.ExecuteNonQuery(); 
                    connection.Close();
                    return true;
                
                }
                catch (MySql.Data.MySqlClient.MySqlException ex)
                {
                    System.Windows.MessageBox.Show("1111111");
                    connection.Close();
                    return false;

                }
               
            }
            
        }    
        public static bool UpdateGoldAndLevel (string difficulty, Characters characters)
        {

           
            int new_level = characters.ExpLevel+1;
            
            int new_gold = characters.Gold;
            if(difficulty == "easy") { new_gold += 10; }
            if (difficulty == "medium") { new_gold += 30; }
            if (difficulty == "hard") { new_gold += 100; }

          
            
            using (var connection = DBConnection.Instance.Connection)
            {
                
                MySqlCommand command= 
                    new MySqlCommand($"{UPDATE_TABLE} set Gold ={new_gold}, EXP_Level={new_level} WHERE CharID={characters.CharId}",connection);
                connection.Open();
                try { var n = command.ExecuteNonQuery();
                  
                    
                    connection.Close();
                  
                    return true;
                }
                catch (MySql.Data.MySqlClient.MySqlException ex)
                {
                    System.Windows.MessageBox.Show (ex.ToString().Substring(0,20));
                    connection.Close();
                    return false;
                }
                
            }

                
        }
        public static bool UpdateGold(Characters characters, int cost)
        {
            int new_gold = characters.Gold - cost;

            using (var connection = DBConnection.Instance.Connection)
            {

                MySqlCommand command =
                    new MySqlCommand($"{UPDATE_TABLE} set Gold = {new_gold} WHERE CharID = {characters.CharId}", connection);
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
        public static bool RemoveCharacter(Characters character)
        {
            using (var connection = DBConnection.Instance.Connection)
            {

                MySqlCommand command =
                    new MySqlCommand($"DELETE FROM characters WHERE CharId = {character.CharId}", connection);
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
