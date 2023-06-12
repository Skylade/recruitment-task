using System.ComponentModel.DataAnnotations;

namespace Data.Entities
{
    public class Representative
    {
        [Key]
        public Guid Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Nip { get; set; }
        public string? CompanyName { get; set; }
    }
}
