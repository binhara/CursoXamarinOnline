using System;
using System.Threading;
using Android.App;
using Android.Content;
using Android.Provider;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace Aula2806
{
    [Activity(Label = "Aula2806", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        
      

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            StartService(new Intent("SimpleService"));


        }

      

       
    }
}

