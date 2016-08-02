using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace idontgetit
{
    [Activity(Label = "Statistics")]
    public class Statistics : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_statistics);
            // Create your application here
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_statistics, menu);
            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnMenuItemSelected(int featureId, IMenuItem item)
        {
            if (item.ItemId == Resource.Id.return_to_module_select)
            {
                var newActivity = new Intent(this, typeof(MainActivity));
                StartActivity(newActivity);
                return true;
            }
            return base.OnMenuItemSelected(featureId, item);
        }

        [Java.Interop.Export("back")]
        public void teacherModule(View view)
        {
            var newActivity = new Intent(this, typeof(TeacherModule)); StartActivity(newActivity);
        }
    }
}