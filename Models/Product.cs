using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiTest.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Column(TypeName = "varchar(32)")]
        public string ProductName { get; set; }

        [Column(TypeName = "varchar(32)")]
        public string ProductDescription { get; set; }

        [Column(TypeName = "decimal(18,3)")]
        public decimal ProductPrice { get; set; }

        [Column(TypeName = "varchar(500)")]
        public string ProductImage { get; set; }
    }
}
