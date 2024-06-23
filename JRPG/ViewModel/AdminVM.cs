using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JRPG.ViewModel
{
    using DAL.Encje;
    using Model;
    using BaseClass;
    using System.Windows.Input;
    using System.Runtime.CompilerServices;
    using System.Windows;
    using JRPG.DAL.Repozytoria;
    using System.Collections.ObjectModel;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using MySql.Data.MySqlClient;
    using Org.BouncyCastle.Math;
    class AdminVM : ViewModelBase
    {
        private MainModel model;
        private ObservableCollection<Items> items;
        private ObservableCollection<Equipment> equipment;
        private ObservableCollection<Classes> classes;
        private ObservableCollection<Enemies> enemies;
        private ObservableCollection<Users> users;
        private ObservableCollection<Characters> characters;

        public AdminVM(MainModel model)
        {
            this.model = model;
            Items = new ObservableCollection<Items>();
            Equipment = new ObservableCollection<Equipment>();
            Classes = new ObservableCollection<Classes>();
            Enemies = new ObservableCollection<Enemies>();
            Users = new ObservableCollection<Users>();
            Characters = new ObservableCollection<Characters>();
            loadAll();
        }

        public void loadAll()
        {
            Items = model.itemsModel.AllItems;
            Equipment = model.msn.AllEquipment;
            Classes = model.classesModel.AllClasses;
            Enemies = model.enemiesModel.AllEnemies;
            Users = model.usersModel.AllUsers;
            Characters = model.charactersModel.AllCharacters;
        }

        public ObservableCollection<Items> Items { get { return items; } set { items = value; onPropertyChanged(nameof(Items)); } }
        public ObservableCollection<Equipment> Equipment { get { return equipment; } set { equipment = value; onPropertyChanged(nameof(Equipment)); } }
        public ObservableCollection<Classes> Classes { get { return classes; } set { classes = value; onPropertyChanged(nameof(Classes)); } }

        public ObservableCollection<Enemies > Enemies { get { return enemies; } set { enemies = value; onPropertyChanged( nameof(Enemies)); } }
        public ObservableCollection<Users> Users { get { return users; } set { users = value; onPropertyChanged(nameof(Users)); } }
        public ObservableCollection<Characters > Characters { get { return characters; } set { characters = value; onPropertyChanged(nameof (Characters)); } }
    }
}
