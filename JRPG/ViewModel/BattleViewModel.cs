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

    class BattleViewModel: ViewModelBase
    {
        private MainModel model;
        private Characters player;
        private Enemies enemy;
        private static Difficulty difficult;
        public string diff;
        private ObservableCollection<Enemies> enemies;
        static Random rnd = new Random();

        public BattleViewModel(MainModel mainModel, Difficulty difficulty)
        {
           
            model = mainModel;
            
            
            player = GlobalVariables.current_user;
            Get_Enemy();
            
            enemies = model.enemiesModel.GetEnemiesByDifficulty(difficult);
            difficult = difficulty;

        }
        
        private void Get_Enemy()
        {
            int r = rnd.Next(enemies.Count);
            enemy = enemies[r];
            

        }
        
        public Difficulty Difficult
        {
            get { return difficult; }
            set
            {
                difficult = value;

                onPropertyChanged(nameof(Difficult));
            }
        }
        
    }
}
