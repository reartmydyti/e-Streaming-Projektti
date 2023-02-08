using System.ComponentModel.DataAnnotations;

namespace MovieDB.Models
{
    public class Resolution
    {
        [Key]
        public int Resolution_ID { get; set; }
        public string Resolution_Name { get; set; }
    }
}
