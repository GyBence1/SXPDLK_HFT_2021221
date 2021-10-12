﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SXPDLK_HFT_2021221.Models
{
    [Table("brands")]
    public class Brand
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [NotMapped]
        public virtual ICollection<Guitar> Guitars { get; set; }
        public Brand()
        {
            Guitars = new HashSet<Guitar>();
        }
    }
}
