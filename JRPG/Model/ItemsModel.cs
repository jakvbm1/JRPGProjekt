using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JRPG.Model
{
    using DAL.Encje;
    using DAL.Repozytoria;
    using System.Collections.ObjectModel;
    class ItemsModel
    {

        public ObservableCollection<Items> AllItems { get; set; } = new ObservableCollection<Items>();

        public ItemsModel()
        {
            var allitems = RepoItems.GetAllItems();
            foreach (var c in allitems)
            {
                AllItems.Add(c);
            }
        }
        public int? GetIdFromName (string name)
        {
            foreach (var c in AllItems) {
                if (c.Name == name) return c.ItemID;
            }
            return null;
        }
    }
}
