using System;
using System.Collections.Generic;

namespace Budget.DB.Entities
{
    public class ProfileBudget
    {
        public Guid Id { get; set; }

        public Guid ProfileId { get; set; }
        public Profile Profile { get; set; }
        
        public List<BudgetAction> BudgetActions { get; set; } = new List<BudgetAction>();
    }
}