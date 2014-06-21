using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace Intent1
{
	[Activity (Label = "Intent2")]
	public class Activity2 : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			var layout = new LinearLayout(this);
			layout.Orientation = Orientation.Vertical;

			var aLabel = new TextView (this);
			aLabel.Text = Intent.GetStringExtra ("dado1");


			layout.AddView (aLabel);

			SetContentView (layout);
		}
	}

}


