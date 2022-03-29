using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Furniture_Store.Classes;
using Furniture_Store.Data;
using System.Text.RegularExpressions;

namespace Furniture_Store.MVVM.View
{
    /// <summary>
    /// Логика взаимодействия для HomeView.xaml
    /// </summary>
    public partial class HomeView : UserControl
    {
        public ObservableCollection<Item> Items { get; set; }

        private ItemContext db;
        public HomeView()
        {
            InitializeComponent();
            UserControlSingleton usr = UserControlSingleton.GetInstance();
            if (usr.IsLogged && usr.Role != 1)
            {
                var addItemButton = (Button)this.FindName("AddItemButton");
                addItemButton.Visibility = Visibility.Hidden;
                RemoveItem.Visibility = Visibility.Hidden;
            }

            using (db = new ItemContext())
            {
                Items = new ObservableCollection<Item>(db.Items.ToList());
                itemsList.ItemsSource = Items;
            }
        }

        private void AddItem_Click(object sender, RoutedEventArgs e)
        {
            ItemUploadWindow uploadWindow = new ItemUploadWindow();
            uploadWindow.Show();
        }

        private void RemoveItem_Click(object sender, RoutedEventArgs e)
        {
            if (itemsList.SelectedItems.Count == 1)
            {
                if (MessageBox.Show("Do you want to remove the item?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    var selectedItem = (Item)itemsList.SelectedItems[0];
                    using (db = new ItemContext())
                    {
                        var item = db.Items.FirstOrDefault(x => x.ID == selectedItem.ID);
                        if (item != null)
                        {
                            db.Items.Remove(item);
                            db.SaveChanges();
                            itemsList.ItemsSource = db.Items.ToList();
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Choose item before delete", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void ItemsList_OnSelectionChangedList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var userAdmin = UserControlSingleton.GetInstance().User.Role == 1;

            if (!userAdmin)
            {
                if (MessageBox.Show("Add to basket?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    var basket = BasketSingleton.GetInstance();
                    var selectedItem = (Item)itemsList.SelectedItems[0];

                    if (selectedItem.Amount == 0)
                    {
                        MessageBox.Show(
                            "Sorry, there's no such items in a storage",
                            "Error",
                            MessageBoxButton.OK,
                            MessageBoxImage.Error);
                        return;
                    }

                    if (basket.Items.Contains(selectedItem))
                    {
                        MessageBox.Show(
                            "Basket already contains this item",
                            "Error",
                            MessageBoxButton.OK,
                            MessageBoxImage.Error);
                    }
                    else
                    {
                        basket.Items.Add(selectedItem);
                    }
                }
            }
        }

        private void refreshButton_OnClick(object sender, RoutedEventArgs e)
        {
            using (db = new ItemContext())
            {
                itemsList.ItemsSource = new ObservableCollection<Item>(db.Items.ToList());
            }
        }

        private void SearchButton_OnClick(object sender, RoutedEventArgs e)
        {
            var itemName = ItemNameSearch.Text;
            var comboBoxItems = (ComboBoxItem)itemTypeSearch.SelectedItem;
            var type = comboBoxItems.Content.ToString();

            using (db = new ItemContext())
            {
                List<Item> filteredData;
                var checkBox = (CheckBox)showAll;
                if ((bool)checkBox.IsChecked)
                {
                    filteredData = db.Items.ToList();
                }
                else
                {
                    // prices
                    decimal priceFrom;
                    decimal priceTo;

                    string fromStr = string.IsNullOrEmpty(PriceFrom.Text) == true ? decimal.MinValue.ToString() : PriceFrom.Text;
                    string toStr = string.IsNullOrEmpty(PriceTo.Text) == true ? decimal.MaxValue.ToString() : PriceTo.Text;

                    if (!decimal.TryParse(fromStr, out priceFrom)
                            || !decimal.TryParse(toStr, out priceTo))
                    {
                        MessageBox.Show(
                            "Wrong price for search",
                            "Error",
                            MessageBoxButton.OK,
                            MessageBoxImage.Error);
                        return;
                    }

                    if (priceTo < priceFrom)
                    {
                        MessageBox.Show(
                            "Minimal price should be higher than maximal price",
                            "Error",
                            MessageBoxButton.OK,
                            MessageBoxImage.Error);
                        return;
                    }

                    if (string.IsNullOrEmpty(itemName))
                    {
                        filteredData = type == "All" ? db.Items.Where(x => (x.Cost >= priceFrom && x.Cost <= priceTo)).ToList() : db.Items.Where(x => x.Item_Type == type && (x.Cost >= priceFrom && x.Cost <= priceTo)).ToList();
                    }
                    else if (type == "All")
                    {
                        filteredData = db.Items.Where(x => x.Name.Contains(itemName) && (x.Cost >= priceFrom && x.Cost <= priceTo)).ToList();
                    }
                    else
                    {
                        filteredData = db.Items.Where(x => x.Name.Contains(itemName) && x.Item_Type == type && (x.Cost >= priceFrom && x.Cost <= priceTo)).ToList();
                    }
                }

                var result = this.OrderItems(filteredData);

                itemsList.ItemsSource = result;
            }
        }

        private List<Item> OrderItems(List<Item> filteredData)
        {
            var filterRadioButtons = Panel.Children.OfType<RadioButton>().ToList();
            var selectedFiletButton = filterRadioButtons
                .FirstOrDefault(x => x.GroupName == "filters" && x.IsChecked == true);

            var orderBy = selectedFiletButton?.Content.ToString();

            if (orderBy != null)
            {
                switch (orderBy)
                {
                    case "None":
                        break;
                    case "Name":
                        filteredData = filteredData.OrderBy(x => x.Name).ToList();
                        break;
                    case "Cost":
                        filteredData = filteredData.OrderBy(x => x.Cost).ToList();
                        break;
                    case "Type":
                        filteredData = filteredData.OrderBy(x => x.Item_Type).ToList();
                        break;
                    case "Date Of Add":
                        filteredData = filteredData.OrderBy(x => x.Date_Of_Add).ToList();
                        break;
                }
            }

            return filteredData;
        }

        private void ItemNameSearch_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            e.Handled = !IsNameAllowed(e.Text);
        }

        private static bool IsNameAllowed(string text)
        {
            Regex regex = new Regex("[^0-9A-Za-z-]+");
            return !regex.IsMatch(text);
        }

        private void PriceFrom_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            e.Handled = !IsPriceAllowed(e.Text);
        }

        private static bool IsPriceAllowed(string text)
        {
            Regex regex = new Regex("[^0-9.]+");
            return !regex.IsMatch(text);
        }
    }
}