using JRPG.DAL.Encje;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
