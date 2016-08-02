using System;

using System.Data;
using System.IO;
using SQLite;
using Android.Util;
using System.Collections.Generic;

namespace idontgetit.ORM
{
    public class DBRepository
    {
        string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "database.db3");
        // Code to crete the database
        public string CreateDB()
        {
            var output = "";
            output += "Creating Database if it doesn't exist.";
            var db = new SQLiteConnection(dbPath);
            output += "\nDatabase Created";
            return output;
        }

        // Code to create the topic Table
        public string CreateTopicTable()
        {
            try
            {
                var db = new SQLiteConnection(dbPath);
                db.CreateTable<Topics>();
                string result = "Table Created successfully";
                return result;
            }
            catch (Exception ex)
            {
                return "Error :  " + ex.Message;
            }
        }

        // Code to create the topicsNotUnderstoodTable Table
        public string CreateTopicsNotUnderstoodTable()
        {
            try
            {
                var db = new SQLiteConnection(dbPath);
                db.CreateTable<TopicsNotUnderstood>();
                string result = "Table Created successfully";
                return result;
            }
            catch (Exception ex)
            {
                return "Error :  " + ex.Message;
            }
        }

        // Code to insert topic into table 
        public string insertTopic(string topic)
        {
            try
            {
                var db = new SQLiteConnection(dbPath);

                Topics item = new Topics();
                item.topic = topic;
                db.Insert(item);
                return "Record Added...";
            }
            catch (Exception ex)
            {

                return "Error : " + ex.Message;
            }
        }

        // Code to insert topic into table 
        public string insertTopicNotUnderstood(string topic)
        {
            try
            {
                var db = new SQLiteConnection(dbPath);

                TopicsNotUnderstood item = new TopicsNotUnderstood();
                item.topic = topic;
                db.Insert(item);
                return "Record Added...";
            }
            catch (Exception ex)
            {

                return "Error : " + ex.Message;
            }
        }

        // Code to retrieve all the records 
        public List<string> GetAllTopics()
        {
            List<string> topics = new List<string>();
            var db = new SQLiteConnection(dbPath);
            string output = "";
            output += "Retrieving the data using ORM...";
            var table = db.Table<Topics>();
            foreach (var item in table)
            {
                output += "\n" + item.id + "...." + item.topic;
                topics.Add(item.topic);
            }
            Log.Info("devInfo", output);
            return topics;
        }

        // Code to retrieve all the records 
        public List<string> GetAllMissunderstoodTopics()
        {
            List<string> topics = new List<string>();
            var db = new SQLiteConnection(dbPath);
            string output = "";
            output += "Retrieving the data using ORM...";
            var table = db.Table<TopicsNotUnderstood>();
            foreach (var item in table)
            {
                output += "\n" + item.id + "...." + item.topic;
                topics.Add(item.topic);
            }
            Log.Info("devInfo", output);
            return topics;
        }

        public string removeTopic(int id)
        {
            var db = new SQLiteConnection(dbPath);
            var item = db.Get<Topics>(id);
            db.Delete(item);
            return "Topic removed.";
        }

        public string removeMissunderstoodTopic(int id)
        {
            // TODO Just have to make this sql command (Will probably have to make it search by name instead of using the id) work properly
            // By using another sql command that finds math and returns the id of math to this method
            var db = new SQLiteConnection(dbPath);
            var item = db.Get<TopicsNotUnderstood>(id);
            db.Delete(item);
            return "Topic removed.";
        }


        // Code to retrieve entry by id 
        //public string getEntryById(int id)
        //{
        //    var db = new SQLiteConnection(dbPath);
        //    var item = db.Get</* What table you want*/TopicsNotUnderstood>(id);
        //    return item.topic;
        //}
    }
}