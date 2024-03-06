using _0_Framework.Domain;
using Domin.ManagementExpenseDomin.ExpenseDomin;

namespace Domin.ManagementExpenseDomin.CollectionDomin
{
    public class Collection : EntityBase<int>
    {
        public string? Name { get; private set; }
        public string? Description { get; private set; }
        public List<Expense>? Expenses { get; }
        public Collection()
        {
            Expenses = new List<Expense>();
        }
        public Collection(string name, string description, int userid, int agenciesId)
        {
            Name = name;
            Description = description;
            UserId = userid;
            AgenciesId = agenciesId;
        }
        public void Edit(string name, string description, int userid, int agenciesId)
        {
            Name = name;
            Description = description;
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