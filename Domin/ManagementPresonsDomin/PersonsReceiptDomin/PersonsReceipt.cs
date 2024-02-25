using _0_Framework.Domain;
using Domin.AgenciesDomin;
using Domin.ManagementPresonsDomin.PersonsDomin;
using Domin.MoneyDomin;
using Domin.SafeBoxDomin;

namespace Domin.ManagementPresonsDomin.PersonsReceiptDomin
{
    public class PersonsReceipt : EntityBase<long>
    {
        public string? Date { get; private set; }
        public string? Description { get; private set; }
        public string? By { get; private set; }
        public string? ReceiptNumber { get; private set; }
        public bool Type { get; private set; }
        public decimal Amount { get; private set; }
        public int SafeBoxId { get; private set; }
        public int MoneyId { get; private set; }
        public int PersonsId { get; private set; }
        public string? Fingerprint { get; private set; }
        public string? Picture { get; private set; }
        public Persons? Persons { get; private set; }
        public Money? Moneys { get; private set; }
        public Agencies? Agenciess { get; private set; }
        public SafeBox? SafeBoxs { get; private set; }
        public PersonsReceipt() { }

        public PersonsReceipt(string? date, string? description, string? by, string? receiptNumber, bool type, decimal amount, int safeBoxId, int moneyId, int personsId, string? fingerprint, string? picture, int userid, int agenciesId)
        {
            Date = date;
            Description = description;
            By = by;
            ReceiptNumber = receiptNumber;
            Type = type;
            Amount = amount;
            SafeBoxId = safeBoxId;
            MoneyId = moneyId;
            PersonsId = personsId;
            Fingerprint = fingerprint;
            Picture = picture;
            UserId = userid;
            AgenciesId = agenciesId;
        }
        public void Edit(string? date, string? description, string? by, string? receiptNumber, bool type, decimal amount, int safeBoxId, int moneyId, int personsId, string? fingerprint, string? picture, int userid, int agenciesId)
        {
            Date = date;
            Description = description;
            By = by;
            ReceiptNumber = receiptNumber;
            Type = type;
            Amount = amount;
            SafeBoxId = safeBoxId;
            MoneyId = moneyId;
            PersonsId = personsId;
            if (!string.IsNullOrWhiteSpace(fingerprint))
                Fingerprint = fingerprint;
            if (!string.IsNullOrWhiteSpace(picture))
                Picture = picture;
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