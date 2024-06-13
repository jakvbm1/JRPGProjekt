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
    

    public MainViewModel()
        {
            mainModel = new MainModel();
            Registering = new Register(mainModel);
            CSVM = new CharScreenVM(mainModel);
        }
    }
}
