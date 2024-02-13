using System;
using System.Collections.Generic;
using Microsoft.Extensions.Options;
using SAMPLE_NetCoreMVC.Helpers;
using SAMPLE_NetCoreMVC.Models;



namespace SAMPLE_NetCoreMVC.Services
{


	public interface IDataService
	{
        public IList<SampleItemModel> GetSampleItems();



    }


     class DataService : IDataService
    {


        private readonly IConnectionStringModel _conSettings;
        private readonly ConnectionString _sampleConnection;
        private readonly AppSettings _appSettings;


        public DataService(IConnectionStringModel conSettings, IAppSettingsModel appSettings)

        {

            _conSettings = conSettings;

            _sampleConnection = _conSettings._connectionSettings.SampleDBConnection;
            _appSettings = appSettings._appSettings;

        }





        public IList<SampleItemModel> GetSampleItems()
        {
            Console.WriteLine(_appSettings.AssetFolder);

            var _db = new PetaPoco.Database(_sampleConnection.Connection, _sampleConnection.ProviderName);

            var res = _db.Fetch<SampleItemModel>("execute [dbo].[GetSampleItems]");


            return res;
        }




    }
}

