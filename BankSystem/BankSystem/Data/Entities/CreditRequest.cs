using System;
using System.ComponentModel.DataAnnotations;

namespace BankSystem.Models
{
    public class CreditRequest
    {
        [Key]
        public int Id { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public decimal Amount { get; set; }
        public string Status { get; set; } // Pending, Approved, Rejected
        public DateTime RequestDate { get; set; }
    }
}
