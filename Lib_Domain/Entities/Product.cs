using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib_Domain.Entities
{
    public class Product : BaseEntity
    {
        public int QuantityPerUnti { get; set; }
        public double UntiPrice { get; set; }
        public int UnitInStock { get; set; }
        public DateTime CreateDate { get; set; }
        public int UntiOnOrder { get; set; }
        [Required]
        public int IdCategory { get; set; }

        [ForeignKey("IdCategory")]
        public virtual Category? Category { get; set; }
    }
}
