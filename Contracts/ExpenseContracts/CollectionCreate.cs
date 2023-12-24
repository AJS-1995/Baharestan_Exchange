﻿using _0_Framework.Application;
using System.ComponentModel.DataAnnotations;

namespace Contracts.ExpenseContracts
{
    public class CollectionCreate
    {
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
}