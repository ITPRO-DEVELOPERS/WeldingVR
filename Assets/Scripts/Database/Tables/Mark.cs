using SQLite4Unity3d;

namespace nsDB
{
    [Table("marks")]
    public class Mark
    {
        [PrimaryKey, AutoIncrement, Column("mrk_id")]
        public int mrk_id     { get; set; }
        public int mrk_value  { get; set; }
        public int mrk_lab_id { get; set; }
    }
}