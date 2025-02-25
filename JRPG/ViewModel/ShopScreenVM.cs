﻿using JRPG.DAL.Encje;
using JRPG.DAL.Repozytoria;
using JRPG.Model;
using JRPG.ViewModel.BaseClass;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace JRPG.ViewModel
{
    class ShopScreenVM : ViewModelBase
    {
        private MainModel model;
        private ObservableCollection<Items> items = new ObservableCollection<Items>();
        private ObservableCollection<ItemWithCheckBox> itemsWithCheckBox = new ObservableCollection<ItemWithCheckBox>();
        private Characters user_char;
        private int cost = 0;
        private ObservableCollection<Items> checkedItems = new ObservableCollection<Items>();
        private ObservableCollection<Equipment> equipment = new ObservableCollection<Equipment>();

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
        public int User_gold
        {
            get { return user_char.Gold; }
            set
            {
                user_char.Gold = value;
                onPropertyChanged(nameof(User_gold));
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
                                    checkedItems.Add(ItemsWithCheckBox[i].Item);
                                }
                            }
                            if (cost == 0)
                            {
                                MessageBox.Show("Najpierw wybierz przedmiot.");
                            }
                            else if (cost <= User_char.Gold)
                            {
                                model.shopScreenModel.UpdateGold(User_char, cost);
                                equipment = model.shopScreenModel.GetUsersEquipment(User_char.CharId);
                                foreach (var item in checkedItems)
                                {
                                    bool inEqupment = false;
                                    for (int i = 0; i < equipment.Count; i++)
                                    {
                                        if (item.ItemID == equipment[i].ItemID)
                                        {
                                            inEqupment = true;
                                            model.shopScreenModel.UpdateQuantity(item.ItemID, User_char.CharId, equipment[i].Quantity);
                                            break;
                                        }
                                    }
                                    if (!inEqupment)
                                    {
                                        model.shopScreenModel.AddItem(item.ItemID, User_char.CharId);
                                    }
                                }
                                User_gold -= cost;
                                MessageBox.Show("Zakupiono przedmiot.");
                            }
                            else
                            {
                                MessageBox.Show("Za mało złota!");
                            }
                            cost = 0;
                            checkedItems.Clear();
                        },
                        arg => true);
                }
                return buttonBuy;
            }
        }
    }
}
