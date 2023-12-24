namespace Contracts.ExpenseContracts
{
    public class ExpenseViewModel
    {
        public long Id { get; set; }
        public string? Description { get; set; }
        public int CollectionId { get; set; }
        public string? CollectionName { get; set; }
        public string? N_Invoice { get; set; }
        public decimal Amount { get; set; }
        public string? Date { get; set; }
        public string? Ph_Invoice { get; set; }
        public int PersonnelId { get; set; }
        public string? PersonnelName { get; set; }
        public int SafeBoxId { get; set; }
        public string? SafeBoxName { get; set; }
        public int MoneyId { get; set; }
        public string? MoneyName { get; set; }
        public string? SaveDate { get; set; }
        public int UserId { get; set; }
        public string? UserName { get; set; }
        public bool Status { get; set; }
        public bool Deleted { get; set; }
    }
}
