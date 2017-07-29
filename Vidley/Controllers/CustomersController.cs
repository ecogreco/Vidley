using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidley.Models;
using Vidley.ViewModels;
using System.Data.Entity;

namespace Vidley.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers
        private ApplicationDbContext _context; // the _context variable is the object that calls the database 

        public CustomersController() //constructor class for the CustomerController and assigns the _context ApplicationDbContext
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing) //nessescary method for the database object
        {
            _context.Dispose();
        }

        public ActionResult New() //creates new customer
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new CustomerFormViewModel //the CustomerFormViewModel is suppose to be an object that includes a single customer but a list of membership types 
            {
                MembershipTypes = membershipTypes //the customer is null(being a new customer), and the MembershipTypes is the list object that was declared as membershipTypes
            };
            return View("CustomerForm",viewModel); //the first paramenter is the name of the view, while the second is the object being passed in 
        }

        public ActionResult Edit(int id) //edits customer
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if(customer == null)
            {
                return HttpNotFound();
            }

            var viewModel = new CustomerFormViewModel() //the CustomerFormViewModel is suppose to be an object that includes a single customer but a list of membership types 
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };

            return View("CustomerForm", viewModel); //the first paramenter is the name of the view, while the second is the object being passed in 
        }

        [HttpPost] //nessescary property for an action
        public ActionResult Save(Customer customer) //saves information in database, either updates customer orr creates new customer
        {
            if(customer == null) //if it is not a pre-existing customer a new customer is created
            {
                _context.Customers.Add(customer);
            }
            else //if the customer is pre-existing the information is updated 
            {
                var customerInDB = _context.Customers.Single(c => c.Id == customer.Id);
                customerInDB.Name = customer.Name;
                customerInDB.Birthday = customer.Birthday;
                customerInDB.MembershipTypeId = customer.MembershipTypeId;
                customerInDB.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
            }
            
            _context.SaveChanges();
            return RedirectToAction("Index", "Customers"); //redirects the user to the index page
        }

        public ActionResult Index() //list of customers
        {
            var customers = _context.Customers.Include(c => c.MembershipType).ToList(); //passes in the list of customers and the Include function includes MembershipType 


            return View(customers); //if there is one parameter then the default view is the name on the control method, and the only parameter would be the object being passed in 
        }

        public ActionResult Details(int id) //returns the details of a customer, the parameters of this method is suppose to match the Id of the customer
        {
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id); //the SingleOrDefault determines the id that was passed in the parameters
            if(customer == null)
            {
                return HttpNotFound();
            }

            return View(customer);//if there is one parameter then the default view is the name on the control method, and the only parameter would be the object being passed in 
        }

        //irrelevant code 
        //public List<Customer> getCustomers()
        //{
        //    return new List<Customer>
        //    {
        //        new Customer{Id = 1, Name = "John Smith"},
        //        new Customer{Id = 2, Name = "Mary Williams"}
        //    };
        //}


    }

}