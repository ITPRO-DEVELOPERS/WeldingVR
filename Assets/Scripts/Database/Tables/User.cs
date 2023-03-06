using SQLite4Unity3d;

namespace nsDB
{
    [Table("users")]
    public class User
    {
        [PrimaryKey, AutoIncrement, Column("usr_id")]
        public int    usr_id       { get; set; }
        public string usr_name     { get; set; }
        public string usr_password { get; set; }
        public string usr_fio      { get; set; }
    }
}