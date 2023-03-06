using SQLite4Unity3d;

namespace nsDB
{
    [Table("ratings")]
    public class Rating
    {
        [PrimaryKey, AutoIncrement, Column("rtn_id")]
        public int  rtn_id        { get; set; }
        public int  rtn_usr_id    { get; set; }
        public int  rtn_value     { get; set; }
        public int  rtn_mrk_id    { get; set; }
    }
}