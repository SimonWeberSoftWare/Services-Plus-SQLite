using System;
using System.Collections.Generic;
using System.Text;

namespace WpfNetCoreMvvm.Services
{
   public class WriteSomething : IWriteSomething        //hier wird das Interface Plattformspezificsh implementiert
    {
        public string WriteSomethingAsString(string s)
        {
            return "something " + s;
        }
    }
}
