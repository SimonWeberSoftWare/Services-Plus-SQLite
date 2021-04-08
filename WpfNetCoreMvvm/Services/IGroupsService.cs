using System;
using System.Collections.Generic;
using System.Text;
using WpfNetCoreMvvm.Models;

namespace WpfNetCoreMvvm.Services
{
    public interface IGroupsService
    {
        public List<Group> getAllGroups();
        public string getNameByID(int id);
        public int getIDByName(string name);
        public List<int> getAllUsersOfGroup(int id);
        public void createGroup(int id, string name);
    }
}
