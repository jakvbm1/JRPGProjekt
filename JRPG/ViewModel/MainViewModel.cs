namespace JRPG.ViewModel
{
    using BaseClass;
    using Model;

    class MainViewModel : ViewModelBase
    {
        private MainModel mainModel;
        
        public Register Registering { get; set; }
        public CharScreenVM CSVM { get; set; }
        public ShopScreenVM ShopVM { get; set; }
        public BattleViewModel BattleVM { get; set; }
        public SelectEnemyVM SelectEnemyVM { get; set; }
        
        public AdminVM AdminVM { get; set; }
        public MainViewModel()
        {
            
            mainModel = new MainModel();
            Registering = new Register(mainModel);
            CSVM = new CharScreenVM(mainModel);
            ShopVM = new ShopScreenVM(mainModel);
            SelectEnemyVM = new SelectEnemyVM(mainModel);
            AdminVM = new AdminVM(mainModel);
            if (string.IsNullOrEmpty(SelectEnemyVM.chosen))
                BattleVM = new BattleViewModel(mainModel);
           else BattleVM = new BattleViewModel(mainModel, SelectEnemyVM.chosen, CSVM.HP, CSVM.ATK, CSVM.DEF, CSVM.Eq_items);
            


        }
       

    }
}
