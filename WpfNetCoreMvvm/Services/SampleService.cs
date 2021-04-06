using System;

namespace WpfNetCoreMvvm.Services
{
    public class SampleService : ISampleService     //implementiert das definierte Interface, ist die für WPF spezifische Implementation, zB bei Xamarin müsste man dieses ersetzen
    {
        public string GetCurrentDate()
        {
            return DateTime.Now.ToLongDateString();
        }
    }
}
