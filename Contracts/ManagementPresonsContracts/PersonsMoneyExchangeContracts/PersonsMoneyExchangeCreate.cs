using _0_Framework.Application;
using Contracts.AgenciesContracts;
using Contracts.ManagementPresonsContracts.PersonsContracts;
using Contracts.MoneyContracts;
using System.ComponentModel.DataAnnotations;

namespace Contracts.ManagementPresonsContracts.PersonsMoneyExchangeContracts
{
    public class PersonsMoneyExchangeCreate
    {
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string? Date { get; set; }
        public int MoneyId_One { get; set; }
        public decimal Amount_One { get; set; }
        public decimal Price { get; set; }
        public bool Type { get; set; }
        public int MoneyId_Two { get; set; }
        public decimal Amount_Two { get; set; }
        public int PersonId { get; set; }
        public int AgenciesId { get; set; }
        public int IdAgencies { get; set; }
        public List<MoneyViewModel>? Moneys { get; set; }
        public List<PersonsViewModel>? Personss { get; set; }
        public List<AgenciesViewModel>? Agencies { get; set; }
    }
}