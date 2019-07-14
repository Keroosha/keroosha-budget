using System;

namespace Budget.DB.Entities
{
    public class BudgetOperationItem
    {
        public Guid Id { get; set; }
        
        public decimal Cost { get; set; }
        
        public Guid BudgetActionId { get; set; }
        public BudgetAction BudgetAction { get; set; }
        
        public Guid OperationItemId { get; set; }
        public OperationItem OperationItem { get; set; }
    }
}