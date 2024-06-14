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
        private string currMaxHP;
        private ObservableCollection<Enemies> enemies;
        static Random rnd = new Random();
        private int max_hp, curr_hp, atk, def;


        public BattleViewModel(MainModel mainModel, string chosen, int hp, int atak, int deff, List<Items> Eq_items)
        {
            model = mainModel;
            if (chosen == "easy") difficult = Difficulty.easy;
            else if (chosen == "medium") difficult = Difficulty.medium;
            else if (chosen == "hard") difficult = Difficulty.hard;
            max_hp = hp;
            curr_hp = hp;
            atk = atak;
            def = deff;
            CurrMaxhp();
        }

        public int HP { get { return curr_hp; } set { curr_hp = value; onPropertyChanged(nameof(HP)); } }
        public int ATK { get { return atk; } set { atk = value; onPropertyChanged(nameof(ATK)); } }
        public int DEF { get { return def; } set { def = value; onPropertyChanged(nameof(DEF)); } }
        public string CurrMaxHP { get { return currMaxHP; } set { currMaxHP = value; onPropertyChanged(nameof(CurrMaxHP)); } }


        private void CurrMaxhp()
        {
            // Console.WriteLine(max_hp);
            //  Console.WriteLine(curr_hp);
            //   Console.WriteLine("  ");
            currMaxHP = curr_hp.ToString() + "/" + max_hp.ToString();

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
                Console.WriteLine(enemy.EnemyName);
                int dif = atk - enemy.Defense;

                int chance = 70 + dif;
                 Console.WriteLine(chance);

                int k = rnd.Next(1, 100);
                Console.WriteLine(k);
                if (k <= chance)
                    return true;
                return false;
            }
            return false;


        }
        private ICommand init = null;
        public ICommand Init
        {

        get {
                if (init == null)
                    init = new RelayCommand(
                        arg => {
                            player = GlobalVariables.current_user;
                            enemies = model.enemiesModel.GetEnemiesByDifficulty(difficult);
                            Get_Enemy();
                            
                            if (player_attack())
                            {
                                Console.WriteLine("uderzyl");
                            }
                        },
                        arg => (1 > 0)

                        );



                return init;
            } 
        
        
        
        
        }





       
    }
}
        
    

