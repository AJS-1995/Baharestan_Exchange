using _0_Framework.Application;
using Contracts.AgenciesContracts;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Contracts.PersonnelContracts
{
    public class PersonnelCreate
    {
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string? FullName { get; set; }
        public string? Fathers_Name { get; set; }
        public string? Mobile { get; set; }
        public string? Address { get; set; }
        public string? Cart_Id { get; set; }
        public IFormFile? Photo { get; set; }
        public int AgenciesId { get; set; }
        public int IdAgencies { get; set; }
        public List<AgenciesViewModel>? Agencies { get; set; }
    }
}
