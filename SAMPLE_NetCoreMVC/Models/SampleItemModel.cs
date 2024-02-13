using System;
namespace SAMPLE_NetCoreMVC.Models
{
	public class SampleItemModel
	{
        public string? Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get ; set; }
        public Decimal Cost { get; set; }
        public int Qty { get; set; }
        public int Sold { get; set; }


     
	}
}

