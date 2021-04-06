using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.Extensions.Options;
using System.Diagnostics;
using System.Threading.Tasks;
using WpfNetCoreMvvm.Models;
using WpfNetCoreMvvm.Services;



namespace WpfNetCoreMvvm.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private string input;
        public string Input
        {
            get => input;
            set => Set(ref input, value);
        }

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

            return Task.CompletedTask;
        }


    }
}
