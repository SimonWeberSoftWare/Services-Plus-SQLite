using Microsoft.Toolkit.Mvvm.ComponentModel;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
namespace WpfNetCoreMvvm.Models
{
    public class Groups : ObservableCollection<Group>
    {
        public Groups() : base() { }

        public Groups(ObservableCollection<Group> value) : base(value) { }

        public Groups(List<Group> value) : base(value) { }

        public Groups(IEnumerable<Group> value) : base(value) { }
    }

    public class Group : ObservableObject, IDataErrorInfo
    {
        /// <summary>
        /// 
        /// </summary>
        public Group()
        {

        }

        ~Group()
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
        private int _gID;
        public int GID
        {
            get => _gID;
            set => SetProperty(ref _gID, value);
        }

        private string _gName;
        public string GName
        {
            get => _gName;
            set => SetProperty(ref _gName, value);
        }
    }
}
