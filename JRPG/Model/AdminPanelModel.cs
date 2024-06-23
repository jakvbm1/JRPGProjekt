using JRPG.DAL.Encje;
using JRPG.DAL.Repozytoria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JRPG.Model
{
    class AdminPanelModel
    {
        public bool RemoveCharacter(Characters character)
        {
            return RepoCharacters.RemoveCharacter(character);
        }
        public bool RemoveItem(Items item)
        {
            return RepoItems.RemoveItem(item);
        }
        public bool RemoveEquipment(Equipment equipment)
        {
            return RepoEquipment.RemoveEquipment(equipment);
        }
        public bool RemoveEnemy(Enemies enemy)
        {
            return RepoEnemies.RemoveEnemy(enemy);
        }
        public bool RemoveClass(Classes _class)
        {
            return RepoClasses.RemoveClass(_class);
        }
    }
}
