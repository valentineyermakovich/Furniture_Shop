using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Furniture_Store.Classes;
using Furniture_Store.Data;


namespace Furniture_Store.MVVM.View
{
    /// <summary>
    /// Логика взаимодействия для OrdersView.xaml
    /// </summary>
    public partial class OrdersView : UserControl
    {
        public ObservableCollection<OrderVM> Orders { get; set; }
        private OrderContext orderDB;

        public OrdersView()
        {
            InitializeComponent();
            var user = UserControlSingleton.GetInstance();
            if (user.Role == 1)
            {
                Disapprove.Visibility = Visibility.Visible;
                Approve.Visibility = Visibility.Visible;
            }

            this.SetItems();
        }

        private OrderVM MapModel(Order order, string address)
        {
            var user = UserControlSingleton.GetInstance();
            string phone;
            string email;
            using (var userContext = new UserContext())
            {
                var user1 = userContext.Users.FirstOrDefault(x => x.ID == order.Customer);
                phone = user1.Phone_Number;
                email = user1.Mail;
            }
            return new OrderVM()
            {
                Is_Approved = order.Is_Approved,
                Address = address,
                Cost = order.Cost,
                Customer = order.Customer,
                ID = order.ID,
                ApproveVisible = user.User.Role == 1,
                Phone = phone,
                EMail = email,
                Delivery = DateTime.Today.AddDays(7).ToShortDateString()
                };
           
        }

        private void Approve_OnClick(object sender, RoutedEventArgs e)
        {
            if (itemsList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Select order first", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                var order = (OrderVM)itemsList.SelectedItems[0];
                if (order.Is_Approved.HasValue && order.Is_Approved.Value == true)
                {
                    MessageBox.Show("Order is already approved", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
                else if (order.Is_Approved.HasValue && order.Is_Approved.Value == false)
                {
                    MessageBox.Show("Order is already disapproved", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }

                using (var orderItems = new Order_ItemContext())
                {
                    var result = orderItems.Order_Items.Where(x => x.Order_ID == order.ID).ToList();

                    foreach (var order_item in result)
                    {
                        using (var items = new ItemContext())
                        {
                            var item = items.Items.SingleOrDefault(x => x.ID == order_item.Item_ID);
                            if (item != null)
                            {
                                item.Amount = item.Amount - 1;
                                items.SaveChanges();
                            }
                        }
                    }
                }

                using (var ordersContext = new OrderContext())
                {
                    var or = ordersContext.Orders.SingleOrDefault(x => x.ID == order.ID);
                    if (or != null)
                    {
                        or.Is_Approved = true;
                        ordersContext.SaveChanges();
                    }
                }
                this.SetItems();

                SendEMail(order);

            }
            
        }

        private void SendEMail(OrderVM order)
        {
            MailAddress from = new MailAddress("valik123qaz@gmail.com");
            MailAddress to = new MailAddress(order.EMail);
            MailMessage message = new MailMessage(from, to);
            message.Subject = "Order approvement";
            message.Body = $"<h2>Your order has been approved!</h2>" +
                $"<h4>Your order will be delivered till {order.Delivery}<br>" +
                $"Total cost: {order.Cost} $<br>" +
                $"Delivery address: {order.Address}<br>" +
                $"You can pay for the order to the courier using a bank card or cash.<br>" +
                $"If you have some questions, call the number +375295954105<br>" +
                $"Thank you for using our service! Enjoy your furniture with  us!</h4>";
            message.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential("ЗДЕСЬ ТЫ ЕБАШИШЬ СВОЮ ЭЛЕКТРОННУЮ ПОЧТУ", "ЗДЕСЬ ПАРОЛЬ ОТ НЕЁ");
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.EnableSsl = true;
            try
            {
                smtp.Send(message);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        private void Disapprove_OnClick(object sender, RoutedEventArgs e)
        {
            if (itemsList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Select order first", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                var order = (OrderVM)itemsList.SelectedItems[0];

                if (order.Is_Approved.HasValue && order.Is_Approved.Value == false)
                {
                    MessageBox.Show("Order is already disapproved", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
                else if (order.Is_Approved.HasValue && order.Is_Approved.Value == true)
                {
                    MessageBox.Show("Order is already approved", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }

                using (var orderItems = new Order_ItemContext())
                {
                    var result = orderItems.Order_Items.Where(x => x.Order_ID == order.ID).ToList();

                    foreach (var order_item in result)
                    {
                        using (var items = new ItemContext())
                        {
                            var item = items.Items.SingleOrDefault(x => x.ID == order_item.Item_ID);
                            if (item != null)
                            {
                                item.Amount = item.Amount + 1;
                                items.SaveChanges();
                            }
                        }
                    }
                }

                using (var ordersContext = new OrderContext())
                {
                    var or = ordersContext.Orders.SingleOrDefault(x => x.ID == order.ID);
                    if (or != null)
                    {
                        or.Is_Approved = false;
                        ordersContext.SaveChanges();
                    }
                }
                this.SetItems();
            }
        }

        private void SetItems()
        {
            var user = UserControlSingleton.GetInstance();

            using (orderDB = new OrderContext())
            {
                List<Order> userOrders = user.User.Role == 1 ?
                    orderDB.Orders.ToList() :
                    orderDB.Orders.Where(x => x.Customer == user.UserID).ToList();

                List<OrderVM> orders = new List<OrderVM>();
                using (var userDatabase = new UserContext())
                {

                    foreach (var order in userOrders)
                    {
                        var orderUser = userDatabase.Users.FirstOrDefault(x => x.ID == order.Customer);
                        orders.Add(MapModel(order, orderUser.Address));
                    }
                }

                Orders = new ObservableCollection<OrderVM>(orders);
                itemsList.ItemsSource = Orders;
            }
        }
    }
}