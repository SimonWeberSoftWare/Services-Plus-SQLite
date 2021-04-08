using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Diagnostics;
using System.Text;
using WpfNetCoreMvvm.Models;

namespace WpfNetCoreMvvm.Services
{
    public class Users : IUsers
    {
        //nur der Service Users hat Zugriff auf die Tabelle Users, 

        //  public  Users UserList { get; set; } = new Users();
        public List<User> UserList = new List<User>();

        public List<User> getAllUsers()
        {
            //speichert alle Einträge der Tabelle Users im Model Users(schlechte Namenswahl)

            using (SQLiteConnection conn = new SQLiteConnection(@"Data Source=C:\Users\Simon Weber Work\Documents\GitHub\Services-Plus-SQLite\WpfNetCoreMvvm\Management.db;"))
            {
                conn.Open();

                SQLiteCommand command = new SQLiteCommand("Select * from Users", conn);
                SQLiteDataReader reader = command.ExecuteReader();

                string curUName;
                int curUID;

                while (reader.Read())
                {
                    curUName = reader["uName"].ToString();
                    curUID = int.Parse(reader["uID"].ToString());
                    UserList.Add(new User() { UID = curUID, UName = curUName });
                }


                reader.Close();
            }
            return UserList;
        }

        public int getIDByName(string name)
        {
            List<User> UserList = new List<User>();
            UserList = getAllUsers();

            int returnID = -1;
            UserList.ForEach(delegate (User Element)
            {
                if (Element.UName == "name")
                {
                    returnID = Element.UID;
                }
            });
            return returnID;
            //returnt ID, falls Name nicht gefunden -1
        }

        public string getNameByID(int id)
        {
            List<User> UserList = new List<User>();
            UserList = getAllUsers();

            string returnName = "-1";
            UserList.ForEach(delegate (User Element)
            {
                if (Element.UID == id)
                {
                    returnName = Element.UName;
                }
            });
            return returnName;
            //returnt Name, falls Name nicht gefunden -1
        }

        public List<int> getAllGroupIDByUser(int id)
        {
            List<int> GroupIDList = new List<int>();
            using (SQLiteConnection conn = new SQLiteConnection(@"Data Source=C:\Users\Simon Weber Work\Documents\GitHub\Services-Plus-SQLite\WpfNetCoreMvvm\Management.db;"))
            {
                conn.Open();

                SQLiteCommand command = new SQLiteCommand("Select * from UsersGroups", conn);
                SQLiteDataReader reader = command.ExecuteReader();

                int curGID;
                //int curUID;

                while (reader.Read())
                {
                    curGID = int.Parse(reader["gID"].ToString());
                    if (int.Parse(reader["uID"].ToString()) == id)  //die GruppenIDs aller Einträge des übergebenen Nutzers werden gespeichert
                    {
                        GroupIDList.Add(curGID);
                    }

                }


                reader.Close();
            }
            return GroupIDList;
        }

        public void createUser(int id, string name)
        {
            using (SQLiteConnection conn = new SQLiteConnection(@"Data Source=C:\Users\Simon Weber Work\Documents\GitHub\Services-Plus-SQLite\WpfNetCoreMvvm\Management.db;"))
            {
                conn.Open();

                SQLiteCommand command = new SQLiteCommand($"INSERT INTO Users(uID, uName) VALUES ({id},'{name}')", conn);
                command.ExecuteNonQuery();
            }
        }

        public void deleteUser(int id)
        {
            using (SQLiteConnection conn = new SQLiteConnection(@"Data Source=C:\Users\Simon Weber Work\Documents\GitHub\Services-Plus-SQLite\WpfNetCoreMvvm\Management.db;"))
            {
                conn.Open();
                SQLiteCommand command = new SQLiteCommand($"DELETE FROM Users WHERE uID ='{id}'", conn);
                command.ExecuteNonQuery();
            }
        }
        
        public void updateUser(int id, string newName)
        {
            using (SQLiteConnection conn = new SQLiteConnection(@"Data Source=C:\Users\Simon Weber Work\Documents\GitHub\Services-Plus-SQLite\WpfNetCoreMvvm\Management.db;"))
            {
                conn.Open();
                SQLiteCommand command = new SQLiteCommand($"UPDATE Users SET uName = '{newName}' WHERE uID = {id}", conn);
                command.ExecuteNonQuery();
            }
        }
    }
}
