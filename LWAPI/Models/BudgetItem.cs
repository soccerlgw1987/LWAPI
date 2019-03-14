using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LWAPI.Models
{
    public class BudgetItem
    {
        /// <summary>
        /// Budget Item Id assigned by default
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Budget Item name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Budget Item targeted amount
        /// </summary>
        public Decimal DesiredAmount { get; set; }
        /// <summary>
        /// The current balance of the budget item
        /// </summary>
        public Decimal? CurrentAmount { get; set; }

        /// <summary>
        /// Budget that budget item belongs in
        /// </summary>
        public int BudgetId { get; set; }
    }
}