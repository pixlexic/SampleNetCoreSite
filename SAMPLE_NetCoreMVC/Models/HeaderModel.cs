using System;
namespace SAMPLE_NetCoreMVC.Models
{
	public class HeaderModel
	{

		public List<string> Items = new List<string>(); 


		public HeaderModel()
		{
			Items.Add("Home");
            Items.Add("Blazor");
            Items.Add("Angular");
            Items.Add("React");


        }



	}
}

