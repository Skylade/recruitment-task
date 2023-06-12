using System.ComponentModel.DataAnnotations;

namespace Data.Entities
{
    public class BankAccount
    {
        [Key]
        public Guid Id { get; set; }
        public string? AccountNumber { get; set; }
    }
}
