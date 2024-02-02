using System;
namespace SAMPLE_NetCoreMVC.Models
{
	public class SampleItemModel
	{
		public string? Title { get; set; }
        public string? Description { get ; set; }
        public Decimal Cost { get; set; }
        public int Qty { get; set; }
        public int Sold { get; set; }


        public SampleItemModel(string INtitle, string INdes, decimal INcost, int INqty, int INsold)
		{
			Title = INtitle;
			Description = INdes;
			Cost = INcost;
			Qty = INqty;
			Sold = INsold;



		}
	}
}

