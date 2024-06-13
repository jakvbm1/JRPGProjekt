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
    class MainModel
    {
        public UsersModel usersModel;
        public CharactersModel charactersModel;
        public ClassesModel classesModel;
        public ItemsModel itemsModel;
    
    public MainModel()
        {
            usersModel = new UsersModel();
            charactersModel = new CharactersModel();
            classesModel = new ClassesModel();
            itemsModel = new ItemsModel();
        }
    }
}
