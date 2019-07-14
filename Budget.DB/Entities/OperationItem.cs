using System;
using System.Collections.Generic;

namespace Budget.DB.Entities
{
    public class OperationItem
    {
        public Guid Id { get; set; }
        
        public string Name { get; set; }
        public string Description { get; set; }
        
        public List<BudgetOperationItem> BudgetOperationItems { get; set; } = new List<BudgetOperationItem>();
    }
}