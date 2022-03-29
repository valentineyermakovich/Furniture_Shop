using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Furniture_Store.Classes;
using Furniture_Store.Data;
using System.Text.RegularExpressions;

namespace Furniture_Store.MVVM.View
{
    /// <summary>
    /// Логика взаимодействия для UserView.xaml
    /// </summary>
    public partial class UserView : UserControl
    {
        private UserContext db;

        public UserView()
        {
            InitializeComponent();
            UserControlSingleton instance = UserControlSingleton.GetInstance();
            if (instance.IsLogged)
            {
                this.ChangeForm(true, instance.Name, instance.Role);
            }
        }

        private void Login_Button_Click(object sender, RoutedEventArgs e)
        {
            UserControlSingleton instance = UserControlSingleton.GetInstance();
            var login = (TextBox)this.FindName("Login");
            var password = (PasswordBox)this.FindName("Password");

            User user = null;
            //get user from DB
            using (db = new UserContext())
            {
                user = db.Users.FirstOrDefault(x => x.Login == login.Text && x.Password == password.Password);


            }

            if (user != null)
            {
                this.ChangeForm(true, user.Name, user.Role);

                instance.IsLogged = true;
                instance.UserID = user.ID;
                instance.Name = user.Name;
                instance.Role = user.Role;
                instance.User = user;

                var errorMessage = (Label)this.FindName("ErrorMessage");
                if (errorMessage.Visibility == Visibility.Visible)
                {
                    errorMessage.Visibility = Visibility.Hidden;
                }

                this.EnableControlsOnMainWindow(true);
            }
            else
            {
                var errorMessage = (Label)this.FindName("ErrorMessage");
                errorMessage.Visibility = Visibility.Visible;
            }
        }

        private void Logout_Button_Click(object sender, RoutedEventArgs e)
        {
            UserControlSingleton instance = UserControlSingleton.GetInstance();
            instance.IsLogged = false;
            instance.UserID = 0;

            this.ChangeForm(false, null, 0);
            this.EnableControlsOnMainWindow(false);
        }

        private void Registration_Click(object sender, RoutedEventArgs e)
        {
            RegistrationWindow rw = new RegistrationWindow();
            rw.Show();
        }

        private void ChangeForm(bool loggedIn, string name, int role)
        {
            if (loggedIn)
            {
                var loginBox = (GroupBox)this.FindName("LoginBox");
                loginBox.Visibility = Visibility.Hidden;

                var userBox = (GroupBox)this.FindName("UserBox");
                userBox.Visibility = Visibility.Visible;
                var userName = (TextBlock)this.FindName("UserName");
                userName.Text = "Username: " + name;
                var userRole = (TextBlock)this.FindName("Role");
                userRole.Text = role == 1 ? "Role: Admin" : "Role: User";
            }
            else
            {
                var userBox = (GroupBox)this.FindName("UserBox");
                userBox.Visibility = Visibility.Hidden;

                var loginBox = (GroupBox)this.FindName("LoginBox");
                loginBox.Visibility = Visibility.Visible;
            }
        }

        private void EnableControlsOnMainWindow(bool enable)
        {
            var ordersButton = (RadioButton)Application.Current.MainWindow.FindName("OrdersButton");
            ordersButton.IsEnabled = enable;
            var homesButton = (RadioButton)Application.Current.MainWindow.FindName("HomeButton");
            homesButton.IsEnabled = enable;
            if (UserControlSingleton.GetInstance().Role != 1)
            {
                var busketButton = (RadioButton)Application.Current.MainWindow.FindName("BasketButton");
                busketButton.IsEnabled = enable;
                busketButton.Visibility = Visibility.Visible;
            }
            else
            {
                var busketButton = (RadioButton)Application.Current.MainWindow.FindName("BasketButton");
                busketButton.Visibility = Visibility.Hidden;
            }
        }

        private void Login_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            e.Handled = !IsLoginAllowed(e.Text);
        }

        private static bool IsLoginAllowed(string text)
        {
            Regex regex = new Regex("[^A-Za-z0-9_-]+");
            return !regex.IsMatch(text);
        }
    }
}
