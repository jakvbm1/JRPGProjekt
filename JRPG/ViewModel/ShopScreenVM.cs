using JRPG.DAL.Encje;
using JRPG.Model;
using JRPG.ViewModel.BaseClass;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JRPG.ViewModel
{
    class ShopScreenVM : ViewModelBase
    {
        private MainModel model;
        private ObservableCollection<Items> items = new ObservableCollection<Items>();

        public ShopScreenVM(MainModel mainModel)
        {
            model = mainModel;
            items = model.itemsModel.AllItems;
        }
        
        public ObservableCollection<Items> Items 
        { 
            get { return items; } 
            set 
            { 
                value = items;
                onPropertyChanged(nameof(Items)); 
            } 
        }
    }
}
