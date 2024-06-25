namespace JRPG.ViewModel
{
    using BaseClass;
    using DAL.Encje;
    using JRPG.DAL.Repozytoria;
    using Model;
    using System.Collections.ObjectModel;
    using System.Windows;
    using System.Windows.Input;

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
        private Characters user_char;

        public AdminVM(MainModel model)
        {
            this.model = model;
            user_char = GlobalVariables.current_user;
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
                            if (SelectedCharacter != null && user_char != SelectedCharacter)
                            {
                                var character = SelectedCharacter;
                                model.adminPanelModel.RemoveEquipmentByCharId(character.CharId);
                                model.adminPanelModel.RemoveCharacter(character);
                                model.adminPanelModel.RemoveUser(character.Usermail);
                                Characters.Remove(character);
                                foreach (var user in Users)
                                {
                                    if (user.Email == character.Usermail)
                                    {
                                        Users.Remove(user);
                                        break;
                                    }
                                }
                                ObservableCollection<Equipment> remove_equip = new ObservableCollection<Equipment>();
                                foreach (var eq in Equipment)
                                {
                                    if (eq.CharID == character.CharId)
                                        remove_equip.Add(eq);
                                }
                                foreach (var eq in remove_equip)
                                    Equipment.Remove(eq);
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
                                ObservableCollection<Equipment> remove_equip = new ObservableCollection<Equipment>();
                                foreach (var eq in Equipment)
                                {
                                    if (eq.ItemID == SelectedItem.ItemID)
                                        remove_equip.Add(eq);
                                }
                                foreach (var eq in remove_equip)
                                {
                                    model.adminPanelModel.RemoveEquipment(eq);
                                    Equipment.Remove(eq);
                                }
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
        
    }
}
