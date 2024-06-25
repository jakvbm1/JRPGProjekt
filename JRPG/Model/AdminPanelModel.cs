using JRPG.DAL.Encje;
using JRPG.DAL.Repozytoria;

namespace JRPG.Model
{
    class AdminPanelModel
    {
        public bool RemoveEquipmentByCharId(int CharID)
        {
            return RepoEquipment.RemoveEquipmentByCharId(CharID);
        }
        public bool RemoveCharacter(Characters character)
        {
            return RepoCharacters.RemoveCharacter(character);
        }
        public bool RemoveUser(string email)
        {
            return RepoUsers.RemoveUser(email);
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
