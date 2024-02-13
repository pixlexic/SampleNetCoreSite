using System;
namespace SAMPLE_NetCoreMVC.Models
{
	public class RazorExampleModel
	{

        public  IList<SampleItemModel> Items { get; set; }

        public SampleItemModel Item = new SampleItemModel();


       public RazorExampleModel()
        {
            Items = new List<SampleItemModel>();

        }

    }
}

