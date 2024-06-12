using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JRPG.DAL.Encje;

namespace JRPG.DAL.Repozytoria
{
    class RepoUsers
    {
        private const string ALL_USERS = "SELECT * FROM users";
        private const string ADD_USER = "INSERT INTO `users` VALUES ";

        public static List<Users> GetAllUsers()
        {
            List<Users> users = new List<Users>();

            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand(ALL_USERS, connection);
                
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                    users.Add(new Users(reader));
                connection.Close();
            }

            return users;
        }
        public static bool AddUserToDatabase(Users user)
        {
            bool check = false;
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command =
                    new MySqlCommand($"{ADD_USER} {user.ToInsert()}", connection);
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
