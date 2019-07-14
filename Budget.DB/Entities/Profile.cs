using System;

namespace Budget.DB.Entities
{
    public class Profile
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        
        public Guid ProfileBudgetId { get; set; }
        public ProfileBudget ProfileBudget { get; set; }
        
        public Guid ProfileSettingsId { get; set; }
        public ProfileSettings ProfileSettings { get; set; }
    }
}