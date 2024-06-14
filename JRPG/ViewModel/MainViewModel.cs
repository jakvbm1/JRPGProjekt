using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JRPG.ViewModel
{
    using DAL.Encje;
    using DAL.Repozytoria;
    using Model;
    using BaseClass;

    class MainViewModel
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
            BattleVM = new BattleViewModel(mainModel, SelectEnemyVM.difficult);
          
            
        }
    }
}
