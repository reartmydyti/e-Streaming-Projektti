using System.ComponentModel.DataAnnotations;

namespace MovieDB.Models
{
    public class Season
    {
        [Key]
        public int Season_ID { get; set; }
        public string Season_Name { get; set; }
    }
}
