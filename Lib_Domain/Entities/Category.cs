﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib_Domain.Entities
{
    public class Category : BaseEntity
    {
        [Required]
        [StringLength(250)]
        public string? Name { get; set; }

        [StringLength(1000)]
        public string? Description { get; set; }
    }
}
