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



namespace WpfNetCoreMvvm.ViewModels
{
    public class MainViewModel : Microsoft.Toolkit.Mvvm.ComponentModel.ObservableObject, INotifyPropertyChanged
    {
       

        private readonly ISampleService sampleServiceTest;
        private readonly AppSettings settings;

        private readonly IWriteSomething writeSomething;

        public RelayCommand ExecuteCommand { get; }

        public MainViewModel(ISampleService sampleService,
            IOptions<AppSettings> options, IWriteSomething writeSomething)
        {
            this.sampleServiceTest = sampleService;
            settings = options.Value;

            this.writeSomething = writeSomething;
            
            ExecuteCommand = new RelayCommand(async () => await ExecuteAsync());
        }

        private Task ExecuteAsync()
        {
            Debug.WriteLine(sampleServiceTest.GetCurrentDate());
            Debug.WriteLine(writeSomething.WriteSomethingAsString("as string"));
            CurTime = sampleServiceTest.GetCurrentDate();
            OnPropertyChanged(nameof(CurTime));
            return Task.CompletedTask;
        }

        private string _curTime;
        public string CurTime
        {
            get => _curTime;
            set => SetProperty(ref _curTime, value);
        }

    }
}
