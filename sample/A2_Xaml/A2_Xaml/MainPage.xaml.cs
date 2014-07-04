using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace A2_Xaml
{	
	public partial class MainPage : ContentPage
	{	
		public MainPage ()
		{
			InitializeComponent ();

            buttonExecute.Clicked += (sender, e) => 
                labelName.Text = "Executed!";
		}
	}
}

