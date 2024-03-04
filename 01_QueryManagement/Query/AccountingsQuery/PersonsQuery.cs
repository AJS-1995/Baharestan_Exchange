using _0_Framework.Application;
using _01_QueryManagement.Contracts.AccountingsContracts.PersonsModels;
using Contracts.ManagementPresonsContracts.LivelihoodMonthContracts;
using Domin.AgenciesDomin;
using Domin.ManagementPresonsDomin.LivelihoodDomin;
using Domin.ManagementPresonsDomin.LivelihoodMonthDomin;
using Domin.ManagementPresonsDomin.PersonsDomin;
using Domin.ManagementPresonsDomin.PersonsMoneyExchangeDomin;
using Domin.ManagementPresonsDomin.PersonsReceiptDomin;
using Domin.MoneyDomin;
using System;
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
        private readonly IAgenciesRepository _agenciesRepository;
        public PersonsQuery(IMoneyRepository moneyRepository, IPersonsReceiptRepository personsReceiptRepository, IPersonsRepository personsRepository, IPersonsMoneyExchangeRepository personsMoneyExchangeRepository, ILivelihoodMonthRepository livelihoodMonthRepository, ILivelihoodMonthApplication livelihoodMonthApplication, ILivelihoodRepository livelihoodRepository, IAgenciesRepository agenciesRepository)
        {
            _moneyRepository = moneyRepository;
            _personsReceiptRepository = personsReceiptRepository;
            _personsRepository = personsRepository;
            _personsMoneyExchangeRepository = personsMoneyExchangeRepository;
            _livelihoodMonthRepository = livelihoodMonthRepository;
            _livelihoodMonthApplication = livelihoodMonthApplication;
            _livelihoodRepository = livelihoodRepository;
            _agenciesRepository = agenciesRepository;
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

                if (years <= dyears)
                {
                    if (yeare < dyears)
                    {
                        int m = months;
                        for (int year = years; year <= yeare; year++)
                        {
                            if (year == yeare)
                            {
                                for (int month = m; month <= monthe; month++)
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
                            }
                            else
                            {
                                for (int month = m; month <= 12; month++)
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
                                m = 1;
                            }
                        }
                    }
                    else if (yeare > dyears)
                    {
                        int m = months;
                        for (int year = years; year <= dyears; year++)
                        {
                            if (year == dyears)
                            {
                                for (int month = m; month <= dmonths; month++)
                                {
                                    if (month == dmonths)
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
                            }
                            else
                            {
                                for (int month = m; month <= 12; month++)
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
                                m = 1;
                            }
                        }
                    }
                    else if (yeare == dyears)
                    {
                        for (int year = years; year <= yeare; year++)
                        {
                            if (monthe < dmonths)
                            {
                                for (int month = months; month <= monthe; month++)
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
                            }
                            else if (monthe >= dmonths)
                            {
                                for (int month = months; month <= dmonths; month++)
                                {
                                    if (month == dmonths)
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
                            }
                        }
                    }
                }
            }
            return operation.Succedded();
        }
        public List<PersonsModels>? PersonsAccountingModelss(int agenciesId)
        {
            var PersonsModels = new List<PersonsModels>();
            var moneies = _moneyRepository.GetViewModel();
            var agencies = _agenciesRepository.GetDetails(agenciesId);
            foreach (var money in moneies)
            {
                var pr = _personsReceiptRepository.GetViewModel().Where(x => x.AgenciesId == agenciesId && x.MoneyId == money.Id).ToList();
                var smoneyperson = _personsMoneyExchangeRepository.GetViewModel().Where(x => x.AgenciesId == agenciesId && x.MoneyId_One == money.Id).ToList();
                var rmoneyperson = _personsMoneyExchangeRepository.GetViewModel().Where(x => x.AgenciesId == agenciesId && x.MoneyId_Two == money.Id).ToList();
                var livelihoodmonth = _livelihoodMonthRepository.GetViewModel().Where(x => x.AgenciesId == agenciesId && x.MoneyId == money.Id).ToList();
                if (pr.Count != 0 || smoneyperson.Count != 0 || rmoneyperson.Count != 0 || livelihoodmonth.Count != 0)
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
                        MoneyId = money.Id,
                        MoneyName = money.Name,
                        MoneySymbol = money.Symbol,
                        Rest = rest,
                        PersonsId = agenciesId,
                        PersonsName = agencies.Name
                    });
                }
            }
            return PersonsModels.ToList();
        }
        public List<PersonsModels>? PersonsAccountingModelss()
        {
            var PersonsModels = new List<PersonsModels>();
            var moneies = _moneyRepository.GetViewModel();
            foreach (var money in moneies)
            {
                var pr = _personsReceiptRepository.GetViewModel().Where(x => x.MoneyId == money.Id).ToList();
                var smoneyperson = _personsMoneyExchangeRepository.GetViewModel().Where(x => x.MoneyId_One == money.Id).ToList();
                var rmoneyperson = _personsMoneyExchangeRepository.GetViewModel().Where(x => x.MoneyId_Two == money.Id).ToList();
                var livelihoodmonth = _livelihoodMonthRepository.GetViewModel().Where(x => x.MoneyId == money.Id).ToList();
                if (pr.Count != 0 || smoneyperson.Count != 0 || rmoneyperson.Count != 0 || livelihoodmonth.Count != 0)
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
                        MoneyId = money.Id,
                        MoneyName = money.Name,
                        MoneySymbol = money.Symbol,
                        Rest = rest,
                    });
                }
            }
            return PersonsModels.ToList();
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
                    if (pr.Count != 0 || smoneyperson.Count != 0 || rmoneyperson.Count != 0 || livelihoodmonth.Count != 0)
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