using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;


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

