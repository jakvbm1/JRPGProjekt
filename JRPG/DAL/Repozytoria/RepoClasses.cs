using JRPG.DAL.Encje;
using MySql.Data.MySqlClient;

namespace JRPG.DAL.Repozytoria
{
    class RepoClasses
    {
        private const string ALL_CLASSES = "SELECT * FROM classes";
        private const string ADD_CLASS = "INSERT INTO `classes` VALUES ";
        
        public static List<Classes> GetAllClasses()
        {
            List<Classes> classes = new List<Classes>();

            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand(ALL_CLASSES, connection);

                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                    classes.Add(new Classes(reader));
                connection.Close();
            }

            return classes;
        }
        public static bool RemoveClass(Classes _class)
        {
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command =
                    new MySqlCommand($"DELETE FROM classes WHERE Class_Name = \"{_class.ClassName}\"", connection);
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
