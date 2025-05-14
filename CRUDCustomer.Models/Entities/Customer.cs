using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDCustomer.Models.Entities
{
    public class Customer
    {
        [Key]
        [Column("customerid")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerId { get; set; }
        [Column("customercode")]
        [Required]
        [StringLength(50)]
        public string CustomerCode { get; set; }
        [Column("customername")]
        [Required]
        [StringLength(255)]
        public string CustomerName { get; set; }
        [Column("customeraddress")]
        [Required]
        [StringLength(1000)]
        public string? CustomerAddress { get; set; } = string.Empty;
        [Column("createdby")]
        [Required]
        public int CreatedBy { get; set; }
        [Column("createdat")]
        [Required]
        public DateTime? CreatedAt { get; set; }
        [Column("modifiedby")]
        public int? ModifiedBy { get; set; }
        [Column("modifiedat")]
        public DateTime? ModifiedAt { get; set; }

    }
}
