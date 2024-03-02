using _0_Framework.Application;
using _01_QueryManagement.Contracts.AccountingsContracts.PersonsModels;
using Contracts.ManagementPresonsContracts.LivelihoodMonthContracts;
using Domin.ManagementPresonsDomin.LivelihoodDomin;
using Domin.ManagementPresonsDomin.LivelihoodMonthDomin;
using Domin.ManagementPresonsDomin.PersonsDomin;
using Domin.ManagementPresonsDomin.PersonsMoneyExchangeDomin;
using Domin.ManagementPresonsDomin.PersonsReceiptDomin;
using Domin.MoneyDomin;
using System.Globalization;

namespace _01_QueryManagement.Query.AccountingsQuery
{
    public class PersonsQuery : IPersonsModels
    {
        private readonly IPersonsRepository _personsRepository;
        private readonly IMoneyRepository _moneyRepository;
        private readonly IPersonsReceiptRepository _personsReceiptRepository;
        private readonly IPersonsMoneyExchangeRepository _personsMoneyExchangeRepository;
        private readonly ILivelihoodMonthRepository _livelihoodMonthRepository;
        private readonly ILivelihoodMonthApplication _livelihoodMonthApplication;
        private readonly ILivelihoodRepository _livelihoodRepository;
        public PersonsQuery(IMoneyRepository moneyRepository, IPersonsReceiptRepository personsReceiptRepository, IPersonsRepository personsRepository, IPersonsMoneyExchangeRepository personsMoneyExchangeRepository, ILivelihoodMonthRepository livelihoodMonthRepository, ILivelihoodMonthApplication livelihoodMonthApplication, ILivelihoodRepository livelihoodRepository)
        {
            _moneyRepository = moneyRepository;
            _personsReceiptRepository = personsReceiptRepository;
            _personsRepository = personsRepository;
            _personsMoneyExchangeRepository = personsMoneyExchangeRepository;
            _livelihoodMonthRepository = livelihoodMonthRepository;
            _livelihoodMonthApplication = livelihoodMonthApplication;
            _livelihoodRepository = livelihoodRepository;
        }

        public OperationResult LivelihoodMonthModelss()
        {
            var operation = new OperationResult();
            var livelihoods = _livelihoodRepository.GetViewModel().Where(x => x.Cancel == false).ToList();
            foreach (var livelihood in livelihoods)
            {
                var years = Convert.ToInt32(livelihood.SDate.Substring(0, 4));
                var months = Convert.ToInt32(livelihood.SDate.Substring(5, 2));
                var yeare = Convert.ToInt32(livelihood.EDate.Substring(0, 4));
                var monthe = Convert.ToInt32(livelihood.EDate.Substring(5, 2));
                var daye = Convert.ToInt32(livelihood.EDate.Substring(8, 2));

                var dates = DateTime.Now.ToFarsi();
                var date = dates.FromFarsiDate();
                var dyears = Convert.ToInt32(dates.Substring(0, 4));
                var dmonths = Convert.ToInt32(dates.Substring(5, 2));
                var day = Convert.ToInt32(dates.Substring(8, 2));
                for (int year = years; year <= yeare; year++)
                {
                    if (year == dyears)
                    {
                        for (int month = months; month <= monthe; month++)
                        {
                            var LivelihoodMonth = _livelihoodMonthRepository.GetViewModel().Where(x => x.LivelihoodId == livelihood.Id && x.Year == year && x.Month == month && x.AgenciesId == livelihood.AgenciesId);
                            if (LivelihoodMonth.Count() == 0)
                            {
                                if (month < dmonths)
                                {
                                    if (month == monthe)
                                    {
                                        var amount = livelihood.Amount;
                                        var to = amount / 30;
                                        var total = daye * to;
                                        var command = new LivelihoodMonthCreate()
                                        {
                                            AgenciesId = livelihood.AgenciesId,
                                            LivelihoodId = livelihood.Id,
                                            Month = month,
                                            Year = year,
                                            PersonsId = livelihood.PersonsId,
                                            Amount = total,
                                            MoneyId = livelihood.MoneyId,
                                        };
                                        _livelihoodMonthApplication.Create(command);
                                    }
                                    else
                                    {
                                        var command = new LivelihoodMonthCreate()
                                        {
                                            AgenciesId = livelihood.AgenciesId,
                                            LivelihoodId = livelihood.Id,
                                            Month = month,
                                            Year = year,
                                            PersonsId = livelihood.PersonsId,
                                            Amount = livelihood.Amount,
                                            MoneyId = livelihood.MoneyId,
                                        };
                                        _livelihoodMonthApplication.Create(command);
                                    }
                                }
                                else if (month == dmonths)
                                {
                                    if (day >= 30)
                                    {
                                        var command = new LivelihoodMonthCreate()
                                        {
                                            AgenciesId = livelihood.AgenciesId,
                                            LivelihoodId = livelihood.Id,
                                            Month = month,
                                            Year = year,
                                            PersonsId = livelihood.PersonsId,
                                            Amount = livelihood.Amount,
                                            MoneyId = livelihood.MoneyId,
                                        };
                                        _livelihoodMonthApplication.Create(command);
                                    }
                                    else if (day <= 29)
                                    {
                                        var amount = livelihood.Amount;
                                        var to = amount / 30;
                                        var total = day * to;
                                        var command = new LivelihoodMonthCreate()
                                        {
                                            AgenciesId = livelihood.AgenciesId,
                                            LivelihoodId = livelihood.Id,
                                            Month = month,
                                            Year = year,
                                            PersonsId = livelihood.PersonsId,
                                            Amount = total,
                                            MoneyId = livelihood.MoneyId,
                                        };
                                        _livelihoodMonthApplication.Create(command);
                                    }
                                }
                            }
                        }
                    }else if (year < dyears)
                    {
                        for (int month = months; month <= 12; month++)
                        {
                            var LivelihoodMonth = _livelihoodMonthRepository.GetViewModel().Where(x => x.LivelihoodId == livelihood.Id && x.Year == year && x.Month == month && x.AgenciesId == livelihood.AgenciesId);
                            if (LivelihoodMonth.Count() == 0)
                            {
                                var command = new LivelihoodMonthCreate()
                                {
                                    AgenciesId = livelihood.AgenciesId,
                                    LivelihoodId = livelihood.Id,
                                    Month = month,
                                    Year = year,
                                    PersonsId = livelihood.PersonsId,
                                    Amount = livelihood.Amount,
                                    MoneyId = livelihood.MoneyId,
                                };
                                _livelihoodMonthApplication.Create(command);
                            }
                        }
                        months = 1;
                    }
                }
            }
            return operation.Succedded();
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
                    var pr = _personsReceiptRepository.GetViewModel().Where(x => x.PersonsId == person.Id && x.MoneyId == money.Id).ToList();
                    var smoneyperson = _personsMoneyExchangeRepository.GetViewModel().Where(x => x.PersonsId == person.Id && x.MoneyId_One == money.Id).ToList();
                    var rmoneyperson = _personsMoneyExchangeRepository.GetViewModel().Where(x => x.PersonsId == person.Id && x.MoneyId_Two == money.Id).ToList();
                    var livelihoodmonth = _livelihoodMonthRepository.GetViewModel().Where(x => x.PersonsId == person.Id && x.MoneyId == money.Id).ToList();
                    if (pr.Count != 0 || smoneyperson.Count != 0 || rmoneyperson.Count !=0 || livelihoodmonth.Count !=0)
                    {
                        decimal receiptp = pr.Where(x => x.Type == true).Sum(x => x.Amount);
                        decimal receiptm = rmoneyperson.Sum(x => x.Amount_Two);
                        decimal receiptl = livelihoodmonth.Sum(x => x.Amount);
                        decimal receipt = receiptp + receiptm + receiptl;
                        decimal slavaryp = pr.Where(x => x.Type == false).Sum(x => x.Amount);
                        decimal slavarym = smoneyperson.Sum(x => x.Amount_One);
                        decimal slavary = slavaryp + slavarym;
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