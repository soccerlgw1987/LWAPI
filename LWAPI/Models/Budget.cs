using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LWAPI.Models
{
    public class Budget
    {
        /// <summary>
        /// Budget Id assigned by default
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Budget name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Budget description
        /// </summary>
        public string Decscription { get; set; }
        /// <summary>
        /// Budget targeted amount
        /// </summary>
        public Decimal DesiredAmount { get; set; }
        /// <summary>
        /// The current balance of the budget
        /// </summary>
        public Decimal? CurrentAmount { get; set; }

        /// <summary>
        /// Household that budget belongs in
        /// </summary>
        public int HouseholdId { get; set; }
    }
}