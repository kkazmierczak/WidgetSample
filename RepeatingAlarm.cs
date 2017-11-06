using System;
using Android.Content;
using Android.Widget;
using Android.Appwidget;

namespace SimpleWidget
{
    [BroadcastReceiver]
    public class RepeatingAlarm : BroadcastReceiver
    {
        public override void OnReceive(Context context, Intent intent)
        {
            var updateViews = new RemoteViews(context.PackageName, Resource.Layout.widget_main);
            updateViews.SetTextViewText(Resource.Id.test, DateTime.Now.ToString());
            ComponentName thisWidget = new ComponentName(context, Java.Lang.Class.FromType(typeof(SimpleWidget)).Name);
            AppWidgetManager manager = AppWidgetManager.GetInstance(context);
            manager.UpdateAppWidget(thisWidget, updateViews);
        }
    }
}