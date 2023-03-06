using SQLite4Unity3d;

namespace nsDB
{
    [Table("laboratory_works")]
    public class LaboratoryWork
    {
        [PrimaryKey, AutoIncrement, Column("lab_id")]
        public int    lab_id            { get; set; }
        public string lab_name          { get; set; }
        public string lab_description   { get; set; }
        public int    lab_difficulty    { get; set; }
        public string lab_start_time    { get; set; }
        public string lab_end_time      { get; set; }
        public int    lab_tch_id        { get; set; }
        public int    lab_usr_id        { get; set; }
        
    }
}