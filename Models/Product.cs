using System.ComponentModel.DataAnnotations;

namespace CrudApplication1.Models
{
    public class Product
    {
        [Key]
        public int Id{ get; set; }
        [Required(ErrorMessage ="name cant be blank")]
        public   string PName { get; set; }

        public  int Id1 { get; set; }
        public string CName { get; set; }
    }
}
