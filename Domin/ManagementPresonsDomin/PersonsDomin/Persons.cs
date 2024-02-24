using _0_Framework.Domain;
using Domin.AgenciesDomin;
using Domin.ManagementPresonsDomin.LivelihoodDomin;
using Domin.ManagementPresonsDomin.PersonsMoneyExchangeDomin;
using Domin.ManagementPresonsDomin.PersonsReceiptDomin;

namespace Domin.ManagementPresonsDomin.PersonsDomin
{
    public class Persons : EntityBase<int>
    {
        public string? Name { get; private set; }
        public string? Mobile { get; private set; }
        public string? Address { get; private set; }
        public string? Company { get; private set; }
        public string? Guarantor { get; private set; }
        public string? ProfilePhoto { get; private set; }
        public bool Personnel { get; private set; }
        public string? UserName { get; private set; }
        public string? Password { get; private set; }
        public Agencies? Agenciess { get; private set; }
        public List<PersonsReceipt>? PersonsReceipts { get; }
        public List<PersonsMoneyExchange>? PersonsMoneyExchanges { get; }
        public List<Livelihood>? Livelihoods { get; }
        public Persons()
        {
            PersonsReceipts = new List<PersonsReceipt>();
            PersonsMoneyExchanges = new List<PersonsMoneyExchange>();
            Livelihoods = new List<Livelihood>();
        }
        public Persons(string? name, string? mobile, string? address, string? company, string? guarantor, string? profilePhoto, bool personnel, string username, string password, int userid, int agenciesId)
        {
            Name = name;
            Mobile = mobile;
            Address = address;
            Company = company;
            Guarantor = guarantor;
            ProfilePhoto = profilePhoto;
            Personnel = personnel;
            UserName = username;
            Password = password;
            UserId = userid;
            AgenciesId = agenciesId;
        }
        public void Edit(string? name, string? mobile, string? address, string? company, string? guarantor, string? profilePhoto, bool personnel, string username, int userid, int agenciesId)
        {
            Name = name;
            Mobile = mobile;
            Address = address;
            Company = company;
            Guarantor = guarantor;
            if (!string.IsNullOrWhiteSpace(ProfilePhoto))
                ProfilePhoto = profilePhoto;
            Personnel = personnel;
            UserName = username;
            UserId = userid;
            AgenciesId = agenciesId;
        }
        public void ChangePassword(string password)
        {
            Password = password;
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