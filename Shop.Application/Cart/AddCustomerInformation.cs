using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Shop.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Shop.Application.Cart
{
    public class AddCustomerInformation
    {
        private ISession _session;

        public AddCustomerInformation(ISession session)
        {
            _session = session;
        }

        public class Request
        {

            [Required(ErrorMessage = "{0} is required")]
            [StringLength(100, MinimumLength = 3,
                ErrorMessage = "FirstName Should be minimum 3 characters and a maximum of 100 characters")]
            [RegularExpression("^((?!^First Name$)[a-zA-Z '])+$", 
                ErrorMessage = "First name is required and must be properly formatted.")]
            [DataType(DataType.Text)]
            public string FirstName { get; set; }
            [Required(ErrorMessage = "{0} is required")]
            [StringLength(100, MinimumLength = 3,
            ErrorMessage = "LastName Should be minimum 3 characters and a maximum of 100 characters")]
            [RegularExpression("^((?!^Last Name$)[a-zA-Z '])+$",
                ErrorMessage = "Last name is required and must be properly formatted.")]
            [DataType(DataType.Text)]

            public string LastName { get; set; }
            [Required(ErrorMessage = "{0} is required")]
            [DataType(DataType.EmailAddress)]
            public string Email { get; set; }
            [Required(ErrorMessage = "{0} is required")]
            [DataType(DataType.PhoneNumber)]
            public string PhoneNumber { get; set; }
            [Required(ErrorMessage = "Address is required")]
            [RegularExpression("^((?!^Address$)[0-9A-Za-z #.,])+$", 
                ErrorMessage = "Address is required and must be properly formatted.")]
            public string Address1 { get; set; }
            [RegularExpression("^((?!^Address$)[0-9A-Za-z #.,])+$", 
                ErrorMessage = "Address is required and must be properly formatted.")]

            public string Address2 { get; set; }
            [Required(ErrorMessage = "City is a Required field.")]
            [DataType(DataType.Text)]
            [RegularExpression("^((?!^City$)[a-zA-Z '])+$", ErrorMessage = "City is required and must be properly formatted.")]
           
            public string City { get; set; }
            [Required(ErrorMessage = "The {0} is required")]
            public string PostCode { get; set; }

        }

        public void Do(Request request)
        {
            var customerInformation = new CustomerInformation
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                Address1 = request.Address1,
                Address2 = request.Address2,
                City = request.City,
                PostCode = request.PostCode
            };
           var stringObject = JsonConvert.SerializeObject(customerInformation);


            _session.SetString("customer-info", stringObject);
        }
    }
}
