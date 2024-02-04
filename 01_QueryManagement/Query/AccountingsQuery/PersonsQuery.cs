using _01_QueryManagement.Contracts.AccountingsContracts.PersonsModels;
using Domin.ManagementPresonsDomin.PersonsDomin;
using Domin.ManagementPresonsDomin.PersonsReceiptDomin;
using Domin.MoneyDomin;

namespace _01_QueryManagement.Query.AccountingsQuery
{
    public class PersonsQuery : IPersonsModels
    {
        private readonly IPersonsRepository _personsRepository;
        private readonly IMoneyRepository _moneyRepository;
        private readonly IPersonsReceiptRepository _personsReceiptRepository;
        public PersonsQuery(IMoneyRepository moneyRepository, IPersonsReceiptRepository personsReceiptRepository, IPersonsRepository personsRepository)
        {
            _moneyRepository = moneyRepository;
            _personsReceiptRepository = personsReceiptRepository;
            _personsRepository = personsRepository;
        }
        public List<PersonsModels> PersonsModelss()
        {
            var PersonsModels = new List<PersonsModels>();
            var persons = _personsRepository.GetViewModel();
            foreach (var person in persons)
            {
                var moneies = _moneyRepository.GetViewModel();
                foreach (var money in moneies)
                {
                    var pr = _personsReceiptRepository.GetViewModel().Where(x => x.PersonId == person.Id && x.MoneyId == money.Id).ToList();
                    if (pr.Count != 0)
                    {
                        decimal receipt = pr.Where(x => x.Type == true).Sum(x => x.Amount);
                        decimal slavary = pr.Where(x => x.Type == false).Sum(x => x.Amount);
                        decimal rest = receipt - slavary;
                        PersonsModels.Add(new PersonsModels()
                        {
                            PersonsId = person.Id,
                            PersonsName = person.Name,
                            MoneyId = money.Id,
                            MoneyName = money.Name,
                            MoneySymbol = money.Symbol,
                            Receipts = receipt,
                            Rest = rest,
                            Slavery = slavary,
                        });
                    }
                }
            }
            return PersonsModels.ToList();
        }
    }
}