using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SXPDLK_HFT_2021221.Models
{
    [Table("purchases")]
    public class Purchase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int Id { get; set; }
        [Required]
        [MaxLength(40)]
        public string BuyerName { get; set; }
        public string BuyerCity { get; set; }
        public string BrandName { get; set; }
        public int Rating { get; set; }
        [NotMapped]
        public virtual Guitar Guitar { get; set; }
        public int GuitarId { get; set; }
        

    }
}
