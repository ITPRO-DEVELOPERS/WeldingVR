using SQLite4Unity3d;

namespace nsDB
{
    [Table("errors")]
    public class Error
    {
        [PrimaryKey, AutoIncrement, Column("err_id")]
        public int    err_id          { get; set; }
        public string err_hnt_id      { get; set; }
        public string err_numer       { get; set; }
        public string err_description { get; set; }
        public string err_lab_id      { get; set; }
    }
}