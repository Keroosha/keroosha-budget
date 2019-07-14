# База данных

```mermaid
graph TD;

User(User)
Profile(Profile)
ProfileBudget(ProfileBudget)
ProfileSettings(ProfileSettings)

BudgetActions(BudgetActions)
BudgetOperationItems(BudgetOperationItems)

OperationItem(OperationItem)

subgraph User/Profile
    User --> |1:1| Profile 
end

subgraph ProfileSettings
    Profile --> |1:1| ProfileSettings
end

subgraph ProfileBudget
    Profile --> |1:1| ProfileBudget
    ProfileBudget --> |1:m| BudgetActions
    BudgetActions --> |1:m| BudgetOperationItems
end

subgraph OperationItems
    OperationItem --> |1:m| BudgetOperationItems
end
```