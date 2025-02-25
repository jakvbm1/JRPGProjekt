﻿using JRPG.DAL.Encje;
using JRPG.DAL.Repozytoria;
using System.Collections.ObjectModel;

namespace JRPG.Model
{
    class ShopScreenModel
    { 

        public bool UpdateGold(Characters character, int cost)
        {
            return RepoCharacters.UpdateGold(character, cost);
        }

        public bool AddItem(int itemid, int userid)
        {
            return RepoEquipment.AddItem(itemid, userid);
        }

        public bool UpdateQuantity(int itemid, int userid, int quantity)
        {
            return RepoEquipment.UpdateQuantity(itemid, userid, quantity);
        }

        public ObservableCollection<Equipment> GetUsersEquipment(int userId)
        {
            ObservableCollection<Equipment> equipment = [.. RepoEquipment.GetUsersEquipment(userId)];
            return equipment;
        }
    }
}
