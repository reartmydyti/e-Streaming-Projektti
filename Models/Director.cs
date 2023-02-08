using System.ComponentModel.DataAnnotations;

namespace MovieDB.Models
{
    public class Director
    {
        [Key]
        public int Director_ID { get; set; }
        public string Director_Name { get; set; }
        public int Nacionaliteti_ID { get; set; }
        
    }
}
