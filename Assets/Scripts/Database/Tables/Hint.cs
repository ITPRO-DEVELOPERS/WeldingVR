using SQLite4Unity3d;

namespace nsDB
{
    [Table("hints")]
    public class Hint
    {
        [PrimaryKey, AutoIncrement, Column("hnt_id")]
        public int    hnt_id          { get; set; }
        public string hnt_name        { get; set; }
        public string hnt_description { get; set; }
        public int    hnt_number      { get; set; }
        public int    hnt_lab_id      { get; set; }
    }
}