using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SXPDLK_HFT_2021221.Models
{
    [Table("guitars")]
    public class Guitar
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int Id { get; set; }
        [MaxLength(30)]
        [Required]
        public string Model { get; set; }
        public int? Price { get; set; }
        [NotMapped]
        public virtual Brand Brand { get; set; }
        public int BrandId { get; set; }
       

    }
}
