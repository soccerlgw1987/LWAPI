using LWAPI.Enumerations;
using LWAPI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace LWAPI.Controllers
{
    
    /// <summary>
    /// Financial Portal Data
    /// </summary>
    [RoutePrefix("Api")]
    public class ValuesController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        //House
        /// <summary>
        /// Return a list of all households and their data
        /// </summary>
        /// <returns></returns>
        [Route("GetHouseholds")]
        public Task<List<Household>> GetHouseholds()
        {
            return db.GetHouseholds();
        }
        /// <summary>
        /// Return a list of all households and their data as Json
        /// </summary>
        /// <returns></returns>
        [Route("GetHouseholds/Json")]
        public async Task<IHttpActionResult> GetHouseholdsJson()
        {
            return Ok(JsonConvert.SerializeObject(await db.GetHouseholds()));
        }

        /// <summary>
        /// Return a specific households data based on household Id
        /// </summary>
        /// <param name="id">Type a Household Id</param>
        /// <returns></returns>
        [Route("GetHouseholdById")]
        public async Task<Household> GetHouseholdById(int id)
        {
            return await db.GetHouseholdById(id);
        }
        /// <summary>
        /// Return a specific households data based on household Id as Json
        /// </summary>
        /// <param name="id">Type a Household Id</param>
        /// <returns></returns>
        [Route("GetHouseholdById/Json")]
        public async Task<IHttpActionResult> GetHouseholdByIdJson(int id)
        {
            return Ok(JsonConvert.SerializeObject(await db.GetHouseholdById(id)));
        }

        /// <summary>
        /// Edit a current Household
        /// </summary>
        /// <param name="id">Enter the Household Id</param>
        /// <param name="name">Change Name of Household</param>
        /// <param name="description">Change Household Description</param>
        /// <param name="incomeamount">Change Income amount for Household</param>
        /// <returns></returns>
        [Route("EditHousehold")]
        [HttpPost]
        public async Task<int> EditHousehold(int id, string name, string description, decimal incomeamount)
        {
            return await db.EditHousehold(id, name, description, incomeamount);
        }
        /// <summary>
        /// Add an additional Household
        /// </summary>
        /// <param name="name">Name the Household</param>
        /// <param name="description">Add a description to welcome members</param>
        /// <param name="incomeamount">Type the total income amount for Household</param>
        /// <returns></returns>
        [Route("AddHousehold")]
        [HttpPost]
        public async Task<int> AddHousehold(string name, string description, decimal incomeamount)
        {
            return await db.AddHousehold(name, description, incomeamount);
        }
        /// <summary>
        /// Delete a current Household
        /// </summary>
        /// <param name="id">Enter the Household Id</param>
        /// <returns></returns>
        [Route("DeleteHousehold")]
        [HttpDelete]
        public async Task<int> DeleteHousehold(int id)
        {
            return await db.DeleteHousehold(id);
        }

        //Account
        /// <summary>
        /// Return a list of all accounts and their data
        /// </summary>
        /// <returns></returns>
        [Route("GetAccounts")]
        public Task<List<Account>> GetAccounts()
        {
            return db.GetAccounts();
        }
        /// <summary>
        /// Return a list of all accounts and their data as Json
        /// </summary>
        /// <returns></returns>
        [Route("GetAccounts/Json")]
        public async Task<IHttpActionResult> GetAccountsJson()
        {
            return Ok(JsonConvert.SerializeObject(await db.GetAccounts()));
        }

        /// <summary>
        /// Return a specific accounts data based on account Id
        /// </summary>
        /// <param name="id">Type an Account Id</param>
        /// <returns></returns>
        [Route("GetAccountDetails")]
        public async Task<Account> GetAccountDetails(int id)
        {
            return await db.GetAccountDetails(id);
        }
        /// <summary>
        /// Return a specific accounts data based on account Id as Json
        /// </summary>
        /// <param name="id">Type an Account Id</param>
        /// <returns></returns>
        [Route("GetAccountDetails/Json")]
        public async Task<IHttpActionResult> GetAccountDetailsJson(int id)
        {
            return Ok(JsonConvert.SerializeObject(await db.GetAccountDetails(id)));
        }

        /// <summary>
        /// Return a specific accounts data based on household Id
        /// </summary>
        /// <param name="householdid">Type a Household Id</param>
        /// <returns></returns>
        [Route("GetAccountByHouseholdId")]
        public async Task<Account> GetAccountByHouseholdId(int householdid)
        {
            return await db.GetAccountByHouseholdId(householdid);
        }
        /// <summary>
        /// Return a specific accounts data based on household Id as Json
        /// </summary>
        /// <param name="householdid">Type a Household Id</param>
        /// <returns></returns>
        [Route("GetAccountByHouseholdId/Json")]
        public async Task<IHttpActionResult> GetAccountByHouseholdIdJson(int householdid)
        {
            return Ok(JsonConvert.SerializeObject(await db.GetAccountByHouseholdId(householdid)));
        }

        /// <summary>
        /// Add an additional Account
        /// </summary>
        /// <param name="name">Name the Account</param>
        /// <param name="initialbalance">Type the starting balance</param>
        /// <param name="lowbalancewarning">Type the amount that you would like to be notified when reached</param>
        /// <param name="householdid">Assign a Household to the Account</param>
        /// <returns></returns>
        [Route("AddAccount")]
        [HttpPost]
        public async Task<int> AddAccount(string name, decimal initialbalance, decimal lowbalancewarning, int householdid)
        {
            return await db.AddAccount(name, initialbalance, lowbalancewarning, householdid);
        }

        //Budget
        /// <summary>
        /// Return a list of all budgets and their data
        /// </summary>
        /// <returns></returns>
        [Route("GetBudgets")]
        public Task<List<Budget>> GetBudgets()
        {
            return db.GetBudgets();
        }
        /// <summary>
        /// Return a list of all budgets and their data as Json
        /// </summary>
        /// <returns></returns>
        [Route("GetBudgets/Json")]
        public async Task<IHttpActionResult> GetBudgetsJson()
        {
            return Ok(JsonConvert.SerializeObject(await db.GetBudgets()));
        }

        /// <summary>
        /// Return a specific budgets data based on budget Id
        /// </summary>
        /// <param name="id">Type a Budget Id</param>
        /// <returns></returns>
        [Route("GetBudgetDetails")]
        public async Task<Budget> GetBudgetDetails(int id)
        {
            return await db.GetBudgetDetails(id);
        }
        /// <summary>
        /// Return a specific budgets data based on budget Id as Json
        /// </summary>
        /// <param name="id">Type a Budget Id</param>
        /// <returns></returns>
        [Route("GetBudgetDetails/Json")]
        public async Task<IHttpActionResult> GetBudgetDetailsJson(int id)
        {
            return Ok(JsonConvert.SerializeObject(await db.GetBudgetDetails(id)));
        }

        /// <summary>
        /// Return a specific budgets data based on household Id
        /// </summary>
        /// <param name="householdid">Type a Household Id</param>
        /// <returns></returns>
        [Route("GetBudgetsByHouseholdId")]
        public async Task<Budget> GetBudgetsByHouseholdId(int householdid)
        {
            return await db.GetBudgetsByHouseholdId(householdid);
        }
        /// <summary>
        /// Return a specific budgets data based on household Id as Json
        /// </summary>
        /// <param name="householdid">Type a Household Id</param>
        /// <returns></returns>
        [Route("GetBudgetsByHouseholdId/Json")]
        public async Task<IHttpActionResult> GetBudgetsByHouseholdIdJson(int householdid)
        {
            return Ok(JsonConvert.SerializeObject(await db.GetBudgetsByHouseholdId(householdid)));
        }

        /// <summary>
        /// Add an additional Budget
        /// </summary>
        /// <param name="name">Name the Budget</param>
        /// <param name="description">Provide additional info about the Budget</param>
        /// <param name="desiredamount">Set a target Budget amount</param>
        /// <param name="householdid">Assign a Household to the Budget</param>
        /// <returns></returns>
        [Route("AddBudget")]
        [HttpPost]
        public async Task<int> AddBudget(string name, string description, decimal desiredamount, int householdid)
        {
            return await db.AddBudget(name, description, desiredamount, householdid);
        }

        //BudgetItem
        /// <summary>
        /// Return a list of all budget items and their data
        /// </summary>
        /// <returns></returns>
        [Route("GetBudgetItems")]
        public Task<List<BudgetItem>> GetBudgetItems()
        {
            return db.GetBudgetItems();
        }
        /// <summary>
        /// Return a list of all budget items and their data as Json
        /// </summary>
        /// <returns></returns>
        [Route("GetBudgetItems/Json")]
        public async Task<IHttpActionResult> GetBudgetItemsJson()
        {
            return Ok(JsonConvert.SerializeObject(await db.GetBudgetItems()));
        }

        /// <summary>
        /// Return a specific budget items data based on budget item Id
        /// </summary>
        /// <param name="id">Type a Budget Item Id</param>
        /// <returns></returns>
        [Route("GetBudgetItemDetails")]
        public async Task<BudgetItem> GetBudgetItemDetails(int id)
        {
            return await db.GetBudgetItemDetails(id);
        }
        /// <summary>
        /// Return a specific budget items data based on budget item Id as Json
        /// </summary>
        /// <param name="id">Type a Budget Item Id</param>
        /// <returns></returns>
        [Route("GetBudgetItemDetails/Json")]
        public async Task<IHttpActionResult> GetBudgetItemDetailsJson(int id)
        {
            return Ok(JsonConvert.SerializeObject(await db.GetBudgetItemDetails(id)));
        }

        /// <summary>
        /// Return a specific budget items data based on budget Id
        /// </summary>
        /// <param name="budgetid">Type a Budget Id</param>
        /// <returns></returns>
        [Route("GetBudgetItemsByBudgetId")]
        public async Task<BudgetItem> GetBudgetItemsByBudgetId(int budgetid)
        {
            return await db.GetBudgetItemsByBudgetId(budgetid);
        }
        /// <summary>
        /// Return a specific budget items data based on budget Id as Json
        /// </summary>
        /// <param name="budgetid">Type a Budget Id</param>
        /// <returns></returns>
        [Route("GetBudgetItemsByBudgetId/Json")]
        public async Task<IHttpActionResult> GetBudgetItemsByBudgetIdJson(int budgetid)
        {
            return Ok(JsonConvert.SerializeObject(await db.GetBudgetItemsByBudgetId(budgetid)));
        }

        /// <summary>
        /// Add an additional Budget Item
        /// </summary>
        /// <param name="name">Name the Budget Item</param>
        /// <param name="desiredamount">Set a target Budget Item amount</param>
        /// <param name="budgetid">Assign a Budget to the Budget Item</param>
        /// <returns></returns>
        [Route("AddBudgetItem")]
        [HttpPost]
        public async Task<int> AddBudgetItem(string name, decimal desiredamount, int budgetid)
        {
            return await db.AddBudgetItem(name, desiredamount, budgetid);
        }

        //Transaction
        /// <summary>
        /// Return a list of all transactions and their data
        /// </summary>
        /// <returns></returns>
        [Route("GetTransactions")]
        public Task<List<Transaction>> GetTransactions()
        {
            return db.GetTransactions();
        }
        /// <summary>
        /// Return a list of all transactions and their data as Json
        /// </summary>
        /// <returns></returns>
        [Route("GetTransactions/Json")]
        public async Task<IHttpActionResult> GetTransactionsJson()
        {
            return Ok(JsonConvert.SerializeObject(await db.GetTransactions()));
        }

        /// <summary>
        /// Return a specific transactions data based on transaction Id
        /// </summary>
        /// <param name="id">Type a Transaction Id</param>
        /// <returns></returns>
        [Route("GetTransactionDetails")]
        public async Task<Transaction> GetTransactionDetails(int id)
        {
            return await db.GetTransactionDetails(id);
        }
        /// <summary>
        /// Return a specific transactions data based on transaction Id as Json
        /// </summary>
        /// <param name="id">Type a Transaction Id</param>
        /// <returns></returns>
        [Route("GetTransactionDetails/Json")]
        public async Task<IHttpActionResult> GetTransactionDetailsJson(int id)
        {
            return Ok(JsonConvert.SerializeObject(await db.GetTransactionDetails(id)));
        }

        /// <summary>
        /// Return a specific transactions data based on account Id
        /// </summary>
        /// <param name="accountid">Type an Account Id</param>
        /// <returns></returns>
        [Route("GetTransactionByAccountId")]
        public async Task<Transaction> GetTransactionByAccountId(int accountid)
        {
            return await db.GetTransactionDetails(accountid);
        }
        /// <summary>
        /// Return a specific transactions data based on account Id as Json
        /// </summary>
        /// <param name="accountid">Type an Account Id</param>
        /// <returns></returns>
        [Route("GetTransactionByAccountId/Json")]
        public async Task<IHttpActionResult> GetTransactionByAccountIdJson(int accountid)
        {
            return Ok(JsonConvert.SerializeObject(await db.GetTransactionByAccountId(accountid)));
        }

        /// <summary>
        /// Return a specific transactions data based on budget item Id
        /// </summary>
        /// <param name="budgetitemid">Type a Budget Item Id</param>
        /// <returns></returns>
        [Route("GetTransactionByBudgetItemId")]
        public async Task<Transaction> GetTransactionByBudgetItemId(int budgetitemid)
        {
            return await db.GetTransactionByBudgetItemId(budgetitemid);
        }
        /// <summary>
        /// Return a specific transactions data based on budget item Id as Json
        /// </summary>
        /// <param name="budgetitemid">Type a Budget Item Id</param>
        /// <returns></returns>
        [Route("GetTransactionByBudgetItemId/Json")]
        public async Task<IHttpActionResult> GetTransactionByBudgetItemIdJson(int budgetitemid)
        {
            return Ok(JsonConvert.SerializeObject(await db.GetTransactionByBudgetItemId(budgetitemid)));
        }

        /// <summary>
        /// Add an additional Transaction
        /// </summary>
        /// <param name="name">Name the Transaction</param>
        /// <param name="type">Select Deposit or Withdrawl</param>
        /// <param name="amount">Type the transaction amount</param>
        /// <param name="accountid">Assign a Account to the Transaction</param>
        /// <param name="budgetitemid">Assign a Budget Item to the Transaction, if needed</param>
        /// <param name="enteredbyid">Key a User Id</param>
        /// <returns></returns>
        [Route("AddTransaction")]
        [HttpPost]
        public async Task<int> AddTransaction(string name, TransactionType type, decimal amount, int accountid, int budgetitemid, string enteredbyid)
        {
            return await db.AddTransaction(name, type, amount, accountid, budgetitemid, enteredbyid);
        }
    }
}
