using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Furniture_Store.Classes;
using Furniture_Store.Data;

namespace Furniture_Store.MVVM.View
{
    /// <summary>
    /// Логика взаимодействия для BasketView.xaml
    /// </summary>
    public partial class BasketView : UserControl
    {
        public ObservableCollection<Item> Items { get; set; }
        private BasketSingleton basket;

        private OrderContext db;

        public BasketView()
        {
            InitializeComponent();
            basket = BasketSingleton.GetInstance();

            Items = new ObservableCollection<Item>(basket.Items);
            itemsList.ItemsSource = Items;
            var totalPrice = basket.Items.Sum(x => x.Cost);
            var price = (Label)this.FindName("Price");
            price.Content = "Total price:" + totalPrice + "$";
        }

        private void MakeOrder_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!basket.Items.Any())
                {
                    MessageBox.Show(
                        "Basket is empty",
                        "Error",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error);
                    return;
                }

                using (db = new OrderContext())
                {
                    var order = new Order();
                    order.Customer = UserControlSingleton.GetInstance().User.ID;
                    order.Cost = basket.Items.Sum(x => x.Cost);
                    order.Is_Approved = null;

                    var newOrder = db.Orders.Add(order);
                    db.SaveChanges();

                    using (Order_ItemContext db2 = new Order_ItemContext())
                    {
                        foreach (var item in basket.Items)
                        {
                            db2.Order_Items.Add(new Order_Item() { Item_ID = item.ID, Order_ID = newOrder.ID });

                        }

                        db2.SaveChanges();
                    }

                    //db.SaveChanges();

                }

                this.CleanBasket();
            }
            catch (Exception ex)
            {
                var x = ex;
            }
        }

        private void CleanBasket()
        {
            BasketSingleton.RemoveItemsFromBasket();
            itemsList.ItemsSource = null;
        }

        private void RemoveItem_OnClick(object sender, RoutedEventArgs e)
        {
            if (itemsList.SelectedItems.Count == 0)
            {

            }
            else
            {
                var elToDelete = itemsList.SelectedItems[0];
                var item = (Item)elToDelete;

                basket.Items.Remove(item);
                if (basket.Items.Any())
                {
                    itemsList.ItemsSource = basket.Items;
                }
                else
                {
                    itemsList.ItemsSource = null;
                }

                var totalPrice = basket.Items.Sum(x => x.Cost);
                var price = (Label)this.FindName("Price");
                price.Content = "Total price:" + totalPrice + "$";
            }
        }
    }
}
