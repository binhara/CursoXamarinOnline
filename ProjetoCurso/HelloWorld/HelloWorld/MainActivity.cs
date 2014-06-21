using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace HelloWorld
{
    [Activity(Label = "HelloWorld", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        int count = 0;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            var layout = new LinearLayout(this);
            layout.Orientation = Orientation.Vertical;

            var aLabel = new TextView(this);

            aLabel.Text = "Olá Mundo!!!";

            var aButton = new Button(this);

            aButton.Text = "Meu Botão";

            aButton.Click += (sender, e) =>
            {
                count++;
                aLabel.Text = String.Format("Cliquei,{0}",count);
            };

            layout.AddView(aLabel);
            layout.AddView(aButton);


            // Set our view from the "main" layout resource
            SetContentView(layout);

			

            //Button button = FindViewById<Button>(Resource.Id.MyButton);

            //button.Click += delegate { button.Text = string.Format("{0} clicks!", count++); };
        }
    }
}

