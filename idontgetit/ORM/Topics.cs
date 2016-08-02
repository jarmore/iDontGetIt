using System;
using System.Data;
using System.IO;
using SQLite;

namespace idontgetit.ORM
{
    [Table("TopicsNotunderstood")]
    public class Topics
    {
        [PrimaryKey,AutoIncrement,Column("_id")]
        public int id { get; set; }

        [NotNull]
        public string topic { get; set; }
    }
}