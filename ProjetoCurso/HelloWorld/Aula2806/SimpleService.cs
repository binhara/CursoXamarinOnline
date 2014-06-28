using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace Aula2806
{
    [Service]
    public class SimpleService : Service
    {
        private System.Threading.Timer _timer;

        public override void OnStart(Android.Content.Intent intent, int startId)
        {
            base.OnStart(intent,startId);

            Log.Debug("SimpleService", "Simple Service started");
            DoStuff();
        }

        public override void OnDestroy()
        {
            base.OnDestroy();

            _timer.Dispose();
        }

        private void DoStuff()
        {
            _timer = new System.Threading.Timer((o) => Log.Debug("SimpleService", "Olá serviço simples"), null, 0, 4000);
        }

        public override IBinder OnBind(Intent intent)
        {
            throw new NotImplementedException();
        }
    }
}