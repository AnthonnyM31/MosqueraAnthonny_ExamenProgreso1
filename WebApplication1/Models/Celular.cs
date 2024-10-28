using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Celular
    {

        [Key]
        public int id {  get; set; }
        public string modelo { get; set; }
        public string año { get; set; }
        public string precio { get; set; }
    }
}
