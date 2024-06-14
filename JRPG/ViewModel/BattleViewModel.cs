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
    using System.Windows.Media;
    using System.Collections.ObjectModel;
    using System.Windows.Documents;

    class BattleViewModel : ViewModelBase
    {
        private MainModel model;
        private Characters player;
        private Enemies enemy;
        private Difficulty difficult;
        private string PL_currMaxHP, EN_currMaxHP, ENname;
        private ObservableCollection<Enemies> enemies;
        static Random rnd = new Random();
        private int PLmax_hp, player_curr_hp, PLatk, PLdef, enemy_curr_hp, ENatk, ENdef, ENmax_hp;


        public BattleViewModel(MainModel mainModel)
        {
            model = mainModel;
        }
        
        public BattleViewModel(MainModel mainModel, string chosen, int hp, int atak, int deff, List<Items> Eq_items)
        {
            model = mainModel;
            if (chosen == "easy") difficult = Difficulty.easy;
            else if (chosen == "medium") difficult = Difficulty.medium;
            else if (chosen == "hard") difficult = Difficulty.hard;
            PLmax_hp = hp;
            player_curr_hp = hp;
            PLatk = atak;
            PLdef = deff;
            PL_CurrMaxhp();
            player = GlobalVariables.current_user;
            enemies = model.enemiesModel.GetEnemiesByDifficulty(difficult);
            Get_Enemy();
            enemy_curr_hp = enemy.Health;
            ENmax_hp = enemy.Health;
            ENdef = enemy.Defense;
            ENatk = enemy.Attack;
            Console.WriteLine(EN_ATK);
            EN_CurrMaxhp();
            PL_ATK -= 1;
            ENname = enemy.EnemyName;

            
        }

      
        public int PL_ATK { get { return PLatk; } set { PLatk = value; onPropertyChanged(nameof(PL_ATK)); } }
        
        public int PL_DEF { get { return PLdef; } set { PLdef = value; onPropertyChanged(nameof(PL_DEF)); } }
        public string PL_CurrMaxHP { get { return PL_currMaxHP; } set { PL_currMaxHP = value; onPropertyChanged(nameof(PL_CurrMaxHP)); } }

        public int EN_ATK { get { return ENatk; } set { ENatk = value; onPropertyChanged(nameof(EN_ATK)); } }
        public int EN_DEF { get { return ENdef; } set { ENdef = value; onPropertyChanged(nameof(EN_DEF)); } }
        public string EN_CurrMaxHP { get { return EN_currMaxHP; } set { EN_currMaxHP = value; onPropertyChanged(nameof(EN_CurrMaxHP)); } }
        public string EN_NAME { get { return ENname; } set { ENname = value; onPropertyChanged(nameof(EN_NAME)); } }

        private void PL_CurrMaxhp()
        {
            // Console.WriteLine(max_hp);
            //  Console.WriteLine(curr_hp);
            //   Console.WriteLine("  ");
            PL_CurrMaxHP = player_curr_hp.ToString() + "/" + PLmax_hp.ToString();

        }

        private void EN_CurrMaxhp()
        {
            // Console.WriteLine(max_hp);
            //  Console.WriteLine(curr_hp);
            //   Console.WriteLine("  ");
            EN_CurrMaxHP = enemy_curr_hp.ToString() + "/" + ENmax_hp.ToString();

        }


        private void Get_Enemy()
        {
            if (enemies.Count > 0)
            {
                int r = rnd.Next(enemies.Count);
                enemy = enemies[r];

            }


        }
        private bool player_attack()
        {
            if (enemies.Count > 0)
            {
               // Console.WriteLine(enemy.EnemyName);
                int dif = PL_ATK - EN_DEF;

                int chance = 50 +  4* dif;
                Console.WriteLine(chance);

                int k = rnd.Next(1, 100);
                Console.WriteLine(k);
                if (k <= chance)
                    return true;
                return false;
            }
            return false;
        }
        private ICommand atakGracza = null;
        public ICommand AtakGracza
        {
            get
            {
                if (atakGracza == null)
                    atakGracza = new RelayCommand(
                      arg =>
                      {
                          if (player_attack())
                          {
                              enemy_curr_hp -= PL_ATK;
                              EN_CurrMaxhp();
                              if (enemy_curr_hp <= 0) { MessageBox.Show("ale mu sprzedałeś bombę"); }
                          }
                         

                      },
                       arg => (1 > 0));


                return atakGracza;




            }
        }






    }
}
        
    

