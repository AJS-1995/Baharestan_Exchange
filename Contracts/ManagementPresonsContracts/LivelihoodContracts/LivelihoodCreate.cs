using _0_Framework.Application;
using Contracts.AgenciesContracts;
using Contracts.ManagementPresonsContracts.PersonsContracts;
using Contracts.MoneyContracts;
using System.ComponentModel.DataAnnotations;

namespace Contracts.ManagementPresonsContracts.LivelihoodContracts
{
    public class LivelihoodCreate
    {
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string? SDate { get; set; }
        public string? EDate { get; set; }
        public int PersonsId { get; set; }
        public decimal Amount { get; set; }
        public bool Cancel { get; set; }
        public int MoneyId { get; set; }
        public int AgenciesId { get; set; }
        public int IdAgencies { get; set; }
        public List<AgenciesViewModel>? Agencies { get; set; }
        public List<PersonsViewModel>? Persons { get; set; }
        public List<MoneyViewModel>? Money { get; set; }
        public string? PersonName { get; set; }
    }
}