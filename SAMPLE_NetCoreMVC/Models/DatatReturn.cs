using System;
namespace SAMPLE_NetCoreMVC.Models
{
	public class DatatReturn
	{

		public IList<SampleItemModel> SampleItems { get; set; }


        public  DatatReturn()
        {

            SampleItems = new List<SampleItemModel>();

        }


        }
}

