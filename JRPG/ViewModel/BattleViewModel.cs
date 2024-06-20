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
        private Visibility isFinished = Visibility.Hidden;
        
        private string message;
        private bool enableButtons;


        public BattleViewModel(MainModel mainModel)
        {
            model = mainModel;
        }
        
        public BattleViewModel(MainModel mainModel, string chosen, int hp, int atak, int deff, ObservableCollection<Items> Eq_items)
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
            EnableButtons = true;



            ENname = enemy.EnemyName;

            
        }

        public Boolean EnableButtons { get { return enableButtons; } set { enableButtons = value; onPropertyChanged(nameof(EnableButtons)); } }
        public Visibility IsFinished { get { return isFinished; } set { isFinished = value; onPropertyChanged(nameof(IsFinished)); } }
        public int PL_ATK { get { return PLatk; } set { PLatk = value; onPropertyChanged(nameof(PL_ATK)); } }
        
        public int PL_DEF { get { return PLdef; } set { PLdef = value; onPropertyChanged(nameof(PL_DEF)); } }
        public string PL_CurrMaxHP { get { return PL_currMaxHP; } set { PL_currMaxHP = value; onPropertyChanged(nameof(PL_CurrMaxHP)); } }

        public int EN_ATK { get { return ENatk; } set { ENatk = value; onPropertyChanged(nameof(EN_ATK)); } }
        public int EN_DEF { get { return ENdef; } set { ENdef = value; onPropertyChanged(nameof(EN_DEF)); } }
        public string EN_CurrMaxHP { get { return EN_currMaxHP; } set { EN_currMaxHP = value; onPropertyChanged(nameof(EN_CurrMaxHP)); } }
        public string EN_NAME { get { return ENname; } set { ENname = value; onPropertyChanged(nameof(EN_NAME)); } }

       

        private void PL_CurrMaxhp()
        {
            
            PL_CurrMaxHP = player_curr_hp.ToString() + "/" + PLmax_hp.ToString();

        }

        private void EN_CurrMaxhp()
        {
            
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
        private bool enemy_attack()
        {
            
            int dif = EN_ATK - PL_DEF;
            int chance = 50 + 2 * dif;
            Console.WriteLine("szansa na atak wroga to - " + chance.ToString());
            int k = rnd.Next(1, 100);
            if (k <= chance)
                return true;

            return false;

        }


        private bool player_attack()
        {
            if (enemies.Count > 0)
            {
              
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
                          message = "";
                          if (player_attack())
                      {
                              message += "przeciwnik oberwał!";
                              enemy_curr_hp -= PL_ATK;
                              if(enemy_curr_hp < 0) enemy_curr_hp = 0;
                                EN_CurrMaxhp();
                              

                          if (enemy_curr_hp == 0) { MessageBox.Show("ale mu sprzedałeś bombę");
                                  IsFinished = Visibility.Visible;
                                  EnableButtons = false;



                              }

                          }

                          if (enemy_attack() && enemy_curr_hp!=0)
                          {
                              message+=("\nTrafil Cie!");
                              player_curr_hp -= ENatk;
                              if (player_curr_hp<0) player_curr_hp = 0;
                              PL_CurrMaxhp();
                              if (player_curr_hp == 0) { MessageBox.Show("przegrales :((");
                                  IsFinished = Visibility.Visible;
                                  EnableButtons = false;


                              }

                          }
                          if (!string.IsNullOrEmpty(message) && enemy_curr_hp>0 && player_curr_hp>0) MessageBox.Show(message);
                          if (string.IsNullOrEmpty(message) && enemy_curr_hp > 0 && player_curr_hp > 0)MessageBox.Show("Nikt nikogo nie uderzył");
                      },
                       arg => (1 > 0));


                return atakGracza;




            }
        }






    }
}
        
    

