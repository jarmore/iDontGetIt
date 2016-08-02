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
using idontgetit.ORM;

namespace idontgetit
{
    [Activity(Label = "Missunderstood")]
    public class Missunderstood : Activity
    {
        public List<string> topics;
        int currentSelectedTopic = -1;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_missunderstood);

            ListView listView = FindViewById<ListView>(Resource.Id.listView);

            Button btnUnderstood = FindViewById<Button>(Resource.Id.understood_button);
            btnUnderstood.Click += BtnUnderstood_Click;


            // Create list of missunderstood topics here 
            DBRepository db = new DBRepository();
            topics = db.GetAllMissunderstoodTopics();
            listView.SetAdapter(new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, topics));
            listView.ItemClick += ListView_ItemClick;
            
        }

        private void BtnUnderstood_Click(object sender, EventArgs e)
        {
            DBRepository db = new DBRepository();
            if (currentSelectedTopic != -1)
            {
                db.removeMissunderstoodTopic(currentSelectedTopic + 1);
               // SetContentView(Resource.Layout.activity_missunderstood);
            }
            else
            {
                Toast.MakeText(this, "Please select a topic before trying to understand it.", ToastLength.Short).Show();
            }
        }

        private void ListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var t = topics[e.Position];
            Toast.MakeText(this, t.ToString() + " is currently selected", Android.Widget.ToastLength.Short).Show();
            currentSelectedTopic = e.Position;
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_missunderstood, menu);
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
            var newActivity = new Intent(this, typeof(StudentModule)); StartActivity(newActivity);
        }
    }
}