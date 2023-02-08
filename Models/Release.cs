using System.ComponentModel.DataAnnotations;

namespace MovieDB.Models
{
    public class Release
    {
        [Key]
        public int Release_ID { get; set; }
        public string Release_Name { get; set; }
    }
}
