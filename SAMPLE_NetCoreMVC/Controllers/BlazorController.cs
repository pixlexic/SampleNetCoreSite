using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SAMPLE_NetCoreMVC.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SAMPLE_NetCoreMVC.Controllers
{
    public class BlazorController : BaseController
    {
        // GET: /<controller>/
        public IActionResult Index()
        {

            dynamic VWModel = new ExpandoObject();
            VWModel.BaseVM = this.BaseVM;
            VWModel.Razor = new RazorExampleModel();

            return View(VWModel);
        }







    }
}

