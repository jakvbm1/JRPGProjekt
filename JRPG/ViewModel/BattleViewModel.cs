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
        private ItemWQ usedItem;
        private ObservableCollection<ItemWQ> Eq_items;
        private string plIdle, plAttack, plDeffense, enIdle, enAttack, plGraf, enGraf;
        private int PLmax_hp, player_curr_hp, PLatk, PLdef, enemy_curr_hp, ENatk, ENdef, ENmax_hp;
        private Visibility isFinished = Visibility.Hidden;
        private string ensprite;
        
        private string plmessage, enmessage;
        private bool enableButtons, fight;


        public BattleViewModel(MainModel mainModel)
        {
            model = mainModel;
        }
        
        public BattleViewModel(MainModel mainModel, string chosen, int hp, int atak, int deff, ObservableCollection<ItemWQ> eq_items)
        {
            
            model = mainModel;
            if (chosen == "easy") difficult = Difficulty.easy;
            else if (chosen == "medium") difficult = Difficulty.medium;
            else if (chosen == "hard") difficult = Difficulty.hard;
            PLmax_hp = hp;
            player_curr_hp = hp;
            PLatk = atak;
            PLdef = deff;
            Eq_items = eq_items;
            foreach (ItemWQ eq_item in Eq_items) //Console.WriteLine(eq_item.quantity);

            

            

            PL_CurrMaxhp();
            player = GlobalVariables.current_user;


            plIdle = $"/sprites/characters/{player.Class_Name.ToLower()}/idle.png";
            plAttack = $"/sprites/characters/{player.Class_Name.ToLower()}/atk.png";
            plDeffense = $"/sprites/characters/{player.Class_Name.ToLower()}/def.png";



            PlGraf = plIdle;
           


            enemies = model.enemiesModel.GetEnemiesByDifficulty(difficult);
            Get_Enemy();

            enemy_curr_hp = enemy.Health;
            ENmax_hp = enemy.Health;
            ENdef = enemy.Defense;
            ENatk = enemy.Attack;
            enIdle = $"/sprites/enemies/{enemy.SpriteSet}/idle.png";
            enAttack = $"/sprites/enemies/{enemy.SpriteSet}/atk.png";
            EnGraf = enIdle;
            EN_CurrMaxhp();
            EnableButtons = true;



            ENname = enemy.EnemyName;

            
        }
        public string PlGraf { get { return plGraf; } set { plGraf = value; onPropertyChanged(nameof(PlGraf)); } }
        public string EnGraf { get { return enGraf; } set { enGraf = value; onPropertyChanged(nameof(EnGraf)); } }
       
    


        public Boolean EnableButtons { get { return enableButtons; } set { enableButtons = value; onPropertyChanged(nameof(EnableButtons)); } }
        public Visibility IsFinished { get { return isFinished; } set { isFinished = value; onPropertyChanged(nameof(IsFinished)); } }
        public int PL_ATK { get { return PLatk; } set { PLatk = value; onPropertyChanged(nameof(PL_ATK)); } }
        
        public int PL_DEF { get { return PLdef; } set { PLdef = value; onPropertyChanged(nameof(PL_DEF)); } }
        public string PL_CurrMaxHP { get { return PL_currMaxHP; } set { PL_currMaxHP = value; onPropertyChanged(nameof(PL_CurrMaxHP)); } }

        public int EN_ATK { get { return ENatk; } set { ENatk = value; onPropertyChanged(nameof(EN_ATK)); } }
        public int EN_DEF { get { return ENdef; } set { ENdef = value; onPropertyChanged(nameof(EN_DEF)); } }
        public string EN_CurrMaxHP { get { return EN_currMaxHP; } set { EN_currMaxHP = value; onPropertyChanged(nameof(EN_CurrMaxHP)); } }
        public string EN_NAME { get { return ENname; } set { ENname = value; onPropertyChanged(nameof(EN_NAME)); } }

       public string Ensprite { get { return ensprite; } set { ensprite = value; onPropertyChanged(nameof(Ensprite)); } } 

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
            int chance = 60 + 2 * dif;
            
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

                int chance = 65 +  4* dif;
            

                int k = rnd.Next(1, 100);
               
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
                          fight = true;
                          plmessage = "";
                          enmessage = "";
                          
                          if (player_attack())
                      {
                             fight = false;
                              PlGraf = plAttack;

                              enemy_curr_hp -= PL_ATK;


                              if (enemy_curr_hp < 0) {
                                  enemy_curr_hp = 0;
                                  EN_CurrMaxhp();
                                  MessageBox.Show("ale mu sprzedałeś bombę");
                                  PlGraf = plIdle;
                                  IsFinished = Visibility.Visible;
                                  EnableButtons = false;
                                  if (usedItem != null) {
                                      if (usedItem.quantity == 0 && model.msn.RemoveEquipmentByCharIdAndItemId(usedItem.item.ItemID, GlobalVariables.current_user.CharId)) { }
                                      if (usedItem.quantity != 0 && model.shopScreenModel.UpdateQuantity(usedItem.item.ItemID, GlobalVariables.current_user.CharId, usedItem.quantity - 1)) { }
                                  }


                                  if (model.charactersModel.UpdateGoldAndLevel(difficult.ToString(), GlobalVariables.current_user)) { }
                                  

                              }
                              else
                              {
                                  MessageBox.Show("przeciwnik oberwał!");
                                  EN_CurrMaxhp();
                                  PlGraf = plIdle;
                              }
                          }

                          if (enemy_attack() && enemy_curr_hp!=0)
                          {
                              EnGraf = enAttack;
                              player_curr_hp -= ENatk;
                              fight = false;
                              if (player_curr_hp <= 0)
                              {
                                  player_curr_hp = 0;
                                  PL_CurrMaxhp();
                                  MessageBox.Show("przegrales :((");
                                  if (usedItem != null)
                                  {
                                      if (usedItem.quantity == 0 && model.msn.RemoveEquipmentByCharIdAndItemId(usedItem.item.ItemID, GlobalVariables.current_user.CharId)) { }
                                      if (usedItem.quantity != 0 && model.shopScreenModel.UpdateQuantity(usedItem.item.ItemID, GlobalVariables.current_user.CharId, usedItem.quantity - 1)) { }
                                  }
                                  IsFinished = Visibility.Visible;
                                  EnableButtons = false;
                                  EnGraf = enIdle;
                                  
                              }
                              else {
                                  MessageBox.Show ("Trafil Cie!");
                                  PL_CurrMaxhp();
                                  EnGraf = enIdle;
                              }

                          }
                          
                          if (fight)MessageBox.Show("Nikt nikogo nie uderzył");
                          
                      },
                       arg => (1 > 0));


                return atakGracza;
          }
        }
        private ICommand uzyjPrzedmiotu = null;
        public ICommand UzyjPrzedmiotu { get
            {

                if (uzyjPrzedmiotu == null)
                    uzyjPrzedmiotu = new RelayCommand(
                        arg => {
                        foreach (var it in Eq_items)
                            {
                                fight = true;
                                if (it.quantity>0 && it.item.Kind == Kind.consumable)
                                {
                                    usedItem = it;
                                    it.quantity--;
                                    player_curr_hp += it.item.Regen_hp;
                                    if(player_curr_hp>PLmax_hp)player_curr_hp = PLmax_hp;
                                    PL_CurrMaxhp();
                                    if (enemy_attack() && enemy_curr_hp != 0)
                                    {
                                        EnGraf = enAttack;
                                        player_curr_hp -= ENatk;
                                        fight = false;
                                        if (player_curr_hp <= 0)
                                        {
                                            player_curr_hp = 0;
                                            PL_CurrMaxhp();
                                            MessageBox.Show("przegrales :((");
                                            if (usedItem != null)
                                            {
                                                if (usedItem.quantity == 0 && model.msn.RemoveEquipmentByCharIdAndItemId(usedItem.item.ItemID, GlobalVariables.current_user.CharId)) { }
                                                if (usedItem.quantity != 0 && model.shopScreenModel.UpdateQuantity(usedItem.item.ItemID, GlobalVariables.current_user.CharId, usedItem.quantity - 1)) { }
                                            }
                                            IsFinished = Visibility.Visible;
                                            EnableButtons = false;
                                            EnGraf = enIdle;

                                        }
                                        else
                                        {
                                            MessageBox.Show("Trafil Cie!");
                                            PL_CurrMaxhp();
                                            EnGraf = enIdle;
                                        }
                                    }
                                    }
                            }
                        
                        
                        }, arg => (1 > 0)
                        );

                return uzyjPrzedmiotu;  
            } }



        private ICommand obronaGracza = null;
        public ICommand ObronaGracza { get {

                if (obronaGracza == null)
                    obronaGracza = new RelayCommand(
                        arg =>
                        {
                            fight = true;
                            PlGraf = plDeffense;
                       
                            if (enemy_attack())
                            {
                                EnGraf = enAttack;
                                player_curr_hp -= ENatk/5;
                                fight = false;
                                if (player_curr_hp <= 0)
                                {
                                    player_curr_hp = 0;
                                    PL_CurrMaxhp();
                                    MessageBox.Show("przegrales :((");
                                    if (usedItem != null)
                                    {
                                        if (usedItem.quantity == 0 && model.msn.RemoveEquipmentByCharIdAndItemId(usedItem.item.ItemID, GlobalVariables.current_user.CharId)) { }
                                        if (usedItem.quantity != 0 && model.shopScreenModel.UpdateQuantity(usedItem.item.ItemID, GlobalVariables.current_user.CharId, usedItem.quantity - 1)) { }
                                    }
                                    IsFinished = Visibility.Visible;
                                    EnableButtons = false;
                                }
                                else
                                {
                                    MessageBox.Show("Trafil Cie, ale zadał niewiele!");
                                    PL_CurrMaxhp();
                                   
                                }       
                            }
                            if (fight) MessageBox.Show("nie trafił Cię!");

                            EnGraf = enIdle;
                            PlGraf = plIdle;
                        },
                        arg => (1 > 0));
            
            return obronaGracza;
            } }




    }
}
        
    

