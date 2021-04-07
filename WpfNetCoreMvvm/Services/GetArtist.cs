using System;
using System.Data.SQLite;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace WpfNetCoreMvvm.Services
{
    public class GetArtist : IGetArtist
    {
        public int GetArtistID(string artist)
        {
            using (SQLiteConnection conn = new SQLiteConnection(@"Data Source=C:\Users\simon.weber\Downloads\chinook\chinook.db;"))
            {
                conn.Open();

                SQLiteCommand command = new SQLiteCommand("Select * from artists", conn);
                SQLiteDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    if(reader["Name"].ToString() == artist)
                    {
                        return int.Parse(reader["ArtistId"].ToString());
                    }
                }
                    

                reader.Close();
            }

            return -1;
        }
    }
}