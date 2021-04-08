using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.Extensions.Options;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading.Tasks;
using WpfNetCoreMvvm.Models;
using WpfNetCoreMvvm.Services;
using System.Windows;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using System.Data.SQLite;
using System.Collections.Generic;

namespace WpfNetCoreMvvm.ViewModels
{
    public class MainViewModel : Microsoft.Toolkit.Mvvm.ComponentModel.ObservableObject, INotifyPropertyChanged
    {
        private readonly IUsers users;

      
        public RelayCommand<string> GetUserName { get; } //dieses Projekt ist in Version 8.0 geschrieben, deshalb RelayCommands auf diese Weise schreiben

        public MainViewModel(IOptions<AppSettings> options, IUsers users)
        {        
            GetUserName = new RelayCommand<string>(GetUserNameCmd);

            this.users = users;

            UserList = users.getAllUsers();    
        

        }

        private void GetUserNameCmd(string id)
        {
          UserName =  users.getNameByID(int.Parse(id));
            OnPropertyChanged(nameof(UserName));
        }

        public List<Models.User> UserList { get; set; } = new List<Models.User>();

    

        private string _userName;
        public string UserName
        {
            get => _userName;
            set => SetProperty(ref _userName, value);
        }

        private int _userID;
        public int UserId
        {
            get => _userID;
            set => SetProperty(ref _userID, value);
        }

      


    }
}
