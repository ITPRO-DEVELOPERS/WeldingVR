using SQLite4Unity3d;

namespace nsDB
{
    [Table("comments")]
    public class Comment
    {
        [PrimaryKey, AutoIncrement, Column("com_id")]
        public int    com_id       { get; set; }
        public string com_text     { get; set; }
        public string com_lab_id   { get; set; }
    }
}