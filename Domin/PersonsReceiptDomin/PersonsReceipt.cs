using _0_Framework.Domain;
using Domin.PersonsDomin;

namespace Domin.PersonsReceiptDomin
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
        public int PersonId { get; private set; }
        public Persons? Personss { get; private set; }
        public PersonsReceipt() { }

        public PersonsReceipt(string? date, string? description, string? by, string? receiptNumber, bool type, decimal amount, int safeBoxId, int moneyId, int personId, int userid, int agenciesId)
        {
            Date = date;
            Description = description;
            By = by;
            ReceiptNumber = receiptNumber;
            Type = type;
            Amount = amount;
            SafeBoxId = safeBoxId;
            MoneyId = moneyId;
            PersonId = personId;
            UserId = userid;
            AgenciesId = agenciesId;
        }
        public void Edit(string? date, string? description, string? by, string? receiptNumber, bool type, decimal amount, int safeBoxId, int moneyId, int personId, int userid, int agenciesId)
        {
            Date = date;
            Description = description;
            By = by;
            ReceiptNumber = receiptNumber;
            Type = type;
            Amount = amount;
            SafeBoxId = safeBoxId;
            MoneyId = moneyId;
            PersonId = personId;
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