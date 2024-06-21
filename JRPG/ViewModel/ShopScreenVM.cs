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
using JRPG.DAL.Repozytoria;

namespace JRPG.ViewModel
{
    class ShopScreenVM : ViewModelBase
    {
        private MainModel model;
        private ObservableCollection<Items> items = new ObservableCollection<Items>();
        private ObservableCollection<ItemWithCheckBox> itemsWithCheckBox = new ObservableCollection<ItemWithCheckBox>();
        private Characters user_char;
        private int cost = 0;

        public ShopScreenVM(MainModel mainModel)
        {
            model = mainModel;
            items = model.itemsModel.AllItems;
            for (int i = 0; i < items.Count; i++)
            {
                var new_sprite = "/sprites/items/" + items[i].Sprite + ".png";
                items[i].Sprite = new_sprite;
            }
            foreach (var item in items)
            {
                ItemsWithCheckBox.Add(new ItemWithCheckBox { Item = item, IsChecked = false });
            }
            User_char = GlobalVariables.current_user;
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
        public Characters User_char 
        {
            get { return user_char; } 
            set 
            { 
                user_char = value;
                onPropertyChanged(nameof(User_char)); 
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
                            for (int i = 0; i < ItemsWithCheckBox.Count; i++)
                            {
                                if (ItemsWithCheckBox[i].IsChecked)
                                {
                                    cost += ItemsWithCheckBox[i].Item.Cost;
                                }
                            }
                            if (cost <= User_char.Gold)
                            {
                                MessageBox.Show("Zakupiono przedmiot");
                                cost = 0;
                            }
                            else
                            {
                                MessageBox.Show("Za mało złota!");
                                cost = 0;
                            }
                        },
                        arg => true);
                }
                return buttonBuy;
            }
        }
    }
}
