using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JRPG.Model;

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
    using Org.BouncyCastle.Bcpg;

    class AdminVM : ViewModelBase
    {
        private MainModel model;
        private ObservableCollection<Items> items;
        private ObservableCollection<Equipment> equipment;
        private ObservableCollection<Classes> classes;
        private ObservableCollection<Enemies> enemies;
        private ObservableCollection<Users> users;
        private ObservableCollection<Characters> characters;
        private Users selectedUser;
        private Characters selectedCharacter;
        private Items selectedItem;
        private Equipment selectedEquipment;
        private Enemies selectedEnemies;
        private Classes selectedClasses;

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
        public Users SelectedUser { get { return selectedUser; } set { selectedUser = value; onPropertyChanged(nameof(SelectedUser)); } }
        public Characters SelectedCharacter { get { return selectedCharacter; } set { selectedCharacter = value; onPropertyChanged(nameof(SelectedCharacter)); } }
        public Items SelectedItem { get { return selectedItem; } set { selectedItem = value; onPropertyChanged(nameof(SelectedItem)); } }
        public Equipment SelectedEquipment { get { return selectedEquipment; } set { selectedEquipment = value; onPropertyChanged(nameof(SelectedEquipment)); } }
        public Enemies SelectedEnemies { get { return selectedEnemies; } set { selectedEnemies = value; onPropertyChanged(nameof(SelectedEnemies)); } }
        public Classes SelectedClasses { get { return selectedClasses; } set { selectedClasses = value; onPropertyChanged(nameof(SelectedClasses)); } }


        private ICommand setAdmin = null;
        public ICommand SetAdmin
        {
            get
            {
                if (setAdmin == null)
                {
                    setAdmin = new RelayCommand(
                        arg =>
                        {
                            if (selectedUser != null)
                            {
                                if (!SelectedUser.IsAdmin)
                                {
                                    model.usersModel.UpdateAdmin(SelectedUser);
                                    var user = SelectedUser;
                                    user.IsAdmin = true;
                                    Users.Remove(SelectedUser);
                                    Users.Add(user);
                                }
                                else
                                {
                                    MessageBox.Show("Wybrany użytkownik jest już adminem.");
                                }
                            }
                        },
                        arg => true);
                }
                return setAdmin;
            }
        }
        private ICommand delUser = null;
        public ICommand DelUser
        {
            get
            {
                if (delUser == null)
                {
                    delUser = new RelayCommand(
                        arg =>
                        {
                            if (SelectedCharacter != null)
                            {
                                model.adminPanelModel.RemoveCharacter(SelectedCharacter);
                                Characters.Remove(SelectedCharacter);
                            }
                        },
                        arg => true);
                }
                return delUser;
            }
        }
        private ICommand delItem = null;
        public ICommand DelItem
        {
            get
            {
                if (delItem == null)
                {
                    delItem = new RelayCommand(
                        arg =>
                        {
                            if (SelectedItem != null)
                            {
                                model.adminPanelModel.RemoveItem(SelectedItem);
                                Items.Remove(SelectedItem);
                            }
                        },
                        arg => true);
                }
                return delItem;
            }
        }
        private ICommand delEquip = null;
        public ICommand DelEquip
        {
            get
            {
                if (delEquip == null)
                {
                    delEquip = new RelayCommand(
                        arg =>
                        {
                            if (SelectedEquipment != null)
                            {
                                model.adminPanelModel.RemoveEquipment(SelectedEquipment);
                                Equipment.Remove(SelectedEquipment);
                            }
                        },
                        arg => true);
                }
                return delEquip;
            }
        }
        private ICommand delEnemy = null;
        public ICommand DelEnemy
        {
            get
            {
                if (delEnemy == null)
                {
                    delEnemy = new RelayCommand(
                        arg =>
                        {
                            if (SelectedEnemies != null)
                            {
                                model.adminPanelModel.RemoveEnemy(SelectedEnemies);
                                Enemies.Remove(SelectedEnemies);
                            }
                        },
                        arg => true);
                }
                return delEnemy;
            }
        }
        private ICommand delClass = null;
        public ICommand DelClass
        {
            get
            {
                if (delClass == null)
                {
                    delClass = new RelayCommand(
                        arg =>
                        {
                            if (SelectedClasses != null)
                            {
                                model.adminPanelModel.RemoveClass(SelectedClasses);
                                Classes.Remove(SelectedClasses);
                            }
                        },
                        arg => true);
                }
                return delClass;
            }
        }
    }
}
