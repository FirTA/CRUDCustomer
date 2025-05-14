using CRUDCustomer.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDCustomer.Models.DTOs
{
    public class ResponseDto
    {
        public string Message { get; set; }
        public Guid TransactionId { get; set; } = Guid.NewGuid();
    }

    public class ResponseGetMethodDto : ResponseDto
    {
        public object Data { get; set; }
    }
}
