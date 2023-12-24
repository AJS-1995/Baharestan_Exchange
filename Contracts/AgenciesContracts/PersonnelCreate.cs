using _0_Framework.Application;
using System.ComponentModel.DataAnnotations;

namespace Contracts.AgenciesContracts
{
    public class AgenciesCreate
    {
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? Mobile { get; set; }
        public string? Responsible { get; set; }
        public int CompanyId { get; set; }
    }
}