using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDCustomer.Models.DTOs
{
    public class CustomerRequestDto
    {
        [StringLength(50, ErrorMessage = "Customer Code max length is 50")]
        [Required(ErrorMessage = "Customer Code is required.")]
        public string CustomerCode { get; set; }
        [StringLength(255, ErrorMessage = "Customer Name max length is 255")]
        [Required(ErrorMessage = "Customer Name is required.")]
        public string CustomerName { get; set; }

        [StringLength(1000, ErrorMessage = "Customer Address max length is 1000")]
        [Required(ErrorMessage = "Customer Address is required.")] 
        public string CustomerAddress { get; set; }
    }

    public class CustomerCreateResuestDto : CustomerRequestDto
    {
        [Required(ErrorMessage = "Request By is requred")]
        public int RequestBy { get; set; }
    }

    public class CustomerUpdateResuestDto : CustomerRequestDto
    {
        public int RequestBy { get; set; }
    }
}
