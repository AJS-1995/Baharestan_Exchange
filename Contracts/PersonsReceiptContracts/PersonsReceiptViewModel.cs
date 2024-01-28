namespace Contracts.PersonsReceiptContracts
{
    public class PersonsReceiptViewModel
    {
        public long Id { get; set; }
        public string? Date { get; set; }
        public string? Description { get; set; }
        public string? By { get; set; }
        public string? ReceiptNumber { get; set; }
        public bool Type { get; set; }
        public decimal Amount { get; set; }
        public int SafeBoxId { get; set; }
        public string? SafeBoxName { get; set; }
        public int MoneyId { get; set; }
        public string? MoneyName { get; set; }
        public int PersonId { get; set; }
        public string? PersonName { get; set; }
        public int AgenciesId { get; set; }
        public int IdAgencies { get; set; }
        public string? NameAgencies { get; set; }
        public string? SaveDate { get; set; }
        public int UserId { get; set; }
        public string? UserName { get; set; }
        public bool Status { get; set; }
        public bool Deleted { get; set; }
    }
}
