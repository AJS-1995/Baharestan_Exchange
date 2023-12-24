using _0_Framework.Domain;

namespace Domin.ExpenseDomin
{
    public class Expense : EntityBase<long>
    {
        public string? Description { get; private set; }
        public int Collection_Id { get; private set; }
        public string? N_Invoice { get; private set; }
        public decimal Amount { get; private set; }
        public string? Date { get; private set; }
        public string? Ph_Invoice { get; private set; }
        public int Personnel_Id { get; private set; }
        public int SafeBox_Id { get; private set; }
        public int Money_Id { get; private set; }
        public Collection? Collection { get; private set; }
        protected Expense() { }
        public Expense(string? description, int collection_Id, string? n_Invoice, decimal amount, string? date, string? ph_Invoice, int personnel_Id, int safeBox_Id, int money_Id, int userid, int agenciesId)
        {
            Description = description;
            Collection_Id = collection_Id;
            N_Invoice = n_Invoice;
            Amount = amount;
            Date = date;
            Ph_Invoice = ph_Invoice;
            Personnel_Id = personnel_Id;
            SafeBox_Id = safeBox_Id;
            Money_Id = money_Id;
            UserId = userid;
            AgenciesId = agenciesId;
        }
        public void Edit(string? description, int collection_Id, string? n_Invoice, decimal amount, string? date, string? ph_Invoice, int personnel_Id, int safeBox_Id, int money_Id, int userid, int agenciesId)
        {
            Description = description;
            Collection_Id = collection_Id;
            N_Invoice = n_Invoice;
            Amount = amount;
            Date = date;
            Ph_Invoice = ph_Invoice;
            Personnel_Id = personnel_Id;
            SafeBox_Id = safeBox_Id;
            Money_Id = money_Id;
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