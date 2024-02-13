

using System;
using System.Collections.Generic;
using System.Text;

namespace SAMPLE_NetCoreMVC.Helpers
{
    public class ConnectionSettings
    {



        public ConnectionString SampleDBConnection { get; set; }


       public ConnectionSettings()
        {

            SampleDBConnection = new ConnectionString();
        }




    }
}
