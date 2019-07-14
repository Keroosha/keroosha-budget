using System.Collections.Generic;
using Budget.DB.Entities;
using Microsoft.EntityFrameworkCore;

namespace Budget.DB
{
    public class BudgetDbContext : DbContext
    {
        public List<Profile> Profiles = new List<Profile>();
        public List<ProfileBudget> ProfileBudgets = new List<ProfileBudget>();
        public List<ProfileSettings> ProfileSettingses = new List<ProfileSettings>();
        
        public List<BudgetAction> BudgetActions = new List<BudgetAction>();
        public List<BudgetOperationItem> BudgetOperationItems = new List<BudgetOperationItem>();
        
        public List<OperationItem> OperationItems = new List<OperationItem>();

        public BudgetDbContext(DbContextOptions<BudgetDbContext> options) : base(options)
        { }
    }
}