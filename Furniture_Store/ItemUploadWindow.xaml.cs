using System;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using Furniture_Store.Data;
using Microsoft.Win32;
using System.Text.RegularExpressions;

namespace Furniture_Store
{
	/// <summary>
	/// Interaction logic for ItemUploadWindow.xaml
	/// </summary>
	public partial class ItemUploadWindow : Window
	{
		private ItemContext db;
		private readonly Item _item = new Item();

		public ItemUploadWindow()
		{
			InitializeComponent();
			this.DataContext = _item;
		}

		private void ChooseImage_OnClick(object sender, RoutedEventArgs e)
		{
			OpenFileDialog fileDialog = new OpenFileDialog();
			fileDialog.Title = "Select image";
			fileDialog.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|"
				+ "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|"
				+ "Portable Network Graphic (*.png)|*.png";

			if (fileDialog.ShowDialog() == true)
			{
				var image = new BitmapImage(new Uri(fileDialog.FileName));
				ItemImage.Source = image;
				_item.Image = this.ImageToByte(image);

			}
		}

		private void ComboBox_Selected(object sender, RoutedEventArgs e)
		{
			ComboBox comboBox = (ComboBox)sender;
			ComboBoxItem selectedItem = (ComboBoxItem)comboBox.SelectedItem;
			string type = selectedItem.Content.ToString();
			_item.Item_Type = type;
		}

		private bool Valid()
		{
			bool check = true;
			if (Item_Name.Text == "")
			{
				check = false;
			}
			if (Item_Cost.Text == "" || Item_Cost.Text == "0")
			{
				check = false;
				MessageBox.Show("Cost value can not be 0","Alert",MessageBoxButton.OK,MessageBoxImage.Warning);
			}
			if (ItemType.Text == "")
			{
				check = false;
			}
			if (Amount.Text == "")
			{
				check = false;
			}
			return check;
		}
		private void AddItem_OnClick(object sender, RoutedEventArgs e)
		{
			if (Valid())
			{
				Item item = (Item)this.DataContext;
				item.Date_Of_Add = DateTime.Now;

				using (db = new ItemContext())
				{
					if (db.Items.Any(x => x.Name == item.Name))
					{
						MessageBox.Show("Item with this name already exists in the system", "Alert", MessageBoxButton.OK, MessageBoxImage.Error);

						return;
					}

					try
					{
						db.Items.Add(item);
						db.SaveChanges();
						MessageBox.Show("Item is added", "Status", MessageBoxButton.OK, MessageBoxImage.Information);
						this.Close();
					}
					catch (Exception ex)
					{
						MessageBox.Show(ex.Message + ex.InnerException?.Message, "Alert", MessageBoxButton.OK, MessageBoxImage.Error);
					}
				}
			}
			else
            {
				MessageBox.Show("Check the information you entered", "Alert", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}

		public byte[] ImageToByte(BitmapImage imageSource)
		{
			byte[] buffer = null;
			JpegBitmapEncoder encoder = new JpegBitmapEncoder();
			encoder.Frames.Add(BitmapFrame.Create(imageSource));
			using (MemoryStream ms = new MemoryStream())
			{
				encoder.Save(ms);
				buffer = ms.ToArray();
			}


			return buffer;
		}



        private void TextBox_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
			e.Handled = !IsTextAllowed(e.Text);
        }
		private static bool IsTextAllowed(string text)
        {
			Regex regex = new Regex("[^0-9.]+");
			return !regex.IsMatch(text);
        }

        private void TextBox_PreviewTextInput_1(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
			e.Handled = !IsNameAllowed(e.Text);
		}
		private static bool IsNameAllowed(string text)
		{
			Regex regex = new Regex("[^0-9A-Za-z-]+");
			return !regex.IsMatch(text);
		}

        private void Amount_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
			e.Handled = !IsAmountAllowed(e.Text);
		}
		private static bool IsAmountAllowed(string text)
		{
			Regex regex = new Regex("[^0-9]+");
			return !regex.IsMatch(text);
		}
	}
}
