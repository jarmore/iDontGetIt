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
    [Activity(Label = "StudentModule")]
    public class StudentModule : Activity
    {
        public int currentSelectedTopic = -1;
        DBRepository db = new DBRepository();
        List<string> topics;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_student_module_main);

            db.CreateTopicsNotUnderstoodTable();

            Button btnRequestTopic = FindViewById<Button>(Resource.Id.button_next_topic);
            btnRequestTopic.Click += BtnRequestTopic_Click;

            ImageButton btnIDontGetIt = FindViewById<ImageButton>(Resource.Id.button_dontgetit);
            btnIDontGetIt.Click += BtnIDontGetIt_Click;

            Button btnMissunderstoodActivity = FindViewById<Button>(Resource.Id.button_view_missunderstood_topics);
            btnMissunderstoodActivity.Click += BtnMissunderstoodActivity_Click;
        }

        private void BtnMissunderstoodActivity_Click(object sender, EventArgs e)
        {
            var newActivity = new Intent(this, typeof(Missunderstood)); StartActivity(newActivity);
        }

        private void BtnIDontGetIt_Click(object sender, EventArgs e)
        {
            if(currentSelectedTopic != -1)
            {
                db.insertTopicNotUnderstood(topics[currentSelectedTopic]);
                Toast.MakeText(this, topics[currentSelectedTopic] + " has been added succesfully to the missunderstood topics list", ToastLength.Short).Show();
            }
            else
            {
                Toast.MakeText(this, "Please tap on a topic before trying to understand it!", ToastLength.Short).Show();
            }
        }

        private void BtnRequestTopic_Click(object sender, EventArgs e)
        {
            topics = db.GetAllTopics();
            currentSelectedTopic++;

            TextView currentSelected = FindViewById<TextView>(Resource.Id.topic_selected);
            try
            {
                currentSelected.Text = topics[currentSelectedTopic];
            }
            catch (Exception ex)
            {
                Toast.MakeText(this, "There are no more topics for you to request, yay!", ToastLength.Short).Show();
                Log.Info("devInfo", ex.Message);
            }
            
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_student_module_main, menu);
            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnMenuItemSelected(int featureId, IMenuItem item)
        {
            if(item.ItemId == Resource.Id.return_to_module_select)
            {
                var newActivity = new Intent(this, typeof(MainActivity));
                StartActivity(newActivity);
                return true;
            }
            return base.OnMenuItemSelected(featureId, item);
        }
    }
}