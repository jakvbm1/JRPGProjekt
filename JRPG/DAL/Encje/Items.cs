using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JRPG.DAL.Encje
{
    public enum Kind
    {
        weapon,
        armor,
        accessory,
        consumable
    }
    public enum EquipableFor
    {
        mage,
        warrior,
        ranger,
        everyone
    }
    class Items
    {
        public int ItemID { get; set; }
        public int Cost { get; set; }
        public Kind Kind { get; set; }
        public EquipableFor EquipableFor { get; set; }

        public Items(MySqlDataReader reader)
        {
            ItemID = int.Parse(reader["ItemID"].ToString());
            Cost = int.Parse(reader["Cost"].ToString());
            string _Kind = reader["Kind"].ToString();
            if (_Kind == "weapon") Kind = Kind.weapon;
            else if (_Kind == "armor") Kind = Kind.armor;
            else if (_Kind == "accessory") Kind = Kind.accessory;
            else if (_Kind == "consumable") Kind = Kind.consumable;
            string Equip = reader["EquipableFor"].ToString();
            if (Equip == "mage") EquipableFor = EquipableFor.mage;
            else if (Equip == "warrior") EquipableFor = EquipableFor.mage;
            else if (Equip == "ranger") EquipableFor = EquipableFor.ranger;
            else if (Equip == "everyone") EquipableFor = EquipableFor.everyone;
        }
        public Items(int itemID, int cost, Kind kind, EquipableFor equipableFor)
        {
            ItemID = itemID;
            Cost = cost;
            Kind = kind;
            EquipableFor = equipableFor;
        }
    }
}
