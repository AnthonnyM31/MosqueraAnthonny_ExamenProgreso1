using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class AMosquera
    {

        [Key]
        public int edad {  get; set; }
       public float numeroFavorito { get; set; }
       public String apodo { get; set; }
        public Boolean genero { get; set; }
        public DateTime fecha { get; set; }
    
        

        
       
    }
}
