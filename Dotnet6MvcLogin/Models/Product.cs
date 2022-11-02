using Dotnet6MvcLogin.Data;
using Dotnet6MvcLogin.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace Dotnet6MvcLogin.Models
{
    public class Product : IEntityBase
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Product Name")]
        [Required(ErrorMessage = "Product Name is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Full Name must be between 3 and 50 chars")]
        public string? ProductName { get; set; }
        public ProductCategory productCategory { get; set; }
        public string ImageURL { get; set; }
        public ProductStaus productStaus { get; set; }
        [Required(ErrorMessage = "First Name is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Full Name must be between 3 and 50 chars")]
        public string? FirstName { get; set; }
        [Required(ErrorMessage = "Last Name is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Last Name must be between 3 and 50 chars")]
        public string? LastName { get; set; }
        [Required(ErrorMessage = "Company Name is required")]
        [StringLength(maximumLength: 50, MinimumLength = 3, ErrorMessage = "Company Name must be between 3 and 150 chars")]
        public string? CompanyName { get; set; }

        [Required(ErrorMessage = "Phone is required")]
        [StringLength(14, ErrorMessage = "Phone  must be between 10 and 14 chars")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Address is required")]
        [StringLength(maximumLength: 200,MinimumLength =2, ErrorMessage = "Address  must greater than two character")]
        public string? Address { get; set; }
        public string? Country { get; set; }
        public string? State { get; set; }
        public string? City { get; set; }

        [Required(ErrorMessage = "Email is required")]
        public string? Email { get; set; }
        public string? PostalCode { get; set; }

        public ProductDimention productDimention{ get; set; }

        [Required(ErrorMessage = "Quantity is required")]
        [MinLength(1)]

        public float Quantity { get; set; }
        public float? Weight { get; set; }


        [Required(ErrorMessage = "Start Date is required")]
        [Display(Name = "Start Date")]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]

        public DateTime StartDate { get; set; }
        [Required(ErrorMessage = "End Date is required")]

        [Display(Name = "End Date")]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime EndDate { get; set; }
        [Required(ErrorMessage = "Starting Price is required")]

        public float StartingPrice { get; set; }


        [Display(Name = "Product Detail")]
        [StringLength(maximumLength: 1000, MinimumLength = 0, ErrorMessage = "invalid detail")]

        public string? ProductDetail { get; set; }

        //Relationships
    }
}
