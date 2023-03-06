using SQLite4Unity3d;

namespace nsDB
{
    [Table("teachers")]
    public class Teacher
    {
        [PrimaryKey, AutoIncrement, Column("tch_id")]
        public int    tch_id       { get; set; }
        public string tch_name     { get; set; }
        public string tch_password { get; set; }
        public string tch_fio    { get; set; }
    }
}