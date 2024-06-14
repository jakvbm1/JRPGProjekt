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
    using System.Windows.Interop;

    class MainModel
    {
        public UsersModel usersModel;
        public CharactersModel charactersModel;
        public ClassesModel classesModel;
        public EnemiesModel enemiesModel;
        public ItemsModel itemsModel;
        public MainScreenModel msn;    
    public MainModel()
        {
            usersModel = new UsersModel();
            charactersModel = new CharactersModel();
            classesModel = new ClassesModel();
            enemiesModel = new EnemiesModel();
            itemsModel = new ItemsModel();
            msn = new MainScreenModel();
        }
    }
}
