using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using idontgetit.ORM;
using Android.Util;

namespace idontgetit
{
    [Activity(Label = "idontgetit", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            DBRepository dbr = new DBRepository();
            var result = dbr.CreateDB();

            Log.Info("devInfo", result);
            //Toast.MakeText(this, result, ToastLength.Short).Show();

        }

        [Java.Interop.Export("studentModule")]
        public void studentModule(View view)
        {
            var newActivity = new Intent(this, typeof(StudentModule)); StartActivity(newActivity);
        }

        [Java.Interop.Export("teacherModule")]
        public void teacherModule(View view)
        {
            var newActivity = new Intent(this, typeof(TeacherModule)); StartActivity(newActivity);
        }
    }
}

