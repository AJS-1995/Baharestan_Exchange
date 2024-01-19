using _0_Framework.Application;
using Contracts.AgenciesContracts;
using System.ComponentModel.DataAnnotations;

namespace Contracts.SafeBoxContracts
{
    public class SafeBoxCreate
    {
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string? Name { get; set; }
        public string? Treasurer { get; set; }
        public string? Mobile { get; set; }
        public int AgenciesId { get; set; }
        public int IdAgencies { get; set; }
        public List<AgenciesViewModel>? Agencies { get; set; }
    }
}