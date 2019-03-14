using LWAPI.Enumerations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LWAPI.Models
{
    public class Transaction
    {
        /// <summary>
        /// Transaction Id assigned by default
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Transaction name
        /// </summary>
        public string Name { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public TransactionType Type { get; set; }
        /// <summary>
        /// Created date set by default
        /// </summary>
        public DateTime Created { get; set; }
        /// <summary>
        /// Updated date set by default, nullable
        /// </summary>
        public DateTime? Updated { get; set; }
        /// <summary>
        /// Amount of the transaction
        /// </summary>
        public Decimal Amount { get; set; }
        /// <summary>
        /// Transaction reconciled amount, nullable
        /// </summary>
        public Decimal? ReconciledAmount { get; set; }
        /// <summary>
        /// True or false, false by default
        /// </summary>
        public bool Reconciled { get; set; }

        /// <summary>
        /// Account that transaction belongs in
        /// </summary>
        public int AccountId { get; set; }
        /// <summary>
        /// Budget Item that transaction belongs in
        /// </summary>
        public int? BudgetItemId { get; set; }
        /// <summary>
        /// Who enters the transaction
        /// </summary>
        public string EnteredById { get; set; }
    }
}