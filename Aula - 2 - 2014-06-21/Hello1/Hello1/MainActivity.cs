using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace Hello1
{
	[Activity (Label = "Hello1", MainLauncher = true)]
	public class MainActivity : Activity
	{
		int count = 1;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			SetContentView (Resource.Layout.Main);
			var layout = new LinearLayout (this);
			layout.Orientation = Orientation.Vertical;

			var alabel = new TextView (this);
			alabel.Text= "Olá!!";

			var aButton = new Button (this);
			aButton.Text = "Meu botão";

			aButton.Click += (sender, e) => {
				count ++;
				alabel.Text= string.Format("Cliquei!! {0}",count);
			};

			layout.AddView (alabel);
			layout.AddView (aButton);

			SetContentView (layout);

		}
	}
}


