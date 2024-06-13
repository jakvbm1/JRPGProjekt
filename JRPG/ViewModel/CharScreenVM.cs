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

    class CharScreenVM : ViewModelBase
    {
        private MainModel model;
        private Characters user_char;
        private ObservableCollection<Items> eq_items;
        private ObservableCollection<Items> uneq_items;
        private Classes user_class;
        private int hp, atk, def;
        private string idle_sp, attack_sp, defense_sp, current_username;
        public string Idle_sp { get {return idle_sp; } set { idle_sp = value; onPropertyChanged(nameof(Idle_sp)); } }
        public string Attack_sp { get {return attack_sp; } set { attack_sp = value; onPropertyChanged(nameof(Attack_sp)); } }
        public string Defense_sp { get {return defense_sp; } set { defense_sp = value; onPropertyChanged(nameof(Defense_sp)); } }
        public string Current_username { get { return current_username; } set { current_username = value; onPropertyChanged(nameof(Current_username)); } }

        public Characters User_char { get { return user_char; } set { user_char = value; onPropertyChanged(nameof(User_char)); } }
        public Classes User_class { get { return user_class; } set { user_class = value; onPropertyChanged(nameof(User_class)); } }
        public int HP { get { return hp; } set { hp = value; onPropertyChanged(nameof(HP)); } }
        public int ATK { get { return atk; } set { atk = value; onPropertyChanged(nameof(ATK)); } }
        public int DEF { get { return def; } set { def = value; onPropertyChanged(nameof(DEF)); } }

        public CharScreenVM(MainModel model)
        {
            User_char = GlobalVariables.current_user;
            Current_username = GlobalVariables.cur_username;
            this.model = model;
            HP = 0; ATK = 0; DEF = 0;
            if (GlobalVariables.current_user != null)
            {
                User_class = model.classesModel.getUsersClass(GlobalVariables.current_user.Class_Name);
                setupStats();
            }


        }

        private void setupStats()
        {
            Idle_sp = $"/sprites/characters/{user_class.SpriteSet}/idle.png";
            Attack_sp = "/sprites/characters/" + User_class.SpriteSet + "/atack.png";
            Defense_sp = "/sprites/characters/" + User_class.SpriteSet + "/def.png";

            ATK += User_class.Attack;
            DEF += User_class.Defense;
            HP += User_class.Health;
        }

        private ICommand onLoadSetup;

        public ICommand OnLoadSetup
        {
            get
            {
                if (onLoadSetup == null)
                {
                    onLoadSetup = new RelayCommand(arg =>
                    {
                        User_class = model.classesModel.getUsersClass(User_char.Class_Name);
                        setupStats();

                    }, arg => true);
                }
                return onLoadSetup;
            }
        }
    }
}
