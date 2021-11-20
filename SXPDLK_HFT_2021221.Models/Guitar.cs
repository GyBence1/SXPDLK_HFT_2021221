using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SXPDLK_HFT_2021221.Models
{
    public enum GuitarTypes
    { 
        Acoustic,Electric
    }
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
        public GuitarTypes Type { get; set; }
        public double Price { get; set; }
        [NotMapped]
        public virtual Brand Brand { get; set; }
        public int BrandId { get; set; }
        [NotMapped]
        public virtual ICollection<Purchase> Purchases { get; set; }
        public Guitar()
        {
            Purchases = new HashSet<Purchase>();
        }


    }
}
