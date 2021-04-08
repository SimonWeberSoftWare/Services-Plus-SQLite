using System;
using System.Collections.Generic;
using System.Text;
using WpfNetCoreMvvm.Models;

namespace WpfNetCoreMvvm.Services
{
   public interface IUsers
    {
        public List<User> getAllUsers();
        public string getNameByID(int id);
        public int getIDByName(string name);
        public List<int> getAllGroupIDByUser(int id);
        public void createUser(int id, string name);
        public void deleteUser(int id);
        public void updateUser(int id,string newName);

    }
}
