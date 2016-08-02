using System;

using System.Data;
using System.IO;
using SQLite;

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

        // Code to retrieve all the records 
        public string GetAllRecords()
        {
            var db = new SQLiteConnection(dbPath);
            string output = "";
            output += "Retrieving the data using ORM...";
            var table = db.Table<Topics>();
            foreach (var item in table)
            {
                output += "\n" + item.id + "...." + item.topic;
            }
            return output;
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