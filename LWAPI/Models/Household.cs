using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LWAPI.Models
{
    public class Household
    {
        /// <summary>
        /// Household Id assigned by default
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Household name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Household description
        /// </summary>
        public string Decscription { get; set; }
        /// <summary>
        /// Created date set by default
        /// </summary>
        public DateTime Created { get; set; }
        /// <summary>
        /// Updated date set by default, nullable
        /// </summary>
        public DateTime? Updated { get; set; }
        /// <summary>
        /// Avatar picture for Household, nullable
        /// </summary>
        public string AvatarPath { get; set; }
        /// <summary>
        /// The total income for all members of the Household
        /// </summary>
        public Decimal IncomeAmount { get; set; }
        /// <summary>
        /// The current budget amount of the Household
        /// </summary>
        public Decimal? CurrentBudgetAmount { get; set; }
    }
}