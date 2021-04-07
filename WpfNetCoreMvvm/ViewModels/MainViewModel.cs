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
       

        private readonly ISampleService sampleServiceTest;
        private readonly AppSettings settings;
        private readonly IGetArtist getArtist;

        private readonly IWriteSomething writeSomething;

        public RelayCommand ExecuteCommand { get; }

        public MainViewModel(ISampleService sampleService,
            IOptions<AppSettings> options, IWriteSomething writeSomething, IGetArtist getArtist)
        {
            this.sampleServiceTest = sampleService;
            settings = options.Value;

            this.writeSomething = writeSomething;
            this.getArtist = getArtist;
            ExecuteCommand = new RelayCommand(async () => await ExecuteAsync());
            /*
            using (SQLiteConnection conn = new SQLiteConnection(@"Data Source=C:\Users\simon.weber\Downloads\chinook\chinook.db;"))
            {
                conn.Open();

                SQLiteCommand command = new SQLiteCommand("Select * from artists", conn);
                SQLiteDataReader reader = command.ExecuteReader();

                while (reader.Read())
                    artistlist.Add(reader["Name"].ToString());

                reader.Close();
            }*/

            using (SQLiteConnection conn = new SQLiteConnection(@"Data Source=C:\Users\Simon Weber Work\Documents\GitHub\Services-Plus-SQLite\WpfNetCoreMvvm\Management.db;"))
            {
                conn.Open();

                SQLiteCommand command = new SQLiteCommand("Select * from Users", conn);
                SQLiteDataReader reader = command.ExecuteReader();
                

                while (reader.Read())
                    Debug.WriteLine(reader["uName"].ToString());

                reader.Close();
            }

            
        

        }

        public List<string> artistlist { get; set; } = new List<string>();

        private Task ExecuteAsync()
        {
            Debug.WriteLine(sampleServiceTest.GetCurrentDate());
            Debug.WriteLine(writeSomething.WriteSomethingAsString("as string"));
            CurTime = sampleServiceTest.GetCurrentDate();
            OnPropertyChanged(nameof(CurTime));

            Artist = artistlist[2];
            OnPropertyChanged(nameof(Artist));

           ArtistId = getArtist.GetArtistID("Kiss");
            OnPropertyChanged(nameof(ArtistId));
            return Task.CompletedTask;
        }

        private string _curTime ;
        public string CurTime
        {
            get => _curTime;
            set => SetProperty(ref _curTime, value);
        }

        private string _artist;
        public string Artist
        {
            get => _artist;
            set => SetProperty(ref _artist, value);
        }

        private int _artistId=0;
        public int ArtistId
        {
            get => _artistId;
            set => SetProperty(ref _artistId, value);
        }
    }
}
