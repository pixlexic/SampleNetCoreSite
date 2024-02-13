using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SAMPLE_NetCoreMVC.Models;
using SAMPLE_NetCoreMVC.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SAMPLE_NetCoreMVC.Areas.API.Controllers
{


    [Area("API")]
    [ApiController]
    [Route("api/[controller]")]
    public class ExampleController : Controller
    {


        private readonly IDataService _dataService;


        public ExampleController(IDataService dataService)
        {

            _dataService = dataService;
        }


        [HttpGet("GetItems")]
        public JsonResult GetItems()
        {


            var _items = _dataService.GetSampleItems();

            DatatReturn _dr = new DatatReturn();
            _dr.SampleItems = _items;

            return new JsonResult(_dr);

        }




    }
}

