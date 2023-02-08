using System.ComponentModel.DataAnnotations;

namespace MovieDB.Models
{
    public class Nacionaliteti
    {
        [Key]
        public int Nacionaliteti_ID { get; set; }
        public string Nacionaliteti_Name { get; set; }
        
    }
}
