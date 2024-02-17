using _01_QueryManagement.Contracts.AccountingsContracts.PersonsModels;
using Domin.ManagementPresonsDomin.PersonsDomin;
using Domin.ManagementPresonsDomin.PersonsMoneyExchangeDomin;
using Domin.ManagementPresonsDomin.PersonsReceiptDomin;
using Domin.MoneyDomin;

namespace _01_QueryManagement.Query.AccountingsQuery
{
    public class PersonsQuery : IPersonsModels
    {
        private readonly IPersonsRepository _personsRepository;
        private readonly IMoneyRepository _moneyRepository;
        private readonly IPersonsReceiptRepository _personsReceiptRepository;
        private readonly IPersonsMoneyExchangeRepository _personsMoneyExchangeRepository;
        public PersonsQuery(IMoneyRepository moneyRepository, IPersonsReceiptRepository personsReceiptRepository, IPersonsRepository personsRepository, IPersonsMoneyExchangeRepository personsMoneyExchangeRepository)
        {
            _moneyRepository = moneyRepository;
            _personsReceiptRepository = personsReceiptRepository;
            _personsRepository = personsRepository;
            _personsMoneyExchangeRepository = personsMoneyExchangeRepository;
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
                    var smoneyperson = _personsMoneyExchangeRepository.GetViewModel().Where(x => x.PersonId == person.Id && x.MoneyId_One == money.Id).ToList();
                    var rmoneyperson = _personsMoneyExchangeRepository.GetViewModel().Where(x => x.PersonId == person.Id && x.MoneyId_Two == money.Id).ToList();
                    if (pr.Count != 0)
                    {
                        decimal receiptp = pr.Where(x => x.Type == true).Sum(x => x.Amount);
                        decimal receiptm = rmoneyperson.Sum(x=> x.Amount_Two);
                        decimal receipt = receiptp + receiptm;
                        decimal slavaryp = pr.Where(x => x.Type == false).Sum(x => x.Amount);
                        decimal slavarym = smoneyperson.Sum(x => x.Amount_One);
                        decimal slavary = slavaryp + slavarym;
                        decimal rest = receipt - slavary;
                        PersonsModels.Add(new PersonsModels()
                        {
                            PersonId = person.Id,
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