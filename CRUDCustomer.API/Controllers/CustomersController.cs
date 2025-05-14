using CRUDCustomer.BLL.Interfaces;
using CRUDCustomer.Models.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Linq;

namespace CRUDCustomer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public async Task<ResponseGetMethodDto> GetAllCustomer()
        {
            var result = await _customerService.GetAllCustomersAsync();
            
            Response.StatusCode = StatusCodes.Status200OK;

            return new ResponseGetMethodDto()
            {
                Message = "Success retrieve all customers",
                Data = result,

            };

        }

        [HttpGet("{id}")]
        public async Task<ResponseGetMethodDto> GetCustomerById(int id)
        {
            try
            {
                var result = await _customerService.GetCustomerByIdAsync(id);

                Response.StatusCode = StatusCodes.Status200OK;

                return new ResponseGetMethodDto()
                {
                    Message = $"Success retrieve customer id {id}",
                    Data = result

                };

            } catch (Exception ex)
            {
                Response.StatusCode = StatusCodes.Status400BadRequest;
                return new ResponseGetMethodDto()
                {
                    Message = ex.Message,
                };
            }

        }

        [HttpPost]
        public async Task<ResponseDto> AddCustomer(CustomerCreateResuestDto customerDto)
        {
            if (!ModelState.IsValid)
            {
                var errorMessages = ModelState.Values.SelectMany(x => x.Errors).Select(e => e.ErrorMessage).ToList();

                Response.StatusCode = StatusCodes.Status400BadRequest;

                return new ResponseDto()
                {
                    Message = $"validation Error : {string.Join("\n", errorMessages)}",
                };
                
            }

            try
            {
                await _customerService.AddCustomerAsync(customerDto);
                
                Response.StatusCode = StatusCodes.Status201Created;

                return new ResponseDto()
                {
                    Message = "Success created data",
                };
                
           

            } catch (Exception ex)
            {

                Response.StatusCode = StatusCodes.Status400BadRequest;
                return new ResponseDto()
                {
                    Message = ex.Message,
                };
               
            }

        }

        [HttpDelete("{id}")]
        public async Task<ResponseDto> DeleteCustomer(int id)
        {
            try
            {
                await _customerService.DeleteCustomerAsync(id);

                Response.StatusCode = StatusCodes.Status200OK;

                return new ResponseDto()
                {
                    Message = $"Delete customer id {id} Successfuly"
                };

            }
            catch (Exception ex)
            {
                Response.StatusCode = StatusCodes.Status400BadRequest;
                return new ResponseDto()
                {
                    Message = ex.Message,
                };

            }
        }

        [HttpPut("{id}")]
        public async Task<ResponseDto> UpdateCustomer(int id, CustomerUpdateResuestDto customerDto)
        {
            if (!ModelState.IsValid)
            {
                var errorMessages = ModelState.Values.SelectMany(x => x.Errors).Select(e => e.ErrorMessage).ToList();

                Response.StatusCode = StatusCodes.Status400BadRequest;

                return new ResponseDto()
                {
                    Message = $"validation Error : {string.Join("\n", errorMessages)}",
                };

            }
            try
            {
                await _customerService.UpdateCustomerAsync(id,customerDto);

                Response.StatusCode = StatusCodes.Status200OK;

                return new ResponseDto()
                {
                    Message = $"Success updated customer id {id}",
                };
                
            }
            catch (Exception ex)
            {
                Response.StatusCode = StatusCodes.Status400BadRequest;
                return new ResponseDto()
                {
                    Message = ex.Message,
                };
            }
        }
    }
}
