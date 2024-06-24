using JRPG.ViewModel.BaseClass;
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

    class CharScreenVM : ViewModelBase
    {
        private MainModel model;
        private Characters user_char;
        private ObservableCollection<ItemWQ> eq_items;
        private ObservableCollection<ItemWQ> uneq_items;
        private ObservableCollection<Equipment> equipment;
        private Classes user_class;
        private int hp, atk, def;
        private BitmapImage idle_sp, attack_sp, defense_sp;
        private string current_username, imageurl;
        private ItemWQ selected_eq, selected_uneq;
        private bool can_equip, admin, can_dequip, should_upt = true;


        public BitmapImage Idle_sp { get { return idle_sp; } set { idle_sp = value; onPropertyChanged(nameof(Idle_sp)); } }
        public BitmapImage Attack_sp { get { return attack_sp; } set { attack_sp = value; onPropertyChanged(nameof(Attack_sp)); } }
        public BitmapImage Defense_sp { get { return defense_sp; } set { defense_sp = value; onPropertyChanged(nameof(Defense_sp)); } }
        public string Current_username { get { return current_username; } set { current_username = value; onPropertyChanged(nameof(Current_username)); } }
        public Characters User_char { get { return user_char; } set { user_char = value; onPropertyChanged(nameof(User_char)); } }
        public Classes User_class { get { return user_class; } set { user_class = value; onPropertyChanged(nameof(User_class)); } }
        public int HP { get { return hp; } set { hp = value; onPropertyChanged(nameof(HP)); } }
        public int ATK { get { return atk; } set { atk = value; onPropertyChanged(nameof(ATK)); } }
        public int DEF { get { return def; } set { def = value; onPropertyChanged(nameof(DEF)); } }
        public ObservableCollection<ItemWQ> Eq_items { get { return eq_items; } set { eq_items = value; onPropertyChanged(nameof(Eq_items)); } }
        public ObservableCollection<ItemWQ> Uneq_items { get { return uneq_items; } set { uneq_items = value; onPropertyChanged(nameof(Uneq_items)); } }

        public bool Can_equip { get { return can_equip; } set { can_equip = value; onPropertyChanged(nameof(Can_equip)); } }
        public bool Can_dequip { get { return can_dequip; } set { can_dequip = value; onPropertyChanged(nameof(Can_dequip)); } }

        public bool Admin { get { return admin; } set { admin = value; onPropertyChanged(nameof(Admin)); } }

        public ItemWQ Selected_eq { get { return selected_eq; } set { selected_eq = value; Can_dequip = true; Can_equip = false;
                onPropertyChanged(nameof(Selected_eq)); updateImage();
            } }
        public ItemWQ Selected_uneq { get { return selected_uneq; } set { selected_uneq = value; Can_dequip = false; Can_equip = classAllignment();
                onPropertyChanged(nameof(Selected_uneq)); updateImage(); } }

        public String Imageurl { get { return imageurl; } set { imageurl = value; onPropertyChanged(nameof(Imageurl)); } }

        private bool classAllignment()
        {
            EquipableFor eqp;

            if(Enum.TryParse(User_class.ClassName.ToLower(), out eqp))
            {
            if(Selected_uneq != null && (Selected_uneq.item.EquipableFor == EquipableFor.everyone || Selected_uneq.item.EquipableFor == eqp))
            {
                return true;
            }
            }
            Console.WriteLine(Enum.TryParse(User_class.ClassName.ToLower(), out eqp));
            return false;
        }

        public CharScreenVM(MainModel model)
        {
            can_equip = false; can_dequip = false;
            User_char = GlobalVariables.current_user;
            Current_username = GlobalVariables.cur_username;
            Admin = GlobalVariables.isadmin;
            Eq_items = new ObservableCollection<ItemWQ>();
            Uneq_items = new ObservableCollection<ItemWQ>();
            this.model = model;

            HP = 0; ATK = 0; DEF = 0;
            if (GlobalVariables.current_user != null)
            {
                User_class = model.classesModel.getUsersClass(GlobalVariables.current_user.Class_Name);
                load_equipment();
                setupSprites();
                setupStats();
            }


        }

        private void load_equipment()
        {
            equipment = model.msn.GetUsersEquipment(User_char.CharId);
            List<Items> equipped = new List<Items>();
            List<Items> unequipped = new List<Items>();

            foreach (var item in equipment)
            {
                Items loaded_item = model.msn.GetItemByID(item.ItemID);
               // Console.WriteLine(loaded_item.ItemID + " " + loaded_item.Name + " " + loaded_item.Attack);
                //Console.WriteLine(item.IsEquipped);

                if (item.IsEquipped)
                {
                    equipped.Add(loaded_item);
                }
                else
                {
                    unequipped.Add(loaded_item);
                }

            }

            Can_equip = false; Can_dequip = false;

            Eq_items = model.msn.GetEquippedItems(User_char.CharId);
            Uneq_items = model.msn.GetUnEquippedItems(User_char.CharId);

        }

        private void setupSprites()
        {
            string bitmapuri = "pack://application:,,,/JRPG;component//sprites/characters/" + user_class.ClassName;

            Idle_sp = new BitmapImage(new Uri(bitmapuri + "/idle.png"));
            Attack_sp = new BitmapImage(new Uri(bitmapuri + "/atk.png"));
            Defense_sp = new BitmapImage(new Uri(bitmapuri + "/def.png"));

        }

        private void setupStats()
        {
            ATK = (int)((9 + User_char.ExpLevel) * User_class.Attack / 10);
            DEF = (int)((9 + User_char.ExpLevel) * User_class.Defense / 10);
            HP = (int)((9 + User_char.ExpLevel) * User_class.Health / 10);

            foreach (var item in Eq_items)
            {
                ATK += item.item.Attack;
                DEF += item.item.Defense;
                HP += item.item.Max_hp;
            }
        }   

        private void updateImage()
        {
            if (should_upt)
            {
                if (Can_dequip)
                    Imageurl = $"/sprites/items/{Selected_eq.item.Sprite}.png";
                else if (Selected_uneq is not null)
                    Imageurl = $"/sprites/items/{Selected_uneq.item.Sprite}.png";
            }
        }

        private ICommand dequip;
        public ICommand Dequip { get { if (dequip == null)
                    dequip = new RelayCommand(arg =>
                    {
                        if (model.msn.Dequip_item(Selected_eq.item.ItemID, User_char.CharId))
                        {
                            
                            should_upt = false;
                            Can_dequip = false;
                            Can_equip = false;
                            load_equipment();
                            should_upt = true;
                            setupStats();
                        }
                    }, arg => true);
                return dequip;
            } }

        private ICommand equip;
        public ICommand Equip
        {
            get
            {
                if (equip == null)
                    equip = new RelayCommand(arg =>
                    {
                        bool succes = false;
                        foreach(var item in Eq_items)
                        {
                            if(item.item.Kind == Selected_uneq.item.Kind)
                            {
                                succes = model.msn.Dequip_item(item.item.ItemID, User_char.CharId);
                                break;
                            }
                        }

                        if (model.msn.Equip_item(Selected_uneq.item.ItemID, User_char.CharId) )
                        {
                            should_upt = false;
                            Can_dequip = false;
                            Can_equip = false;
                            load_equipment();
                            should_upt = true;
                            setupStats();
                        }
                    }, arg => true);
                return equip;
            }
        }

        public ObservableCollection<Items> GetEquipped()
        {
            ObservableCollection<Items> items = new ObservableCollection<Items>();
            foreach (var item in Eq_items) { items.Add(item.item); }
            return items;
        }
    }
}
