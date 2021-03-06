﻿using System.ComponentModel.DataAnnotations;

namespace Store.Web.Mvc.Client.Areas.Auth.ViewModels
{
    public class SignupModel
    {
        [Display(Name = "First Name")]
        [Required(ErrorMessage = "First name is required")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Last name is required")]
        public string LastName { get; set; }

        [Display(Name = "Patronymic")]
        public string Patronymic { get; set; }

        [Display(Name = "Address")]
        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; }

        [Display(Name = "City")]
        [Required(ErrorMessage = "City is required")]
        public string City { get; set; }

        [Display(Name = "Region")]
        public string Region { get; set; }

        [Display(Name = "Country")]
        [Required(ErrorMessage = "Country is required")]
        public string Country { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email")]
        public string Email { get; set; }

        [Display(Name = "Phone number")]
        [Required(ErrorMessage = "Phone number is required")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "Invalid phone number")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [StringLength(50, MinimumLength = 7, ErrorMessage = "Min password length is 7 characters")]
        public string Password { get; set; }
    }
}