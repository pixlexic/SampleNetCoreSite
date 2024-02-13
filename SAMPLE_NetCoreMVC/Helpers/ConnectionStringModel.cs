
using System;
using System.Collections.Generic;
using System.Text;

namespace SAMPLE_NetCoreMVC.Helpers
{
    public interface IConnectionStringModel
    {
        ConnectionSettings _connectionSettings { get; set; }

    }



    public class ConnectionStringModel : IConnectionStringModel
    {

        public ConnectionSettings _connectionSettings { get; set; }

        public ConnectionStringModel(ConnectionSettings con)
        {

            _connectionSettings = con;

     

        }



    }
}
