
using System;
using System.Collections.Generic;
using System.Text;

namespace SAMPLE_NetCoreMVC.Helpers
{
    public class ConnectionString
    {

        //public string Name { get; set; }
        public string Connection { get; set; }
        public string ProviderName { get; set; }


       public ConnectionString()
        {

            Connection = "";
            ProviderName = "";

        }


    }
}
