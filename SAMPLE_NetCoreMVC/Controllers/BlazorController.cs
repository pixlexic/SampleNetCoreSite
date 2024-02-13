using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SAMPLE_NetCoreMVC.Models;
using SAMPLE_NetCoreMVC.Services;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SAMPLE_NetCoreMVC.Controllers
{
    public class BlazorController : BaseController
    {

        private readonly IDataService _dataService;



public BlazorController(IDataService dataService)
        {
            _dataService = dataService;
        }



        // GET: /<controller>/
        public IActionResult Index()
        {

            dynamic VWModel = new ExpandoObject();
            VWModel.BaseVM = this.BaseVM;
            VWModel.Razor = new RazorExampleModel();

            VWModel.Razor.Items = _dataService.GetSampleItems();

            /*
            if (VWModel.Razor.Items.Count == 0)
            {
                var _A = new SampleItemModel();
                _A.Id = "A";
                _A.Title = "A Item";
                _A.Description = "This is A Item.";
                _A.Qty = 1;
                _A.Cost = 1m;
                _A.Sold = 5;
            }
            */

            return View(VWModel);
        }







    }
}

