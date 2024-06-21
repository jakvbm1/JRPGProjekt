using JRPG.DAL.Encje;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JRPG.DAL.Repozytoria
{
    class RepoEquipment
    {
        private const string ALL_EQUIPMENTS = "SELECT * FROM equipment";
        private const string ADD_EQUIPMENT = "INSERT INTO `equipment` VALUES ";

        public static List<Equipment> GetAllEquipment()
        {
            List<Equipment> equipment = new List<Equipment>();

            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand(ALL_EQUIPMENTS, connection);

                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                    equipment.Add(new Equipment(reader));
                connection.Close();
            }

            return equipment;
        }

        public static bool Dequip(int itemid, int userid)
        {
            string upt = $"UPDATE equipment set IsEquipped = 0 where ItemID = {itemid} and CharId = {userid};";


            bool check = false;
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command =
                    new MySqlCommand(upt, connection);
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

        public static bool Equip(int itemid, int userid)
        {
            string upt = $"UPDATE equipment set IsEquipped = 1 where ItemID = {itemid} and CharId = {userid} ;";


            bool check = false;
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command =
                    new MySqlCommand(upt, connection);
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
        public static bool AddItem(int itemid, int userid)
        {
            string upt = $"{ADD_EQUIPMENT}({itemid}, 1, 0, {userid});";


            bool check = false;
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command =
                    new MySqlCommand(upt, connection);
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
