using System;
using System.ComponentModel.DataAnnotations;

namespace BankSystem.Models
{
    public class CreditManagement
    {
        [Key]
        public int Id { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public decimal Amount { get; set; }
        public string Status { get; set; } // Active, Closed
        public DateTime ApprovalDate { get; set; }
    }
}
