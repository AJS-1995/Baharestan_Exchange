﻿namespace Contracts.ExpenseContracts
{
    public class ExpenseRemoved
    {
        public List<ExpenseViewModel>? ExpenseRemoveds { get; set; }
        public int idAgencies { get; set; }
    }
}
