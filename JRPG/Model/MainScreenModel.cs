﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JRPG.Model
{
    using DAL.Encje;
    using DAL.Repozytoria;
    using System.Collections.ObjectModel;
    class MainScreenModel
    {
        public ObservableCollection<Items> AllItems { get; set; } = new ObservableCollection<Items>();
        public ObservableCollection<Equipment> AllEquipment { get; set; } = new ObservableCollection<Equipment>();

        public MainScreenModel()
        {
            var allitems = RepoItems.GetAllItems();
            var alleq = RepoEquipment.GetAllEquipment();

            foreach (var item in allitems)
            {
                AllItems.Add(item);
                //Console.WriteLine(item.ItemID);
            }

            foreach (var eq in alleq)
            {
                AllEquipment.Add(eq);
            }
        }

        public ObservableCollection<Equipment> GetUsersEquipment(int userId)
        {
            var eq =  new ObservableCollection<Equipment>();
            foreach (var  q in AllEquipment)
            {
                if (q.CharID == userId)
                {
                    eq.Add(q);
                }
            }
            return eq;
        }

        public Items GetItemById(int itemID)
        {
            foreach (var item in AllItems) 
            {
                if(itemID == item.ItemID)
                {
                return item;
                }
            }
            return null;
        }

        public List<Items> GetEquippedItems(int userId)
        {
            var items = new List<Items>();
            var eq = GetUsersEquipment(userId);

            foreach (var item in eq)
            {
                if (item.IsEquipped)
                {
                    Items itemToAdd = GetItemById(item.ItemID);
                    if(itemToAdd != null)
                    items.Add(itemToAdd);
                }
            }
            return items;
        }

        public List<Items> GetUnEquippedItems(int userId)
        {
            var items = new List<Items>();
            var eq = GetUsersEquipment(userId);

            foreach (var item in eq)
            {
                if (!item.IsEquipped)
                {
                    Items itemToAdd = GetItemById(item.ItemID);
                    if (itemToAdd != null)
                        items.Add(itemToAdd);
                }
            }
            return items;
        }

        public Items GetItemByID(int itemID)
        {
            foreach (var item in AllItems)
            {
                if (item.ItemID == itemID)
                { return item; }
                
            }
            return null;
        }

    }

    
}
