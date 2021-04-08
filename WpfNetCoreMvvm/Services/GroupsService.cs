using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Text;
using WpfNetCoreMvvm.Models;

namespace WpfNetCoreMvvm.Services
{
   public class GroupsService : IGroupsService
    {
        //nur der Service Users hat Zugriff auf die Tabelle Users, 

        //  public  Users UserList { get; set; } = new Users();
        public List<Group> GroupList = new List<Group>();

        public List<Group> getAllGroups()
        {
            //speichert alle Einträge der Tabelle Users im Model Users(schlechte Namenswahl)

            using (SQLiteConnection conn = new SQLiteConnection(@"Data Source=C:\Users\Simon Weber Work\Documents\GitHub\Services-Plus-SQLite\WpfNetCoreMvvm\Management.db;"))
            {
                conn.Open();

                SQLiteCommand command = new SQLiteCommand("Select * from Groups", conn);
                SQLiteDataReader reader = command.ExecuteReader();

                string curGName;
                int curGID;

                while (reader.Read())
                {
                    curGName = reader["gName"].ToString();
                    curGID = int.Parse(reader["gID"].ToString());
                    GroupList.Add(new Group() { GID = curGID, GName = curGName });
                }


                reader.Close();

            }

           
            return GroupList;
        }

        public int getIDByName(string name)
        {
            List<Group> GroupList = new List<Group>();
            GroupList = getAllGroups();

            int returnID = -1;
            GroupList.ForEach(delegate (Group Element)
            {
                if (Element.GName == "name")
                {
                    returnID = Element.GID;
                }
            });
            return returnID;
            //returnt ID, falls Name nicht gefunden -1
        }

        public string getNameByID(int id)
        {
            List<Group> GroupList = new List<Group>();
            GroupList = getAllGroups();

            string returnName = "-1";
            GroupList.ForEach(delegate (Group Element)
            {
                if (Element.GID == id)
                {
                    returnName = Element.GName;
                }
            });
            return returnName;
            //returnt Name, falls Name nicht gefunden -1
        }

        public List<int> getAllUsersOfGroup(int id)
        {
            List<Models.User> UsersOfGroupList = new List<User>();
            List<int> idList = new List<int>();
            using (SQLiteConnection conn = new SQLiteConnection(@"Data Source=C:\Users\Simon Weber Work\Documents\GitHub\Services-Plus-SQLite\WpfNetCoreMvvm\Management.db;"))
            {
                conn.Open();

                SQLiteCommand command = new SQLiteCommand("Select * from UsersGroups", conn);
                SQLiteDataReader reader = command.ExecuteReader();


                while (reader.Read())
                {
                    if(int.Parse(reader["gID"].ToString()) == id){
                        idList.Add(int.Parse(reader["uID"].ToString()));
                    }
                 
                }


                reader.Close();
            }
            return idList;      //Liste mit ids aller, die in gewähtler gruppe sind
        }

        public void createGroup(int id, string name) {
            using (SQLiteConnection conn = new SQLiteConnection(@"Data Source=C:\Users\Simon Weber Work\Documents\GitHub\Services-Plus-SQLite\WpfNetCoreMvvm\Management.db;"))
            {
                conn.Open();

                SQLiteCommand command = new SQLiteCommand($"INSERT INTO Groups(gID, gName) VALUES ({id},'{name}')", conn);
                command.ExecuteNonQuery();
            }
    }
}}

