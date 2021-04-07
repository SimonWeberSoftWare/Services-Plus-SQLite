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
    
        public Users UserList { get; set; } = new Users();

    public void getAllUsers()
        {
            using (SQLiteConnection conn = new SQLiteConnection(@"Data Source=C:\Users\simon.weber\Downloads\WpfNetCoreMvvm\WpfNetCoreMvvm\Management.db;"))
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
        }

      public  int getIDByName(string name)
        {
            using (SQLiteConnection conn = new SQLiteConnection(@"Data Source=C:\Users\simon.weber\Downloads\WpfNetCoreMvvm\WpfNetCoreMvvm\Management.db;"))
            {
                conn.Open();

                SQLiteCommand command = new SQLiteCommand("Select * from Users", conn);
                SQLiteDataReader reader = command.ExecuteReader();


                while (reader.Read())
                {
                    if(reader["uName"].ToString() == name)
                    {
                        return int.Parse(reader["uID"].ToString());
                    }
                }
                    //Debug.WriteLine(reader["uName"].ToString());

                reader.Close();
            }
            return -1;
        }

      public  string getNameByID(int id)
        {
            using (SQLiteConnection conn = new SQLiteConnection(@"Data Source=C:\Users\simon.weber\Downloads\WpfNetCoreMvvm\WpfNetCoreMvvm\Management.db;"))
            {
                conn.Open();

                SQLiteCommand command = new SQLiteCommand("Select * from Users", conn);
                SQLiteDataReader reader = command.ExecuteReader();


                while (reader.Read())
                {
                    if (reader["uID"].ToString() == id.ToString())
                    {
                        return reader["uName"].ToString();
                    }
                }
             

                reader.Close();
            }
            return "nothere";
        }
    }
}
