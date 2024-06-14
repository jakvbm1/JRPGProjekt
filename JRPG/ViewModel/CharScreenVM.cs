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
        private List<Items> eq_items;
        private List<Items> uneq_items;
        private ObservableCollection<Equipment> equipment;
        private Classes user_class;
        private int hp, atk, def;
        private BitmapImage idle_sp, attack_sp, defense_sp;
        private string current_username;
        public BitmapImage Idle_sp { get {return idle_sp; } set { idle_sp = value; onPropertyChanged(nameof(Idle_sp)); } }
        public BitmapImage Attack_sp { get {return attack_sp; } set { attack_sp = value; onPropertyChanged(nameof(Attack_sp)); } }
        public BitmapImage Defense_sp { get {return defense_sp; } set { defense_sp = value; onPropertyChanged(nameof(Defense_sp)); } }
        public string Current_username { get { return current_username; } set { current_username = value; onPropertyChanged(nameof(Current_username)); } }

        public Characters User_char { get { return user_char; } set { user_char = value; onPropertyChanged(nameof(User_char)); } }
        public Classes User_class { get { return user_class; } set { user_class = value; onPropertyChanged(nameof(User_class)); } }
        public int HP { get { return hp; } set { hp = value; onPropertyChanged(nameof(HP)); } }
        public int ATK { get { return atk; } set { atk = value; onPropertyChanged(nameof(ATK)); } }
        public int DEF { get { return def; } set { def = value; onPropertyChanged(nameof(DEF)); } }
        public List<Items> Eq_items { get { return eq_items; } set { eq_items = value; onPropertyChanged(nameof(Eq_items)); } }
        public List<Items> Uneq_items { get { return uneq_items; } set { uneq_items = value; onPropertyChanged(nameof(Uneq_items)); } }

        public CharScreenVM(MainModel model)
        {
            User_char = GlobalVariables.current_user;
            Current_username = GlobalVariables.cur_username;
            Eq_items = new List<Items>();
            Uneq_items = new List<Items>();
            this.model = model;
           
            HP = 0; ATK = 0; DEF = 0;
            if (GlobalVariables.current_user != null)
            {
                User_class = model.classesModel.getUsersClass(GlobalVariables.current_user.Class_Name);
                load_equipment();
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
                Console.WriteLine(loaded_item.ItemID +" "+ loaded_item.Name +" "+loaded_item.Attack);
                Console.WriteLine(item.IsEquipped);

                if (item.IsEquipped)
                {
                    equipped.Add(loaded_item);
                }
                else
                {
                    unequipped.Add(loaded_item);
                }

            }

            Eq_items = model.msn.GetEquippedItems(User_char.CharId);
            Uneq_items = model.msn.GetUnEquippedItems(User_char.CharId);

            foreach(var item in equipped)
            {
                Console.WriteLine(item.ItemID + " debil");
            }
        }

        private void setupStats()
        {
            string bitmapuri = "pack://application:,,,/JRPG;component//sprites/characters/" + user_class.ClassName;

            Idle_sp = new BitmapImage(new Uri(bitmapuri+"/idle.png"));
            Attack_sp = new BitmapImage(new Uri(bitmapuri+"/atk.png"));
            Defense_sp = new BitmapImage(new Uri(bitmapuri+"/def.png"));



            ATK = User_class.Attack;
            DEF = User_class.Defense;
            HP = User_class.Health;

            foreach (var item in Eq_items)
            {
                ATK += item.Attack;
                DEF += item.Defense;
                HP += item.Max_hp;
            }
        }

    }
}
