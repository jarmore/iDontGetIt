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
using Android.Util;
using idontgetit.ORM;

namespace idontgetit
{
    [Activity(Label = "TeacherModule")]
    public class TeacherModule : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_teacher_module);
            // Create your application here

            Button btnInsertTopic = FindViewById<Button>(Resource.Id.button_insert);

            btnInsertTopic.Click += BtnInsertTopic_Click;
        // Do some code here to insert topic into database


        }

        private void BtnInsertTopic_Click(object sender, EventArgs e)
        {
            DBRepository dbr = new DBRepository();
            var result = dbr.CreateTable();
            Toast.MakeText(this, result, ToastLength.Short).Show();
            Log.Info("devInfo", result);

            TextView topicToAdd = FindViewById<TextView>(Resource.Id.editTopicToAdd);
            if(topicToAdd.Text != "")
            {
                dbr.insertTopic(topicToAdd.Text);
                Toast.MakeText(this, "Topic: " + topicToAdd.Text + "Has been added successfully to the database", ToastLength.Short).Show();

            }
            else
            {
                Toast.MakeText(this, "Please insert a topic before trying to add one", ToastLength.Short).Show();
            }
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_teacher_module, menu);
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

        [Java.Interop.Export("viewStatistics")]
        public void teacherModule(View view)
        {
            var newActivity = new Intent(this, typeof(Statistics)); StartActivity(newActivity);
        }
    }
}