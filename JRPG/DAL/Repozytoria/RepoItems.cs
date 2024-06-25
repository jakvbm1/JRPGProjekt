using JRPG.DAL.Encje;
using MySql.Data.MySqlClient;

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

        public static bool RemoveItem(Items item)
        {
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command =
                    new MySqlCommand($"DELETE FROM items WHERE ItemID = {item.ItemID}", connection);
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
