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

    class BattleViewModel
    {
        private MainModel model;
        private Characters player;
        private Enemies enemy;
        private Difficulty difficulty;
        private ObservableCollection<Enemies> enemies;

        public BattleViewModel(MainModel mainModel)
        {
            model = mainModel;
            player = GlobalVariables.current_user;
            enemies = model.enemiesModel.GetEnemiesByDifficulty(difficulty);
        }
        
    }
}
