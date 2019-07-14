using System;
using System.Collections.Generic;

namespace Budget.DB.Entities
{
    public class BudgetAction
    {
        public Guid Id { get; set; }
        
        public List<BudgetOperationItem> BudgetOperationItems { get; set; } = new List<BudgetOperationItem>();
    }
}