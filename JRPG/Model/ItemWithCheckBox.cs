using JRPG.DAL.Encje;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JRPG.Model
{
    class ItemWithCheckBox
    {
        public Items Item { get; set; }
        public bool IsChecked { get; set; }
    }
}
