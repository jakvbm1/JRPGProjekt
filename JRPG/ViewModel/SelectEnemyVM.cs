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
    class SelectEnemyVM
    {
    private MainModel model;
    public Difficulty difficult;
    
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
                          difficult = Difficulty.easy;
                          Console.WriteLine(difficult.ToString());
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
                          difficult = Difficulty.medium;
                          Console.WriteLine(difficult.ToString());
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
                          difficult = Difficulty.hard;
                          Console.WriteLine(difficult.ToString());
                      },
                       arg => (1 > 0));


                return hardDifficulty;




            }
        }



    }
}
