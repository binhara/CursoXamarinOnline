using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace Intent1
{
	[Activity (Label = "Intent1", MainLauncher = true)]
	public class MainActivity : Activity
	{
		int count = 1;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);


			var layout = new LinearLayout(this);
			layout.Orientation = Orientation.Vertical;






			var aButtonLigar = new Button(this);
			aButtonLigar.Text = "Ligar para OnlineSites";

			var aButtonNovaTela = new Button (this);

			aButtonNovaTela.Text = "Abrir outra Atividade";

			// Get our button from the layout resource,
			// and attach an event to it

			aButtonLigar.Click += delegate {
				var act = new Activity2();


			};

			aButtonLigar.Click += delegate {

//				var activity = new Intent(this,typeof(Activity2));
//				activity.PutExtra("dado1","Ola intent 2");
////				StartActivity(activity);

				var uri = Android.Net.Uri.Parse("tel:03732215817");
				var intent = new Intent(Intent.ActionView,uri);
				StartActivity(intent);

			};

			layout.AddView(aButtonLigar);

			// Set our view from the "main" layout resource
			SetContentView (layout);
		}
	}
}


