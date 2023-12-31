﻿using _0_Framework.Domain;
using Domin.ExchangeRateDomin;

namespace Domin.MoneyDomin
{
    public class Money : EntityBase<int>
    {
        public string? Name { get; set; }
        public string? Country { get; set; }
        public string? Symbol { get; set; }
        public Money() { }
        public Money(string? name, string? country, string? symbol, int userid, int agenciesId)
        {
            Name = name;
            Country = country;
            Symbol = symbol;
            UserId = userid;
            AgenciesId = agenciesId;
        }
        public void Edit(string? name, string? country, string? symbol, int userid, int agenciesId)
        {
            Name = name;
            Country = country;
            Symbol = symbol;
            UserId = userid;
            AgenciesId = agenciesId;
        }
        public void InActive()
        {
            Status = false;
        }
        public void Active()
        {
            Status = true;
        }
        public void Remove()
        {
            Deleted = true;
        }
        public void Reset()
        {
            Deleted = false;
        }
    }
}