using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Furniture_Store.Data;
using System.Text.RegularExpressions;

namespace Furniture_Store
{
	/// <summary>
	/// Interaction logic for Registration.xaml
	/// </summary>
	public partial class RegistrationWindow : Window
	{
		private UserContext db;
		public User User { get; set; }
		public RegistrationWindow()
		{
			InitializeComponent();

			User = new User { Name = "", Login = "", Address = "", Role = 0 };
			this.DataContext = User;
		}

		private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
		{

		}

		private bool Valid()
		{
			bool check = true;
			if (Login.Text == "")
			{
				check = false;
			}
			if (UserName.Text == "" )
			{
				check = false;
			}
			if (Address.Text == "")
			{
				check = false;
			}
			if (EMail.Text == "")
			{
				check = false;
			}
			if (Phone.Text == "")
			{
				check = false;
			}
			return check;
		}

		private void Register_Click(object sender, RoutedEventArgs e)
		{
			if (Valid())
			{
				using (db = new UserContext())
				{
					User newUser = (User)this.DataContext;
					var password = (PasswordBox)this.FindName("Password");
					newUser.Password = password?.Password;
					newUser.Role = newUser.Role == 0 ? 2 : 1;

					if (!this.IsUserValid(newUser))
					{
						MessageBox.Show("Set all inputs data", "Invalid user data", MessageBoxButton.OK, MessageBoxImage.Error);

						return;
					}

					if (db.Users.Any(x => x.Name == newUser.Name))
					{
						MessageBox.Show("User with this name already exists in the system", "Alert", MessageBoxButton.OK, MessageBoxImage.Error);

						return;
					}

					try
					{
						db.Users.Add(newUser);
						db.SaveChanges();

						MessageBox.Show(
							$"User with name {newUser.Name} has been added",
							"User added",
							MessageBoxButton.OK,
							MessageBoxImage.Information);

						this.Close();

					}
					catch (Exception ex)
					{
						MessageBox.Show(ex.Message + ex?.InnerException?.Message, "Alert", MessageBoxButton.OK, MessageBoxImage.Error);
					}
				}
			}
			else 
			{
				MessageBox.Show("Check entered data", "Alert", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}

		private bool IsUserValid(User user)
		{
			if (string.IsNullOrEmpty(user.Name)
				|| string.IsNullOrEmpty(user.Login)
				|| string.IsNullOrEmpty(user.Password) 
				|| string.IsNullOrEmpty(user.Address))
			{
				return false;
			}
			return true;
		}

        private void Login_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
			e.Handled = !IsTextAllowed(e.Text);
        }

		private static bool IsTextAllowed(string text)
		{
			Regex regex = new Regex("[^A-Za-z0-9_-]+");
			return !regex.IsMatch(text);
		}

        private void TextBox_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
			e.Handled = !IsNameAllowed(e.Text);
		}
		private static bool IsNameAllowed(string text)
		{
			Regex regex = new Regex("[^A-Za-z-]+");
			return !regex.IsMatch(text);
		}

        private void TextBox_PreviewTextInput_1(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
			e.Handled = !IsAddressAllowed(e.Text);
		}
		private static bool IsAddressAllowed(string text)
		{
			Regex regex = new Regex("[^A-Za-z-0-9./]+");
			return !regex.IsMatch(text);
		}

        private void Phone_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
			e.Handled = !IsPhoneAllowed(e.Text);
		}
		private static bool IsPhoneAllowed(string text)
		{
			Regex regex = new Regex("[^0-9+]+");
			return !regex.IsMatch(text);
		}

        private void EMail_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
			e.Handled = !IsEmailAllowed(e.Text);
		}
		private static bool IsEmailAllowed(string text)
		{
			Regex regex = new Regex("[^A-Za-z_0-9@.-]+");
			return !regex.IsMatch(text);
		}
	}
}