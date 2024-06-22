using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JRPG.DAL.Encje;

namespace JRPG.Model
{
    class ItemWQ
    {
        public Items item { get; set; }
        public int quantity { get; set; }

        public ItemWQ(Items item, int quantity)
        {
            this.item = item;
            this.quantity = quantity;
        }
    }
}
