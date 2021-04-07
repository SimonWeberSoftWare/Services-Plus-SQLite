using Microsoft.Toolkit.Mvvm.ComponentModel;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace WpfNetCoreMvvm.Models
{
    public class Users : ObservableCollection<User>
    {
        public Users() : base() { }

        public Users(ObservableCollection<User> value) : base(value) { }

        public Users(List<User> value) : base(value) { }

        public Users(IEnumerable<User> value) : base(value) { }
    }

    public class User : ObservableObject, IDataErrorInfo
    {
        /// <summary>
        /// 
        /// </summary>
        public User()
        {
            
        }

        ~User()
        {
           
        }

        public string Error => null;

        public string this[string columnName]
        {
            get
            {
                switch (columnName)
                {

                }
                return string.Empty;
            }
        }
        private int _uID;
        public int UID
        {
            get => _uID;
            set => SetProperty(ref _uID, value);
        }

        private string _uName;
        public string UName
        {
            get => _uName;
            set => SetProperty(ref _uName, value);
        }
    }
}