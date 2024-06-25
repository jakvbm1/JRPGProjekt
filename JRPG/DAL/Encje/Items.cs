using MySql.Data.MySqlClient;

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
        public string Name { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int Max_hp { get; set; }
        public int Regen_hp { get; set; }
        public string Sprite { get; set; }

        public Items(MySqlDataReader reader)
        {
            Name = reader["name"].ToString();
            ItemID = int.Parse(reader["ItemID"].ToString());
            Cost = int.Parse(reader["Cost"].ToString());
            string _Kind = reader["Kind"].ToString();
            if (_Kind == "weapon") Kind = Kind.weapon;
            else if (_Kind == "armor") Kind = Kind.armor;
            else if (_Kind == "accessory") Kind = Kind.accessory;
            else if (_Kind == "consumable") Kind = Kind.consumable;
            string Equip = reader["EquipableFor"].ToString();
            if (Equip == "mage") EquipableFor = EquipableFor.mage;
            else if (Equip == "warrior") EquipableFor = EquipableFor.warrior;
            else if (Equip == "ranger") EquipableFor = EquipableFor.ranger;
            else if (Equip == "everyone") EquipableFor = EquipableFor.everyone;
            Attack = int.Parse(reader["Attack"].ToString());
            Defense = int.Parse(reader["Defense"].ToString());
            Max_hp = int.Parse(reader["Max_hp"].ToString());
            Regen_hp = int.Parse(reader["Regen_hp"].ToString());
            Sprite = reader["Sprite"].ToString();
        }
        public Items(int itemID, int cost, Kind kind, EquipableFor equipableFor, string name, int attack, int defense, int max_hp, int regen_hp, string sprite)
        {
            ItemID = itemID;
            Cost = cost;
            Kind = kind;
            EquipableFor = equipableFor;
            Name = name;
            Attack = attack;
            Defense = defense;
            Max_hp = max_hp;
            Regen_hp = regen_hp;
            Sprite = sprite;
        }

        public Items(Items items)
        {
            ItemID = items.ItemID;
            Cost = items.Cost;
            Kind = items.Kind;
            EquipableFor = items.EquipableFor;
            Name = items.Name;
            Attack = items.Attack;
            Defense = items.Defense;
            Max_hp = items.Max_hp;  
            Regen_hp = items.Regen_hp;
            Sprite = items.Sprite;
        }
        public String toInsert()
        {
            return Name + " " + Regen_hp.ToString();
        }
       
    }
}
