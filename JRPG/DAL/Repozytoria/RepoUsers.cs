using JRPG.DAL.Encje;
using MySql.Data.MySqlClient;

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
                    System.Windows.MessageBox.Show(ex.ToString().Substring(51, 49));
                    connection.Close();
                    return false;
                    
                }
                check = true;
                
                connection.Close();
            }
            return check;
        }
        public static bool UpdateAdmin(Users user)
        {
            bool check = false;
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command =
                    new MySqlCommand($"UPDATE users SET PlayerOrAdmin = 1 WHERE Email = \"{user.Email}\"", connection);
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
        public static bool RemoveUser(string email)
        {
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command =
                    new MySqlCommand($"DELETE FROM users WHERE Email = \"{email}\"", connection);
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
