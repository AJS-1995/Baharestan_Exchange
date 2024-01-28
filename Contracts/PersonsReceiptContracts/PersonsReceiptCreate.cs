using _0_Framework.Application;
using Contracts.AgenciesContracts;
using Contracts.MoneyContracts;
using Contracts.PersonsContracts;
using Contracts.SafeBoxContracts;
using System.ComponentModel.DataAnnotations;

namespace Contracts.PersonsReceiptContracts
{
    public class PersonsReceiptCreate
    {
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string? Date { get; set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string? Description { get; set; }
        public string? By { get; set; }
        public string? ReceiptNumber { get; set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public bool Type { get; set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public decimal Amount { get; set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public int SafeBoxId { get; set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public int MoneyId { get; set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public int PersonId { get; set; }
        public string? PersonName { get; set; }
        public List<PersonsViewModel>? Persons { get; set; }
        public List<SafeBoxViewModel>? SafeBoxs { get; set; }
        public List<MoneyViewModel>? Moneys { get; set; }
        public int AgenciesId { get; set; }
        public int IdAgencies { get; set; }
        public List<AgenciesViewModel>? Agencies { get; set; }
    }
}