

using System;
using System.Collections.Generic;
using System.Text;

namespace SAMPLE_NetCoreMVC.Helpers
{

    public interface IAppSettingsModel
    {

        AppSettings _appSettings { get; set; }

    }




    public class AppSettingsModel : IAppSettingsModel
    {


        public AppSettings _appSettings { get; set; }

        public AppSettingsModel(AppSettings con)
        {

            _appSettings = con;


        }



    }
}
