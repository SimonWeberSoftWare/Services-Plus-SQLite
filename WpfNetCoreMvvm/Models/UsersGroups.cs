using Microsoft.Toolkit.Mvvm.ComponentModel;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace WpfNetCoreMvvm.Models
{
    public class UsersGroups : ObservableCollection<UsersGroup>
    {
        public UsersGroups() : base() { }

        public UsersGroups(ObservableCollection<UsersGroup> value) : base(value) { }

        public UsersGroups(List<UsersGroup> value) : base(value) { }

        public UsersGroups(IEnumerable<UsersGroup> value) : base(value) { }
    }

    public class UsersGroup : ObservableObject, IDataErrorInfo
    {
        /// <summary>
        /// 
        /// </summary>
        public UsersGroup()
        {

        }

        ~UsersGroup()
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

        private int _gID;
        public int GID
        {
            get => _gID;
            set => SetProperty(ref _gID, value);
        }
    }
}