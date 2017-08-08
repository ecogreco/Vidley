using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidley.Dtos;
using Vidley.Models;

namespace Vidley.Controllers.Api
{
    public class CustomersController : ApiController //when you use API you must included GlobalConfiguration.Configure(WebApiConfig.Register) and later on Mapper.Initialize(c => c.AddProfile<MapingProfile>()) in the global.asax.cs 
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        //GET/API/Customers 
        public IHttpActionResult GetCustomers(string query = null) //returns list of customers
        {
            var customersQuery = _context.Customers
                .Include(c => c.MembershipType);

            if(!String.IsNullOrWhiteSpace(query))
            {
                customersQuery = customersQuery.Where(c => c.Name.Contains(query));
            }

            var customersDto = customersQuery
                .ToList()
                .Select(Mapper.Map<Customer, CustomerDto>);

            return Ok(customersDto);
            
            
        }

        //GET /api/customers/1
        public IHttpActionResult GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id); // in case the customer is null
            if (customer == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<Customer, CustomerDto>(customer)) ; //this returns a okay method with the DTO by using the mapper.map method, the Customer is the source and the (customer) is the source object, and it is being mapped to a CustomerDto
        }

        //POST /api / customers
        [HttpPost] // attribute that indicates a resource is being created 
        public IHttpActionResult CreateCustomer(CustomerDto customerDto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }

            var customer = Mapper.Map<CustomerDto, Customer>(customerDto); //this creates a customer object and then passed into the actual database
            _context.Customers.Add(customer);
            _context.SaveChanges();
            customerDto.Id = customer.Id; // when a new customer is created in the database it is nessescary to create an ID for the DTO object 

            return Created(new Uri(Request.RequestUri+"/"+customer.Id),customerDto);
        }

        //PUT /customer /1
        [HttpPut] //attribute that indicates that a resources is being changed 
        public void UpdateCustomer(int id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var customerInDB = _context.Customers.SingleOrDefault(c => c.Id == id);

            if(customerInDB == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            Mapper.Map(customerDto, customerInDB); //in this care of the normal () parameters, the first object is the source object, and the second object is the target object, there are no <> generics because of this
            _context.SaveChanges();

        }

        //DELETE /Customer/api /1
        [HttpDelete] //attribute that indicates that a resources is being removed 
        public void DeleteCustomer(int id)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var customerInDB = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDB == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            _context.Customers.Remove(customerInDB);
            _context.SaveChanges();
        }

    }
}
