using System;
namespace SAMPLE_NetCoreMVC.Models
{
	public class RazorExampleModel
	{

        public List<SampleItemModel> Items = new List<SampleItemModel>();

        public SampleItemModel? Item;


        public RazorExampleModel()
		{


			Items.Add(new SampleItemModel("A_Item", "This is an A Item.", 1.00m, 8, 10));
            Items.Add(new SampleItemModel("B_Item", "This is an B Item.", 2.00m, 7, 5));
            Items.Add(new SampleItemModel("C_Item", "This is an C Item.", 3.00m, 6, 3));
            Items.Add(new SampleItemModel("D_Item", "This is an D Item.", 4.00m, 5, 8));
            Items.Add(new SampleItemModel("E_Item", "This is an E Item.", 5.00m, 4, 1));
            Items.Add(new SampleItemModel("F_Item", "This is an F Item.", 6.00m, 3, 22));
            Items.Add(new SampleItemModel("G_Item", "This is an G Item.", 7.00m, 2, 0));
            Items.Add(new SampleItemModel("H_Item", "This is an H Item.", 8.00m, 1, 1));


        }
	}
}

