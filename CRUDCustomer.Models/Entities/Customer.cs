using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDCustomer.Models.Entities
{
    [Table("customer")]
    public class Customer
    {
        [Column("customerid")]
        public int CustomerId { get; set; }
        [Column("customercode")]
        public string CustomerCode { get; set; }
        [Column("customername")]
        public string CustomerName { get; set; }
        [Column("customeraddress")]
        public string? CustomerAddress { get; set; }
        [Column("createdby")]
        public int CreatedBy { get; set; }
        [Column("createdat")]
        public DateTime? CreatedAt { get; set; }
        [Column("modifiedby")]
        public int? ModifiedBy { get; set; }
        [Column("modifiedat")]
        public DateTime? ModifiedAt { get; set; }

    }
}
