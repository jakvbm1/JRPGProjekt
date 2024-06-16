using JRPG.DAL.Encje;
using JRPG.Model;
using JRPG.ViewModel.BaseClass;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

namespace JRPG.ViewModel
{
    class ShopScreenVM : ViewModelBase
    {
        private MainModel model;
        private ObservableCollection<Items> items = new ObservableCollection<Items>();
        private ObservableCollection<ItemWithCheckBox> itemsWithCheckBox = new ObservableCollection<ItemWithCheckBox>();

        public ShopScreenVM(MainModel mainModel)
        {
            model = mainModel;
            items = model.itemsModel.AllItems;
            foreach (var item in items)
            {
                ItemsWithCheckBox.Add(new ItemWithCheckBox { Item = item, IsChecked = false });
            }
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
        public ObservableCollection<ItemWithCheckBox> ItemsWithCheckBox
        { 
            get { return itemsWithCheckBox; }
            set
            {
                itemsWithCheckBox = value;
                onPropertyChanged(nameof(ItemsWithCheckBox));
            }
        }

        private ICommand buttonBuy = null;
        public ICommand ButtonBuy
        {
            get
            {
                if (buttonBuy == null)
                {
                    buttonBuy = new RelayCommand(
                        arg =>
                        {
                            string x = "";
                            for (int i = 0; i < ItemsWithCheckBox.Count; i++)
                            {
                                x += ItemsWithCheckBox[i].IsChecked.ToString();
                                x += "\n";
                            }
                            MessageBox.Show(x);
                        },
                        arg => true);
                }
                return buttonBuy;
            }
        }
    }
}
