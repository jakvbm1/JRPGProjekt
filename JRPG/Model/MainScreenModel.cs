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

        public ObservableCollection<ItemWQ> GetEquippedItems(int userId)
        {
            var items = new ObservableCollection<ItemWQ>();
            var eq = GetUsersEquipment(userId);

            foreach (var item in eq)
            {
                if (item.IsEquipped)
                {
                    Items itemToAdd = GetItemById(item.ItemID);
                    if(itemToAdd != null)
                    items.Add(new ItemWQ(itemToAdd, item.Quantity));
                }
            }
            return items;
        }

        public ObservableCollection<ItemWQ> GetUnEquippedItems(int userId)
        {
            var items = new ObservableCollection<ItemWQ>();
            var eq = GetUsersEquipment(userId);

            foreach (var item in eq)
            {
                if (!item.IsEquipped)
                {
                    Items itemToAdd = GetItemById(item.ItemID);
                    if (itemToAdd != null)
                        items.Add(new ItemWQ(itemToAdd, item.Quantity));
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

        public bool Dequip_item(int itemID, int userId)
        {
            if (RepoEquipment.Dequip(itemID, userId))
            { refresh_eq(); }
            return RepoEquipment.Dequip(itemID, userId);
        }

        public bool Equip_item(int itemID, int userID)
        {
            if (RepoEquipment.Equip(itemID, userID))
            { refresh_eq(); }
            return RepoEquipment.Equip(itemID, userID);
        }

        private void refresh_eq()
        {
            AllEquipment.Clear();
            var alleq = RepoEquipment.GetAllEquipment();
            foreach (var eq in alleq)
            {
        
                AllEquipment.Add(eq);
            }
            
        }
        public bool RemoveEquipmentByCharIdAndItemId(int ItemID, int CharID)
        {
            if(RepoEquipment.RemoveEquipmentByCharIdAndItemId(ItemID, CharID)){
                refresh_eq();
                return true;

            }
            return false;
            
        }
    }
}
