using _0_Framework.Application;
using System.ComponentModel.DataAnnotations;

namespace Contracts.MoneyContracts
{
    public class MoneyCreate
    {
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string? Name { get; set; }
        public string? Country { get; set; }
        public string? Symbol { get; set; }
    }
}