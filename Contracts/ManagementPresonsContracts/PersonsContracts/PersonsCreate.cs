using _0_Framework.Application;
using Contracts.AgenciesContracts;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Contracts.ManagementPresonsContracts.PersonsContracts
{
    public class PersonsCreate
    {
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string? Name { get; set; }
        public string? Mobile { get; set; }
        public string? Address { get; set; }
        public string? Company { get; set; }
        public string? Guarantor { get; set; }
        public bool Personnel { get; set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string? UserName { get; set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string? Password { get; set; }
        public IFormFile? ProfilePhoto { get; set; }
        public int AgenciesId { get; set; }
        public int IdAgencies { get; set; }
        public List<AgenciesViewModel>? Agencies { get; set; }
    }
}