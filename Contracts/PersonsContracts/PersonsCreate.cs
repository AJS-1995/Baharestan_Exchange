﻿using _0_Framework.Application;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Contracts.PersonsContracts
{
    public class PersonsCreate
    {
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string? Name { get; set; }
        public string? Mobile { get; set; }
        public string? Address { get; set; }
        public string? Company { get; set; }
        public string? Guarantor { get; set; }
        public IFormFile? GuarantorPhoto { get; set; }
    }
}