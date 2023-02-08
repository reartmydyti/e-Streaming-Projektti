using System.ComponentModel.DataAnnotations;

namespace MovieDB.Models
{
    public class Titrat
    {
        [Key]
        public int Titrat_ID { get; set; }
        public string Titrat_Name { get; set; }
    }
}
