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


        public string Idle_sprite, Attack_sprite, Defense_sprite;

        public Characters User_char { get { return user_char; } set { user_char = value; onPropertyChanged(nameof(User_char)); } }
        public Classes User_class { get { return user_class; } set { user_class = value; onPropertyChanged(nameof(User_class)); } }
        public int HP { get { return hp; } set { hp = value; onPropertyChanged(nameof(HP)); } }
        public int ATK { get { return atk; } set { atk = value; onPropertyChanged(nameof(ATK)); } }
        public int DEF { get { return def; } set { def = value; onPropertyChanged(nameof(DEF)); } }

        public CharScreenVM(MainModel model)
        {
            User_char = GlobalVariables.current_user;
            this.model = model;
            //user_class = model.classesModel.getUsersClass(User_char.Class_Name);
            HP = 0; ATK = 0; DEF = 0;
        }
    }
}
