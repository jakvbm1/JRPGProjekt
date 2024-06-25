namespace JRPG.ViewModel
{
    using BaseClass;
    using Model;
    using System.Windows.Input;
    class SelectEnemyVM: ViewModelBase
    {
    private MainModel model;
   
        public static string chosen;


    public SelectEnemyVM(MainModel model)
        {
            this.model = model;
         
            
        }
        
        private ICommand easyDifficulty = null;
        public ICommand EasyDifficulty
        {
            get
            {
                if (easyDifficulty == null)
                    easyDifficulty = new RelayCommand(
                      arg =>
                      {
                          
                          chosen = "easy";
                          
                      },
                       arg => (1 > 0));
                return easyDifficulty;
            }
        }


        private ICommand mediumDifficulty = null;
        public ICommand MediumDifficulty
        {
            get
            {
                if (mediumDifficulty == null)
                    mediumDifficulty = new RelayCommand(
                      arg =>
                      {
                      
                          chosen = "medium";

                      },
                       arg => (1 > 0));


                return mediumDifficulty;




            }
        }
        private ICommand hardDifficulty = null;
        public ICommand HardDifficulty
        {
            get
            {
                if (hardDifficulty == null)
                    hardDifficulty = new RelayCommand(
                      arg =>
                      {
                     
                          chosen = "hard";

                      },
                       arg => (1 > 0));


                return hardDifficulty;




            }
        }



    }
}
