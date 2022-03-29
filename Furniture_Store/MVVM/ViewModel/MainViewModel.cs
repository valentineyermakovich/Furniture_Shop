using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Furniture_Store.Core;

namespace Furniture_Store.MVVM.ViewModel
{
    class MainViewModel:ObservableObject
    {
        public RelayCommand HomeViewCommand { get; set; }
        public RelayCommand OrdersViewCommand { get; set; }
        public RelayCommand BasketViewCommand { get; set; }
        public RelayCommand UserViewCommand { get; set; }
        public RelayCommand RegistrationViewCommand { get; set; }
        public HomeViewModel HomeVM { get; set; }
        public OrdersViewModel OrdersVM { get; set; }
        public BasketViewModel BasketVM { get; set; }
        public UserViewModel UserVM { get; set; }
        public RegistrationViewModel RegistrationVM { get; set; }

        private object _currentView;

        public object CurrentView
        {
            get { return _currentView; }
            set 
            { 
                _currentView = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel()
        {
            HomeVM = new HomeViewModel();
            OrdersVM = new OrdersViewModel();
            BasketVM = new BasketViewModel();
            UserVM = new UserViewModel();
            RegistrationVM = new RegistrationViewModel();
            CurrentView = UserVM;

            HomeViewCommand = new RelayCommand(o => 
            {
                CurrentView = HomeVM;
            });

            OrdersViewCommand = new RelayCommand(o =>
            {
                CurrentView = OrdersVM;
            });

            BasketViewCommand = new RelayCommand(o =>
            {
                CurrentView = BasketVM;
            });

            UserViewCommand = new RelayCommand(o =>
            {
                CurrentView = UserVM;
            });

            RegistrationViewCommand = new RelayCommand(
                o =>
                {
                    CurrentView = RegistrationVM;
                });
        }
    }
}
