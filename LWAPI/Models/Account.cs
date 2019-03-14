using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LWAPI.Models
{
    public class Account
    {
        /// <summary>
        /// Account Id assigned by default
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Account name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// The initial balance of the account
        /// </summary>
        public Decimal InitialBalance { get; set; }
        /// <summary>
        /// The current balance of the account, set to initial by default
        /// </summary>
        public Decimal? CurrentBalance { get; set; }
        /// <summary>
        /// Reconciled balance, nullable
        /// </summary>
        public Decimal? ReconciledBalance { get; set; }
        /// <summary>
        /// Notification sent when account balance hits this mark
        /// </summary>
        public Decimal LowBalanceWarning { get; set; }
        /// <summary>
        /// Created date set by default
        /// </summary>
        public DateTime Created { get; set; }

        /// <summary>
        /// Household that account belongs in
        /// </summary>
        public int HouseholdId { get; set; }
    }
}