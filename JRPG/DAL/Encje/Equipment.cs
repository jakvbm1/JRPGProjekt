﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JRPG.DAL.Encje
{
    class Equipment
    {
        public int ItemID { get; set; }
        public int Quantity { get; set; }
        public bool IsEquipped { get; set; }
        public string Username { get; set; }

        public Equipment(MySqlDataReader reader)
        {
            ItemID = int.Parse(reader["ItemID"].ToString());
            Quantity = int.Parse(reader["Quantity"].ToString());
            string IsEquip = reader["IsEquipped"].ToString();
            if (IsEquip == "1") IsEquipped = true;
            else if (IsEquip == "0") IsEquipped = false;
            Username = reader["Username"].ToString();
        }
        public Equipment(int itemID, int quantity, bool isEquipped, string username)
        {
            ItemID=itemID;
            Quantity = quantity;
            IsEquipped = isEquipped;
            Username = username;

        }
    }
}
