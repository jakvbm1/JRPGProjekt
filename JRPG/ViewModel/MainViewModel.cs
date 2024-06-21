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

    class MainViewModel : ViewModelBase
    {
        private MainModel mainModel;
        
        public Register Registering { get; set; }
        public CharScreenVM CSVM { get; set; }
        public ShopScreenVM ShopVM { get; set; }
        public BattleViewModel BattleVM { get; set; }
        public SelectEnemyVM SelectEnemyVM { get; set; }
        
        public MainViewModel()
        {
            
            mainModel = new MainModel();
            Registering = new Register(mainModel);
            CSVM = new CharScreenVM(mainModel);
            ShopVM = new ShopScreenVM(mainModel);
            SelectEnemyVM = new SelectEnemyVM(mainModel);
            if (string.IsNullOrEmpty(SelectEnemyVM.chosen))
                BattleVM = new BattleViewModel(mainModel);
           else BattleVM = new BattleViewModel(mainModel, SelectEnemyVM.chosen, CSVM.HP, CSVM.ATK, CSVM.DEF, CSVM.Eq_items);
            


        }
       

    }
}
