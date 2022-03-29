using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Furniture_Store.Data;

namespace Furniture_Store.Classes
{
    class UserControlSingleton
    {
        private static UserControlSingleton instance;
        public bool IsLogged;
        public int UserID;
        public string Name;
        public int Role;
        public User User { get; set; }
        private UserControlSingleton()
        {
        
        }

        public static UserControlSingleton GetInstance()
        {
            if(instance == null)
            {
                instance = new UserControlSingleton();
            }
            return instance;
        }
    }
}
