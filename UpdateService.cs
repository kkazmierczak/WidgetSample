using System;
using Android.App;
using Android.Appwidget;
using Android.Content;
using Android.OS;
using Android.Widget;
using Java.Interop;

namespace SimpleWidget
{
    [Service]
    public class UpdateService : Service
    {
        [Obsolete]
        public override void OnStart(Intent intent, int startId)
        {
            var updateViews = new RemoteViews(this.PackageName, Resource.Layout.widget_main);
            updateViews.SetTextViewText(Resource.Id.test, DateTime.Now.ToString());
            ComponentName thisWidget = new ComponentName(this, Java.Lang.Class.FromType(typeof(SimpleWidget)).Name);
            AppWidgetManager manager = AppWidgetManager.GetInstance(this);
            manager.UpdateAppWidget(thisWidget, updateViews);

            Intent alarmIntent = new Intent(this, typeof(RepeatingAlarm));
            var source = PendingIntent.GetBroadcast(this, 0, alarmIntent, 0);
            AlarmManager alarmManager = GetSystemService(AlarmService).JavaCast<AlarmManager>();
            alarmManager.SetRepeating(AlarmType.ElapsedRealtimeWakeup, SystemClock.CurrentThreadTimeMillis(), 10000, source);
        }

        public override IBinder OnBind(Intent intent)
        {
            // We don't need to bind to this service
            return null;
        }
    }
}

