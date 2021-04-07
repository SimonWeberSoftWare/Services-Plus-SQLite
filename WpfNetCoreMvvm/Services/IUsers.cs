using System;
using System.Collections.Generic;
using System.Text;

namespace WpfNetCoreMvvm.Services
{
    interface IUsers
    {
        public void getAllUsers();
        public string getNameByID(int id);
        public int getIDByName(string name);
    }
}
