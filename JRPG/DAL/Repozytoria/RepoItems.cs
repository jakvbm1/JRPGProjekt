using JRPG.DAL.Encje;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JRPG.DAL.Repozytoria
{
     class RepoItems
    {
        private const string ALL_ITEMS = "SELECT * FROM items";
        private const string ADD_ITEM = "INSERT INTO `items` VALUES ";

        public static List<Items> GetAllItems()
        {
            List<Items> items = new List<Items>();

            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand(ALL_ITEMS, connection);

                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                    items.Add(new Items(reader));
                connection.Close();
            }

            return items;
        }

    }
}
