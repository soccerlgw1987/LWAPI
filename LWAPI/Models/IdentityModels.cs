using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Security.Claims;
using System.Threading.Tasks;
using LWAPI.Enumerations;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;

namespace LWAPI.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }
        
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        //Household
        public async Task<List<Household>> GetHouseholds()
        {
            return await Database.SqlQuery<Household>("GetHouseholds").ToListAsync();
        }
        public async Task<Household> GetHouseholdById(int id)
        {
            return await Database.SqlQuery<Household>("GetHouseholdById @id",
                new SqlParameter("id", id)).FirstOrDefaultAsync();
        }
        public async Task<int> EditHousehold(int id, string name, string description, decimal incomeamount)
        {
            return await Database.ExecuteSqlCommandAsync("EditHousehold @id, @name, @description, @incomeamount",
                new SqlParameter("id", id),
                new SqlParameter("name", name),
                new SqlParameter("description", description),
                new SqlParameter("incomeamount", incomeamount));
        }
        public async Task<int> AddHousehold(string name, string description, decimal incomeamount)
        {
            return await Database.ExecuteSqlCommandAsync("AddHousehold @name, @description, @incomeamount",
                new SqlParameter("name", name),
                new SqlParameter("description", description),
                new SqlParameter("incomeamount", incomeamount));
        }
        public async Task<int> DeleteHousehold(int id)
        {
            return await Database.ExecuteSqlCommandAsync("DeleteHousehold @id",
                new SqlParameter("id", id));
        }

        //Account
        public async Task<List<Account>> GetAccounts()
        {
            return await Database.SqlQuery<Account>("GetAccounts").ToListAsync();
        }
        public async Task<Account> GetAccountDetails(int id)
        {
            return await Database.SqlQuery<Account>("GetAccountDetails @id",
                new SqlParameter("id", id)).FirstOrDefaultAsync();
        }
        public async Task<Account> GetAccountByHouseholdId(int householdid)
        {
            return await Database.SqlQuery<Account>("GetAccountByHouseholdId @householdid",
                new SqlParameter("householdid", householdid)).FirstOrDefaultAsync();
        }
        public async Task<int> AddAccount(string name, decimal initialbalance, decimal lowbalancewarning, int householdid)
        {
            return await Database.ExecuteSqlCommandAsync("AddAccount @name, @initialbalance, @lowbalancewarning, @householdid",
                new SqlParameter("name", name),
                new SqlParameter("initialbalance", initialbalance),
                new SqlParameter("lowbalancewarning", lowbalancewarning),
                new SqlParameter("householdid", householdid));
        }

        //Budget
        public async Task<List<Budget>> GetBudgets()
        {
            return await Database.SqlQuery<Budget>("GetBudgets").ToListAsync();
        }
        public async Task<Budget> GetBudgetDetails(int id)
        {
            return await Database.SqlQuery<Budget>("GetBudgetDetails @id",
                new SqlParameter("id", id)).FirstOrDefaultAsync();
        }
        public async Task<Budget> GetBudgetsByHouseholdId(int householdid)
        {
            return await Database.SqlQuery<Budget>("GetBudgetsByHouseholdId @householdid",
                new SqlParameter("householdid", householdid)).FirstOrDefaultAsync();
        }
        public async Task<int> AddBudget(string name, string description, decimal desiredamount, int householdid)
        {
            return await Database.ExecuteSqlCommandAsync("AddBudget @name, @description, @desiredamount, @householdid",
                new SqlParameter("name", name),
                new SqlParameter("description", description),
                new SqlParameter("desiredamount", desiredamount),
                new SqlParameter("householdid", householdid));
        }

        //BudgetItem
        public async Task<List<BudgetItem>> GetBudgetItems()
        {
            return await Database.SqlQuery<BudgetItem>("GetBudgetItems").ToListAsync();
        }
        public async Task<BudgetItem> GetBudgetItemDetails(int id)
        {
            return await Database.SqlQuery<BudgetItem>("GetBudgetItemDetails @id",
                new SqlParameter("id", id)).FirstOrDefaultAsync();
        }
        public async Task<BudgetItem> GetBudgetItemsByBudgetId(int budgetid)
        {
            return await Database.SqlQuery<BudgetItem>("GetBudgetItemsByBudgetId @budgetid",
                new SqlParameter("budgetid", budgetid)).FirstOrDefaultAsync();
        }
        public async Task<int> AddBudgetItem(string name, decimal desiredamount, int budgetid)
        {
            return await Database.ExecuteSqlCommandAsync("AddBudgetItem @name, @desiredamount, @budgetid",
                new SqlParameter("name", name),
                new SqlParameter("desiredamount", desiredamount),
                new SqlParameter("budgetid", budgetid));
        }

        //Transaction
        public async Task<List<Transaction>> GetTransactions()
        {
            return await Database.SqlQuery<Transaction>("GetTransactions").ToListAsync();
        }
        public async Task<Transaction> GetTransactionDetails(int id)
        {
            return await Database.SqlQuery<Transaction>("GetTransactionDetails @id",
                new SqlParameter("id", id)).FirstOrDefaultAsync();
        }
        public async Task<Transaction> GetTransactionByAccountId(int accountid)
        {
            return await Database.SqlQuery<Transaction>("GetTransactionByAccountId @accountid",
                new SqlParameter("accountid", accountid)).FirstOrDefaultAsync();
        }
        public async Task<Transaction> GetTransactionByBudgetItemId(int budgetitemid)
        {
            return await Database.SqlQuery<Transaction>("GetTransactionByBudgetItemId @budgetitemid",
                new SqlParameter("budgetitemid", budgetitemid)).FirstOrDefaultAsync();
        }
        public async Task<int> AddTransaction(string name, TransactionType type, decimal amount, int accountid, int budgetitemid, string enteredbyid)
        {
            return await Database.ExecuteSqlCommandAsync("AddTransaction @name, @type, @amount, @accountid, @budgetitemid, @enteredbyid",
                new SqlParameter("name", name),
                new SqlParameter("type", type),
                new SqlParameter("amount", amount),
                new SqlParameter("accountid", accountid),
                new SqlParameter("budgetitemid", budgetitemid),
                new SqlParameter("enteredbyid", enteredbyid));
        }

        public DbSet<Household> Households { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Budget> Budgets { get; set; }
        public DbSet<BudgetItem> BudgetItems { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
    }
}