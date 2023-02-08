using System.ComponentModel.DataAnnotations;

namespace MovieDB.Models
{
    public class Producer
    {
        [Key]
        public int Producer_ID { get; set; }
        public string Producer_Name { get; set; }
        public int Nacionaliteti_ID { get; set; }
    }
}
